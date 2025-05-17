using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePharmacy
{
    public partial class ThanhToan : Form
    {
        public long tongtien;
        public string khachhang;
        public string taikhoan;
        public string manv=null;
        public ThanhToan(int tt,string KH,string TK)
        {
            InitializeComponent();
            tongtien = tt;
            khachhang = KH;
            taikhoan = TK;
            LoadForm();
        }

        public ThanhToan(int tt,string KH,string TK,string maNV)
        {
            InitializeComponent();
            tongtien = tt;
            khachhang = KH;
            taikhoan = TK;
            manv = maNV;
            LoadForm();
        }
        public void LoadForm()
        {
            string inputText = "Hóa đơn của bạn là: " + tongtien + "VND";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(inputText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pictureBox.Image = qrCodeImage;
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           if (manv=="orderOnline")
            {
                //MessageBox.Show("Thanh toán thành công");
                this.Hide();
                Customer page = new Customer(khachhang, taikhoan);
                page.Show();
            }
            else
            {
                //MessageBox.Show("Thanh toán thành công");
                this.Hide();
                Employee page = new Employee(manv);
                page.Show();
            }
        }
    }
}
