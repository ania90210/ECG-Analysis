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
        static int SamplesToAnalise = 20000; //1000 //8000/ 20000;
        double[] time = new double[SamplesToAnalise + 5];
        double[] amplitude = new double[SamplesToAnalise + 5];
        double Fs = 4000;//100//400//4000;     
        int Window = 10;
        StripLine stripline = new StripLine();
        double[] valueY = new double[SamplesToAnalise + 5];

        double[] Pressure = new double[SamplesToAnalise];
        double[] timeP = new double[SamplesToAnalise];

        double[] Pressure2 = new double[SamplesToAnalise];
        double[] timeP2 = new double[SamplesToAnalise];

        double[] valueXp1 = new double[10000];
        double[] valueYp1 = new double[10000];

        System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

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
            buttonWasClicked = true;
            string fileName = null;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "C:\\Users\\Ania\\Desktop\\Inzynierka";
                ofd.Filter = "TXT (*.txt)|*.txt";
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
                for (int i = 0; i < SamplesToAnalise; i++)
                {
                    //  Decimal.TryParse(lines[i], NumberStyles.Any, CultureInfo.InvariantCulture, out decY);
                    //valueY[i] = decimal.ToDouble(decY);
                    lines[i] = lines[i].Replace('.', ',');
                    valueY[i] = Double.Parse(lines[i]);
                    double Ts = 1 / Fs;
                    if (i == 0)
                    {
                        /*  amplitude[i] = valueY[i]/100;
                          time[i] = Ts;*/
                        amplitude[i] = valueY[i];
                        time[i] = 0;
                    }
                    else
                    {
                        /* amplitude[i] = (valueY[i] + valueY[i - 1])/100;
                         time[i] = (i+1)*Ts; */
                        amplitude[i] = valueY[i];
                        time[i] = i * Ts;
                    }
                    /*string[] XY = lines[i].Split(',');
                    
                    Decimal.TryParse(XY[0], NumberStyles.Any, CultureInfo.InvariantCulture, out decX);
                    valueX[i] = decimal.ToDouble(decX);

                    Decimal.TryParse(XY[1], NumberStyles.Any, CultureInfo.InvariantCulture, out decY);
                    valueY[i] = decimal.ToDouble(decY);*/

                    //valueXp1[i] = double.Parse(XY[2]);
                    //valueYp1[i] = double.Parse(XY[3]); 
                }
                // EKG chart
                var chart = this.EKGchart.ChartAreas[0];
                chart.AxisX.Title = "Time [s]";
                chart.AxisY.Title = "Amplitude [mV]";
                EKGchart.Series["EKG"].Points.Clear(); // clear chart
                chart.AxisX.Minimum = 0;
                chart.AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);
                chart.AxisX.Interval = 5;
                this.EKGchart.Series["EKG"].Color = Color.Red;

                for (int i = 0; i < SamplesToAnalise; i++)
                {
                    this.EKGchart.Series["EKG"].Points.AddXY(time[i], amplitude[i]);
                }
                listView1.Items.Clear();
                StripLine(chart, Window);
                watch.Stop();
                Console.WriteLine($"OpenFileButton_Click_1: {watch.ElapsedMilliseconds} ms");

            /*    //PILLOW I
                for (int i = SamplesToAnalise; i < SamplesToAnalise + 1000; i++) //_1000
                {
                    lines[i] = lines[i].Replace('.', ',');
                    valueY[i - SamplesToAnalise] = Double.Parse(lines[i]);
                    double Ts = 1 / Fs ;
                    Pressure[i- SamplesToAnalise] = valueY[i- SamplesToAnalise];
                    timeP[i- SamplesToAnalise] = (i- SamplesToAnalise) * Ts;
                }
             
                var chartP = PressureChart1.ChartAreas[0];
                chartP.AxisX.Title = "Time [s]";
                chartP.AxisY.Title = "Pressure [p]";
                PressureChart1.Series["Pressure1"].Points.Clear(); // clear chart
                PressureChart1.Series["Pressure1"].Color = Color.Blue;
                chartP.AxisX.Minimum = 0;
                chartP.AxisX.Interval = 5;
                chartP.AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);

                for (int i = 0; i < SamplesToAnalise; i++)
                {
                    PressureChart1.Series["Pressure1"].Points.AddXY(timeP[i], Pressure[i]);
                }
                StripLine(chartP, Window);

                //PILLOW II
                for (int i = SamplesToAnalise + 1000; i < SamplesToAnalise + 2000; i++)
                {
                    lines[i] = lines[i].Replace('.', ',');
                    valueY[i - SamplesToAnalise - 1000] = Double.Parse(lines[i]);
                    double Ts = 1 / Fs;
                    Pressure2[i - SamplesToAnalise - 1000] = valueY[i - SamplesToAnalise - 1000];
                    timeP2[i - SamplesToAnalise - 1000] = (i - SamplesToAnalise - 1000) * Ts;
                }

                var chartP2 = PressureChart2.ChartAreas[0];
                chartP2.AxisX.Title = "Time [s]";
                chartP2.AxisY.Title = "Pressure [p]";
                PressureChart2.Series["Pressure1"].Points.Clear(); // clear chart
                PressureChart2.Series["Pressure1"].Color = Color.Blue;
                chartP2.AxisX.Minimum = 0;
                chartP2.AxisX.Interval = 5;
                chartP2.AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);

                for (int i = 0; i < SamplesToAnalise; i++)
                {
                    PressureChart2.Series["Pressure1"].Points.AddXY(timeP2[i], Pressure2[i]);
                }
                StripLine(chartP, Window);
                */
            }
        }
        public void StripLine(ChartArea chart, int x)
        {
            if (!watch.IsRunning)
                watch.Restart();
            stripline.Interval = x;
            stripline.IntervalOffset = x - 0.04;
            stripline.StripWidth = 0.08;
            stripline.BackColor = Color.MidnightBlue;
            chart.AxisX.StripLines.Add(stripline);
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
                StripLine(this.EKGchart.ChartAreas[0], Window);
              //  StripLine(PressureChart1.ChartAreas[0], Window);
               // PressureChart2.Series["Pressure1"].Points.Clear();
                PressureChart3.Series["Pressure1"].Points.Clear();
                chart4.Series["Pressure1"].Points.Clear();
                listView1.Items.Clear();

                List<double> resultsPillow = new List<double>();
                List<double> resultsPillow2 = new List<double>();
                List<double> resultsECG = new List<double>();

                Pillows pillow = new Pillows();
                
                /*    resultsPillow = pillow.checkPillow(Pressure, SamplesToAnalise, Fs, Window);
                    foreach (double n in resultsPillow) {
                        Console.WriteLine(" pillow: " + n);
                    }
                    resultsPillow2 = pillow.checkPillow(Pressure2, SamplesToAnalise, Fs, Window);
                    foreach (double n in resultsPillow2)
                    {
                        Console.WriteLine(" pillow 2: " + n);
                    }
                    */
                PanTompkins PanT = new PanTompkins();
                resultsECG = PanT.PanTompkinsAlgorithm(amplitude, Fs, time, SamplesToAnalise, PressureChart1, PressureChart2, PressureChart3, chart4, Window, listView1);
                foreach (double n in resultsECG)
                {
                    Console.WriteLine(" resultsECG: " + n);
                }
                FinalResult(resultsPillow, resultsECG, listView1, Window);
                watch.Stop();
                Console.WriteLine($"Po calym Start_Click Execution Time: {watch.ElapsedMilliseconds} ms");
            }
        }

        private void WindowLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            Window = int.Parse(WindowLength.SelectedItem.ToString());
            StripLine(this.EKGchart.ChartAreas[0], Window);
          //  StripLine(PressureChart1.ChartAreas[0], Window);
        }
        private void FinalResult(List<double> resultsPillow, List<double> resultsECG, ListView listView1, int Window)
        {
            string wynik = "";
            
            for (int i = 0; i < resultsECG.Count; i++) //resultsPillow
            {
                
                double HR = resultsECG[i];
                var result = new ListViewItem();

                /*if (resultsPillow[i] >= 10) // movement
                {
                    if (HR >= 60 && HR <= 90) wynik = "wszystko OK";
                    if (HR < 60) wynik = "rusza sie ale HR za male";
                    if (HR > 90) wynik = "ekscytuje sie/ rusza";
                    if (HR == -1) wynik = "zmiana pozycji"; 
                }
                if (resultsPillow[i] < 10) // no movement
                {
                    if (HR >= 60 && HR <= 90) wynik = "wszystko OK";
                    if (HR < 60) wynik = "tetno za male";
                    if (HR > 90) wynik = "ZAWAL/ STRES";
                    if (HR == -1) wynik = "COS SIE DZIEJE!?";
                }*/
                if (HR >= 60 && HR <= 90) wynik = "wszystko OK";
                if (HR < 60) wynik = "tetno za male";
                if (HR > 90) wynik = "ZAWAL/ STRES";
                if (HR == -1) wynik = "COS SIE DZIEJE!?";
                string okno = " [" + i * Window + " - " + (i + 1) * Window + "s]";
                if (HR == -1) result = new ListViewItem(new[] { (i + 1).ToString() + okno, " ?  bpm", wynik });
                else result = new ListViewItem(new[] { (i + 1).ToString() + okno, HR.ToString() + " bpm", wynik });
                if (!watch.IsRunning)
                    watch.Restart();
                listView1.Items.Add(result);
                watch.Stop();
                Console.WriteLine($"listView1.Items.Add(result); Execution Time: {watch.ElapsedMilliseconds} ms");
                result.ForeColor = (HR > 59 && HR < 91) ? Color.ForestGreen : Color.Red;
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CSVFile CSVF = new CSVFile();
            CSVF.csv(listView1, EKGchart);
        }
    } 
}