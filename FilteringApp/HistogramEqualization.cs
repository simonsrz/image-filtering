using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringApp
{
    internal class HistogramEqualization : HistogramOperations
    {
        public double[] calculateDistribution(int[] hist, DirectBitmap bitmap)
        {
            double n = bitmap.Width * bitmap.Height;
            double[] dist = new double[256];
            for(int i=0; i < 256; i++)
            {
                double sum = 0;
                for(int j=0; j<=i; j++)
                {
                    sum += hist[j];
                }
                dist[i] = sum / n;
            }
            return dist;
        }

        public int getMinValue(double[] dist)
        {
            for (int i = 0; i < 256; i++)
            {
                if (dist[i] != 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public void equalizeHistogram(DirectBitmap bitmap)
        {
            int[] RHistogram = getRHistogram(bitmap);
            int[] GHistogram = getGHistogram(bitmap);
            int[] BHistogram = getBHistogram(bitmap);

            double[] RDist = calculateDistribution(RHistogram, bitmap);
            double[] GDist = calculateDistribution(GHistogram, bitmap);
            double[] BDist = calculateDistribution(BHistogram, bitmap);

            int RDMin = getMinValue(RDist);
            int GDMin = getMinValue(GDist);
            int BDMin = getMinValue(BDist);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color currPixel = bitmap.GetPixel(x, y);
                    int R = (int)(((RDist[currPixel.R] - RDist[RDMin]) / (1 - RDist[RDMin])) * 255);
                    int G = (int)(((GDist[currPixel.G] - GDist[GDMin]) / (1 - GDist[GDMin])) * 255);
                    int B = (int)(((BDist[currPixel.B] - BDist[BDMin]) / (1 - BDist[BDMin])) * 255);
                    bitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
        }
    }
}
