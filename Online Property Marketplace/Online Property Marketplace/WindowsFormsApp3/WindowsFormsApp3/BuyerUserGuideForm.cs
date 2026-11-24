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
    public partial class BuyerUserGuideForm : Form
    {
        public BuyerUserGuideForm()
        {
            InitializeComponent();
        }
        private void AdminUserGuideForm_Load(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BuyerUserGuideForm_Load(object sender, EventArgs e)
        {
            richTextBox1.Text =
                @"👤 Buyer Guide
                🔹 1. Login

                Enter your username and password.

                Click Login to access your buyer dashboard.

                🔹 2. Browse Properties

                On the Buyer Home Page, all available properties are listed.

                Each property shows Title, Address, Price, and Description.

                Click View to open ViewPropertyForm for details.

                🔹 3. Purchase Property

                On the property details screen, click the Buy button.

                Select a payment method:

                Mobile Banking

                Bank Transfer

                MasterCard

                PayPal

                Click Confirm Purchase.

                You will see a message:

                ✅ “Purchase successful! Payment method: [chosen method]”

                A record is saved in the system, and the seller is notified.

                🔹 4. Notifications

                Buyers receive a message:

                “Purchase successful! Thank you for buying.”

                To view notifications:

                Go to Notification Page (Form2).

                All purchase messages will be listed.

                🔹 5. Purchase History

                Click the History button.

                The system shows your past purchases with property details, price, and date.

                🔹 6. Refresh Dashboard

                Click the Reload button on the Buyer Home Page.

                This ensures the property list is updated with latest availability.";
        }
    }
}
