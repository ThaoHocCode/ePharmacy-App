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
    public partial class So_Kham_Benh : Form
    {
        public string tenTK;
        public string tenKH;
        public string tenNV;
        public string sdtNV;
        public string gt;
        //public int dieukien = 0;
        public So_Kham_Benh(string KH, string TK)
        {
            InitializeComponent();
            tenKH = KH;
            tenTK = TK;
            LoadForm();
        }

        public So_Kham_Benh(string s1,string s2,string s3, string s4)
        {
            InitializeComponent();
            tenKH = s1;
            tenTK = s2;
            tenNV = s3;
            sdtNV = s4;
            AddExitButton();
            LoadForm();
        }

        private void AddExitButton()
        {
            Button btnExit = new Button();
            btnExit.Name = "btnExit";
            btnExit.Text = "X";
            btnExit.Size = new Size(40, 30);
            btnExit.Location = new Point(560, 10); // Hoặc this.ClientSize.Width - 50
            btnExit.BackColor = Color.Red;
            btnExit.ForeColor = Color.White;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnExit.Click += btnExit_Click;

            this.Controls.Add(btnExit);
            btnExit.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee emp = new Employee(sdtNV);
            emp.Show();
        }

        public void LoadForm()
        {
            string query1 = "select FullName,Date,TelephoneNumber,Position,Password from [User] where TelephoneNumber=@sdt";
            string query2 = "select GioiTinh from Information_User where SoDienThoai=@sdt";

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
                        //MessageBox.Show("Đã lấy được giới tính");
                        string gt = reader["GioiTinh"].ToString();
                        txGioiTinh.Text = gt;
                        picBox.Image = null;
                        if (gt=="Nam")
                            picBox.Image = Properties.Resources.image_boy;
                        else
                            picBox.Image = Properties.Resources.image_woman;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }
        private void So_Kham_Benh_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
