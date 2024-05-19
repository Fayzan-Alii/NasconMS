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
    public partial class RegisterPackage : Form
    {
        int userID;
        public RegisterPackage(int userID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.userID = userID;
        }

        private void RegisterPackage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sponsor sponsor = new Sponsor(userID);
            sponsor.Show();
            this.Hide();
        }
    }
}
