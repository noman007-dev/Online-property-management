using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class SellerMassageForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString);
        //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI";

        private int sellerID;
        private int propertyID;
        private int buyerID;

        public SellerMassageForm(int sellerID)
        {
            InitializeComponent();
            this.sellerID = sellerID;

            // Get the latest property & buyer that messaged the seller
            LoadLatestConversation();

            // Load messages if a buyer exists
            if (buyerID != 0 && propertyID != 0)
                LoadMessages();
            else
                MessageBox.Show("No messages from buyers yet.");
        }

        private void LoadLatestConversation()
        {
            using (SqlConnection con = new SqlConnection(DbConnection.connectionString))
            {
                string query = @"
                    SELECT TOP 1 PropertyID, BuyerID 
                    FROM Messages
                    WHERE SellerID=@SellerID
                    ORDER BY MessageID DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SellerID", sellerID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    propertyID = Convert.ToInt32(dr["PropertyID"]);
                    buyerID = Convert.ToInt32(dr["BuyerID"]);
                }
            }
        }

        // Load all messages between this buyer and seller
        private void LoadMessages()
        {
            richTextBox1.Clear();

            using (SqlConnection con = new SqlConnection(DbConnection.connectionString))
            {
                string query = @"
                    SELECT BuyerID, MessageText
                    FROM Messages
                    WHERE PropertyID=@PropertyID AND
                    ((BuyerID=@BuyerID AND SellerID=@SellerID) OR
                     (BuyerID=@SellerID AND SellerID=@BuyerID))
                    ORDER BY MessageID ASC";

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

        private void SellerMassageForm_Load(object sender, EventArgs e)
        {
            
        }

        private void AddMessage(string message, bool isBuyer)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionColor = isBuyer ? Color.Blue : Color.Green;
            string prefix = isBuyer ? "Buyer: " : "You: ";
            richTextBox1.AppendText(prefix + message + Environment.NewLine);
            richTextBox1.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = textBoxMessage.Text.Trim();
            if (msg == "" || buyerID == 0) return;

            using (SqlConnection con = new SqlConnection(DbConnection.connectionString))
            {
                string query = @"
                    INSERT INTO Messages (BuyerID, SellerID, PropertyID, MessageText)
                    VALUES (@BuyerID, @SellerID, @PropertyID, @MessageText)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BuyerID", buyerID);
                cmd.Parameters.AddWithValue("@SellerID", sellerID);
                cmd.Parameters.AddWithValue("@PropertyID", propertyID);
                cmd.Parameters.AddWithValue("@MessageText", msg);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            AddMessage(msg, false); // Seller message
            textBoxMessage.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            SellerHistoryForm historyForm = new SellerHistoryForm(sellerID);
            historyForm.Show();
            this.Close();
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

        private void button3_Click(object sender, EventArgs e)
        {
            SellerHomePageForm shp = new SellerHomePageForm(sellerID);
            shp.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SellerProfileForm sp = new SellerProfileForm(sellerID);
            sp.Show();
            this.Close();
        }
    }
}
