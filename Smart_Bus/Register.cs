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
    public partial class Register : Form
    {
        public bool emp = false;
        public string passName;
        public string passSurname;
        public string passNumber;
        public Register()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.MidnightBlue;
            Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.CadetBlue;
            Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text)) && comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("All fields are required. Please fill in all the information.");
            }
            else if ((!string.IsNullOrWhiteSpace(textBox1.Text) || !string.IsNullOrWhiteSpace(textBox2.Text) || !string.IsNullOrWhiteSpace(textBox3.Text)) && comboBox1.SelectedIndex == 0)
            {
                emp = false;
                passName = textBox1.Text;
                passSurname = textBox2.Text;
                passNumber = textBox3.Text;

                this.Hide();
                StartupScreen r = new StartupScreen(this);
                r.Show();
            }
            else if (textBox1.Text == "A123!" && textBox2.Text == "Ado123!" && comboBox1.SelectedIndex == 1)
            {
                emp = true;
                this.Hide();
                StartupScreen r = new StartupScreen(this);
                r.Show();
            }       
            else if ((textBox1.Text != "A123!" || textBox2.Text != "Ado123!") && comboBox1.SelectedIndex == 1)
            {
                MessageBox.Show("Wrong Username or Password");
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true; 
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                textBox3.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
                label1.Text = "Login";
                label1.Location = new Point(139, 11);
                label2.Text = "Username";
                label3.Text = "Password";
                button1.Text = "Login";
            }
            else
                PassengerScreen();
        }
        private void PassengerScreen()
        {
            label1.Text = "Register";
            label1.Location = new Point(119, 11);
            label2.Text = "Name";
            label3.Text = "Surname";
            label4.Visible = true;
            textBox3.Visible = true;
            label6.Visible = true;
            button1.Text = "Register";
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}
