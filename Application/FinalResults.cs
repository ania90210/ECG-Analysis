using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application
{
    class FinalResults
    {
        ListViewItem result = new ListViewItem();
        double HeartRate;

        public void FinalResult(List<double> resultsPillow1, List<double> resultsPillow2, List<double> resultsECG, ListView listView1, int Window)
        {
            string comment = "";

            for (int i = 0; i < resultsECG.Count; i++) //resultsPillow
            {

                HeartRate = resultsECG[i];

                if (resultsPillow1[i] == 0 && resultsPillow2[i] == 0) // jezeli nikt nie siedzi
                {
                    comment = "Brak nacisku";
                    HeartRate = 0;
                }

                else if (resultsPillow1[i] >= 4 && resultsPillow2[i] >= 4) // movement && resultsPillow2[i] >= 10
                {
                    if (HeartRate >= 60 && HeartRate <= 90) comment = "Wszystko OK";
                    else if (HeartRate >= 40 && HeartRate < 60) comment = "Tętno za małe";
                    else if (HeartRate > 90 && HeartRate < 110) comment = "Tętno za duże";
                    else if (HeartRate == 0 || HeartRate < 40) comment = "Zmiana pozycji";
                    else if (HeartRate < 0 && HeartRate + 200 < 40) {comment = "Zmiana pozycji"; HeartRate = 0; }
                    else if (HeartRate < 0) { comment = "Arytmia serca"; HeartRate = HeartRate + 200; }
                }
               else if (resultsPillow1[i] < 4 && resultsPillow2[i] < 4) // no movement
                {
                    if (HeartRate >= 60 && HeartRate <= 90) comment = "Wszystko OK";
                    else if (HeartRate >= 40 && HeartRate < 60) comment = "Tętno za małe";
                    else if(HeartRate > 90 && HeartRate < 110) comment = "Tętno za duże";
                    else if (HeartRate == 0 || HeartRate < 40 || HeartRate >= 110) comment = "ALERT!";
                    else if (HeartRate < 0) { comment = "Arytmia serca"; HeartRate = HeartRate + 200; }
                }

                string WindowTime = " [" + i * Window + " - " + (i + 1) * Window + "s]";
                if (HeartRate == 0 || comment == "Zmiana pozycji") result = new ListViewItem(new[] { (i + 1).ToString() + WindowTime, " ?  bpm", comment });
                else result = new ListViewItem(new[] { (i + 1).ToString() + WindowTime, HeartRate.ToString() + " bpm", comment });
               
                listView1.Items.Add(result);
                result.ForeColor = (comment == "Wszystko OK" || comment == "Zmiana pozycji") ? Color.ForestGreen : Color.Red;
            }
        }
    }
}
