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
    public partial class Sign_up_Form : Form
    {
        public Sign_up_Form()
        {
            InitializeComponent();
            LoadForm();
        }

        public void LoadForm()
        {
            btnDn.Left = label2.Left + TextRenderer.MeasureText(label2.Text, label2.Font).Width;
            btnDn.Top = label2.Top - (btnDn.Height - label2.Height) / 2;
            this.exit_btn.Hide(); 
        }
        private void sign_in_btn_Click(object sender, EventArgs e)
        {
            string fullname = txtFullName.Text;
            string sdt = txtPhoneNumber.Text;
            string mk = txtPassword.Text;
            string date = txtDate.Text;
            string position = txtPosition.Text;
            string verify = txtVerify.Text;
            bool tam = true;
            
            if (position=="Quản lý" && txtbox.Text == "eManager")
            {
                position = "eManager";
            }
            else
            if (position == "Nhân viên" & txtbox.Text == "eEmployee")
            {
                position = "eEmployee";
            }
            else
            {
                position = "eCustomer";
            }
            
            if (fullname == "" || sdt == "" || mk == "" || date == "" || position == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản!", "Thông báo");
                return;
            }

            EndUser truy_xuat = new EndUser();
            if (truy_xuat.kiem_tra_tai_khoan(sdt, mk) > 0)
            {
                MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo");
                return;
            }

            if (verify == mk)
            {
                tam=truy_xuat.updateData(fullname, date, sdt, position, mk);
            }
            else
                MessageBox.Show("Việc xác nhận mật khẩu chưa đúng!", "Thông báo");
            if (tam==true)
            {
                MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Đăng ký tài khoản không thành công!", "Thông báo");
            }
        }

        private void Sign_up_Form_Load(object sender, EventArgs e)
        {

        }


        private void btnDn_Click(object sender, EventArgs e)
        {
            Sign_in_Form page = new Sign_in_Form();
            this.Hide();
            page.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void exit_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
