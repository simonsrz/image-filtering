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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.modifiedImage = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gammaButton = new System.Windows.Forms.Button();
            this.contrastButton = new System.Windows.Forms.Button();
            this.brightnessButton = new System.Windows.Forms.Button();
            this.inversionButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.embossButton = new System.Windows.Forms.Button();
            this.edgeDetectionButton = new System.Windows.Forms.Button();
            this.gaussianBlurButton = new System.Windows.Forms.Button();
            this.sharpenButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.blurButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.initialImage = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.kernelGridButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.kernelColumns = new System.Windows.Forms.NumericUpDown();
            this.kernelRows = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modifiedImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initialImage)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kernelColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kernelRows)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(526, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(0, 0);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
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
            this.modifiedImage.Location = new System.Drawing.Point(619, 47);
            this.modifiedImage.Name = "modifiedImage";
            this.modifiedImage.Size = new System.Drawing.Size(603, 547);
            this.modifiedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.modifiedImage.TabIndex = 3;
            this.modifiedImage.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gammaButton);
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
            // gammaButton
            // 
            this.gammaButton.Location = new System.Drawing.Point(6, 250);
            this.gammaButton.Name = "gammaButton";
            this.gammaButton.Size = new System.Drawing.Size(304, 46);
            this.gammaButton.TabIndex = 3;
            this.gammaButton.Text = "Gamma correction";
            this.gammaButton.UseVisualStyleBackColor = true;
            this.gammaButton.Click += new System.EventHandler(this.gammaButton_Click);
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
            this.groupBox2.Controls.Add(this.embossButton);
            this.groupBox2.Controls.Add(this.edgeDetectionButton);
            this.groupBox2.Controls.Add(this.gaussianBlurButton);
            this.groupBox2.Controls.Add(this.sharpenButton);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.blurButton);
            this.groupBox2.Location = new System.Drawing.Point(1246, 367);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 292);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Convolution filters";
            // 
            // embossButton
            // 
            this.embossButton.Location = new System.Drawing.Point(6, 246);
            this.embossButton.Name = "embossButton";
            this.embossButton.Size = new System.Drawing.Size(304, 40);
            this.embossButton.TabIndex = 11;
            this.embossButton.Text = "Emboss";
            this.embossButton.UseVisualStyleBackColor = true;
            this.embossButton.Click += new System.EventHandler(this.embossButton_Click);
            // 
            // edgeDetectionButton
            // 
            this.edgeDetectionButton.Location = new System.Drawing.Point(6, 194);
            this.edgeDetectionButton.Name = "edgeDetectionButton";
            this.edgeDetectionButton.Size = new System.Drawing.Size(304, 40);
            this.edgeDetectionButton.TabIndex = 10;
            this.edgeDetectionButton.Text = "Edge detection";
            this.edgeDetectionButton.UseVisualStyleBackColor = true;
            this.edgeDetectionButton.Click += new System.EventHandler(this.edgeDetectionButton_Click);
            // 
            // gaussianBlurButton
            // 
            this.gaussianBlurButton.Location = new System.Drawing.Point(6, 90);
            this.gaussianBlurButton.Name = "gaussianBlurButton";
            this.gaussianBlurButton.Size = new System.Drawing.Size(304, 40);
            this.gaussianBlurButton.TabIndex = 9;
            this.gaussianBlurButton.Text = "Gaussian blur";
            this.gaussianBlurButton.UseVisualStyleBackColor = true;
            this.gaussianBlurButton.Click += new System.EventHandler(this.gaussianBlurButton_Click);
            // 
            // sharpenButton
            // 
            this.sharpenButton.Location = new System.Drawing.Point(6, 142);
            this.sharpenButton.Name = "sharpenButton";
            this.sharpenButton.Size = new System.Drawing.Size(304, 40);
            this.sharpenButton.TabIndex = 9;
            this.sharpenButton.Text = "Sharpen";
            this.sharpenButton.UseVisualStyleBackColor = true;
            this.sharpenButton.Click += new System.EventHandler(this.sharpenButton_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 246);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(0, 0);
            this.button5.TabIndex = 8;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 194);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(0, 0);
            this.button4.TabIndex = 7;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 142);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(0, 0);
            this.button3.TabIndex = 6;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(0, 0);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // blurButton
            // 
            this.blurButton.Location = new System.Drawing.Point(6, 38);
            this.blurButton.Name = "blurButton";
            this.blurButton.Size = new System.Drawing.Size(304, 40);
            this.blurButton.TabIndex = 4;
            this.blurButton.Text = "Blur";
            this.blurButton.UseVisualStyleBackColor = true;
            this.blurButton.Click += new System.EventHandler(this.blurButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageMenuItem,
            this.reloadImageMenuItem,
            this.saveImageMenuItem});
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
            // saveImageMenuItem
            // 
            this.saveImageMenuItem.Name = "saveImageMenuItem";
            this.saveImageMenuItem.Size = new System.Drawing.Size(157, 36);
            this.saveImageMenuItem.Text = "Save image";
            this.saveImageMenuItem.Click += new System.EventHandler(this.saveImageMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.initialImage);
            this.groupBox3.Controls.Add(this.modifiedImage);
            this.groupBox3.Location = new System.Drawing.Point(12, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1228, 600);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Images";
            // 
            // initialImage
            // 
            this.initialImage.Location = new System.Drawing.Point(6, 47);
            this.initialImage.Name = "initialImage";
            this.initialImage.Size = new System.Drawing.Size(603, 547);
            this.initialImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.initialImage.TabIndex = 0;
            this.initialImage.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.kernelGridButton);
            this.groupBox4.Controls.Add(this.tableLayoutPanel1);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.kernelColumns);
            this.groupBox4.Controls.Add(this.kernelRows);
            this.groupBox4.Location = new System.Drawing.Point(18, 665);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1544, 607);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Additional filter";
            // 
            // kernelGridButton
            // 
            this.kernelGridButton.Location = new System.Drawing.Point(464, 66);
            this.kernelGridButton.Name = "kernelGridButton";
            this.kernelGridButton.Size = new System.Drawing.Size(139, 39);
            this.kernelGridButton.TabIndex = 6;
            this.kernelGridButton.Text = "Create";
            this.kernelGridButton.UseVisualStyleBackColor = true;
            this.kernelGridButton.Click += new System.EventHandler(this.kernelGridButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 121);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(588, 424);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(162, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 32);
            this.label4.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(273, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "×";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 32);
            this.label2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(15, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kernel";
            // 
            // kernelColumns
            // 
            this.kernelColumns.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.kernelColumns.Location = new System.Drawing.Point(141, 66);
            this.kernelColumns.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.kernelColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.kernelColumns.Name = "kernelColumns";
            this.kernelColumns.Size = new System.Drawing.Size(126, 39);
            this.kernelColumns.TabIndex = 1;
            this.kernelColumns.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // kernelRows
            // 
            this.kernelRows.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.kernelRows.Location = new System.Drawing.Point(316, 66);
            this.kernelRows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.kernelRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.kernelRows.Name = "kernelRows";
            this.kernelRows.Size = new System.Drawing.Size(126, 39);
            this.kernelRows.TabIndex = 0;
            this.kernelRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Filtering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 1284);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Filtering";
            this.Text = "Filtering app";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modifiedImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.initialImage)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kernelColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kernelRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox pictureBox2;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox modifiedImage;
        private GroupBox groupBox1;
        private Button inversionButton;
        private GroupBox groupBox2;
        private Button gammaButton;
        private Button contrastButton;
        private Button brightnessButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem loadImageMenuItem;
        private ToolStripMenuItem reloadImageMenuItem;
        private GroupBox groupBox3;
        private ToolStripMenuItem saveImageMenuItem;
        private Button embossButton;
        private Button edgeDetectionButton;
        private Button gaussianBlurButton;
        private Button sharpenButton;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button blurButton;
        private GroupBox groupBox4;
        private Label label1;
        private NumericUpDown kernelColumns;
        private NumericUpDown kernelRows;
        private Label label2;
        private PictureBox initialImage;
        private Label label3;
        private Label label4;
        private Button kernelGridButton;
        private TableLayoutPanel tableLayoutPanel1;
    }
}