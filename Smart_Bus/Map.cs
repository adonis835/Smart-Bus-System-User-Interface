using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Bus
{
    public partial class Map : Form
    {
        private StartupScreen form;
        int number = 0;
        int n = 1;


        public Map(StartupScreen form)
        {
            InitializeComponent();
            this.form = form;
            Main();
        }
        private void Main()
        {
            List<landmark> landmarks = new List<landmark>()
            {
                new landmark { Name = "Darling Harbour", Description = "Darling Harbour is one of Sydney’s most vibrant waterfront areas, located just a short walk from the city centre. It is home to popular attractions such as SEA LIFE Sydney Aquarium, WILD LIFE Sydney Zoo, and the Australian National Maritime Museum. The area offers a wide range of restaurants, cafés, and bars, making it a favourite spot for both locals and visitors. With pedestrian promenades, open public spaces, and frequent events, Darling Harbour is an ideal place to relax, explore, and enjoy harbour views day or night.",img = Properties.Resources.darling_harbour},
                new landmark { Name = "Queen Victoria Building", Description = "The Queen Victoria Building (QVB) is one of Sydney’s most iconic historic landmarks, located in the heart of the city’s Central Business District. Built in the late 19th century, it is known for its grand architecture, featuring a striking central dome, stained glass windows, and ornate interior details. Today, the QVB is a beautifully restored heritage building that houses a wide range of shops, cafés, and restaurants. Blending history with modern city life, it is a popular destination for shopping, sightseeing, and appreciating Sydney’s architectural heritage.",img = Properties.Resources.queen_victoria_building },
                new landmark { Name = "Sydney Observatory", Description = "The Sydney Observatory is a historic landmark located on Observatory Hill, overlooking Sydney Harbour. Built in the mid-19th century, it played an important role in astronomy, timekeeping, and navigation for the colony of New South Wales. Today, it operates as a museum and education centre, offering interactive exhibits, historic telescopes, and guided night-time sky viewing sessions. With its mix of science, history, and scenic harbour views, the Sydney Observatory is a popular place to learn about space and Sydney’s past.",img = Properties.Resources.sydney_observatory },
                new landmark { Name = "Harbour Bridge", Description = "The Sydney Harbour Bridge is one of Australia’s most famous landmarks, connecting the Sydney Central Business District with the North Shore across Sydney Harbour. Opened in 1932, it is one of the largest steel arch bridges in the world. The bridge carries cars, trains, bicycles, and pedestrians, making it a vital part of the city’s transport network. Known as “the Coathanger” because of its shape, it also offers spectacular views of the harbour and is a symbol of Sydney’s engineering achievement and identity.",img = Properties.Resources.Sydney_Harbour_Bridge },
                new landmark { Name = "Circular Quay", Description = "Circular Quay is one of Sydney’s most important and lively waterfront areas, located between the Sydney Opera House and the Sydney Harbour Bridge. It is a major transport hub where ferries, trains, buses, and light rail connect, making it a key gateway to Sydney Harbour. The area is lined with restaurants, cafés, and public spaces, and offers some of the city’s best views of the harbour. With its mix of transport, dining, and iconic scenery, Circular Quay is a popular starting point for exploring Sydney.",img = Properties.Resources.sydney_circular_quay },
                new landmark { Name = "Opera House", Description = "The Sydney Opera House is one of the most famous landmarks in Australia and a symbol of the city. Located on Bennelong Point in Sydney Harbour, it is known for its distinctive sail-like roof design. Opened in 1973 and designed by Danish architect Jørn Utzon, the building hosts concerts, theatre, opera, and other performances throughout the year. As a UNESCO World Heritage site, the Sydney Opera House is not only a major cultural venue but also one of the most photographed buildings in the world.",img = Properties.Resources.sydney_opera_house },
                new landmark { Name = "Royal Botanic Garden", Description = "The Royal Botanic Garden Sydney is a peaceful green space located beside Sydney Harbour, near the Sydney Opera House. Established in 1816, it is one of the oldest botanic gardens in the world and is home to a diverse collection of native and international plants. The gardens feature walking paths, lawns, and scenic viewpoints with harbour and city skyline views. Popular with both locals and visitors, the Royal Botanic Garden is an ideal place to relax, explore nature, and enjoy the contrast between gardens and the surrounding city.",img = Properties.Resources.botanic_gardens },
                new landmark { Name = "Tower eye", Description = "The Sydney Tower Eye is the tallest structure in Sydney and one of the city’s most popular observation points. Located in the Central Business District, it offers 360-degree views across the city skyline, Sydney Harbour, and on clear days, as far as the Blue Mountains. Visitors can explore the indoor observation deck or take part in the Skywalk, an outdoor glass-floor experience high above the city. The Sydney Tower Eye is a great place to see the scale and layout of Sydney from above.",img = Properties.Resources.tower_eye },
                new landmark { Name = "Hyde Park", Description = "Hyde Park is Sydney’s oldest public park, located in the heart of the Central Business District. Stretching from St James Station to the ANZAC War Memorial, it features wide tree-lined avenues, open lawns, and fountains, including the iconic Archibald Fountain. The park is a popular spot for walking, jogging, picnics, and relaxation, providing a green oasis amid the city’s busy streets. Hyde Park also hosts events and ceremonies, making it a place where history, nature, and city life come together.",img = Properties.Resources.hyde_park },
                new landmark { Name = "Australian Museum", Description = "The Australian Museum in Sydney is the country’s oldest museum, founded in 1827, and is located near Hyde Park in the CBD. It is renowned for its extensive natural history and anthropology collections, including fossils, minerals, and Indigenous cultural artifacts. The museum also features engaging exhibits on wildlife, dinosaurs, and science, making it a popular destination for families, students, and visitors interested in Australia’s natural and cultural heritage.",img = Properties.Resources.australian_museum }
             };

            foreach (var d in landmarks)
            {
                Label title = new Label();
                title.Text = n+"." + d.Name;
                title.Font = new Font("Arial", 14, FontStyle.Regular);
                title.AutoSize = true;
                flowLayoutPanel1.Controls.Add(title);
                n++;


            }

            pictureBox1.Tag = landmarks[3];
            pictureBox2.Tag = landmarks[5];
            pictureBox3.Tag = landmarks[2];
            pictureBox4.Tag = landmarks[4];
            pictureBox5.Tag = landmarks[6];
            pictureBox6.Tag = landmarks[7];
            pictureBox7.Tag = landmarks[1];
            pictureBox8.Tag = landmarks[8];
            pictureBox9.Tag = landmarks[0];
            pictureBox10.Tag = landmarks[9];

            PictureBox[] boxes =
            {
            pictureBox1,pictureBox2,pictureBox3,pictureBox4,pictureBox5,
            pictureBox6,pictureBox7,pictureBox8,pictureBox9,pictureBox10
            };

            foreach (var pb in boxes)
            {
                pb.Paint += pictureBox_Paint;
                pb.Click += pictureBox_Click;
                pb.Cursor = Cursors.Hand;
            }

        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Font font = new Font("Arial", 10, FontStyle.Bold);
            Brush brush = Brushes.Black;
            if(sender == pictureBox1) { number = 4; brush = Brushes.Black; }
            else if (sender == pictureBox2) { number = 6; brush = Brushes.Black; }
            else if (sender == pictureBox3) { number = 3; brush = Brushes.Black; }
            else if (sender == pictureBox4) { number = 5; brush = Brushes.Black; }
            else if (sender == pictureBox5) { number = 7; brush = Brushes.Black; }
            else if (sender == pictureBox6) { number = 9; brush = Brushes.Black; }
            else if (sender == pictureBox7) { number = 2; brush = Brushes.Black; }
            else if (sender == pictureBox8) { number = 8; brush = Brushes.Black; }
            else if (sender == pictureBox9) { number = 1; brush = Brushes.Black; }
            else if (sender == pictureBox10) { number = 10; brush = Brushes.Black; }

            g.DrawString(number.ToString(), font, brush, new Point(3, 1));

            Brush fillBrush = Brushes.Black;
            Pen outlinePen = new Pen(Color.White, 3) { LineJoin = LineJoin.Round }; // περίγραμμα

            GraphicsPath path = new GraphicsPath();
            path.AddString(number.ToString(), font.FontFamily, (int)font.Style, g.DpiY * font.Size / 72, new Point(3, 1), StringFormat.GenericDefault);

            g.DrawPath(outlinePen, path);  // Περίγραμμα
            g.FillPath(fillBrush, path);   // Γέμισμα αριθμού
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            landmark lk = pb.Tag as landmark;

            Landmarks ld = new Landmarks(lk, this);
            this.Hide();
            ld.Show();
        }

        private void Map_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Show();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Hide();
            DriversView form = new DriversView(this);
            form.Show();
        }

        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            Cursor= Cursors.Default;
        }
    }
    public class landmark
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Image img { get; set; }
    }
}
