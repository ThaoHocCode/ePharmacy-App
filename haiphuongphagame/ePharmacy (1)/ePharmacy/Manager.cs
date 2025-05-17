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
using static QRCoder.PayloadGenerator;

namespace ePharmacy
{
    public partial class Manager : Form
    {
        private string managerPhone;
        public Manager( string phoneNumber)
        {
            InitializeComponent();
            managerPhone = phoneNumber;
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            lblManagerName.Text = GetManagerName(managerPhone);

            
        }
        private string GetManagerName(string phone)
        {
            string name = "";

            try
            {
                using (SqlConnection conn = new SqlConnection(Database.GetConnectionString()))
                {
                    conn.Open();
                    string query = "SELECT FullName FROM [User] WHERE TelephoneNumber = @phone";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@phone", phone);
                        name = (string)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            return name;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Sign_in_Form signInForm = new Sign_in_Form();
            signInForm.Show();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            ThongKeDoanhThu revenueReportForm = new ThongKeDoanhThu();
            revenueReportForm.Show();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien quanly = new QuanLyNhanVien();
            quanly.Show();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            QuanLyKhoThuoc quanLyKhoThuoc = new QuanLyKhoThuoc();
            quanLyKhoThuoc.Show();
        }
    }
}
