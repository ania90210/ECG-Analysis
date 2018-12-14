using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Application
{
    class SaveResults
    {
        public void Save(ListView ListView1, Chart chart)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Zapisz folder z wynikami",
                FileName = "",
                FilterIndex = 0,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(sfd.FileName) && !File.Exists(sfd.FileName))
                {
                    Directory.CreateDirectory(sfd.FileName);

                    string[] headers = ListView1.Columns
                         .OfType<ColumnHeader>()
                         .Select(header => header.Text.Trim())
                         .ToArray();

                    string[][] items = ListView1.Items
                                .OfType<ListViewItem>()
                                .Select(lvi => lvi.SubItems
                                    .OfType<ListViewItem.ListViewSubItem>()
                                    .Select(si => si.Text).ToArray()).ToArray();

                    string table = string.Join(",     ", headers) + Environment.NewLine;
                    foreach (string[] a in items)
                    {
                        table += string.Join(",     ", a) + Environment.NewLine;
                    }
                    table = table.TrimEnd('\r', '\n');
                    File.WriteAllText(sfd.FileName + "\\wynik.csv", table);
                    chart.SaveImage(sfd.FileName + "\\wynik.jpeg", ImageFormat.Jpeg);
                }
                else
                {
                    MessageBox.Show("Zmień nazwę");
                    return;
                }
            }
        }
    }
}