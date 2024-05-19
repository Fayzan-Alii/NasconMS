using NasCon_proj.Controllers;
using NasCon_proj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NasCon_proj.Views
{
    public partial class ManageUsers : Form
    {
        private EventController eventController;

        public ManageUsers()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeDatabaseConnection();
            DisplayAvailableUsers();

        }


        private void InitializeDatabaseConnection()
        {
            eventController = new EventController();
        }

        private void DisplayAvailableUsers()
        {
            List<User> users = eventController.GetUsers();

            DataTable dt = new DataTable();
            dt.Columns.Add("UserID", typeof(int));
            dt.Columns.Add("Username", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("RoleID", typeof(int));

            foreach (User user in users)
            {
                dt.Rows.Add(user.UserID, user.Username, user.Email, user.RoleID);
            }

            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdministratorView administratorView = new AdministratorView();  
            administratorView.Show();
            this.Hide();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int userID;
            if (int.TryParse(id1.Text, out userID))
            {
                string username = name1.Text;
                string password = password1.Text;
                string email = email1.Text;

                bool success = eventController.UpdateUser(userID, username, password, email);
                if (success)
                {
                    MessageBox.Show("User details updated successfully!");
                    DisplayAvailableUsers();
                }
                else
                {
                    MessageBox.Show("Failed to update user details. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid User ID.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int userID;
            if (int.TryParse(id1.Text, out userID))
            {
                bool success = eventController.DeleteUser(userID);
                if (success)
                {
                    MessageBox.Show("User deleted successfully!");
                    DisplayAvailableUsers();
                }
                else
                {
                    MessageBox.Show("Failed to delete user. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid User ID.");
            }
        }
    }
}
