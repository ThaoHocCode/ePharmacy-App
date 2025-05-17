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
    public partial class QuanLyNhanVien : Form
    {
        private Database db;
        private bool isEmployeeView = true;

        public QuanLyNhanVien()
        {
            InitializeComponent();
            db = new Database();

            ConfigureDataGridView();

            LoadPositions();
            LoadEmployeeData();
        }

        private void ConfigureDataGridView()
        {
            DataGridView_NhanVien.AutoGenerateColumns = false;
            DataGridView_NhanVien.ColumnHeadersVisible = true;
            DataGridView_NhanVien.RowHeadersVisible = false;
            DataGridView_NhanVien.AllowUserToAddRows = false;
            DataGridView_NhanVien.AllowUserToDeleteRows = false;
            DataGridView_NhanVien.ReadOnly = true;
            DataGridView_NhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView_NhanVien.MultiSelect = false;

            DataGridView_NhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            DataGridView_NhanVien.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            DataGridView_NhanVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridView_NhanVien.EnableHeadersVisualStyles = false;
            DataGridView_NhanVien.ColumnHeadersHeight = 40;
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void LoadPositions()
        {
            try
            {
                DataTable dt = db.Execute("SELECT DISTINCT Position FROM [User]");
                cmbPosition.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string position = row["Position"].ToString();
                    if (!string.IsNullOrEmpty(position))
                    {
                        cmbPosition.Items.Add(position);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chức vụ: " + ex.Message);
            }
        }

        private void LoadEmployeeData()
        {
            try
            {
                CreateEmployeeColumns();

                DataTable dt = db.Execute("SELECT FULLName, [Date], TelephoneNumber, Position FROM [User] WHERE Position = 'eEmployee'");

                dt.Columns.Add("Salary", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    string sdt = row["TelephoneNumber"].ToString();
                    row["Salary"] = CalculateSalary(sdt);
                }

                DataGridView_NhanVien.DataSource = dt;
                SetupEmployeeGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message);
            }
        }

        private void CreateEmployeeColumns()
        {
            DataGridView_NhanVien.Columns.Clear();

            DataGridViewTextBoxColumn fullNameCol = new DataGridViewTextBoxColumn();
            fullNameCol.DataPropertyName = "FULLName";
            fullNameCol.Name = "FULLName";
            fullNameCol.HeaderText = "Họ và tên";
            fullNameCol.Width = 150;

            DataGridViewTextBoxColumn dateCol = new DataGridViewTextBoxColumn();
            dateCol.DataPropertyName = "Date";
            dateCol.Name = "Date";
            dateCol.HeaderText = "Ngày sinh";
            dateCol.Width = 100;

            DataGridViewTextBoxColumn phoneCol = new DataGridViewTextBoxColumn();
            phoneCol.DataPropertyName = "TelephoneNumber";
            phoneCol.Name = "TelephoneNumber";
            phoneCol.HeaderText = "Số điện thoại";
            phoneCol.Width = 120;

            DataGridViewTextBoxColumn positionCol = new DataGridViewTextBoxColumn();
            positionCol.DataPropertyName = "Position";
            positionCol.Name = "Position";
            positionCol.HeaderText = "Chức vụ";
            positionCol.Width = 100;

            DataGridViewTextBoxColumn salaryCol = new DataGridViewTextBoxColumn();
            salaryCol.DataPropertyName = "Salary";
            salaryCol.Name = "Salary";
            salaryCol.HeaderText = "Lương";
            salaryCol.Width = 120;

            DataGridView_NhanVien.Columns.Add(fullNameCol);
            DataGridView_NhanVien.Columns.Add(dateCol);
            DataGridView_NhanVien.Columns.Add(phoneCol);
            DataGridView_NhanVien.Columns.Add(positionCol);
            DataGridView_NhanVien.Columns.Add(salaryCol);
        }

        private void LoadAllUserData()
        {
            try
            {
                CreateAllUserColumns();

                DataTable dt = db.Execute("SELECT FULLName, [Date], TelephoneNumber, Position FROM [User]");

                DataGridView_NhanVien.DataSource = dt;
                SetupAllUsersGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu người dùng: " + ex.Message);
            }
        }

        private void CreateAllUserColumns()
        {
            DataGridView_NhanVien.Columns.Clear();

            DataGridViewTextBoxColumn fullNameCol = new DataGridViewTextBoxColumn();
            fullNameCol.DataPropertyName = "FULLName";
            fullNameCol.Name = "FULLName";
            fullNameCol.HeaderText = "Họ và tên";
            fullNameCol.Width = 150;

            DataGridViewTextBoxColumn dateCol = new DataGridViewTextBoxColumn();
            dateCol.DataPropertyName = "Date";
            dateCol.Name = "Date";
            dateCol.HeaderText = "Ngày sinh";
            dateCol.Width = 100;

            DataGridViewTextBoxColumn phoneCol = new DataGridViewTextBoxColumn();
            phoneCol.DataPropertyName = "TelephoneNumber";
            phoneCol.Name = "TelephoneNumber";
            phoneCol.HeaderText = "Số điện thoại";
            phoneCol.Width = 120;

            DataGridViewTextBoxColumn positionCol = new DataGridViewTextBoxColumn();
            positionCol.DataPropertyName = "Position";
            positionCol.Name = "Position";
            positionCol.HeaderText = "Chức vụ";
            positionCol.Width = 100;

            DataGridView_NhanVien.Columns.Add(fullNameCol);
            DataGridView_NhanVien.Columns.Add(dateCol);
            DataGridView_NhanVien.Columns.Add(phoneCol);
            DataGridView_NhanVien.Columns.Add(positionCol);
        }

        private void SetupEmployeeGridColumns()
        {
            DataGridView_NhanVien.ColumnHeadersVisible = true;
            DataGridView_NhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            DataGridView_NhanVien.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            DataGridView_NhanVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridView_NhanVien.EnableHeadersVisualStyles = false;
            DataGridView_NhanVien.ColumnHeadersHeight = 40;

            DataGridView_NhanVien.Columns["FULLName"].HeaderText = "Họ và tên";
            DataGridView_NhanVien.Columns["Date"].HeaderText = "Ngày sinh";
            DataGridView_NhanVien.Columns["TelephoneNumber"].HeaderText = "Số điện thoại";
            DataGridView_NhanVien.Columns["Position"].HeaderText = "Chức vụ";
            DataGridView_NhanVien.Columns["Salary"].HeaderText = "Lương";

            DataGridView_NhanVien.Columns["FULLName"].Width = 150;
            DataGridView_NhanVien.Columns["Date"].Width = 100;
            DataGridView_NhanVien.Columns["TelephoneNumber"].Width = 120;
            DataGridView_NhanVien.Columns["Position"].Width = 100;
            DataGridView_NhanVien.Columns["Salary"].Width = 120;
        }

        private void SetupAllUsersGridColumns()
        {
            DataGridView_NhanVien.ColumnHeadersVisible = true;
            DataGridView_NhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            DataGridView_NhanVien.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            DataGridView_NhanVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridView_NhanVien.EnableHeadersVisualStyles = false;
            DataGridView_NhanVien.ColumnHeadersHeight = 40;

            DataGridView_NhanVien.Columns["FULLName"].HeaderText = "Họ và tên";
            DataGridView_NhanVien.Columns["Date"].HeaderText = "Ngày sinh";
            DataGridView_NhanVien.Columns["TelephoneNumber"].HeaderText = "Số điện thoại";
            DataGridView_NhanVien.Columns["Position"].HeaderText = "Chức vụ";

            DataGridView_NhanVien.Columns["FULLName"].Width = 150;
            DataGridView_NhanVien.Columns["Date"].Width = 100;
            DataGridView_NhanVien.Columns["TelephoneNumber"].Width = 120;
            DataGridView_NhanVien.Columns["Position"].Width = 100;
        }

        private string CalculateSalary(string sdt)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@sdt", sdt)
                };

                DataTable dt = db.ExecuteWithParameters(
                    "SELECT SUM(SoTien) AS TongTien FROM QuanLyDonHang WHERE MaNV = @sdt",
                    parameters);

                long tongTien = 0;
                if (dt.Rows.Count > 0 && dt.Rows[0]["TongTien"] != DBNull.Value)
                {
                    tongTien = Convert.ToInt64(dt.Rows[0]["TongTien"]);
                }

                if (tongTien <= 5000000)
                {
                    return "5.560.450 VND";
                }
                else if (tongTien <= 10000000)
                {
                    return "8.000.000 VND";
                }
                else
                {
                    float luong = tongTien * 0.008f;
                    return string.Format("{0:N0} VND", tongTien + luong);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính lương: " + ex.Message);
                return "0 VND";
            }
        }

        private void DataGridView_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DataGridView_NhanVien.Rows[e.RowIndex];

                txtName.Text = row.Cells["FULLName"].Value.ToString();
                txtBirth.Text = row.Cells["Date"].Value.ToString();
                txtPhone.Text = row.Cells["TelephoneNumber"].Value.ToString();
                cmbPosition.Text = row.Cells["Position"].Value.ToString();

                if (isEmployeeView && DataGridView_NhanVien.Columns.Contains("Salary"))
                {
                    txtSalary.Text = row.Cells["Salary"].Value.ToString();
                }
                else
                {
                    txtSalary.Text = "";
                }
            }
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtBirth.Text = "";
            txtPhone.Text = "";
            cmbPosition.Text = "";
            txtSalary.Text = "";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_TaiKhoan_Click_1(object sender, EventArgs e)
        {
            isEmployeeView = !isEmployeeView;

            if (isEmployeeView)
            {
                btn_TaiKhoan.Text = "Xem tất cả tài khoản";
                LoadEmployeeData();
            }
            else
            {
                btn_TaiKhoan.Text = "Xem nhân viên";
                LoadAllUserData();
                txtSalary.Text = "";
            }

            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?",
                                                "Xác nhận xóa",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@phone", txtPhone.Text)
                    };

                    int rowsAffected = db.ExecuteNonQuery(
                        "DELETE FROM [User] WHERE TelephoneNumber = @phone",
                        parameters);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa người dùng thành công!");
                        ClearFields();

                        if (isEmployeeView)
                            LoadEmployeeData();
                        else
                            LoadAllUserData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy người dùng cần xóa!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa người dùng: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng chọn người dùng cần cập nhật!");
                return;
            }

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@name", txtName.Text),
                    new SqlParameter("@birth", txtBirth.Text),
                    new SqlParameter("@position", cmbPosition.Text),
                    new SqlParameter("@phone", txtPhone.Text)
                };

                int result = db.ExecuteNonQuery(
                    "UPDATE [User] SET FULLName = @name, [Date] = @birth, Position = @position " +
                    "WHERE TelephoneNumber = @phone",
                    parameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    ClearFields();

                    if (isEmployeeView)
                        LoadEmployeeData();
                    else
                        LoadAllUserData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy người dùng cần cập nhật!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtBirth.Text) ||
                string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(cmbPosition.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try
            {

                SqlParameter[] checkParams = new SqlParameter[]
                {
                    new SqlParameter("@sdt", txtPhone.Text)
                };

                DataTable result = db.ExecuteWithParameters(
                    "SELECT COUNT(*) AS Count FROM [User] WHERE TelephoneNumber = @sdt",
                    checkParams);

                int count = Convert.ToInt32(result.Rows[0]["Count"]);

                if (count > 0)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại trong hệ thống!");
                    return;
                }


                SqlParameter[] insertParams = new SqlParameter[]
                {
                    new SqlParameter("@name", txtName.Text),
                    new SqlParameter("@birth", txtBirth.Text),
                    new SqlParameter("@phone", txtPhone.Text),
                    new SqlParameter("@position", cmbPosition.Text),
                    new SqlParameter("@password", "123456")
                };

                int rowsAffected = db.ExecuteNonQuery(
                    "INSERT INTO [User] (FULLName, [Date], TelephoneNumber, Position, Password) " +
                    "VALUES (@name, @birth, @phone, @position, @password)",
                    insertParams);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm người dùng thành công!");
                    ClearFields();

                    if (isEmployeeView)
                        LoadEmployeeData();
                    else
                        LoadAllUserData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm người dùng: " + ex.Message);
            }
        }

        private void QuanLyNhanVien_Load_1(object sender, EventArgs e)
        {

        }
    }
}