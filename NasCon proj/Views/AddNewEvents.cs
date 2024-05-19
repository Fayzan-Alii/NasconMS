using NasCon_proj.Controllers;
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
    public partial class AddNewEvents : Form
    {
        private EventController eventController;

        public AddNewEvents()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            InitializeDatabaseConnection();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdministratorView administratorView = new AdministratorView();  
            administratorView.Show();
            this.Hide();
        }

        private void InitializeDatabaseConnection()
        {
            eventController = new EventController();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string name = name1.Text;
            string categoryName = categ1.Text;
            string description = desc1.Text;
            DateTime date = date1.Value;
            string venue = venue1.Text;
            decimal registrationPrice = Convert.ToDecimal(regprice1.Text);
            bool eventType = eventtype1.SelectedItem.ToString() == "Individual" ? true : false;
            int capacity = Convert.ToInt32(capacity1.Text);

            bool success = eventController.AddEvent(name, categoryName, description, date, venue, registrationPrice, eventType, capacity);

            if (success)
            {
                MessageBox.Show("Event added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Failed to add event. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            name1.Text = "";
            categ1.Text = "";
            desc1.Text = "";
            date1.Value = DateTime.Now;
            venue1.Text = "";
            regprice1.Text = "";
            eventtype1.SelectedIndex = -1;
            capacity1.Text = "";
        }

        private void AddNewEvents_Load(object sender, EventArgs e)
        {

        }
    }
}
