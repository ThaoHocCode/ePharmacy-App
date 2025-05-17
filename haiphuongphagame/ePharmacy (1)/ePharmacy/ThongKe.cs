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

namespace ePharmacy
{
    public partial class ThongKe : Form
    {
        public string SoDienThoai;
        public string conTent;
        public ThongKe(string sdt)
        {
            InitializeComponent();
            SoDienThoai = sdt;
            LoadForm();
        }

        
        private void ThongKe_Load(object sender, EventArgs e)
        {

        }
        public void LoadForm()
        {
            TruyVanTen();
            TruyVanDoanhThu();
            richTextBox.Text = conTent;
        }
        public void TruyVanTen()
        {
            string query = "select FullName from [User] where TelephoneNumber = @sdt";
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sdt", SoDienThoai);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string tam = reader["FullName"].ToString();
                            conTent+=tam+"\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void TruyVanDoanhThu()
        {
        string query = "SELECT SUM(SoTien) AS TongTien FROM QuanLyDonHang WHERE MaNV = @sdt";
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sdt", SoDienThoai);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            long tongTien = 0;
                            if (reader["TongTien"] != DBNull.Value)
                            {
                                tongTien = Convert.ToInt64(reader["TongTien"]); 
                            }
                            conTent += $"Tổng doanh thu: {tongTien:N0} VND\n";
                            TinhTienLuong(tongTien);
                            if (tongTien <= 5000000)
                                conTent += "Nhân viên chưa đạt yêu cầu trong tháng này\n";
                            else
                                if (tongTien <= 10000000)
                                conTent += "Nhân viên đã hoàn thành mức chỉ tiêu theo yêu cầu\n";
                            else
                                conTent += "Nhân viên đã đạt và nhận được thêm hoa hồng sản phẩm\n";
                            conTent += "--------------------------------------------------\n";
                            conTent += "Y đức – Niềm tin – Sức khỏe cộng đồng.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void TinhTienLuong(long m) 
        {
            float luong = m * 0.008f;
            if (m <= 5000000)
            {
                txtSalary.Text = "5.560.450 VND";
            }
            else if (m <= 10000000)
            {
                txtSalary.Text="8.000.000 VND";
            }
            else
            {
                txtSalary.Text = (m + luong).ToString() + "VND";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Employee page = new Employee(SoDienThoai);
            page.Show();
        }
    }
}
