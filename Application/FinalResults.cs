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
        public void FinalResult(List<double> resultsPillow1, List<double> resultsPillow2, List<double> resultsECG, ListView listView1, int Window)
        {
            string comment = "";

            for (int i = 0; i < resultsECG.Count; i++) //resultsPillow
            {

                double HR = resultsECG[i];
                var result = new ListViewItem();


                if (resultsPillow1[i] == 0 && resultsPillow2[i] == 0) // jezeli nikt nie siedzi
                {
                    comment = "Brak nacisku";
                    HR = 0;
                }

                else if (resultsPillow1[i] >= 4 && resultsPillow2[i] >= 4) // movement && resultsPillow2[i] >= 10
                {
                    if (HR >= 60 && HR <= 90) comment = "Wszystko OK";
                    else if (HR >= 40 && HR < 60) comment = "Tętno za małe";
                    else if (HR > 90 && HR < 110) comment = "Tętno za duże";
                    else if (HR == 0 || HR < 40) comment = "Zmiana pozycji";
                    else if (HR < 0 && HR + 200 < 40) {comment = "Zmiana pozycji"; HR = 0; }
                    else if (HR < 0) { comment = "Arytmia serca"; HR = HR + 200; }
                }
               else if (resultsPillow1[i] < 4 && resultsPillow2[i] < 4) // no movement
                {
                    if (HR >= 60 && HR <= 90) comment = "Wszystko OK";
                    else if (HR >= 40 && HR < 60) comment = "Tętno za małe";
                    else if(HR > 90 && HR < 110) comment = "Tętno za duże";
                    else if (HR == 0 || HR < 40 || HR >= 110) comment = "ALERT!";
                    else if (HR < 0) { comment = "Arytmia serca"; HR = HR + 200; }
                }

                string WindowTime = " [" + i * Window + " - " + (i + 1) * Window + "s]";
                if (HR == 0 || comment == "Zmiana pozycji") result = new ListViewItem(new[] { (i + 1).ToString() + WindowTime, " ?  bpm", comment });
                else result = new ListViewItem(new[] { (i + 1).ToString() + WindowTime, HR.ToString() + " bpm", comment });
               
                listView1.Items.Add(result);
                result.ForeColor = (comment == "Wszystko OK" || comment == "Zmiana pozycji") ? Color.ForestGreen : Color.Red;
            }
        }
    }
}
