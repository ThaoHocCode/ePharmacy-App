using System.Windows.Forms;

namespace ePharmacy
{
    partial class ThongKeDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.btnMonthlyRevenue = new Guna.UI2.WinForms.Guna2Button();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.btnYearlyRevenue = new Guna.UI2.WinForms.Guna2Button();
            this.btnStaffRevenue = new Guna.UI2.WinForms.Guna2Button();
            this.btnCategoryRevenue = new Guna.UI2.WinForms.Guna2Button();
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblTotalOrdersTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPeriod = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPeriodTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalOrders = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblAvgRevenue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblAvgRevenueTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalRevenue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalRevenueTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelChart = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelButtons.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.panelButtons.Controls.Add(this.btnBack);
            this.panelButtons.Controls.Add(this.btnMonthlyRevenue);
            this.panelButtons.Controls.Add(this.btnExport);
            this.panelButtons.Controls.Add(this.btnYearlyRevenue);
            this.panelButtons.Controls.Add(this.btnStaffRevenue);
            this.panelButtons.Controls.Add(this.btnCategoryRevenue);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(281, 653);
            this.panelButtons.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(3, 383);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(272, 40);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Quay Lại";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnMonthlyRevenue
            // 
            this.btnMonthlyRevenue.BackColor = System.Drawing.Color.SteelBlue;
            this.btnMonthlyRevenue.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMonthlyRevenue.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMonthlyRevenue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMonthlyRevenue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMonthlyRevenue.FillColor = System.Drawing.Color.SteelBlue;
            this.btnMonthlyRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnMonthlyRevenue.ForeColor = System.Drawing.Color.White;
            this.btnMonthlyRevenue.Location = new System.Drawing.Point(3, 133);
            this.btnMonthlyRevenue.Name = "btnMonthlyRevenue";
            this.btnMonthlyRevenue.Size = new System.Drawing.Size(272, 40);
            this.btnMonthlyRevenue.TabIndex = 0;
            this.btnMonthlyRevenue.Text = "Doanh Thu Theo Tháng";
            this.btnMonthlyRevenue.Click += new System.EventHandler(this.btnMonthlyRevenue_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExport.FillColor = System.Drawing.Color.SeaGreen;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(3, 333);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(272, 40);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Xuất Báo Cáo";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnYearlyRevenue
            // 
            this.btnYearlyRevenue.BackColor = System.Drawing.Color.SteelBlue;
            this.btnYearlyRevenue.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnYearlyRevenue.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnYearlyRevenue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnYearlyRevenue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnYearlyRevenue.FillColor = System.Drawing.Color.SteelBlue;
            this.btnYearlyRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnYearlyRevenue.ForeColor = System.Drawing.Color.White;
            this.btnYearlyRevenue.Location = new System.Drawing.Point(3, 183);
            this.btnYearlyRevenue.Name = "btnYearlyRevenue";
            this.btnYearlyRevenue.Size = new System.Drawing.Size(272, 40);
            this.btnYearlyRevenue.TabIndex = 1;
            this.btnYearlyRevenue.Text = "Doanh Thu Theo Năm";
            this.btnYearlyRevenue.Click += new System.EventHandler(this.btnYearlyRevenue_Click);
            // 
            // btnStaffRevenue
            // 
            this.btnStaffRevenue.BackColor = System.Drawing.Color.SteelBlue;
            this.btnStaffRevenue.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStaffRevenue.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStaffRevenue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStaffRevenue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStaffRevenue.FillColor = System.Drawing.Color.SteelBlue;
            this.btnStaffRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnStaffRevenue.ForeColor = System.Drawing.Color.White;
            this.btnStaffRevenue.Location = new System.Drawing.Point(3, 283);
            this.btnStaffRevenue.Name = "btnStaffRevenue";
            this.btnStaffRevenue.Size = new System.Drawing.Size(272, 40);
            this.btnStaffRevenue.TabIndex = 3;
            this.btnStaffRevenue.Text = "Doanh Thu Theo Nhân Viên";
            this.btnStaffRevenue.Click += new System.EventHandler(this.btnStaffRevenue_Click);
            // 
            // btnCategoryRevenue
            // 
            this.btnCategoryRevenue.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCategoryRevenue.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCategoryRevenue.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCategoryRevenue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCategoryRevenue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCategoryRevenue.FillColor = System.Drawing.Color.SteelBlue;
            this.btnCategoryRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCategoryRevenue.ForeColor = System.Drawing.Color.White;
            this.btnCategoryRevenue.Location = new System.Drawing.Point(3, 233);
            this.btnCategoryRevenue.Name = "btnCategoryRevenue";
            this.btnCategoryRevenue.Size = new System.Drawing.Size(272, 40);
            this.btnCategoryRevenue.TabIndex = 2;
            this.btnCategoryRevenue.Text = "Doanh Thu Theo Danh Mục";
            this.btnCategoryRevenue.Click += new System.EventHandler(this.btnCategoryRevenue_Click);
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panelStats.Controls.Add(this.lblTotalOrdersTitle);
            this.panelStats.Controls.Add(this.lblPeriod);
            this.panelStats.Controls.Add(this.lblPeriodTitle);
            this.panelStats.Controls.Add(this.lblTotalOrders);
            this.panelStats.Controls.Add(this.lblAvgRevenue);
            this.panelStats.Controls.Add(this.lblAvgRevenueTitle);
            this.panelStats.Controls.Add(this.lblTotalRevenue);
            this.panelStats.Controls.Add(this.lblTotalRevenueTitle);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(281, 0);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(1071, 119);
            this.panelStats.TabIndex = 2;
            // 
            // lblTotalOrdersTitle
            // 
            this.lblTotalOrdersTitle.AutoSize = false;
            this.lblTotalOrdersTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTotalOrdersTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalOrdersTitle.Location = new System.Drawing.Point(360, 10);
            this.lblTotalOrdersTitle.Name = "lblTotalOrdersTitle";
            this.lblTotalOrdersTitle.Size = new System.Drawing.Size(169, 22);
            this.lblTotalOrdersTitle.TabIndex = 8;
            this.lblTotalOrdersTitle.Text = "TỔNG SỐ ĐƠN";
            this.lblTotalOrdersTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPeriod
            // 
            this.lblPeriod.BackColor = System.Drawing.Color.Transparent;
            this.lblPeriod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPeriod.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblPeriod.Location = new System.Drawing.Point(530, 48);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(84, 30);
            this.lblPeriod.TabIndex = 7;
            this.lblPeriod.Text = "05/2025";
            this.lblPeriod.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPeriodTitle
            // 
            this.lblPeriodTitle.AutoSize = false;
            this.lblPeriodTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPeriodTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPeriodTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblPeriodTitle.Location = new System.Drawing.Point(530, 10);
            this.lblPeriodTitle.Name = "lblPeriodTitle";
            this.lblPeriodTitle.Size = new System.Drawing.Size(161, 22);
            this.lblPeriodTitle.TabIndex = 6;
            this.lblPeriodTitle.Text = "THỜI GIAN";
            this.lblPeriodTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalOrders.Location = new System.Drawing.Point(360, 48);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(15, 30);
            this.lblTotalOrders.TabIndex = 5;
            this.lblTotalOrders.Text = "0 ";
            this.lblTotalOrders.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAvgRevenue
            // 
            this.lblAvgRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lblAvgRevenue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAvgRevenue.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblAvgRevenue.Location = new System.Drawing.Point(190, 48);
            this.lblAvgRevenue.Name = "lblAvgRevenue";
            this.lblAvgRevenue.Size = new System.Drawing.Size(65, 30);
            this.lblAvgRevenue.TabIndex = 3;
            this.lblAvgRevenue.Text = "0 VNĐ";
            this.lblAvgRevenue.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAvgRevenueTitle
            // 
            this.lblAvgRevenueTitle.AutoSize = false;
            this.lblAvgRevenueTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAvgRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblAvgRevenueTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblAvgRevenueTitle.Location = new System.Drawing.Point(190, 10);
            this.lblAvgRevenueTitle.Name = "lblAvgRevenueTitle";
            this.lblAvgRevenueTitle.Size = new System.Drawing.Size(278, 22);
            this.lblAvgRevenueTitle.TabIndex = 2;
            this.lblAvgRevenueTitle.Text = "TRUNG BÌNH/ĐƠN";
            this.lblAvgRevenueTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalRevenue.Location = new System.Drawing.Point(20, 48);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(65, 30);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "0 VNĐ";
            this.lblTotalRevenue.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalRevenueTitle
            // 
            this.lblTotalRevenueTitle.AutoSize = false;
            this.lblTotalRevenueTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTotalRevenueTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalRevenueTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTotalRevenueTitle.Name = "lblTotalRevenueTitle";
            this.lblTotalRevenueTitle.Size = new System.Drawing.Size(243, 22);
            this.lblTotalRevenueTitle.TabIndex = 0;
            this.lblTotalRevenueTitle.Text = "TỔNG DOANH THU";
            this.lblTotalRevenueTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelChart
            // 
            this.panelChart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelChart.Controls.Add(this.chart1);
            this.panelChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChart.Location = new System.Drawing.Point(281, 119);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(1071, 534);
            this.panelChart.TabIndex = 3;
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.LightGray;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1071, 534);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // ThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1352, 653);
            this.Controls.Add(this.panelChart);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ThongKeDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RevenueReportForm";
            this.Load += new System.EventHandler(this.ThongKeDoanhThu_Load);
            this.panelButtons.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.panelChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelChart;
        private Guna.UI2.WinForms.Guna2Button btnStaffRevenue;
        private Guna.UI2.WinForms.Guna2Button btnCategoryRevenue;
        private Guna.UI2.WinForms.Guna2Button btnYearlyRevenue;
        private Guna.UI2.WinForms.Guna2Button btnMonthlyRevenue;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2Button btnExport;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalOrders;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAvgRevenue;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAvgRevenueTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalRevenue;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalRevenueTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPeriod;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPeriodTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalOrdersTitle;
    }
}