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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea109 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series109 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea110 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series110 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title73 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea111 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series111 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title74 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea112 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series112 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title75 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea113 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series113 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea114 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series114 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title76 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.EKGchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PressureChart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.WindowLength = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PressureChart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PressureChart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PressureChart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HeartRateLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.OknoLabel = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EKGchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.SuspendLayout();
            // 
            // EKGchart
            // 
            this.EKGchart.BackColor = System.Drawing.Color.Lavender;
            chartArea109.Name = "ChartArea1";
            this.EKGchart.ChartAreas.Add(chartArea109);
            this.EKGchart.Location = new System.Drawing.Point(779, 1);
            this.EKGchart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EKGchart.Name = "EKGchart";
            series109.ChartArea = "ChartArea1";
            series109.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series109.Color = System.Drawing.Color.Red;
            series109.Name = "EKG";
            this.EKGchart.Series.Add(series109);
            this.EKGchart.Size = new System.Drawing.Size(741, 233);
            this.EKGchart.TabIndex = 1;
            this.EKGchart.Text = "chart1";
            // 
            // PressureChart1
            // 
            this.PressureChart1.BackColor = System.Drawing.Color.Lavender;
            chartArea110.BackColor = System.Drawing.Color.White;
            chartArea110.Name = "ChartArea1";
            this.PressureChart1.ChartAreas.Add(chartArea110);
            this.PressureChart1.Location = new System.Drawing.Point(-1, 1);
            this.PressureChart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PressureChart1.Name = "PressureChart1";
            series110.ChartArea = "ChartArea1";
            series110.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series110.Name = "Pressure1";
            this.PressureChart1.Series.Add(series110);
            this.PressureChart1.Size = new System.Drawing.Size(757, 233);
            this.PressureChart1.TabIndex = 3;
            this.PressureChart1.Text = "chart2";
            title73.Name = "Title1";
            this.PressureChart1.Titles.Add(title73);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.OpenFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFileButton.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OpenFileButton.ForeColor = System.Drawing.Color.Black;
            this.OpenFileButton.Location = new System.Drawing.Point(919, 238);
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
            this.WindowLength.Location = new System.Drawing.Point(1245, 272);
            this.WindowLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WindowLength.Name = "WindowLength";
            this.WindowLength.Size = new System.Drawing.Size(119, 28);
            this.WindowLength.TabIndex = 5;
            this.WindowLength.Text = "10";
            this.WindowLength.SelectedIndexChanged += new System.EventHandler(this.WindowLength_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1199, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Wybierz okno czasowe [s]";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // PressureChart2
            // 
            this.PressureChart2.BackColor = System.Drawing.Color.Lavender;
            chartArea111.Name = "ChartArea1";
            this.PressureChart2.ChartAreas.Add(chartArea111);
            this.PressureChart2.Location = new System.Drawing.Point(-1, 252);
            this.PressureChart2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PressureChart2.Name = "PressureChart2";
            series111.ChartArea = "ChartArea1";
            series111.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series111.CustomProperties = "IsXAxisQuantitative=False";
            series111.Legend = "Legend1";
            series111.Name = "Pressure1";
            this.PressureChart2.Series.Add(series111);
            this.PressureChart2.Size = new System.Drawing.Size(757, 233);
            this.PressureChart2.TabIndex = 7;
            this.PressureChart2.Text = "chart1";
            title74.Name = "Title1";
            this.PressureChart2.Titles.Add(title74);
            // 
            // PressureChart3
            // 
            this.PressureChart3.BackColor = System.Drawing.Color.Lavender;
            chartArea112.Name = "ChartArea1";
            this.PressureChart3.ChartAreas.Add(chartArea112);
            this.PressureChart3.Location = new System.Drawing.Point(-1, 503);
            this.PressureChart3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PressureChart3.Name = "PressureChart3";
            series112.ChartArea = "ChartArea1";
            series112.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series112.Name = "Pressure1";
            this.PressureChart3.Series.Add(series112);
            this.PressureChart3.Size = new System.Drawing.Size(757, 233);
            this.PressureChart3.TabIndex = 8;
            this.PressureChart3.Text = "chart1";
            title75.Name = "Title1";
            this.PressureChart3.Titles.Add(title75);
            // 
            // PressureChart4
            // 
            this.PressureChart4.BackColor = System.Drawing.Color.Lavender;
            chartArea113.Name = "ChartArea1";
            this.PressureChart4.ChartAreas.Add(chartArea113);
            this.PressureChart4.Location = new System.Drawing.Point(-1, 748);
            this.PressureChart4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PressureChart4.Name = "PressureChart4";
            series113.ChartArea = "ChartArea1";
            series113.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series113.Name = "Series1";
            this.PressureChart4.Series.Add(series113);
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
            this.panel1.Location = new System.Drawing.Point(944, 891);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 151);
            this.panel1.TabIndex = 10;
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
            this.Start.Location = new System.Drawing.Point(1063, 320);
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
            chartArea114.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea114);
            this.chart4.Location = new System.Drawing.Point(779, 374);
            this.chart4.Name = "chart4";
            series114.ChartArea = "ChartArea1";
            series114.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series114.Name = "Series1";
            this.chart4.Series.Add(series114);
            this.chart4.Size = new System.Drawing.Size(679, 260);
            this.chart4.TabIndex = 12;
            this.chart4.Text = "chart1";
            title76.Name = "Title1";
            this.chart4.Titles.Add(title76);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listView1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(919, 653);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(376, 198);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1344, 667);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 21);
            this.button1.TabIndex = 14;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Application
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1521, 1040);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.chart4);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PressureChart4);
            this.Controls.Add(this.PressureChart3);
            this.Controls.Add(this.PressureChart2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WindowLength);
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
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart EKGchart;
        private System.Windows.Forms.DataVisualization.Charting.Chart PressureChart1;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.ComboBox WindowLength;
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Timer timer1;
    }
}

