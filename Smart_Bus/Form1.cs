using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis.TtsEngine;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Bus
{

    public partial class StartupScreen : Form
    {
        public bool cleaning { get; set; } = false;
        public CleanSession currentSession { get; set; }
        public CleaningProgress cleaningProgressForm;

        public Order orderForm;
        private Register form;
        public string passName;
        public string passSurname;
        public string passNumber;
        public bool em;
        
        public StartupScreen(Register form)
        {
            InitializeComponent();
            this.form = form;
            em = form.emp;
            this.passName = form.passName;
            this.passSurname = form.passSurname;
            this.passNumber = form.passNumber;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (orderForm == null)
            {
                orderForm = new Order(this);
                orderForm.Show();
            }
            else
                orderForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (!cleaning)
            {
                Clean cleanForm = new Clean(this);
                cleanForm.Show();
            }
            else
            {
                cleaningProgressForm.Show();
                cleaningProgressForm.open = true;
            }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.MidnightBlue;
            Cursor = Cursors.Hand;
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.CadetBlue;
            Cursor = Cursors.Default;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Map mapform = new Map(this);
            mapform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Driving drivingForm = new Driving(this);
            drivingForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ControlPanel controlPanelForm = new ControlPanel(this);
            controlPanelForm.Show();
        }

        private void StartupScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void StartupScreen_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            if (em == false)
            {
                button4.Enabled = false;
            }
            else
            {
                button1.Enabled = false;
                button4.Enabled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel1.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Help help = new Help(this);
            help.Show();
        }
    }
}
