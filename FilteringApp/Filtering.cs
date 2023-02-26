using System.Diagnostics.Contracts;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FilteringApp
{
    public partial class Filtering : Form
    {
        Bitmap modifiedImg = null;
        Bitmap initialImg = null;
        public Filtering()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void loadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog imgDialog = new OpenFileDialog();
            imgDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (imgDialog.ShowDialog() == DialogResult.OK)
            {
                initialImage.Image = new Bitmap(imgDialog.FileName);
                initialImg = new Bitmap(imgDialog.FileName);
                modifiedImage.Image = new Bitmap(imgDialog.FileName);
                modifiedImg = new Bitmap(imgDialog.FileName);
            }
        }

        private void reloadImageMenuItem_Click(object sender, EventArgs e)
        {
            modifiedImage.Image = initialImg;
            modifiedImg = initialImg;
        }

        private void saveImageMenuItem_Click(object sender, EventArgs e)
        {
            modifiedImage.Image.Save(@"D:\test.png", ImageFormat.Png);
        }

        private void inversionButton_Click(object sender, EventArgs e)
        {
            Bitmap afterModificationMap = new Bitmap(modifiedImg.Width, modifiedImg.Height);

            for (int x = 0; x < modifiedImg.Width; x++)
            {
                for (int y = 0; y < modifiedImg.Height; y++)
                {
                    Color currPixel = modifiedImg.GetPixel(x, y);

                    currPixel = Color.FromArgb(255 - currPixel.R, 255 - currPixel.G, 255 - currPixel.B);

                    afterModificationMap.SetPixel(x, y, currPixel);
                }
            }
            modifiedImage.Image = afterModificationMap;
            modifiedImg = afterModificationMap;
        }

        private void brightnessButton_Click(object sender, EventArgs e)
        {
            Bitmap afterModificationMap = new Bitmap(modifiedImg.Width, modifiedImg.Height);

            for (int x = 0; x < modifiedImg.Width; x++)
            {
                for (int y = 0; y < modifiedImg.Height; y++)
                {
                    Color currPixel = modifiedImg.GetPixel(x, y);

                    int red = currPixel.R + 10;
                    int green = currPixel.G + 10;
                    int blue = currPixel.B + 10;

                    if (red > 255)
                        red = 255;
                    if (green > 255)
                        green = 255;
                    if (blue > 255)
                        blue = 255;

                    currPixel = Color.FromArgb(red, green, blue);

                    afterModificationMap.SetPixel(x, y, currPixel);
                }
            }
            modifiedImage.Image = afterModificationMap;
            modifiedImg = afterModificationMap;
        }

        private void contrastButton_Click(object sender, EventArgs e)
        {
            double contrastLevel = Math.Pow((100.0 + 10) / 100.0, 2);

            Bitmap afterModificationMap = new Bitmap(modifiedImg.Width, modifiedImg.Height);

            for (int x = 0; x < modifiedImg.Width; x++)
            {
                for (int y = 0; y < modifiedImg.Height; y++)
                {
                    Color currPixel = modifiedImg.GetPixel(x, y);

                    int red = (int)(((((currPixel.R / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0);
                    int green = (int)(((((currPixel.G / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0);
                    int blue = (int)(((((currPixel.B / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0);

                    if (red > 255)
                        red = 255;
                    if (green > 255)
                        green = 255;
                    if (blue > 255)
                        blue = 255;
                    if (red < 0)
                        red = 0;
                    if (green < 0)
                        green = 0;
                    if (blue < 0)
                        blue = 0;

                    currPixel = Color.FromArgb(red, green, blue);

                    afterModificationMap.SetPixel(x, y, currPixel);
                }
            }
            modifiedImage.Image = afterModificationMap;
            modifiedImg = afterModificationMap;
        }

        private void gammaButton_Click(object sender, EventArgs e)
        {
            Bitmap afterModificationMap = new Bitmap(modifiedImg.Width, modifiedImg.Height);
            double gamma = 1.5;

            for (int x = 0; x < modifiedImg.Width; x++)
            {
                for (int y = 0; y < modifiedImg.Height; y++)
                {
                    Color currPixel = modifiedImg.GetPixel(x, y);

                    int red = (int)(255.0 * Math.Pow((currPixel.R / 255.0), gamma));
                    int green = (int)(255.0 * Math.Pow((currPixel.G / 255.0), gamma));
                    int blue = (int)(255.0 * Math.Pow((currPixel.B / 255.0), gamma));

                    if (red > 255)
                        red = 255;
                    if (green > 255)
                        green = 255;
                    if (blue > 255)
                        blue = 255;
                    if (red < 0)
                        red = 0;
                    if (green < 0)
                        green = 0;
                    if (blue < 0)
                        blue = 0;

                    currPixel = Color.FromArgb(red, green, blue);

                    afterModificationMap.SetPixel(x, y, currPixel);
                }
            }
            modifiedImage.Image = afterModificationMap;
            modifiedImg = afterModificationMap;
        }

        
    }
}