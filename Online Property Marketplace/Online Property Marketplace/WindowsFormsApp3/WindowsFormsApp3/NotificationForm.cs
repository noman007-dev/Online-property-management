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
    public partial class NotificationForm : Form
    {
        private int userID;
        public NotificationForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            LoadNotifications();
        }
        private void LoadNotifications()
        {
            listBoxNotifications.Items.Clear();

            using (SqlConnection conn = new SqlConnection(DbConnection.connectionString))
            {
                string query = "SELECT Message FROM Notifications WHERE UserID = @UserID ORDER BY NotificationID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listBoxNotifications.Items.Add(reader.GetString(0));
                }
            }
        }

        private void listBoxNotifications_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
