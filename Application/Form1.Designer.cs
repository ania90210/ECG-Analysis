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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title8 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.EKGchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PressureChart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.WindowLength = new System.Windows.Forms.ComboBox();
            this.PressureChart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PressureChart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Start = new System.Windows.Forms.Button();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EKGchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.SuspendLayout();
            // 
            // EKGchart
            // 
            this.EKGchart.BackColor = System.Drawing.Color.Lavender;
            chartArea6.Name = "ChartArea1";
            this.EKGchart.ChartAreas.Add(chartArea6);
            this.EKGchart.Location = new System.Drawing.Point(1148, 14);
            this.EKGchart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EKGchart.Name = "EKGchart";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Color = System.Drawing.Color.Red;
            series6.Name = "EKG";
            this.EKGchart.Series.Add(series6);
            this.EKGchart.Size = new System.Drawing.Size(792, 233);
            this.EKGchart.TabIndex = 1;
            this.EKGchart.Text = "chart1";
            // 
            // PressureChart1
            // 
            this.PressureChart1.BackColor = System.Drawing.Color.Lavender;
            chartArea7.BackColor = System.Drawing.Color.White;
            chartArea7.Name = "ChartArea1";
            this.PressureChart1.ChartAreas.Add(chartArea7);
            this.PressureChart1.Location = new System.Drawing.Point(307, 14);
            this.PressureChart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PressureChart1.Name = "PressureChart1";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Name = "Pressure1";
            this.PressureChart1.Series.Add(series7);
            this.PressureChart1.Size = new System.Drawing.Size(757, 233);
            this.PressureChart1.TabIndex = 3;
            this.PressureChart1.Text = "chart2";
            title5.Name = "Title1";
            this.PressureChart1.Titles.Add(title5);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.OpenFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFileButton.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OpenFileButton.ForeColor = System.Drawing.Color.Black;
            this.OpenFileButton.Location = new System.Drawing.Point(64, 327);
            this.OpenFileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(155, 62);
            this.OpenFileButton.TabIndex = 4;
            this.OpenFileButton.Text = "Wybierz plik";
            this.OpenFileButton.UseVisualStyleBackColor = false;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click_1);
            // 
            // WindowLength
            // 
            this.WindowLength.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowLength.FormattingEnabled = true;
            this.WindowLength.Items.AddRange(new object[] {
            "5",
            "10",
            "15"});
            this.WindowLength.Location = new System.Drawing.Point(83, 530);
            this.WindowLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WindowLength.Name = "WindowLength";
            this.WindowLength.Size = new System.Drawing.Size(119, 28);
            this.WindowLength.TabIndex = 5;
            this.WindowLength.Text = "10";
            this.WindowLength.SelectedIndexChanged += new System.EventHandler(this.WindowLength_SelectedIndexChanged);
            // 
            // PressureChart2
            // 
            this.PressureChart2.BackColor = System.Drawing.Color.Lavender;
            chartArea8.Name = "ChartArea1";
            this.PressureChart2.ChartAreas.Add(chartArea8);
            this.PressureChart2.Location = new System.Drawing.Point(307, 251);
            this.PressureChart2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PressureChart2.Name = "PressureChart2";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.CustomProperties = "IsXAxisQuantitative=False";
            series8.Legend = "Legend1";
            series8.Name = "Pressure1";
            this.PressureChart2.Series.Add(series8);
            this.PressureChart2.Size = new System.Drawing.Size(757, 233);
            this.PressureChart2.TabIndex = 7;
            this.PressureChart2.Text = "chart1";
            title6.Name = "Title1";
            this.PressureChart2.Titles.Add(title6);
            // 
            // PressureChart3
            // 
            this.PressureChart3.BackColor = System.Drawing.Color.Lavender;
            chartArea9.Name = "ChartArea1";
            this.PressureChart3.ChartAreas.Add(chartArea9);
            this.PressureChart3.Location = new System.Drawing.Point(307, 494);
            this.PressureChart3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PressureChart3.Name = "PressureChart3";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Name = "Pressure1";
            this.PressureChart3.Series.Add(series9);
            this.PressureChart3.Size = new System.Drawing.Size(757, 233);
            this.PressureChart3.TabIndex = 8;
            this.PressureChart3.Text = "chart1";
            title7.Name = "Title1";
            this.PressureChart3.Titles.Add(title7);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Start.Location = new System.Drawing.Point(1481, 327);
            this.Start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(197, 48);
            this.Start.TabIndex = 11;
            this.Start.Text = "Rozpocznij analizê";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // chart4
            // 
            this.chart4.BackColor = System.Drawing.Color.Lavender;
            chartArea10.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea10);
            this.chart4.Location = new System.Drawing.Point(307, 731);
            this.chart4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart4.Name = "chart4";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series10.Name = "Pressure1";
            this.chart4.Series.Add(series10);
            this.chart4.Size = new System.Drawing.Size(757, 233);
            this.chart4.TabIndex = 12;
            this.chart4.Text = "chart1";
            title8.Name = "Title1";
            this.chart4.Titles.Add(title8);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listView1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(1329, 468);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 25, 3, 25);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(609, 414);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nr okna";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Heart rate";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Wynik";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 250;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(37, 494);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Wybierz okno czasowe [s]";
            // 
            // Application
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(1924, 1040);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.chart4);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.PressureChart3);
            this.Controls.Add(this.PressureChart2);
            this.Controls.Add(this.WindowLength);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.PressureChart1);
            this.Controls.Add(this.EKGchart);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(2554, 1311);
            this.Name = "Application";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Okno";
            this.Load += new System.EventHandler(this.Application_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EKGchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart EKGchart;
        private System.Windows.Forms.DataVisualization.Charting.Chart PressureChart1;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.ComboBox WindowLength;
        private System.Windows.Forms.DataVisualization.Charting.Chart PressureChart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart PressureChart3;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

