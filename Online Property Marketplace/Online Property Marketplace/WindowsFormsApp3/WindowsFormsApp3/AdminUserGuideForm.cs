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
    public partial class AdminUserGuideForm : Form
    {
        public AdminUserGuideForm()
        {
            InitializeComponent();
        }

        private void AdminUserGuideForm_Load(object sender, EventArgs e)
        {
            richTextBox1.Text =
            @"📘 Admin Guide

            1. Login as Admin
               - Enter your Admin credentials on the Login page.
               - You will be redirected to the Admin Dashboard.

            2. Manage Users (Buyers & Sellers)
               - Go to Manage Users section.
               - View all registered Buyers and Sellers.
               - You can delete a user if necessary (e.g., fake account, misuse).

            3. Manage Properties
               - Navigate to Manage Properties.
               - View all properties listed by Sellers.
               - Delete a property if it violates rules or is no longer valid.

            4. Manage Transactions
               - Open Transaction History.
               - View all completed purchase/rent transactions between Buyers and Sellers.
               - Transactions are read-only (for record keeping).

            5. Dashboard Overview
               - See quick stats like:
                 • Total Buyers
                 • Total Sellers
                 • Total Properties
                 • Total Transactions

            6. Notifications
               - Admin does not receive notifications.
               - Notifications are only for Buyers and Sellers.

            7. Responsibilities
               - Ensure fair usage of the system.
               - Remove invalid users or properties.
               - Keep the database clean and updated.
            ";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
