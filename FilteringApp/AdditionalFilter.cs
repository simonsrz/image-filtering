using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringApp
{
    public class AdditionalFilter : ConvolutionFilter
    {
        public override string filterName
        {
            get { return "Blur without edges"; }
        }

        private int _divisor = 25;
        public override int divisor
        {
            get { return _divisor; }
        }

        private int _offset = 0;
        public override int offset
        {
            get { return _offset; }
        }

        int[,] _kernel = new int[5, 5] { { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 } };

        public override int[,] kernel
        {
            get { return _kernel; }
        }

        int _anchorX = 2;
        public override int anchorX
        {
            get { return _anchorX; }
        }

        int _anchorY = 2;
        public override int anchorY
        {
            get { return _anchorY; }
        }

        private double getRedChannelFromKernelWithDistance(Color[,] colorsMatrix, int[,] kernel, int M)
        {
            double red = 0;
            int divisor = 0;
            for (int i = 0; i < kernel.GetLength(0); i++)
            {
                for (int j = 0; j < kernel.GetLength(1); j++)
                {
                    if (calculateDistance(colorsMatrix[anchorX, anchorY], colorsMatrix[i, j]) < M)
                    {
                        red += colorsMatrix[i, j].R * kernel[i, j];
                        divisor++;
                    }
                }
            }
            return red / divisor;
        }
        private double getGreenChannelFromKernelWithDistance(Color[,] colorsMatrix, int[,] kernel, int M)
        {
            double green = 0;
            int divisor = 0;
            for (int i = 0; i < kernel.GetLength(0); i++)
            {
                for (int j = 0; j < kernel.GetLength(1); j++)
                {
                    if (calculateDistance(colorsMatrix[anchorX, anchorY], colorsMatrix[i, j]) < M)
                    {
                        green += colorsMatrix[i, j].G * kernel[i, j];
                        divisor++;
                    }
                }
            }
            return green / divisor;
        }
        private double getBlueChannelFromKernelWithDistance(Color[,] colorsMatrix, int[,] kernel, int M)
        {
            double blue = 0;
            int divisor = 0;
            for (int i = 0; i < kernel.GetLength(0); i++)
            {
                for (int j = 0; j < kernel.GetLength(1); j++)
                {
                    if (calculateDistance(colorsMatrix[anchorX, anchorY], colorsMatrix[i, j]) < M)
                    {
                        blue += colorsMatrix[i, j].B * kernel[i, j];
                        divisor++;
                    }
                }
            }
            return blue / divisor;
        }

        public void applyAdditionalFilter(DirectBitmap originalImage, int M)
        {
            int height = kernel.GetLength(1);
            int width = kernel.GetLength(0);

            DirectBitmap temp = new DirectBitmap(originalImage.Width, originalImage.Height);
            using (var g = Graphics.FromImage(temp.Bitmap))
            {
                g.DrawImage(originalImage.Bitmap, 0, 0);


                for (int x = 0; x < temp.Width; x++)
                {
                    for (int y = 0; y < temp.Height; y++)
                    {
                        Color[,] colorsMatrix = getColorsMatrix(x, y, anchorX, anchorY, temp);

                        double red = (getRedChannelFromKernelWithDistance(colorsMatrix, _kernel, M)) + _offset;
                        double green = (getGreenChannelFromKernelWithDistance(colorsMatrix, _kernel, M)) + _offset;
                        double blue = (getBlueChannelFromKernelWithDistance(colorsMatrix, _kernel, M)) + _offset;

                        int[] rgb = rgbValidation((int)red, (int)green, (int)blue);

                        colorsMatrix[_anchorX, _anchorY] = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                        originalImage.SetPixel(x, y, colorsMatrix[_anchorX, _anchorY]);
                    }
                }
            }
            temp.Dispose();
        }
    }
}
