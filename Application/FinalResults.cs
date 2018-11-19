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
        System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
        public void FinalResult(List<double> resultsPillow1, List<double> resultsECG, ListView listView1, int Window)
        {
            string wynik = "";

            for (int i = 0; i < resultsECG.Count; i++) //resultsPillow
            {

                double HR = resultsECG[i];
                var result = new ListViewItem();

                /*
                 if (resultsPillow1 < 1 && resultsPillow2 < 1) // jezeli nikt nie siedzi
                 {
                 wynik = "nikt nie siedzi"
                 HR = 0;
                 }
                 * if (resultsPillow1[i] >= 10) // movement && resultsPillow2[i] >= 10
                {
                    if (HR >= 60 && HR <= 90) wynik = "wszystko OK";
                    if (HR < 60) wynik = "rusza sie ale HR za male";
                    if (HR > 90) wynik = "ekscytuje sie/ rusza";
                    if (HR == -1) wynik = "zmiana pozycji"; 
                }
                if (resultsPillow1[i] < 10) // no movement
                {
                    if (HR >= 60 && HR <= 90) wynik = "wszystko OK";
                    if (HR < 60) wynik = "tetno za male";
                    if (HR > 90) wynik = "ZAWAL/ STRES";
                    if (HR == -1) wynik = "COS SIE DZIEJE!?";
                }*/
                if (HR >= 60 && HR <= 90) wynik = "wszystko OK";
                else if (HR > 40 && HR < 60) wynik = "Puls jest za niski / śpi";
                else if (HR > 90 && HR < 120) wynik = "Puls jest za wysoki / stres";
                else if (HR == -1) wynik = "COS SIE DZIEJE!?";
               // else wynik = "błąd";

                string WindowTime = " [" + i * Window + " - " + (i + 1) * Window + "s]";
                if (HR == -1) result = new ListViewItem(new[] { (i + 1).ToString() + WindowTime, " ?  bpm", wynik });
                else result = new ListViewItem(new[] { (i + 1).ToString() + WindowTime, HR.ToString() + " bpm", wynik });
                if (!watch.IsRunning)
                    watch.Restart();
                listView1.Items.Add(result);
                watch.Stop();
                Console.WriteLine($"listView1.Items.Add(result); Execution Time: {watch.ElapsedMilliseconds} ms");
                result.ForeColor = (HR > 59 && HR < 91) ? Color.ForestGreen : Color.Red;
            }
        }
    }
}
