using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Application
{
    class PanTompkins
    {      
        // LOW / HIGH PASS FILTER
        public static double[] Butterworth(double[] indata, double sampleRate, string HL)
        {
            double[] error = { };
            long dF2 = indata.Length - 1;        // The data range is set with dF2
            double[] Dat2 = new double[dF2 + 4]; // Array with 4 extra points front and back // INPUT
           // double[] data = indata; // Ptr., changes passed data
            double[] data = new double[indata.Length];
            // Copy indata to Dat2
            for (long r = 0; r < dF2; r++)
            {
                Dat2[2 + r] = indata[r];
            }
            Dat2[1] = Dat2[0] = indata[0];
            Dat2[dF2 + 3] = Dat2[dF2 + 2] = indata[dF2];

            // RECURSIVE TRIGGERS - ENABLE filter is performed (first, last points constant)
            double[] DatYt = new double[dF2 + 4]; //OUTPUT
            DatYt[1] = DatYt[0] = indata[0];

            double[] DatH = new double[dF2 + 4]; //OUTPUT
            DatH[1] = DatH[0] = indata[0];
            
            // LOW FILTER
            if (HL == "LOW")
            {
                double cN = 1 / Math.Tan(Math.PI * 12 / sampleRate);
                double a1N = 1.0 / (1.0 + Math.Sqrt(2) * cN + cN * cN);
                double a2N = 2 * a1N;
                double a3N = a1N;
                double b1N = 2.0 * (1 - cN * cN) * a1N;
                double b2N = (1.0 - Math.Sqrt(2) * cN + cN * cN) * a1N;

                for (long n = 2; n < dF2 + 2; n++)
                {
                    DatYt[n] = a1N * Dat2[n] + a2N * Dat2[n - 1] + a3N * Dat2[n - 2] - b1N * DatYt[n - 1] - b2N * DatYt[n - 2];
                }
                DatYt[dF2 + 3] = DatYt[dF2 + 2] = DatYt[dF2 + 1];

                for (long p = 0; p < dF2; p++)
                {
                    data[p] = DatYt[p];
                }
                return data;
            }


            //HIGH FILTER 
            if (HL == "HIGH")
            {
                double cNH = Math.Tan(Math.PI * 7 / sampleRate);
                double a1NH = 1.0 / (1.0 + Math.Sqrt(2) * cNH + cNH * cNH);
                double a2NH = -2 * a1NH;
                double a3NH = a1NH;
                double b1NH = 2.0 * (cNH * cNH - 1) * a1NH;
                double b2NH = (1.0 - Math.Sqrt(2) * cNH + cNH * cNH) * a1NH;

                for (long n = 2; n < dF2 + 2; n++)
                {
                    DatH[n] = a1NH * Dat2[n] + a2NH * Dat2[n - 1] + a3NH * Dat2[n - 2] - b1NH * DatH[n - 1] - b2NH * DatH[n - 2];
                }
                DatH[dF2 + 3] = DatH[dF2 + 2] = DatH[dF2 + 1];

                for (long p = 0; p < dF2; p++)
                {
                    data[p] = DatH[p];
                }
                return data;
            }
            else
            {
                return error;
            }
        }
        

        public List<double> PanTompkinsAlgorithm(double[] indata, double sampleRate, double[] time, int SamplesToAnalise, Chart PressureChart1, Chart PressureChart2, Chart PressureChart3, Chart chart4, int WindowLength, ListView listView1)
        {
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            double[] lowFilter = new double[SamplesToAnalise + 5];            
            double[] highoriginal = new double[SamplesToAnalise + 5];
            
            // FILTERING
            lowFilter = Butterworth(indata, sampleRate, "LOW");
            watch.Stop();
            Console.WriteLine($"Po low FILTER: Execution Time: {watch.ElapsedMilliseconds} ms");
            if (!watch.IsRunning) // checks if it is not running
                watch.Restart();
            highoriginal = Butterworth(lowFilter, sampleRate, "HIGH");
            watch.Stop();
            Console.WriteLine($"Po HIGH FILTER: Execution Time: {watch.ElapsedMilliseconds} ms");
            if (!watch.IsRunning) // checks if it is not running
                watch.Restart();

            // DERIVATIVE
            double[] derivative = new double[SamplesToAnalise + 5];

            for (int i = 0; i < SamplesToAnalise; i++)
            {
                derivative[i] = (highoriginal[i + 1] - highoriginal[i]) / (time[i + 1] - time[i]);
            }
            PressureChart1.Titles["Title1"].Text = "derivative";
            PressureChart1.ChartAreas[0].AxisX.Minimum = 0;
            PressureChart1.ChartAreas[0].AxisX.Interval = 5;
            PressureChart1.ChartAreas[0].AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);
            for (int i = 0; i < SamplesToAnalise; i++)
            {
                PressureChart1.Series["Pressure1"].Points.AddXY(time[i], derivative[i]);
            }
            // WYKRES
            watch.Stop();
            Console.WriteLine($"Po DERIVATIVE: Execution Time: {watch.ElapsedMilliseconds} ms");
            if (!watch.IsRunning) // checks if it is not running
                watch.Restart();
            // SQUARING
            double[] square = new double[SamplesToAnalise + 400];
            for (int i = 0; i < SamplesToAnalise; i++)
            {
                square[i] = derivative[i] * derivative[i];
            }
            PressureChart2.Titles["Title1"].Text = "SQUARE";
            PressureChart2.ChartAreas[0].AxisX.Minimum = 0;
            PressureChart2.ChartAreas[0].AxisX.Interval = 5;
            PressureChart2.ChartAreas[0].AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);
            for (int i = 0; i < SamplesToAnalise; i++)
            {
                PressureChart2.Series["Pressure1"].Points.AddXY(time[i], square[i]);
            }
            watch.Stop();
            Console.WriteLine($"Po SQUERING: Execution Time: {watch.ElapsedMilliseconds} ms");
            if (!watch.IsRunning) // checks if it is not running
                watch.Restart();
            //MOVING AVERAGE FILTER
            double[] average = new double[SamplesToAnalise + 5];
            int movingAverageFilter = 0;
            if (sampleRate == 100) movingAverageFilter = 12;
            if (sampleRate == 400 || sampleRate == 360) movingAverageFilter = 100;
            if (sampleRate == 4000) movingAverageFilter = 300; // z 200
            for (int j = movingAverageFilter-1; j < SamplesToAnalise + movingAverageFilter -1; j++) //99//11
            {
                double sum = 0;
                for (int i = 0; i < movingAverageFilter; i++)
                {
                    sum += square[j - (movingAverageFilter - (i + 1))]; // 100
                }

                average[j - (movingAverageFilter - 1)] = sum / movingAverageFilter;
            }

            PressureChart3.Titles["Title1"].Text = "MOVING AVERAGE FILTER";
            PressureChart3.Series["Pressure1"].Color = Color.DeepPink;
            PressureChart3.ChartAreas[0].AxisX.Minimum = 0;
            PressureChart3.ChartAreas[0].AxisX.Interval = 5;
            PressureChart3.ChartAreas[0].AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);
            for (int i = 0; i < SamplesToAnalise; i++)
            {
                PressureChart3.Series["Pressure1"].Points.AddXY(time[i], average[i]);
            }
            watch.Stop();
            Console.WriteLine($"Po MOVING AVERAGE FILTER: Execution Time: {watch.ElapsedMilliseconds} ms");
            if (!watch.IsRunning) // checks if it is not running
                watch.Restart();
            // FIRST PEAK
            int Samples = 0;
            if (sampleRate == 100) Samples = 100;
            if (sampleRate == 400 || sampleRate == 360) Samples = 300;
            if (sampleRate == 4000) Samples = 3000;
            double[] firstSamples = new double[Samples];
            for (int i = 0; i < Samples; i++)   
            {
                firstSamples[i] = average[i];
            }

            double maxValue = firstSamples.Max();
            double SPK = 0.13 * maxValue; //maxValue;
            double NPK = 0.1 * SPK;
            double THRESHOLD = 0.25 * SPK + 0.75 * NPK;
            //  double THRESHOLD = 0.5* maxValue;

            List<double> ListOfPeaks = new List<double>();            
            List<double> RTime = new List<double>();
            List<double> AboveAverage = new List<double>();
            List<double> TimeAverage = new List<double>();
            double[] AboveThreshold = new double[average.Length];
            List<double> difference = new List<double>();
            List<double> Rdet = new List<double>();
            List<double> RtooHigh = new List<double>();
            // DETECTION
            for (int i = 0; i < SamplesToAnalise; i++) // od FirstRTime = Array.FindIndex(firstSamples, w => w == maxValue);
            {
                if (average[i] > THRESHOLD)
                {
                    AboveAverage.Add(average[i]);
                    TimeAverage.Add(time[i]);
                    // AboveThreshold[i] = average[i];
                    if (average[i + 1] < THRESHOLD)
                    {
                        double max = AboveAverage.Max(); // R peak
                        int index = AboveAverage.FindIndex(w => w == max); // index of R peak == index of Time of this peak
                      /*  double start = TimeAverage.First();
                        double end = TimeAverage.Last();
                        double[] range = { start, end };
                        if (end - start > 0.2)
                        {
                            difference.AddRange(range);
                            MessageBox.Show("jest roznica > 0.8");
                            // sprawdz poduszki
                        }
                        */
                        RTime.Add(TimeAverage[index]);
                        ListOfPeaks.Add(max);
                        AboveAverage.Clear();
                        TimeAverage.Clear();

                        /*
                        // RTime.Add(Array.FindIndex(AboveThreshold, w => w == AboveThreshold.Max()));
                        int indx = (Array.FindIndex(AboveThreshold, w => w == AboveThreshold.Max()));
                        RTime.Add(time[indx]);
                        ListOfPeaks.Add(AboveThreshold.Max());
                        Array.Clear(AboveThreshold, 0, AboveThreshold.Length);
                        */
                    }
                }
            }
            int number = ListOfPeaks.Count;
            for (int i = 0; i < number - 1; i++)
            {
                if(RTime[i+1] - RTime[i] < 0.4)//0.49
                {
                    if (ListOfPeaks[i + 1] < ListOfPeaks[i])
                    {
                        ListOfPeaks[i + 1] = 0;
                    }
                    else
                    {
                        ListOfPeaks[i] = 0;
                    }
                }
                
                /*if (i < number-2 && RTime[i + 2] - RTime[i] < 0.8)
                {
                    double[] range = { RTime[i], RTime[i + 2] };
                    difference.AddRange(range);                   
                }*/
                
                    /* double firstTime = 0;
                     double secondTime = 0;
                     for (int j = 0; j < SamplesToAnalise; j++)
                     {
                         if (average[j] == ListOfPeaks[i])
                         {
                             firstTime = time[j];
                         }
                     }
                     for (int j = 0; j < SamplesToAnalise; j++)
                     {
                         if (average[j] == ListOfPeaks[i + 1])
                         {
                             secondTime = time[j];
                         }
                     }
                     if ((secondTime - firstTime) < 0.45)//343
                     {
                         if (ListOfPeaks[i + 1] < ListOfPeaks[i])
                         {
                             ListOfPeaks[i + 1] = 0;
                             RTime[i + 1] = 0;
                         }
                         else
                         {
                             ListOfPeaks[i] = 0;
                             RTime[i] = 0;
                         }
                     }*/
            }
            for (int i = 0; i < number; i++)
            {
                if (ListOfPeaks[i] != 0)
                {
                    Rdet.Add(RTime[i]);
                }
                if (ListOfPeaks[i] > maxValue*5)
                {
                    Console.WriteLine("za duzy r " + ListOfPeaks[i]);
                    RtooHigh.Add(RTime[i]);
                }
            }
            foreach (double d in Rdet)
            {
                Console.WriteLine(" Rdet " + d);
            }
            int numbewr = Rdet.Count;
            Console.WriteLine("number rdet: " + numbewr);
            for (int i = 0; i < numbewr; i++)
            {               
                if (i < Rdet.Count - 2 && Rdet[i + 2] - Rdet[i] < 1)
                {
                    double[] range = { Rdet[i], Rdet[i + 2] };
                    difference.AddRange(range);
                    Console.WriteLine("Rdet[i]: " + Rdet[i]);
                }
            }
            foreach (double d in ListOfPeaks)
            {
            Console.WriteLine(" ListOfPeaks " + d);          
            }
            foreach (double d in RtooHigh)
            {
                Console.WriteLine(" Rtoohigh " + d);
            }
            watch.Stop();
            Console.WriteLine($"Po DETEKCJI PEAKOW: Execution Time: {watch.ElapsedMilliseconds} ms");
            if (!watch.IsRunning) // checks if it is not running
                watch.Restart();
            foreach (double K in ListOfPeaks)
            {
                for (int i = 0; i < SamplesToAnalise; i++)
               {
                   if (average[i] == K)
                   {
                        chart4.Titles["Title1"].Text = "PEAK";
                        chart4.ChartAreas[0].AxisX.Minimum = 0;
                        chart4.ChartAreas[0].AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);
                        chart4.ChartAreas[0].AxisX.Interval = 5;
                        chart4.Series["Pressure1"].Color = Color.Brown;
                        chart4.Series["Pressure1"].Points.AddXY(time[i], K); //AboveThreshold[i]
                    }
               }
            }
            // HEART RATE
            List<double> resultsHR = new List<double>();
            int y = 0;
            int x = 1;
            double numberOfWindows = (SamplesToAnalise / sampleRate) / WindowLength;
            double RoundWindow = Math.Floor(numberOfWindows);//Math.Round(numberOfWindows);
            for (int i = 0; i < RoundWindow; i++)
            {
                resultsHR.Add(HeartRate(WindowLength, RTime, ListOfPeaks, sampleRate, x, y, listView1, difference, RtooHigh));
                y++;
                x++;
            }
            watch.Stop();
            Console.WriteLine($"Po HEART RATE: Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine("thresh: " + THRESHOLD + " maxvalue " + maxValue);
            if (!watch.IsRunning) // checks if it is not running
                watch.Restart();
            return resultsHR;
        }
        public double HeartRate(int WindowLength, List<double> RTime, List<double> ListOfPeaks, double sampleRate, int x, int y, ListView listView1, List<double> difference, List<double> RtooHigh)
        {            
            int R = 0;
            string wynik = "";
            for(int i = 0; i < difference.Count; i=i+2)
            {
                if (difference.Count != 0 && difference[i] >= y * WindowLength && difference[i] < x * WindowLength)
                {
                    Console.WriteLine("range[i]: " + difference[i]);
                    Console.WriteLine("range[i+1]: " + difference[i + 1]);
                    if (difference[i + 1] < x * WindowLength)
                    {
                        wynik = "check";                       
                    }
                    if (difference[i + 1] >= x * WindowLength && difference[i + 1] <= (x + 1) * WindowLength)
                    {
                        wynik = "check";
                    }
                }                
            }
            for (int i = 0; i < RtooHigh.Count; i = i + 2)
            {
                if (RtooHigh.Count != 0 && RtooHigh[i] >= y * WindowLength && RtooHigh[i] < x * WindowLength)
                {
                    wynik = "check";
                }
            }
            for (int i = 0; i < RTime.Count; i++)
            {               
                if (RTime[i] > y * WindowLength && RTime[i] < x * WindowLength && ListOfPeaks[i] != 0)
                {
                    R++;
                }
            }
            double perMinute = 60 / WindowLength;
            double HeartRate = R * perMinute;
            if (wynik == "check") HeartRate = -1;

           /* string NrOkna = x + "  [" + y * WindowLength + " - " + x * WindowLength + "s]";
            var result = new ListViewItem(new[] { NrOkna, HeartRate.ToString() + " bpm" });
            listView1.Items.Add(result);
            result.ForeColor = (HeartRate > 59 && HeartRate < 91) ? Color.ForestGreen : Color.Red;  */         
            return HeartRate;
        }
    }
}
