using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class BuyerMessageForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString);
        //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI";

        int buyerID;
        int sellerID;
        int propertyID;

        public BuyerMessageForm(int buyerID, int sellerID, int propertyID)
        {
            InitializeComponent();
            this.buyerID = buyerID;
            this.sellerID = sellerID;
            this.propertyID = propertyID;
            LoadMessages_Buyer();
        }

        private void LoadMessages_Buyer()
        {
            richTextBox1.Clear();

            using (SqlConnection con = new SqlConnection(DbConnection.connectionString))
            {
                string query = "SELECT BuyerID, MessageText FROM Messages " +
                               "WHERE PropertyID=@PropertyID AND " +
                               "((BuyerID=@BuyerID AND SellerID=@SellerID) OR " +
                               "(BuyerID=@SellerID AND SellerID=@BuyerID)) " +
                               "ORDER BY MessageID ASC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BuyerID", buyerID);
                cmd.Parameters.AddWithValue("@SellerID", sellerID);
                cmd.Parameters.AddWithValue("@PropertyID", propertyID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string msg = dr["MessageText"].ToString();
                    bool isBuyer = Convert.ToInt32(dr["BuyerID"]) == buyerID;
                    AddMessage(msg, isBuyer);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // Add message to RichTextBox
        private void AddMessage(string message, bool isBuyer)
        {
            richTextBox1.SelectionColor = isBuyer ? Color.Blue : Color.Green;
            string prefix = isBuyer ? "You: " : "Seller: ";
            richTextBox1.AppendText(prefix + message + Environment.NewLine);
            richTextBox1.ScrollToCaret();
        }

        // Send button click
        private void button1_Click(object sender, EventArgs e)
        {
            string msg = textBox1.Text.Trim();
            if (msg == "") return;

            using (SqlConnection con = new SqlConnection(DbConnection.connectionString))
            {
                string query = "INSERT INTO Messages (BuyerID, SellerID, PropertyID, MessageText) " +
                               "VALUES (@BuyerID, @SellerID, @PropertyID, @MessageText)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BuyerID", buyerID);
                cmd.Parameters.AddWithValue("@SellerID", sellerID);
                cmd.Parameters.AddWithValue("@PropertyID", propertyID);
                cmd.Parameters.AddWithValue("@MessageText", msg);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            AddMessage(msg, true);
            textBox1.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BuyerProfileForm buyerProfileFrom = new BuyerProfileForm(buyerID);
            buyerProfileFrom.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuyerHomePageForm buyerHomePageFrom = new BuyerHomePageForm(buyerID);
            buyerHomePageFrom.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WishlistForm buyerWishlist = new WishlistForm(buyerID);
            buyerWishlist.Show();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BuyerHistoryForm buyerHistoryFrom = new BuyerHistoryForm(buyerID);
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
