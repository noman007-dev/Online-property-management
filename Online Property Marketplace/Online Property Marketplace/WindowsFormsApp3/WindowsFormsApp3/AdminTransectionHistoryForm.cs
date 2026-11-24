using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class AdminTransectionHistoryForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString); 
        private int userID; 
        //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI";
        public AdminTransectionHistoryForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            string[] role = new string[3];
            role[0] = "All";
            role[1] = "Rent";
            role[2] = "Sell";

            comboBox1.DataSource = role;

            FillDataGridView();
            
        }

        private void FillDataGridView()
        {
            string query = "SELECT   t.TransactionID, b.Id AS BuyerID, b.Name AS BuyerName, s.Id AS SellerID, s.Name AS SellerName, p.PropertyID, p.Title AS PropertyTitle, p.Price AS TransactionAmount, p.RentOrSell FROM logintransactions t JOIN logindata b ON t.BuyerID = b.Id JOIN logindata s ON t.SellerID = s.Id JOIN loginproperties p ON t.PropertyID = p.PropertyID ORDER BY t.TransactionID DESC;";
            using (SqlConnection con = new SqlConnection(DbConnection.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                }
            }

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = comboBox1.SelectedItem.ToString();

            string query = @"
SELECT t.TransactionID,
       b.Id AS BuyerID, b.Name AS BuyerName,
       s.Id AS SellerID, s.Name AS SellerName,
       p.PropertyID, p.Title AS PropertyTitle,
       p.Price AS TransactionAmount,
       p.RentOrSell
FROM logintransactions t
JOIN logindata b ON t.BuyerID = b.Id
JOIN logindata s ON t.SellerID = s.Id
JOIN loginproperties p ON t.PropertyID = p.PropertyID
";

            if (selectedRole != "All")
            {
                query += " WHERE p.RentOrSell = @RentOrSell"; // add WHERE before ORDER BY
            }

            query += " ORDER BY t.TransactionID DESC"; // add ORDER BY at the end

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (selectedRole != "All")
                    {
                        command.Parameters.AddWithValue("@RentOrSell", selectedRole);
                    }

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void AdminUpdateCategoryForm_Load(object sender, EventArgs e)
        {

        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            string searchValue = searchtextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT 
                        t.TransactionID,
                        b.Id AS BuyerID, b.Name AS BuyerName, 
                        s.Id AS SellerID, s.Name AS SellerName, 
                        p.PropertyID, p.Title AS PropertyTitle, 
                        p.Price AS TransactionAmount, 
                        p.RentOrSell
                    FROM logintransactions t
                    JOIN logindata b ON t.BuyerID = b.Id
                    JOIN logindata s ON t.SellerID = s.Id
                    JOIN loginproperties p ON t.PropertyID = p.PropertyID
                    WHERE (b.Name LIKE @searchTerm 
                           OR s.Name LIKE @searchTerm 
                           OR p.Title LIKE @searchTerm 
                           OR CAST(b.Id AS NVARCHAR) LIKE @searchTerm
                           OR CAST(s.Id AS NVARCHAR) LIKE @searchTerm
                           OR CAST(p.PropertyID AS NVARCHAR) LIKE @searchTerm)
                    ORDER BY t.TransactionID DESC;";

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchTerm", "%" + searchValue + "%");
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No matching rows found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to delete.");
                return;
            }

            int selectedTransactionId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value); // first column must be TransactionID

            if (MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "DELETE FROM logintransactions WHERE TransactionID = @TransactionID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionId);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Transaction deleted successfully.");
                        else
                            MessageBox.Show("Delete failed. TransactionID not found.");
                    }
                }

                // Refresh grid
                FillDataGridView();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminProfileForm ap = new AdminProfileForm(userID);
            ap.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            AdminHomePageForm ahp = new AdminHomePageForm(userID);
            ahp.Show();
            this.Close();
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

        private void button5_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Close();
        }

        private void deletebutton_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to delete.");
                return;
            }

            int selectedTransactionId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value); // first column must be TransactionID

            if (MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "DELETE FROM logintransactions WHERE TransactionID = @TransactionID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", selectedTransactionId);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Transaction deleted successfully.");
                        else
                            MessageBox.Show("Delete failed. TransactionID not found.");
                    }
                }

                // Refresh grid
                FillDataGridView();
            }
        }

        private void AdminTransectionHistoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
