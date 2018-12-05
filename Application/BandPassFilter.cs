using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class BandPassFilter
    {
        public double[] Filter(double[] indata, double sampleRate, string HL)
        {
            double[] error = { };
            long dF2 = indata.Length - 1;        // The data range is set with dF2
            double[] Dat2 = new double[dF2 + 4]; // Array with 4 extra points front and back // INPUT
                                                 // double[] data = indata; // Ptr., changes passed data
            double[] data = new double[indata.Length];
            // Copy indata to Dat2
            for (long r = 0; r < dF2; r++)
            {
                Dat2[2 + r] = indata[r];
            }
            Dat2[1] = Dat2[0] = indata[0];
            Dat2[dF2 + 3] = Dat2[dF2 + 2] = indata[dF2];

            // RECURSIVE TRIGGERS - ENABLE filter is performed (first, last points constant)
            double[] DatYt = new double[dF2 + 4]; //OUTPUT
            DatYt[1] = DatYt[0] = indata[0];

            double[] DatH = new double[dF2 + 4]; //OUTPUT
            DatH[1] = DatH[0] = indata[0];

            // LOW FILTER
            if (HL == "LOW")
            {
                double cN = 1 / Math.Tan(Math.PI * 12 / sampleRate);
                double a1N = 1.0 / (1.0 + Math.Sqrt(2) * cN + cN * cN);
                double a2N = 2 * a1N;
                double a3N = a1N;
                double b1N = 2.0 * (1 - cN * cN) * a1N;
                double b2N = (1.0 - Math.Sqrt(2) * cN + cN * cN) * a1N;

                for (long n = 2; n < dF2 + 2; n++)
                {
                    DatYt[n] = a1N * Dat2[n] + a2N * Dat2[n - 1] + a3N * Dat2[n - 2] - b1N * DatYt[n - 1] - b2N * DatYt[n - 2];
                }
                DatYt[dF2 + 3] = DatYt[dF2 + 2] = DatYt[dF2 + 1];

                for (long p = 0; p < dF2; p++)
                {
                    data[p] = DatYt[p];
                }
                return data;
            }


            //HIGH FILTER 
            if (HL == "HIGH")
            {
                double cNH = Math.Tan(Math.PI * 7 / sampleRate);
                double a1NH = 1.0 / (1.0 + Math.Sqrt(2) * cNH + cNH * cNH);
                double a2NH = -2 * a1NH;
                double a3NH = a1NH;
                double b1NH = 2.0 * (cNH * cNH - 1) * a1NH;
                double b2NH = (1.0 - Math.Sqrt(2) * cNH + cNH * cNH) * a1NH;

                for (long n = 2; n < dF2 + 2; n++)
                {
                    DatH[n] = a1NH * Dat2[n] + a2NH * Dat2[n - 1] + a3NH * Dat2[n - 2] - b1NH * DatH[n - 1] - b2NH * DatH[n - 2];
                }
                DatH[dF2 + 3] = DatH[dF2 + 2] = DatH[dF2 + 1];

                for (long p = 0; p < dF2; p++)
                {
                    data[p] = DatH[p];
                }
                return data;
            }
            else
            {
                return error;
            }
        }
    }
}
