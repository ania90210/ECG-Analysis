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
        static int SamplesToAnalise = 1000; //8000;
        double[] time = new double[SamplesToAnalise + 5];
        double[] amplitude = new double[SamplesToAnalise + 5];
        double Fs = 100;//400;     
        int Window = 10;
        StripLine stripline = new StripLine();
        double[] valueY = new double[SamplesToAnalise + 5];
        double[] valueXp1 = new double[10000];
        double[] valueYp1 = new double[10000];
        int counter;

        public Application()
        {
            InitializeComponent();
            // empty chart
          //  var header1 = listView1.Columns.Add("Nr okna", 100, HorizontalAlignment.Left);
            //var header2 = listView1.Columns.Add("Têtno", -2, HorizontalAlignment.Center);
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
                        /*  amplitude[i] = valueY[i]/100;
                          time[i] = Ts;*/
                        amplitude[i] = valueY[i];
                          time[i] = 0;
                    }
                    else {
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
                // do charts
                var chart = this.EKGchart.ChartAreas[0];                 
                chart.AxisX.Title = "Time [s]";
                chart.AxisY.Title = "Amplitude [mV]";

                // EKG chart
                if (this.EKGchart.Series.IndexOf("EKG") != -1) // if it exists
                {
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
                    StripLine(this.EKGchart.ChartAreas[0], Window);
                }
            }
        }
        public void StripLine(ChartArea chart, int x)
        {         
            stripline.Interval = x;
            stripline.IntervalOffset = x - 0.04;
            stripline.StripWidth = 0.08;
            stripline.BackColor = Color.MidnightBlue;
            chart.AxisX.StripLines.Add(stripline);
        }

        private void Start_Click(object sender, EventArgs e)
        {
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
                PressureChart1.Series["Pressure1"].Points.Clear(); // clear chart
                PressureChart2.Series["Pressure1"].Points.Clear();
                PressureChart3.Series["Pressure1"].Points.Clear();
                chart4.Series["Pressure1"].Points.Clear();
                listView1.Items.Clear();

                PanTompkins PanT = new PanTompkins();
                PanT.PanTompkinsAlgorithm(amplitude, Fs, time, SamplesToAnalise, PressureChart1, PressureChart2, PressureChart3, chart4, Window, listView1);
            }
        }

        private void WindowLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            Window = int.Parse(WindowLength.SelectedItem.ToString());
            StripLine(this.EKGchart.ChartAreas[0], Window);
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
/* Document pdfDoc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
PdfWriter.GetInstance(pdfDoc, new FileStream("Test.pdf", FileMode.Create));
pdfDoc.Open();
using (MemoryStream stream = new MemoryStream())
{
    chart.SaveImage(stream, ChartImageFormat.Png);
    iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
    chartImage.ScalePercent(200f);
    pdfDoc.Add(chartImage);
    pdfDoc.Close();

    Response.Clear();
    Response.AppendHeader("content-disposition", "attachment;filename=Chart.pdf");
    Response.ContentType = "application/pdf";
    Response.WriteFile(pdfDoc);
    Response.Flush();
    Response.End();
}*/
