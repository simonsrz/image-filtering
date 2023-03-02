using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringApp
{
    internal class FunctionFilters : Filter
    {
        public Bitmap colorInversion(Bitmap originalImage)
        {
            Bitmap afterModificationMap = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color currPixel = originalImage.GetPixel(x, y);

                    currPixel = Color.FromArgb(255 - currPixel.R, 255 - currPixel.G, 255 - currPixel.B);

                    afterModificationMap.SetPixel(x, y, currPixel);
                }
            }

            return afterModificationMap;
        }

        public Bitmap brightnessEnhancement(Bitmap originalImage, int brightnessLevel)
        {
            Bitmap afterModificationMap = new Bitmap(originalImage.Width, originalImage.Height);

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

                    afterModificationMap.SetPixel(x, y, currPixel);
                }
            }

            return afterModificationMap;
        }

        public Bitmap contrastEnhancement(Bitmap originalImage, double contrastThreshold)
        {
            double contrastLevel = Math.Pow((100.0 + contrastThreshold) / 100.0, 2);
            Bitmap afterModificationMap = new Bitmap(originalImage.Width, originalImage.Height);

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

                    afterModificationMap.SetPixel(x, y, currPixel);
                }
            }

            return afterModificationMap;
        }

        public Bitmap gammaCorrection(Bitmap originalImage, double gamma)
        {
            Bitmap afterModificationMap = new Bitmap(originalImage.Width, originalImage.Height);

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

                    afterModificationMap.SetPixel(x, y, currPixel);
                }
            }

            return afterModificationMap;
        }
    }
}
