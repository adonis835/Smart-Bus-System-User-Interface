using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Smart_Bus
{
    public partial class CleaningProgress : Form
    {
        private CleanSession cleanSessionForm;
        private StartupScreen startupScreen;
        private Timer timer;
        private int seconds;
        private int totalSeconds;
        public bool open;



        public CleaningProgress(StartupScreen startupScreen, CleanSession cleanSessionForm)
        {
            InitializeComponent();
            this.startupScreen = startupScreen;
            this.cleanSessionForm = cleanSessionForm;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (cleaningState.remainingTime <= 0)
            {
                timer.Stop();
                cleaningState.running = false;
                cleaningState.remainingTime = 0;

                startupScreen.cleaning = false;
                startupScreen.currentSession = null;

                ValuablesCheck();

                this.Close();
            }
            seconds--;
            panel1.Invalidate(); 
            cleaningState.remainingTime--;
            UpdateTimeLabel();
        }

        private void CleaningProgress_Load(object sender, EventArgs e)
        {
            if (timer == null)
            {
                timer = new Timer();
                timer.Interval = 1000;
                timer.Tick += Timer_Tick;
                timer.Start();
            }

            if (!cleaningState.running)
            {
                cleaningState.remainingTime = cleanSessionForm.Minutes * 60;
                cleaningState.running = true;
            }
            UpdateTimeLabel();

            label5.Text = cleanSessionForm.Method;
            button10.Tag = "area1";
            button7.Tag = "area2";
            button9.Tag = "area3";
            button8.Tag = "area4";
            button12.Tag = "area5";
            button11.Tag = "area6";
            button13.Tag = "area7";

            seconds = cleaningState.remainingTime;
            totalSeconds = cleaningState.remainingTime;

            foreach (Button btn in GetAllButtons(this))
            {
                if (btn.Tag == null) continue;

                if (cleanSessionForm.Areas.Contains(btn.Tag.ToString()))
                {
                    btn.BackColor = Color.LightBlue;
                }
            }
        }
        private IEnumerable<Button> GetAllButtons(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn)
                    yield return btn;

                foreach (var child in GetAllButtons(c))
                    yield return child;
            }
        }

        private void CleaningProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            if (open)
            {
                startupScreen.Show();
                open = false;
            }
        }
        private void UpdateTimeLabel()
        {
            int minutes = cleaningState.remainingTime / 60;
            int seconds = cleaningState.remainingTime % 60;
            label1.Text = $"{minutes}:{seconds:D2}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the cleaning session?", "Confirm Cancellation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                timer.Stop();
                cleaningState.running = false;
                cleaningState.remainingTime = 0;

                startupScreen.cleaning = false;
                startupScreen.currentSession = null;

                MessageBox.Show(
                    "Cleaning session cancelled.\nIf there are valuables or trash, they will remain uncollected.","Session Cancelled",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                this.Close();
            }
        }
        public static class cleaningState
        {
            public static int remainingTime;
            public static bool running;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(cleaningState.running)
            {
                cleaningState.running = false;
                timer.Stop();
                button3.Text = "START";
            }
            else
            {
                cleaningState.running = true;
                timer.Start();
                button3.Text = "STOP";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            float progress =  (float)(totalSeconds - seconds) / (totalSeconds); // Υπολογισμος προοδου για τελος καθαρισμου και ολοκληρωση του κυκλου

            Graphics g = e.Graphics; 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;// Ομαλη σχεδιαση

            Rectangle rect = new Rectangle(350, 170, 230, 230);// Ορισμος περιοχης σχεδιασης

            using (Pen pen = new Pen(Color.LightGray, 12))// Χρωμα και παχος γραμμης υποβαθρου
                g.DrawArc(pen, rect, -90, 360); // Σχεδιαση κυκλου υποβαθρου, παιρνει την πενα και την περιοχη σχεδιασης, γωνια εκκινησης και γωνια τελους

            using (Pen progressPen = new Pen(Color.DodgerBlue, 12))
                g.DrawArc(progressPen, rect, -90, progress * 360);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ValuablesCheck()
        {
            Random rnd = new Random();
            int passport = 0;
            int jewelry = 0;
            int money = 0;
            int trash = 0;

            int total = cleanSessionForm.Minutes * 2;

            for (int i = 0; i < total; i++)
            {
                bool foundValuable = rnd.Next(0, 10) < 2; // 20% πιθανότητα

                if (foundValuable)
                {
                    int choice = rnd.Next(0, 3);

                    switch (choice)
                    {
                        case 0: passport++; break;
                        case 1: jewelry++; break;
                        case 2: money++; break;
                    }
                }
                else
                {
                    trash++;
                }
            }

            MessageBox.Show(
                "The robot vacuum has finished cleaning and is returning to its dock!\n\n" +
                "Cleaning summary:\n" +
                $"• Jewelry found: {jewelry}\n" +
                $"• Money found: {money}\n" +
                $"• Passports found: {passport}\n" +
                $"• Trash collected: {trash}",
                "Cleaning Report",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Cursor = Cursors.Hand;
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Cursor = Cursors.Default;
        }
    }
}
