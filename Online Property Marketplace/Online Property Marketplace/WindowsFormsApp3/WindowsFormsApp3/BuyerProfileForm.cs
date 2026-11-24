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

namespace WindowsFormsApp3
{
    public partial class BuyerProfileForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString);
        private int sellerID;
        private int buyerID;
        private int propertyID;
        public BuyerProfileForm(int sellerID)
        {
            InitializeComponent();
            this.sellerID = sellerID;
            LoadDetails();
        }

        private void LoadDetails()
        {
            string query = "SELECT Name, Email, Phone, Password FROM logindata WHERE Id = @Id";


            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", sellerID);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Populate the text boxes with the retrieved data
                        nametextBox.Text = reader["Name"].ToString();
                        emailtextBox.Text = reader["Email"].ToString();
                        phonetextBox.Text = reader["Phone"].ToString();
                        passwordtextBox.Text = reader["Password"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No details found for the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close(); // Close the form if no data is found
                    }
                }
            }
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            // Confirm deletion
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this profile?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM logindata WHERE Id = @Id";

                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", sellerID);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close(); // Close the form after successful deletion
                        }
                        else
                        {
                            MessageBox.Show("No profile was found to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            string newName = nametextBox.Text.Trim();
            string newemail = emailtextBox.Text.Trim();
            string newphone = phonetextBox.Text.Trim();
            string newpassword = passwordtextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newemail) || string.IsNullOrWhiteSpace(newphone) || string.IsNullOrWhiteSpace(newpassword))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE logindata SET Name=@Name, Email=@Email, Phone=@Phone, Password=@Password WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", sellerID);
                    command.Parameters.AddWithValue("@Name", newName);
                    command.Parameters.AddWithValue("@Email", newemail);
                    command.Parameters.AddWithValue("@Phone", newphone);
                    command.Parameters.AddWithValue("@Password", newpassword);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Close(); // Optionally close the form after a successful update
                    }
                    else
                    {
                        MessageBox.Show("No record was updated. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuyerHistoryForm buyerHistoryFrom = new BuyerHistoryForm(sellerID);
            buyerHistoryFrom.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WishlistForm buyerWishlist = new WishlistForm(sellerID);
            buyerWishlist.Show();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BuyerMessageForm buyerMessageFrom = new BuyerMessageForm(buyerID, sellerID, propertyID);
            buyerMessageFrom.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuyerHomePageForm buyerHomePageFrom = new BuyerHomePageForm(sellerID);
            buyerHomePageFrom.Show();
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
