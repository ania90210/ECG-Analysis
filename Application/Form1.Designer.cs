namespace Application
{
    partial class Application
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.EKGchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PressureChart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PressureChart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PressureChart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PressureChart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.OknoLabel = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.HeartRateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EKGchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart4)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EKGchart
            // 
            this.EKGchart.BackColor = System.Drawing.Color.Lavender;
            chartArea11.Name = "ChartArea1";
            this.EKGchart.ChartAreas.Add(chartArea11);
            this.EKGchart.Location = new System.Drawing.Point(779, 24);
            this.EKGchart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EKGchart.Name = "EKGchart";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series11.Color = System.Drawing.Color.Red;
            series11.Name = "EKG";
            this.EKGchart.Series.Add(series11);
            this.EKGchart.Size = new System.Drawing.Size(741, 233);
            this.EKGchart.TabIndex = 1;
            this.EKGchart.Text = "chart1";
            // 
            // PressureChart1
            // 
            this.PressureChart1.BackColor = System.Drawing.Color.Lavender;
            chartArea12.BackColor = System.Drawing.Color.White;
            chartArea12.Name = "ChartArea1";
            this.PressureChart1.ChartAreas.Add(chartArea12);
            this.PressureChart1.Location = new System.Drawing.Point(-1, 24);
            this.PressureChart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PressureChart1.Name = "PressureChart1";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series12.Name = "Pressure1";
            this.PressureChart1.Series.Add(series12);
            this.PressureChart1.Size = new System.Drawing.Size(757, 233);
            this.PressureChart1.TabIndex = 3;
            this.PressureChart1.Text = "chart2";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.OpenFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFileButton.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OpenFileButton.ForeColor = System.Drawing.Color.Black;
            this.OpenFileButton.Location = new System.Drawing.Point(919, 273);
            this.OpenFileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(155, 62);
            this.OpenFileButton.TabIndex = 4;
            this.OpenFileButton.Text = "Wybierz plik";
            this.OpenFileButton.UseVisualStyleBackColor = false;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click_1);
            // 
            // comboBox
            // 
            this.comboBox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "5",
            "10",
            "15"});
            this.comboBox.Location = new System.Drawing.Point(1251, 307);
            this.comboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(119, 28);
            this.comboBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1207, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Wybierz okno czasowe [s]";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // PressureChart2
            // 
            this.PressureChart2.BackColor = System.Drawing.Color.Lavender;
            chartArea13.Name = "ChartArea1";
            this.PressureChart2.ChartAreas.Add(chartArea13);
            this.PressureChart2.Location = new System.Drawing.Point(-1, 290);
            this.PressureChart2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PressureChart2.Name = "PressureChart2";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series13.CustomProperties = "IsXAxisQuantitative=False";
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            this.PressureChart2.Series.Add(series13);
            this.PressureChart2.Size = new System.Drawing.Size(757, 233);
            this.PressureChart2.TabIndex = 7;
            this.PressureChart2.Text = "chart1";
            // 
            // PressureChart3
            // 
            this.PressureChart3.BackColor = System.Drawing.Color.Lavender;
            chartArea14.Name = "ChartArea1";
            this.PressureChart3.ChartAreas.Add(chartArea14);
            this.PressureChart3.Location = new System.Drawing.Point(-1, 551);
            this.PressureChart3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PressureChart3.Name = "PressureChart3";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series14.Name = "Series1";
            this.PressureChart3.Series.Add(series14);
            this.PressureChart3.Size = new System.Drawing.Size(757, 233);
            this.PressureChart3.TabIndex = 8;
            this.PressureChart3.Text = "chart1";
            // 
            // PressureChart4
            // 
            this.PressureChart4.BackColor = System.Drawing.Color.Lavender;
            chartArea15.Name = "ChartArea1";
            this.PressureChart4.ChartAreas.Add(chartArea15);
            this.PressureChart4.Location = new System.Drawing.Point(-1, 809);
            this.PressureChart4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PressureChart4.Name = "PressureChart4";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series15.Name = "Series1";
            this.PressureChart4.Series.Add(series15);
            this.PressureChart4.Size = new System.Drawing.Size(757, 233);
            this.PressureChart4.TabIndex = 9;
            this.PressureChart4.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.HeartRateLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ResultLabel);
            this.panel1.Controls.Add(this.OknoLabel);
            this.panel1.Location = new System.Drawing.Point(952, 494);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 320);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(109, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 322);
            this.panel2.TabIndex = 11;
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ResultLabel.Location = new System.Drawing.Point(244, 8);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(57, 20);
            this.ResultLabel.TabIndex = 1;
            this.ResultLabel.Text = "Wynik";
            // 
            // OknoLabel
            // 
            this.OknoLabel.AutoSize = true;
            this.OknoLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OknoLabel.Location = new System.Drawing.Point(20, 8);
            this.OknoLabel.Name = "OknoLabel";
            this.OknoLabel.Size = new System.Drawing.Size(49, 20);
            this.OknoLabel.TabIndex = 0;
            this.OknoLabel.Text = "Okno";
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.SpringGreen;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Start.Location = new System.Drawing.Point(1071, 384);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(197, 48);
            this.Start.TabIndex = 11;
            this.Start.Text = "Rozpocznij analizê";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Heart Rate";
            // 
            // HeartRateLabel
            // 
            this.HeartRateLabel.AutoSize = true;
            this.HeartRateLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HeartRateLabel.ForeColor = System.Drawing.Color.Navy;
            this.HeartRateLabel.Location = new System.Drawing.Point(254, 69);
            this.HeartRateLabel.Name = "HeartRateLabel";
            this.HeartRateLabel.Size = new System.Drawing.Size(41, 20);
            this.HeartRateLabel.TabIndex = 13;
            this.HeartRateLabel.Text = "bpm";
            // 
            // Application
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1521, 1040);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PressureChart4);
            this.Controls.Add(this.PressureChart3);
            this.Controls.Add(this.PressureChart2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.PressureChart1);
            this.Controls.Add(this.EKGchart);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1942, 1087);
            this.Name = "Application";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Okno";
            this.Load += new System.EventHandler(this.Application_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EKGchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart EKGchart;
        private System.Windows.Forms.DataVisualization.Charting.Chart PressureChart1;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart PressureChart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart PressureChart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart PressureChart4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Label OknoLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label HeartRateLabel;
        private System.Windows.Forms.Label label2;
    }
}

