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
    public partial class Help : Form
    {
        StartupScreen mainForm;
        public Help(StartupScreen mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void Help_Load(object sender, EventArgs e)
        {
            string path = System.IO.Path.Combine(Application.StartupPath, "User_Manual_Smart_Bus.pdf");

            webBrowser1.Navigate(path);
        }

        private void Help_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Show();
        }
    }
}
