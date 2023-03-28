using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilteringApp
{
    public abstract class ErrorDiffusion : Filter
    {
        public abstract string filterName { get; }
        public abstract int f_x { get; }
        public abstract int f_y { get; }
        public abstract float[,] kernel { get; }

        public Color getNearestColor(Color currColor, List<Color> colorPalette)
        {
            Color nearestColor = Color.Black;
            int minDistance = int.MaxValue;
            int cnt = colorPalette.Count;
            for (int i = 0; i < cnt; i++)
            {
                int rRed = colorPalette[i].R - currColor.R;
                int rGreen = colorPalette[i].G - currColor.G;
                int rBlue = colorPalette[i].B - currColor.B;
                int rDistance =
                (rRed * rRed) +
                (rGreen * rGreen) +
                (rBlue * rBlue);

                if (rDistance == 0.0)
                {
                    return colorPalette[i];
                }
                else if (rDistance < minDistance)
                {
                    minDistance = rDistance;
                    nearestColor = colorPalette[i];
                }
            }
            return nearestColor;
        }

        public List<Color> getColorPalette(int k)
        {
            //List<Color> palette = new List<Color>();
            //int val = 255;
            //if (k == 1)
            //{
            //    palette.Add(Color.FromArgb(127, 127, 127));
            //} 
            //else if (k == 2)
            //{
            //    palette.Add(Color.FromArgb(0, 0, 0));
            //    palette.Add(Color.FromArgb(255, 255, 255));
            //}
            //else
            //{
            //    palette.Add(Color.FromArgb(0, 0, 0));
            //    palette.Add(Color.FromArgb(255, 255, 255));
            //    val = (int)Math.Floor(255.0 / (k - 1));
            //    int temp = val;
            //    for(int i=0; i < k - 2; i++)
            //    {
            //        palette.Add(Color.FromArgb(temp, temp, temp));
            //        temp += val;
            //    }

            //}
            //return palette;

            List<Color> palette = new List<Color>();
            int step = (int)(255 / (k - 1));
            int[] thresholds = new int[k];
            thresholds[0] = 0;
            thresholds[k - 1] = 255;
            for(int i=1; i < k - 1; i++)
            {
                thresholds[i] = thresholds[i - 1] + step;
            }
            for(int i = 0; i < k; i++)
            {
                for(int j = 0; j < k; j++)
                {
                    for(int l = 0; l < k; l++)
                    {
                        palette.Add(Color.FromArgb(thresholds[i], thresholds[j], thresholds[l]));
                    }
                }
            }
            return palette;
        }

        public void applyFilter(DirectBitmap bitmap, int k)
        {
            int error_r = 0;
            int error_g = 0;
            int error_b = 0;
            List<Color> palette = getColorPalette(k);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color originalPixel = bitmap.GetPixel(x, y);
                    Color transformedPixel = getNearestColor(originalPixel, palette);
                    bitmap.SetPixel(x, y, transformedPixel);
                    error_r = originalPixel.R - transformedPixel.R;
                    error_g = originalPixel.G - transformedPixel.G;
                    error_b = originalPixel.B - transformedPixel.B;
                    for(int i=-f_x; i <= f_x; i++)
                    {
                        for(int j=-f_y; j<= f_y; j++)
                        {
                            if(kernel[i + f_x, j + f_y] != 0 && x+i>=0 && x + i < bitmap.Width && y + j < bitmap.Height)
                            {
                                Color newPix = bitmap.GetPixel(x + i, y + j);
                                int new_r = Convert.ToInt32(newPix.R + error_r * kernel[i + f_x, j + f_y]);
                                int new_g = Convert.ToInt32(newPix.G + error_g * kernel[i + f_x, j + f_y]);
                                int new_b = Convert.ToInt32(newPix.B + error_b * kernel[i + f_x, j + f_y]);
                                int[] rgb = rgbValidation(new_r, new_g, new_b);
                                bitmap.SetPixel(x + i, y + j, Color.FromArgb(rgb[0], rgb[1], rgb[2]));
                            }
                        }
                    }
                }
            }
        }

    }


    public class FloydSteinberg : ErrorDiffusion
    {
        public override string filterName
        {
            get { return "Floyd and Steinberg Filter"; }
        }

        float[,] _kernel = new float[3, 3] { { 0, 0, (float)3/16 }, { 0, 0, (float)5/16 }, { 0, (float)7/16, (float)1/16 } };

        public override float[,] kernel
        {
            get { return _kernel; }
        }

        int _f_x = 1;
        public override int f_x
        {
            get { return _f_x; }
        }

        int _f_y = 1;
        public override int f_y
        {
            get { return _f_y; }
        }
    }

    public class Burkes : ErrorDiffusion
    {
        public override string filterName
        {
            get { return "Burkes Filter"; }
        }

        float[,] _kernel = new float[5, 3] { { 0, 0, (float)2 / 32 }, { 0, 0, (float)4 / 32 }, { 0, 0, (float)8 / 32 }, { 0, (float)8 / 32, (float)4 / 32 }, { 0, (float)4 / 32, (float)2 / 32 } };

        public override float[,] kernel
        {
            get { return _kernel; }
        }

        int _f_x = 2;
        public override int f_x
        {
            get { return _f_x; }
        }

        int _f_y = 1;
        public override int f_y
        {
            get { return _f_y; }
        }
    }

    public class Stucky : ErrorDiffusion
    {
        public override string filterName
        {
            get { return "Stucky Filter"; }
        }

        float[,] _kernel = new float[5, 5] { { 0, 0, 0, (float)2 / 32, (float)1 / 32 }, 
            { 0, 0, 0, (float)4 / 32, (float)2 / 32 }, 
            { 0, 0, 0, (float)8 / 32, (float)4 / 32 }, 
            { 0, 0, (float)8 / 32, (float)4 / 32, (float)2 / 32 }, 
            { 0, 0, (float)4 / 32, (float)2 / 32, (float)1 / 32 } };

        public override float[,] kernel
        {
            get { return _kernel; }
        }

        int _f_x = 2;
        public override int f_x
        {
            get { return _f_x; }
        }

        int _f_y = 2;
        public override int f_y
        {
            get { return _f_y; }
        }
    }

    public class Sierra : ErrorDiffusion
    {
        public override string filterName
        {
            get { return "Sierra Filter"; }
        }

        float[,] _kernel = new float[5, 5] { { 0, 0, 0, (float)2 / 32, 0 },
            { 0, 0, 0, (float)4 / 32, (float)2 / 32 },
            { 0, 0, 0, (float)5 / 32, (float)3 / 32 },
            { 0, 0, (float)5 / 32, (float)4 / 32, (float)2 / 32 },
            { 0, 0, (float)3 / 32, (float)2 / 32, 0 } };

        public override float[,] kernel
        {
            get { return _kernel; }
        }

        int _f_x = 2;
        public override int f_x
        {
            get { return _f_x; }
        }

        int _f_y = 2;
        public override int f_y
        {
            get { return _f_y; }
        }
    }

    public class Atkinson : ErrorDiffusion
    {
        public override string filterName
        {
            get { return "Atkinson Filter"; }
        }

        float[,] _kernel = new float[5, 5] { { 0, 0, 0, 0, 0 },
            { 0, 0, 0, (float)1 / 8, 0 },
            { 0, 0, 0, (float)1 / 8, (float)1 / 8 },
            { 0, 0, (float)1 / 8, (float)1 / 8, 0 },
            { 0, 0, (float)1 / 8, 0, 0 } };

        public override float[,] kernel
        {
            get { return _kernel; }
        }

        int _f_x = 2;
        public override int f_x
        {
            get { return _f_x; }
        }

        int _f_y = 2;
        public override int f_y
        {
            get { return _f_y; }
        }
    }


}
