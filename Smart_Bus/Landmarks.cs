using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Smart_Bus
{

    public partial class Landmarks : Form
    {
        private landmark l;
        private Map mapform;
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        public Landmarks(landmark l,Map mapform)
        {
            InitializeComponent();
            this.mapform = mapform;
            this.l = l;
            Main();
        }
        private void Main() { 
            Label title = new Label();
            title.Text = l.Name;
            title.Location = new Point(0, 0);
            title.Size = new Size(880, 50);
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Font = new Font("Arial", 24, FontStyle.Bold);
            this.Controls.Add(title);

            Label info = new Label();
            info.Text = l.Description;
            info.Location = new Point(50, 50);
            info.Font = new Font("Arial", 14, FontStyle.Regular);
            info.Size = new Size(750, 200);
            this.Controls.Add(info);

            PictureBox img = new PictureBox();
            img.Image = l.img;
            img.Location = new Point(0, 263);
            img.Size = new Size(874, 338);
            img.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(img);

            Button speakButton = new Button();
            speakButton.Text = "Start Audio";
            speakButton.Location = new Point(50, 210);
            speakButton.Size = new Size(150, 40);
            speakButton.Click += SpeakButton_Click;
            speakButton.MouseEnter += button_MouseEnter;
            speakButton.MouseLeave += button_MouseLeave;
            this.Controls.Add(speakButton);
            speakButton.BringToFront();

            Button stop = new Button();
            stop.Text = "Pause";
            stop.Location = new Point(250, 210);
            stop.Size = new Size(150, 40);
            stop.Click += Stop_Click;
            stop.MouseEnter += button_MouseEnter;
            stop.MouseLeave += button_MouseLeave;
            this.Controls.Add(stop);
            stop.BringToFront();

            Button resume = new Button();
            resume.Text = "Resume";
            resume.Location = new Point(450, 210);
            resume.Size = new Size(150, 40);
            resume.Click += Resume_Click;
            resume.MouseEnter += button_MouseEnter;
            resume.MouseLeave += button_MouseLeave;
            this.Controls.Add(resume);
            resume.BringToFront();

            Button back = new Button();
            back.Text = "Back to Map";
            back.Location = new Point(650, 210);
            back.Size = new Size(150, 40);
            back.Click += Back_Click;
            back.MouseEnter += button_MouseEnter;
            back.MouseLeave += button_MouseLeave;
            this.Controls.Add(back);
            back.BringToFront();

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
        private void Landmarks_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            mapform.Show();
            synthesizer.Dispose();
        }

        private void SpeakButton_Click(object sender, EventArgs e)
        {
            synthesizer.SpeakAsync(l.Description);
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            synthesizer.Pause();
        }
        private void Resume_Click(object sender, EventArgs e)
        {
            synthesizer.Resume();
        }
        private void synthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            synthesizer.Dispose();
        }
        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
            mapform.Show();
            synthesizer.Dispose();
        }
    }
}
