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
    public partial class Thong_tin_KH : Form
    {
        public string tenTK;
        public string tenKH;

        public Thong_tin_KH(string tenKhachHang, string tenTaiKhoan)
        {
            InitializeComponent();
            tenTK = tenTaiKhoan;
            tenKH = tenKhachHang;
            LoadForm();
        }

        public void LoadForm()
        {
            string query1 = "select FullName,Date,TelephoneNumber,Position,Password from [User] where TelephoneNumber=@sdt";
            string query2 = "select GioiTinh,DiemTichLuy from Information_User where SoDienThoai=@sdt";

            try
            {
                using (SqlConnection loadData = new SqlConnection(Database.GetConnectionString()))
                {
                    loadData.Open();
                    SqlCommand command = new SqlCommand(query1, loadData);
                    command.Parameters.AddWithValue("@sdt", tenTK);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtHoVaTen.Text = reader["FullName"].ToString();
                        txtNgaySinh.Text = reader["Date"].ToString();
                        txtSoDienThoai.Text = reader["TelephoneNumber"].ToString();
                        txtMaKH.Text = reader["Position"].ToString() + reader["TelephoneNumber"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin khách hàng.");
                    }
                }
                using (SqlConnection loadData = new SqlConnection(Database.GetConnectionString()))
                {
                    loadData.Open();
                    SqlCommand command = new SqlCommand(query2, loadData);
                    command.Parameters.AddWithValue("@sdt", tenTK);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        checkBox_1.Checked = false;
                        checkbox_2.Checked = false;
                        string gt = reader["GioiTinh"].ToString();
                        if (gt == "Nam")
                            checkBox_1.Checked = true;
                        else 
                            checkbox_2.Checked = true;
                        txtDiemTichLuy.Text = reader["DiemTichLuy"].ToString();

                    }
                }
                if (checkBox_1.Checked == true)
                {
                    picture_box.Image = null;
                    picture_box.Image = Properties.Resources.image_boy;
                }
                else
                    if (checkbox_2.Checked == true)
                {
                    picture_box.Image = null;
                    picture_box.Image = Properties.Resources.image_woman;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }

        private void Thong_tin_KH_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string gt = null;
            if (checkBox_1.Checked && checkbox_2.Checked)
            {
                MessageBox.Show("Vui lòng chọn một giới tính duy nhất.");
                return;
            }
            else if (checkBox_1.Checked)
            {
                gt = "Nam";
            }
            else if (checkbox_2.Checked)
            {
                gt = "Nữ";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtHoVaTen.Text) ||
                string.IsNullOrWhiteSpace(txtNgaySinh.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSoDienThoai.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải là 10 chữ số.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtNgaySinh.Text, @"^\d{2}/\d{2}/\d{4}$"))
            {
                MessageBox.Show("Ngày sinh phải có định dạng dd/MM/yyyy.");
                return;
            }
            string query1 = "UPDATE Information_User SET GioiTinh = @gt WHERE SoDienThoai = @sdt";
            string query2 = "UPDATE [User] SET FullName = @ht, [Date] = @ns, TelephoneNumber = @sdt WHERE TelephoneNumber = @sdt";

            try
            {
                using (SqlConnection connection = new SqlConnection(Database.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Thực hiện truy vấn 1
                            using (SqlCommand command1 = new SqlCommand(query1, connection, transaction))
                            {
                                command1.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text);
                                command1.Parameters.AddWithValue("@gt", gt);
                                int rowsAffected1 = command1.ExecuteNonQuery();

                                if (rowsAffected1 == 0)
                                {
                                    MessageBox.Show("Không tìm thấy thông tin khách hàng trong bảng Information_User.");
                                    transaction.Rollback();
                                    return;
                                }
                            }

                            // Thực hiện truy vấn 2
                            using (SqlCommand command2 = new SqlCommand(query2, connection, transaction))
                            {
                                command2.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text);
                                command2.Parameters.AddWithValue("@ht", txtHoVaTen.Text);
                                command2.Parameters.AddWithValue("@ns", txtNgaySinh.Text);
                                int rowsAffected2 = command2.ExecuteNonQuery();

                                if (rowsAffected2 == 0)
                                {
                                    MessageBox.Show("Không tìm thấy thông tin khách hàng trong bảng User.");
                                    transaction.Rollback();
                                    return;
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Cập nhật thông tin thành công!");
                            LoadForm(); 
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSoKhamBenh_Click(object sender, EventArgs e)
        {

        }
    }
}
