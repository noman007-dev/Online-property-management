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
    public partial class SellerHistoryForm : Form
    {
        private int sellerID;
        private ImageList imageList = new ImageList();
        public SellerHistoryForm(int sellerID)
        {
            InitializeComponent();
            this.sellerID = sellerID;

            imageList.ImageSize = new Size(100, 100);
            listViewHistory.LargeImageList = imageList;
            listViewHistory.View = View.LargeIcon;

            LoadHistory();
        }
        private void LoadHistory()
        {
            listViewHistory.Items.Clear();
            imageList.Images.Clear();

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                string query = @"
                SELECT t.TransactionID, p.PropertyID, p.Title, p.Address, p.Price, p.Description, p.RentOrSell, p.Image, t.TransactionDate, t.BuyerID
                FROM logintransactions t
                JOIN loginproperties p ON t.PropertyID = p.PropertyID
                WHERE p.SellerID = @SellerID
                ORDER BY t.TransactionDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SellerID", sellerID);
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int propertyId = (int)reader["PropertyID"];
                            string title = reader["Title"].ToString();
                            string address = reader["Address"].ToString();
                            decimal price = (decimal)reader["Price"];
                            string description = reader["Description"]?.ToString() ?? "";
                            string type = reader["RentOrSell"].ToString();
                            byte[] imageBytes = reader["Image"] as byte[];
                            DateTime date = (DateTime)reader["TransactionDate"];
                            int buyerId = (int)reader["BuyerID"];

                            Image propertyImage = null;
                            if (imageBytes != null && imageBytes.Length > 0)
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                    propertyImage = Image.FromStream(ms);

                            string key = propertyId.ToString();
                            if (propertyImage != null && !imageList.Images.ContainsKey(key))
                                imageList.Images.Add(key, propertyImage);

                            ListViewItem item = new ListViewItem(
                                $"{title}\nAddress: {address}\nPrice: {price:N0} BDT\nDescription: {description}\nType: {type}\nSold On: {date}\nBuyerID: {buyerId}"
                            );
                            item.ImageKey = key;
                            listViewHistory.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnviewmessage_Click(object sender, EventArgs e)
        {
            SellerMassageForm msgForm = new SellerMassageForm(sellerID);
            msgForm.Show();
        }

        private void viewpropertybutton_Click(object sender, EventArgs e)
        {
            SellerViewProperty f4 = new SellerViewProperty(sellerID);
            f4.Show();
            this.Close();
        }

        private void gotoaddbutton_Click(object sender, EventArgs e)
        {
            SellerAddPropertyForm sap = new SellerAddPropertyForm(sellerID);
            sap.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SellerHomePageForm shp = new SellerHomePageForm(sellerID);
            shp.Show();
            this.Close();
        }

        private void logoutbutton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SellerProfileForm sp = new SellerProfileForm(sellerID);
            sp.Show();
            this.Close();
        }
    }
}
