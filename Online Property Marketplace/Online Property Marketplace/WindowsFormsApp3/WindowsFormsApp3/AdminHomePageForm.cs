using System;
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

namespace WindowsFormsApp3
{
    public partial class AdminHomePageForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString); 
        private int userID;
        private ImageList imageList = new ImageList();

        //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI"; 
        public AdminHomePageForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            LoadAdminStats();
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
                string query = @"SELECT PropertyID, Title, Address, Price, Description, RentOrSell, Image
                 FROM loginproperties
                 WHERE Status = 'Available'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SellerID", userID);
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

        private void LoadAdminStats()
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.connectionString))
            {
                conn.Open();

                // Total Properties
                SqlCommand cmdProperties = new SqlCommand("SELECT COUNT(*) FROM loginproperties", conn);
                int totalProperties = (int)cmdProperties.ExecuteScalar();

                // Total Sellers
                SqlCommand cmdSellers = new SqlCommand("SELECT COUNT(*) FROM logindata WHERE Role='Seller'", conn);
                int totalSellers = (int)cmdSellers.ExecuteScalar();

                // Total Buyers
                SqlCommand cmdBuyers = new SqlCommand("SELECT COUNT(*) FROM logindata WHERE Role='Buyer'", conn);
                int totalBuyers = (int)cmdBuyers.ExecuteScalar();

                // Total Transactions
                SqlCommand cmdTransactions = new SqlCommand("SELECT COUNT(*) FROM logintransactions", conn);
                int totalTransactions = (int)cmdTransactions.ExecuteScalar();

                // Show in Labels
                lblTotalProperties.Text = totalProperties.ToString();
                lblTotalSellers.Text = totalSellers.ToString();
                lblTotalBuyers.Text = totalBuyers.ToString();
                lblTotalTransactions.Text = totalTransactions.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            AdminManageUsersForm amu = new AdminManageUsersForm(userID);
            amu.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            AdminManagePropertyForm amp = new AdminManagePropertyForm(userID);
            amp.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminTransectionHistoryForm amu = new AdminTransectionHistoryForm(userID);
            amu.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminProfileForm ap = new AdminProfileForm(userID);
            ap.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            AdminUserGuideForm aug = new AdminUserGuideForm();
            aug.Show();
            
        }

        private void AdminHomePageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
