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
using MySql.Data.MySqlClient;
using NasCon_proj.Controllers;
using NasCon_proj.Models;
using NasCon_proj.Views;

namespace NasCon_proj
{
    public partial class RegisterView : Form
    {
        public RegisterView()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Hide();
        }

        private void RegisterView_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void register1_Click(object sender, EventArgs e)
        {
            // Check if any of the fields are empty
            if (string.IsNullOrWhiteSpace(username1.Text) ||
                string.IsNullOrWhiteSpace(password1.Text) ||
                string.IsNullOrWhiteSpace(email1.Text) ||
                rolename1.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Validate email format
            string email = email1.Text.Trim();
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            // Validate password length
            string password = password1.Text;
            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return;
            }

            // Extract role ID
            int roleId;
            string selectedRole = rolename1.SelectedItem.ToString();
            switch (selectedRole)
            {
                case "Participant":
                    roleId = 1;
                    break;
                case "Team Leader":
                    roleId = 2;
                    break;
                case "Administrator":
                    roleId = 3;
                    break;
                case "Sponsor":
                    roleId = 4;
                    break;
                case "Faculty Mentor":
                    roleId = 5;
                    break;
                default:
                    roleId = 0;
                    break;
            }

            // Create user object
            User user = new User
            {
                Username = username1.Text,
                Password = password,
                Email = email,
                RoleID = roleId
            };

            // Register the user using UserController
            UserController userController = new UserController();
            bool success = userController.RegisterUser(user);

            if (success)
            {
                MessageBox.Show("User registered successfully!");
                username1.Clear();
                password1.Clear();
                email1.Clear();
                rolename1.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Failed to register user.");
            }
        }

        // Validate email format
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, emailPattern);
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void email1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
