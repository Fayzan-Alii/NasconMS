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
    public partial class ManageEventCategories : Form
    {
        private EventController eventController;

        public ManageEventCategories()
        {
            InitializeComponent();
            InitializeDatabaseConnection();

            PopulateEventComboBox();
            this.StartPosition = FormStartPosition.CenterScreen;

            
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12); 

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
        private void PopulateEventComboBox()
        {
            List<Event> events = eventController.GetEvents(null); // Get all events

            eventcomboBox1.DisplayMember = "Name";

            eventcomboBox1.DataSource = events;
        }
        private void InitializeDatabaseConnection()
        {
            eventController = new EventController();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AdministratorView administratorView = new AdministratorView();  
            administratorView.Show();
            this.Hide();
        }

        private void ManageEventCategories_Load(object sender, EventArgs e)
        {

        }

        private void eventcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void DisplayEventDetails(Event selectedEvent)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Property", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            dt.Rows.Add("Name", selectedEvent.Name);
            dt.Rows.Add("Category", selectedEvent.CategoryName);
            dt.Rows.Add("Description", selectedEvent.Description);
            dt.Rows.Add("Date", selectedEvent.Date.ToString("yyyy-MM-dd")); // Format date as "yyyy-MM-dd"
            dt.Rows.Add("Venue", selectedEvent.Venue);
            dt.Rows.Add("Registration Price", selectedEvent.RegistrationPrice.ToString("C")); // Format as currency
            dt.Rows.Add("Event Type", selectedEvent.EventType ? "Individual" : "Team");
            dt.Rows.Add("Capacity", selectedEvent.Capacity.ToString());

            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "Property";
            dataGridView1.Columns[1].HeaderText = "Value";
        }
        private void display1_Click(object sender, EventArgs e)
        {
            Event selectedEvent = (Event)eventcomboBox1.SelectedItem;

            DisplayEventDetails(selectedEvent);
        }

        private void confirm1_Click(object sender, EventArgs e)
        {
            Event selectedEvent = (Event)eventcomboBox1.SelectedItem;

            if (selectedEvent != null)
            {
                // Check which fields have been modified
                if (!string.IsNullOrEmpty(name1.Text))
                    selectedEvent.Name = name1.Text;
                if (!string.IsNullOrEmpty(categoryname1.Text))
                    selectedEvent.CategoryName = categoryname1.Text;
                if (!string.IsNullOrEmpty(description.Text))
                    selectedEvent.Description = description.Text;
                if (date1.Value.Date != DateTime.Today) // Check if date is not today's date
                    selectedEvent.Date = date1.Value;
                if (!string.IsNullOrEmpty(venue1.Text))
                    selectedEvent.Venue = venue1.Text;
                if (!string.IsNullOrEmpty(registrationprice1.Text))
                    selectedEvent.RegistrationPrice = decimal.Parse(registrationprice1.Text);
                if (!string.IsNullOrEmpty(capacity1.Text))
                    selectedEvent.Capacity = int.Parse(capacity1.Text);

                // Update the event
                bool success = eventController.UpdateEvent(selectedEvent);
                if (success)
                {
                    MessageBox.Show("Event details updated successfully!");
                    // Refresh the event details display
                    DisplayEventDetails(selectedEvent);
                }
                else
                {
                    MessageBox.Show("Failed to update event details. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please select an event to update.");
            }
        }
    }
}
