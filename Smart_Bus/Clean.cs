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
    public partial class Clean : Form
    {
        private StartupScreen startupForm;
        private Button method = null;
        private Button time = null;
        private List<Button> buttons = new List<Button>();
        public Clean(StartupScreen startupForm)
        {
            InitializeComponent();
            this.startupForm = startupForm;
        }

        private void Clean_Load(object sender, EventArgs e)
        {

            button2.Enabled = false;
            button10.Tag = "area1";
            button7.Tag = "area2";
            button9.Tag = "area3";
            button8.Tag = "area4";
            button12.Tag = "area5";
            button11.Tag = "area6";
            button13.Tag = "area7";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            startupForm.Show();
        }

        private void Clean_FormClosing(object sender, FormClosingEventArgs e)
        {
            startupForm.Show();
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Cursor = Cursors.Hand;
            if (!buttons.Contains(btn))
            {
                btn.BackColor = Color.LightBlue;
            }
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Cursor = Cursors.Default;
            if (!buttons.Contains(btn))
                btn.BackColor = Color.White;
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (buttons.Contains(btn))
            {
                buttons.Remove(btn);
                btn.BackColor = Color.White;
            }
            else
            {
                buttons.Add(btn);
                btn.BackColor = Color.LightBlue;
            }
            if (method != null && buttons.Count > 0)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }
        private void buttonMethod_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Cursor = Cursors.Hand;
            if (method != btn)
            {
                btn.BackColor = Color.LightBlue;
            }
        }
        private void buttonMethod_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Cursor = Cursors.Default;
            if (method != btn)
                btn.BackColor = Color.White;
        }
        private void buttonMethod_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (method != null)
            {
                method.BackColor = Color.White;
            }
            method = btn;
            method.BackColor = Color.LightBlue;
            if (buttons.Count > 0)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }
        private void buttonTime_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Cursor = Cursors.Hand;
            if (time != btn)
            {
                btn.BackColor = Color.LightBlue;
            }
        }
        private void buttonTime_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Cursor = Cursors.Default;
            if (time != btn)
                btn.BackColor = Color.White;
        }
        private void buttonTime_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (time != null)
            {
                time.BackColor = Color.White;
            }
            time = btn;
            time.BackColor = Color.LightBlue;
            if (button15.BackColor == Color.LightBlue)
            {
                label4.Text = "Time: 15'";
                trackBar1.Value = 15;
            }
            else if (button14.BackColor == Color.LightBlue)
            {
                label4.Text = "Time: 30'";
                trackBar1.Value = 30;
            }
            else if (button6.BackColor == Color.LightBlue)
            {
                label4.Text = "Time: 50'";
                trackBar1.Value = 50;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CleanSession session = new CleanSession();

            foreach (Button btn in buttons)
            {
                if (btn.Tag != null)
                    session.Areas.Add(btn.Tag.ToString());
            }

            session.Method = method?.Text;
            session.Minutes = trackBar1.Value;

            startupForm.cleaning = true;
            startupForm.currentSession = session;

            startupForm.cleaningProgressForm = new CleaningProgress(startupForm, session);
            startupForm.cleaningProgressForm.open = true;
            startupForm.cleaningProgressForm.Show();
            this.Hide();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = "Time: " + trackBar1.Value.ToString() + "'";
            if (time != null)
            {
                time.BackColor = Color.White;
                time = null;
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
    public class CleanSession
    {
        public List<string> Areas { get; set; } = new List<string>();
        public string Method { get; set; }
        public int Minutes { get; set; }
    }
}
