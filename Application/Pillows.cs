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
        public List<double> checkPillow(double[] Pressure, int SamplesToAnalise, double Fs, int Window)
        {
            List<double> resultsSD = new List<double>();
            int y = 0;
            int x = 1;
            double numberOfWindows = (SamplesToAnalise / Fs) / Window;
            double RoundWindow = Math.Round(numberOfWindows);

            for (int i = 0; i < RoundWindow; i++)
            {
                resultsSD.Add(standardDerivative(Pressure, SamplesToAnalise, Fs, Window, x, y));
                y++;
                x++;
            }
            return resultsSD;
        }

        public double standardDerivative(double[] Pressure, int SamplesToAnalise, double Fs, int Window, int x, int y)
        {
            double MeanValue = 10;
            double sum = 0;
            double sd = 0;
            int sampleRate = (int)Fs;
            List<double> standardD = new List<double>();
            for (int i = y * Window * sampleRate; i < x * Window * sampleRate; i++)
            {
                standardD.Add(Pressure[i]);               
            }
            sum = standardD.Select(value => (value - MeanValue) * (value - MeanValue)).Sum();
            sd = Math.Sqrt(sum / (Window * sampleRate - 1));
            return sd;
           // MessageBox.Show("standard deviation " + sd + "od " + y * Window + " do " + x * Window);
        }
    }
}
