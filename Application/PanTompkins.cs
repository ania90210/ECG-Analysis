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
        List<double> ListOfPeaks = new List<double>();
        List<double> RTime = new List<double>();
        List<double> AboveAverage = new List<double>();
        List<double> TimeAboveAverage = new List<double>();
        List<double> error = new List<double>();
        List<double> RTimeDetected = new List<double>();
        List<double> RtooHigh_Low = new List<double>();
        List<double> RDistance = new List<double>();
        List<double> resultsHR = new List<double>();
        double HeartRate;

        public List<double> PanTompkinsAlgorithm(List<double> inputdata, double sampleRate, List<double> intime, int SamplesToAnalise, Chart EKGchart, 
                int WindowLength, ListView listView1)
        {
            double[] lowFilter = new double[SamplesToAnalise + 5];            
            double[] highFilter = new double[SamplesToAnalise + 5];
            double[] indata = inputdata.ToArray();
            double[] time = intime.ToArray();

            // FILTERING
            BandPassFilter bf = new BandPassFilter();
            lowFilter = bf.Filter(indata, sampleRate, "LOW");              
            highFilter = bf.Filter(lowFilter, sampleRate, "HIGH");
            // DERIVATIVE
            double[] derivative = new double[SamplesToAnalise];

            for (int i = 0; i < SamplesToAnalise - 1; i++)
            {
                derivative[i] = (highFilter[i + 1] - highFilter[i]) / (time[i + 1] - time[i]);
            }
            // SQUARING
            double[] square = new double[SamplesToAnalise + 500];
            for (int i = 0; i < SamplesToAnalise -1; i++)
            {
                square[i] = derivative[i] * derivative[i];
            }
            /*  PressureChart2.Titles["Title1"].Text = "SQUARE";
              PressureChart2.ChartAreas[0].AxisX.Minimum = 0;
              PressureChart2.ChartAreas[0].AxisX.Interval = 5;
              PressureChart2.ChartAreas[0].AxisX.Maximum = Math.Round(time[SamplesToAnalise - 1]);
              for (int i = 0; i < SamplesToAnalise; i++)
              {
                  PressureChart2.Series["Pressure1"].Points.AddXY(time[i], square[i]);
              }*/
            //MOVING AVERAGE FILTER
            double[] average = new double[SamplesToAnalise + 5];
            int movingAverageFilter = 0;
            if (sampleRate == 100) movingAverageFilter = 12;
            if (sampleRate == 400 || sampleRate == 360) movingAverageFilter = 100;
            if (sampleRate == 4500) movingAverageFilter = 400; // z 300
            else movingAverageFilter = 50;
            for (int j = movingAverageFilter-1; j < SamplesToAnalise + movingAverageFilter -1; j++) 
            {
                double sum = 0;
                for (int i = 0; i < movingAverageFilter; i++)
                {
                    sum += square[j - (movingAverageFilter - (i + 1))]; 
                }

                average[j - (movingAverageFilter - 1)] = sum / movingAverageFilter;
            }
            
            // FIRST PEAK
           /* int Samples = 0;
            if (sampleRate == 100) Samples = 100;
            else if (sampleRate == 400 || sampleRate == 360) Samples = 380;
            else if (sampleRate == 4500) Samples = 4300;
            else Samples = 200;*/
            int Samples = (int)(sampleRate * 0.95);
            double[] firstSamples = new double[Samples];
            for (int i = 0; i < Samples; i++)   
            {
                firstSamples[i] = average[i];
            }

            double maxValue = firstSamples.Max();
            double SPK = 0.7*maxValue;//0.13 * maxValue; //maxValue
            double NPK = 0.1 * SPK;
            double THRESHOLD = 0.25 * SPK + 0.75 * NPK;
            //  double THRESHOLD = 0.5* maxValue;
            Console.WriteLine("thresh: " + THRESHOLD + " maxvalue " + maxValue + " time " + Array.FindIndex(firstSamples, w => w == maxValue));

            
            // DETECTION
            for (int i = Array.FindIndex(firstSamples, w => w == maxValue); i < SamplesToAnalise; i++) 
            {
                if (average[i] > THRESHOLD)
                {
                    AboveAverage.Add(average[i]);
                    TimeAboveAverage.Add(time[i]);

                    if (average[i + 1] < THRESHOLD)
                    {
                        double max = AboveAverage.Max(); // R peak
                        int index = AboveAverage.FindIndex(w => w == max); // index of R peak == index of Time of this peak
                        RTime.Add(TimeAboveAverage[index]);
                        ListOfPeaks.Add(max);
                        AboveAverage.Clear();
                        TimeAboveAverage.Clear();
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
                
            }
            for (int i = 0; i < number; i++)
            {
                if (ListOfPeaks[i] != 0)
                {
                    RTimeDetected.Add(RTime[i]);
                }
                if (ListOfPeaks[i] != 0 && ListOfPeaks[i] > maxValue * 3) // jezeli peak R jest za duzy
                {
                    Console.WriteLine("za duzy r " + ListOfPeaks[i]);
                    RtooHigh_Low.Add(RTime[i]);
                }
                else if (ListOfPeaks[i] != 0 && ListOfPeaks[i] < maxValue * 0.4) // jezeli peak R jest za maly 0.3
                {
                    Console.WriteLine("za male r " + ListOfPeaks[i]);
                    RtooHigh_Low.Add(RTime[i]);
                }
            }
            foreach (double d in RTimeDetected)
            {
                Console.WriteLine(" RTimeDetected " + d);
            }
            double averageRTime = 0;
            int numberRdet = RTimeDetected.Count;

            if (numberRdet > 2)
            {
                for (int i = 0; i < 3; i++) // wez pierwsze 3 R
                {
                    RDistance.Add(RTimeDetected[i + 1] - RTimeDetected[i]);
                }
                averageRTime = RDistance.Average(); // Srednia miedzy kazdym R x3
                Console.WriteLine(" averageRTime: " + averageRTime);
            }
           
            Console.WriteLine("number rdet: " + numberRdet);
            if (numberRdet > 7)
            {               
                for (int i = 0; i < numberRdet; i++)
                {
                    if (i < numberRdet - 2 && RTimeDetected[i + 2] - RTimeDetected[i] < 1) // jezeli R wystepuja za czesto
                    {
                        double[] range = { RTimeDetected[i], RTimeDetected[i + 2] };
                        error.AddRange(range);
                        Console.WriteLine("RTimeDetected[i]: 3xR < 1s: wystepuja za czesto " + RTimeDetected[i] + " " + RTimeDetected[i + 2]);
                    }
                    if (i < numberRdet - 1 && RTimeDetected[i + 1] - RTimeDetected[i] > 2) // jezeli R wystepuja za rzadko
                    {
                        double[] range = { RTimeDetected[i], RTimeDetected[i + 1] };
                        error.AddRange(range);
                        Console.WriteLine("RTimeDetected[i]: 2xR > 2s: wystepuja za rzadko " + RTimeDetected[i] + " " + RTimeDetected[i + 1]);
                    }
                }
               /* for (int i = 0; i < numberRdet; i++) // co z tym?????????????????????????????????????????????????????????????
                {
                    if (i < numberRdet - 1 && averageRTime != 0 && RTimeDetected[i + 1] - RTimeDetected[i] < 0.30 * averageRTime)
                    {
                        Console.WriteLine("Za mala odleglosc do: " + RTimeDetected[i + 1]);
                        double[] range = { RTimeDetected[i], RTimeDetected[i + 1] };
                        error.AddRange(range);
                    }
                    else if (i < numberRdet - 1 && averageRTime != 0 && RTimeDetected[i + 1] - RTimeDetected[i] > 1.60 * averageRTime) // bylo 1.7
                    {
                        Console.WriteLine("Za duza odleglosc do: " + RTimeDetected[i + 1]);
                        double[] range = { RTimeDetected[i], RTimeDetected[i + 1] };
                        error.AddRange(range);
                    }
                }*/
            }
                foreach (double d in ListOfPeaks)
            {
            Console.WriteLine(" ListOfPeaks " + d);          
            }
            foreach (double d in RtooHigh_Low)
            {
                Console.WriteLine(" RtooHigh_Low " + d);
            }           

            foreach (double K in ListOfPeaks)
            {
                for (int i = 0; i < SamplesToAnalise; i++)
               {
                   if (average[i] == K)
                   {
                        EKGchart.Series["Peaks"].ChartType = SeriesChartType.FastPoint;
                        EKGchart.Series["Peaks"].Points.AddXY(time[i], indata[i]);
                    }
               }
            }
            // HEART RATE
            int y = 0;
            int x = 1;
            double numberOfWindows = (SamplesToAnalise / sampleRate) / WindowLength;
            double RoundWindow = Math.Floor(numberOfWindows);//Math.Round(numberOfWindows);
            for (int i = 0; i < RoundWindow; i++)
            {
                resultsHR.Add(CalculateHeartRate(WindowLength, RTime, ListOfPeaks, x, y, listView1, error, RtooHigh_Low));
                y++;
                x++;
            }
            return resultsHR;
        }
        private double CalculateHeartRate(int WindowLength, List<double> RTime, List<double> ListOfPeaks, int x, int y, ListView listView1, List<double> error, List<double> RtooHigh_Low)
        {            
            int R = 0;
            int Rerror = 0;
            string result = "";
            for(int i = 0; i < error.Count; i=i+2)
            {
                if (error.Count != 0 && error[i] >= y * WindowLength && error[i] < x * WindowLength)
                {
                    result = "noise";
                }                
            }
            for (int i = 0; i < RtooHigh_Low.Count; i++) //+2
            {
                if (RtooHigh_Low.Count != 0 && result != "noise" && RtooHigh_Low[i] >= y * WindowLength && RtooHigh_Low[i] < x * WindowLength)
                {                    
                    result = "irregularity";
                    Rerror++;
                }
            }
           // if (Rerror < 3 && result != "noise") { result = ""; R = R - Rerror; }
            for (int i = 0; i < RTime.Count; i++)
            {
                if (RTime[i] >= y * WindowLength && RTime[i] <= x * WindowLength && ListOfPeaks[i] != 0)
                {
                    R++;
                }
            }
           // if (RtooHigh_Low.Count < 3 && result != "noise") { result = ""; R = R - RtooHigh_Low.Count;  }
            double perMinute = 60 / WindowLength;
            HeartRate = R * perMinute;
            if (result == "noise") HeartRate = 0;
            else if (result == "irregularity") HeartRate = HeartRate - 200;

            return HeartRate;
        }
    }
}
