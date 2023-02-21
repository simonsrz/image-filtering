namespace FilteringApp
{
    public partial class Filtering : Form
    {
        Bitmap modifiedImg;
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
                modifiedImage.Image = new Bitmap(imgDialog.FileName);
                modifiedImg = new Bitmap(imgDialog.FileName);
            }
        }

        private void inversionButton_Click(object sender, EventArgs e)
        {
            Bitmap afterModificationMap = new Bitmap(modifiedImg.Width, modifiedImg.Height);

            for (int x = 0; x < modifiedImg.Width; x++)
            {
                for (int y = 0; y < modifiedImg.Height; y++)
                {
                    Color currPixel = modifiedImg.GetPixel(x, y);

                    currPixel = Color.FromArgb(255 - currPixel.R, 255 -
                       currPixel.G, 255 - currPixel.B);

                    afterModificationMap.SetPixel(x, y, currPixel);
                }
            }
            modifiedImage.Image = afterModificationMap;
            modifiedImg = afterModificationMap;
        }
    }
}