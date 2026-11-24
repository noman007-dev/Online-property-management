using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class SellerViewProperty : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString);
        
        private int sellerID;
        private ImageList imageList = new ImageList();
        
        //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI";
        
        public SellerViewProperty(int sellerID)
        {
            InitializeComponent();
            this.sellerID = sellerID;
            LoadProperties();
            
        }

        private void LoadProperties()
        {
            listView1.Items.Clear();
            imageList.Images.Clear();
            imageList.ImageSize = new Size(100, 100);
            listView1.LargeImageList = imageList;
            //listView1.View = View.LargeIcon;

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                string query = "SELECT PropertyID, Title, Address, Price, Description, RentOrSell, Image FROM loginproperties WHERE SellerID = @SellerID AND Status = 'Available'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SellerID", sellerID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int propertyId = reader.GetInt32(0);
                            string title = reader.GetString(1);
                            string address = reader.GetString(2);
                            decimal price = reader.GetDecimal(3);
                            string description = reader.GetString(4);
                            string type = reader.GetString(5);
                            byte[] imageBytes = (byte[])reader["Image"];


                            Image propertyImage;
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                propertyImage = Image.FromStream(ms);
                            }


                            string key = propertyId.ToString();
                            if (propertyImage != null && !imageList.Images.ContainsKey(key))
                                imageList.Images.Add(key, propertyImage);


                            ListViewItem item = new ListViewItem($"{title}\nAddress: {address}\nPrice: {price} BDT\nDescription: {description}\nType: {type}");
                            item.ImageKey = key;
                            item.Tag = propertyId;
                            listView1.Items.Add(item);
                            
                        }
                    }
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SVPdeletebutton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a property to delete.");
                return;
            }

            // Get selected item
            ListViewItem selectedItem = listView1.SelectedItems[0];
            int propertyId = (int)selectedItem.Tag;

            // Confirm deletion
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this property?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "DELETE FROM loginproperties WHERE PropertyID = @PropertyID AND SellerID = @SellerID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PropertyID", propertyId);
                        command.Parameters.AddWithValue("@SellerID", sellerID);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Remove from listview UI
                            listView1.Items.Remove(selectedItem);
                            MessageBox.Show("Property deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete property.");
                        }
                    }
                }
            }
        }

        private void logoutbutton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void gotoaddbutton_Click(object sender, EventArgs e)
        {
            SellerAddPropertyForm sap = new SellerAddPropertyForm(sellerID);
            sap.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SellerProfileForm sp = new SellerProfileForm(sellerID);
            sp.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SellerHomePageForm shp = new SellerHomePageForm(sellerID);
            shp.Show();
            this.Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            SellerHistoryForm historyForm = new SellerHistoryForm(sellerID);
            historyForm.Show();
            this.Close();
        }

        private void btnviewmessage_Click(object sender, EventArgs e)
        {
            SellerMassageForm msgForm = new SellerMassageForm(sellerID);
            msgForm.Show();
            this.Close();
        }
    }
}
