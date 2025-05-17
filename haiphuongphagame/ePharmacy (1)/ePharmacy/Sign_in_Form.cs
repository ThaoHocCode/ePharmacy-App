using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePharmacy
{
    public partial class Sign_in_Form : Form
    {

        public string tenTaiKhoan;
        public string tenKhachHang;
        public Sign_in_Form()
        {
            InitializeComponent();
            LoadForm();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        public void LoadForm()
        {
            btnDk.Left = label2.Left + TextRenderer.MeasureText(label2.Text, label2.Font).Width;
            btnDk.Top = label2.Top - (btnDk.Height - label2.Height) / 2;
           

        }
        private void sign_in_btn_Click(object sender, EventArgs e)
        {
            string sdt = txtSdt.Text;
            string mk = txtMk.Text;
            if (sdt == "" || mk == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản!", "Thông báo");
                return;
            }
            EndUser truy_xuat = new EndUser();
            if (truy_xuat.kiem_tra_tai_khoan(sdt, mk) == 0)
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Thông báo");
                return;
            }
            string position = truy_xuat.kiem_tra_vi_tri(sdt, mk);
            string tenKhachHang = truy_xuat.kiem_tra_ten_khach_hang(sdt, mk);

            if (position == "eManager")
            {
                Manager page = new Manager(sdt);
                this.Hide();
                page.Show();
            }
            else if (position == "eEmployee")
            {
                Employee page = new Employee(sdt);
                this.Hide();
                page.Show();
            }
            else if (position == "eCustomer")
            {
                Customer page = new Customer(tenKhachHang, sdt);
                this.Hide();
                page.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lại đúng thông tin tài khoản!", "Thông báo");
            }
          

            }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            Sign_up_Form page = new Sign_up_Form();
            this.Hide();
            page.Show(); 
        }

        private void Sign_in_Form_Load(object sender, EventArgs e)
        {

        }

        private void txtMk_TextChanged(object sender, EventArgs e)
        {
         

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtMk.UseSystemPasswordChar = !checkbox.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Sign_up_Form page = new Sign_up_Form();
            this.Hide();
            page.Show();
        }
    }
}
