using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FilteringApp
{
    internal class HistogramStretching : HistogramOperations
    {
        public int getMinValue(int[] hist)
        {
            for(int i=0; i<256; i++)
            {
                if (hist[i] != 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public int getMaxValue(int[] hist)
        {
            for (int i = 255; i >=0; i--)
            {
                if (hist[i] != 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public void histogramStretch(DirectBitmap bitmap)
        {
            int[] RHistogram = getRHistogram(bitmap);
            int[] GHistogram = getGHistogram(bitmap);
            int[] BHistogram = getBHistogram(bitmap);

            int RMin = getMinValue(RHistogram);
            int RMax = getMaxValue(RHistogram);

            int GMin = getMinValue(GHistogram);
            int GMax = getMaxValue(GHistogram);

            int BMin = getMinValue(BHistogram);
            int BMax = getMaxValue(BHistogram);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color currPixel = bitmap.GetPixel(x, y);
                    int R = (int)((255 / (RMax - RMin)) * (currPixel.R - RMin));
                    int G = (int)((255 / (GMax - GMin)) * (currPixel.G - GMin));
                    int B = (int)((255 / (BMax - BMin)) * (currPixel.B - BMin));
                    bitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
        }
    }
}
