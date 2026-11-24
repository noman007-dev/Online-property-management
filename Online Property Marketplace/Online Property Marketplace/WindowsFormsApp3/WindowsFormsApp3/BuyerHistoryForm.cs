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
    public partial class BuyerHistoryForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString);
        private int userID;
        private int buyerID;
        private int propertyID;
        private ImageList imageList = new ImageList();
        //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI"; 
        public BuyerHistoryForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;

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
                SELECT t.TransactionID, p.PropertyID, p.Title, p.Address, p.Price, p.Description, p.RentOrSell, p.Image, t.TransactionDate
                FROM logintransactions t
                JOIN loginproperties p ON t.PropertyID = p.PropertyID
                WHERE t.BuyerID = @BuyerID";


                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@BuyerID", userID);
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int propertyId = reader.GetInt32(reader.GetOrdinal("PropertyID"));
                            string title = reader["Title"].ToString();
                            string address = reader["Address"].ToString();
                            decimal price = (decimal)reader["Price"];
                            string description = reader["Description"]?.ToString() ?? "";
                            string type = reader["RentOrSell"].ToString();
                            byte[] imageBytes = reader["Image"] as byte[];
                            DateTime date = (DateTime)reader["TransactionDate"];

                            Image propertyImage = null;
                            if (imageBytes != null && imageBytes.Length > 0)
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                    propertyImage = Image.FromStream(ms);

                            string key = propertyId.ToString();
                            if (propertyImage != null && !imageList.Images.ContainsKey(key))
                                imageList.Images.Add(key, propertyImage);

                            ListViewItem item = new ListViewItem(
                                $"{title}\nAddress: {address}\nPrice: {price:N0} BDT\nDescription: {description}\nType: {type}\nBought On: {date}"
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

        private void BuyerHistoryForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuyerProfileForm buyerProfileFrom = new BuyerProfileForm(userID);
            buyerProfileFrom.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuyerHomePageForm buyerHomePageFrom = new BuyerHomePageForm(userID);
            buyerHomePageFrom.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WishlistForm buyerWishlist = new WishlistForm(userID);
            buyerWishlist.Show();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BuyerMessageForm buyerMessageFrom = new BuyerMessageForm(userID,buyerID,propertyID);
            buyerMessageFrom.Show();
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoginForm gotologin = new LoginForm();
            gotologin.Show();
            this.Close();

        }

        private void lblTotalProperties_Click(object sender, EventArgs e)
        {

        }
    }
}
