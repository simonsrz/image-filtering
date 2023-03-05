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
        List<ConvolutionFilter> convFilters = new List<ConvolutionFilter>();
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
            loadComboBox.SelectedIndex = 0;
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
            modifiedImage.Image = convFilters[0].applyFilter(modifiedImg);
            modifiedImg = convFilters[0].applyFilter(modifiedImg);
        }

        private void gaussianBlurButton_Click(object sender, EventArgs e)
        {
            modifiedImage.Image = convFilters[1].applyFilter(modifiedImg);
            modifiedImg = convFilters[1].applyFilter(modifiedImg);
        }

        private void sharpenButton_Click(object sender, EventArgs e)
        {
            modifiedImage.Image = convFilters[2].applyFilter(modifiedImg);
            modifiedImg = convFilters[2].applyFilter(modifiedImg);
        }

        private void edgeDetectionButton_Click(object sender, EventArgs e)
        {
            modifiedImage.Image = convFilters[3].applyFilter(modifiedImg);
            modifiedImg = convFilters[3].applyFilter(modifiedImg);
        }

        private void embossButton_Click(object sender, EventArgs e)
        {
            modifiedImage.Image = convFilters[4].applyFilter(modifiedImg);
            modifiedImg = convFilters[4].applyFilter(modifiedImg);
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

            kernelColumns.Value = convFilters[loadComboBox.SelectedIndex].kernel.GetLength(1);
            kernelRows.Value = convFilters[loadComboBox.SelectedIndex].kernel.GetLength(0);
            divisorValue.Text = convFilters[loadComboBox.SelectedIndex].divisor.ToString();
            divisorValue.Text = convFilters[loadComboBox.SelectedIndex].divisor.ToString();
            offsetValue.Text = convFilters[loadComboBox.SelectedIndex].offset.ToString();
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
            int[,] customKernel = new int[customKernelWidth,customKernelHeight];

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

            modifiedImage.Image = custom.applyFilter(modifiedImg);
            modifiedImg = custom.applyFilter(modifiedImg);
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
    }
}