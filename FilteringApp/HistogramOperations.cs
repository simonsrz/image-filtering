using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringApp
{
    internal class HistogramOperations
    {
        public int[] getRHistogram(DirectBitmap bitmap)
        {
            int[] RHistogram = new int[256];
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    RHistogram[bitmap.GetPixel(x, y).R]++;
                }
            }
            return RHistogram;
        }

        public int[] getGHistogram(DirectBitmap bitmap)
        {
            int[] GHistogram = new int[256];
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    GHistogram[bitmap.GetPixel(x, y).G]++;
                }
            }
            return GHistogram;
        }

        public int[] getBHistogram(DirectBitmap bitmap)
        {
            int[] BHistogram = new int[256];
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    BHistogram[bitmap.GetPixel(x, y).B]++;
                }
            }
            return BHistogram;
        }
    }
}
