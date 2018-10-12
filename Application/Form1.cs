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

namespace Application
{
    public partial class Application : Form
    {
        double[] time = new double[40000];
        double[] amplitude = new double[40000];
        double Fs = 400;
        double[] valueY = new double[40000];
        double[] valueXp1 = new double[4000];
        double[] valueYp1 = new double[40000];
        double[] lowFilter = new double[40000];
        double[] highFilter = new double[40000];
        double[] highoriginal = new double[40000];
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
            //MessageBox.Show("brak wykresu Pressure1");
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
                decimal decY;

                for (int i = 0; i < 2000; i++)
                {                                      
                    Decimal.TryParse(lines[i], NumberStyles.Any, CultureInfo.InvariantCulture, out decY);                  
                    valueY[i] = decimal.ToDouble(decY);
                    double Ts = 1 / Fs;
                    if (i == 0)
                    {
                        amplitude[i] = valueY[i]/100;
                        time[i] = Ts;
                    }
                    else {
                        amplitude[i] = (valueY[i] + valueY[i - 1])/100;
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
               // MessageBox.Show("time: "  + time.Length + "time[i]" + time[3000]);
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
                    chart.AxisX.Maximum = Math.Round(time[2000 - 1]);

                    this.EKGchart.Series["EKG"].ChartType = SeriesChartType.Spline;
                    this.EKGchart.Series["EKG"].Color = Color.Red;

                    for (int i = 0; i < 2000; i++)
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

            lowFilter = PanTompkins.Butterworth(amplitude, Fs, "LOW");
            /*
            PressureChart1.Titles["Title1"].Text = "Low Filter";
            PressureChart1.Series["Pressure1"].ChartType = SeriesChartType.Spline;
            PressureChart1.Series["Pressure1"].Color = Color.Blue;
            PressureChart1.ChartAreas[0].AxisX.Maximum = Math.Round(time[2000 - 1]);

            for (int i = 0; i < 2000; i++)
            {
                PressureChart1.Series["Pressure1"].Points.AddXY(time[i], lowFilter[i]);
            }*/

            highFilter = PanTompkins.Butterworth(amplitude, Fs, "HIGH");
            highoriginal = PanTompkins.Butterworth(lowFilter, Fs, "HIGH");

            /*PressureChart2.Titles["Title1"].Text = "High Filter from Low Filter";
            PressureChart2.Series["Pressure1"].ChartType = SeriesChartType.Spline;
            PressureChart2.Series["Pressure1"].Color = Color.Brown;
            PressureChart2.ChartAreas[0].AxisX.Maximum = Math.Round(time[2000 - 1]);
            for (int i = 0; i < 2000; i++)
            {
                PressureChart2.Series["Pressure1"].Points.AddXY(time[i], highoriginal[i]);
            }*/
/*
            PressureChart3.Titles["Title1"].Text = "Low Filter * High Filter(from original)";
            PressureChart3.Series["Pressure1"].ChartType = SeriesChartType.Spline;
            PressureChart3.Series["Pressure1"].Color = Color.Green;
            PressureChart3.ChartAreas[0].AxisX.Maximum = Math.Round(time[2000 - 1]);
          
            for (int i = 0; i < 2000; i++)
            {
                PressureChart3.Series["Pressure1"].Points.AddXY(time[i], lowFilter[i]* highFilter[i]);
            }*/

            // DERIVATIVE
            double[] derivative = new double[40000];

            for (int i = 0; i < 2000; i++)
            {
                derivative[i] = (highoriginal[i + 1] - highoriginal[i]) / (time[i + 1] - time[i]);
            }

            PressureChart1.Titles["Title1"].Text = "DERIVATIVE";
            PressureChart1.Series["Pressure1"].ChartType = SeriesChartType.Spline;
            PressureChart1.Series["Pressure1"].Color = Color.Blue;
            PressureChart1.ChartAreas[0].AxisX.Maximum = Math.Round(time[2000 - 1]);

            for (int i = 0; i < 2000; i++)
            {
                PressureChart1.Series["Pressure1"].Points.AddXY(time[i], derivative[i]);
            }

            // SQUARE
            double[] square = new double[40000];
            for (int i = 0; i < 2000; i++)
            {
                square[i] = derivative[i] * derivative[i];
            }
            PressureChart3.Titles["Title1"].Text = "SQUARE";
            for (int i = 0; i < 2000; i++)
            {
                PressureChart3.Series["Pressure1"].Points.AddXY(time[i], square[i]);
            }

            //MOVING AVERAGE FILTER
            double[] average = new double[40000];           
            for (int j = 59; j < 2000; j++)
            {
                double sum = 0;
                for (int i = 0; i < 60; i++)
                {
                    sum += square[j - (60 - (i + 1))];
                }

                average[j-59] = sum / 60;                            
            }

            chart4.Titles["Title1"].Text = "MOVING AVERAGE FILTER";
            chart4.Series["Series1"].ChartType = SeriesChartType.Spline;
            chart4.Series["Series1"].Color = Color.DeepPink;
            chart4.ChartAreas[0].AxisX.Maximum = Math.Round(time[2000 - 1]);
            for (int i = 0; i < 2000; i++)
            {
                chart4.Series["Series1"].Points.AddXY(time[i], average[i]);
            }

            //PEAK
            double[] first300 = new double[300];           
            double[] rrrr = new double[300];
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

            for (int i = 0; i < 2000; i++)
            {
                if (average[i] > THRESHOLD)
                {
                    first[i] = average[i];

                    if(average[i + 1] < THRESHOLD)
                    {
                        lst.Add(first.Max());
                        Array.Clear(first, 0, first.Length);
                    }
                }              
            }

            int number = lst.Count;
            foreach(double K in lst)
            {
                for (int i = 0; i < 2000; i++)
                {
                    if(average[i] == K)
                    {
                        PressureChart2.Titles["Title1"].Text = "High Filter from Low Filter";
            PressureChart2.Series["Pressure1"].Color = Color.Brown;
            PressureChart2.ChartAreas[0].AxisX.Maximum = Math.Round(time[2000 - 1]);
                        PressureChart2.Series["Pressure1"].Points.AddXY(time[i], average[i]);
                    }
                }
            }
                MessageBox.Show("THRESHOLD: " + THRESHOLD + "number: " + number);
           
        }
    }
}
/*
for (long s = 2; s < dF2 + 2; s++)
            {
                if (HL == "LOW")
                {
                    DatYt[s] = a * Dat2[s] + b * Dat2[s - 1] + c * Dat2[s - 2]
                               + d * DatYt[s - 1] + e * DatYt[s - 2];
                }
                if (HL == "HIGH")
                {
                    DatYt[s] = a1 * Dat2[s] + a2 * Dat2[s - 1] + a3 * Dat2[s - 2]
                               + b1 * DatYt[s - 1] + b2 * DatYt[s - 2];
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
            */
