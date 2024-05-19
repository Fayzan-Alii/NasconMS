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
    public partial class Sponsor : Form
    {
        private int userID;
        private EventController eventController;

        public Sponsor(int userID)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            InitializeDatabaseConnection();

            this.userID = userID;

            //register package
            panel1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            button5.Visible = false;

            dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; 
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); 


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ScrollBars = ScrollBars.Both; 

            dataGridView1.BackgroundColor = this.BackColor;
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }
        private void InitializeDatabaseConnection()
        {
            eventController = new EventController();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            LoginView loginView = new LoginView();  
            loginView.Show();
            this.Hide();
        }

        private void DisplayEventDetails()
        {
            List<Event> events = eventController.GetEvents("All");
            dataGridView1.DataSource = events;
        }

        private void PopulateEventGridView()
        {
            int sponsorID = userID;

            List<Event> sponsoredEvents = eventController.GetSponsoredEvents(sponsorID);

            dataGridView1.DataSource = sponsoredEvents;
        }

        private void Sponsor_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           RegisterPackage registerPackage = new RegisterPackage(userID);
            registerPackage.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //register package
            panel1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            button5.Visible = false;

            int userID = this.userID; 
            int sponsorID = Convert.ToInt32(textBox2.Text); 
            int eventID = Convert.ToInt32(textBox1.Text); 

            RegisterSponsorship(userID, sponsorID, eventID);

        }

        private void DisplaySponsorPackages()
        {
            List<SponsorM> sponsorPackages = eventController.GetSponsorPackagesByUserID(userID);

            dataGridView1.DataSource = sponsorPackages;
        }
        private void RegisterSponsorship(int userID, int sponsorID, int eventID)
        {
            bool success = eventController.RegisterSponsorship(userID, sponsorID, eventID);

            if (success)
            {
                MessageBox.Show("Sponsorship registered successfully!");
            }
            else
            {
                MessageBox.Show("Failed to register sponsorship. Please try again.");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //register package
            panel1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            button5.Visible = false;
            DisplayEventDetails();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //register package
            panel1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            button5.Visible = true;

            DisplaySponsorPackages();

        }

        private void button6_Click(object sender, EventArgs e)
        { 
            //register package
            panel1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            button5.Visible = false;

            PopulateEventGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
