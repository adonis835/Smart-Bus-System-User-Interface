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
    public partial class Order : Form
    {
        private StartupScreen startupForm;
        private MyOrder myOrderForm;
        public List<OrderEntry> myOrders = new List<OrderEntry>();

        public string passName;
        public string passSurname;
        public string passNumber;
        public int n = 0;


        public Order(StartupScreen startupForm)
        {
            InitializeComponent();
            this.startupForm = startupForm;
            this.passName = startupForm.passName;
            this.passSurname = startupForm.passSurname;
            this.passNumber = startupForm.passNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            startupForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Coffee_house coffeeForm = new Coffee_house(this);
            coffeeForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Coffee_Shop coffeeShopForm = new Coffee_Shop(this);
            coffeeShopForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Coffee_Place coffeePlaceForm = new Coffee_Place(this);
            coffeePlaceForm.Show();
        }

        private void Order_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            startupForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (myOrders.Count > 0)
            {
                myOrderForm = new MyOrder(this, myOrders);
                myOrderForm.Show();
            }
            else
            {
                MessageBox.Show("You have no orders yet.");
                this.Show();
            }
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
    public class OrderEntry
    {
        public int OrderNumber { get; set; }
        public List<ItemForm.Cart> Items { get; set; } = new List<ItemForm.Cart>();
        public String stop { get; set; }
        public int delivery { get; set; }
        public float price { get; set; }

    }
}
