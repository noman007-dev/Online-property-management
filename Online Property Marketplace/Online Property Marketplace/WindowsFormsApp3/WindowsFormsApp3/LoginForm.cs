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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp3
{
    public partial class LoginForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString); 
        public LoginForm()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.CenterScreen;

            string[] role = new string[3];
            role[0] = "Buyer";
            role[1] = "Seller";
            role[2] = "Admin";


            loginrolecomboBox.DataSource = role;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignupForm signupForm = new SignupForm();
            signupForm.Show();
            this.Hide();
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI";

            string name = loginnametextBox.Text.Trim();
            string password = loginpasstextBox.Text.Trim();
            string role = loginrolecomboBox.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both name and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT Id, Name, Role FROM logindata WHERE Name=@Name AND Password=@Password AND Role=@Role";

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", role);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())  // if a matching user is found
                    {
                        int userId = Convert.ToInt32(reader["Id"]);

                        if (role == "Buyer")
                        {
                            BuyerHomePageForm form = new BuyerHomePageForm(userId);
                            form.Show();
                            this.Hide();
                        }
                        else if (role == "Seller")
                        {
                            SellerHomePageForm form = new SellerHomePageForm(userId);
                            form.Show();
                            this.Hide();
                        }
                        else if (role == "Admin")
                        {
                            AdminHomePageForm form = new AdminHomePageForm(userId);
                            form.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid name, password, or role.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        fplinklabel.Visible = true;
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void fplinklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPasswordForm forgetForm = new ForgetPasswordForm();
            forgetForm.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.Checked)  // check the checkbox
            {
                loginpasstextBox.UseSystemPasswordChar = true; // show password
            }
            else
            {
                loginpasstextBox.UseSystemPasswordChar = false;  // hide password
            }
        }
    }
}
