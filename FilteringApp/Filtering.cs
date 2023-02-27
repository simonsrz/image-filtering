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

        private Color[,] getColorsMatrix(int x, int y)
        {
            Color[,] colorsMatrix = new Color[3, 3];

            for (int posX = 0; posX < 3; posX++)
            {
                for(int posY = 0; posY < 3; posY++)
                {
                    if (x - 1 + posX < 0 || y - 1 + posY < 0 || x - 1 + posX >= modifiedImg.Width || y - 1 + posY >= modifiedImg.Height)
                    {
                        colorsMatrix[posX, posY] = Color.Empty;
                    }
                    else
                    {
                        colorsMatrix[posX, posY] = modifiedImg.GetPixel(x - 1 + posX, y - 1 + posY);
                    }
                }
            }
            return colorsMatrix;
        }

        private double getRedChannelFromKernel(Color[,] colorsMatrix, double[,] kernel)
        {
            double red = 0;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    red += colorsMatrix[i, j].R * kernel[i, j];
                }
            }
            return red;
        }
        private double getGreenChannelFromKernel(Color[,] colorsMatrix, double[,] kernel)
        {
            double green = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    green += colorsMatrix[i, j].G * kernel[i, j];
                }
            }
            return green;
        }
        private double getBlueChannelFromKernel(Color[,] colorsMatrix, double[,] kernel)
        {
            double blue = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    blue += colorsMatrix[i, j].B * kernel[i, j];
                }
            }
            return blue;
        }

        private int[] rgbValidation(int red, int green, int blue)
        {
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
            return new int[3] { red, green, blue };
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

                    int[] rgb = rgbValidation(red,green, blue);

                    currPixel = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

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

                    int[] rgb = rgbValidation(red, green, blue);

                    currPixel = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

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

                    int[] rgb = rgbValidation(red,green, blue);

                    currPixel = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    afterModificationMap.SetPixel(x, y, currPixel);
                }
            }
            modifiedImage.Image = afterModificationMap;
            modifiedImg = afterModificationMap;
        }
        private void blurButton_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[3,3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            int offset = 0;
            int divisor = 9;

            Bitmap afterModificationMap = new Bitmap(modifiedImg.Width, modifiedImg.Height);

            for (int x = 0; x < modifiedImg.Width; x++)
            {
                for (int y = 0; y < modifiedImg.Height; y++)
                {
                    Color[,] colorsMatrix = getColorsMatrix(x, y);

                    double red = ( getRedChannelFromKernel(colorsMatrix, kernel) / divisor ) + offset;
                    double green = (getGreenChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double blue = (getBlueChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;

                    int[] rgb = rgbValidation((int)red, (int)green, (int)blue);

                    colorsMatrix[1,1] = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    afterModificationMap.SetPixel(x, y, colorsMatrix[1, 1]);
                }
            }
            modifiedImage.Image = afterModificationMap;
            modifiedImg = afterModificationMap;
        }

        private void gaussianBlurButton_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[3, 3] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };
            int offset = 0;
            int divisor = 16;

            Bitmap afterModificationMap = new Bitmap(modifiedImg.Width, modifiedImg.Height);

            for (int x = 0; x < modifiedImg.Width; x++)
            {
                for (int y = 0; y < modifiedImg.Height; y++)
                {
                    Color[,] colorsMatrix = getColorsMatrix(x, y);

                    double red = (getRedChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double green = (getGreenChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double blue = (getBlueChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;

                    int[] rgb = rgbValidation((int)red, (int)green, (int)blue);

                    colorsMatrix[1, 1] = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    afterModificationMap.SetPixel(x, y, colorsMatrix[1, 1]);
                }
            }
            modifiedImage.Image = afterModificationMap;
            modifiedImg = afterModificationMap;
        }

        private void sharpenButton_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
            int offset = 0;
            int divisor = 1;

            Bitmap afterModificationMap = new Bitmap(modifiedImg.Width, modifiedImg.Height);

            for (int x = 0; x < modifiedImg.Width; x++)
            {
                for (int y = 0; y < modifiedImg.Height; y++)
                {
                    Color[,] colorsMatrix = getColorsMatrix(x, y);

                    double red = (getRedChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double green = (getGreenChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double blue = (getBlueChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;

                    int[] rgb = rgbValidation((int)red, (int)green, (int)blue);

                    colorsMatrix[1, 1] = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    afterModificationMap.SetPixel(x, y, colorsMatrix[1, 1]);
                }
            }
            modifiedImage.Image = afterModificationMap;
            modifiedImg = afterModificationMap;
        }

        private void edgeDetectionButton_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };
            int offset = 0;
            int divisor = 1;

            Bitmap afterModificationMap = new Bitmap(modifiedImg.Width, modifiedImg.Height);

            for (int x = 0; x < modifiedImg.Width; x++)
            {
                for (int y = 0; y < modifiedImg.Height; y++)
                {
                    Color[,] colorsMatrix = getColorsMatrix(x, y);

                    double red = (getRedChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double green = (getGreenChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double blue = (getBlueChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;

                    int[] rgb = rgbValidation((int)red, (int)green, (int)blue);

                    colorsMatrix[1, 1] = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    afterModificationMap.SetPixel(x, y, colorsMatrix[1, 1]);
                }
            }
            modifiedImage.Image = afterModificationMap;
            modifiedImg = afterModificationMap;
        }

        private void embossButton_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[3, 3] { { -1, -1, -1 }, { 0, 1, 0 }, { 1, 1, 1 } };
            int offset = 0;
            int divisor = 1;

            Bitmap afterModificationMap = new Bitmap(modifiedImg.Width, modifiedImg.Height);

            for (int x = 0; x < modifiedImg.Width; x++)
            {
                for (int y = 0; y < modifiedImg.Height; y++)
                {
                    Color[,] colorsMatrix = getColorsMatrix(x, y);

                    double red = (getRedChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double green = (getGreenChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double blue = (getBlueChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;

                    int[] rgb = rgbValidation((int)red, (int)green, (int)blue);

                    colorsMatrix[1, 1] = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    afterModificationMap.SetPixel(x, y, colorsMatrix[1, 1]);
                }
            }
            modifiedImage.Image = afterModificationMap;
            modifiedImg = afterModificationMap;
        }
    }
}