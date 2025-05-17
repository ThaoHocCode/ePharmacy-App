using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using QRCoder;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ePharmacy
{
    public partial class Tao_don : Form
    {
        public string selectedProductName;
        public int dem = 0;
        public int value = 0;
        public string invoice;
        public long total;
        public long substract;
        public string str;
        public string tenTK;
        public string tenKH;
        public string MaNhanVien = "orderOnline";
        public Tao_don(string KH, string TK)
        {
            InitializeComponent();
            tenKH = KH;
            tenTK = TK;
            value = 1;
            LoadForm();
        }

        public Tao_don(string KH, string TK, string maNV)
        {
            InitializeComponent();
            tenKH = KH;
            tenTK = TK;
            MaNhanVien = maNV;
            value = 2;
            LoadForm();
        }

        public void LoadForm()
        {
            //invoice += 
            invoice += "Khách hàng:" + tenKH + "\n";
            invoice += "Số điện thoại:" + tenTK + "\n";
        }
        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void Tao_don_Load(object sender, EventArgs e)
        {

            AutoCompleteStringCollection autoList = new AutoCompleteStringCollection();
            string[] items = new string[]
            {
                    "PQA viêm mũi dị ứng",
                    "Ibuprofen 400mg",
                    "Telfast BD",
                    "JointCarePlus - Mỹ - Lọ 60 Viên",
                    "Tràng Vị Khang - Đông Á - H6Gói",
                    "Hoàn Khơp Bổ Thận NK - TW - H14 Gói",
                    "Bromuric - ÂuCơ - H30Viên",
                    "Cốt Thoái VƯơng - ÁÂu - H3Vĩ10Viên",
                    "Clorpheniramin4mg - Tipharco - Lọ 500 Viên",
                    "Loramark - Loratadine10mg - Ấn Độ - H10Vx 10 Viên",
                    "TelfastBD180mg - Sanofi - H10 Viên",
                    "Cetirizin10mg - Đồng Nai - H10Vx10 Viên",
                    "Theralene - Alimemazine5mg - Sanofi - H2Vx20 Viên",
                    "Dimicox - Meloxicam7.5mg - Medisun - H5Vx10 Viên",
                    "Dexamethason0.5mg - Becamex - Lọ 500 Viên",
                    "Detromethorpharn15mg - Đồng Tháp - Lọ 200 Viên",
                    "Mobic7.5mg - Meloxicam - Đức - H2Vx10 Viên",
                    "Medrol16mg - Methypred - Pháp - H3Vx10 Viên",
                    "Combo dụng cụ kiểm tra sốt",
                    "Combo thuốc bổ",
                    "Dịch vụ thay băng, cắt chỉ",
                    "Dịch vụ tiêm truyền tại nhà",
                    "Nhiệt Kế Aurora - Đức - H12Chiếc",
                    "Ecosipcool14x10cm - Tatra - H2túix 5Miếng",
                    "Ecosip7.5x10cm - Tatra - H20túix 5Miếng",
                    "Cao Dan Salonsip14x10cm - Hisamitsu - H10 Gói 2 Miếng",
                    "Đè Lưỡi Gỗi Hanomed - TânÁ - H10Chiếc",
                    "NattoGinkgo - HồGươm - H3Vx10Viên",
                    "Acnacare - TháiLan - H3Vỉ x10Viên",
                    "Zentomum - TânThịnh - H2Vỉ x15Viên",
                    "GingkoSoftM6 - HảiDương - H6Vx10Viên",
                    "Dầu Gấc Vinaga - VN - H1Lọ100Viên"
            };

            autoList.AddRange(items);
            comboBox.AutoCompleteCustomSource = autoList;
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource. ListItems;
            comboBox.Items.AddRange(items);
            comboBox1.AutoCompleteCustomSource = autoList;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.Items.AddRange(items);
        }
        private void ShowProductDetails(string ten)
        {
            string query = "select cost from SanPham where CommodityName = @ten";
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.GetConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ten", ten);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtPrice.Text = reader["cost"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem != null)
            {
                selectedProductName = comboBox.SelectedItem.ToString();
                ShowProductDetails(selectedProductName);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            
            if (value == 1)
            {
                Customer page = new Customer(tenKH, tenTK);
                page.Show();
                this.Close();
            }
            else
            if (value == 2)
            {
                Employee page = new Employee(MaNhanVien);
                page.Show();
                this.Close();
            }
        }
        public bool truyVan(string ten, decimal sl)
        {
            string query = "select Iventory from SanPham where CommodityName = @ten";
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.GetConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ten", ten);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (Convert.ToInt32(reader["Iventory"]) >= sl)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return false;
        }

        public void updateData(string ten, decimal sl)
        {
            string query = "update SanPham set Iventory = Iventory - @sl where CommodityName = @ten";
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.GetConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ten", ten);
                    cmd.Parameters.AddWithValue("@sl", sl);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (numberic.Value <= 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng sản phẩm");
                return;
            }
            long s = (Convert.ToInt64(txtPrice.Text)) * (Convert.ToInt64(numberic.Value));
            if (truyVan(selectedProductName,numberic.Value) == false)
            {
                MessageBox.Show("Sản phẩm không đủ số lượng");
                return;
            }
            invoice += selectedProductName + ":" + txtPrice.Text + "x" + numberic.Value + "=" + s + "VND\n";
            total += s;
            updateData(selectedProductName, numberic.Value);
            ListViewItem list = new ListViewItem(selectedProductName);
            list.SubItems.Add(txtPrice.Text);
            list.SubItems.Add(numberic.Value.ToString());
            listView1.Items.Add(list);
            txtBill.Text = total.ToString();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                listView1.FullRowSelect = true;
                ListViewItem ds = listView1.SelectedItems[0];
                txtPrice.Text = ds.SubItems[1].Text;
                numberic.Value = Convert.ToInt32(ds.SubItems[2].Text);
                selectedProductName = ds.SubItems[0].Text;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string columnData = selectedItem.SubItems[0].Text; 
                 string columnData1 = selectedItem.SubItems[1].Text;
                string columnData2 = selectedItem.SubItems[2].Text;
                str = str +columnData + ":" + columnData1 + "x" + columnData2 + "\n";
                substract = Convert.ToInt64(columnData1) * Convert.ToInt64(columnData2);
                txtBill.Text = (total - substract).ToString();
                dem = dem + 1;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng!");
                return;
            }
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.");
            }

        }

        public void sanPham(string ten)
        {
            string tam= "Sản phẩm "+ten+"\n";
            string query = "select GoodsCode,ActiveElement,Packaging,Cost from SanPham where CommodityName = @ten";
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.GetConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ten", ten);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tam= tam +"Chi phí:"+ reader["cost"].ToString()+"VND\n";
                        tam = tam + "Thành phần hoạt chất: " + reader["ActiveElement"].ToString() + "\n";
                        tam = tam + "Quy cách: " + reader["Packaging"].ToString() + "\n";
                        MessageBox.Show(tam,"Thông báo tra cứu tham khảo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                selectedProductName = comboBox1.SelectedItem.ToString();
                sanPham(selectedProductName);
            }
        }
        public void LuuChiTietDonHang(string maDonHang, string danhSachThuoc, long tongTien, string ghiChu)
        {
            string query = @"INSERT INTO ChiTietDonHang 
                           (MaDonHang, MaNhanVien, SoDienThoaiKhachHang, DanhSachThuoc, TongTien, TrangThai, GhiChu) 
                           VALUES (@maDonHang, @maNhanVien, @soDienThoai, @danhSachThuoc, @tongTien, 'CXN', @ghiChu)";

            try
            {
                using (SqlConnection conn = new SqlConnection(Database.GetConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maDonHang", maDonHang);
                    cmd.Parameters.AddWithValue("@maNhanVien", MaNhanVien);
                    cmd.Parameters.AddWithValue("@soDienThoai", tenTK);
                    cmd.Parameters.AddWithValue("@danhSachThuoc", danhSachThuoc);
                    cmd.Parameters.AddWithValue("@tongTien", tongTien);
                    cmd.Parameters.AddWithValue("@ghiChu", ghiChu);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu chi tiết đơn hàng: " + ex.Message);
            }
        }
        public void SaveOrder()
        {
            int tienMua = Convert.ToInt32(txtBill.Text);
            string maDonhang = madonhang(tenTK); // Lấy mã đơn hàng một lần duy nhất

            string query = "insert into QuanLyDonHang (MaDH,SoDT,MaNV,SoTien) values (@madonhang,@sdt,@sdtNV,@tienMua)";
            string status = "insert into TruyXuatDonHang (MaDonHang,SoDienThoai,TrangThai) values (@madonhang,@sdt,'CXN')";
            try
            {
                using (SqlConnection doi_tuong = new SqlConnection(Database.GetConnectionString()))
                {
                    doi_tuong.Open();
                    SqlCommand yeu_cau = new SqlCommand(query, doi_tuong);
                    yeu_cau.Parameters.AddWithValue("@madonhang", maDonhang); 
                    yeu_cau.Parameters.AddWithValue("@sdt", tenTK);
                    yeu_cau.Parameters.AddWithValue("@sdtNV", MaNhanVien);
                    yeu_cau.Parameters.AddWithValue("@tienMua", tienMua);
                    yeu_cau.ExecuteNonQuery();
                }
                using (SqlConnection doi_tuong = new SqlConnection(Database.GetConnectionString()))
                {
                    doi_tuong.Open();
                    SqlCommand yeu_cau = new SqlCommand(status, doi_tuong);
                    yeu_cau.Parameters.AddWithValue("@madonhang", maDonhang); 
                    yeu_cau.Parameters.AddWithValue("@sdt", tenTK);
                    yeu_cau.ExecuteNonQuery();
                }

                // Thu thập thông tin sản phẩm để lưu vào ChiTietDonHang
                StringBuilder danhSachThuoc = new StringBuilder();
                foreach (ListViewItem item in listView1.Items)
                {
                    string tenThuoc = item.Text;
                    string giaTien = item.SubItems[1].Text;
                    string soLuong = item.SubItems[2].Text;
                    danhSachThuoc.AppendLine($"{tenThuoc} - Giá: {giaTien} - SL: {soLuong}");
                }

                // Lưu thông tin vào bảng ChiTietDonHang
                LuuChiTietDonHang(maDonhang, danhSachThuoc.ToString(), tienMua, txtNote.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            invoice = maDonhang + tenTK + "\n" + invoice + "\n" + maDonhang + tenTK + "\n";
        }

        public string madonhang(string sdt)
        {
            int chiSo = 0;
            string query = "select count(MaDH) as SoLuong from QuanLyDonHang where SoDT = @sdt";
            try
            {
                using (SqlConnection doi_tuong = new SqlConnection(Database.GetConnectionString()))
                {
                    doi_tuong.Open();
                    SqlCommand yeu_cau = new SqlCommand(query, doi_tuong);
                    yeu_cau.Parameters.AddWithValue("@sdt", sdt);
                    SqlDataReader reader = yeu_cau.ExecuteReader();
                    if (reader.Read())
                    {
                        string m = reader["SoLuong"].ToString();
                        int.TryParse(m, out chiSo);

                        
                        string ngayThang = DateTime.Now.ToString("yyyyMMdd");
                        return "DH" + ngayThang + "_" + (chiSo + 1).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return null;
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string pathFile = tenTK + ".txt";
            //invoice += "------------------HÓA ĐƠN-------------------\n";
            if (dem>0)
            {
                invoice += "Sản phẩm bị hủy" + "\n";
                invoice += str;
            }
            invoice += "Tổng tiền: " + txtBill.Text + "VND\n";
            invoice += "Ghi chú: " + txtNote.Text + "\n";
            invoice += DateTime.Now.ToString("dd/MM/yyyy") + "\n" +"------------------CẢM ƠN QUÝ KHÁCH HÀNG-------------------" +"\n";
            if (!string.IsNullOrEmpty(invoice))
            {
                try
                {
                    SaveOrder();
                    File.AppendAllText(pathFile, invoice + Environment.NewLine);
                    MessageBox.Show("Vui lòng thanh toán bằng việc quét mã QR","Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                    return;
                }
            }
            int Prase = Convert.ToInt32(txtBill.Text);
            if (string.IsNullOrEmpty(MaNhanVien))
            {
                ThanhToan page = new ThanhToan(Prase, tenKH, tenTK);
                page.Show();
                this.Close();
            }
            else
            {
                ThanhToan page = new ThanhToan(Prase, tenKH, tenTK, MaNhanVien);
                page.Show();
                this.Close();
            }

        }
    }
}
