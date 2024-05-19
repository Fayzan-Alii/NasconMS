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
    public partial class AdministratorView : Form
    {
        private AdminController adminController;
        private EventController eventController;

        public AdministratorView()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.adminController = new AdminController(); // Initialize the AdminController
            this.eventController = new EventController();

         


            //----------
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Header text color
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue; // Header background color
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); 

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ScrollBars = ScrollBars.Both; 

            dataGridView1.BackgroundColor = this.BackColor;
        }


        private void LoadEvents()
        {
            List<Event> events = eventController.GetEvents("All");
            dataGridView1.DataSource = events;
        }




        private void Administrator_Load(object sender, EventArgs e)
        {
            LoadEvents();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void signout_Click(object sender, EventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Hide();
        }

        private void newevents1_Click(object sender, EventArgs e)
        {
            AddNewEvents addNewEvents = new AddNewEvents();
            addNewEvents.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void generatereports1_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Hide();
        }

        private void deleteevents1_Click(object sender, EventArgs e)
        {
            DeleteExipredEvents deleteExipredEvents = new DeleteExipredEvents();    
            deleteExipredEvents.Show();
            this.Hide();
        }

        private void manageevents1_Click(object sender, EventArgs e)
        {
            ManageEventCategories manageEventCategories = new ManageEventCategories();  
            manageEventCategories.Show();
            this.Hide();
        }

        private void manageusers1_Click(object sender, EventArgs e)
        {
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.Show();
            this.Hide();
        }

        private void newadmins1_Click(object sender, EventArgs e)
        {
            NewAdmins newAdmins = new NewAdmins();
            newAdmins.Show();
            this.Hide();
        }
    }
}
