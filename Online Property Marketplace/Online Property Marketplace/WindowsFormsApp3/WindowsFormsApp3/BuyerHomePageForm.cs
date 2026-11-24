using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class BuyerHomePageForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString);
        private int userID;
        private ImageList imageList = new ImageList();

        //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI";

        public BuyerHomePageForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;

            // Setup RentOrSell filter
            comboBox1.Items.Add("All");
            comboBox1.Items.Add("Sell");
            comboBox1.Items.Add("Rent");
            comboBox1.SelectedIndex = 0;

            LoadCategories();   // Fill category combobox2
            LoadProperties();
            LoadBuyerStats(userID);// Load all properties initially
        }
        private void LoadBuyerStats(int buyerId)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.connectionString))
            {
                conn.Open();

                // Wishlist count
                SqlCommand cmdWishlist = new SqlCommand(
                    "SELECT COUNT(*) FROM Wishlist WHERE BuyerID = @BuyerID", conn);
                cmdWishlist.Parameters.AddWithValue("@BuyerID", buyerId);
                int wishlistCount = (int)cmdWishlist.ExecuteScalar();

                // Total available properties
                SqlCommand cmdBought = new SqlCommand(
            "SELECT COUNT(*) FROM buyerproperties WHERE BuyerID = @BuyerID AND Status = 'Bought'", conn);
                cmdBought.Parameters.AddWithValue("@BuyerID", buyerId);
                int boughtCount = (int)cmdBought.ExecuteScalar();

                // Show on labels
                lblWishlist.Text = wishlistCount.ToString();
                lblAvailable.Text = boughtCount.ToString();
            }
        }
        private void LoadCategories()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "SELECT CategoryID, CategoryName FROM logincategories";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow dr = dt.NewRow();
                    dr["CategoryID"] = 0;
                    dr["CategoryName"] = "All";
                    dt.Rows.InsertAt(dr, 0);

                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "CategoryName";
                    comboBox2.ValueMember = "CategoryID";
                    comboBox2.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load categories: " + ex.Message);
            }
        }

        private void LoadProperties(string search = "", string rentOrSell = "All", int categoryId = 0)
        {
            listView1.Items.Clear();
            imageList.Images.Clear();
            imageList.ImageSize = new Size(100, 100);
            listView1.LargeImageList = imageList;
            listView1.View = View.LargeIcon;

            try
            {
                using (SqlConnection conn = new SqlConnection(DbConnection.connectionString))
                {
                    string query = @"SELECT PropertyID, Title, Address, Price, Description, RentOrSell, Image 
                                     FROM loginproperties 
                                     WHERE Status = 'Available'";

                    if (!string.IsNullOrEmpty(search))
                    {
                        query += @" AND (Title LIKE @Search OR Address LIKE @Search 
                                     OR Description LIKE @Search OR RentOrSell LIKE @Search 
                                     OR CAST(Price AS NVARCHAR(50)) LIKE @Search)";
                    }
                    if (rentOrSell != "All")
                    {
                        query += " AND RentOrSell = @Filter";
                    }
                    if (categoryId > 0)
                    {
                        query += " AND CategoryID = @CategoryID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        if (!string.IsNullOrEmpty(search))
                            cmd.Parameters.AddWithValue("@Search", "%" + search + "%");
                        if (rentOrSell != "All")
                            cmd.Parameters.AddWithValue("@Filter", rentOrSell);
                        if (categoryId > 0)
                            cmd.Parameters.AddWithValue("@CategoryID", categoryId);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int propertyId = reader.GetInt32(0);
                                string title = reader["Title"].ToString();
                                string address = reader["Address"].ToString();
                                decimal price = Convert.ToDecimal(reader["Price"]);
                                string description = reader["Description"].ToString();
                                string type = reader["RentOrSell"].ToString();

                                Image propertyImage = null;
                                if (!(reader["Image"] is DBNull))
                                {
                                    byte[] imageBytes = (byte[])reader["Image"];
                                    if (imageBytes.Length > 0)
                                    {
                                        using (MemoryStream ms = new MemoryStream(imageBytes))
                                        {
                                            propertyImage = Image.FromStream(ms);
                                        }
                                    }
                                }

                                string key = propertyId.ToString();
                                if (propertyImage != null && !imageList.Images.ContainsKey(key))
                                    imageList.Images.Add(key, propertyImage);

                                ListViewItem item = new ListViewItem($"{title}\nAddress: {address}\nPrice: {price:N0} BDT\nType: {type}\n{description}");
                                if (propertyImage != null)
                                    item.ImageKey = key;
                                item.Tag = propertyId;        
                                listView1.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading properties: " + ex.Message);
            }
        }

        private void btnAddToViewProperty_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = (ListViewItem)listView1.SelectedItems[0].Clone();
                int propertyId = (int)listView1.SelectedItems[0].Tag;

                ViewPropertyForm vp = new ViewPropertyForm(propertyId, selectedItem, imageList, userID);
                vp.Show();
            }
            else
            {
                MessageBox.Show("Please select a property first.");
            }
        }

        private void btnAddToWishlist_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int propertyId = (int)listView1.SelectedItems[0].Tag;

                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = @"
                INSERT INTO Wishlist (BuyerID, PropertyID)
                VALUES (@BuyerID, @PropertyID)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@BuyerID", userID);
                        cmd.Parameters.AddWithValue("@PropertyID", propertyId);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Property added to wishlist!");
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            BuyerHistoryForm history = new BuyerHistoryForm(userID);
            history.Show();
            this.Close();
        }

        private void btnwishlist_Click(object sender, EventArgs e)
        {

            // Open the wishlist page for this buyer
            WishlistForm w = new WishlistForm(userID);
            w.Show();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string search = textBox1.Text.Trim();
            string filter = comboBox1.SelectedItem.ToString();
            int categoryId = Convert.ToInt32(comboBox2.SelectedValue);
            LoadProperties(search, filter, categoryId);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string search = textBox1.Text.Trim();
            string filter = comboBox1.SelectedItem.ToString();
            int categoryId = 0;
            if (comboBox2.SelectedValue != null && int.TryParse(comboBox2.SelectedValue.ToString(), out int val))
            {
                categoryId = val;
            }
            LoadProperties(search, filter, categoryId);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string search = textBox1.Text.Trim();
            string filter = comboBox1.SelectedItem.ToString();
            int categoryId = Convert.ToInt32(comboBox2.SelectedValue);
            LoadProperties(search, filter, categoryId);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int buyerID = userID;
            NotificationForm notifForm = new NotificationForm(buyerID);
            notifForm.Show();
        }

        private void btnmessage_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int propertyId = (int)listView1.SelectedItems[0].Tag;

                // Get SellerID of this property
                int sellerId = 0;
                using (SqlConnection con = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "SELECT SellerID FROM loginproperties WHERE PropertyID=@PropertyID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PropertyID", propertyId);
                    con.Open();
                    sellerId = (int)cmd.ExecuteScalar();
                }

                BuyerMessageForm bm = new BuyerMessageForm(userID, sellerId, propertyId);
                bm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a property first.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuyerProfileForm buyerProfileFrom = new BuyerProfileForm(userID);
            buyerProfileFrom.Show();
            this.Close();

        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            LoginForm gotologin = new LoginForm();
            gotologin.Show();
            this.Close();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            BuyerProfileForm buyerProfileFrom = new BuyerProfileForm(userID);
            buyerProfileFrom.Show();
            this.Close();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            string search = textBox1.Text.Trim();
            string filter = comboBox1.SelectedItem.ToString();
            int categoryId = Convert.ToInt32(comboBox2.SelectedValue);

            LoadProperties(search, filter, categoryId);

           
            LoadBuyerStats(userID);

            MessageBox.Show("Buyer page reloaded!");
        }

        private void btnBuyerGuide_Click(object sender, EventArgs e)
        {
            BuyerUserGuideForm buyerGuideForm = new BuyerUserGuideForm();
            buyerGuideForm.Show(); ;
        }
    }
}
