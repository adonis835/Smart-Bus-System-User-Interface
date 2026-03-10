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
    public partial class DriversView : Form
    {
        Point point;
        bool drag = false;
        Map map;
        public DriversView(Map map)
        {
            InitializeComponent();
            this.map = map;
        }

        private void DriversView_MouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;
            drag = true;
        }

        private void DriversView_MouseUp(object sender, MouseEventArgs e)
        {
            int direction = e.Location.X - point.X;
            drag = false;
            const int swipe = 50;

            if (direction < -swipe)
            {
                right();
            }
            else if (direction > swipe)
            {
                left();
            }
        }
        private void right() {
            if ((string)this.Tag == "drivers view")
            {
                this.BackgroundImage = Properties.Resources.right;
                this.Tag = "right";
            }else if ((string)this.Tag == "left")
            {
                this.BackgroundImage = Properties.Resources.drivers_view;
                this.Tag = "drivers view";
            }
        }
        private void left() {
            if ((string)this.Tag == "drivers view")
            {
                this.BackgroundImage= Properties.Resources.left;
                this.Tag = "left";
            } else if ((string)this.Tag == "right")
            {
                this.BackgroundImage = Properties.Resources.drivers_view;
                this.Tag = "drivers view";
            }
        }

        private void DriversView_FormClosing(object sender, FormClosingEventArgs e)
        {
            map.Show();
        }

        private void DriversView_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.drivers_view;
            this.Tag = "drivers view";
            MessageBox.Show("Swipe left or right to change view");
        }
    }
}
