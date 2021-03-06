﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Application
{
    class DrawGraphs
    {
        string[] column;
        public void Graphs(double Fs, string[] lines, Chart EKGchart, Chart PressureChart1, Chart PressureChart2, int SamplesToAnalise, 
            int PressureSamples, List<double> time, List<double> amplitude, int Window, List<double> Pressure1, List<double> timeP1, 
            List<double> Pressure2, List<double> timeP2, bool eChair, bool PhysioNet)
        {
            double Ts = 1 / Fs;

            for (int i = 0; i < SamplesToAnalise; i++)
            {
                lines[i] = lines[i].Replace('.', ',');
                column = lines[i].Split(' ', '\t');

               if(eChair) amplitude.Add(Double.Parse(column[0])); // weź pierwszą kolumnę z wartościami
               else if(PhysioNet) amplitude.Add(Double.Parse(column[1])); // weź drugą kolumnę z wartościami

               if (i!=SamplesToAnalise-1) time.Add(i * Ts);
               else time.Add(Math.Round(time[SamplesToAnalise - 2]));

            }

            // wykres EKG
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
                EKGchart.Series["EKG"].Points.AddXY(time[i], amplitude[i]);
                if (time[i] % Window == 0)
                {
                    VerticalLine(EKGchart, i, time);
                }
            }

            if (eChair)
            {
                // Poduszka I
                for (int i = 0; i < PressureSamples; i++)
                {
                    lines[i] = lines[i].Replace('.', ',');
                    column = lines[i].Split(' ', '\t');

                    Pressure1.Add(Double.Parse(column[1]));
                    if (i != PressureSamples-1) timeP1.Add(i* Ts);
                    else timeP1.Add(Math.Round(timeP1[PressureSamples - 2]));
                }

                var chartP = PressureChart1.ChartAreas[0];
                PressureChart1.Series["Pressure1"].Color = Color.Blue;
                chartP.AxisY.Minimum = 0;
                chartP.AxisY.Maximum = 20;
                chartP.AxisX.Minimum = 0;
                chartP.AxisX.Maximum = Math.Round(timeP1[PressureSamples - 1]);
                chartP.AxisX.Interval = 1;
                chartP.AxisX.IntervalOffset = 0;
                chartP.AxisX.ScaleView.Zoom(0, 11);
                chartP.AxisX.LabelStyle.Format = "#";
                chartP.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
                chartP.AxisX.ScaleView.SmallScrollSize = 5;
                PressureChart1.Series[0].ChartType = SeriesChartType.FastLine;

                for (int i = 0; i < PressureSamples; i++)
                {
                    PressureChart1.Series["Pressure1"].Points.AddXY(timeP1[i], Pressure1[i]);
                    if (timeP1[i] % Window == 0)
                    {
                        VerticalLine(PressureChart1, i, timeP1);
                    }
                }

                //Poduszka II
                for (int i = 0; i < PressureSamples; i++)
                {
                    lines[i] = lines[i].Replace('.', ',');
                    column = lines[i].Split(' ', '\t');

                    Pressure2.Add(Double.Parse(column[2]));
                    if (i != PressureSamples - 1) timeP2.Add(i * Ts);
                    else timeP2.Add(Math.Round(timeP2[PressureSamples - 2]));
                }

                var chartP2 = PressureChart2.ChartAreas[0];
                PressureChart2.Series["Pressure1"].Color = Color.Blue;
                chartP2.AxisY.Minimum = 0;
                chartP2.AxisY.Maximum = 20;
                chartP2.AxisX.Minimum = 0;
                chartP2.AxisX.Interval = 5;
                chartP2.AxisX.Maximum = Math.Round(timeP2[PressureSamples - 1]);
                chartP2.AxisX.Interval = 1;
                chartP2.AxisX.IntervalOffset = 0;
                chartP2.AxisX.ScaleView.Zoom(0, 11);
                chartP2.AxisX.LabelStyle.Format = "#";
                chartP2.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
                chartP2.AxisX.ScaleView.SmallScrollSize = 5;
                PressureChart2.Series[0].ChartType = SeriesChartType.FastLine;

                for (int i = 0; i < PressureSamples; i++)
                {
                    PressureChart2.Series["Pressure1"].Points.AddXY(timeP2[i], Pressure2[i]);
                    if (timeP2[i] % Window == 0)
                    {
                        VerticalLine(PressureChart2, i, timeP2);
                    }
                }
            }
        }
        // metoda rysująca podziałki
        public void VerticalLine(Chart chart, int x, List<double> time)
        {
            VerticalLineAnnotation VA = new VerticalLineAnnotation();
            VA.AxisX = chart.ChartAreas[0].AxisX;
            VA.AllowMoving = false;
            VA.Visible = true;
            VA.AnchorOffsetX = 0;
            VA.IsInfinitive = true;
            VA.LineColor = Color.BlueViolet;
            VA.LineWidth = 1;
            VA.X = time[x];
            chart.Annotations.Add(VA);
        }
    }
}
