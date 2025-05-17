using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace ePharmacy
{
    public partial class KT_don : Form
    {
        public string PhoneNumber;
        public KT_don(string phoneNumber)
        {
            InitializeComponent();
            PhoneNumber = phoneNumber;
            LoadForm();
        }
        public void LoadForm()
        {
            string query = "select MaDonHang,SoDienThoai,TrangThai from TruyXuatDonHang where TrangThai='CXN'";
            try
            {
                using (SqlConnection doi_tuong = new SqlConnection(Database.GetConnectionString()))
                {
                    doi_tuong.Open();
                    SqlCommand cmd = new SqlCommand(query, doi_tuong);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MaDonHang"].ToString());
                        item.SubItems.Add(reader["SoDienThoai"].ToString());
                        if (reader["TrangThai"].ToString() == "CXN")
                        {
                            item.SubItems.Add("Chờ xác nhận");
                        }
                        else
                        {
                            item.SubItems.Add("Đã xác nhận");
                        }
                        //item.SubItems.Add(reader["TrangThai"].ToString());
                        listViewOrder.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void updateData(string m)
        {
            string query = "update TruyXuatDonHang set TrangThai = 'DXN' WHERE MaDonHang = @madonhang";
            // Cập nhật bảng ChiTietDonHang
            string query2 = "update ChiTietDonHang set TrangThai = 'DXN' WHERE MaDonHang = @madonhang";
            try
            {
                using (SqlConnection doi_tuong = new SqlConnection(Database.GetConnectionString()))
                {
                    doi_tuong.Open();

                    SqlCommand cmd = new SqlCommand(query, doi_tuong);
                    cmd.Parameters.AddWithValue("@madonhang", m);
                    cmd.ExecuteNonQuery();

                    // Cập nhật ChiTietDonHang
                    SqlCommand cmd2 = new SqlCommand(query2, doi_tuong);
                    cmd2.Parameters.AddWithValue("@madonhang", m);
                    cmd2.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            listViewOrder.Items.Clear();
            LoadForm();
        }
        private void guna2Button4_Click(object sender, EventArgs e)   //button để xác nhận đơn hàng
        {
            if (listViewOrder.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewOrder.SelectedItems[0];
                string maDonHang = selectedItem.SubItems[0].Text;
                //string sdt = selectedItem.SubItems[1].Text;
                updateData(maDonHang);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee page = new Employee(PhoneNumber);
            page.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewOrder.SelectedItems[0];
                string maDonHang = selectedItem.SubItems[0].Text.Trim();

                // Hiển thị chi tiết đơn hàng
                HienThiChiTietDonHang(maDonHang);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xem chi tiết.");
            }
        }

        public void InRaManHinh(string m, string n)
        {

        }
        public string TimChuoiTuXDenX(string filePath, string x)
        {
            if (!File.Exists(filePath))
                return "Không tìm thấy file.";

            string input = File.ReadAllText(filePath);

            // Sử dụng Regular Expressions để tìm chuỗi
            Match match = Regex.Match(input, Regex.Escape(x));
            if (!match.Success)
                return x;

            return match.Value;
        }

        public void DocFileVaTimChuoi(string m, string n)
        {
            string result = TimChuoiTuXDenX(m,n);
            richTextBox.Text = result;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewOrder.SelectedItems[0];
                string maDonHang = selectedItem.SubItems[0].Text.Trim();
                deleteData(maDonHang);
            }
        }

        public void deleteData(string m)
        {
            string query = "update TruyXuatDonHang set TrangThai = 'HD' WHERE MaDonHang = @madonhang";
            // Cập nhật bảng ChiTietDonHang
            string query2 = "update ChiTietDonHang set TrangThai = 'HD' WHERE MaDonHang = @madonhang";
            try
            {
                using (SqlConnection doi_tuong = new SqlConnection(Database.GetConnectionString()))
                {
                    doi_tuong.Open();

                    SqlCommand cmd = new SqlCommand(query, doi_tuong);
                    cmd.Parameters.AddWithValue("@madonhang", m);
                    cmd.ExecuteNonQuery();
                    // Cập nhật ChiTietDonHang
                    SqlCommand cmd2 = new SqlCommand(query2, doi_tuong);
                    cmd2.Parameters.AddWithValue("@madonhang", m);
                    cmd2.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            listViewOrder.Items.Clear();
            LoadForm();
        }

        // Thêm phương thức để hiển thị chi tiết đơn hàng từ bảng ChiTietDonHang
        public void HienThiChiTietDonHang(string maDonHang)
        {
            // Làm trống richTextBox trước khi hiển thị dữ liệu mới
            richTextBox.Text = string.Empty;

            string query = @"SELECT 
                    MaDonHang, 
                    NgayTao, 
                    MaNhanVien, 
                    SoDienThoaiKhachHang, 
                    DanhSachThuoc, 
                    TongTien, 
                    TrangThai, 
                    GhiChu 
                  FROM ChiTietDonHang 
                  WHERE MaDonHang = @maDonHang";

            try
            {
                bool dataFound = false;

                using (SqlConnection conn = new SqlConnection(Database.GetConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maDonHang", maDonHang);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows) // Kiểm tra xem có dữ liệu không trước khi đọc
                        {
                            while (reader.Read())
                            {
                                dataFound = true;
                                StringBuilder sb = new StringBuilder();
                                sb.AppendLine("MÃ ĐƠN HÀNG: " + reader["MaDonHang"].ToString());
                                sb.AppendLine("NGÀY TẠO: " + Convert.ToDateTime(reader["NgayTao"]).ToString("dd/MM/yyyy HH:mm:ss"));
                                sb.AppendLine("MÃ NHÂN VIÊN: " + reader["MaNhanVien"].ToString());
                                sb.AppendLine("SỐ ĐIỆN THOẠI KHÁCH HÀNG: " + reader["SoDienThoaiKhachHang"].ToString());
                                sb.AppendLine("DANH SÁCH THUỐC:");
                                sb.AppendLine(reader["DanhSachThuoc"].ToString());
                                sb.AppendLine("TỔNG TIỀN: " + reader["TongTien"].ToString() + " VND");
                                sb.AppendLine("TRẠNG THÁI: " + (reader["TrangThai"].ToString() == "CXN" ? "Chờ xác nhận" : "Đã xác nhận"));
                                sb.AppendLine("GHI CHÚ: " + reader["GhiChu"].ToString());

                                richTextBox.Text = sb.ToString();
                            }
                        }
                    }
                }

                // Nếu không tìm thấy dữ liệu trong ChiTietDonHang, thử phương pháp cũ
                if (!dataFound)
                {
                    if (listViewOrder.SelectedItems.Count > 0)
                    {
                        string sdt = listViewOrder.SelectedItems[0].SubItems[1].Text.Trim();
                        DocFileVaTimChuoi(sdt + ".txt", maDonHang + sdt);
                    }
                    else
                    {
                        richTextBox.Text = "Không tìm thấy thông tin chi tiết cho đơn hàng này.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị chi tiết đơn hàng: " + ex.Message);
                richTextBox.Text = "Đã xảy ra lỗi khi hiển thị chi tiết đơn hàng.";
            }
        }

        private void KT_don_Load(object sender, EventArgs e)
        {

        }
    }
}
