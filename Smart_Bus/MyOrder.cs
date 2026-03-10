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
    public partial class MyOrder : Form
    {
        private List<OrderEntry> orders;
        private Order form;

        public MyOrder(Order form, List<OrderEntry> orders)
        {
            InitializeComponent();
            this.orders = orders;
            this.form = form;
        }

        private void MyOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Show();
        }

        private void MyOrder_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            foreach (var order in orders)
            {
                Label header = new Label();
                header.Text = $"Order {order.OrderNumber}"; 
                header.Font = new Font("Arial", 20, FontStyle.Bold);
                header.Size = new Size(600,30);
                flowLayoutPanel1.Controls.Add(header);

                Label des = new Label();
                des.Text = " Stop: " + order.stop + " | Delivery Time: " + order.delivery + "'" + " | Price: $" + order.price.ToString("0.00");
                des.Font = new Font("Arial", 14, FontStyle.Regular);
                des.AutoSize = true;
                flowLayoutPanel1.Controls.Add(des);


                foreach (var cartItem in order.Items)
                {
                    Panel panel = new Panel();
                    panel.Size = new Size(650, 120);
                    panel.BorderStyle = BorderStyle.FixedSingle;

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(130, 120);
                    pictureBox.Image = cartItem.item.img;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel.Controls.Add(pictureBox);

                    Label name = new Label();
                    name.Text = cartItem.item.Name;
                    name.Font = new Font("Arial", 16, FontStyle.Bold);
                    name.Location = new Point(150, 5);
                    name.AutoSize = true;
                    panel.Controls.Add(name);

                    Label quantity = new Label();
                    quantity.Text = "Quantity: " + cartItem.quantity;
                    quantity.Font = new Font("Arial", 12, FontStyle.Bold);
                    quantity.Location = new Point(550, 10);
                    quantity.AutoSize = true;
                    panel.Controls.Add(quantity);

                    Label description = new Label();
                    description.Text = cartItem.options.ToString();
                    description.Font = new Font("Arial", 10, FontStyle.Regular);
                    description.Location = new Point(150, 35);
                    description.Size = new Size(400, 80);
                    panel.Controls.Add(description);

                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
        }
    }
}
