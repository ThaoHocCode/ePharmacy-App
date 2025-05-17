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
    public partial class Employee : Form
    {
        public string PhoneNumber;
        public Employee(string sdt)
        {
            InitializeComponent();
            PhoneNumber = sdt;
            panelMainForm.Dock = DockStyle.Fill;
            label1.Text=LoadForm(PhoneNumber);
        }

        public string LoadForm(string s)
        {
            string query = "select FullName from [User] where TelephoneNumber=@sdt";
            //mainPanel.Dock = DockStyle.Fill;
            try
            {
                using (SqlConnection doi_tuong = new SqlConnection(Database.GetConnectionString()))
                {
                    doi_tuong.Open();
                    SqlCommand yeu_cau = new SqlCommand(query,doi_tuong);
                    {
                        yeu_cau.Parameters.AddWithValue("@sdt", s);
                        string tenKhachHang = (string)yeu_cau.ExecuteScalar();
                        s = tenKhachHang;
                        return s;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return "";

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {
                   
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tao_TK page = new Tao_TK(PhoneNumber);
            page.Show();
        }

        private void guna2Panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sign_in_Form page = new Sign_in_Form();
            page.Show();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSoKhamBenh_Click(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại","Thông báo");
                return;
            }
            this.Hide();
            So_Kham_Benh so_Kham_Benh = new So_Kham_Benh(LoadForm(txtPhoneNumber.Text), txtPhoneNumber.Text,LoadForm(PhoneNumber),PhoneNumber);
            so_Kham_Benh.Show();
        }
        public void Window_SoKhamBenh(string s)
        {
            So_Kham_Benh callForm = new So_Kham_Benh(LoadForm(s),s);
            callForm.TopLevel = false;
            callForm.FormBorderStyle = FormBorderStyle.None;
            callForm.Dock = DockStyle.Fill;
            callForm.Enabled = true;
            panelMainForm.Controls.Clear();
            panelMainForm.Controls.Add(callForm);
            callForm.Show();
            callForm.BringToFront();
            callForm.Focus();
        }

        private void btnPress_Click(object sender, EventArgs e)
        {
            string query = "select count(*) from [User] where TelephoneNumber=@sdt";
            try
            {
                using (SqlConnection doi_tuong = new SqlConnection(Database.GetConnectionString()))
                {
                    doi_tuong.Open();
                    SqlCommand yeu_cau = new SqlCommand(query, doi_tuong);
                    yeu_cau.Parameters.AddWithValue("@sdt", txtPhoneNumber.Text);
                    int count = (int)yeu_cau.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Số điện thoại tồn tại trong hệ thống", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại không tồn tại trong hệ thống","Thông báo");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDatDonThuoc_Click(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại","Thông báo");
                return;
            }
            this.Hide();
            Tao_don page = new Tao_don(LoadForm(txtPhoneNumber.Text), txtPhoneNumber.Text,PhoneNumber);
            page.Show();
        }

        private void btnKiemTraDonThuoc_Click(object sender, EventArgs e)
        {
            this.Hide();
            KT_don page = new KT_don(PhoneNumber);
            page.Show();
        }

        private void btnChamSocKhachHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            PhanHoi page = new PhanHoi(PhoneNumber);
            page.Show();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongKe page = new ThongKe(PhoneNumber);
            page.Show();
        }

        private void panelMainForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
