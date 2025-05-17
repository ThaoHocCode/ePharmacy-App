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
    public partial class PhanHoi : Form
    {
        public string SoDienThoai;
        public PhanHoi(string sdt)
        {
            InitializeComponent();
            SoDienThoai = sdt;
            loadForm();
        }


        private void PhanHoi_Load(object sender, EventArgs e)
        {
            
        }
        public void loadForm()
        {
            listView1.Items.Clear();
            string query = "select SoDienThoai,Email,LoaiPhanHoi,PhanHoi from Feedback";
            try
            {
                using (SqlConnection loadData = new SqlConnection(Database.GetConnectionString()))
                {
                    loadData.Open();
                    SqlCommand command = new SqlCommand(query, loadData);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["SoDienThoai"].ToString());
                        item.SubItems.Add(reader["Email"].ToString());
                        item.SubItems.Add(reader["LoaiPhanHoi"].ToString());
                        item.SubItems.Add(reader["PhanHoi"].ToString());

                        listView1.Items.Add(item);
                        txtSoDienThoai.Clear();
                        txtEmail.Clear();
                        txtLoaiGopY.Clear();
                        textBox.Clear();
                        txtHoVaTen.Clear();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        public void timHoVaTen(string sdt)
        {
            string query = "select FullName from [User] where TelephoneNumber = @sdt";
            try
            {
                using (SqlConnection loadData = new SqlConnection(Database.GetConnectionString()))
                {
                    loadData.Open();
                    SqlCommand command = new SqlCommand(query, loadData);
                    command.Parameters.AddWithValue("@sdt", sdt);
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
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                //string SoDienThoai = selectedItem.SubItems[0].Text;
                txtSoDienThoai.Text = selectedItem.SubItems[0].Text;
                txtEmail.Text = selectedItem.SubItems[1].Text;
                txtLoaiGopY.Text = selectedItem.SubItems[2].Text;
                textBox.Text = selectedItem.SubItems[3].Text;
                timHoVaTen(txtSoDienThoai.Text);
            }
        }

        private void txtHoVaTen_TextChanged(object sender, EventArgs e)
        {

        }

        public void deleteData()
        {
            string query = "DELETE FROM Feedback WHERE SoDienThoai = @sdt AND PhanHoi =@ph";
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text);
                        cmd.Parameters.AddWithValue("@ph", textBox.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            deleteData();
            loadForm();
            MessageBox.Show("Cảm ơn bạn đã gửi phản hồi cho chúng tôi. Chúng tôi sẽ xem xét và phản hồi lại bạn trong thời gian sớm nhất.","Thông báo");
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee page = new Employee(SoDienThoai);
            page.Show();
        }
    }
}
