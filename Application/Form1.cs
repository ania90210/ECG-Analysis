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
        bool eChair = false;
        bool PhysioNet = false;

        //static int NumberOfLines = 45000; //1000 //8000/ 20000 /21600 /45000 ;
        static int SamplesToAnalise; //1000 //8000/ 20000 /21600 /45000 ;
        static int PressureSamples; //120 /100
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
                    amplitude.Clear();
                    time.Clear();
                    listView1.Items.Clear();
                    EKGchart.Series["EKG"].Points.Clear();
                    EKGchart.Series["Peaks"].Points.Clear();
                    PressureChart1.Series["Pressure1"].Points.Clear();
                    PressureChart2.Series["Pressure1"].Points.Clear();
                    EKGchart.Annotations.Clear();
                    PressureChart1.Annotations.Clear();
                    PressureChart2.Annotations.Clear();

                    fileName = ofd.FileName;                   
                    string line1 = File.ReadLines(fileName).First();
                    string[] column = line1.Split(',', ' ');

                    if (column[0] == "eKrzeslo" && column.Length == 2)
                    {
                        EKGchart.Series["EKG"].Points.Clear();

                        eChair = true;
                        PhysioNet = false;
                        Fs = Double.Parse(column[1]); // bez column.Length == 2
                        EKGchart.Series["EKG"].Points.Clear();

                    }
                    else if (column[0] == "PhysioNet" && column.Length == 1)
                    {
                        EKGchart.Series["EKG"].Points.Clear();

                        PhysioNet = true;
                        eChair = false;
                        string line3 = File.ReadLines(fileName).ElementAt(2);
                        string[] column1 = line3.Split(' ', '"');
                        Fs = 1 / Double.Parse(column1[0].Substring(1).Replace('.', ','));
                        EKGchart.Series["EKG"].Points.Clear();
                    }

                    else
                    {
                        fileName = null;
                        MessageBox.Show("Wybrano nieprawid³owy plik");
                    }
                    
                }
            }
            if (fileName != null) 
            {               
                

                WindowLength.Enabled = true;
                buttonOpenFileClicked = true;

                string[] lines = File.ReadAllLines(fileName);
                if (eChair) lines = lines.Skip(1).ToArray();
                else if (PhysioNet) lines = lines.Skip(3).ToArray();
                int lineNumber = lines.Count();
                SamplesToAnalise = PressureSamples = lineNumber;
                Console.WriteLine("SamplesToAnalise " + SamplesToAnalise);
                DrawGraphs dg = new DrawGraphs();
                dg.Graphs(Fs, lines, EKGchart, PressureChart1, PressureChart2, SamplesToAnalise, PressureSamples,
                time, amplitude, Window, Pressure1, timeP1, Pressure2, timeP2, lineNumber, eChair, PhysioNet);
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
                if (eChair)
                {
                    Pillows pillow = new Pillows();
                    resultsPillow1 = pillow.checkPillow(Pressure1, timeP1, PressureSamples, Fs, Window);
                    foreach (double n in resultsPillow1)
                    {
                        Console.WriteLine(" pillow1: " + n);
                    }
                    resultsPillow2 = pillow.checkPillow(Pressure2, timeP2, PressureSamples, Fs, Window);
                    foreach (double n in resultsPillow2)
                    {
                        Console.WriteLine(" pillow 2: " + n);
                    }
                }
                PanTompkins PT = new PanTompkins();
                resultsECG = PT.PanTompkinsAlgorithm(amplitude, Fs, time, SamplesToAnalise, EKGchart, Window, listView1);
                foreach (double n in resultsECG)
                {
                    Console.WriteLine(" resultsECG: " + n);
                }
                FinalResults FR = new FinalResults();
                FR.FinalResult(resultsPillow1, resultsPillow2, resultsECG, listView1, Window, eChair);
                buttonAnaliseClicked = true;
              //  Console.WriteLine("resultsECG " + resultsECG.Count + "  od 8: " + resultsPillow1[6]);
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