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
    public partial class ControlPanel : Form
    {
        StartupScreen mainForm;
        int ACtemp = 24;
        int energyStored = 200;
        int energyConsumption = 15;
        int solarProduction = 15;
        bool status = true;
        bool sunny = true;
        bool heat = true;
        int weatherCon = 0;
        int AC_con = 5;
        int baseCon = 10;
        int en = 5;
        public bool emp1;
        bool roof = true;
        public ControlPanel(StartupScreen mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            emp1 = mainForm.em;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label10.Text = "A/C Status: On - Cool";
            heat = false;
            label5.Text = "A/C Temperature: 24°C";
            label11.Text = "A/C Mode: Normal";
            AC_con = 5;
            ACtemp = 24;
            en = 5;
            UpdateEnergyConsumption();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label10.Text = "A/C Status: On - Heat";
            heat = true;
            label5.Text = "A/C Temperature: 24°C";
            label11.Text = "A/C Mode: Normal";
            AC_con = 5;
            ACtemp = 24;
            en = 5;
            UpdateEnergyConsumption();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (status)
            {
                status = false;
                label10.Text = "A/C Status: Off";
                label5.Text = "A/C Temperature: 0°C";
                label11.Text = "A/C Mode: None";
                AC_con = 0;
                button4.Enabled = false;
                button5.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else if (!status)
            {
                status = true;
                label10.Text = "A/C Status: On - Heat";
                AC_con = 5;
                ACtemp = 24;
                en = 5;
                label5.Text = "A/C Temperature: 24°C";
                label11.Text = "A/C Mode: Normal";
                button4.Enabled = true;
                button5.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
            }
            UpdateEnergyConsumption();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sunny)
            {
                sunny = false;
                pictureBox1.Image = Properties.Resources.rain;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                label2.Text = "Rainy";
                label3.Text = "12°C";
                label4.Text = "Roof Status: Closed";
                roof = false;
                solarProduction = 5;
                weatherCon = 5; 
            }
            else if (!sunny)
            {
                sunny = true;
                pictureBox1.Image = Properties.Resources.sun;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                label2.Text = "Sunny";
                label3.Text = "25°C";
                label4.Text = "Roof Status: Open";
                roof = true;
                solarProduction = 15;
                weatherCon = 0;
            }
            label9.Text = "Solar Production: " + solarProduction + " Kwh";
            UpdateEnergyConsumption();
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timerUpdate.Start();
            if (emp1 == false)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
            }
        }

        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timerUpdate.Stop();
            mainForm.Show();
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (ACtemp < 30)
            {
                ACtemp += 2;
                label5.Text = "A/C Temperature: " + ACtemp + "°C";
                en++;
            }
            else
            {
                MessageBox.Show("A/C Temperature cannot be set higher than 30°C", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button4.Enabled = false;
            }
            if (heat && ACtemp > 24)
            {
                AC_con = 7;
                label11.Text = "A/C Mode: Turbo";
                if (en == 6)
                {
                    MessageBox.Show("Air Condition Turbo mode activated.\nYou are now consuming 2 kwh more.", "Energy Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (!heat && ACtemp > 24)
            {
                AC_con = 3;
                label11.Text = "A/C Mode: Eco";
                if (en == 6)
                {
                    MessageBox.Show("Air Condition Eco mode activated.\nYou are now saving 2 kwh.", "Energy Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (ACtemp >= 22 && ACtemp <= 24)
            {
                AC_con = 5;
                label11.Text = "A/C Mode: Normal";
            }

            UpdateEnergyConsumption();
            button5.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ACtemp > 16)
            {
                ACtemp -= 2;
                label5.Text = "A/C Temperature: " + ACtemp + "°C";
                en--;
            }
            else
            {
                MessageBox.Show("A/C Temperature cannot be set lower than 16°C", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button5.Enabled = false;
            }
            if (heat && ACtemp < 22)
            {
                AC_con = 3;
                label11.Text = "A/C Mode: Eco";
                if (en == 3)
                {
                    MessageBox.Show("Air Condition Eco mode activated.\nYou are now saving 2 kwh.", "Energy Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (!heat && ACtemp < 22)
            {
                AC_con = 7;
                label11.Text = "A/C Mode: Turbo";
                if (en == 3)
                {
                    MessageBox.Show("Air Condition Turbo mode activated.\nYou are now consuming 2 kwh more.", "Energy Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (ACtemp >= 22 && ACtemp <= 24)
            {
                AC_con = 5;
                label11.Text = "A/C Mode: Normal";
            }

            UpdateEnergyConsumption();
            button4.Enabled = true;
        }

        private void timerUpdate_Tick(object sender, EventArgs e) 
        {
            energyStored += solarProduction - energyConsumption;
            label7.Text = "Energy Stored: " + energyStored + " Kwh";
            if (energyStored < 30 && energyStored > 0) 
            {
                MessageBox.Show(
                    "Energy level is low. Please reduce consumption or disable non-essential systems.",
                    "Low Energy Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                label5.Text = "A/C Temperature: 0°C";
                label11.Text = "A/C Mode: None";
                label10.Text = "A/C Status: Off";
                label4.Text = "Roof Status: Closed";
            }
            else if(energyStored <= 0 )
            {
                timer1.Stop();
                timerUpdate.Stop();
                label9.Text = "Solar Production: 0 Kwh";
                label8.Text = "Energy Consumption: 0 Kwh";
                label7.Text = "Energy Stored: 0 Kwh";
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                label5.Text = "A/C Temperature: 0°C";
                label11.Text = "A/C Mode: None";
                label10.Text = "A/C Status: Off";
                label4.Text = "Roof Status: Closed";
                MessageBox.Show("Energy level is zero. The bus systems are shutting down.", "Energy Depleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void UpdateEnergyConsumption()
        {
            energyConsumption = baseCon + AC_con + weatherCon;
            label8.Text = "Energy Consumption: " + energyConsumption + " Kwh";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (roof)
            {
                label4.Text = "Roof Status: Closed";
                roof = false;
            }
            else if (!roof)
            {
                label4.Text = "Roof Status: Open";
                roof = true;
            }
        }
    }
}
