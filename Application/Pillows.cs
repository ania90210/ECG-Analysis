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
        List<double> resultsSD = new List<double>();

        public List<double> checkPillow(List<double> Pressure, List<double> timeP, int SamplesToAnalise, double Fs, int Window)
        {           
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

        private double standardDeviation(List<double> Pressure, List<double> timeP, int Window, int x, int y) 
        {
            double MeanValue = 10;
            double sum = 0;
            double sd = 0;
            List<double> standardD = new List<double>();

            for (int i = timeP.FindIndex(w => w == y * Window); i <= timeP.FindIndex(w => w == x * Window); i=i+50)
            {
                standardD.Add(Pressure[i]);
            }
            sum = standardD.Select(w => (w - MeanValue) * (w - MeanValue)).Sum();
            sd = Math.Sqrt(sum / (standardD.Count() - 1));
            return sd;
        }
    }
}
