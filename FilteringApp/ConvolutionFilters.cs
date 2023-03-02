using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringApp
{
    internal class ConvolutionFilters : Filter
    {
        private Color[,] getColorsMatrix(int x, int y, Bitmap originalImage)
        {
            Color[,] colorsMatrix = new Color[3, 3];

            for (int posX = 0; posX < 3; posX++)
            {
                for (int posY = 0; posY < 3; posY++)
                {
                    colorsMatrix[posX, posY] = originalImage.GetPixel(x - 1 + posX, y - 1 + posY);
                }
            }
            return colorsMatrix;
        }

        private double getRedChannelFromKernel(Color[,] colorsMatrix, double[,] kernel)
        {
            double red = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
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

        public Bitmap blurFilter(Bitmap originalImage, double[,] kernel, int anchorX, int anchorY, int offset, int divisor)
        {
            Bitmap afterModificationMap = new Bitmap(originalImage.Width, originalImage.Height);
            int height = kernel.GetLength(0);
            int width = kernel.GetLength(1);

            for (int x = anchorX; x < originalImage.Width - (width + anchorX + 1); x++)
            {
                for (int y = anchorY; y < originalImage.Height - (height + anchorY + 1); y++)
                {
                    Color[,] colorsMatrix = getColorsMatrix(x, y, originalImage);

                    double red = (getRedChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double green = (getGreenChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double blue = (getBlueChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;

                    int[] rgb = rgbValidation((int)red, (int)green, (int)blue);

                    colorsMatrix[1, 1] = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    afterModificationMap.SetPixel(x, y, colorsMatrix[1, 1]);
                }
            }
            return afterModificationMap;
        }

        public Bitmap gaussianBlurFilter(Bitmap originalImage, double[,] kernel, int anchorX, int anchorY, int offset, int divisor)
        {
            Bitmap afterModificationMap = new Bitmap(originalImage.Width, originalImage.Height);
            int height = kernel.GetLength(0);
            int width = kernel.GetLength(1);

            for (int x = anchorX; x < originalImage.Width - (width + anchorX + 1); x++)
            {
                for (int y = anchorY; y < originalImage.Height - (height + anchorY + 1); y++)
                {
                    Color[,] colorsMatrix = getColorsMatrix(x, y, originalImage);

                    double red = (getRedChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double green = (getGreenChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double blue = (getBlueChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;

                    int[] rgb = rgbValidation((int)red, (int)green, (int)blue);

                    colorsMatrix[1, 1] = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    afterModificationMap.SetPixel(x, y, colorsMatrix[1, 1]);
                }
            }
            return afterModificationMap;
        }

        public Bitmap sharpenFilter(Bitmap originalImage, double[,] kernel, int anchorX, int anchorY, int offset, int divisor)
        {
            Bitmap afterModificationMap = new Bitmap(originalImage.Width, originalImage.Height);
            int height = kernel.GetLength(0);
            int width = kernel.GetLength(1);

            for (int x = anchorX; x < originalImage.Width - (width + anchorX + 1); x++)
            {
                for (int y = anchorY; y < originalImage.Height - (height + anchorY + 1); y++)
                {
                    Color[,] colorsMatrix = getColorsMatrix(x, y, originalImage);

                    double red = (getRedChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double green = (getGreenChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double blue = (getBlueChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;

                    int[] rgb = rgbValidation((int)red, (int)green, (int)blue);

                    colorsMatrix[1, 1] = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    afterModificationMap.SetPixel(x, y, colorsMatrix[1, 1]);
                }
            }
            return afterModificationMap;
        }

        public Bitmap edgeDetectionFilter(Bitmap originalImage, double[,] kernel, int anchorX, int anchorY, int offset, int divisor)
        {
            Bitmap afterModificationMap = new Bitmap(originalImage.Width, originalImage.Height);
            int height = kernel.GetLength(0);
            int width = kernel.GetLength(1);

            for (int x = anchorX; x < originalImage.Width - (width + anchorX + 1); x++)
            {
                for (int y = anchorY; y < originalImage.Height - (height + anchorY + 1); y++)
                {
                    Color[,] colorsMatrix = getColorsMatrix(x, y, originalImage);

                    double red = (getRedChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double green = (getGreenChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double blue = (getBlueChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;

                    int[] rgb = rgbValidation((int)red, (int)green, (int)blue);

                    colorsMatrix[1, 1] = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    afterModificationMap.SetPixel(x, y, colorsMatrix[1, 1]);
                }
            }
            return afterModificationMap;
        }
        public Bitmap embossFilter(Bitmap originalImage, double[,] kernel, int anchorX, int anchorY, int offset, int divisor)
        {
            Bitmap afterModificationMap = new Bitmap(originalImage.Width, originalImage.Height);
            int height = kernel.GetLength(0);
            int width = kernel.GetLength(1);

            for (int x = anchorX; x < originalImage.Width - (width + anchorX + 1); x++)
            {
                for (int y = anchorY; y < originalImage.Height - (height + anchorY + 1); y++)
                {
                    Color[,] colorsMatrix = getColorsMatrix(x, y, originalImage);

                    double red = (getRedChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double green = (getGreenChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double blue = (getBlueChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;

                    int[] rgb = rgbValidation((int)red, (int)green, (int)blue);

                    colorsMatrix[1, 1] = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    afterModificationMap.SetPixel(x, y, colorsMatrix[1, 1]);
                }
            }
            return afterModificationMap;
        }
    }
}
