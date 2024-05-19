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
    public partial class LoginView : Form
    {
        public LoginView()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
        }

        private void login1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(email1.Text) ||
                string.IsNullOrWhiteSpace(password1.Text) )
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            string email = email1.Text;
            string password = password1.Text;



            UserController userController = new UserController();

            User user = userController.LoginUser(email, password);

            if (user != null)
            {
                //MessageBox.Show("Login successful!");

                if (user.RoleID == 1)
                {
                    ParticipantView participantView = new ParticipantView(user.UserID);
                    participantView.Show();
                    this.Hide();
                }
                else if (user.RoleID == 2) 
                {
                    TeamLeader teamLeader = new TeamLeader(user.UserID);
                    teamLeader.Show();
                    this.Hide();
                }
                else if (user.RoleID == 3) 
                {
                    Sponsor sponsor = new Sponsor(user.UserID);
                    sponsor.Show();
                    this.Hide();
                }
                else if (user.RoleID == 4) 
                {
                    AdministratorView admin = new AdministratorView();
                    admin.Show();
                    this.Hide();
                }
               

            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.");
            }
        }

        private void LoginView_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterView registerView = new RegisterView();
            registerView.Show();
            this.Hide();
        }
    }
}
