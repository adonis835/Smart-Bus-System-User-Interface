namespace Smart_Bus
{
    partial class DriversView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DriversView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Smart_Bus.Properties.Resources.drivers_view;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1106, 586);
            this.DoubleBuffered = true;
            this.Name = "DriversView";
            this.Text = "DriversView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DriversView_FormClosing);
            this.Load += new System.EventHandler(this.DriversView_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DriversView_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DriversView_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}