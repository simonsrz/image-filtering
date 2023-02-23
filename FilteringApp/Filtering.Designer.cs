namespace FilteringApp
{
    partial class Filtering
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.initialImage = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.modifiedImage = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.contrastButton = new System.Windows.Forms.Button();
            this.brightnessButton = new System.Windows.Forms.Button();
            this.inversionButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.initialImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modifiedImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // initialImage
            // 
            this.initialImage.Location = new System.Drawing.Point(12, 59);
            this.initialImage.Name = "initialImage";
            this.initialImage.Size = new System.Drawing.Size(600, 600);
            this.initialImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.initialImage.TabIndex = 0;
            this.initialImage.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(526, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(0, 0);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 627);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // modifiedImage
            // 
            this.modifiedImage.Location = new System.Drawing.Point(640, 59);
            this.modifiedImage.Name = "modifiedImage";
            this.modifiedImage.Size = new System.Drawing.Size(600, 600);
            this.modifiedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.modifiedImage.TabIndex = 3;
            this.modifiedImage.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.contrastButton);
            this.groupBox1.Controls.Add(this.brightnessButton);
            this.groupBox1.Controls.Add(this.inversionButton);
            this.groupBox1.Location = new System.Drawing.Point(1246, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 302);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Function filters";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 250);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(304, 46);
            this.button4.TabIndex = 3;
            this.button4.Text = "Gamma correction";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // contrastButton
            // 
            this.contrastButton.Location = new System.Drawing.Point(6, 182);
            this.contrastButton.Name = "contrastButton";
            this.contrastButton.Size = new System.Drawing.Size(304, 46);
            this.contrastButton.TabIndex = 2;
            this.contrastButton.Text = "Contrast enhancement";
            this.contrastButton.UseVisualStyleBackColor = true;
            this.contrastButton.Click += new System.EventHandler(this.contrastButton_Click);
            // 
            // brightnessButton
            // 
            this.brightnessButton.Location = new System.Drawing.Point(6, 114);
            this.brightnessButton.Name = "brightnessButton";
            this.brightnessButton.Size = new System.Drawing.Size(304, 46);
            this.brightnessButton.TabIndex = 1;
            this.brightnessButton.Text = "Brightness correction";
            this.brightnessButton.UseVisualStyleBackColor = true;
            this.brightnessButton.Click += new System.EventHandler(this.brightnessButton_Click);
            // 
            // inversionButton
            // 
            this.inversionButton.Location = new System.Drawing.Point(6, 47);
            this.inversionButton.Name = "inversionButton";
            this.inversionButton.Size = new System.Drawing.Size(304, 46);
            this.inversionButton.TabIndex = 0;
            this.inversionButton.Text = "Inversion";
            this.inversionButton.UseVisualStyleBackColor = true;
            this.inversionButton.Click += new System.EventHandler(this.inversionButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(1246, 367);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 292);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Convolution filters";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageMenuItem,
            this.reloadImageMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1574, 40);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadImageMenuItem
            // 
            this.loadImageMenuItem.Name = "loadImageMenuItem";
            this.loadImageMenuItem.Size = new System.Drawing.Size(158, 36);
            this.loadImageMenuItem.Text = "Load image";
            this.loadImageMenuItem.Click += new System.EventHandler(this.loadImage_Click);
            // 
            // reloadImageMenuItem
            // 
            this.reloadImageMenuItem.Name = "reloadImageMenuItem";
            this.reloadImageMenuItem.Size = new System.Drawing.Size(179, 36);
            this.reloadImageMenuItem.Text = "Reload image";
            this.reloadImageMenuItem.Click += new System.EventHandler(this.reloadImageMenuItem_Click);
            // 
            // Filtering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 916);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.modifiedImage);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.initialImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Filtering";
            this.Text = "Filtering app";
            ((System.ComponentModel.ISupportInitialize)(this.initialImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modifiedImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox initialImage;
        private PictureBox pictureBox2;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox modifiedImage;
        private GroupBox groupBox1;
        private Button inversionButton;
        private GroupBox groupBox2;
        private Button button4;
        private Button contrastButton;
        private Button brightnessButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem loadImageMenuItem;
        private ToolStripMenuItem reloadImageMenuItem;
    }
}