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
    public partial class Tao_TK : Form
    {
        public string phoneNumber;
        public Tao_TK(string sdt)
        {
            InitializeComponent();
            phoneNumber = sdt;
        }

        private void Tao_TK_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            int count1 = 0;
            string fullname = txtFullName.Text;
            string sdt = txtPhoneNumber.Text;
            string mk = txtPassword.Text;
            string date = txtDate.Text;
            string position = txtPosition.Text;
            string verify = txtVerify.Text;
            string query = "insert into [User] (FullName, Date,TelephoneNumber,Position,Password) values (@fullname,@date,@sdt,@position,@mk)";
            string checksdt = "select count(*) from [User] where TelephoneNumber=@sdt";
            string query_db = "insert into Information_User (SoDienThoai,GioiTinh,DiemTichLuy) values (@sdt,@gt,@dtl)";
            if (position == "Quản lý")
            {
                position = "eManager";
            }
            else
            if (position == "Nhân viên")
            {
                position = "eEmployee";
            }
            else
            {
                position = "eCustomer";
            }
            try
            {
                using (SqlConnection doi_tuong = new SqlConnection(Database.GetConnectionString()))
                {
                    doi_tuong.Open();
                    SqlCommand yeu_cau = new SqlCommand(checksdt, doi_tuong);
                    yeu_cau.Parameters.AddWithValue("@fullname", fullname);
                    yeu_cau.Parameters.AddWithValue("@date", date);
                    yeu_cau.Parameters.AddWithValue("@sdt", sdt);
                    yeu_cau.Parameters.AddWithValue("@position", position);
                    yeu_cau.Parameters.AddWithValue("@mk", mk);
                    int count = (int)yeu_cau.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại", "Thông báo");
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            if (verify == mk)
            {
                try
                {
                    using (SqlConnection doi_tuong = new SqlConnection(Database.GetConnectionString()))
                    {
                        doi_tuong.Open();
                        SqlCommand yeu_cau = new SqlCommand(query, doi_tuong);
                        yeu_cau.Parameters.AddWithValue("@fullname", fullname);
                        yeu_cau.Parameters.AddWithValue("@date", date);
                        yeu_cau.Parameters.AddWithValue("@sdt", sdt);
                        yeu_cau.Parameters.AddWithValue("@position", position);
                        yeu_cau.Parameters.AddWithValue("@mk", mk);
                        count1 = yeu_cau.ExecuteNonQuery();

                    }
                    using (SqlConnection doi_tuong = new SqlConnection(Database.GetConnectionString()))
                    {
                        doi_tuong.Open();
                        SqlCommand yeu_cau = new SqlCommand(query_db, doi_tuong);
                        yeu_cau.Parameters.AddWithValue("@sdt", sdt);
                        yeu_cau.Parameters.AddWithValue("@gt", "null");
                        yeu_cau.Parameters.AddWithValue("@dtl", 0);
                        int count2 = yeu_cau.ExecuteNonQuery();
                        if (count2 > 0 & count1 > 0)
                        {
                            MessageBox.Show("Đăng ký thành công", "Thông báo");
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                }
            }
            else
                MessageBox.Show("Việc xác nhận mật khẩu chưa đúng!", "Thông báo");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee employee = new Employee(phoneNumber);
            employee.Show();
        }
    }
}
