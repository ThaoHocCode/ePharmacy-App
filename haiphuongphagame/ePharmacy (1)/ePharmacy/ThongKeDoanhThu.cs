using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ePharmacy
{
    public partial class ThongKeDoanhThu : Form
    {
        public ThongKeDoanhThu()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Thiết lập thuộc tính cho Chart (giữ lại vì cần tùy chỉnh động)
            chart1.Visible = false;
            chart1.BorderlineColor = Color.LightGray;
            chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            chart1.BorderlineWidth = 1;
            chart1.BackColor = Color.White;
            chart1.Dock = DockStyle.Fill;
            chart1.Titles.Clear();
            Title mainTitle = new Title("THỐNG KÊ DOANH THU", Docking.Top);
            mainTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            mainTitle.ForeColor = Color.DarkBlue;
            chart1.Titles.Add(mainTitle);
            chart1.Legends.Clear();
            Legend legend = new Legend("MainLegend");
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            legend.BackColor = Color.Transparent;
            legend.Font = new Font("Segoe UI", 10);
            chart1.Legends.Add(legend);

            
        }

        private void ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            ShowMonthlyRevenue();
        }

        #region Chart Methods

        private void btnMonthlyRevenue_Click(object sender, EventArgs e)
        {
            ShowMonthlyRevenue();
        }

        private void btnYearlyRevenue_Click(object sender, EventArgs e)
        {
            ShowYearlyRevenue();
        }

        private void btnCategoryRevenue_Click(object sender, EventArgs e)
        {
            ShowCategoryRevenue();
        }

        private void btnStaffRevenue_Click(object sender, EventArgs e)
        {
            ShowStaffRevenue();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportChart();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowMonthlyRevenue()
        {
            try
            {
                chart1.Titles.Clear();
                Title title = new Title("DOANH THU THEO THÁNG (" + DateTime.Now.Year + ")", Docking.Top);
                title.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                title.ForeColor = Color.DarkBlue;
                chart1.Titles.Add(title);
                chart1.ChartAreas.Clear();
                chart1.Series.Clear();
                ChartArea chartArea = new ChartArea("MonthlyArea");
                chartArea.AxisX.Title = "Tháng";
                chartArea.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Regular);
                chartArea.AxisY.Title = "Doanh thu (VNĐ)";
                chartArea.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Regular);
                chartArea.AxisY.LabelStyle.Format = "{0:N0}";
                chartArea.BackColor = Color.White;
                chartArea.BackSecondaryColor = Color.FromArgb(240, 240, 240);
                chartArea.BackGradientStyle = GradientStyle.TopBottom;
                chartArea.AxisY.Minimum = 0;
                chart1.ChartAreas.Add(chartArea);
                Series revenueSeries = new Series("Doanh thu");
                revenueSeries.ChartType = SeriesChartType.Column;
                revenueSeries.IsValueShownAsLabel = true;
                revenueSeries.LabelFormat = "{0:N0}";
                revenueSeries.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                revenueSeries.Color = Color.FromArgb(65, 140, 240);
                revenueSeries.BorderWidth = 2;
                revenueSeries.BorderColor = Color.FromArgb(65, 140, 240);
                revenueSeries.ShadowOffset = 2;
                revenueSeries["LabelStyle"] = "Top";
                revenueSeries.SmartLabelStyle.Enabled = true;
                revenueSeries.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
                revenueSeries.SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Top;
                revenueSeries.LabelAngle = 0;
                revenueSeries["PixelPointWidth"] = "30";
                revenueSeries["PointWidth"] = "0.6";
                chart1.Series.Add(revenueSeries);
                Series avgSeries = new Series("Trung bình");
                avgSeries.ChartType = SeriesChartType.Line;
                avgSeries.BorderWidth = 3;
                avgSeries.Color = Color.FromArgb(252, 180, 65);
                avgSeries.MarkerStyle = MarkerStyle.Circle;
                avgSeries.MarkerSize = 8;
                avgSeries.MarkerColor = Color.FromArgb(252, 180, 65);
                chart1.Series.Add(avgSeries);
                decimal totalRevenue = 0;
                int totalOrders = 0;
                Dictionary<int, decimal> monthlyRevenue = new Dictionary<int, decimal>();
                Dictionary<int, int> monthlyOrders = new Dictionary<int, int>();
                for (int i = 1; i <= 12; i++)
                {
                    monthlyRevenue[i] = 0;
                    monthlyOrders[i] = 0;
                }
                using (SqlConnection connection = new SqlConnection(Database.GetConnectionString()))
                {
                    connection.Open();
                    string query = @"
                                SELECT 
                                    MONTH(NgayTao) as Thang, 
                                    SUM(TongTien) as DoanhThu,
                                    COUNT(*) as SoDonHang
                                FROM ChiTietDonHang 
                                WHERE YEAR(NgayTao) = YEAR(GETDATE()) 
                                    AND TrangThai = 'DXN'  
                                GROUP BY MONTH(NgayTao) 
                                ORDER BY MONTH(NgayTao)";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    bool hasData = false;
                    while (reader.Read())
                    {
                        hasData = true;
                        int month = reader.GetInt32(0);
                        decimal revenue = reader.GetInt64(1);
                        int orders = reader.GetInt32(2);
                        monthlyRevenue[month] = revenue;
                        monthlyOrders[month] = orders;
                        totalRevenue += revenue;
                        totalOrders += orders;
                    }
                    reader.Close();
                    if (!hasData)
                    {
                        monthlyRevenue[5] = 242343245000;
                        monthlyOrders[5] = 25;
                        monthlyRevenue[2] = 342345000;
                        monthlyOrders[2] = 20;
                        monthlyRevenue[1] = 242340000;
                        monthlyOrders[1] = 15;
                        monthlyRevenue[3] = 24240000;
                        monthlyOrders[3] = 18;
                        monthlyRevenue[4] = 21412400;
                        monthlyOrders[4] = 22;
                        totalRevenue = monthlyRevenue.Values.Sum();
                        totalOrders = monthlyOrders.Values.Sum();
                    }
                }
                for (int month = 1; month <= 12; month++)
                {
                    revenueSeries.Points.AddXY("Tháng " + month, (double)monthlyRevenue[month]);
                }
                decimal maxRevenue = monthlyRevenue.Values.Max();
                chartArea.AxisY.Maximum = (double)(maxRevenue * 1.2m);
                int monthsWithRevenue = monthlyRevenue.Count(m => m.Value > 0);
                decimal avgMonthlyRevenue = monthsWithRevenue > 0 ? totalRevenue / monthsWithRevenue : 0;
                for (int i = 1; i <= 12; i++)
                {
                    avgSeries.Points.AddXY("Tháng " + i, (double)avgMonthlyRevenue);
                }
                lblTotalRevenue.Text = string.Format("{0:N0} VNĐ", totalRevenue);
                lblTotalOrders.Text = totalOrders.ToString();
                lblAvgRevenue.Text = string.Format("{0:N0} VNĐ", totalOrders > 0 ? totalRevenue / totalOrders : 0);
                lblPeriod.Text = "Năm " + DateTime.Now.Year;
                chart1.Visible = true;
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị doanh thu theo tháng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowYearlyRevenue()
        {
            try
            {
                chart1.Titles.Clear();
                Title title = new Title("DOANH THU THEO NĂM", Docking.Top);
                title.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                title.ForeColor = Color.DarkBlue;
                chart1.Titles.Add(title);
                chart1.ChartAreas.Clear();
                chart1.Series.Clear();
                ChartArea chartArea = new ChartArea("YearlyArea");
                chartArea.AxisX.Title = "Năm";
                chartArea.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Regular);
                chartArea.AxisY.Title = "Doanh thu (VNĐ)";
                chartArea.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Regular);
                chartArea.AxisY.LabelStyle.Format = "{0:N0}";
                chartArea.BackColor = Color.White;
                chartArea.BackSecondaryColor = Color.FromArgb(240, 240, 240);
                chartArea.BackGradientStyle = GradientStyle.TopBottom;
                chartArea.AxisY.Minimum = 0;
                chart1.ChartAreas.Add(chartArea);
                Series revenueSeries = new Series("Doanh thu");
                revenueSeries.ChartType = SeriesChartType.Column;
                revenueSeries.IsValueShownAsLabel = true;
                revenueSeries.LabelFormat = "{0:N0}";
                revenueSeries.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                revenueSeries.Color = Color.FromArgb(65, 140, 240);
                revenueSeries.BorderWidth = 2;
                revenueSeries.BorderColor = Color.FromArgb(65, 140, 240);
                revenueSeries.ShadowOffset = 2;
                chart1.Series.Add(revenueSeries);
                Series growthSeries = new Series("Tăng trưởng (%)");
                growthSeries.ChartType = SeriesChartType.Line;
                growthSeries.BorderWidth = 3;
                growthSeries.Color = Color.FromArgb(252, 180, 65);
                growthSeries.MarkerStyle = MarkerStyle.Circle;
                growthSeries.MarkerSize = 8;
                growthSeries.MarkerColor = Color.FromArgb(252, 180, 65);
                growthSeries.YAxisType = AxisType.Secondary;
                chart1.Series.Add(growthSeries);
                chartArea.AxisY2.Enabled = AxisEnabled.True;
                chartArea.AxisY2.Title = "Tăng trưởng (%)";
                chartArea.AxisY2.TitleFont = new Font("Segoe UI", 10, FontStyle.Regular);
                chartArea.AxisY2.LabelStyle.Format = "{0:0.0}%";
                chartArea.AxisY2.Minimum = -100;
                chartArea.AxisY2.Maximum = 100;
                List<int> years = new List<int>();
                List<decimal> revenues = new List<decimal>();
                List<int> orders = new List<int>();
                bool hasData = false;
                using (SqlConnection connection = new SqlConnection(Database.GetConnectionString()))
                {
                    connection.Open();
                    string query = @"
                                        SELECT 
                                            YEAR(NgayTao) as Nam, 
                                            SUM(TongTien) as DoanhThu,
                                            COUNT(*) as SoDonHang
                                        FROM ChiTietDonHang 
                                        WHERE TrangThai = 'DXN'  
                                        GROUP BY YEAR(NgayTao) 
                                        ORDER BY YEAR(NgayTao)";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        hasData = true;
                        int year = reader.GetInt32(0);
                        decimal revenue = reader.GetInt64(1);
                        int orderCount = reader.GetInt32(2);
                        years.Add(year);
                        revenues.Add(revenue);
                        orders.Add(orderCount);
                        revenueSeries.Points.AddXY(year.ToString(), (double)revenue);
                    }
                    reader.Close();
                }
                if (!hasData)
                {
                    int currentYear = DateTime.Now.Year;
                    for (int i = 0; i < 3; i++)
                    {
                        int year = currentYear - 2 + i;
                        decimal revenue = 50000000 + (i * 15000000);
                        int orderCount = 500 + (i * 100);
                        years.Add(year);
                        revenues.Add(revenue);
                        orders.Add(orderCount);
                        revenueSeries.Points.AddXY(year.ToString(), (double)revenue);
                    }
                }
                for (int i = 0; i < years.Count; i++)
                {
                    if (i > 0)
                    {
                        decimal prevRevenue = revenues[i - 1];
                        decimal currRevenue = revenues[i];
                        double growthRate = prevRevenue != 0 ? (double)((currRevenue - prevRevenue) / prevRevenue * 100) : 0;
                        DataPoint point = growthSeries.Points.Add(growthRate);
                        point.AxisLabel = years[i].ToString();
                        point.Label = string.Format("{0:0.0}%", growthRate);
                    }
                    else
                    {
                        DataPoint point = growthSeries.Points.Add(0);
                        point.AxisLabel = years[i].ToString();
                        point.IsEmpty = true;
                    }
                }
                decimal totalRevenue = revenues.Sum();
                int totalOrderCount = orders.Sum();
                lblTotalRevenue.Text = string.Format("{0:N0} VNĐ", totalRevenue);
                lblTotalOrders.Text = totalOrderCount.ToString();
                lblAvgRevenue.Text = string.Format("{0:N0} VNĐ", totalRevenue / (totalOrderCount > 0 ? totalOrderCount : 1));
                lblPeriod.Text = years.Count > 0 ? years.First() + " - " + years.Last() : "";
                chart1.Visible = true;
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị doanh thu theo năm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowCategoryRevenue()
        {
            try
            {
                chart1.Titles.Clear();
                Title title = new Title("DOANH THU THEO DANH MỤC SẢN PHẨM", Docking.Top);
                title.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                title.ForeColor = Color.DarkBlue;
                chart1.Titles.Add(title);
                chart1.ChartAreas.Clear();
                chart1.Series.Clear();
                chart1.Legends.Clear();
                ChartArea chartArea = new ChartArea("CategoryArea");
                chartArea.BackColor = Color.White;
                chart1.ChartAreas.Add(chartArea);
                Series pieSeries = new Series("Danh mục");
                pieSeries.ChartType = SeriesChartType.Pie;
                pieSeries.IsValueShownAsLabel = true;
                pieSeries.LabelFormat = "{0:0.0%}";
                pieSeries.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                pieSeries.LabelForeColor = Color.White;
                pieSeries.BorderWidth = 1;
                pieSeries.BorderColor = Color.White;
                chart1.Series.Add(pieSeries);
                ChartArea barArea = new ChartArea("BarArea");
                barArea.AxisX.Title = "Danh mục";
                barArea.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Regular);
                barArea.AxisY.Title = "Doanh thu (VNĐ)";
                barArea.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Regular);
                barArea.AxisY.LabelStyle.Format = "{0:N0}";
                barArea.BackColor = Color.White;
                barArea.BackSecondaryColor = Color.FromArgb(240, 240, 240);
                barArea.BackGradientStyle = GradientStyle.TopBottom;
                chart1.ChartAreas.Add(barArea);
                Series barSeries = new Series("Chi tiết doanh thu");
                barSeries.ChartType = SeriesChartType.Column;
                barSeries.IsValueShownAsLabel = true;
                barSeries.LabelFormat = "{0:N0}";
                barSeries.Font = new Font("Segoe UI", 10);
                barSeries.LabelForeColor = Color.Black;
                barSeries.ChartArea = "BarArea";
                barSeries["PointWidth"] = "0.7";
                chart1.Series.Add(barSeries);
                chartArea.Position = new ElementPosition(0, 0, 100, 40);
                barArea.Position = new ElementPosition(0, 45, 100, 40);
                Legend mainLegend = new Legend("MainLegend");
                mainLegend.Docking = Docking.Bottom;
                mainLegend.Alignment = StringAlignment.Center;
                mainLegend.BackColor = Color.Transparent;
                mainLegend.Font = new Font("Segoe UI", 10);
                mainLegend.LegendStyle = LegendStyle.Table;
                mainLegend.TableStyle = LegendTableStyle.Wide;
                mainLegend.IsTextAutoFit = true;
                mainLegend.Position.Auto = false;
                mainLegend.Position = new ElementPosition(0, 85, 100, 15);
                chart1.Legends.Add(mainLegend);
                pieSeries.Legend = "MainLegend";
                pieSeries.LegendText = "#VALX: #PERCENT{P0}";
                Title pieTitle = new Title("Tỷ lệ phần trăm", Docking.Top);
                pieTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                pieTitle.DockedToChartArea = "CategoryArea";
                pieTitle.IsDockedInsideChartArea = false;
                chart1.Titles.Add(pieTitle);
                Title barTitle = new Title("Chi tiết doanh thu (VNĐ)", Docking.Top);
                barTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                barTitle.DockedToChartArea = "BarArea";
                barTitle.IsDockedInsideChartArea = false;
                chart1.Titles.Add(barTitle);
                Color[] chartColors = new Color[]
                {
                    Color.FromArgb(65, 140, 240),
                    Color.FromArgb(252, 180, 65),
                    Color.FromArgb(224, 64, 10),
                    Color.FromArgb(5, 100, 146),
                    Color.FromArgb(191, 191, 191),
                    Color.FromArgb(26, 59, 105),
                    Color.FromArgb(0, 128, 0),
                    Color.FromArgb(186, 85, 211)
                };
                Dictionary<string, decimal> categoryRevenue = new Dictionary<string, decimal>();
                int totalOrders = 0;
                using (SqlConnection connection = new SqlConnection(Database.GetConnectionString()))
                {
                    connection.Open();
                    string query = @"
                SELECT MaDonHang, DanhSachThuoc, TongTien 
                FROM ChiTietDonHang
                WHERE TrangThai = 'DXN'";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string maDonHang = reader.GetString(0);
                        string danhSachThuoc = reader.GetString(1);
                        decimal tongTien = reader.GetInt64(2);
                        totalOrders++;
                        Dictionary<string, Tuple<int, decimal>> productDetails = ParseProductList(danhSachThuoc);
                        decimal totalProductValue = 0;
                        foreach (var product in productDetails)
                        {
                            totalProductValue += product.Value.Item1 * product.Value.Item2;
                        }
                        foreach (var product in productDetails)
                        {
                            string productName = product.Key;
                            int quantity = product.Value.Item1;
                            decimal price = product.Value.Item2;
                            decimal productValue = quantity * price;
                            decimal contributionRatio = totalProductValue > 0 ? productValue / totalProductValue : 0;
                            decimal productRevenue = tongTien * contributionRatio;
                            string category = GetProductCategory(connection, productName);
                            if (categoryRevenue.ContainsKey(category))
                            {
                                categoryRevenue[category] += productRevenue;
                            }
                            else
                            {
                                categoryRevenue[category] = productRevenue;
                            }
                        }
                    }
                    reader.Close();
                    if (categoryRevenue.Count == 0)
                    {
                        categoryRevenue.Add("Thuốc kháng sinh", 15000000);
                        categoryRevenue.Add("Thuốc giảm đau", 12000000);
                        categoryRevenue.Add("Vitamin", 8000000);
                        categoryRevenue.Add("Thực phẩm chức năng", 10000000);
                        categoryRevenue.Add("Thuốc tim mạch", 7500000);
                        totalOrders = 100;
                    }
                    int colorIndex = 0;
                    foreach (var category in categoryRevenue.OrderByDescending(x => x.Value))
                    {
                        DataPoint piePoint = pieSeries.Points.Add((double)category.Value);
                        piePoint.LegendText = category.Key;
                        piePoint.Label = "#PERCENT{P0}";
                        piePoint.Color = chartColors[colorIndex % chartColors.Length];
                        DataPoint barPoint = barSeries.Points.Add((double)category.Value);
                        barPoint.AxisLabel = category.Key;
                        barPoint.Label = string.Format("{0:N0}", category.Value);
                        barPoint.Color = chartColors[colorIndex % chartColors.Length];
                        colorIndex++;
                    }
                    decimal totalRevenue = categoryRevenue.Values.Sum();
                    lblTotalRevenue.Text = string.Format("{0:N0} VNĐ", totalRevenue);
                    lblTotalOrders.Text = totalOrders.ToString();
                    lblAvgRevenue.Text = string.Format("{0:N0} VNĐ", totalRevenue / (totalOrders > 0 ? totalOrders : 1));
                    lblPeriod.Text = "Tất cả thời gian";
                }
                chart1.Visible = true;
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị doanh thu theo danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Dictionary<string, Tuple<int, decimal>> ParseProductList(string productList)
        {
            Dictionary<string, Tuple<int, decimal>> result = new Dictionary<string, Tuple<int, decimal>>();
            try
            {
                string[] parts = productList.Split(new string[] { " - SL: " }, StringSplitOptions.None);
                for (int i = 0; i < parts.Length - 1; i++)
                {
                    string productPart = parts[i];
                    string quantityPart = parts[i + 1];
                    int quantity;
                    int spaceIndex = quantityPart.IndexOf(' ');
                    if (spaceIndex > 0)
                    {
                        string quantityStr = quantityPart.Substring(0, spaceIndex);
                        if (int.TryParse(quantityStr, out quantity))
                        {
                            int priceIndex = productPart.LastIndexOf(" - Giá: ");
                            if (priceIndex > 0)
                            {
                                string productName = productPart.Substring(0, priceIndex).Trim();
                                string priceStr = productPart.Substring(priceIndex + 8);
                                decimal price;
                                if (decimal.TryParse(priceStr, out price))
                                {
                                    result[productName] = new Tuple<int, decimal>(quantity, price);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (int.TryParse(quantityPart, out quantity))
                        {
                            int priceIndex = productPart.LastIndexOf(" - Giá: ");
                            if (priceIndex > 0)
                            {
                                string productName = productPart.Substring(0, priceIndex).Trim();
                                string priceStr = productPart.Substring(priceIndex + 8);
                                decimal price;
                                if (decimal.TryParse(priceStr, out price))
                                {
                                    result[productName] = new Tuple<int, decimal>(quantity, price);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return result;
        }

        private string GetProductCategory(SqlConnection connection, string productName)
        {
            try
            {
                string query = "SELECT [Group] FROM SanPham WHERE CommodityName LIKE @ProductName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", "%" + productName + "%");
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return result.ToString();
                }
            }
            catch
            {
            }
            return "Khác";
        }

        private void ShowStaffRevenue()
        {
            try
            {
                chart1.Titles.Clear();
                Title title = new Title("DOANH THU THEO NHÂN VIÊN", Docking.Top);
                title.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                title.ForeColor = Color.DarkBlue;
                chart1.Titles.Add(title);
                chart1.ChartAreas.Clear();
                chart1.Series.Clear();
                ChartArea chartArea = new ChartArea("StaffArea");
                chartArea.AxisX.Title = "Nhân viên";
                chartArea.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Regular);
                chartArea.AxisY.Title = "Doanh thu (VNĐ)";
                chartArea.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Regular);
                chartArea.AxisY.LabelStyle.Format = "{0:N0}";
                chartArea.BackColor = Color.White;
                chartArea.BackSecondaryColor = Color.FromArgb(240, 240, 240);
                chartArea.BackGradientStyle = GradientStyle.TopBottom;
                chart1.ChartAreas.Add(chartArea);
                Series revenueSeries = new Series("Doanh thu");
                revenueSeries.ChartType = SeriesChartType.Column;
                revenueSeries.IsValueShownAsLabel = true;
                revenueSeries.LabelFormat = "{0:N0}";
                revenueSeries.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                revenueSeries.Color = Color.FromArgb(65, 140, 240);
                chart1.Series.Add(revenueSeries);
                Series orderSeries = new Series("Số đơn hàng");
                orderSeries.ChartType = SeriesChartType.Line;
                orderSeries.BorderWidth = 3;
                orderSeries.Color = Color.FromArgb(252, 180, 65);
                orderSeries.MarkerStyle = MarkerStyle.Circle;
                orderSeries.MarkerSize = 8;
                orderSeries.MarkerColor = Color.FromArgb(252, 180, 65);
                orderSeries.YAxisType = AxisType.Secondary;
                chart1.Series.Add(orderSeries);
                chartArea.AxisY2.Enabled = AxisEnabled.True;
                chartArea.AxisY2.Title = "Số đơn hàng";
                chartArea.AxisY2.TitleFont = new Font("Segoe UI", 10, FontStyle.Regular);
                using (SqlConnection connection = new SqlConnection(Database.GetConnectionString()))
                {
                    connection.Open();
                    string query = @"
                                    SELECT 
                                        MaNhanVien, 
                                        SUM(TongTien) as DoanhThu,
                                        COUNT(*) as SoDonHang
                                    FROM ChiTietDonHang 
                                    WHERE TrangThai = 'DXN'  
                                    GROUP BY MaNhanVien 
                                    ORDER BY SUM(TongTien) DESC";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    decimal totalRevenue = 0;
                    int totalOrders = 0;
                    while (reader.Read())
                    {
                        string staffId = reader.GetString(0);
                        decimal revenue = reader.GetInt64(1);
                        int orders = reader.GetInt32(2);
                        totalRevenue += revenue;
                        totalOrders += orders;
                        string staffName = staffId;
                        if (staffId.ToLower() == "online" || staffId.ToLower() == "web" || staffId.ToLower() == "app")
                        {
                            staffName = "Đơn Online";
                        }
                        else
                        {
                            try
                            {
                                using (SqlCommand cmdStaff = new SqlCommand(
                                    "SELECT FULLName FROM [User] WHERE TelephoneNumber = @MaNV", connection))
                                {
                                    cmdStaff.Parameters.AddWithValue("@MaNV", staffId);
                                    object result = cmdStaff.ExecuteScalar();
                                    if (result != null && result != DBNull.Value)
                                    {
                                        staffName = result.ToString();
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                        int pointIndex = revenueSeries.Points.AddXY(staffName, (double)revenue);
                        revenueSeries.Points[pointIndex].Label = string.Format("{0:N0}", revenue);
                        orderSeries.Points.AddXY(staffName, orders);
                    }
                    reader.Close();
                    lblTotalRevenue.Text = string.Format("{0:N0} VNĐ", totalRevenue);
                    lblTotalOrders.Text = totalOrders.ToString();
                    lblAvgRevenue.Text = string.Format("{0:N0} VNĐ", totalRevenue / (totalOrders > 0 ? totalOrders : 1));
                    lblPeriod.Text = "Tất cả thời gian";
                }
                chart1.Visible = true;
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị doanh thu theo nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportChart()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Tệp hình ảnh (*.png)|*.png|Tệp hình ảnh (*.jpg)|*.jpg|Tất cả các tệp (*.*)|*.*";
                saveDialog.Title = "Lưu biểu đồ";
                saveDialog.DefaultExt = "png";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Size originalSize = chart1.Size;
                    try
                    {
                        chart1.Size = new Size(1200, 800);
                        foreach (ChartArea area in chart1.ChartAreas)
                        {
                            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                            if (area.AxisY2.Enabled == AxisEnabled.True)
                                area.AxisY2.LabelStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                        }
                        foreach (Series series in chart1.Series)
                        {
                            if (series.IsValueShownAsLabel)
                                series.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                        }
                        chart1.SaveImage(saveDialog.FileName, ChartImageFormat.Png);
                        MessageBox.Show("Đã xuất biểu đồ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        chart1.Size = originalSize;
                        foreach (ChartArea area in chart1.ChartAreas)
                        {
                            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
                            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
                            if (area.AxisY2.Enabled == AxisEnabled.True)
                                area.AxisY2.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
                        }
                        foreach (Series series in chart1.Series)
                        {
                            if (series.IsValueShownAsLabel)
                                series.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất biểu đồ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}