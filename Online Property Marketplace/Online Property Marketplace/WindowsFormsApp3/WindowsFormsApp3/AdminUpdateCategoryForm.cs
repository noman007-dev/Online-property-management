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
    public partial class AdminUpdateCategoryForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString); 
        private int userID;
        //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI"; 
        public AdminUpdateCategoryForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            
            FillDataGridView();
        }

        private void FillDataGridView()
        {
            string query = "SELECT * FROM logincategories"; 
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

            string query = @"SELECT CategoryID, CategoryName 
                 FROM logincategories WHERE
                       (CategoryID LIKE @searchTerm 
                        OR CategoryName LIKE @searchTerm)";


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
                MessageBox.Show("Please select a category to delete.");
                return;
            }

            
            int selectedCategoryId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            if (MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = @"
                        DELETE FROM logincategories
                        WHERE CategoryID = @CategoryID
                        AND NOT EXISTS (
                        SELECT 1 FROM loginproperties WHERE CategoryID = @CategoryID
                        )";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", selectedCategoryId);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category deleted successfully.");
                            FillDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Delete failed. This category is still assigned to some properties.");
                        }
                            
                    }
                }

                
            }
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            string newcategory = textBox1.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(newcategory))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
      
            string query = "INSERT INTO logincategories (CategoryName) VALUES (@CategoryName)";
           
            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", newcategory);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillDataGridView();

                    }
                    else
                    {
                        MessageBox.Show("Failed to add the category. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
       
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminManagePropertyForm amp = new AdminManagePropertyForm(userID);
            amp.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminProfileForm ap = new AdminProfileForm(userID);
            ap.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminHomePageForm ahp = new AdminHomePageForm(userID);
            ahp.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
