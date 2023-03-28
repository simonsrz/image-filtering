using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringApp
{
    public class PopularityQuantization
    {
        public IEnumerable<Color> getColors(DirectBitmap bitmap)
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    yield return bitmap.GetPixel(x, y);
                }
            }
        }

        public List<Color> getColorPalette(DirectBitmap bitmap, int k)
        {
            List<Color> palette = getColors(bitmap)
                .GroupBy(color => color)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .Take(k)
                .ToList();
            return palette;
        }

        Color getNearestColor(Color currColor, List<Color> colorPalette)
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

        public void applyQuantization(DirectBitmap bitmap, int k)
        {
            List<Color> palette = getColorPalette(bitmap, k);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    bitmap.SetPixel(x, y, getNearestColor(pixel, palette));
                }
            }
        }
    }
}
