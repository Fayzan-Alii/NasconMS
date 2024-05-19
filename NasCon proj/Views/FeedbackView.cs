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
    public partial class FeedbackView : Form
    {
        private int userID;
        private EventController eventController;

        public FeedbackView(int userID)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            this.userID = userID;
            InitializeComponent();
            InitializeDatabaseConnection();


            List<Event> events = eventController.GetEvents("All"); // Or any category you prefer
            foreach (Event ev in events)
            {
                eventComboBox.Items.Add(ev);
            }
        }

        private void InitializeDatabaseConnection()
        {
            eventController = new EventController();
        }

        private void FeedbackView_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Event selectedEvent = (Event)eventComboBox.SelectedItem;
            int eventId = selectedEvent.EventID;
            int rating = Convert.ToInt32(ratings1.Text);
            string comments = comments1.Text;

            // You'll need to get userID from your view or some other source
            int userId = userID;

            bool isFeedbackSubmitted = eventController.SubmitFeedback(userId, eventId, rating, comments);

            if (isFeedbackSubmitted)
            {
                MessageBox.Show("Feedback submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to submit feedback. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ParticipantView participantView = new ParticipantView(userID);
            participantView.Show();
            this.Hide();
        }
    }
}
