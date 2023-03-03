using System;
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

        private double getRedChannelFromKernel(Color[,] colorsMatrix, int[,] kernel)
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
        private double getGreenChannelFromKernel(Color[,] colorsMatrix, int[,] kernel)
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
        private double getBlueChannelFromKernel(Color[,] colorsMatrix, int[,] kernel)
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

        public Bitmap applyFilter(Bitmap originalImage)
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
}
