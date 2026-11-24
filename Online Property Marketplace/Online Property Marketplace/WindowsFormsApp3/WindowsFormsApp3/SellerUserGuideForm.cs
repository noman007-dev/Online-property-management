using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class SellerUserGuideForm : Form
    {
        public SellerUserGuideForm()
        {
            InitializeComponent();
        }
        private void SellerUserGuideForm_Load(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SellerUserGuideForm_Load_1(object sender, EventArgs e)
        {
            richTextBox1.Text =
                @"🏡 Seller Guide
                    🔹 1. Login

                    Enter your username and password.

                    Click Login to access your seller dashboard.

                    🔹 2. Add Property

                    On the Seller Home Page, click Add Property.

                    Fill in details:

                    Title, Address, Price, Description, and Upload Image.

                    Click Save to publish property.

                    🔹 3. Manage Properties

                    Seller Home Page lists all your properties.

                    You can view, edit, or remove them.

                    🔹 4. Notifications

                    When a buyer purchases your property:

                    You get a notification:

                    ✅ “Your property has been sold!”

                    Notifications can be checked from the Notification Page (Form2).

                    🔹 5. Sales History

                    Click the History button on your dashboard.

                    You will see all properties sold, along with buyer info and price.

                    🔹 6. Refresh Dashboard

                    Click the Reload button on the Seller Home Page.

                    Updates your property list with the most recent status (available/sold).";
        }
    }
}
