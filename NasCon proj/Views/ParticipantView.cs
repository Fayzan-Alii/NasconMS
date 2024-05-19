using MySql.Data.MySqlClient;
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
    public partial class ParticipantView : Form
    {
        private EventController eventController;
        private int userID; 

        public ParticipantView(int userID)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            InitializeDatabaseConnection();
            PopulateCategoriesComboBox();
            PopulateEventComboBox();
            DisplayEventDetails();
            PopulateFoodDealsComboBox();

            textBox1.Text = userID.ToString();

            //events reg
            label3.Visible = false;
            registereventbox1.Visible = false;
            registerevent1.Visible = false;

            //deals reg
            label2.Visible = false;
            registerDealBox.Visible = false;
            RegisterDealbutton.Visible = false;

            back.Visible = false;

            this.userID = userID;


            //----------
            dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Header text color
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue; // Header background color
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Header font


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ScrollBars = ScrollBars.Both; // Enable both vertical and horizontal scrollbars

            dataGridView1.BackgroundColor = this.BackColor;



        }
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Check if the current row index is even or odd
            if (e.RowIndex % 2 == 0)
            {
                // Highlight the background color of even rows
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                // Reset the background color of odd rows
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void PopulateBookedEvents()
        {
            List<Event> bookedEvents = eventController.GetBookedEvents(userID);

            dataGridView1.DataSource = bookedEvents;
        }

        private void PopulateBookedFoodDeals()
        {
            List<FoodDeal> bookedFoodDeals = eventController.GetRegisteredFoodDealsByUserID(userID);

            dataGridView1.DataSource = bookedFoodDeals;
        }

        private void InitializeDatabaseConnection()
        {
            eventController = new EventController();
        }

        private void DisplayEventDetails()
        {
            string selectedCategory = categories1.SelectedItem?.ToString();
            List<Event> events = eventController.GetEvents(selectedCategory);
            dataGridView1.DataSource = events;
        }

        private void PopulateCategoriesComboBox()
        {
            List<string> categories = eventController.GetEventCategories();
            categories1.Items.Add("All");
            foreach (string category in categories)
            {
                categories1.Items.Add(category);
            }
            categories1.SelectedIndex = 0;


        }
        private void PopulateEventComboBox()
        {
            List<Event> events = eventController.GetEvents(null); // Get all events
            foreach (Event evnt in events)
            {
                registereventbox1.Items.Add(evnt.Name);
            }
        }

        private void PopulateFoodDealsComboBox()
        {
            List<FoodDeal> foodDeals = eventController.GetFoodDeals();

            registerDealBox.Items.Clear();

            registerDealBox.Items.Add("");

            foreach (FoodDeal deal in foodDeals)
            {
                registerDealBox.Items.Add(deal.DealName);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void categories1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayEventDetails();
        }

        private void ParticipantView_Load(object sender, EventArgs e)
        {

        }


     
        private void button3_Click(object sender, EventArgs e)
        {
            List<FoodDeal> foodDeals = eventController.GetFoodDeals();
            dataGridView1.DataSource = foodDeals;
        }

      

        private void signout1_Click(object sender, EventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           PopulateBookedEvents();
        }

        private void events_Click(object sender, EventArgs e)
        {

        }

        private void registerevent1_Click(object sender, EventArgs e)
        {
            string selectedEventName = registereventbox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedEventName))
            {
                MessageBox.Show("Please select an event to register.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EventController eventController = new EventController();
            Event selectedEvent = eventController.GetEventByName(selectedEventName);
            if (selectedEvent == null)
            {
                MessageBox.Show("Failed to retrieve event details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = eventController.RegisterForEvent(userID, selectedEvent.EventID, null, "Individual");

            if (success)
            {
                MessageBox.Show($"Successfully registered for event: {selectedEvent.Name}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to register for event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registereventbox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void registerEvent_Click(object sender, EventArgs e)
        {

            string selectedCategory = categories1.SelectedItem?.ToString();
            List<Event> events = eventController.GetEvents(selectedCategory);
            dataGridView1.DataSource = events;


            foreach (Button btn in Controls.OfType<Button>())
            {
                btn.Visible = false;
            }

            
            label1.Visible = true;
            categories1.Visible = true;

            //events
            label3.Visible = true;
            registereventbox1.Visible = true;
            registerevent1.Visible = true;

            back.Visible = true;

            //deals reg
            label2.Visible = false;
            registerDealBox.Visible = false;
            RegisterDealbutton.Visible = false;

        }

        private void events_Click_1(object sender, EventArgs e)
        {
            string selectedCategory = categories1.SelectedItem?.ToString();
            List<Event> events = eventController.GetEvents(selectedCategory);
            dataGridView1.DataSource = events;
        }

        private void back_Click(object sender, EventArgs e)
        {
            foreach (Button btn in Controls.OfType<Button>())
            {
                btn.Visible = true;
            }


            //events reg
            label3.Visible = false;
            registereventbox1.Visible = false;
            registerevent1.Visible = false;

            //deals reg
            label2.Visible = false;
            registerDealBox.Visible = false;
            RegisterDealbutton.Visible = false;

            back.Visible = false;
        }

        private void registerFoodDeals_Click(object sender, EventArgs e)
        {
            List<FoodDeal> foodDeals = eventController.GetFoodDeals();
            dataGridView1.DataSource = foodDeals;


            foreach (Button btn in Controls.OfType<Button>())
            {
                btn.Visible = false;
            }

            back.Visible = true;

            //deals
            label2.Visible = true;
            registerDealBox.Visible = true;
            RegisterDealbutton.Visible = true;


            //events reg
            label3.Visible = false;
            registereventbox1.Visible = false;
            registerevent1.Visible = false;

         

        }

        private void bookedDeals_Click(object sender, EventArgs e)
        {
            PopulateBookedFoodDeals();
        }

        private void RegisterDealbutton_Click(object sender, EventArgs e)
        {
            string selectedDealName = registerDealBox.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedDealName))
            {
                var foodDeals = eventController.GetFoodDeals();

                var selectedDeal = foodDeals.Find(deal => deal.DealName == selectedDealName);

                if (selectedDeal != null)
                {
                    
                    bool success = eventController.RegisterParticipantForFoodDeal(userID, selectedDeal.DealID);

                    if (success)
                    {
                        MessageBox.Show("Successfully registered for the food deal!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to register for the food deal. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Selected food deal not found.");
                }
            }
            else
            {
                MessageBox.Show("Please select a food deal to register.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FeedbackView feedbackView = new FeedbackView(userID);
            feedbackView.Show();

            this.Hide();

        }
    }
}
