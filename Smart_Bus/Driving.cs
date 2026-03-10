using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Bus
{
    public partial class Driving : Form
    {
        int n = 0;
        StartupScreen mainForm;
        Label l;
        public Driving(StartupScreen mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void Driving_Load(object sender, EventArgs e)
        {
            timer1.Interval = 3000;
            timer1.Start();
            timer2.Interval = 10000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            n++;
            int m = new Random().Next(65, 75);
            label1.Text = m.ToString();
            label1.Location = new Point(373, 243);
            if (m > 70)
            {
                label3.Text = "Speed limit exceeded. Slow down!";
                label3.Location = new Point(210, 82);
                label3.BackColor = Color.Red;
                System.Media.SystemSounds.Beep.Play();
            }
            else if (m <= 70)
            {
                label3.Text = "Speed is within safe limits.";
                label3.Location = new Point(255, 82);
                label3.BackColor = Color.LightGreen;
            }
            if (n == 5)
            {
                timer1.Stop();
                label1.Text = "0";
                label1.Location = new Point(380, 243);
                label3.Text = "Destination reached. Doors are open - passengers are exiting!";
                label3.Location = new Point(30, 82);
                label3.BackColor = Color.LightBlue;
                l = new Label();
                l.Text = "Are you tired? How about ordering a coffee?";
                l.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
                l.AutoSize = true;
                l.Location = new Point(150,50);
                this.Controls.Add(l);
                l.Visible = true;
                timer2.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            n = 0;
            label3.Text = "All passengers have exited. Ready for next destination.";
            label3.Location = new Point(70, 82);
            label3.BackColor = Color.LightGray;
            timer2.Stop();
            timer1.Start();
            l.Visible = false;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void Driving_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Show();
        }
    }
}
 