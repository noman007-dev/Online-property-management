using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class SellerAddPropertyForm : Form
    {
        SqlConnection con = new SqlConnection(DbConnection.connectionString);

        private int sellerID;
        private byte[] imageBytes;
        //string connectionString = "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI"; 
        public SellerAddPropertyForm(int sellerID)
        {
            InitializeComponent();
            /*string[] catagory = new string[2];
            catagory[0] = "house";
            catagory[1] = "shop";
            catagorycomboBox.DataSource = catagory;*/

            this.sellerID = sellerID;

            LoadCategories();

            string[] type = new string[2];
            type[0] = "Sell";
            type[1] = "Rent";
            typecomboBox.DataSource = type;
        }

        private void LoadCategories()
        {
            using (SqlConnection conn = new SqlConnection(DbConnection.connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT CategoryID, CategoryName FROM logincategories", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                catagorycomboBox.DataSource = dt;
                catagorycomboBox.DisplayMember = "CategoryName"; // shown to user
                catagorycomboBox.ValueMember = "CategoryID";     // value saved in DB
            }
        }


        private void addpropertybutton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please select a property image.");
                return;
            }

            string title = titletextBox.Text.Trim();
            string address = addresstextBox.Text.Trim();
            string price = pricetextBox.Text.Trim();
            //string category = catagorycomboBox.Text.Trim();
            string type = typecomboBox.SelectedItem.ToString();
            string description = descriptionrichTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(price) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(price, out decimal priceValue))
            {
                MessageBox.Show("Price must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int categoryID = (int)catagorycomboBox.SelectedValue;

            string query = "INSERT INTO loginproperties (Title, Address, Price, CategoryID, RentOrSell, Description, Image, SellerID) VALUES (@Title, @Address, @Price, @CategoryID, @RentOrSell, @Description, @Image, @SellerID)";

            /*byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                imageBytes = ms.ToArray();
            }*/

            using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Price", priceValue);
                    command.Parameters.AddWithValue("@CategoryID", categoryID);
                    command.Parameters.AddWithValue("@RentOrSell", type);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Image", imageBytes);
                    command.Parameters.AddWithValue("@SellerID", this.sellerID);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Property added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();

                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //MessageBox.Show("Account created successfully");
                }
            }
        }

        private void addpicturebutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                imageBytes = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void ResetForm()
        {
            titletextBox.Clear();
            addresstextBox.Clear();
            pricetextBox.Clear();
            descriptionrichTextBox.Clear();
            catagorycomboBox.SelectedIndex = -1;  
            typecomboBox.SelectedIndex = -1;      
            pictureBox1.Image = null;
            imageBytes = null;
        }

        private void viewpropertybutton_Click(object sender, EventArgs e)
        {
            SellerViewProperty f4 = new SellerViewProperty(sellerID);
            f4.Show();
            this.Close();
        }

        private void logoutbutton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SellerProfileForm sp = new SellerProfileForm(sellerID);
            sp.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SellerHomePageForm shp = new SellerHomePageForm(sellerID);
            shp.Show();
            this.Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            SellerHistoryForm historyForm = new SellerHistoryForm(sellerID);
            historyForm.Show();
            this.Close();
        }

        private void btnviewmessage_Click(object sender, EventArgs e)
        {
            SellerMassageForm msgForm = new SellerMassageForm(sellerID);
            msgForm.Show();
            this.Close();
        }
    }
}
