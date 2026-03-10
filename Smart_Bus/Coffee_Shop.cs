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
    public partial class Coffee_Shop : Form
    {
        public Order orderform;
        private Dictionary<string, Label> categoryLabels;
        public List<ItemForm.Cart> globalCart = new List<ItemForm.Cart>();

        public string passName;
        public string passSurname;
        public string passNumber;
        public Coffee_Shop(Order orderForm)
        {
            InitializeComponent();
            this.orderform = orderForm;
            this.passName = orderForm.passName;
            this.passSurname = orderForm.passSurname;
            this.passNumber = orderForm.passNumber;
        }

        public static class Categories
        {
            public const String Hot_Coffees = "Hot Coffees";
            public const String Cold_Coffees = "Cold Coffees";
            public const String Soft_Drinks = "Soft Drinks";
            public const String Beverages = "Beverages";
            public const String Light_Meals = "Light Meals";
        }
        private void Coffee_Shop_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.AutoScroll = true;

            UpdateCartButton();

            List<Item> items = new List<Item>()
            {

                new Item() { Name = "Espresso", Description = "Strong and bold coffee", img = Properties.Resources.espresso, Categories = Categories.Hot_Coffees,price = 5.30f },
                new Item() { Name = "Cappuccino", Description = "Espresso with steamed milk and foam", img = Properties.Resources.cappuchino, Categories = Categories.Hot_Coffees,price = 7.00f },
                new Item() { Name = "Latte", Description = "Espresso with steamed milk", img = Properties.Resources.latte, Categories = Categories.Hot_Coffees,price = 7.00f},
                new Item() { Name = "Mocha", Description = "Espresso with chocolate and steamed milk", img = Properties.Resources.mocha, Categories = Categories.Hot_Coffees,price = 7.50f },
                new Item() { Name = "Americano", Description = "Espresso with hot water", img = Properties.Resources.americano, Categories = Categories.Hot_Coffees,price = 6.50f },
                new Item() {Name = "Flat White", Description = "Espresso with steamed milk and thin foam", img = Properties.Resources.flat_white, Categories = Categories.Hot_Coffees,price = 7.50f },
                new Item() {Name = "Filter Coffee", Description = "Brewed coffee with a rich flavor", img = Properties.Resources.filter_coffee, Categories = Categories.Hot_Coffees,price = 6.80f},

                new Item() { Name = "Freddo Espresso", Description = "Iced espresso",img = Properties.Resources.fredo_espresso,Categories = Categories.Cold_Coffees,price = 6.50f },
                new Item() { Name = "Freddo Cappuccino", Description = "Iced espresso with cold milk foam",img = Properties.Resources.freddo_cappuccino,Categories = Categories.Cold_Coffees,price = 7.00f },
                new Item() { Name = "Iced Latte", Description = "Espresso with cold milk and ice",img = Properties.Resources.iced_latte, Categories = Categories.Cold_Coffees,price = 7.00f },
                new Item() { Name = "Iced Mocha", Description = "Espresso with chocolate, cold milk and ice", img = Properties.Resources.iced_mocha, Categories = Categories.Cold_Coffees,price = 7.50f },
                new Item() { Name = "Iced Americano", Description = "Espresso with cold water and ice" , img = Properties.Resources.iced_americano,Categories = Categories.Cold_Coffees,price = 6.50f },
                new Item() { Name = "Iced Flat White", Description = "Espresso with cold milk", img = Properties.Resources.iced_flat_white, Categories = Categories.Cold_Coffees,price = 7.50f },

                new Item() { Name = "Coca-Cola 330ml", Description = "Classic soft drink", img = Properties.Resources.cocacola, Categories = Categories.Soft_Drinks,price = 5.00f },
                new Item() {Name =  "Coca-Cola Zero 330ml", Description = "Sugar-free soft drink", img = Properties.Resources.cocacola_zero, Categories = Categories.Soft_Drinks,price = 5.00f },
                new Item() { Name = "Fanta 330ml", Description = "Fruit-flavored soft drink", img = Properties.Resources.fanta, Categories = Categories.Soft_Drinks,price = 5.00f },
                new Item() { Name = "Sprite 330ml", Description = "Lemon-lime flavored soft drink", img = Properties.Resources.sprite, Categories = Categories.Soft_Drinks,price = 5.00f },

                new Item() { Name = "Orange Juice", Description = "Freshly squeezed orange juice", img = Properties.Resources.orange_juice, Categories = Categories.Beverages,price = 7.00f },
                new Item() { Name = "Lemonade", Description = "Freshly squeezed lemon drink", img = Properties.Resources.lemonade, Categories = Categories.Beverages,price = 7.00f },
                new Item() { Name = "Iced Tea Peach 330ml", Description = "Tea with ice and sugar peach flavor", img = Properties.Resources.icetea_peach, Categories = Categories.Beverages,price = 5.00f },
                new Item() { Name = "Iced Tea Lemon 330ml", Description = "Tea with ice and sugar lemon flavor", img = Properties.Resources.icetea_lemon, Categories = Categories.Beverages,price = 5.00f },
                new Item() { Name = "Mineral Water 500ml", Description = "Bottled mineral water", img = Properties.Resources.water, Categories = Categories.Beverages,price = 3.00f },
                new Item() { Name = "Green Tea", Description = "Light tea with a fresh, mild taste", img = Properties.Resources.green_tea, Categories = Categories.Beverages,price = 5.50f },
                new Item() { Name = "Black Tea", Description = "Rich and full-bodied hot tea", img = Properties.Resources.black_tea, Categories = Categories.Beverages,price = 5.50f },
                new Item() { Name = "Hot Chocolate", Description = "Rich cocoa with milk", img = Properties.Resources.hot_chocolate, Categories = Categories.Beverages,price = 6.00f },
                

                new Item() { Name = "Chicken Sandwich", Description = "Grilled chicken with lettuce and tomato", img = Properties.Resources.chicken, Categories = Categories.Light_Meals,price = 14.00f },
                new Item() { Name = "Veggie Wrap", Description = "Fresh vegetables wrapped in a tortilla", img = Properties.Resources.veggie_wrap, Categories = Categories.Light_Meals,price = 12.00f },
                new Item() { Name = "Caesar Salad", Description = "Crisp romaine with Caesar dressing", img = Properties.Resources.caesar, Categories = Categories.Light_Meals,price = 16.00f },
                new Item() { Name = "Fruit Cup", Description = "Fresh fruit in a cup", img = Properties.Resources.fruitcup, Categories = Categories.Light_Meals,price = 11.00f },
                new Item() { Name = "Crossant", Description = "Flaky croissant filled with chocolate", img = Properties.Resources.croissant, Categories = Categories.Light_Meals,price = 11.50f },
                new Item() { Name = "Muffin", Description = "A small, soft, and slightly sweet baked treat", img = Properties.Resources.muffin, Categories = Categories.Light_Meals,price = 10.00f },
                new Item() { Name = "Brownie", Description = "Rich and fudgy chocolate square", img = Properties.Resources.brownie, Categories = Categories.Light_Meals,price = 9.00f },
            };

            string lastCategory = null;
            categoryLabels = new Dictionary<string, Label>();

            foreach (var d in items)
            {
                if (d.Categories != lastCategory)
                {
                    Label header = new Label();
                    header.Text = d.Categories;
                    header.Font = new Font("Arial", 14, FontStyle.Bold);
                    header.Size = new Size(800, 30);
                    flowLayoutPanel1.Controls.Add(header);
                    categoryLabels[d.Categories] = header;
                    lastCategory = d.Categories;
                }

                Panel panel = new Panel();
                panel.Size = new Size(200, 200);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.BackColor = Color.WhiteSmoke;
                panel.Cursor = Cursors.Hand;
                panel.Tag = d;

                Label name = new Label();
                name.Text = d.Name;
                name.Font = new Font("Arial", 12, FontStyle.Bold);
                name.Location = new Point(10, 10);
                name.AutoSize = true;
                name.Tag = d;
                panel.Controls.Add(name);

                Label description = new Label();
                description.Text = d.Description;
                description.Font = new Font("Arial", 10);
                description.Location = new Point(10, 30);
                description.Size = new Size(180, 40);
                description.Tag = d;
                panel.Controls.Add(description);

                Label price = new Label();
                price.Text = $"${d.price:F2}";
                price.Font = new Font("Arial", 10, FontStyle.Italic);
                price.Location = new Point(10, 70);
                price.AutoSize = true;
                panel.Controls.Add(price);


                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(180, 100);
                pictureBox.Location = new Point(10, 95);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = d.img;
                pictureBox.BackColor = Color.White;
                pictureBox.Tag = d;
                panel.Controls.Add(pictureBox);

                panel.MouseClick += Panel_Click;
                name.MouseClick += Label_Click;
                description.MouseClick += Label_Click;
                pictureBox.MouseClick += PictureBox_Click;



                flowLayoutPanel1.Controls.Add(panel);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            orderform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cart cartForm = new Cart(this, globalCart);
            cartForm.Show();
        }
        private void Panel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            Item item = panel.Tag as Item;
            ItemForm form2 = new ItemForm(item, this);
            this.Hide();
            form2.Show();
        }
        private void Label_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            Item item = label.Tag as Item;
            ItemForm form2 = new ItemForm(item, this);
            this.Hide();
            form2.Show();
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            Item item = pictureBox.Tag as Item;
            ItemForm form2 = new ItemForm(item, this);
            this.Hide();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.ScrollControlIntoView(categoryLabels["Hot Coffees"]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.ScrollControlIntoView(categoryLabels["Cold Coffees"]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.ScrollControlIntoView(categoryLabels["Soft Drinks"]);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.ScrollControlIntoView(categoryLabels["Beverages"]);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.ScrollControlIntoView(categoryLabels["Light Meals"]);
        }

        private void Coffee_Shop_FormClosing(object sender, FormClosingEventArgs e)
        {
            orderform.Show();
        }
        public void UpdateCartButton()
        {
            button4.Enabled = globalCart.Count > 0;
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
