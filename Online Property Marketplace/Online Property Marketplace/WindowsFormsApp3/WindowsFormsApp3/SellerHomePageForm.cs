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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class SellerHomePageForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString);
        
        private int sellerID;
        private ImageList imageList = new ImageList();

        public SellerHomePageForm(int sellerID)
        {
            InitializeComponent();
            this.sellerID = sellerID;
            LoadProperties();
        }

        private void SellerHomePageForm_Load(object sender, EventArgs e)
        {
            LoadSellerStats(sellerID);
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

        private void LoadSellerStats(int sellerId)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.connectionString))
            {
                conn.Open();

                // Total properties
                SqlCommand cmdTotal = new SqlCommand(
                    "SELECT COUNT(*) FROM loginproperties WHERE SellerID = @SellerID", conn);
                cmdTotal.Parameters.AddWithValue("@SellerID", sellerId);
                int total = (int)cmdTotal.ExecuteScalar();

                // Sold properties
                SqlCommand cmdSold = new SqlCommand(
                    @"SELECT COUNT(*) 
                    FROM logintransactions t
                    INNER JOIN loginproperties p ON t.propertyID = p.PropertyID
                    WHERE p.SellerID = @SellerID", conn);
                
                cmdSold.Parameters.AddWithValue("@SellerID", sellerId);
                int sold = (int)cmdSold.ExecuteScalar();

                // Active properties
                int active = total - sold;

                // Show on labels
                lblTotal.Text = total.ToString();
                lblActive.Text = active.ToString();
                lblSold.Text = sold.ToString();
            }
        }

        private void gotoaddbutton_Click(object sender, EventArgs e)
        {
            SellerAddPropertyForm sap = new SellerAddPropertyForm(sellerID);
            sap.Show();
            this.Close();
        }

        private void logoutbutton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void viewpropertybutton_Click(object sender, EventArgs e)
        {
            SellerViewProperty f4 = new SellerViewProperty(sellerID);
            f4.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SellerProfileForm sp = new SellerProfileForm(sellerID);
            sp.Show();
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NotificationForm notifForm = new NotificationForm(sellerID);
            notifForm.Show();
            
        }

        private void btnviewmessage_Click(object sender, EventArgs e)
        {
            SellerMassageForm msgForm = new SellerMassageForm(sellerID);
            msgForm.Show();
            this.Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            SellerHistoryForm historyForm = new SellerHistoryForm(sellerID);
            historyForm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SellerUserGuideForm sellerGuideForm = new SellerUserGuideForm();
            sellerGuideForm.Show();
            
        }
    }
}
