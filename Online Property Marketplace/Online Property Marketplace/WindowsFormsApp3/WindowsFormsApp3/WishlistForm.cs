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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class WishlistForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString);
        
        private int userID;
        private int buyerID;
        private int propertyID;
        private ImageList imageList = new ImageList();

        //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI";
        public WishlistForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            LoadWishlistProperties();
        }

        private void LoadWishlistProperties()
        {
            listViewWishlist.Items.Clear();
            imageList.Images.Clear();
            imageList.ImageSize = new Size(100, 100);
            listViewWishlist.LargeImageList = imageList;
            listViewWishlist.View = View.LargeIcon;

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                string query = @"
                SELECT p.PropertyID, p.Title, p.Address, p.Price, p.Description, p.RentOrSell, p.Image
                FROM loginproperties p
                INNER JOIN Wishlist w ON p.PropertyID = w.PropertyID
                WHERE w.BuyerID = @BuyerID AND w.Status = 'Active' AND p.Status = 'Available'";


                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@BuyerID", userID);
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int propertyId = reader.GetInt32(0);
                            string title = reader.GetString(1);
                            string address = reader.GetString(2);
                            decimal price = reader.GetDecimal(3);
                            string description = reader.GetString(4);
                            string type = reader.GetString(5);
                            byte[] imageBytes = reader["Image"] as byte[];

                            Image propertyImage = null;
                            if (imageBytes != null && imageBytes.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    propertyImage = Image.FromStream(ms);
                                }
                            }

                            string key = propertyId.ToString();
                            if (propertyImage != null && !imageList.Images.ContainsKey(key))
                                imageList.Images.Add(key, propertyImage);

                            ListViewItem item = new ListViewItem($"{title}\nAddress: {address}\nPrice: {price:N0} BDT\nDescription: {description}\nType: {type}");
                            item.ImageKey = key;
                            item.Tag = propertyId;
                            listViewWishlist.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void WishlistForm_Load(object sender, EventArgs e)
        {

        }

        private void listViewWishlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listViewWishlist.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a property to delete.");
                return;
            }

            int propertyId = (int)listViewWishlist.SelectedItems[0].Tag;

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Wishlist WHERE BuyerID=@BuyerID AND PropertyID=@PropertyID";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@BuyerID", userID);
                    cmd.Parameters.AddWithValue("@PropertyID", propertyId);
                    cmd.ExecuteNonQuery();
                }
            }

            listViewWishlist.Items.Remove(listViewWishlist.SelectedItems[0]);
            MessageBox.Show("Property removed from wishlist.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listViewWishlist.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a property to view.");
                return;
            }

            ListViewItem selectedItem = listViewWishlist.SelectedItems[0];
            int propertyId = (int)selectedItem.Tag;

            // Delete from Wishlist first
            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Wishlist WHERE BuyerID=@BuyerID AND PropertyID=@PropertyID";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@BuyerID", userID);
                    cmd.Parameters.AddWithValue("@PropertyID", propertyId);
                    cmd.ExecuteNonQuery();
                }
            }

            // Open ViewPropertyForm with this property
            ViewPropertyForm viewForm = new ViewPropertyForm(propertyId, selectedItem, imageList, userID);
            viewForm.Show();

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BuyerProfileForm buyerProfileFrom = new BuyerProfileForm(userID);
            buyerProfileFrom.Show();
            this.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            BuyerHomePageForm buyerHomePageFrom = new BuyerHomePageForm(userID);
            buyerHomePageFrom.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BuyerMessageForm buyerMessageFrom = new BuyerMessageForm(userID,buyerID,propertyID);
            buyerMessageFrom.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuyerHistoryForm buyerHistoryFrom = new BuyerHistoryForm(userID);
            buyerHistoryFrom.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoginForm gotologin = new LoginForm();
            gotologin.Show();
            this.Close();
        }
    }
    
}
