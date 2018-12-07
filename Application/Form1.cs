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
        static int NumberOfLines = 45000; //1000 //8000/ 20000 /21600 /45000 ;
        static int SamplesToAnalise = 45000; //1000 //8000/ 20000 /21600 /45000 ;
        static int PressureSamples = 45000; //120 /100
        double Fs;//100//400//4500 //360;  
        int Window = 5;

        List<double> time = new List<double>();
        List<double> amplitude = new List<double>();

        List<double> Pressure1 = new List<double>();
        List<double> timeP1 = new List<double>();

        List<double> Pressure2 = new List<double>();
        List<double> timeP2 = new List<double>();

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
                ofd.InitialDirectory = "C:\\Users\\Ania\\Desktop\\Inzynierka\\dane";//Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ofd.Filter = "TXT (*.txt)|*.txt";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    EKGchart.Series["EKG"].Points.Clear(); 
                    EKGchart.Series["Peaks"].Points.Clear();
                    PressureChart1.Series["Pressure1"].Points.Clear(); 
                    PressureChart2.Series["Pressure1"].Points.Clear(); 
                    listView1.Items.Clear();
                    string line1 = File.ReadLines(fileName).First();
                    string[] column = line1.Split(',', ' ');
                    if (column[0] != "eKrzeslo") // lub physionet
                    {
                        fileName = null;
                        MessageBox.Show("Wybrano nieprawid³owy plik");
                    }
                    else if (column[0] == "eKrzeslo") Fs = Double.Parse(column[1]);                
                }
            }
            if (fileName != null) 
            {
                WindowLength.Enabled = true;
                buttonOpenFileClicked = true;
                string[] lines = File.ReadAllLines(fileName);
                int lineNumber = File.ReadAllLines(fileName).Count();
                NumberOfLines = lineNumber - 1;
              //  SamplesToAnalise = NumberOfLines;
                Console.WriteLine("NumberOfLines " + NumberOfLines + "samples : " + SamplesToAnalise);
                DrawGraphs dg = new DrawGraphs();
                dg.Graphs(Fs, PressureSamples, lines, EKGchart, PressureChart1, PressureChart2, SamplesToAnalise, PressureSamples,
                time, amplitude, Window, Pressure1, timeP1, Pressure2, timeP2, lineNumber);
                buttonAnaliseClicked = false;
            }
        }
        
        private void Start_Click(object sender, EventArgs e)
        {
            if (!buttonOpenFileClicked)
            {
                MessageBox.Show("Wybierz plik do analizy");
            }
            if (Window > SamplesToAnalise / Fs)
            {
                MessageBox.Show("Wybrana wartoœæ okna czasowego jest nieprawid³owa");
            }
            if (buttonOpenFileClicked && Window <= SamplesToAnalise / Fs)
            {
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
                    
                PanTompkins PT = new PanTompkins();
                resultsECG = PT.PanTompkinsAlgorithm(amplitude, Fs, time, SamplesToAnalise, EKGchart, Window, listView1);
                foreach (double n in resultsECG)
                {
                    Console.WriteLine(" resultsECG: " + n);
                }
                FinalResults FR = new FinalResults();
                FR.FinalResult(resultsPillow1, resultsPillow2, resultsECG, listView1, Window);
                buttonAnaliseClicked = true;
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
            if (!buttonOpenFileClicked) MessageBox.Show("Wybierz plik do analizy");
            else if (!buttonAnaliseClicked && buttonOpenFileClicked == true && listView1.Items.Count == 0) MessageBox.Show("Najpierw rozpocznij analizê");
            else if (buttonAnaliseClicked == true && buttonOpenFileClicked == true && listView1.Items.Count !=0)
            {
                SaveResults sr = new SaveResults();
                EKGchart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                sr.Save(listView1, EKGchart);
                EKGchart.ChartAreas[0].AxisX.ScaleView.Zoom(0, 11);
            }
        }
    } 
}