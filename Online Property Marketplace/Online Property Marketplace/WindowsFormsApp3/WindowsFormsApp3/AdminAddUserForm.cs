using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class AdminAddUserForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString);
        private int userID;
        public AdminAddUserForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            //this.StartPosition = FormStartPosition.CenterScreen;

            string[] role = new string[3];
            role[0] = "Buyer";
            role[1] = "Seller";
            role[2] = "Admin";


            signuprolecomboBox.DataSource = role;
        }


        private void signupbutton_Click(object sender, EventArgs e)
        {
            //string connectionString = "data source=*\\SQLEXPRESS; database=login; integrated security=SSPI";

            string name = signupnametextBox.Text.Trim();
            string email = signupemailtextBox.Text.Trim();
            string phone = (phone1textBox.Text + phone2textBox.Text).Trim();
            string password = signuppasstextBox.Text.Trim();
            string role = signuprolecomboBox.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!phone.All(char.IsDigit))
            {
                MessageBox.Show("Phone must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO logindata (Name, Email, Phone, Password, Role) VALUES (@Name, @Email, @Phone, @Password, @Role)";

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", role);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        AdminManageUsersForm amu = new AdminManageUsersForm(userID);
                        amu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //MessageBox.Show("Account created successfully");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            AdminManageUsersForm amu = new AdminManageUsersForm(userID);
            amu.Show();
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
            AdminManagePropertyForm amp = new AdminManagePropertyForm(userID);
            amp.Show();
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
    }
}
