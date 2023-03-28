using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringApp
{
    internal class FunctionFilters : Filter
    {
        public void colorInversion(DirectBitmap originalImage)
        {
            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color currPixel = originalImage.GetPixel(x, y);

                    currPixel = Color.FromArgb(255 - currPixel.R, 255 - currPixel.G, 255 - currPixel.B);

                    originalImage.SetPixel(x, y, currPixel);
                }
            }
        }

        public void brightnessEnhancement(DirectBitmap originalImage, int brightnessLevel)
        {
            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color currPixel = originalImage.GetPixel(x, y);

                    int red = currPixel.R + brightnessLevel;
                    int green = currPixel.G + brightnessLevel;
                    int blue = currPixel.B + brightnessLevel;

                    int[] rgb = rgbValidation(red, green, blue);

                    currPixel = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    originalImage.SetPixel(x, y, currPixel);
                }
            }
        }

        public void contrastEnhancement(DirectBitmap originalImage, double contrastThreshold)
        {
            double contrastLevel = Math.Pow((100.0 + contrastThreshold) / 100.0, 2);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color currPixel = originalImage.GetPixel(x, y);

                    int red = (int)(((((currPixel.R / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0);
                    int green = (int)(((((currPixel.G / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0);
                    int blue = (int)(((((currPixel.B / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0);

                    int[] rgb = rgbValidation(red, green, blue);

                    currPixel = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    originalImage.SetPixel(x, y, currPixel);
                }
            }
        }

        public void gammaCorrection(DirectBitmap originalImage, double gamma)
        {
            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color currPixel = originalImage.GetPixel(x, y);

                    int red = (int)(255.0 * Math.Pow((currPixel.R / 255.0), gamma));
                    int green = (int)(255.0 * Math.Pow((currPixel.G / 255.0), gamma));
                    int blue = (int)(255.0 * Math.Pow((currPixel.B / 255.0), gamma));

                    int[] rgb = rgbValidation(red, green, blue);

                    currPixel = Color.FromArgb(rgb[0], rgb[1], rgb[2]);

                    originalImage.SetPixel(x, y, currPixel);
                }
            }
        }

        public void toGrayScale(DirectBitmap originalImage)
        {
            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color currPixel = originalImage.GetPixel(x, y);

                    int avg = (currPixel.R + currPixel.G + currPixel.B) / 3;

                    currPixel = Color.FromArgb(avg, avg, avg);

                    originalImage.SetPixel(x, y, currPixel);
                }
            }
        }
    }
}
