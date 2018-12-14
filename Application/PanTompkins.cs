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
                int WindowLength, bool PhysioNet)
        {
            double[] lowFilter = new double[SamplesToAnalise + 5];            
            double[] highFilter = new double[SamplesToAnalise + 5];
            double[] indata = inputdata.ToArray();
            double[] time = intime.ToArray();

            // FILTRACJA
            BandPassFilter bf = new BandPassFilter();
            lowFilter = bf.Filter(indata, sampleRate, "LOW");              
            highFilter = bf.Filter(lowFilter, sampleRate, "HIGH");
       
            // RÓŻNICZKOWANIE
            double[] derivative = new double[SamplesToAnalise];

            for (int i = 0; i < SamplesToAnalise - 1; i++)
            {
                derivative[i] = (highFilter[i + 1] - highFilter[i]) / (time[i + 1] - time[i]);
            }
            // POTĘGOWANIE
            double[] square = new double[SamplesToAnalise + 500];
            for (int i = 0; i < SamplesToAnalise -1; i++)
            {
                square[i] = derivative[i] * derivative[i];
            }
           
            //FILTRACJA UŚREDNIAJĄCA
            double[] average = new double[SamplesToAnalise + 5];
            int movingAverageFilter = 0; // długość okna ruchomego
            if(sampleRate < 150) movingAverageFilter = 15;
            else if (sampleRate >= 150 && sampleRate <= 300) movingAverageFilter = 40; 
            else if (sampleRate < 500 && sampleRate > 300) movingAverageFilter = 100;
            else if (sampleRate <= 1000 && sampleRate >= 500) movingAverageFilter = 200;
            else if (sampleRate < 4000 && sampleRate > 1000) movingAverageFilter = 300;
            else if (sampleRate >= 4500) movingAverageFilter = 400; 
            else movingAverageFilter = 500;

            for (int j = movingAverageFilter-1; j < SamplesToAnalise + movingAverageFilter -1; j++) 
            {
                double sum = 0;
                for (int i = 0; i < movingAverageFilter; i++)
                {
                    sum += square[j - (movingAverageFilter - (i + 1))]; 
                }

                average[j - (movingAverageFilter - 1)] = sum / movingAverageFilter;
            }
          


            // PIERWSZE MAKSIMUM
            int Samples = (int)sampleRate;
            double[] firstSamples = new double[Samples];
            for (int i = 0; i < Samples; i++)   
            {
                firstSamples[i] = average[i];
            }
            // WARTOŚĆ GRANICZNA
            double maxValue = firstSamples.Max();
            double SPK = 0.7*maxValue;
            double NPK = 0.1 * SPK;
            double THRESHOLD = 0.25 * SPK + 0.75 * NPK;
           
            // DETEKCJA
            for (int i =0; i < SamplesToAnalise; i++) 
            {
                if (average[i] > THRESHOLD)
                {
                    AboveAverage.Add(average[i]);
                    TimeAboveAverage.Add(time[i]);

                    if (average[i + 1] < THRESHOLD)
                    {
                        double max = AboveAverage.Max(); // załamek R
                        int index = AboveAverage.FindIndex(w => w == max); // czas w jakim wystąpił załamek R
                        RTime.Add(TimeAboveAverage[index]);
                        ListOfPeaks.Add(max);
                        AboveAverage.Clear();
                        TimeAboveAverage.Clear();
                    }
                }
            }
            int number = ListOfPeaks.Count;
            // sprawdzanie odległości między wykrytymi maksimami i usuwanie tych błędnie wykrytych
            for (int i = 0; i < number - 1; i++)
            {
                if(RTime[i+1] - RTime[i] < 0.4)
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
                if (ListOfPeaks[i] != 0 && ListOfPeaks[i] > maxValue * 3) // jezeli załamek R jest za wysoki
                {
                    RtooHigh_Low.Add(RTime[i]);
                }
                else if (ListOfPeaks[i] != 0 && ListOfPeaks[i] < maxValue * 0.5) // jezeli załamek R jest za niski
                {
                    RtooHigh_Low.Add(RTime[i]);
                }
            }
            
            double averageRTime = 0;
            int numberRdet = RTimeDetected.Count;

            if (numberRdet > 4)
            {
                for (int i = 0; i < 3; i++)
                {
                    RDistance.Add(RTimeDetected[i + 1] - RTimeDetected[i]);
                }
                averageRTime = RDistance.Average(); // średnia odległość miedzy każdym załamkiem R
            }
           
            if (numberRdet > 7)
            {               
                for (int i = 0; i < numberRdet; i++)
                {
                    if (i < numberRdet - 2 && RTimeDetected[i + 2] - RTimeDetected[i] < 1) // jezeli załamki R wystepują za często
                    {
                        double[] range = { RTimeDetected[i], RTimeDetected[i + 2] };
                        error.AddRange(range);
                    }
                    if (i < numberRdet - 1 && RTimeDetected[i + 1] - RTimeDetected[i] > 2) // jezeli załamki R wystepują za rzadko
                    {
                        double[] range = { RTimeDetected[i], RTimeDetected[i + 1] };
                        error.AddRange(range);
                    }
                }
                // czy odległość R-R nie są za duże / małe
                for (int i = 0; i < numberRdet; i++)
                {
                    if (i < numberRdet - 1 && averageRTime != 0 && RTimeDetected[i + 1] - RTimeDetected[i] < 0.30 * averageRTime)
                    {
                        double[] range = { RTimeDetected[i], RTimeDetected[i + 1] };
                        error.AddRange(range);
                    }
                    else if (i < numberRdet - 1 && averageRTime != 0 && RTimeDetected[i + 1] - RTimeDetected[i] > 1.60 * averageRTime)
                    {
                        double[] range = { RTimeDetected[i], RTimeDetected[i + 1] };
                        error.AddRange(range);
                    }
                }
            }
                   
            // rysowanie punktów na wykresie EKG
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
            // obliczenie pulsu dla każdego okna
            int y = 0;
            int x = 1;
            double numberOfWindows = (SamplesToAnalise / sampleRate) / WindowLength;
            double RoundWindow = Math.Floor(numberOfWindows);
            for (int i = 0; i < RoundWindow; i++)
            {
                resultsHR.Add(CalculateHeartRate(WindowLength, RTime, ListOfPeaks, x, y, error, RtooHigh_Low, PhysioNet));
                y++;
                x++;
            }
            return resultsHR;
        }
        private double CalculateHeartRate(int WindowLength, List<double> RTime, List<double> ListOfPeaks, int x, int y, List<double> error, List<double> RtooHigh_Low, bool PhysioNet)
        {            
            int R = 0;
            int Rerror = 0;
            string result = "";
            for(int i = 0; i < error.Count; i=i+2)
            {
                if (error.Count != 0 && error[i] >= y * WindowLength && error[i] < x * WindowLength)
                {
                    result = "noise"; // jeżeli odległości między załamkami R są niewłaściwe
                }                
            }
            for (int i = 0; i < RtooHigh_Low.Count; i++) 
            {
                if (RtooHigh_Low.Count > 0 && result != "noise" && RtooHigh_Low[i] >= y * WindowLength && RtooHigh_Low[i] < x * WindowLength) 
                {                    
                    result = "irregularity"; // jeżeli występowały zmiany amplitud załamków R
                    Rerror++;
                }
            }
            for (int i = 0; i < RTime.Count; i++)
            {
                if (RTime[i] >= y * WindowLength && RTime[i] <= x * WindowLength && ListOfPeaks[i] != 0)
                {
                    R++;
                }
            }

            double perMinute = 60 / WindowLength;
            HeartRate = R * perMinute;
            if (PhysioNet)
            {
                if (result == "noise" || result == "irregularity") HeartRate = HeartRate - 400; ;
            }
            else
            {
                if (result == "noise") HeartRate = 0;
                else if (result == "irregularity") HeartRate = HeartRate - 400;
            }                      
            return HeartRate;
        }
    }
}
