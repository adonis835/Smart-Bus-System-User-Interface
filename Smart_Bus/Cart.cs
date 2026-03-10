using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Smart_Bus
{

    public partial class Cart : Form
    {
        private Coffee_house form;
        private Coffee_Shop form2;
        private Coffee_Place form3;

        String t1 = "Number";
        String t2 = "MM/YY";
        String t3 = "CVV";

        private List<ItemForm.Cart> cartItems;

        public string passName;
        public string passSurname;
        public string passNumber;

        public Cart(Coffee_house form, List<ItemForm.Cart> cartItems)
        {
            InitializeComponent();
            this.form = form;
            this.cartItems = cartItems;
            this.passName = form.passName;
            this.passSurname = form.passSurname;
            this.passNumber = form.passNumber;
            LoadCartItems();
        }
        public Cart(Coffee_Shop form, List<ItemForm.Cart> cartItems)
        {
            InitializeComponent();
            this.form2 = form;
            this.cartItems = cartItems;
            this.passName = form.passName;
            this.passSurname = form.passSurname;
            this.passNumber = form.passNumber;
            LoadCartItems();
        }
        public Cart(Coffee_Place form, List<ItemForm.Cart> cartItems)
        {
            InitializeComponent();
            this.form3 = form;
            this.cartItems = cartItems;
            this.passName = form.passName;
            this.passSurname = form.passSurname;
            this.passNumber = form.passNumber;
            LoadCartItems();
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            textBox2.Text = t1;
            textBox3.Text = t2;
            textBox4.Text = t3;
            textBox2.ForeColor = Color.Gray;
            textBox3.ForeColor = Color.Gray;
            textBox4.ForeColor = Color.Gray;

            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.AutoScroll = true;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("Darling Harbour");
            comboBox1.Items.Add("Queen Victoria Building");
            comboBox1.Items.Add("Sydney Observatory");
            comboBox1.Items.Add("Harbour Bridge");
            comboBox1.Items.Add("Circular Quay");
            comboBox1.Items.Add("Opera House");
            comboBox1.Items.Add("Royal Botanic Garden");
            comboBox1.Items.Add("Tower eye");
            comboBox1.Items.Add("Hyde Park");
            comboBox1.Items.Add("Australian Museum");

            textBox2.MaxLength = 19;
            textBox3.MaxLength = 5;
            textBox4.MaxLength = 3;

            button1.Enabled = false;

        }



        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(textBox2.Text == t1)
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = t1;
                textBox2.ForeColor = Color.Gray;
            }
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == t2)
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = t2;
                textBox3.ForeColor = Color.Gray;
            }
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == t3)
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = t3;
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(form != null)
            {
                form.UpdateCartButton();
                this.Hide();
                form.Show();
            }
            else if (form2 != null)
            {
                form2.UpdateCartButton();
                this.Hide();
                form2.Show();
            }
            else if (form3 != null)
            {
                form3.UpdateCartButton();
                this.Hide();
                form3.Show();
            }
        }
        private void LoadCartItems()
        {
            flowLayoutPanel1.Controls.Clear();
            label10.Text = "Total: $" + cartItems.Sum(item => item.options.finalPrice).ToString("0.00");

            foreach (var cartItem in cartItems)
            {
                Panel panel = new Panel();
                panel.Size = new Size(650, 120);
                panel.BorderStyle = BorderStyle.FixedSingle;

                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(130, 120);
                pictureBox.Location = new Point(0, 0);
                pictureBox.Image = cartItem.item.img;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                panel.Controls.Add(pictureBox);

                Label name = new Label();
                name.Text = cartItem.item.Name;
                name.Font = new Font("Arial", 16, FontStyle.Bold);
                name.Location = new Point(150, 5);
                name.AutoSize = true;
                panel.Controls.Add(name);
                flowLayoutPanel1.Controls.Add(panel);

                Label quantity = new Label();
                quantity.Text = "Quantity: " + cartItem.quantity.ToString();
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

                Button remove = new Button();
                remove.BackgroundImage = Properties.Resources.trash_icon;
                remove.BackgroundImageLayout = ImageLayout.Stretch;
                remove.Size = new Size(30, 30);
                remove.Location = new Point(615, 40);
                remove.Click += removeButton_Click;
                remove.MouseEnter += button_MouseEnter;
                remove.MouseLeave += button_MouseLeave;
                remove.Tag = cartItem;
                panel.Controls.Add(remove);

                Button add = new Button();
                add.Text = "+";
                add.Font = new Font("Arial", 12, FontStyle.Bold);
                add.Size = new Size(30, 30);
                add.Location = new Point(585, 40);
                add.Click += addButton_Click;
                add.MouseEnter += button_MouseEnter;
                add.MouseLeave += button_MouseLeave;
                add.Tag = cartItem;
                panel.Controls.Add(add);
            }
            if(cartItems.Count == 0)
            {
                this.Close();
                if (form != null)
                {
                    form.UpdateCartButton();
                    form.Show();
                }
                else if (form2 != null)
                {
                    form2.UpdateCartButton();
                    form2.Show();
                }
                else if (form3 != null)
                {
                    form3.UpdateCartButton();
                    form3.Show();
                }
            }
        }

        private void Remove_MouseEnter(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ItemForm.Cart cartItem = button.Tag as ItemForm.Cart;
            if(cartItem == null) return;
            if(cartItem.quantity > 1)
            {
                cartItem.quantity -= 1;
                cartItem.options.finalPrice -= cartItem.item.price;
            }
            else if (cartItem.quantity == 1)
            {
                cartItems.Remove(cartItem);
            }    
                LoadCartItems();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ItemForm.Cart cartItem = button.Tag as ItemForm.Cart;
            if (cartItem == null) return;
            cartItem.quantity += 1;
            cartItem.options.finalPrice += cartItem.item.price;
            LoadCartItems();
            
        }

        private void Cart_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (form != null)
            {
                form.Show();
            }
            else if (form2 != null)
            {
                form2.Show();
            }
            else if (form3 != null)
            {
                form3.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = new Random().Next(10, 30);
            MessageBox.Show("Payment Successful! Your order will be delivered in "+ num + " minutes at stop '"+ comboBox1.SelectedItem.ToString() + "'.\nOrder Information:" +
                "\nName: " +  passName + "\nSurname: " + passSurname + "\nMobile Number: " + passNumber );


            if (form != null)
            {
                form.orderform.n++;

                OrderEntry newOrder = new OrderEntry()
                {
                    OrderNumber = form.orderform.n,
                    stop = comboBox1.SelectedItem.ToString(),
                    delivery = num,
                    price = (float)cartItems.Sum(item => item.options.finalPrice),
                    Items = cartItems.Select(c => c).ToList()
                };
                
                form.orderform.myOrders.Add(newOrder);
                cartItems.Clear();
                form.UpdateCartButton();
                this.Close();
                form.Show();
            }
            else if (form2 != null)
            {
                form2.orderform.n++;

                OrderEntry newOrder = new OrderEntry()
                {
                    OrderNumber = form2.orderform.n,
                    stop = comboBox1.SelectedItem.ToString(),
                    delivery = num,
                    price = (int)cartItems.Sum(item => item.options.finalPrice),
                    Items = cartItems.Select(c => c).ToList()
                };

                form2.orderform.myOrders.Add(newOrder);
                cartItems.Clear();
                form2.UpdateCartButton();
                this.Close();
                form2.Show();
            }
            else if (form3 != null)
            {
                form3.orderform.n++;

                OrderEntry newOrder = new OrderEntry()
                {
                    OrderNumber = form3.orderform.n,
                    stop = comboBox1.SelectedItem.ToString(),
                    delivery = num,
                    price = (int)cartItems.Sum(item => item.options.finalPrice),
                    Items = cartItems.Select(c => c).ToList()
                };

                form3.orderform.myOrders.Add(newOrder);
                cartItems.Clear();
                form3.UpdateCartButton();
                this.Close();
                form3.Show();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if(char.IsDigit(e.KeyChar) && textBox2.Text.Length == 4 || textBox2.Text.Length == 9 || textBox2.Text.Length == 14)
            {
                textBox2.Text += " ";
                textBox2.SelectionStart = textBox2.Text.Length;
            }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar) && textBox3.Text.Length == 2)
            {
                textBox3.Text += "/";
                textBox3.SelectionStart = textBox3.Text.Length;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void ValidatePaymentFields()
        {
            bool valid = textBox2.Text.Length == 19 && textBox3.Text.Length == 5 && textBox4.Text.Length == 3;    
            if(valid && comboBox1.SelectedIndex != -1)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            ValidatePaymentFields();
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
