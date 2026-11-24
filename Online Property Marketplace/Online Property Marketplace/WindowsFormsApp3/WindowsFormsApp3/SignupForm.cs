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
    public partial class SignupForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString); 
        public SignupForm()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.CenterScreen;

            string[] role = new string[2];
            role[0] = "Buyer";
            role[1] = "Seller";
            

            signuprolecomboBox.DataSource = role;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void signupbutton_Click(object sender, EventArgs e)
        {
            //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI";

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
                        MessageBox.Show("Profile created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        LoginForm f2 = new LoginForm();
                        f2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //MessageBox.Show("Account created successfully");
                }
            }
        }
    }
}
