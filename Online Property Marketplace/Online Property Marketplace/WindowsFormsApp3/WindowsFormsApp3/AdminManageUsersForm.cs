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
    public partial class AdminManageUsersForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString);
        private int userID;
        //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI";
        public AdminManageUsersForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            string[] role = new string[3];
            role[0] = "All";
            role[1] = "Buyer";
            role[2] = "Seller";
            


            comboBox1.DataSource = role;
            string query = "SELECT Id, Name, Email, Phone, Role FROM logindata WHERE Role <> 'Admin'";
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

            string query = "SELECT Id, Name, Email, Phone, Role FROM logindata WHERE Role <> 'Admin'";

            if (selectedRole != "All")
            {
                query += " AND Role = @role";
            }

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (selectedRole != "All")
                    {
                        command.Parameters.AddWithValue("@role", selectedRole);
                    }

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }


        private void deletebutton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            // Get the Id and Role of the selected user
            int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            string selectedRole = dataGridView1.SelectedRows[0].Cells["Role"].Value.ToString();

            // Build warning message based on role
            string warningMessage = "This action will permanently delete the user account.\n\n";

            if (selectedRole == "Buyer")
            {
                warningMessage += "- All buyer history (buyerproperties) linked to this user will also be deleted.\n";
            }
            else if (selectedRole == "Seller")
            {
                warningMessage += "- All properties listed by this seller (loginproperties).\n" +
                                  "- All buyer-property links (buyerproperties) related to those properties.\n";
            }
            else
            {
                warningMessage += "- Any associated records linked to this user will also be removed.\n";
            }

            warningMessage += "\nAre you sure you want to continue?";

            // Confirm delete
            if (MessageBox.Show(warningMessage, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = @"
                        DELETE FROM Notifications WHERE UserID = @Id;
                        DELETE FROM logintransactions WHERE BuyerID = @Id;
                        DELETE FROM logintransactions WHERE PropertyID IN (SELECT PropertyID FROM loginproperties WHERE SellerID = @Id);
                        DELETE FROM buyerproperties WHERE BuyerID = @Id;
                        DELETE FROM buyerproperties WHERE PropertyID IN (SELECT PropertyID FROM loginproperties WHERE SellerID = @Id);
                        DELETE FROM loginproperties WHERE SellerID = @Id;
                        DELETE FROM logindata WHERE Id = @Id;";




                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", selectedId);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // Refresh DataGridView
                string role = comboBox1.SelectedItem.ToString();
                string queryRefresh = "SELECT Id, Name, Email, Phone, Role FROM logindata WHERE Role <> 'Admin'";
                if (role != "All")
                    queryRefresh += " AND Role = @role";

                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                using (SqlCommand command = new SqlCommand(queryRefresh, connection))
                {
                    if (role != "All")
                        command.Parameters.AddWithValue("@role", role);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
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

            string query = @"SELECT Id, Name, Email, Phone, Role 
                 FROM logindata
                 WHERE Role <> 'Admin' AND
                       (Id LIKE @searchTerm 
                        OR Name LIKE @searchTerm 
                        OR Email LIKE @searchTerm 
                        OR Role LIKE @searchTerm 
                        OR Phone LIKE @searchTerm)";


            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchTerm", "%" + searchValue + "%");

                    /* SqlDataAdapter adapter = new SqlDataAdapter(command); //adapter acts as a bridge between a DataSet (or DataTable) and the SQL database.
                 DataTable dataTable = new DataTable();  //Instantiates a new, empty DataTable object to store the retrieved data
                 adapter.Fill(dataTable);  // Executes the SQL command and fills the dataTable with the result set returned from the database
                    dataGridView1.DataSource = dataTable;
*/
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
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            AdminProfileForm apf = new AdminProfileForm(userID);
            apf.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminHomePageForm ahp = new AdminHomePageForm(userID);
            ahp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminManagePropertyForm amp = new AdminManagePropertyForm(userID);
            amp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminTransectionHistoryForm amu = new AdminTransectionHistoryForm(userID);
            amu.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Close();
        }

        private void AdminManageUsersForm_Load(object sender, EventArgs e)
        {

        }
    }
}
