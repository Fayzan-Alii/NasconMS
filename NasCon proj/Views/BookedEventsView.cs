using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NasCon_proj.Controllers;
using NasCon_proj.Models;

namespace NasCon_proj.Views
{
    public partial class BookedEventsView : Form
    {
        private int userID;
        private EventController eventController;

        public BookedEventsView(int userID)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            this.userID = userID;

            this.eventController = new EventController(); 

            PopulateBookedEvents(); 
        }

        private void PopulateBookedEvents()
        {
            List<Event> bookedEvents = eventController.GetBookedEventsByUserID(userID);

            dataGridView1.DataSource = bookedEvents;
        }

        private void BookedEvents_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
