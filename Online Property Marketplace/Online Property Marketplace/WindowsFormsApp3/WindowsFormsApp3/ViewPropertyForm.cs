using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp3
{
    public partial class ViewPropertyForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString);
        
        private int userID;
        private ImageList sharedImageList;
        //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI";

        public ViewPropertyForm(int propertyId, ListViewItem item, ImageList imgList, int userID)
        {
            InitializeComponent();
            this.userID = userID;

            sharedImageList = imgList;
            listViewViewProperty.LargeImageList = sharedImageList;
            listViewViewProperty.View = View.LargeIcon;

           
            ListViewItem clonedItem = (ListViewItem)item.Clone();
            clonedItem.Tag = propertyId;

            listViewViewProperty.Items.Add(clonedItem);
        }

        private void ViewPropertyForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (listViewViewProperty.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a property to buy.");
                return;
            }

            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)
            {
                MessageBox.Show("Please select a payment method (Bikash / VISA / MasterCard / PayPal).");
                return;

            }

            int selectedPropertyId = (int)listViewViewProperty.SelectedItems[0].Tag;

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Fetch property details first
                    string getPropertyDetails = "SELECT Title, Address, Price, RentOrSell, SellerID FROM loginproperties WHERE PropertyID=@PropertyID";
                    SqlCommand cmdDetails = new SqlCommand(getPropertyDetails, connection, transaction);
                    cmdDetails.Parameters.AddWithValue("@PropertyID", selectedPropertyId);

                    string title = "";
                    string address = "";
                    decimal price = 0;
                    string type = "";
                    int sellerID = 0;

                    using (SqlDataReader reader = cmdDetails.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            title = reader["Title"].ToString();
                            address = reader["Address"].ToString();
                            price = Convert.ToDecimal(reader["Price"]);
                            type = reader["RentOrSell"].ToString();
                            sellerID = Convert.ToInt32(reader["SellerID"]);
                        }
                        else
                        {
                            throw new Exception("Property details not found.");
                        }
                    }

                    //  Update property status to Sold
                    string updateStatus = "UPDATE loginproperties SET Status='Sold' WHERE PropertyID=@PropertyID";
                    SqlCommand cmdStatus = new SqlCommand(updateStatus, connection, transaction);
                    cmdStatus.Parameters.AddWithValue("@PropertyID", selectedPropertyId);
                    cmdStatus.ExecuteNonQuery();

                    //  Insert into buyerproperties
                    string insertBuyerProp = "INSERT INTO buyerproperties (BuyerID, PropertyID, Status) VALUES (@BuyerID, @PropertyID, 'Bought')";
                    SqlCommand cmdBuyerProp = new SqlCommand(insertBuyerProp, connection, transaction);
                    cmdBuyerProp.Parameters.AddWithValue("@BuyerID", userID);
                    cmdBuyerProp.Parameters.AddWithValue("@PropertyID", selectedPropertyId);
                    cmdBuyerProp.ExecuteNonQuery();

                    //  Insert into logintransactions
                    string insertTransaction = @"
                    INSERT INTO logintransactions (BuyerID, PropertyID, Amount, SellerID, RentOrSell, TransactionDate)
                    VALUES (@BuyerID, @PropertyID, @Price, @SellerID, 'Sell', GETDATE())";
                    SqlCommand cmdTransaction = new SqlCommand(insertTransaction, connection, transaction);
                    cmdTransaction.Parameters.AddWithValue("@BuyerID", userID);
                    cmdTransaction.Parameters.AddWithValue("@PropertyID", selectedPropertyId);
                    cmdTransaction.Parameters.AddWithValue("@Price", price);
                    cmdTransaction.Parameters.AddWithValue("@SellerID", sellerID);
                    cmdTransaction.ExecuteNonQuery();

                    //  Remove from Wishlist if exists
                    string deleteWishlist = "DELETE FROM Wishlist WHERE BuyerID=@BuyerID AND PropertyID=@PropertyID";
                    SqlCommand cmdWishlist = new SqlCommand(deleteWishlist, connection, transaction);
                    cmdWishlist.Parameters.AddWithValue("@BuyerID", userID);
                    cmdWishlist.Parameters.AddWithValue("@PropertyID", selectedPropertyId);
                    cmdWishlist.ExecuteNonQuery();

                    
                    // Buyer notification
                    string insertBuyerNotif = "INSERT INTO Notifications (UserID, Message) VALUES (@UserID, @Message)";
                    SqlCommand cmdBuyerNotif = new SqlCommand(insertBuyerNotif, connection, transaction);
                    cmdBuyerNotif.Parameters.AddWithValue("@UserID", userID);
                    cmdBuyerNotif.Parameters.AddWithValue("@Message",
                        $"Purchase successful! Thank you for buying or renting {title}, Address: {address}, Price: {price} BDT, RentOrSell: {type}.");
                    cmdBuyerNotif.ExecuteNonQuery();

                    // Seller notification
                    string insertSellerNotif = "INSERT INTO Notifications (UserID, Message) VALUES (@UserID, @Message)";
                    SqlCommand cmdSellerNotif = new SqlCommand(insertSellerNotif, connection, transaction);
                    cmdSellerNotif.Parameters.AddWithValue("@UserID", sellerID);
                    cmdSellerNotif.Parameters.AddWithValue("@Message", $"Your property \"{title}\" has been sold!");
                    cmdSellerNotif.ExecuteNonQuery();

                    transaction.Commit();

                    string paymentMethod = "";
                    if (radioButton1.Checked) paymentMethod = "Bkash";
                    else if (radioButton2.Checked) paymentMethod = "VISA";
                    else if (radioButton3.Checked) paymentMethod = "MasterCard";
                    else if (radioButton4.Checked) paymentMethod = "PayPal";

                    MessageBox.Show($"Purchase successful! Payment method: {paymentMethod}");
                    this.Close();

                    
                    listViewViewProperty.Items.Remove(listViewViewProperty.SelectedItems[0]);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error occurred during purchase: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listViewViewProperty.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a property to delete.");
                return;
            }

            int selectedPropertyId = (int)listViewViewProperty.SelectedItems[0].Tag;

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                connection.Open();

               
                string deleteProperty = "DELETE FROM loginproperties WHERE PropertyID=@PropertyID AND Status IS NULL";
                SqlCommand cmdDelete = new SqlCommand(deleteProperty, connection);
                cmdDelete.Parameters.AddWithValue("@PropertyID", selectedPropertyId);
                cmdDelete.ExecuteNonQuery();
            }

            
            listViewViewProperty.Items.Remove(listViewViewProperty.SelectedItems[0]);
            MessageBox.Show("Property deleted successfully.");
        }

        private void listViewViewProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewViewProperty.SelectedItems.Count == 0)
                return;

            int selectedPropertyId = (int)listViewViewProperty.SelectedItems[0].Tag;

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                connection.Open();
                string query = @"
        SELECT p.Title, p.Address, p.Price, p.RentOrSell, p.SellerID, p.Status, c.CategoryName
        FROM loginproperties p
        LEFT JOIN logincategories c ON p.CategoryID = c.CategoryID
        WHERE p.PropertyID = @PropertyID";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PropertyID", selectedPropertyId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblTitle.Text =reader["Title"].ToString();
                        lblAddress.Text =reader["Address"].ToString();
                        lblPrice.Text =reader["Price"].ToString() + "\nBDT";
                        lblType.Text =reader["RentOrSell"].ToString();
                        lblCategory.Text =(reader["CategoryName"] == DBNull.Value ? "N/A" : reader["CategoryName"].ToString());
                    }
                }
            }
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }
    }
}
