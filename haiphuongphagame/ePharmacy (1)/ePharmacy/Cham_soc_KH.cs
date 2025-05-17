using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePharmacy
{
    public partial class Cham_soc_KH : Form
    {
        public string tenTK;
        public string tenKH;
        public Cham_soc_KH(string KH,string TK)
        {
            InitializeComponent();
            tenKH = KH;
            tenTK = TK;
            LoadForm();
        }

        public void LoadForm()
        {
           txtSoDienThoai.Text = tenTK;
            string query = "select FullName from [User] where TelephoneNumber = @values";
            try
            {
                using (SqlConnection loadData = new SqlConnection(Database.GetConnectionString()))
                {
                    loadData.Open();
                    SqlCommand command = new SqlCommand(query, loadData);
                    command.Parameters.AddWithValue("@values", tenTK);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtHoVaTen.Text = reader["FullName"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Truy xuất dữ liệu thất bại");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }
        private void Cham_soc_KH_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            string query = "insert into Feedback (SoDienThoai,Email,LoaiPhanHoi,PhanHoi) values (@values1,@values2,@values3,@values4)";
            try
            {
                using (SqlConnection loadData = new SqlConnection(Database.GetConnectionString()))
                {
                    loadData.Open();
                    SqlCommand command = new SqlCommand(query, loadData);
                    command.Parameters.AddWithValue("@values1", txtSoDienThoai.Text);
                    command.Parameters.AddWithValue("@values2", txtEmail.Text);
                    command.Parameters.AddWithValue("@values3", comboBox.Text);
                    command.Parameters.AddWithValue("@values4", textBox.Text);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Gửi phản hồi thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Gửi phản hồi không thành công.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
