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
        private bool buttonWasClicked = false;
        static int SamplesToAnalise = 45000; //1000 //8000/ 20000 /21600 /45000 ;
        static int PressureValues = 100; //120 /100
        double[] time = new double[SamplesToAnalise + 5];
        double[] amplitude = new double[SamplesToAnalise + 5];
        double Fs = 4500;//100//400//4500 //360;     
        int Window = 5;
        //  double[] valueY = new double[SamplesToAnalise + 5];
        StripLine stripline1 = new StripLine();
        double[] Pressure1 = new double[PressureValues+5];
        double[] timeP1 = new double[PressureValues+5];

        double[] Pressure2 = new double[PressureValues + 5];
        double[] timeP2 = new double[PressureValues+5];

        double[] valueXp1 = new double[10000];
        double[] valueYp1 = new double[10000];

        System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

        public Application()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            // empty chart
        }

        private void Application_Load(object sender, EventArgs e)
        {
        }

        private void OpenFileButton_Click_1(object sender, EventArgs e)
        {
            buttonWasClicked = true;
            string fileName = null;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Wybierz plik do analizy";
                ofd.InitialDirectory = "C:\\Users\\Ania\\Desktop\\Inzynierka";
                ofd.Filter = "TXT (*.txt)|*.txt";
                ofd.FilterIndex = 2;//?
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    EKGchart.Series["EKG"].Points.Clear(); // clear chart
                }
            }

            if (fileName != null) // if everything is OK
            {
                string[] lines = File.ReadAllLines(fileName);
                for (int i = 0; i < SamplesToAnalise; i++)
                {
                    //  Decimal.TryParse(lines[i], NumberStyles.Any, CultureInfo.InvariantCulture, out decY);
                    //valueY[i] = decimal.ToDouble(decY);
                    lines[i] = lines[i].Replace('.', ',');
                    amplitude[i] = Double.Parse(lines[i]);
                    double Ts = 1 / Fs;
                    if (i == 0)
                    {
                        /*  amplitude[i] = valueY[i]/100;
                          time[i] = Ts;*/
                   //     amplitude[i] = valueY[i];
                        time[i] = 0;
                    }
                    else
                    {
                        /* amplitude[i] = (valueY[i] + valueY[i - 1])/100;
                         time[i] = (i+1)*Ts; */
                      //  amplitude[i] = valueY[i];
                        time[i] = i * Ts;
                    }
                }
                // EKG chart
                var chart = this.EKGchart.ChartAreas[0];
                chart.AxisX.Minimum = 0;
                chart.AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);
                chart.AxisX.Interval = 5;
                this.EKGchart.Series["EKG"].Color = Color.Red;

                for (int i = 0; i < SamplesToAnalise; i++)
                {
                    this.EKGchart.Series["EKG"].Points.AddXY(time[i], amplitude[i]);
                }
                listView1.Items.Clear();              
                StripLine();
                watch.Stop();
                Console.WriteLine($"OpenFileButton_Click_1: {watch.ElapsedMilliseconds} ms");

                //PILLOW I
                for (int i = SamplesToAnalise; i <= SamplesToAnalise + PressureValues; i++) //_1000
                {
                //lines[i] = lines[i].Replace('.', ',');
                 // valueY[i - SamplesToAnalise] = Double.Parse(lines[i]);
                 double Ts = 0.1; // 0.1/ 0.5
                 Pressure1[i- SamplesToAnalise] = Double.Parse(lines[i]); //valueY[i- SamplesToAnalise];
                 timeP1[i- SamplesToAnalise] = (i- SamplesToAnalise) * Ts;
                }
                    var chartP = PressureChart1.ChartAreas[0];
                    PressureChart1.Series["Pressure1"].Points.Clear(); // clear chart
                    PressureChart1.Series["Pressure1"].Color = Color.Blue;
                    chartP.AxisY.Minimum = 0;
                    chartP.AxisY.Maximum = 20;
                    chartP.AxisX.Minimum = 0;
                    chartP.AxisX.Interval = 5;
                    chartP.AxisX.Maximum = Math.Round(timeP1[PressureValues - 1]);
               
                    for (int i = 0; i <= PressureValues; i++)
                    {
                        PressureChart1.Series["Pressure1"].Points.AddXY(timeP1[i], Pressure1[i]);
                    }
                //StripLine();

                //PILLOW II
                // for (int i = SamplesToAnalise + 1000; i < SamplesToAnalise + 2000; i++)
                for (int i = SamplesToAnalise; i <= SamplesToAnalise + PressureValues; i++) //_1000
                {
                    // lines[i] = lines[i].Replace('.', ',');
                    //valueY[i - SamplesToAnalise - 1000] = Double.Parse(lines[i]);
                    double Ts = 0.1; // 0.1/ 0.5
                    Pressure2[i - SamplesToAnalise] = Double.Parse(lines[i]); //valueY[i - SamplesToAnalise - 1000];
                        timeP2[i - SamplesToAnalise] = (i - SamplesToAnalise) * Ts;
                    }

                    var chartP2 = PressureChart2.ChartAreas[0];
                    PressureChart2.Series["Pressure1"].Points.Clear(); // clear chart
                    PressureChart2.Series["Pressure1"].Color = Color.Blue;
                chartP2.AxisY.Minimum = 0;
                chartP2.AxisY.Maximum = 20;
                chartP2.AxisX.Minimum = 0;
                chartP2.AxisX.Interval = 5;
                chartP2.AxisX.Maximum = Math.Round(timeP2[PressureValues - 1]);

                    for (int i = 0; i <= PressureValues; i++)
                    {
                        PressureChart2.Series["Pressure1"].Points.AddXY(timeP2[i], Pressure2[i]);
                    }                    
            }
        }
        public void StripLine()
        {
            if (!watch.IsRunning)
                watch.Restart();
            stripline1.Interval = Window - 0.02;
            stripline1.IntervalOffset = Window;
            stripline1.StripWidth = 0.05;
            stripline1.BackColor = Color.PaleGreen;
            this.EKGchart.ChartAreas[0].AxisX.StripLines.Add(stripline1);
            /*
            StripLine stripline = new StripLine();
            stripline.Interval = x;
            stripline.IntervalOffset = x - 0.02;
            stripline.StripWidth = 0.05;
            stripline.BackColor = Color.DarkBlue;
            chart.AxisX.StripLines.Add(stripline);*/
            watch.Stop();
            Console.WriteLine($"Po calym Start_Click Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (!watch.IsRunning)
                watch.Restart();
            if (buttonWasClicked == false)
            {
                MessageBox.Show("Najpierw wybierz folder");
            }
            if (Window > SamplesToAnalise / Fs)
            {
                MessageBox.Show("Wybrana wartoœæ okna czasowego jest nieprawid³owa");
            }
            if (buttonWasClicked && Window <= SamplesToAnalise / Fs)
            {
               // StripLine(this.EKGchart.ChartAreas[0], Window);
              //  StripLine(PressureChart1.ChartAreas[0], Window);
               // PressureChart2.Series["Pressure1"].Points.Clear();
                PressureChart3.Series["Pressure1"].Points.Clear();
                chart4.Series["Pressure1"].Points.Clear();
                listView1.Items.Clear();

                List<double> resultsPillow1 = new List<double>();
                List<double> resultsPillow2 = new List<double>();
                List<double> resultsECG = new List<double>();



                  Pillows pillow = new Pillows();
                    resultsPillow1 = pillow.checkPillow(Pressure1, SamplesToAnalise, Fs, Window);
                    foreach (double n in resultsPillow1) {
                        Console.WriteLine(" pillow1: " + n);
                    }
                    resultsPillow2 = pillow.checkPillow(Pressure2, SamplesToAnalise, Fs, Window);
                    foreach (double n in resultsPillow2)
                    {
                        Console.WriteLine(" pillow 2: " + n);
                    }
                    
                PanTompkins PanT = new PanTompkins();
                resultsECG = PanT.PanTompkinsAlgorithm(amplitude, Fs, time, SamplesToAnalise, PressureChart1, PressureChart2, PressureChart3, chart4, Window, listView1);
                foreach (double n in resultsECG)
                {
                    Console.WriteLine(" resultsECG: " + n);
                }
                FinalResults FR = new FinalResults();
                FR.FinalResult(resultsPillow1, resultsPillow2, resultsECG, listView1, Window);
              //  FinalResult(resultsPillow1, resultsECG, listView1, Window);
                watch.Stop();
                Console.WriteLine($"Po calym Start_Click Execution Time: {watch.ElapsedMilliseconds} ms");
            }
        }

        private void WindowLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            Window = int.Parse(WindowLength.SelectedItem.ToString());
           
            StripLine();
            //  StripLine(PressureChart1.ChartAreas[0], Window);
           /* stripline.Interval = 0;
            stripline.IntervalOffset = 5; //- 0.02;
            stripline.StripWidth = 0.09;
            stripline.BackColor = Color.Yellow;
            this.EKGchart.ChartAreas[0].AxisX.StripLines.Add(stripline);*/

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveResults sr = new SaveResults();
            sr.Save(listView1, EKGchart);
        }
    } 
}