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
    public partial class Events : Form
    {
        private EventController eventController;

        public Events()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            InitializeDatabaseConnection();
            List<Event> events = eventController.GetEvents("All");
            dataGridView1.DataSource = events;
        }

        private void Events_Load(object sender, EventArgs e)
        {

        }
        private void InitializeDatabaseConnection()
        {
            eventController = new EventController();
        }
    }
}
