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
    class Pillows
    {
        public List<double> checkPillow(double[] Pressure, double[] timeP, int SamplesToAnalise, double Fs, int Window)
        {
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            if (!watch.IsRunning)
                watch.Restart();
            List<double> resultsSD = new List<double>();
            int y = 0;
            int x = 1;
            double numberOfWindows = (SamplesToAnalise / Fs) / Window;
            double RoundWindow = Math.Floor(numberOfWindows);;
            for (int i = 0; i < RoundWindow; i++)
            {
                resultsSD.Add(standardDerivative(Pressure, timeP, Window, x, y));
                y++;
                x++;
            }
            watch.Stop();
            Console.WriteLine($"checkPillow Execution Time: {watch.ElapsedMilliseconds} ms");
            return resultsSD;
        }

        public double standardDerivative(double[] Pressure, double[] timeP, int Window, int x, int y) // nazwa
        {
            double value = 0; // arytmeycna
            double MeanValue = 0;
            double sum = 0;
            double sd = 0;
            //int sampleRate = 10;
            List<double> standardD = new List<double>();

            for (int i = Array.FindIndex(timeP, w => w == y * Window); i <= Array.FindIndex(timeP, w => w == x * Window); i++)
            {
                standardD.Add(Pressure[i]);
                value = value + Pressure[i];
            }
            MeanValue = value / standardD.Count();
            Console.WriteLine("MeanValue " + MeanValue);
            sum = standardD.Select(w => (w - MeanValue) * (w - MeanValue)).Sum();
            sd = Math.Sqrt(sum / (standardD.Count() - 1));//(Window * sampleRate - 1)); // ?????????????????
            return sd;
        }
    }
}
