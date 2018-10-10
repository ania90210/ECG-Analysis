using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static Application.LowPassFilter;

namespace Application
{
    public partial class Application : Form
    {
        double[] time = new double[40000];
        double[] amplitude = new double[40000];
        double Fs = 400;
        double[] valueY = new double[40000];
        double[] valueXp1 = new double[4000];
        double[] valueYp1 = new double[0000];
        int counter;

        public Application()
        {
            InitializeComponent();
            // empty chart
        }

        private void Application_Load(object sender, EventArgs e)
        {

        }

        private void OpenFileButton_Click_1(object sender, EventArgs e)
        {
            string fileName = null;

                using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "C:\\Users\\Ania\\Desktop\\Inzynierka";
                ofd.Filter = "Zwyk³y tekst (*.txt)|*.txt";
                ofd.FilterIndex = 2;//?
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;                   
                }
            }

            if (fileName != null) // if everything is OK
            {
                string[] lines = File.ReadAllLines(fileName);
                counter = File.ReadLines(fileName).Count();
                decimal decX, decY;

                for (int i = 0; i < 450; i++)
                {                                      
                    Decimal.TryParse(lines[i], NumberStyles.Any, CultureInfo.InvariantCulture, out decY);                  
                    valueY[i] = decimal.ToDouble(decY);
                    double Ts = 1 / Fs;
                    if (i == 0)
                    {
                        amplitude[i] = valueY[i]/2;
                        time[i] = Ts;
                    }
                    else {
                        amplitude[i] = (valueY[i] + valueY[i - 1])/2;
                        time[i] = (i+1)*Ts;
                    }
                    
                    /*string[] XY = lines[i].Split(',');

                    Decimal.TryParse(XY[0], NumberStyles.Any, CultureInfo.InvariantCulture, out decX);
                    valueX[i] = decimal.ToDouble(decX);

                    Decimal.TryParse(XY[1], NumberStyles.Any, CultureInfo.InvariantCulture, out decY);
                    valueY[i] = decimal.ToDouble(decY);*/

                    //valueXp1[i] = double.Parse(XY[2]);
                    //valueYp1[i] = double.Parse(XY[3]); 
                }

                // do charts
                //MessageBox.Show("time: "  + time.Length);
                var chart = this.EKGchart.ChartAreas[0];                 
                var chartP = PressureChart1.ChartAreas[0];
                chartP.AxisX.Title = "Hz";
                chartP.AxisY.Title = "Pressure";

                // EKG chart
                if (this.EKGchart.Series.IndexOf("EKG") != -1) // if it exists
                {
                    foreach (var series in EKGchart.Series)
                    {
                        series.Points.Clear(); // clear chart
                    }
                    chart.AxisX.Minimum = 0;
                    chart.AxisX.Maximum = Math.Round(time[450 - 1]);
                    //chart.AxisY.Minimum = -200;                
                    //chart.AxisY.Maximum = 200;

                    this.EKGchart.Series["EKG"].ChartType = SeriesChartType.Spline;
                    this.EKGchart.Series["EKG"].Color = Color.Red;

                    for (int i = 0; i < 450; i++)
                    {
                        this.EKGchart.Series["EKG"].Points.AddXY(time[i], amplitude[i]);
                    }
                }
                else
                {
                    MessageBox.Show("brak wykresu");
                    this.EKGchart.Series.Add("EKG");
                }

                // Pillow I chart
                /*
                if (PressureChart1.Series.IndexOf("Pressure1") != -1) //if exists
                {
                    foreach (var series in PressureChart1.Series)
                    {
                        series.Points.Clear(); // clear chart
                    }
                    PressureChart1.Series["Pressure1"].ChartType = SeriesChartType.Spline;
                    PressureChart1.Series["Pressure1"].Color = Color.Blue;

                    for (int i = 0; i < counter; i++)
                    {
                        PressureChart1.Series["Pressure1"].Points.AddXY(valueXp1[i], valueYp1[i]);
                    }
                }
                else
                {
                    MessageBox.Show("brak wykresu Pressure1");
                    PressureChart1.Series.Add("Pressure1");//
                }
                */
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void QRSdetection()
        {
            int Rcounter = 0;

            for (int i = 0; i < counter; i++)
            {
                if (valueY[i] > 0.65 && valueY[i-1] <= 0.65)
                {   
                        Rcounter++;                  
                }
            }
            int HR = Rcounter * 6;
            HeartRateLabel.Text = HR + " bpm";
        }

        private void Start_Click(object sender, EventArgs e)
        {
            QRSdetection();
            valueYp1 = Butterworth(amplitude, Fs, 20, "LOW");

            PressureChart1.Series["Pressure1"].ChartType = SeriesChartType.Spline;
            PressureChart1.Series["Pressure1"].Color = Color.Blue;
            PressureChart1.ChartAreas[0].AxisX.Maximum = Math.Round(time[450 - 1]);

            for (int i = 0; i < 450; i++)
            {
                PressureChart1.Series["Pressure1"].Points.AddXY(time[i], valueYp1[i]);
            }
        }

        public static double[] Butterworth(double[] indata, double sampleRate, double frequency, string HL)
        {

            if (indata == null) return null;
            if (frequency == 0) return indata;

            long dF2 = indata.Length - 1;        // The data range is set with dF2
            double[] Dat2 = new double[dF2 + 4]; // Array with 4 extra points front and back // INPUT
            double[] data = indata; // Ptr., changes passed data

            // Copy indata to Dat2
            for (long r = 0; r < dF2; r++)
            {
                Dat2[2 + r] = indata[r];
            }
            Dat2[1] = Dat2[0] = indata[0];
            Dat2[dF2 + 3] = Dat2[dF2 + 2] = indata[dF2];

            //const double pi = 3.14159265358979;
            double wc = Math.Tan(frequency * Math.PI / sampleRate);
            double k1 = 1.414213562 * wc; // Sqrt(2) * wc
            double k2 = wc * wc;
            double a = k2 / (1 + k1 + k2);
            double b = 2 * a;
            double c = a;
            double k3 = b / k2;
            double d = -2 * a + k3;
            double e = 1 - (2 * a) - k3;

            // HIGH PASS
            double cHIGH = Math.Tan(Math.PI * frequency / sampleRate);//
            double a1 = 1 / (1 + 1.414213562 * cHIGH + cHIGH * cHIGH);//
            double a2 = -2 * a1;
            double a3 = a1;
            double b1 = 2 * (cHIGH * cHIGH - 1) * a1;
            double b2 = (1 - 1.414213562 * cHIGH + cHIGH * cHIGH) * a1;

            // RECURSIVE TRIGGERS - ENABLE filter is performed (first, last points constant)
            double[] DatYt = new double[dF2 + 4]; //OUTPUT
            DatYt[1] = DatYt[0] = indata[0];
            for (long s = 2; s < dF2 + 2; s++)
            {
                if (HL == "LOW")
                {
                    DatYt[s] = a * Dat2[s] + b * Dat2[s - 1] + c * Dat2[s - 2]
                               + d * DatYt[s - 1] + e * DatYt[s - 2];
                }
                if (HL == "HIGH")
                {
                    DatYt[s] = a * Dat2[s] + b * Dat2[s - 1] + c * Dat2[s - 2]
                               + d * DatYt[s - 1] + e * DatYt[s - 2];
                }
            }
            DatYt[dF2 + 3] = DatYt[dF2 + 2] = DatYt[dF2 + 1];

            // FORWARD filter
            double[] DatZt = new double[dF2 + 2];
            DatZt[dF2] = DatYt[dF2 + 2];
            DatZt[dF2 + 1] = DatYt[dF2 + 3];
            for (long t = -dF2 + 1; t <= 0; t++)
            {
                if (HL == "LOW")
                {
                    DatZt[-t] = a * DatYt[-t + 2] + b * DatYt[-t + 3] + c * DatYt[-t + 4]
                            + d * DatZt[-t + 1] + e * DatZt[-t + 2];
                }
                if (HL == "HIGH")
                {
                    DatZt[-t] = a1 * DatYt[-t + 2] + a2 * DatYt[-t + 3] + a3 * DatYt[-t + 4]
                            + b1 * DatZt[-t + 1] + b2 * DatZt[-t + 2];
                }
            }
            bool equals = DatZt.SequenceEqual(DatYt);
            // Calculated points copied for return
            for (long p = 0; p < dF2; p++)
            {
                data[p] = DatZt[p]; //Y
            }
            
            MessageBox.Show("dd: " + DatYt[400] + " hh: " + DatZt[0]); // NaN
            return data;         
        }
    }
}
