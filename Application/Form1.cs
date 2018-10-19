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
        int SamplesToAnalise = 8000;
        int Window = 10;
        double[] valueY = new double[40000];
        double[] valueXp1 = new double[40000];
        double[] valueYp1 = new double[40000];
        int counter;

        public Application()
        {
            InitializeComponent();
            // empty chart
            var header1 = listView1.Columns.Add("Window", -2, HorizontalAlignment.Left);
            var header2 = listView1.Columns.Add("Heart Rate", -2, HorizontalAlignment.Center);
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
                decimal decY;

                for (int i = 0; i < SamplesToAnalise; i++)
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
                    chart.AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);

                    this.EKGchart.Series["EKG"].ChartType = SeriesChartType.Spline;
                    this.EKGchart.Series["EKG"].Color = Color.Red;

                    for (int i = 0; i < SamplesToAnalise; i++)
                    {
                        this.EKGchart.Series["EKG"].Points.AddXY(time[i], amplitude[i]);
                    }
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

        private void Start_Click(object sender, EventArgs e)
        {
            PanTompkins PanT = new PanTompkins();
            PanT.PanTompkinsAlgorithm(amplitude, Fs, time, SamplesToAnalise, PressureChart1, PressureChart2, PressureChart3, chart4, HeartRateLabel, Window, listView1);           
        }

        private void WindowLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            Window = int.Parse(WindowLength.SelectedItem.ToString());
        }
    } 
}
/*
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
