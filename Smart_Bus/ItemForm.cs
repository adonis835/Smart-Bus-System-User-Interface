using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Smart_Bus
{
    
    public partial class ItemForm : Form
    {
        private Item item;
        int n = 1;
        float basePrice;
        float sizeExtra = 0f;
        float addonExtra = 0f;
        Label p;
        List<Cart> cartItems = new List<Cart>();
        private Coffee_house coffeeHouseForm;
        ComboBox sizeBox;
        ComboBox sugarBox;
        ComboBox milkBox;
        ComboBox addBox;
        ComboBox removeBox;
        ComboBox honeyBox;
        CheckedListBox ingredientsBox;
        CheckedListBox addInBox;
        private Coffee_Shop coffeeshopform;
        private Coffee_Place coffeeplaceform;


        public class Addon
        {
            public string Name { get; set; }
            public float Price { get; set; }

            public override string ToString() => Name; // Να εμφανιζει το ονομα, χωρις αυτο να εμφανιζει το namespace
        }

        public class Cart 
        {
            public Item item { get; set; }
            public int quantity { get; set; }

            public Options options { get; set; }
            public int n { get; set; }
        }
        
        public class Options
        {
            public String size { get; set; }
            public String sugar { get; set; }
            public String milk { get; set; }
            public String add { get; set; }
            public String remove { get; set; }
            public String honey { get; set; }
            public float finalPrice { get; set; }

            public List<string> ingredients { get; set; } = new List<string>();
            public List<Addon> addIns { get; set; } = new List<Addon>();
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(size)) sb.AppendLine($"Size: {size}");
                if (!string.IsNullOrEmpty(sugar)) sb.AppendLine($"Sugar: {sugar}");
                if (!string.IsNullOrEmpty(milk)) sb.AppendLine($"Milk: {milk}");
                if (!string.IsNullOrEmpty(add)) sb.AppendLine($"Add: {add}");
                if (!string.IsNullOrEmpty(remove)) sb.AppendLine($"Remove: {remove}");
                if (!string.IsNullOrEmpty(honey)) sb.AppendLine($"Honey: {honey}");
                if (ingredients.Count > 0)
                {
                    sb.AppendLine("Ingredients: " + string.Join(", ", ingredients));
                }
                if (addIns.Count > 0)
                {
                    sb.AppendLine("Add: " + string.Join(", ", addIns.Select(a => a.Name)));
                }
                sb.AppendLine($"Final Price ${finalPrice:F2}");
                return sb.ToString();
            }

        }

        public ItemForm(Item item, Coffee_house coffeeHouseForm)
        {
            InitializeComponent();
            this.item = item;
            this.coffeeHouseForm = coffeeHouseForm; 
            Main();
        }
        public ItemForm(Item item, Coffee_Shop coffeeshopform)
        {
            InitializeComponent();
            this.item = item;
            this.coffeeshopform = coffeeshopform; 
            Main();
        }
        public ItemForm(Item item, Coffee_Place coffeeplaceform)
        {
            InitializeComponent();
            this.item = item;
            this.coffeeplaceform = coffeeplaceform; 
            Main();
        }



        private void Main()
        {
            basePrice = item.price;
            pictureBox1.Image = item.img;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.AutoScroll = true;

            Label name = new Label();
            name.Text = item.Name;
            name.Font = new Font("Arial", 16, FontStyle.Bold);
            name.AutoSize = true;
            flowLayoutPanel1.Controls.Add(name);

            Label d = new Label();
            d.Text = item.Description;
            d.Font = new Font("Arial", 12, FontStyle.Regular);
            d.Size = new Size(400, 25);
            flowLayoutPanel1.Controls.Add(d);

            p = new Label();
            p.Text = $"${item.price:F2}";
            p.Font = new Font("Arial", 14, FontStyle.Bold);
            p.Size = new Size(200, 30);
            flowLayoutPanel1.Controls.Add(p);

            if (item.Categories == "Hot Coffees" || item.Categories == "Cold Coffees")
            {
                Label l = new Label();
                l.Text = "Size";
                l.Font = new Font("Arial", 16, FontStyle.Bold);
                l.Size = new Size(200, 25);
                flowLayoutPanel1.Controls.Add(l);

                sizeBox = new ComboBox();
                sizeBox.Items.AddRange(new string[] { "Small", "Medium", "Large" });
                sizeBox.SelectedIndex = 0;
                sizeBox.Font = new Font("Arial", 12, FontStyle.Regular);
                sizeBox.DropDownStyle = ComboBoxStyle.DropDownList;
                sizeBox.SelectedIndexChanged += SizeBox_SelectedIndexChanged;
                sizeBox.MouseEnter += button_MouseEnter;
                sizeBox.MouseLeave += button_MouseLeave;
                sizeBox.Size = new Size(455, 30);
                flowLayoutPanel1.Controls.Add(sizeBox);

                Label sugar = new Label();
                sugar.Text = "Sugar";
                sugar.Font = new Font("Arial", 16, FontStyle.Bold);
                sugar.AutoSize = true;
                flowLayoutPanel1.Controls.Add(sugar);

                sugarBox = new ComboBox();
                sugarBox.Items.AddRange(new string[] { "No Sugar", "1 tsp", "2 tsp", "3 tsp", "4 tsp", "5 tsp" });
                sugarBox.SelectedIndex = 0;
                sugarBox.Font = new Font("Arial", 12, FontStyle.Regular);
                sugarBox.DropDownStyle = ComboBoxStyle.DropDownList;
                sugarBox.Size = new Size(455, 30);
                sugarBox.MouseEnter += button_MouseEnter;
                sugarBox.MouseLeave += button_MouseLeave;
                flowLayoutPanel1.Controls.Add(sugarBox);

                Label milk = new Label();
                milk.Text = "Milk";
                milk.Font = new Font("Arial", 16, FontStyle.Bold);
                milk.Size = new Size(200, 25);
                flowLayoutPanel1.Controls.Add(milk);

                milkBox = new ComboBox();
                milkBox.Items.AddRange(new string[] { "Whole Milk", "Skim Milk", "Soy Milk", "Almond Milk", "Oat Milk" });
                milkBox.SelectedIndex = 0;
                milkBox.Font = new Font("Arial", 12, FontStyle.Regular);
                milkBox.DropDownStyle = ComboBoxStyle.DropDownList;
                milkBox.Size = new Size(455, 30);
                milkBox.MouseEnter += button_MouseEnter;
                milkBox.MouseLeave += button_MouseLeave;
                flowLayoutPanel1.Controls.Add(milkBox);

                Label add = new Label();
                add.Text = "Add";
                add.Font = new Font("Arial", 16, FontStyle.Bold);
                add.AutoSize = true;
                flowLayoutPanel1.Controls.Add(add);

                addBox = new ComboBox();
                addBox.Items.AddRange(new string[] { "None", "Extra Espresso Shot" });
                addBox.SelectedIndex = 0;
                addBox.Font = new Font("Arial", 12, FontStyle.Regular);
                addBox.DropDownStyle = ComboBoxStyle.DropDownList;
                addBox.Size = new Size(455, 30);
                addBox.SelectedIndexChanged += AddBox_SelectedIndexChanged;
                addBox.MouseEnter += button_MouseEnter;
                addBox.MouseLeave += button_MouseLeave;
                flowLayoutPanel1.Controls.Add(addBox);

            }
            if (item.Categories == "Soft Drinks")
            {
                Label add = new Label();
                add.Text = "Add";
                add.Font = new Font("Arial", 16, FontStyle.Bold);
                add.AutoSize = true;
                flowLayoutPanel1.Controls.Add(add);

                addBox = new ComboBox();
                addBox.Items.AddRange(new string[] { "None", "Cup", "Cup With Ice" });
                addBox.SelectedIndex = 0;
                addBox.Font = new Font("Arial", 12, FontStyle.Regular);
                addBox.DropDownStyle = ComboBoxStyle.DropDownList;
                addBox.Size = new Size(455, 30);
                addBox.MouseEnter += button_MouseEnter;
                addBox.MouseLeave += button_MouseLeave;
                flowLayoutPanel1.Controls.Add(addBox);
            }
            if (item.Categories == "Beverages" && (item.Name == "Orange Juice" || item.Name == "Lemonade"))
            {
                Label l = new Label();
                l.Text = "Size";
                l.Font = new Font("Arial", 16, FontStyle.Bold);
                l.Size = new Size(200, 25);
                flowLayoutPanel1.Controls.Add(l);

                sizeBox = new ComboBox();
                sizeBox.Items.AddRange(new string[] { "Small", "Medium", "Large" });
                sizeBox.SelectedIndex = 0;
                sizeBox.Font = new Font("Arial", 12, FontStyle.Regular);
                sizeBox.DropDownStyle = ComboBoxStyle.DropDownList;
                sizeBox.SelectedIndexChanged += SizeBox_SelectedIndexChanged;
                sizeBox.MouseEnter += button_MouseEnter;
                sizeBox.MouseLeave += button_MouseLeave;
                sizeBox.Size = new Size(455, 30);
                flowLayoutPanel1.Controls.Add(sizeBox);

                Label remove = new Label();
                remove.Text = "Remove";
                remove.Font = new Font("Arial", 16, FontStyle.Bold);
                remove.Size = new Size(200, 25);
                flowLayoutPanel1.Controls.Add(remove);

                removeBox = new ComboBox();
                removeBox.Items.AddRange(new string[] { "None", "Ice" });
                removeBox.SelectedIndex = 0;
                removeBox.Font = new Font("Arial", 12, FontStyle.Regular);
                removeBox.DropDownStyle = ComboBoxStyle.DropDownList;
                removeBox.MouseEnter += button_MouseEnter;
                removeBox.MouseLeave += button_MouseLeave;
                removeBox.Size = new Size(455, 30);
                flowLayoutPanel1.Controls.Add(removeBox);
            }
            if (item.Categories == "Beverages" && (item.Name == "Green Tea" || item.Name == "Black Tea"))
            {
                Label l = new Label();
                l.Text = "Size";
                l.Font = new Font("Arial", 16, FontStyle.Bold);
                l.Size = new Size(200, 25);
                flowLayoutPanel1.Controls.Add(l);

                sizeBox = new ComboBox();
                sizeBox.Items.AddRange(new string[] { "Small", "Medium", "Large" });
                sizeBox.SelectedIndex = 0;
                sizeBox.Font = new Font("Arial", 12, FontStyle.Regular);
                sizeBox.DropDownStyle = ComboBoxStyle.DropDownList;
                sizeBox.SelectedIndexChanged += SizeBox_SelectedIndexChanged;
                sizeBox.MouseEnter += button_MouseEnter;
                sizeBox.MouseLeave += button_MouseLeave;
                sizeBox.Size = new Size(455, 30);
                flowLayoutPanel1.Controls.Add(sizeBox);

                Label sugar = new Label();
                sugar.Text = "Sugar";
                sugar.Font = new Font("Arial", 16, FontStyle.Bold);
                sugar.AutoSize = true;
                flowLayoutPanel1.Controls.Add(sugar);

                sugarBox = new ComboBox();
                sugarBox.Items.AddRange(new string[] { "No Sugar", "1 tsp", "2 tsp", "3 tsp", "4 tsp", "5 tsp" });
                sugarBox.SelectedIndex = 0;
                sugarBox.Font = new Font("Arial", 12, FontStyle.Regular);
                sugarBox.DropDownStyle = ComboBoxStyle.DropDownList;
                sugarBox.MouseEnter += button_MouseEnter;
                sugarBox.MouseLeave += button_MouseLeave;
                sugarBox.Size = new Size(455, 30);
                flowLayoutPanel1.Controls.Add(sugarBox);

                Label honey = new Label();
                honey.Text = "Add";
                honey.Font = new Font("Arial", 16, FontStyle.Bold);
                honey.AutoSize = true;
                flowLayoutPanel1.Controls.Add(honey);

                honeyBox = new ComboBox();
                honeyBox.Items.AddRange(new string[] { "None", "Honey" });
                honeyBox.SelectedIndex = 0;
                honeyBox.Font = new Font("Arial", 12, FontStyle.Regular);
                honeyBox.DropDownStyle = ComboBoxStyle.DropDownList;
                honeyBox.MouseEnter += button_MouseEnter;
                honeyBox.MouseLeave += button_MouseLeave;
                honeyBox.Size = new Size(455, 30);
                flowLayoutPanel1.Controls.Add(honeyBox);
            }
            if (item.Categories == "Beverages" && (item.Name == "Iced Tea Peach 330ml" || item.Name == "Iced Tea Lemon 330ml" || item.Name == "Mineral Water 500ml"))
            {
                Label add = new Label();
                add.Text = "Add";
                add.Font = new Font("Arial", 16, FontStyle.Bold);
                add.AutoSize = true;
                flowLayoutPanel1.Controls.Add(add);

                addBox = new ComboBox();
                addBox.Items.AddRange(new string[] { "None", "Cup", "Cup With Ice" });
                addBox.SelectedIndex = 0;
                addBox.Font = new Font("Arial", 12, FontStyle.Regular);
                addBox.DropDownStyle = ComboBoxStyle.DropDownList;
                addBox.MouseEnter += button_MouseEnter;
                addBox.MouseLeave += button_MouseLeave;
                addBox.Size = new Size(455, 30);
                flowLayoutPanel1.Controls.Add(addBox);
            }
            if (item.Categories == "Beverages" && item.Name == "Hot Chocolate")
            {
                Label l = new Label();
                l.Text = "Size";
                l.Font = new Font("Arial", 16, FontStyle.Bold);
                l.Size = new Size(200, 25);
                flowLayoutPanel1.Controls.Add(l);

                sizeBox = new ComboBox();
                sizeBox.Items.AddRange(new string[] { "Small", "Medium", "Large" });
                sizeBox.SelectedIndex = 0;
                sizeBox.Font = new Font("Arial", 12, FontStyle.Regular);
                sizeBox.DropDownStyle = ComboBoxStyle.DropDownList;
                sizeBox.SelectedIndexChanged += SizeBox_SelectedIndexChanged;
                sizeBox.MouseEnter += button_MouseEnter;
                sizeBox.MouseLeave += button_MouseLeave;
                sizeBox.Size = new Size(455, 30);
                flowLayoutPanel1.Controls.Add(sizeBox);

                Label sugar = new Label();
                sugar.Text = "Sugar";
                sugar.Font = new Font("Arial", 16, FontStyle.Bold);
                sugar.AutoSize = true;
                flowLayoutPanel1.Controls.Add(sugar);

                sugarBox = new ComboBox();
                sugarBox.Items.AddRange(new string[] { "No Sugar", "1 tsp", "2 tsp", "3 tsp", "4 tsp", "5 tsp" });
                sugarBox.SelectedIndex = 0;
                sugarBox.Font = new Font("Arial", 12, FontStyle.Regular);
                sugarBox.DropDownStyle = ComboBoxStyle.DropDownList;
                sugarBox.MouseEnter += button_MouseEnter;
                sugarBox.MouseLeave += button_MouseLeave;
                sugarBox.Size = new Size(455, 30);
                flowLayoutPanel1.Controls.Add(sugarBox);

                Label milk = new Label();
                milk.Text = "Milk";
                milk.Font = new Font("Arial", 16, FontStyle.Bold);
                milk.Size = new Size(200, 25);
                flowLayoutPanel1.Controls.Add(milk);

                milkBox = new ComboBox();
                milkBox.Items.AddRange(new string[] { "Whole Milk", "Skim Milk", "Soy Milk", "Almond Milk", "Oat Milk" });
                milkBox.SelectedIndex = 0;
                milkBox.Font = new Font("Arial", 12, FontStyle.Regular);
                milkBox.DropDownStyle = ComboBoxStyle.DropDownList;
                milkBox.MouseEnter += button_MouseEnter;
                milkBox.MouseLeave += button_MouseLeave;
                milkBox.Size = new Size(455, 30);
                flowLayoutPanel1.Controls.Add(milkBox);

                Label add = new Label();
                add.Text = "Add";
                add.Font = new Font("Arial", 16, FontStyle.Bold);
                add.AutoSize = true;
                flowLayoutPanel1.Controls.Add(add);

                addBox = new ComboBox();
                addBox.Items.AddRange(new string[] { "None", "Marshmallows" });
                addBox.SelectedIndex = 0;
                addBox.Font = new Font("Arial", 12, FontStyle.Regular);
                addBox.DropDownStyle = ComboBoxStyle.DropDownList;
                addBox.MouseEnter += button_MouseEnter;
                addBox.MouseLeave += button_MouseLeave;
                addBox.Size = new Size(455, 30);
                addBox.SelectedIndexChanged += AddBox_SelectedIndexChanged;
                flowLayoutPanel1.Controls.Add(addBox);

            }
            if(item.Categories == "Beverages" && item.Name == "Hot Macha Latte")
            {
                Label l = new Label();
                l.Text = "Size";
                l.Font = new Font("Arial", 16, FontStyle.Bold);
                l.Size = new Size(200, 25);
                flowLayoutPanel1.Controls.Add(l);

                sizeBox = new ComboBox();
                sizeBox.Items.AddRange(new string[] { "Small", "Medium", "Large" });
                sizeBox.SelectedIndex = 0;
                sizeBox.Font = new Font("Arial", 12, FontStyle.Regular);
                sizeBox.DropDownStyle = ComboBoxStyle.DropDownList;
                sizeBox.SelectedIndexChanged += SizeBox_SelectedIndexChanged;
                sizeBox.MouseEnter += button_MouseEnter;
                sizeBox.MouseLeave += button_MouseLeave;
                sizeBox.Size = new Size(455, 30);
                flowLayoutPanel1.Controls.Add(sizeBox);

                Label sugar = new Label();
                sugar.Text = "Sugar";
                sugar.Font = new Font("Arial", 16, FontStyle.Bold);
                sugar.AutoSize = true;
                flowLayoutPanel1.Controls.Add(sugar);

                sugarBox = new ComboBox();
                sugarBox.Items.AddRange(new string[] { "No Sugar", "1 tsp", "2 tsp", "3 tsp", "4 tsp", "5 tsp" });
                sugarBox.SelectedIndex = 0;
                sugarBox.Font = new Font("Arial", 12, FontStyle.Regular);
                sugarBox.DropDownStyle = ComboBoxStyle.DropDownList;
                sugarBox.MouseEnter += button_MouseEnter;
                sugarBox.MouseLeave += button_MouseLeave;
                sugarBox.Size = new Size(455, 30);
                flowLayoutPanel1.Controls.Add(sugarBox);

                Label milk = new Label();
                milk.Text = "Milk";
                milk.Font = new Font("Arial", 16, FontStyle.Bold);
                milk.Size = new Size(200, 25);
                flowLayoutPanel1.Controls.Add(milk);

                milkBox = new ComboBox();
                milkBox.Items.AddRange(new string[] { "Whole Milk", "Skim Milk", "Soy Milk", "Almond Milk", "Oat Milk" });
                milkBox.SelectedIndex = 0;
                milkBox.Font = new Font("Arial", 12, FontStyle.Regular);
                milkBox.DropDownStyle = ComboBoxStyle.DropDownList;
                milkBox.MouseEnter += button_MouseEnter;
                milkBox.MouseLeave += button_MouseLeave;
                milkBox.Size = new Size(455, 30);
                flowLayoutPanel1.Controls.Add(milkBox);
            }
            if (item.Categories == "Light Meals" && item.Name == "Chicken Sandwich")
            {
                Label ingredients = new Label();
                ingredients.Text = "Ingredients";
                ingredients.Font = new Font("Arial", 16, FontStyle.Bold);
                ingredients.Size = new Size(200, 25);
                flowLayoutPanel1.Controls.Add(ingredients);

                ingredientsBox = new CheckedListBox();
                ingredientsBox.Items.AddRange(new string[] { "Chicken Fillet", "Lettuce", "Tomato", "Cheese", "Mayonaise" });
                ingredientsBox.Font = new Font("Arial", 12, FontStyle.Regular);
                ingredientsBox.Size = new Size(455, 110);
                ingredientsBox.CheckOnClick = true;
                ingredientsBox.MouseEnter += button_MouseEnter;
                ingredientsBox.MouseLeave += button_MouseLeave;
                flowLayoutPanel1.Controls.Add(ingredientsBox);
                CheckAllItems(ingredientsBox);

                Label add = new Label();
                add.Text = "Add";
                add.Font = new Font("Arial", 16, FontStyle.Bold);
                add.AutoSize = true;
                flowLayoutPanel1.Controls.Add(add);

                addInBox = new CheckedListBox();
                addInBox.Font = new Font("Arial", 12, FontStyle.Regular);
                addInBox.Size = new Size(455, 80);
                addInBox.CheckOnClick = true;
                addInBox.MouseEnter += button_MouseEnter;
                addInBox.MouseLeave += button_MouseLeave;
                addInBox.Items.Add(new Addon() { Name = "Extra Chicken Fillet", Price = 3.0f });
                addInBox.Items.Add(new Addon() { Name = "Bacon", Price = 2.0f });
                addInBox.Items.Add(new Addon() { Name = "Pickles", Price = 1.0f });
                addInBox.Items.Add(new Addon() { Name = "BBQ Sauce", Price = 0.5f });
                addInBox.Items.Add(new Addon() { Name = "Honey Mustard", Price = 0.5f });

                addInBox.ItemCheck += AddOn_ItemCheck;
                flowLayoutPanel1.Controls.Add(addInBox);

            }
            if (item.Categories == "Light Meals" && item.Name == "Veggie Wrap")
            {
                Label ingredients = new Label();
                ingredients.Text = "Ingredients";
                ingredients.Font = new Font("Arial", 16, FontStyle.Bold);
                ingredients.Size = new Size(200, 25);
                flowLayoutPanel1.Controls.Add(ingredients);

                ingredientsBox = new CheckedListBox();
                ingredientsBox.Items.AddRange(new string[] { "Lettuce", "Tomato", "Cucumber", "Pepper", "Carrots" });
                ingredientsBox.Font = new Font("Arial", 12, FontStyle.Regular);
                ingredientsBox.Size = new Size(455, 110);
                ingredientsBox.CheckOnClick = true;
                ingredientsBox.MouseEnter += button_MouseEnter;
                ingredientsBox.MouseLeave += button_MouseLeave;
                flowLayoutPanel1.Controls.Add(ingredientsBox);
                CheckAllItems(ingredientsBox);

                Label add = new Label();
                add.Text = "Add";
                add.Font = new Font("Arial", 16, FontStyle.Bold);
                add.AutoSize = true;
                flowLayoutPanel1.Controls.Add(add);

                addInBox = new CheckedListBox();
                addInBox.Font = new Font("Arial", 12, FontStyle.Regular);
                addInBox.Size = new Size(455, 80);
                addInBox.CheckOnClick = true;
                addInBox.MouseEnter += button_MouseEnter;
                addInBox.MouseLeave += button_MouseLeave;
                addInBox.Items.Add(new Addon() { Name = "Avocado", Price = 1.5f });
                addInBox.Items.Add(new Addon() { Name = "Mushrooms", Price = 1.0f });
                addInBox.Items.Add(new Addon() { Name = "Pickles", Price = 1.0f });
                addInBox.Items.Add(new Addon() { Name = "Olives", Price = 0.5f });
                addInBox.Items.Add(new Addon() { Name = "Hummus", Price = 0.5f });

                addInBox.ItemCheck += AddOn_ItemCheck;
                flowLayoutPanel1.Controls.Add(addInBox);
            }
            if (item.Categories == "Light Meals" && item.Name == "Caesar Salad")
            {
                Label ingredients = new Label();
                ingredients.Text = "Ingredients";
                ingredients.Font = new Font("Arial", 16, FontStyle.Bold);
                ingredients.Size = new Size(200, 25);
                flowLayoutPanel1.Controls.Add(ingredients);

                ingredientsBox = new CheckedListBox();
                ingredientsBox.Items.AddRange(new string[] { "Grilled Chicken","Lettuce", "Croutons", "Parmesan Cheese", "Caesar Dressing" });
                ingredientsBox.Font = new Font("Arial", 12, FontStyle.Regular);
                ingredientsBox.Size = new Size(455, 110);
                ingredientsBox.CheckOnClick = true;
                ingredientsBox.MouseEnter += button_MouseEnter;
                ingredientsBox.MouseLeave += button_MouseLeave;
                flowLayoutPanel1.Controls.Add(ingredientsBox);
                CheckAllItems(ingredientsBox);

                Label add = new Label();
                add.Text = "Add";
                add.Font = new Font("Arial", 16, FontStyle.Bold);
                add.AutoSize = true;
                flowLayoutPanel1.Controls.Add(add);

                addInBox = new CheckedListBox();
                addInBox.Font = new Font("Arial", 12, FontStyle.Regular);
                addInBox.Size = new Size(455, 80);
                addInBox.CheckOnClick = true;
                addInBox.MouseEnter += button_MouseEnter;
                addInBox.MouseLeave += button_MouseLeave;
                addInBox.Items.Add(new Addon() { Name = "Extra Grilled Chicken", Price = 3.0f });
                addInBox.Items.Add(new Addon() { Name = "Bacon", Price = 2.0f });
                addInBox.Items.Add(new Addon() { Name = "Avocado", Price = 1.5f });
                addInBox.Items.Add(new Addon() { Name = "Boiled Egg", Price = 1.0f });
                addInBox.ItemCheck += AddOn_ItemCheck;
                flowLayoutPanel1.Controls.Add(addInBox);
            }
            if(item.Categories == "Light Meals" && item.Name == "Fruit Cup")
            {
                Label ingredients = new Label();
                ingredients.Text = "Ingredients";
                ingredients.Font = new Font("Arial", 16, FontStyle.Bold);
                ingredients.Size = new Size(200, 25);
                flowLayoutPanel1.Controls.Add(ingredients);

                ingredientsBox = new CheckedListBox();
                ingredientsBox.Items.AddRange(new string[] { "Apple", "Strawberry", "Grapes", "Banana", "Pineapple" });
                ingredientsBox.Font = new Font("Arial", 12, FontStyle.Regular);
                ingredientsBox.Size = new Size(455, 110);
                ingredientsBox.MouseEnter += button_MouseEnter;
                ingredientsBox.MouseLeave += button_MouseLeave;
                ingredientsBox.CheckOnClick = true;
                flowLayoutPanel1.Controls.Add(ingredientsBox);
                CheckAllItems(ingredientsBox);

                Label add = new Label();
                add.Text = "Add";
                add.Font = new Font("Arial", 16, FontStyle.Bold);
                add.AutoSize = true;
                flowLayoutPanel1.Controls.Add(add);

                addInBox = new CheckedListBox();
                addInBox.Font = new Font("Arial", 12, FontStyle.Regular);
                addInBox.Size = new Size(455, 80);
                addInBox.MouseEnter += button_MouseEnter;
                addInBox.MouseLeave += button_MouseLeave;
                addInBox.CheckOnClick = true;
                addInBox.Items.Add(new Addon() { Name = "Mango", Price = 2.0f });
                addInBox.Items.Add(new Addon() { Name = "Watermelon", Price = 1.5f });
                addInBox.Items.Add(new Addon() { Name = "Kiwi", Price = 2.0f });
                addInBox.Items.Add(new Addon() { Name = "Blueberries", Price = 2.0f });
                addInBox.Items.Add(new Addon() { Name = "Peach", Price = 1.5f });
                addInBox.Items.Add(new Addon() { Name = "Orange", Price = 1.5f });

                addInBox.ItemCheck += AddOn_ItemCheck;
                flowLayoutPanel1.Controls.Add(addInBox);
            }
            if(item.Categories == "Light Meals" && item.Name == "Muffin")
            {
                Label add = new Label();
                add.Text = "Add";
                add.Font = new Font("Arial", 16, FontStyle.Bold);
                add.AutoSize = true;
                flowLayoutPanel1.Controls.Add(add);
                addInBox = new CheckedListBox();
                addInBox.Font = new Font("Arial", 12, FontStyle.Regular);
                addInBox.Size = new Size(455, 80);
                addInBox.CheckOnClick = true;
                addInBox.Items.Add(new Addon() { Name = "Chocolate Chips", Price = 1.0f });
                addInBox.Items.Add(new Addon() { Name = "Blueberries", Price = 1.5f });
                addInBox.Items.Add(new Addon() { Name = "Nuts", Price = 1.0f });
                addInBox.Items.Add(new Addon() { Name = "Frosting", Price = 0.5f });

                addInBox.MouseEnter += button_MouseEnter;
                addInBox.MouseLeave += button_MouseLeave;
                addInBox.ItemCheck += AddOn_ItemCheck;
                flowLayoutPanel1.Controls.Add(addInBox);
            }
            if(item.Categories == "Light Meals" && item.Name == "Brownie")
            {
                Label add = new Label();
                add.Text = "Add";
                add.Font = new Font("Arial", 16, FontStyle.Bold);
                add.AutoSize = true;
                flowLayoutPanel1.Controls.Add(add);
                addInBox = new CheckedListBox();
                addInBox.Font = new Font("Arial", 12, FontStyle.Regular);
                addInBox.Size = new Size(455, 80);
                addInBox.CheckOnClick = true;
                addInBox.Items.Add(new Addon() { Name = "Nuts", Price = 1.0f });
                addInBox.Items.Add(new Addon() { Name = "Caramel Drizzle", Price = 0.5f });
                addInBox.Items.Add(new Addon() { Name = "Whipped Cream", Price = 0.5f });
                addInBox.Items.Add(new Addon() { Name = "Ice Cream Scoop", Price = 2.0f });

                addInBox.MouseEnter += button_MouseEnter;
                addInBox.MouseLeave += button_MouseLeave;
                addInBox.ItemCheck += AddOn_ItemCheck;
                flowLayoutPanel1.Controls.Add(addInBox);
            }
        }
        private void AddOn_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox clb = sender as CheckedListBox;
            Addon addon = clb.Items[e.Index] as Addon;

            if(addon == null)
                return;

            float pr = (e.NewValue == CheckState.Checked) ? addon.Price : -addon.Price;
            addonExtra += pr;

            UpdateFoodPrice();
        }

        private void SizeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox sizeBox = sender as ComboBox;

            sizeExtra = 0f;

            if (sizeBox.SelectedItem.ToString() == "Medium")
                sizeExtra = 1f;
            else if (sizeBox.SelectedItem.ToString() == "Large")
                sizeExtra = 2f;

            UpdateDrinkPrice();
        }


        private void AddBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox addBox = sender as ComboBox;

            addonExtra = 0f;

            if (addBox.SelectedItem.ToString() == "Extra Espresso Shot")
                addonExtra = 2f;
            else if(addBox.SelectedItem.ToString() == "Marshmallows")
                addonExtra = 1.5f;

            UpdateDrinkPrice();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            n++;
            label2.Text = n.ToString();
            if (n >= 10)
            {
                label2.Location = new Point(185, 608);
            }
            if(n > 0)
            {
                button3.Enabled = true;
                button1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            n--;
            label2.Text = n.ToString();
            if (n < 10)
            {
                label2.Location = new Point(193, 608);
            }
            if( n == 0)
            {
                button3.Enabled = false;
                button1.Enabled = false;
            }

        }
        private void UpdateDrinkPrice()
        {
            p.Text = $"${(basePrice + sizeExtra + addonExtra):F2}";
        }

        private void UpdateFoodPrice()
        {
            p.Text = $"${(basePrice + addonExtra):F2}";
        }
        private void CheckAllItems(CheckedListBox clb)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                clb.SetItemChecked(i, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Options opt = new Options();

            if (sizeBox != null)
                opt.size = sizeBox.SelectedItem?.ToString();

            if (sugarBox != null)
                opt.sugar = sugarBox.SelectedItem?.ToString();

            if (milkBox != null)
                opt.milk = milkBox.SelectedItem?.ToString();

            if (addBox != null)
                opt.add = addBox.SelectedItem?.ToString();

            if (removeBox != null)
                opt.remove = removeBox.SelectedItem?.ToString();

            if (honeyBox != null)
                opt.honey = honeyBox.SelectedItem?.ToString();

            if (ingredientsBox != null)
            {
                foreach (var ing in ingredientsBox.CheckedItems)
                    opt.ingredients.Add(ing.ToString());
            }

            if (addInBox != null)
            {
                foreach (Addon a in addInBox.CheckedItems)
                    opt.addIns.Add(a);
            }

            Cart entry = new Cart()
            {
                item = this.item,
                quantity = n,
                options = opt
            };


            opt.finalPrice = (basePrice + sizeExtra + addonExtra) * entry.quantity;

            if (coffeeHouseForm != null)
            {
                coffeeHouseForm.globalCart.Add(entry);
                coffeeHouseForm.UpdateCartButton();
                this.Hide();
                coffeeHouseForm.Show();
            }
            else if (coffeeshopform != null)
            {
                coffeeshopform.globalCart.Add(entry);
                coffeeshopform.UpdateCartButton();
                this.Hide();
                coffeeshopform.Show();
            }
            else if (coffeeplaceform != null)
            {
                coffeeplaceform.globalCart.Add(entry);
                coffeeplaceform.UpdateCartButton();
                this.Hide();
                coffeeplaceform.Show();
            }
        }

        private void ItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(coffeeHouseForm != null)
            {
                coffeeHouseForm.Show();
            }
            else if (coffeeshopform != null)
            {
                coffeeshopform.Show();
            }
            else if (coffeeplaceform != null)
            {
                coffeeplaceform.Show();
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
}
