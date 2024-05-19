using NasCon_proj.Controllers;
using NasCon_proj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NasCon_proj.Views
{
    public partial class NewAdmins : Form
    {
        public NewAdmins()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void NewAdmins_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdministratorView administratorView = new AdministratorView();  
            administratorView.Show();
            this.Hide();
        }

        private void confirm1_Click(object sender, EventArgs e)
        {
            // Check if any of the fields are empty
            if (string.IsNullOrWhiteSpace(name1.Text) ||
                string.IsNullOrWhiteSpace(password1.Text) ||
                string.IsNullOrWhiteSpace(email1.Text) )
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string email = email1.Text.Trim();
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            string password = password1.Text;
            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return;
            }


            int roleId = 4; // for admins


            User user = new User
            {
                Username = name1.Text,
                Password = password,
                Email = email,
                RoleID = roleId
            };

            UserController userController = new UserController();
            bool success = userController.RegisterUser(user);

            if (success)
            {
                MessageBox.Show("User registered successfully!");
                name1.Clear();
                password1.Clear();
                email1.Clear();
            }
            else
            {
                MessageBox.Show("Failed to register user.");
            }
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void name1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
