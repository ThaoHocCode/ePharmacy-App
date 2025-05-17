using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ePharmacy
{
    public partial class Customer : Form
    {
        private string tenTaiKhoan;
        private string tenKhachHang;
        public Customer(string name,string sdt)
        {
            InitializeComponent();
            tenKhachHang = name;
            tenTaiKhoan = sdt;
            LoadForm();
        }

        public void LoadForm()
        {
            label1.Text = tenKhachHang;
            btnExit.Visible= false;
        }

        


        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadForm1InGroupBox()
        {
            Thong_tin_KH form1 = new Thong_tin_KH(tenKhachHang,tenTaiKhoan);
            form1.TopLevel = false; 
            form1.FormBorderStyle = FormBorderStyle.None; 
            form1.Dock = DockStyle.Fill; 
            form1.Enabled = true;
            panel_number1.Controls.Clear();
            panel_number1.Controls.Add(form1);
            form1.Show(); 
            form1.BringToFront();
            form1.Focus();
        }

        public void Window_SoKhamBenh()
        {
            So_Kham_Benh form2 = new So_Kham_Benh(tenKhachHang, tenTaiKhoan);
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;
            form2.Enabled = true;
            panel_number1.Controls.Clear();
            panel_number1.Controls.Add(form2);
            form2.Show();
            form2.BringToFront();
            form2.Focus();
        }

        public void Window_ChamSocKhachHang()
        {
        Cham_soc_KH form3 = new Cham_soc_KH(tenKhachHang, tenTaiKhoan);
            form3.TopLevel = false;
            form3.FormBorderStyle = FormBorderStyle.None;
            form3.Dock = DockStyle.Fill;
            form3.Enabled = true;
            panel_number1.Controls.Clear();
            panel_number1.Controls.Add(form3);
            form3.Show();
            form3.BringToFront();
            form3.Focus();
        }

        private void btnThongTinKhachHang_Click(object sender, EventArgs e)
        {
           LoadForm1InGroupBox();

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sign_in_Form signInForm = new Sign_in_Form();
            signInForm.Show();
        }

        private void btnDatDonThuoc_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tao_don tao_Don = new Tao_don(tenKhachHang, tenTaiKhoan);
            tao_Don.Show();

        }

        private void btnSoKhamBenh_Click(object sender, EventArgs e)
        {
            Window_SoKhamBenh();
        }

        private void btnChamSocKhachHang_Click(object sender, EventArgs e)
        {
            Window_ChamSocKhachHang();
            
        }

        
    }
}
