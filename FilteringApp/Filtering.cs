using System.Diagnostics.Contracts;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FilteringApp
{
    public partial class Filtering : Form
    {
        DirectBitmap modifiedImg = null;
        DirectBitmap initialImg = null;
        Bitmap uploadedBmp = null;
        FunctionFilters functionFilter = new FunctionFilters();
        List<ConvolutionFilter> convFilters = new List<ConvolutionFilter>();
        List<ErrorDiffusion> errorDiffusionFilters = new List<ErrorDiffusion>();
        int customKernelWidth = 0;
        int customKernelHeight = 0;
        int customFilterNr = 1;

        public Filtering()
        {
            InitializeComponent();
            convFilters.Add(new BlurFillter());
            convFilters.Add(new GaussianBlurFillter());
            convFilters.Add(new SharpenFilter());
            convFilters.Add(new EdgeDetectionFilter());
            convFilters.Add(new EmbossFilter());
            loadComboBox.Items.Add(convFilters[0].filterName);
            loadComboBox.Items.Add(convFilters[1].filterName);
            loadComboBox.Items.Add(convFilters[2].filterName);
            loadComboBox.Items.Add(convFilters[3].filterName);
            loadComboBox.Items.Add(convFilters[4].filterName);

            errorDiffusionFilters.Add(new FloydSteinberg());
            errorDiffusionFilters.Add(new Burkes());
            errorDiffusionFilters.Add(new Stucky());
            errorDiffusionFilters.Add(new Sierra());
            errorDiffusionFilters.Add(new Atkinson());
            ditherFilterCombo.Items.Add(errorDiffusionFilters[0].filterName);
            ditherFilterCombo.Items.Add(errorDiffusionFilters[1].filterName);
            ditherFilterCombo.Items.Add(errorDiffusionFilters[2].filterName);
            ditherFilterCombo.Items.Add(errorDiffusionFilters[3].filterName);
            ditherFilterCombo.Items.Add(errorDiffusionFilters[4].filterName);

            ditherFilterCombo.SelectedIndex = 0;
            loadComboBox.SelectedIndex = 0;
        }

        private void loadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog imgDialog = new OpenFileDialog();
            imgDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (imgDialog.ShowDialog() == DialogResult.OK)
            {
                uploadedBmp = new Bitmap(imgDialog.FileName);
                modifiedImg = new DirectBitmap(uploadedBmp.Width, uploadedBmp.Height);
                initialImg = new DirectBitmap(uploadedBmp.Width, uploadedBmp.Height);

                using (var g = Graphics.FromImage(initialImg.Bitmap))
                {
                    g.DrawImage(uploadedBmp, 0, 0);
                }
                using (var g = Graphics.FromImage(modifiedImg.Bitmap))
                {
                    g.DrawImage(uploadedBmp, 0, 0);
                }

                initialImage.Image = initialImg.Bitmap;
                modifiedImage.Image = modifiedImg.Bitmap;
            }
        }

        private void reloadImageMenuItem_Click(object sender, EventArgs e)
        {
            modifiedImg.Dispose();
            modifiedImg = new DirectBitmap(uploadedBmp.Width, uploadedBmp.Height);
            using (var g = Graphics.FromImage(modifiedImg.Bitmap))
            {
                g.DrawImage(uploadedBmp, 0, 0);
            }

            modifiedImage.Image = modifiedImg.Bitmap;
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
            functionFilter.colorInversion(modifiedImg);
            modifiedImage.Image = modifiedImg.Bitmap;
        }

        private void brightnessButton_Click(object sender, EventArgs e)
        {
            functionFilter.brightnessEnhancement(modifiedImg, 10);
            modifiedImage.Image = modifiedImg.Bitmap;
        }

        private void contrastButton_Click(object sender, EventArgs e)
        {
            functionFilter.contrastEnhancement(modifiedImg, 10);
            modifiedImage.Image = modifiedImg.Bitmap;
        }

        private void gammaButton_Click(object sender, EventArgs e)
        {
            functionFilter.gammaCorrection(modifiedImg, 1.5);
            modifiedImage.Image = modifiedImg.Bitmap;
        }
        private void blurButton_Click(object sender, EventArgs e)
        {
            convFilters[0].applyFilter(modifiedImg);
            modifiedImage.Image = modifiedImg.Bitmap;
        }

        private void gaussianBlurButton_Click(object sender, EventArgs e)
        {
            convFilters[1].applyFilter(modifiedImg);
            modifiedImage.Image = modifiedImg.Bitmap;
        }

        private void sharpenButton_Click(object sender, EventArgs e)
        {
            convFilters[2].applyFilter(modifiedImg);
            modifiedImage.Image = modifiedImg.Bitmap;
        }

        private void edgeDetectionButton_Click(object sender, EventArgs e)
        {
            convFilters[3].applyFilter(modifiedImg);
            modifiedImage.Image = modifiedImg.Bitmap;
        }

        private void embossButton_Click(object sender, EventArgs e)
        {
            convFilters[4].applyFilter(modifiedImg);
            modifiedImage.Image = modifiedImg.Bitmap;
        }

        private void kernelGridButton_Click(object sender, EventArgs e)
        {
            while (kernelEditorPanel.Controls.Count > 0)
            {
                kernelEditorPanel.Controls[0].Dispose();
            }

            for (int i = 0; i < kernelColumns.Value; i++)
            {
                for (int j = 0; j < kernelRows.Value; j++)
                {
                    TextBox input = new TextBox();
                    input.Text = "0";
                    kernelEditorPanel.Controls.Add(input, i, j);
                }
            }
            anchorX.Maximum = kernelColumns.Value - 1;
            anchorX.Value = Math.Floor(kernelColumns.Value / 2);
            anchorY.Maximum = kernelRows.Value - 1;
            anchorY.Value = Math.Floor(kernelRows.Value / 2);
            customKernelWidth = (int)kernelColumns.Value;
            customKernelHeight = (int)kernelRows.Value;
        }

        private void calcDivisorButton_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < kernelColumns.Value; i++)
            {
                for (int j = 0; j < kernelRows.Value; j++)
                {
                    sum += Int32.Parse(kernelEditorPanel.GetControlFromPosition(i, j).Text);
                }
            }
            if(sum == 0)
            {
                divisorValue.Text = "1";
            }
            else
            {
                divisorValue.Text = sum.ToString();
            }
        }

        private void loadKernel_Click(object sender, EventArgs e)
        {
            while (kernelEditorPanel.Controls.Count > 0)
            {
                kernelEditorPanel.Controls[0].Dispose();
            }

            kernelColumns.Value = convFilters[loadComboBox.SelectedIndex].kernel.GetLength(0);
            kernelRows.Value = convFilters[loadComboBox.SelectedIndex].kernel.GetLength(1);
            divisorValue.Text = convFilters[loadComboBox.SelectedIndex].divisor.ToString();
            divisorValue.Text = convFilters[loadComboBox.SelectedIndex].divisor.ToString();
            offsetValue.Text = convFilters[loadComboBox.SelectedIndex].offset.ToString();

            anchorX.Maximum = kernelColumns.Value - 1;
            anchorY.Maximum = kernelRows.Value - 1;

            anchorX.Value = convFilters[loadComboBox.SelectedIndex].anchorX;
            anchorY.Value = convFilters[loadComboBox.SelectedIndex].anchorY;

            for (int i = 0; i < kernelColumns.Value; i++)
            {
                for (int j = 0; j < kernelRows.Value; j++)
                {
                    TextBox input = new TextBox();
                    input.Text = convFilters[loadComboBox.SelectedIndex].kernel[i, j].ToString();
                    kernelEditorPanel.Controls.Add(input, i, j);
                }
            }
            customKernelWidth = (int)kernelColumns.Value;
            customKernelHeight = (int)kernelRows.Value;
        }

        private void applyFilterButton_Click(object sender, EventArgs e)
        {
            int[,] customKernel = new int[customKernelWidth, customKernelHeight];

            for (int i = 0; i < customKernelWidth; i++)
            {
                for (int j = 0; j < customKernelHeight; j++)
                {
                    customKernel[i, j] = Int32.Parse(kernelEditorPanel.GetControlFromPosition(i, j).Text);
                }
            }
            ConvolutionFilter custom = new CustomFilter(
                "custom",
                customKernel,
                Int32.Parse(offsetValue.Text),
                Int32.Parse(divisorValue.Text),
                (int)anchorX.Value, (int)anchorY.Value);

            custom.applyFilter(modifiedImg);
            modifiedImage.Image = modifiedImg.Bitmap;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int[,] customKernel = new int[customKernelWidth, customKernelHeight];

            for (int i = 0; i < customKernelWidth; i++)
            {
                for (int j = 0; j < customKernelHeight; j++)
                {
                    customKernel[i, j] = Int32.Parse(kernelEditorPanel.GetControlFromPosition(i, j).Text);
                }
            }

            SavePopupForm popup = new SavePopupForm();
            DialogResult dialogresult = popup.ShowDialog();

            if (dialogresult == DialogResult.OK)
            {
                ConvolutionFilter custom = new CustomFilter(
                    popup.Controls[0].Text,
                    customKernel,
                    Int32.Parse(offsetValue.Text),
                    Int32.Parse(divisorValue.Text),
                    (int)anchorX.Value, (int)anchorY.Value);
                convFilters.Add(custom);
                loadComboBox.Items.Add(custom.filterName);
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                ConvolutionFilter custom = new CustomFilter(
                   $"Filter no. {customFilterNr}",
                   customKernel,
                   Int32.Parse(offsetValue.Text),
                   Int32.Parse(divisorValue.Text),
                   (int)anchorX.Value, (int)anchorY.Value);
                convFilters.Add(custom);
                loadComboBox.Items.Add(custom.filterName);
                customFilterNr++;
            }
            popup.Dispose();
        }

        private void labPartButton_Click(object sender, EventArgs e)
        {
            AdditionalFilter newFilter = new AdditionalFilter();
            newFilter.applyAdditionalFilter(modifiedImg, 150);
            modifiedImage.Image = modifiedImg.Bitmap;
        }

        private void grayscaleButton_Click(object sender, EventArgs e)
        {
            functionFilter.toGrayScale(modifiedImg);
            modifiedImage.Image = modifiedImg.Bitmap;
        }

        private void popularityButton_Click(object sender, EventArgs e)
        {
            PopularityQuantization quantization = new PopularityQuantization();
            quantization.applyQuantization(modifiedImg, (int)quantizationColors.Value);
            modifiedImage.Image = modifiedImg.Bitmap;
        }

        private void ditheringButton_Click(object sender, EventArgs e)
        {
            errorDiffusionFilters[ditherFilterCombo.SelectedIndex].applyFilter(modifiedImg, (int)ditheringColors.Value);
            modifiedImage.Image = modifiedImg.Bitmap;
        }

        private bool isGrayscale(DirectBitmap bitmap)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    if(!(bitmap.GetPixel(x, y).R == bitmap.GetPixel(x, y).G && bitmap.GetPixel(x, y).G == bitmap.GetPixel(x, y).B))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void stretchButton_Click(object sender, EventArgs e)
        {
            HistogramStretching stretching = new HistogramStretching();
            stretching.histogramStretch(modifiedImg);
            modifiedImage.Image = modifiedImg.Bitmap;
        }

        private void equalizationButton_Click(object sender, EventArgs e)
        {
            HistogramEqualization equalization = new HistogramEqualization();
            equalization.equalizeHistogram(modifiedImg);
            modifiedImage.Image = modifiedImg.Bitmap;
        }
    }
}