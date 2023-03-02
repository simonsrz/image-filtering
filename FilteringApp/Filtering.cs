using System.Diagnostics.Contracts;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FilteringApp
{
    public partial class Filtering : Form
    {
        Bitmap modifiedImg = null;
        Bitmap initialImg = null;
        FunctionFilters functionFilter = new FunctionFilters();
        ConvolutionFilters convolutionFilter = new ConvolutionFilters();

        public Filtering()
        {
            InitializeComponent();
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
            SaveFileDialog saveDialog = new SaveFileDialog();
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                modifiedImage.Image.Save(saveDialog.FileName + ".png", ImageFormat.Png);
            }
        }

        private void inversionButton_Click(object sender, EventArgs e)
        {
            modifiedImage.Image = functionFilter.colorInversion(modifiedImg);
            modifiedImg = functionFilter.colorInversion(modifiedImg);
        }

        private void brightnessButton_Click(object sender, EventArgs e)
        {
            modifiedImage.Image = functionFilter.brightnessEnhancement(modifiedImg, 10);
            modifiedImg = functionFilter.brightnessEnhancement(modifiedImg, 10);
        }

        private void contrastButton_Click(object sender, EventArgs e)
        {
            modifiedImage.Image = functionFilter.contrastEnhancement(modifiedImg, 10);
            modifiedImg = functionFilter.contrastEnhancement(modifiedImg, 10);
        }

        private void gammaButton_Click(object sender, EventArgs e)
        {
            modifiedImage.Image = functionFilter.gammaCorrection(modifiedImg, 1.5);
            modifiedImg = functionFilter.gammaCorrection(modifiedImg, 1.5);
        }
        private void blurButton_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[3,3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            int offset = 0;
            int divisor = 9;
            modifiedImage.Image = convolutionFilter.blurFilter(modifiedImg, kernel, 1, 1, offset, divisor);
            modifiedImg = convolutionFilter.blurFilter(modifiedImg, kernel, 1, 1, offset, divisor);
        }

        private void gaussianBlurButton_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[3, 3] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };
            int offset = 0;
            int divisor = 16;

            modifiedImage.Image = convolutionFilter.gaussianBlurFilter(modifiedImg, kernel, 1, 1, offset, divisor);
            modifiedImg = convolutionFilter.gaussianBlurFilter(modifiedImg, kernel, 1, 1, offset, divisor);
        }

        private void sharpenButton_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
            int offset = 0;
            int divisor = 1;

            modifiedImage.Image = convolutionFilter.sharpenFilter(modifiedImg, kernel, 1, 1, offset, divisor);
            modifiedImg = convolutionFilter.sharpenFilter(modifiedImg, kernel, 1, 1, offset, divisor);
        }

        private void edgeDetectionButton_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };
            int offset = 0;
            int divisor = 1;

            modifiedImage.Image = convolutionFilter.edgeDetectionFilter(modifiedImg, kernel, 1, 1, offset, divisor);
            modifiedImg = convolutionFilter.edgeDetectionFilter(modifiedImg, kernel, 1, 1, offset, divisor);
        }

        private void embossButton_Click(object sender, EventArgs e)
        {
            double[,] kernel = new double[3, 3] { { -1, -1, -1 }, { 0, 1, 0 }, { 1, 1, 1 } };
            int offset = 0;
            int divisor = 1;

            modifiedImage.Image = convolutionFilter.embossFilter(modifiedImg, kernel, 1, 1, offset, divisor);
            modifiedImg = convolutionFilter.embossFilter(modifiedImg, kernel, 1, 1, offset, divisor);
        }

        private void kernelGridButton_Click(object sender, EventArgs e)
        {

        }
    }
}