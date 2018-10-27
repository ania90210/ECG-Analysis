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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            chartArea1.Name = "ChartArea1";
            this.EKGchart.ChartAreas.Add(chartArea1);
            this.EKGchart.Location = new System.Drawing.Point(861, 11);
            this.EKGchart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EKGchart.Name = "EKGchart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "EKG";
            this.EKGchart.Series.Add(series1);
            this.EKGchart.Size = new System.Drawing.Size(594, 189);
            this.EKGchart.TabIndex = 1;
            this.EKGchart.Text = "chart1";
            // 
            // PressureChart1
            // 
            this.PressureChart1.BackColor = System.Drawing.Color.Lavender;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.PressureChart1.ChartAreas.Add(chartArea2);
            this.PressureChart1.Location = new System.Drawing.Point(230, 11);
            this.PressureChart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PressureChart1.Name = "PressureChart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Name = "Pressure1";
            this.PressureChart1.Series.Add(series2);
            this.PressureChart1.Size = new System.Drawing.Size(568, 189);
            this.PressureChart1.TabIndex = 3;
            this.PressureChart1.Text = "chart2";
            title1.Name = "Title1";
            this.PressureChart1.Titles.Add(title1);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.OpenFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFileButton.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OpenFileButton.ForeColor = System.Drawing.Color.Black;
            this.OpenFileButton.Location = new System.Drawing.Point(48, 266);
            this.OpenFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(116, 50);
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
            this.WindowLength.Location = new System.Drawing.Point(62, 431);
            this.WindowLength.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WindowLength.Name = "WindowLength";
            this.WindowLength.Size = new System.Drawing.Size(90, 24);
            this.WindowLength.TabIndex = 5;
            this.WindowLength.Text = "10";
            this.WindowLength.SelectedIndexChanged += new System.EventHandler(this.WindowLength_SelectedIndexChanged);
            // 
            // PressureChart2
            // 
            this.PressureChart2.BackColor = System.Drawing.Color.Lavender;
            chartArea3.Name = "ChartArea1";
            this.PressureChart2.ChartAreas.Add(chartArea3);
            this.PressureChart2.Location = new System.Drawing.Point(230, 204);
            this.PressureChart2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PressureChart2.Name = "PressureChart2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.CustomProperties = "IsXAxisQuantitative=False";
            series3.Legend = "Legend1";
            series3.Name = "Pressure1";
            this.PressureChart2.Series.Add(series3);
            this.PressureChart2.Size = new System.Drawing.Size(568, 189);
            this.PressureChart2.TabIndex = 7;
            this.PressureChart2.Text = "chart1";
            title2.Name = "Title1";
            this.PressureChart2.Titles.Add(title2);
            // 
            // PressureChart3
            // 
            this.PressureChart3.BackColor = System.Drawing.Color.Lavender;
            chartArea4.Name = "ChartArea1";
            this.PressureChart3.ChartAreas.Add(chartArea4);
            this.PressureChart3.Location = new System.Drawing.Point(230, 401);
            this.PressureChart3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PressureChart3.Name = "PressureChart3";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Name = "Pressure1";
            this.PressureChart3.Series.Add(series4);
            this.PressureChart3.Size = new System.Drawing.Size(568, 189);
            this.PressureChart3.TabIndex = 8;
            this.PressureChart3.Text = "chart1";
            title3.Name = "Title1";
            this.PressureChart3.Titles.Add(title3);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Start.Location = new System.Drawing.Point(1111, 266);
            this.Start.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(148, 39);
            this.Start.TabIndex = 11;
            this.Start.Text = "Rozpocznij analiz�";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // chart4
            // 
            this.chart4.BackColor = System.Drawing.Color.Lavender;
            chartArea5.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea5);
            this.chart4.Location = new System.Drawing.Point(230, 594);
            this.chart4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chart4.Name = "chart4";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series5.Name = "Pressure1";
            this.chart4.Series.Add(series5);
            this.chart4.Size = new System.Drawing.Size(568, 189);
            this.chart4.TabIndex = 12;
            this.chart4.Text = "chart1";
            title4.Name = "Title1";
            this.chart4.Titles.Add(title4);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listView1.ForeColor = System.Drawing.Color.Honeydew;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(997, 380);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 20, 2, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(458, 337);
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
            this.columnHeader3.Text = "Pillow";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 250;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(28, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Wybierz okno czasowe [s]";
            // 
            // Application
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(1534, 845);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1920, 1074);
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

