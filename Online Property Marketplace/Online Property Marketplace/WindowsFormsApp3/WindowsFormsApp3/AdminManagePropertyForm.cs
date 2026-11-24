using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class AdminManagePropertyForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString);
        
        private int userID;
        //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI";
        public AdminManagePropertyForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            string[] role = new string[3];
            role[0] = "All"; 
            role[1] = "Rent";
            role[2] = "Sell";
            
            comboBox1.DataSource = role;
            string query = "SELECT PropertyID, SellerID, CategoryID, Title, Address, Price, RentOrSell, Description, Status FROM loginproperties";
            FillDataGridView(query);
        }

        private void FillDataGridView(string query)
        {
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

            string query = "SELECT PropertyID, SellerID, CategoryID, Title, Address, Price, RentOrSell, Description, Status FROM loginproperties";

            if (selectedRole != "All")
            {
                query += " WHERE RentOrSell = @RentOrSell";
            }

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


        

        private void searchbutton_Click(object sender, EventArgs e)
        {
            string searchValue = searchtextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT PropertyID, SellerID, CategoryID, Title, Address, Price, RentOrSell, Description, Status 
                 FROM loginproperties WHERE
                       (PropertyID LIKE @searchTerm 
                        OR SellerID LIKE @searchTerm 
                        OR CategoryID LIKE @searchTerm 
                        OR Title LIKE @searchTerm 
                        OR Address LIKE @searchTerm 
                        OR Price LIKE @searchTerm 
                        OR RentOrSell LIKE @searchTerm 
                        OR Description LIKE @searchTerm
                        OR Status LIKE @searchTerm)";


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

        private void addbutton_Click(object sender, EventArgs e)
        {
           
            AdminAddUserForm aau = new AdminAddUserForm(userID);
            aau.Show();
            this.Close();
        }

        private void deletebutton_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a property to delete.");
                return;
            }

            int selectedPropertyId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                connection.Open();

                // 1. Check if the property is already sold
                string checkQuery = "SELECT COUNT(*) FROM buyerproperties WHERE PropertyID = @PropertyID";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@PropertyID", selectedPropertyId);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("This property is already sold. You cannot delete it.",
                                        "Delete Restricted",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 2. Confirm delete
                if (MessageBox.Show("Are you sure you want to delete this property?",
                                    "Confirm Delete",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = "DELETE FROM loginproperties WHERE PropertyID = @PropertyID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PropertyID", selectedPropertyId);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Property deleted successfully.");
                        else
                            MessageBox.Show("Delete failed. PropertyID not found.");
                    }

                    // Refresh DataGridView
                    string role = comboBox1.SelectedItem.ToString();
                    string queryRefresh = "SELECT PropertyID, SellerID, CategoryID, Title, Address, Price, RentOrSell, Description, Status FROM loginproperties";
                    if (role != "All")
                        queryRefresh += " WHERE RentOrSell = @RentOrSell";

                    using (SqlCommand command = new SqlCommand(queryRefresh, connection))
                    {
                        if (role != "All")
                            command.Parameters.AddWithValue("@RentOrSell", role);

                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void ucbutton_Click(object sender, EventArgs e)
        {
            
            AdminUpdateCategoryForm auc = new AdminUpdateCategoryForm(userID);
            auc.Show();
            this.Close();
        }

        private void searchtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
        
            AdminProfileForm ap = new AdminProfileForm(userID);
            ap.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
         
            AdminTransectionHistoryForm amu = new AdminTransectionHistoryForm(userID);
            amu.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Close();
        }

        private void AdminManagePropertyForm_Load(object sender, EventArgs e)
        {

        }
    }
}
