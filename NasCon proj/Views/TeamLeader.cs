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

    public partial class TeamLeader : Form
    {
        private EventController eventController;

        private int userID; 


        public TeamLeader(int userID)
        {
            InitializeComponent();
            InitializeDatabaseConnection();

            teamname1.Hide();
            teamname2.Hide();
            Register1.Hide();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.userID = userID;
        }

        private void InitializeDatabaseConnection()
        {
            eventController = new EventController();
        }

        private void TeamLeader_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            teamname1.Hide();
            teamname2.Hide();
            Register1.Hide();
            DisplayEventDetails();
        }

        private void DisplayEventDetails()
        {
            List<Event> events = eventController.GetEvents("All");
            dataGridView1.DataSource = events;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            teamname1.Show();
            teamname2.Show();
            Register1.Show();
        }

        private void Register1_Click(object sender, EventArgs e)
        {
            string teamName = teamname2.Text;
            int leaderID = userID; 

            bool registered = eventController.RegisterTeam(leaderID, teamName);

            if (registered)
            {
                MessageBox.Show("Team registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to register team. Team name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            teamname1.Hide();
            teamname2.Hide();
            Register1.Hide();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            teamname1.Hide();
            teamname2.Hide();
            Register1.Hide();
        }
    }
}
