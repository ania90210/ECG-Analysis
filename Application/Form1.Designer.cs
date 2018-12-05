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
            System.Windows.Forms.DataVisualization.Charting.AnnotationGroup annotationGroup2 = new System.Windows.Forms.DataVisualization.Charting.AnnotationGroup();
            System.Windows.Forms.DataVisualization.Charting.VerticalLineAnnotation verticalLineAnnotation2 = new System.Windows.Forms.DataVisualization.Charting.VerticalLineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title12 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title13 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title14 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title15 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title16 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title17 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title18 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title19 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title20 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title21 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title22 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EKGchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureChart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.SuspendLayout();
            // 
            // EKGchart
            // 
            verticalLineAnnotation2.LineColor = System.Drawing.Color.Maroon;
            verticalLineAnnotation2.Name = "VA";
            annotationGroup2.Annotations.Add(verticalLineAnnotation2);
            annotationGroup2.Name = "AnnotationGroup";
            this.EKGchart.Annotations.Add(annotationGroup2);
            this.EKGchart.BackColor = System.Drawing.Color.DarkGray;
            this.EKGchart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.EKGchart.BackSecondaryColor = System.Drawing.Color.Gainsboro;
            this.EKGchart.BorderlineColor = System.Drawing.Color.DarkGray;
            this.EKGchart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.EKGchart.BorderSkin.BackColor = System.Drawing.Color.DarkGray;
            this.EKGchart.BorderSkin.BorderColor = System.Drawing.Color.DarkGray;
            this.EKGchart.BorderSkin.BorderWidth = 0;
            chartArea6.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea6.Name = "ChartArea1";
            chartArea6.Position.Auto = false;
            chartArea6.Position.Height = 87F;
            chartArea6.Position.Width = 94F;
            chartArea6.Position.X = 3F;
            chartArea6.Position.Y = 6F;
            this.EKGchart.ChartAreas.Add(chartArea6);
            this.EKGchart.Location = new System.Drawing.Point(23, 102);
            this.EKGchart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EKGchart.Name = "EKGchart";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Color = System.Drawing.Color.Red;
            series7.Name = "EKG";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series8.Color = System.Drawing.Color.Blue;
            series8.Name = "Peaks";
            this.EKGchart.Series.Add(series7);
            this.EKGchart.Series.Add(series8);
            this.EKGchart.Size = new System.Drawing.Size(1318, 268);
            this.EKGchart.TabIndex = 1;
            this.EKGchart.Text = "chart1";
            title12.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title12.DockingOffset = 2;
            title12.Name = "Title1";
            title12.Text = "Czas [s]";
            title13.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title13.Name = "Title2";
            title13.Position.Auto = false;
            title13.Position.Height = 84.72366F;
            title13.Position.Width = 1.272423F;
            title13.Position.X = 3F;
            title13.Position.Y = 3F;
            title13.Text = "Amplituda [V]";
            title13.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            title14.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title14.DockingOffset = -3;
            title14.Name = "Title3";
            title14.Text = "EKG";
            this.EKGchart.Titles.Add(title12);
            this.EKGchart.Titles.Add(title13);
            this.EKGchart.Titles.Add(title14);
            // 
            // PressureChart1
            // 
            this.PressureChart1.BackColor = System.Drawing.Color.DarkGray;
            this.PressureChart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.PressureChart1.BackSecondaryColor = System.Drawing.Color.Gainsboro;
            this.PressureChart1.BorderlineColor = System.Drawing.Color.DarkGray;
            this.PressureChart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea7.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea7.Name = "ChartArea1";
            chartArea7.Position.Auto = false;
            chartArea7.Position.Height = 87F;
            chartArea7.Position.Width = 94F;
            chartArea7.Position.X = 3F;
            chartArea7.Position.Y = 6F;
            this.PressureChart1.ChartAreas.Add(chartArea7);
            this.PressureChart1.Location = new System.Drawing.Point(23, 393);
            this.PressureChart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PressureChart1.Name = "PressureChart1";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Name = "Pressure1";
            this.PressureChart1.Series.Add(series9);
            this.PressureChart1.Size = new System.Drawing.Size(1318, 268);
            this.PressureChart1.TabIndex = 3;
            this.PressureChart1.Text = "chart2";
            title15.Alignment = System.Drawing.ContentAlignment.BottomCenter;
            title15.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title15.DockingOffset = 2;
            title15.Name = "Title1";
            title15.Text = "Czas [s]";
            title16.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title16.Name = "Title2";
            title16.Position.Auto = false;
            title16.Position.Height = 84.72366F;
            title16.Position.Width = 1.272423F;
            title16.Position.X = 3F;
            title16.Position.Y = 3F;
            title16.Text = "Ciœnienie [Pa]";
            title16.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            title17.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title17.DockingOffset = -3;
            title17.Name = "Title3";
            title17.Text = "Poduszka I";
            this.PressureChart1.Titles.Add(title15);
            this.PressureChart1.Titles.Add(title16);
            this.PressureChart1.Titles.Add(title17);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.OpenFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFileButton.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OpenFileButton.ForeColor = System.Drawing.Color.Black;
            this.OpenFileButton.Location = new System.Drawing.Point(330, 27);
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
            this.WindowLength.Enabled = false;
            this.WindowLength.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowLength.FormattingEnabled = true;
            this.WindowLength.Items.AddRange(new object[] {
            "5",
            "10",
            "15"});
            this.WindowLength.Location = new System.Drawing.Point(696, 61);
            this.WindowLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WindowLength.Name = "WindowLength";
            this.WindowLength.Size = new System.Drawing.Size(119, 28);
            this.WindowLength.TabIndex = 5;
            this.WindowLength.Text = "5";
            this.WindowLength.SelectedIndexChanged += new System.EventHandler(this.WindowLength_SelectedIndexChanged);
            // 
            // PressureChart2
            // 
            this.PressureChart2.BackColor = System.Drawing.Color.DarkGray;
            this.PressureChart2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.PressureChart2.BackSecondaryColor = System.Drawing.Color.Gainsboro;
            this.PressureChart2.BorderlineColor = System.Drawing.Color.DarkGray;
            this.PressureChart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea8.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea8.Name = "ChartArea1";
            chartArea8.Position.Auto = false;
            chartArea8.Position.Height = 87F;
            chartArea8.Position.Width = 94F;
            chartArea8.Position.X = 3F;
            chartArea8.Position.Y = 6F;
            this.PressureChart2.ChartAreas.Add(chartArea8);
            this.PressureChart2.Location = new System.Drawing.Point(23, 686);
            this.PressureChart2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PressureChart2.Name = "PressureChart2";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.CustomProperties = "IsXAxisQuantitative=False";
            series10.Legend = "Legend1";
            series10.Name = "Pressure1";
            this.PressureChart2.Series.Add(series10);
            this.PressureChart2.Size = new System.Drawing.Size(1318, 268);
            this.PressureChart2.TabIndex = 7;
            this.PressureChart2.Text = "chart1";
            title18.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title18.DockingOffset = 2;
            title18.Name = "Title1";
            title18.Text = "Czas [s]";
            title19.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title19.Name = "Title2";
            title19.Position.Auto = false;
            title19.Position.Height = 84.72366F;
            title19.Position.Width = 1.272423F;
            title19.Position.X = 3F;
            title19.Position.Y = 3F;
            title19.Text = "Ciœnienie [Pa]";
            title19.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            title20.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title20.DockingOffset = -3;
            title20.Name = "Title3";
            title20.Text = "Poduszka II";
            this.PressureChart2.Titles.Add(title18);
            this.PressureChart2.Titles.Add(title19);
            this.PressureChart2.Titles.Add(title20);
            // 
            // PressureChart3
            // 
            this.PressureChart3.BackColor = System.Drawing.Color.DarkGray;
            this.PressureChart3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.PressureChart3.BackSecondaryColor = System.Drawing.Color.Gainsboro;
            this.PressureChart3.BorderlineColor = System.Drawing.Color.DarkGray;
            this.PressureChart3.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea9.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea9.Name = "ChartArea1";
            this.PressureChart3.ChartAreas.Add(chartArea9);
            this.PressureChart3.Location = new System.Drawing.Point(1374, 323);
            this.PressureChart3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PressureChart3.Name = "PressureChart3";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series11.Name = "Pressure1";
            this.PressureChart3.Series.Add(series11);
            this.PressureChart3.Size = new System.Drawing.Size(599, 242);
            this.PressureChart3.TabIndex = 8;
            this.PressureChart3.Text = "chart1";
            title21.Name = "Title1";
            this.PressureChart3.Titles.Add(title21);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Start.Location = new System.Drawing.Point(1520, 34);
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
            this.chart4.BackColor = System.Drawing.Color.DarkGray;
            this.chart4.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart4.BackSecondaryColor = System.Drawing.Color.Gainsboro;
            this.chart4.BorderlineColor = System.Drawing.Color.DarkGray;
            this.chart4.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea10.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea10.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea10);
            this.chart4.Location = new System.Drawing.Point(1374, 478);
            this.chart4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart4.Name = "chart4";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series12.Name = "Pressure1";
            this.chart4.Series.Add(series12);
            this.chart4.Size = new System.Drawing.Size(599, 242);
            this.chart4.TabIndex = 12;
            this.chart4.Text = "chart1";
            title22.Name = "Title1";
            this.chart4.Titles.Add(title22);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listView1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(1364, 171);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 25, 3, 25);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(609, 368);
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
            this.columnHeader2.Text = "Puls";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ocena";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 250;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(660, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Wybierz okno czasowe [s]";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveButton.Location = new System.Drawing.Point(1610, 820);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(164, 70);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "Zapisz wynik";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Application
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1924, 992);
            this.Controls.Add(this.saveButton);
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
            this.MaximumSize = new System.Drawing.Size(2554, 1310);
            this.Name = "Application";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button saveButton;
    }
}

