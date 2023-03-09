using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringApp
{
    public abstract class ConvolutionFilter : Filter
    {

        public abstract string filterName { get; }
        public abstract int divisor { get; }
        public abstract int offset { get; }
        public abstract int anchorX { get; }
        public abstract int anchorY { get; }
        public abstract int[,] kernel { get; }

        public Color[,] getColorsMatrix(int x, int y, int ancX, int ancY, Bitmap originalImage)
        {
            Color[,] colorsMatrix = new Color[kernel.GetLength(0), kernel.GetLength(1)];

            for (int posX = 0; posX < kernel.GetLength(0); posX++)
            {
                for (int posY = 0; posY < kernel.GetLength(1); posY++)
                {
                    int xp = Math.Clamp(x - ancX + posX, 0, originalImage.Width - 1);
                    int yp = Math.Clamp(y - ancY + posY, 0, originalImage.Height - 1);
                    colorsMatrix[posX, posY] = originalImage.GetPixel(xp, yp);
                }
            }
            return colorsMatrix;
        }

        public double getRedChannelFromKernel(Color[,] colorsMatrix, int[,] kernel)
        {
            double red = 0;
            for (int i = 0; i < kernel.GetLength(0); i++)
            {
                for (int j = 0; j < kernel.GetLength(1); j++)
                {
                    red += colorsMatrix[i, j].R * kernel[i, j];
                }
            }
            return red;
        }
        public double getGreenChannelFromKernel(Color[,] colorsMatrix, int[,] kernel)
        {
            double green = 0;
            for (int i = 0; i < kernel.GetLength(0); i++)
            {
                for (int j = 0; j < kernel.GetLength(1); j++)
                {
                    green += colorsMatrix[i, j].G * kernel[i, j];
                }
            }
            return green;
        }
        public double getBlueChannelFromKernel(Color[,] colorsMatrix, int[,] kernel)
        {
            double blue = 0;
            for (int i = 0; i < kernel.GetLength(0); i++)
            {
                for (int j = 0; j < kernel.GetLength(1); j++)
                {
                    blue += colorsMatrix[i, j].B * kernel[i, j];
                }
            }
            return blue;
        }

        public Bitmap applyFilter(Bitmap originalImage)
        {
            Bitmap afterModificationMap = new Bitmap( originalImage.Width, originalImage.Height);
            int height = kernel.GetLength(1);
            int width = kernel.GetLength(0);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color[,] colorsMatrix = getColorsMatrix(x, y, anchorX, anchorY, originalImage);

                    double red = (getRedChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double green = (getGreenChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;
                    double blue = (getBlueChannelFromKernel(colorsMatrix, kernel) / divisor) + offset;

                    int[] rgb = rgbValidation((int)red, (int)green, (int)blue);

                    colorsMatrix[anchorX, anchorY] = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    afterModificationMap.SetPixel(x, y, colorsMatrix[anchorX, anchorY]);
                }
            }
            return afterModificationMap;
        }

    }

    public class BlurFillter : ConvolutionFilter
    {
        public override string filterName
        {
            get { return "Blur Filter"; }
        }


        private int _divisor = 9;
        public override int divisor
        {
            get { return _divisor; }
        }


        private int _offset = 0;
        public override int offset
        {
            get { return _offset; }
        }


        int[,] _kernel = new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

        public override int[,] kernel
        {
            get { return _kernel; }
        }

        int _anchorX = 1;
        public override int anchorX
        {
            get { return _anchorX; }
        }

        int _anchorY = 1;
        public override int anchorY
        {
            get { return _anchorY; }
        }
    }

    public class GaussianBlurFillter : ConvolutionFilter
    {
        public override string filterName
        {
            get { return "Gaussian Blur Filter"; }
        }


        private int _divisor = 18;
        public override int divisor
        {
            get { return _divisor; }
        }


        private int _offset = 0;
        public override int offset
        {
            get { return _offset; }
        }


        int[,] _kernel = new int[3, 3] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };

    public override int[,] kernel
        {
            get { return _kernel; }
        }

        int _anchorX = 1;
        public override int anchorX
        {
            get { return _anchorX; }
        }

        int _anchorY = 1;
        public override int anchorY
        {
            get { return _anchorY; }
        }
    }

    public class SharpenFilter : ConvolutionFilter
    {
        public override string filterName
        {
            get { return "Sharpen Filter"; }
        }


        private int _divisor = 1;
        public override int divisor
        {
            get { return _divisor; }
        }


        private int _offset = 0;
        public override int offset
        {
            get { return _offset; }
        }


        int[,] _kernel = new int[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };

        public override int[,] kernel
        {
            get { return _kernel; }
        }

        int _anchorX = 1;
        public override int anchorX
        {
            get { return _anchorX; }
        }

        int _anchorY = 1;
        public override int anchorY
        {
            get { return _anchorY; }
        }
    }

    public class EdgeDetectionFilter : ConvolutionFilter
    {
        public override string filterName
        {
            get { return "Edge Detection Filter"; }
        }


        private int _divisor = 1;
        public override int divisor
        {
            get { return _divisor; }
        }


        private int _offset = 0;
        public override int offset
        {
            get { return _offset; }
        }


        int[,] _kernel = new int[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };

        public override int[,] kernel
        {
            get { return _kernel; }
        }

        int _anchorX = 1;
        public override int anchorX
        {
            get { return _anchorX; }
        }

        int _anchorY = 1;
        public override int anchorY
        {
            get { return _anchorY; }
        }
    }

    public class EmbossFilter : ConvolutionFilter
    {
        public override string filterName
        {
            get { return "Emboss Filter"; }
        }


        private int _divisor = 1;
        public override int divisor
        {
            get { return _divisor; }
        }


        private int _offset = 0;
        public override int offset
        {
            get { return _offset; }
        }


        int[,] _kernel = new int[3, 3] { { -1, -1, -1 }, { 0, 1, 0 }, { 1, 1, 1 } };

        public override int[,] kernel
        {
            get { return _kernel; }
        }

        int _anchorX = 1;
        public override int anchorX
        {
            get { return _anchorX; }
        }

        int _anchorY = 1;
        public override int anchorY
        {
            get { return _anchorY; }
        }
    }

    public class CustomFilter : ConvolutionFilter
    {
        string _name;
        int[,] _kernel = new int[,] {};
        private int _divisor;
        private int _offset;
        int _anchorX;
        int _anchorY;
    
        public CustomFilter(string name, int[,] kernel, int offset, int divisor, int anchorX, int anchorY)
        {
            _name = name;
            _kernel = kernel;
            _offset = offset;
            _divisor = divisor;
            _anchorX = anchorX;
            _anchorY = anchorY;
        }
        public override string filterName
        {
            get { return _name; }
        }
        public override int divisor
        {
            get { return _divisor; }
        }
        public override int offset
        {
            get { return _offset; }
        }
        public override int[,] kernel
        {
            get { return _kernel; }
        }
        public override int anchorX
        {
            get { return _anchorX; }
        }
        public override int anchorY
        {
            get { return _anchorY; }
        }
    }
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

        private double getRedChannelFromKernelLabPart(Color[,] colorsMatrix, int[,] kernel, int M)
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
            return red/divisor;
        }
        private double getGreenChannelFromKernelLabPart(Color[,] colorsMatrix, int[,] kernel, int M)
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
            return green/divisor;
        }
        private double getBlueChannelFromKernelLabPart(Color[,] colorsMatrix, int[,] kernel, int M)
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
            return blue/divisor;
        }

        public Bitmap applyAdditionalFilter(Bitmap originalImage, int M)
        {
            Bitmap afterModificationMap = new Bitmap(originalImage.Width, originalImage.Height);
            int height = kernel.GetLength(1);
            int width = kernel.GetLength(0);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color[,] colorsMatrix = getColorsMatrix(x, y, anchorX, anchorY, originalImage);

                    double red = (getRedChannelFromKernelLabPart(colorsMatrix, _kernel, M)) + _offset;
                    double green = (getGreenChannelFromKernelLabPart(colorsMatrix, _kernel, M)) + _offset;
                    double blue = (getBlueChannelFromKernelLabPart(colorsMatrix, _kernel, M)) + _offset;

                    int[] rgb = rgbValidation((int)red, (int)green, (int)blue);

                    colorsMatrix[_anchorX, _anchorY] = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    afterModificationMap.SetPixel(x, y, colorsMatrix[_anchorX, _anchorY]);
                }
            }
            return afterModificationMap;
        }
    }

}
