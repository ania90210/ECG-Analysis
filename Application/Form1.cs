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