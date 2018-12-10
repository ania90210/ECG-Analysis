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
        public List<double> checkPillow(List<double> Pressure, List<double> timeP, int SamplesToAnalise, double Fs, int Window)
        {
            List<double> resultsSD = new List<double>();

            int y = 0;
            int x = 1;
            double numberOfWindows = (SamplesToAnalise / Fs) / Window;
            double RoundWindow = Math.Floor(numberOfWindows); ;
            for (int i = 0; i < RoundWindow; i++)
            {
                resultsSD.Add(standardDeviation(Pressure, timeP, Window, x, y));
                y++;
                x++;
            }

            return resultsSD;
        }

        private double standardDeviation(List<double> Pressure, List<double> time, int Window, int x, int y) 
        {
            List<double> pressureValues = new List<double>();
            double sum = 0;
            double MeanValue = 0;
            double numerator = 0;
            double standardDeviation = 0;

            for (int i = time.FindIndex(w => w == y * Window); i <= time.FindIndex(w => w == x * Window); i=i+50)
            {
                pressureValues.Add(Pressure[i]);
                sum = sum + Pressure[i];
            }
            MeanValue = sum / pressureValues.Count();
            numerator = pressureValues.Select(w => (w - MeanValue) * (w - MeanValue)).Sum();
            standardDeviation = Math.Sqrt(numerator / pressureValues.Count());
            Console.WriteLine("MeanValue " + MeanValue + " numerator " + numerator);
            return standardDeviation;
        }
    }
}
