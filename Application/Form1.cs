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
        bool buttonOpenFileClicked = false;
        bool buttonAnaliseClicked = false;
        static int SamplesToAnalise = 45000; //1000 //8000/ 20000 /21600 /45000 ;
        static int PressureSamples = 45000; //120 /100
        double[] time = new double[SamplesToAnalise + 5];
        double[] amplitude = new double[SamplesToAnalise + 5];
        double Fs = 4500;//100//400//4500 //360;  
        int Window = 5;
        double[] Pressure1 = new double[PressureSamples + 5];
        double[] timeP1 = new double[PressureSamples + 5];

        double[] Pressure2 = new double[PressureSamples + 5];
        double[] timeP2 = new double[PressureSamples + 5];
        System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

        public Application()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void Application_Load(object sender, EventArgs e)
        {
        }

        private void OpenFileButton_Click_1(object sender, EventArgs e)
        {
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
                WindowLength.Enabled = true;
                buttonOpenFileClicked = true;
                string[] lines = File.ReadAllLines(fileName);
                DrawGraphs dg = new DrawGraphs();
                dg.Graphs(Fs, PressureSamples, lines, EKGchart, PressureChart1, PressureChart2, SamplesToAnalise, PressureSamples,
                time, amplitude, Window, Pressure1, timeP1, Pressure2, timeP2);

            }
        }

            
            /* for (int i = 1; i <= SamplesToAnalise; i++)
             {
                 lines[i] = lines[i].Replace('.', ',');
                 string[] column = lines[i].Split(' ', '\t');
                 amplitude[i - 1] = Double.Parse(column[0]);

                 double Ts = 1 / Fs;
                 time[i - 1] = (i - 1) * Ts;
                 time[SamplesToAnalise - 1] = Math.Round(time[SamplesToAnalise - 1]);
             }
             // EKG chart
             var chart = EKGchart.ChartAreas[0];
             chart.AxisX.Minimum = 0;
             chart.AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);
             chart.AxisX.Interval = 1;
             chart.AxisX.IntervalOffset = 0;
             EKGchart.Series["EKG"].Color = Color.Red;
             EKGchart.Series[0].ChartType = SeriesChartType.FastLine;

             chart.AxisX.LabelStyle.Format = "#";
             chart.AxisX.ScaleView.Zoom(0, 11);

             chart.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
             chart.AxisX.ScaleView.SmallScrollSize = 5;
             for (int i = 0; i < SamplesToAnalise; i++)
             {
                 this.EKGchart.Series["EKG"].Points.AddXY(time[i], amplitude[i]);
                 if (time[i] % Window == 0)
                 {
                     VerticalLine(EKGchart, i);
                 }
             }*/


            //PILLOW I
            //nowe Z KOLUMNAMI
            /*for (int i = 1; i <= PressureSamples; i++)
            {
                string[] column = lines[i].Split(' ', '\t');
                Pressure1[i] = Double.Parse(column[1]);
                Pressure1[0] = Pressure1[1];
                double Ts = Math.Round(time[SamplesToAnalise - 1]) / PressureSamples;

                timeP1[0] = 0;
                timeP1[i] = i * Ts;
            }

            
            var chartP = PressureChart1.ChartAreas[0];
            PressureChart1.Series["Pressure1"].Color = Color.Blue;
            chartP.AxisY.Minimum = 0;
            chartP.AxisY.Maximum = 20;
            chartP.AxisX.Minimum = 0;
            chartP.AxisX.Maximum = Math.Round(timeP1[PressureSamples]);
            chartP.AxisX.Interval = 1;
            chartP.AxisX.IntervalOffset = 0;
            chartP.AxisX.ScaleView.Zoom(0, 11);
            chartP.AxisX.LabelStyle.Format = "#";
            Console.WriteLine("imeP1[PressureSamples] " + timeP1[PressureSamples-1]);
            chartP.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartP.AxisX.ScaleView.SmallScrollSize = 5;
            PressureChart1.Series[0].ChartType = SeriesChartType.FastLine;
            
            for (int i = 0; i <= PressureSamples; i++)
            {
                PressureChart1.Series["Pressure1"].Points.AddXY(timeP1[i], Pressure1[i]);
                if (timeP1[i] % Window == 0)
                {
                   VerticalLine(PressureChart1, i);
                }
            }
            */

            //PILLOW II
            //nowe Z KOLUMNAMI
            /*   for (int i = 1; i <= PressureSamples; i++)
               {
                   string[] column = lines[i].Split(' ', '\t');
                   Pressure2[i] = Double.Parse(column[2]);
                   Pressure2[0] = Pressure2[1];
                   double Ts = Math.Round(time[SamplesToAnalise - 1]) / PressureSamples;

                   timeP2[0] = 0;
                   timeP2[i] = i * Ts;
               }

               var chartP2 = PressureChart2.ChartAreas[0];
               PressureChart2.Series["Pressure1"].Color = Color.Blue;
               chartP2.AxisY.Minimum = 0;
               chartP2.AxisY.Maximum = 20;
               chartP2.AxisX.Minimum = 0;
               chartP2.AxisX.Interval = 5;
               chartP2.AxisX.Maximum = Math.Round(timeP2[PressureSamples]);

               chartP2.AxisX.Interval = 1;
               chartP2.AxisX.IntervalOffset = 0;
               chartP2.AxisX.ScaleView.Zoom(0, 11);
               chartP2.AxisX.LabelStyle.Format = "#";

               chartP2.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
               chartP2.AxisX.ScaleView.SmallScrollSize = 5;

               PressureChart2.Series[0].ChartType = SeriesChartType.FastLine;

               for (int i = 0; i <= PressureSamples; i++)
               {
                   PressureChart2.Series["Pressure1"].Points.AddXY(timeP2[i], Pressure2[i]);
                   if (timeP2[i] % Window == 0)
                   {
                       VerticalLine(PressureChart2, i);
                   }
               }*/
        
        private void Start_Click(object sender, EventArgs e)
        {
            buttonAnaliseClicked = true;
            if (buttonOpenFileClicked == false)
            {
                MessageBox.Show("Najpierw wybierz folder");
            }
            if (Window > SamplesToAnalise / Fs)
            {
                MessageBox.Show("Wybrana wartoœæ okna czasowego jest nieprawid³owa");
            }
            if (buttonOpenFileClicked && Window <= SamplesToAnalise / Fs)
            {
                PressureChart3.Series["Pressure1"].Points.Clear();
                chart4.Series["Pressure1"].Points.Clear();
                listView1.Items.Clear();

                List<double> resultsPillow1 = new List<double>();
                List<double> resultsPillow2 = new List<double>();
                List<double> resultsECG = new List<double>();



                  Pillows pillow = new Pillows();
                    resultsPillow1 = pillow.checkPillow(Pressure1, timeP1, PressureSamples, Fs, Window);
                    foreach (double n in resultsPillow1) {
                        Console.WriteLine(" pillow1: " + n);
                    }
                    resultsPillow2 = pillow.checkPillow(Pressure2, timeP2, PressureSamples, Fs, Window);
                    foreach (double n in resultsPillow2)
                    {
                        Console.WriteLine(" pillow 2: " + n);
                    }
                    
                PanTompkins PanT = new PanTompkins();
                resultsECG = PanT.PanTompkinsAlgorithm(amplitude, Fs, time, SamplesToAnalise, EKGchart, PressureChart2, PressureChart3, chart4, Window, listView1);
                foreach (double n in resultsECG)
                {
                    Console.WriteLine(" resultsECG: " + n);
                }
                FinalResults FR = new FinalResults();
                FR.FinalResult(resultsPillow1, resultsPillow2, resultsECG, listView1, Window);
            }
        }

        private void WindowLength_SelectedIndexChanged(object sender, EventArgs e)
        { 
        
                Window = int.Parse(WindowLength.SelectedItem.ToString());
                EKGchart.Annotations.Clear();
                PressureChart1.Annotations.Clear();
                PressureChart2.Annotations.Clear();
                DrawGraphs dg = new DrawGraphs();
                for (int i = 0; i < SamplesToAnalise; i++)
                {
                    if (time[i] % Window == 0)
                    {
                        dg.VerticalLine(EKGchart, i, time);
                        dg.VerticalLine(PressureChart1, i, timeP1);
                        dg.VerticalLine(PressureChart2, i, timeP2);

                   /* VerticalLine(EKGchart, i);
                        VerticalLine(PressureChart1, i);
                        VerticalLine(PressureChart2, i);*/
                    }
                }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (buttonOpenFileClicked == false) MessageBox.Show("Wybierz plik do analizy");
            else if (buttonAnaliseClicked == false && buttonOpenFileClicked == true) MessageBox.Show("Najpierw rozpocznij analizê");
            else if (buttonAnaliseClicked == true && buttonOpenFileClicked == true)
            {
                SaveResults sr = new SaveResults();
                EKGchart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                sr.Save(listView1, EKGchart);
                EKGchart.ChartAreas[0].AxisX.ScaleView.Zoom(0, 11);
            }
        }
    } 
}