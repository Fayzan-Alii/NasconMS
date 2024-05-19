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
    public partial class FoodDealsView : Form
    {
        private EventController eventController;

        public FoodDealsView()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            this.eventController = new EventController(); 

            PopulateFoodDeals(); 
        }
        private void PopulateFoodDeals()
        {
            List<FoodDeal> foodDeals = eventController.GetFoodDeals();

            dataGridView1.DataSource = foodDeals;
        }

        private void FoodDeals_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
