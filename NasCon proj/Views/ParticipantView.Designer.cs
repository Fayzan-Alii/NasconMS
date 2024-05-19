namespace NasCon_proj.Views
{
    partial class ParticipantView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParticipantView));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.foodDeals = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.categories1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.signout1 = new System.Windows.Forms.Button();
            this.events = new System.Windows.Forms.Button();
            this.registerFoodDeals = new System.Windows.Forms.Button();
            this.bookedDeals = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.registerEvent = new System.Windows.Forms.Button();
            this.registerevent1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.registereventbox1 = new System.Windows.Forms.ComboBox();
            this.back = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.registerDealBox = new System.Windows.Forms.ComboBox();
            this.RegisterDealbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(303, 240);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1176, 563);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // foodDeals
            // 
            this.foodDeals.BackColor = System.Drawing.Color.SkyBlue;
            this.foodDeals.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodDeals.Location = new System.Drawing.Point(500, 173);
            this.foodDeals.Name = "foodDeals";
            this.foodDeals.Size = new System.Drawing.Size(191, 61);
            this.foodDeals.TabIndex = 3;
            this.foodDeals.Text = "Food Deals";
            this.foodDeals.UseVisualStyleBackColor = false;
            this.foodDeals.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "View Events By Categories";
            // 
            // categories1
            // 
            this.categories1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categories1.FormattingEnabled = true;
            this.categories1.Location = new System.Drawing.Point(12, 281);
            this.categories1.Name = "categories1";
            this.categories1.Size = new System.Drawing.Size(223, 33);
            this.categories1.TabIndex = 5;
            this.categories1.SelectedIndexChanged += new System.EventHandler(this.categories1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(74, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 22);
            this.label6.TabIndex = 17;
            this.label6.Text = "NaSCon";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(43, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // signout1
            // 
            this.signout1.BackColor = System.Drawing.Color.Crimson;
            this.signout1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signout1.Location = new System.Drawing.Point(43, 805);
            this.signout1.Name = "signout1";
            this.signout1.Size = new System.Drawing.Size(143, 45);
            this.signout1.TabIndex = 20;
            this.signout1.Text = "Signout";
            this.signout1.UseVisualStyleBackColor = false;
            this.signout1.Click += new System.EventHandler(this.signout1_Click);
            // 
            // events
            // 
            this.events.BackColor = System.Drawing.Color.SkyBlue;
            this.events.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.events.Location = new System.Drawing.Point(303, 174);
            this.events.Name = "events";
            this.events.Size = new System.Drawing.Size(191, 59);
            this.events.TabIndex = 21;
            this.events.Text = "Events";
            this.events.UseVisualStyleBackColor = false;
            this.events.Click += new System.EventHandler(this.events_Click_1);
            // 
            // registerFoodDeals
            // 
            this.registerFoodDeals.BackColor = System.Drawing.Color.SkyBlue;
            this.registerFoodDeals.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerFoodDeals.Location = new System.Drawing.Point(894, 175);
            this.registerFoodDeals.Name = "registerFoodDeals";
            this.registerFoodDeals.Size = new System.Drawing.Size(191, 59);
            this.registerFoodDeals.TabIndex = 22;
            this.registerFoodDeals.Text = "Register Food Deals";
            this.registerFoodDeals.UseVisualStyleBackColor = false;
            this.registerFoodDeals.Click += new System.EventHandler(this.registerFoodDeals_Click);
            // 
            // bookedDeals
            // 
            this.bookedDeals.BackColor = System.Drawing.Color.SkyBlue;
            this.bookedDeals.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookedDeals.Location = new System.Drawing.Point(1091, 174);
            this.bookedDeals.Name = "bookedDeals";
            this.bookedDeals.Size = new System.Drawing.Size(191, 59);
            this.bookedDeals.TabIndex = 23;
            this.bookedDeals.Text = "Booked Deals";
            this.bookedDeals.UseVisualStyleBackColor = false;
            this.bookedDeals.Click += new System.EventHandler(this.bookedDeals_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.SkyBlue;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(1288, 174);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(191, 60);
            this.button5.TabIndex = 24;
            this.button5.Text = "Booked Events";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // registerEvent
            // 
            this.registerEvent.BackColor = System.Drawing.Color.SkyBlue;
            this.registerEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerEvent.Location = new System.Drawing.Point(697, 174);
            this.registerEvent.Name = "registerEvent";
            this.registerEvent.Size = new System.Drawing.Size(191, 59);
            this.registerEvent.TabIndex = 25;
            this.registerEvent.Text = "Register Events";
            this.registerEvent.UseVisualStyleBackColor = false;
            this.registerEvent.Click += new System.EventHandler(this.registerEvent_Click);
            // 
            // registerevent1
            // 
            this.registerevent1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.registerevent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerevent1.Location = new System.Drawing.Point(27, 460);
            this.registerevent1.Name = "registerevent1";
            this.registerevent1.Size = new System.Drawing.Size(191, 62);
            this.registerevent1.TabIndex = 1;
            this.registerevent1.Text = "Register Event";
            this.registerevent1.UseVisualStyleBackColor = true;
            this.registerevent1.Click += new System.EventHandler(this.registerevent1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 22);
            this.label3.TabIndex = 18;
            this.label3.Text = "Select Event To Register";
            // 
            // registereventbox1
            // 
            this.registereventbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registereventbox1.FormattingEnabled = true;
            this.registereventbox1.Location = new System.Drawing.Point(7, 421);
            this.registereventbox1.Name = "registereventbox1";
            this.registereventbox1.Size = new System.Drawing.Size(223, 33);
            this.registereventbox1.TabIndex = 19;
            this.registereventbox1.SelectedIndexChanged += new System.EventHandler(this.registereventbox1_SelectedIndexChanged);
            // 
            // back
            // 
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Location = new System.Drawing.Point(828, 174);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(191, 57);
            this.back.TabIndex = 26;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 22);
            this.label2.TabIndex = 27;
            this.label2.Text = "Select a Deal to Register";
            // 
            // registerDealBox
            // 
            this.registerDealBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerDealBox.FormattingEnabled = true;
            this.registerDealBox.Location = new System.Drawing.Point(12, 421);
            this.registerDealBox.Name = "registerDealBox";
            this.registerDealBox.Size = new System.Drawing.Size(218, 33);
            this.registerDealBox.TabIndex = 28;
            // 
            // RegisterDealbutton
            // 
            this.RegisterDealbutton.BackColor = System.Drawing.Color.SkyBlue;
            this.RegisterDealbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterDealbutton.Location = new System.Drawing.Point(24, 460);
            this.RegisterDealbutton.Name = "RegisterDealbutton";
            this.RegisterDealbutton.Size = new System.Drawing.Size(194, 62);
            this.RegisterDealbutton.TabIndex = 29;
            this.RegisterDealbutton.Text = "Register Deal";
            this.RegisterDealbutton.UseVisualStyleBackColor = false;
            this.RegisterDealbutton.Click += new System.EventHandler(this.RegisterDealbutton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(314, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 30;
            this.label4.Text = "User ID: ";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.RoyalBlue;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(406, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(29, 34);
            this.textBox1.TabIndex = 31;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1485, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 47);
            this.button1.TabIndex = 32;
            this.button1.Text = "Feedback";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ParticipantView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1785, 862);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RegisterDealbutton);
            this.Controls.Add(this.registerDealBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.registerEvent);
            this.Controls.Add(this.registerFoodDeals);
            this.Controls.Add(this.back);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.bookedDeals);
            this.Controls.Add(this.events);
            this.Controls.Add(this.signout1);
            this.Controls.Add(this.registereventbox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.categories1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.foodDeals);
            this.Controls.Add(this.registerevent1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ParticipantView";
            this.Text = "ParticipantView";
            this.Load += new System.EventHandler(this.ParticipantView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button foodDeals;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categories1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button signout1;
        private System.Windows.Forms.Button events;
        private System.Windows.Forms.Button registerFoodDeals;
        private System.Windows.Forms.Button bookedDeals;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button registerEvent;
        private System.Windows.Forms.Button registerevent1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox registereventbox1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox registerDealBox;
        private System.Windows.Forms.Button RegisterDealbutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}