using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Application
{
    public partial class PanTompkins : Form
    {
        // LOW / HIGH PASS FILTER
        public static double[] Butterworth(double[] indata, double sampleRate, string HL)
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
                double cNH = Math.Tan(Math.PI * 10 / sampleRate);
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
        

        public void PanTompkinsAlgorithm(double[] indata, double sampleRate, double[] time, int SamplesToAnalise, Chart PressureChart1, Chart PressureChart2, Chart PressureChart3, Chart chart4, Label HeartRateLabel)
        {
            double[] lowFilter = new double[40000];
            double[] highFilter = new double[40000];
            double[] highoriginal = new double[40000];

            // FILTERING
            lowFilter = Butterworth(indata, sampleRate, "LOW");
            highFilter = Butterworth(indata, sampleRate, "HIGH");
            highoriginal = Butterworth(lowFilter, sampleRate, "HIGH");

            // DERIVATIVE
            double[] derivative = new double[40000];

            for (int i = 0; i < SamplesToAnalise; i++)
            {
                derivative[i] = (highoriginal[i + 1] - highoriginal[i]) / (time[i + 1] - time[i]);
            }
            PressureChart1.Titles["Title1"].Text = "DERIVATIVE";
            PressureChart1.Series["Pressure1"].ChartType = SeriesChartType.Spline;
            PressureChart1.Series["Pressure1"].Color = Color.Blue;
            PressureChart1.ChartAreas[0].AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);

            for (int i = 0; i < SamplesToAnalise; i++)
            {
               PressureChart1.Series["Pressure1"].Points.AddXY(time[i], derivative[i]);
            }

            // SQUARING
            double[] square = new double[40000];
            for (int i = 0; i < SamplesToAnalise; i++)
            {
                square[i] = derivative[i] * derivative[i];
            }
            PressureChart3.Titles["Title1"].Text = "SQUARE";
            for (int i = 0; i < SamplesToAnalise; i++)
            {
                PressureChart3.Series["Pressure1"].Points.AddXY(time[i], square[i]);
            }

            //MOVING AVERAGE FILTER
            double[] average = new double[40000];
            for (int j = 99; j < SamplesToAnalise + 99; j++)
            {
                double sum = 0;
                for (int i = 0; i < 100; i++)
                {
                    sum += square[j - (100 - (i + 1))];
                }

                average[j - 99] = sum / 100;
            }

            chart4.Titles["Title1"].Text = "MOVING AVERAGE FILTER";
            chart4.Series["Series1"].ChartType = SeriesChartType.Spline;
            chart4.Series["Series1"].Color = Color.DeepPink;
            chart4.ChartAreas[0].AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);
            for (int i = 0; i < SamplesToAnalise; i++)
            {
                chart4.Series["Series1"].Points.AddXY(time[i], average[i]);
            }

            //PEAK
            double[] first300 = new double[300];
            for (int i = 0; i < 300; i++)
            {
                first300[i] = average[i];
            }

            double maxValue = first300.Max();
            double SPK = 0.13 * maxValue;
            double NPK = 0.1 * SPK;
            double THRESHOLD = 0.25 * SPK + 0.75 * NPK;
            // double THRESHOLD = 0.5* maxValue;

            double[] QRS = new double[1000];
            List<double> lst = new List<double>();

            double[] first = new double[20000];
            int firstT = 0;
            for (int i = 0; i < SamplesToAnalise; i++)
            {
                if (average[i] == maxValue)
                {
                    firstT = i;
                }
            }
            // DETECTION
            for (int i = firstT; i < SamplesToAnalise; i++)
            {
                if (average[i] > THRESHOLD)
                {
                    first[i] = average[i];
                    if (average[i + 1] < THRESHOLD)
                    {
                        lst.Add(first.Max());
                        Array.Clear(first, 0, first.Length);
                    }
                }
            }
            int number = lst.Count;
            for (int i = 0; i < number - 1; i++)
            {
                double firstTime = 0;
                double secondTime = 0;
                for (int j = 0; j < SamplesToAnalise; j++)
                {
                    if (average[j] == lst[i])
                    {
                        firstTime = time[j];
                    }
                }
                for (int j = 0; j < SamplesToAnalise; j++)
                {
                    if (average[j] == lst[i + 1])
                    {
                        secondTime = time[j];
                    }
                }
                //MessageBox.Show("secondTime:" + secondTime + "f" + firstTime);
                if ((secondTime - firstTime) < 0.343)
                {
                    if (lst[i + 1] < lst[i])
                    {
                        lst[i + 1] = 0;
                    }
                    else
                    {
                        lst[i] = 0;
                    }
                }
            }

            foreach (double K in lst)
            {
                if (K != 0)
                {
                    for (int i = 0; i < SamplesToAnalise; i++)
                    {
                        if (average[i] == K)
                        {
                            PressureChart2.Titles["Title1"].Text = "PEAK";
                            PressureChart2.Series["Pressure1"].Color = Color.Brown;
                            PressureChart2.ChartAreas[0].AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);
                            PressureChart2.Series["Pressure1"].Points.AddXY(time[i], average[i]);
                        }
                    }
                }
              //  MessageBox.Show("THRESHOLD: " + K + " number: " + number);
            }

            // HEART RATE
            int notR = 0; ;
            for (int i = 0; i < number - 1; i++)
            {
                if (lst[i] == 0)
                {
                    notR++;                 
                }
            }
            int R = number - notR;
            double perMinute = 60 / Math.Round(time[SamplesToAnalise - 1]);
            double HeartRate = R * perMinute;
            HeartRateLabel.Text = HeartRate + " bpm";
        }
    }
}
