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

    public partial class DeleteExipredEvents : Form
    {
        private EventController eventController;

        public DeleteExipredEvents()
        {
            InitializeComponent();
            InitializeDatabaseConnection();

            LoadExpiredEvents();

            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdministratorView administratorView = new AdministratorView();  
            administratorView.Show();
            this.Hide();
        }

        private void DeleteExipredEvents_Load(object sender, EventArgs e)
        {
        }

        private void InitializeDatabaseConnection()
        {
            eventController = new EventController();
        }

        private void LoadExpiredEvents()
        {
            List<Event> expiredEvents = eventController.GetExpiredEvents();
            DataTable dt = new DataTable();

            // Add columns to the DataTable
            dt.Columns.Add("EventID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Date", typeof(DateTime));

            // Add rows to the DataTable
            foreach (var evt in expiredEvents)
            {
                dt.Rows.Add(evt.EventID, evt.Name, evt.Date);
            }

            // Bind DataTable to DataGridView
            dataGridView1.DataSource = dt;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(eventid1.Text, out int selectedEventID))
            {
                bool deleted = eventController.DeleteEvent(selectedEventID);

                if (deleted)
                {
                    MessageBox.Show("Event deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadExpiredEvents(); 
                }
                else
                {
                    MessageBox.Show("Failed to delete event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid event ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
