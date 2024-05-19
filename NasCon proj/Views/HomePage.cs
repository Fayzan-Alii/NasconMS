using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NasCon_proj.Views
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        private int imageNumber = 1;

        private void LoadNextImage()
        {
            if(imageNumber == 5)
            {
                imageNumber = 1;
            }
            pictureBox1.ImageLocation = string.Format(@"Images\{0}.jpg", imageNumber);
            imageNumber++;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string url = "https://www.facebook.com/fast.nascon/";

            Process.Start(url);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string url = "https://www.instagram.com/nascon_fast/";

            Process.Start(url);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string url = "https://pk.linkedin.com/company/nascon-nu";

            Process.Start(url);
        }

        private int imageNumber2 = 1;

        private void LoadNextImage2()
        {
            if (imageNumber2 == 4)
            {
                imageNumber2 = 1;
            }
            pictureBox9.ImageLocation = string.Format(@"images2\{0}.jpg", imageNumber);
            imageNumber2++;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            LoadNextImage2();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
       
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RegisterView registerView = new RegisterView();
            registerView.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string url = "https://nascon.com.pk/";

            Process.Start(url);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Events events = new Events();
            events.Show();
        }
    }
}
