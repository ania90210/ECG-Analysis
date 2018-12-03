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
        static int SamplesToAnalise = 90000; //1000 //8000/ 20000 /21600 /45000 ;
        static int PressureNumber = 100; //120 /100
        double[] time = new double[SamplesToAnalise + 5];
        double[] amplitude = new double[SamplesToAnalise + 5];
        double Fs = 4500;//100//400//4500 //360;  
        int Window = 5;
        //  double[] valueY = new double[SamplesToAnalise + 5];
        StripLine stripline1 = new StripLine();
        StripLine stripline2 = new StripLine();
        double[] Pressure1 = new double[PressureNumber + 5];
        double[] timeP1 = new double[PressureNumber + 5];

        double[] Pressure2 = new double[PressureNumber + 5];
        double[] timeP2 = new double[PressureNumber + 5];

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
                ofd.InitialDirectory = "C:\\Users\\Ania\\Desktop\\Inzynierka";//Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ofd.Filter = "TXT (*.txt)|*.txt";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    EKGchart.Series["EKG"].Points.Clear(); // clear chart
                    EKGchart.Series["Peaks"].Points.Clear();
                    PressureChart1.Series["Pressure1"].Points.Clear(); // clear chart
                    PressureChart2.Series["Pressure1"].Points.Clear(); // clear chart
                    listView1.Items.Clear();
                    string line1 = File.ReadLines(fileName).First();
                    if (line1 != "eKrzeslo")
                    {
                        fileName = null;
                        MessageBox.Show("Wybrano nieprawid³owy plik");
                    }
                }
            }

            if (fileName != null) // if everything is OK
            {
                string[] lines = File.ReadAllLines(fileName);
                for (int i = 1; i <= SamplesToAnalise; i++)
                {
                    // dodane
                    //  Decimal.TryParse(lines[i], NumberStyles.Any, CultureInfo.InvariantCulture, out decY);
                    //valueY[i] = decimal.ToDouble(decY);
                    lines[i] = lines[i].Replace('.', ',');

                    //dodane
                    string[] column = lines[i].Split(' ', '\t');
                    amplitude[i-1] = Double.Parse(column[0]);


                    //amplitude[i] = Double.Parse(lines[i]);
                    double Ts = 1 / Fs;
                    time[i-1] = (i-1) * Ts;
                    time[SamplesToAnalise - 1] = Math.Round(time[SamplesToAnalise - 1]);
                }
                // EKG chart
                var chart = EKGchart.ChartAreas[0];
                chart.AxisX.Minimum = 0;
                chart.AxisX.Maximum = Math.Round(time[SamplesToAnalise-1]);
                chart.AxisX.Interval = 1;
                chart.AxisX.IntervalOffset = 0;
                EKGchart.Series["EKG"].Color = Color.Red;
                EKGchart.Series[0].ChartType = SeriesChartType.FastLine;

                chart.AxisX.LabelStyle.Format = "#";
                // chart.AxisX.ScaleView.Zoomable = true;
                //  chart.CursorX.Interval = 5;
                //  chart.CursorX.IntervalOffset = 0;
                /*   chart.AxisX.ScrollBar.Axis.Maximum = 5;
                   chart.AxisX.ScrollBar.ChartArea.CursorX.IntervalOffset = 5;
                   chart.AxisX.ScrollBar.ChartArea.AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);
                   chart.AxisX.ScrollBar.ChartArea.AxisX.Minimum = 0;
                   chart.AxisX.ScrollBar.ChartArea.AxisX.Interval = 5;*/
                // chart.AxisX.ScrollBar.Axis.IntervalOffset = 0;
                //   chart.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;

                chart.AxisX.ScaleView.Zoom(0, 11);

                chart.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
                chart.AxisX.ScaleView.SmallScrollSize = 5;
                
                for (int i = 0; i < SamplesToAnalise; i++)
                {
                    this.EKGchart.Series["EKG"].Points.AddXY(time[i], amplitude[i]);
                    if (time[i] % Window == 0)
                    {
                        VerticalLineAnnotation VA;
                        VA = new VerticalLineAnnotation();
                        VA.AxisX = chart.AxisX;
                        VA.AllowMoving = false;
                        VA.Visible = true;
                        VA.AnchorOffsetX = 0;
                        VA.IsInfinitive = true;
                        VA.LineColor = Color.BlueViolet;
                        VA.LineWidth = 1;
                        VA.X = time[i];
                        EKGchart.Annotations.Add(VA);
                    }
                }
                            
                //StripLine("EKG");
                watch.Stop();
                Console.WriteLine($"OpenFileButton_Click_1: {watch.ElapsedMilliseconds} ms");

                //PILLOW I
                //nowe Z KOLUMNAMI
                for (int i = 1; i <= PressureNumber; i++)
                {
                    string[] column = lines[i].Split(' ', '\t');                                      
                    Pressure1[i] = Double.Parse(column[1]);
                    Pressure1[0] = Pressure1[1];
                    double Ts = Math.Round(time[SamplesToAnalise - 1]) / PressureNumber;
                    
                    timeP1[0] = 0;
                    timeP1[i] = i * Ts;
                }

                /* STARE
                for (int i = SamplesToAnalise; i <= SamplesToAnalise + PressureValues; i++) //_1000
                {
                //lines[i] = lines[i].Replace('.', ',');
                 // valueY[i - SamplesToAnalise] = Double.Parse(lines[i]);
                 double Ts = 0.1; // 0.1/ 0.5
                 Pressure1[i- SamplesToAnalise] = Double.Parse(lines[i]); //valueY[i- SamplesToAnalise];
                 timeP1[i- SamplesToAnalise] = (i- SamplesToAnalise) * Ts;
                }
                */
                    var chartP = PressureChart1.ChartAreas[0];                   
                    PressureChart1.Series["Pressure1"].Color = Color.Blue;
                    chartP.AxisY.Minimum = 0;
                    chartP.AxisY.Maximum = 20;
                    chartP.AxisX.Minimum = 0;
                    chartP.AxisX.Interval = 5;
                    chartP.AxisX.Maximum = Math.Round(timeP1[PressureNumber]);
                    for (int i = 0; i <= PressureNumber; i++)
                    {
                        PressureChart1.Series["Pressure1"].Points.AddXY(timeP1[i], Pressure1[i]);
                    }
                //StripLine();

                //PILLOW II
                //nowe Z KOLUMNAMI
                for (int i = 1; i <= PressureNumber; i++)
                {
                    string[] column = lines[i].Split(' ', '\t');
                    Pressure2[i] = Double.Parse(column[2]);
                    Pressure2[0] = Pressure2[1];
                    double Ts = Math.Round(time[SamplesToAnalise - 1]) / PressureNumber;

                    timeP2[0] = 0;
                    timeP2[i] = i * Ts;
                }


                // STARE
               /* for (int i = SamplesToAnalise; i <= SamplesToAnalise + PressureValues; i++) //_1000
                {
                    // lines[i] = lines[i].Replace('.', ',');
                    //valueY[i - SamplesToAnalise - 1000] = Double.Parse(lines[i]);

                    double Ts = 0.1; // 0.1/ 0.5
                    Pressure2[i - SamplesToAnalise] = Double.Parse(lines[i]); //valueY[i - SamplesToAnalise - 1000];
                        timeP2[i - SamplesToAnalise] = (i - SamplesToAnalise) * Ts;
                    }
                    */
                    var chartP2 = PressureChart2.ChartAreas[0];
                    PressureChart2.Series["Pressure1"].Color = Color.Blue;
                chartP2.AxisY.Minimum = 0;
                chartP2.AxisY.Maximum = 20;
                chartP2.AxisX.Minimum = 0;
                chartP2.AxisX.Interval = 5;
                chartP2.AxisX.Maximum = Math.Round(timeP2[PressureNumber]);

                    for (int i = 0; i <= PressureNumber; i++)
                    {
                        PressureChart2.Series["Pressure1"].Points.AddXY(timeP2[i], Pressure2[i]);
                    }
                StripLine("Pressure");
            }
        }
        public void StripLine(string chart)
        {
            if (chart == "Pressure")
            {
                stripline1.Interval = Window;
                stripline1.IntervalOffset = Window;
                stripline1.StripWidth = 0.05;
                stripline1.BackColor = Color.BlueViolet;
                PressureChart1.ChartAreas[0].AxisX.StripLines.Add(stripline1);
                PressureChart2.ChartAreas[0].AxisX.StripLines.Add(stripline1);
            }
            else if (chart == "EKG")
            {
                stripline2.Interval = Window;
                stripline2.IntervalOffset = Window;
                stripline2.StripWidth = 0.04;
                stripline2.BackColor = Color.BlueViolet;
              this.EKGchart.ChartAreas[0].AxisX.StripLines.Add(stripline2);
            }
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
                    resultsPillow1 = pillow.checkPillow(Pressure1, timeP1, SamplesToAnalise, Fs, Window);
                    foreach (double n in resultsPillow1) {
                        Console.WriteLine(" pillow1: " + n);
                    }
                    resultsPillow2 = pillow.checkPillow(Pressure2, timeP2, SamplesToAnalise, Fs, Window);
                    foreach (double n in resultsPillow2)
                    {
                        Console.WriteLine(" pillow 2: " + n);
                    }
                    
                PanTompkins PanT = new PanTompkins();
                resultsECG = PanT.PanTompkinsAlgorithm(amplitude, Fs, time, SamplesToAnalise, this.EKGchart, PressureChart2, PressureChart3, chart4, Window, listView1);
                foreach (double n in resultsECG)
                {
                    Console.WriteLine(" resultsECG: " + n);
                }
                FinalResults FR = new FinalResults();
                FR.FinalResult(resultsPillow1, resultsPillow2, resultsECG, listView1, Window);
                watch.Stop();
                Console.WriteLine($"Po calym Start_Click Execution Time: {watch.ElapsedMilliseconds} ms");
            }
        }

        private void WindowLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            Window = int.Parse(WindowLength.SelectedItem.ToString());
           
            StripLine("EKG");
            StripLine("Pressure");
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