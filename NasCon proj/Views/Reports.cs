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
    public partial class Reports : Form
    {
        private AdminController adminController;

        public Reports()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            PopulateReportOptions();

            this.StartPosition = FormStartPosition.CenterScreen;

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

        private void InitializeDatabaseConnection()
        {
            adminController = new AdminController();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AdministratorView administratorView = new AdministratorView();  
            administratorView.Show();
            this.Hide();
          
        }

        private void PopulateReportOptions()
        {
            comboBox1.Items.Add("Get Event Registration Summary");
            comboBox1.Items.Add("Get Feedback Summary");
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedReport = comboBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedReport))
            {
                if (selectedReport == "Get Event Registration Summary")
                {
                    PopulateEventRegistrationSummary();
                }
                else if (selectedReport == "Get Feedback Summary")
                {
                    PopulateFeedbackSummary();
                }
            }

        }

        private void PopulateEventRegistrationSummary()
        {
            Dictionary<string, Dictionary<string, int>> summary = adminController.GetEventRegistrationSummary();

            DataTable dt = new DataTable();
            dt.Columns.Add("Event Name", typeof(string));
            dt.Columns.Add("Individual Registrations", typeof(int));
            dt.Columns.Add("Team Registrations", typeof(int));

            foreach (var item in summary)
            {
                DataRow row = dt.NewRow();
                row["Event Name"] = item.Key;
                row["Individual Registrations"] = item.Value["IndividualRegistrations"];
                row["Team Registrations"] = item.Value["TeamRegistrations"];
                dt.Rows.Add(row);
            }

            dataGridView1.DataSource = dt;
        }

        private void PopulateFeedbackSummary()
        {
            Dictionary<string, List<(int Rating, string Comment)>> summary = adminController.GetFeedbackSummary();

            DataTable dt = new DataTable();
            dt.Columns.Add("Event Name", typeof(string));
            dt.Columns.Add("Rating", typeof(int));
            dt.Columns.Add("Comment", typeof(string));

            foreach (var item in summary)
            {
                foreach (var feedback in item.Value)
                {
                    DataRow row = dt.NewRow();
                    row["Event Name"] = item.Key;
                    row["Rating"] = feedback.Item1;
                    row["Comment"] = feedback.Item2;
                    dt.Rows.Add(row);
                }
            }

            dataGridView1.DataSource = dt;
        }

       
    
}
}
