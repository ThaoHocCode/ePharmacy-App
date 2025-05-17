using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePharmacy
{
    public partial class QuanLyKhoThuoc : Form
    {
        private DataTable dtSanPham;
        private readonly Medication medicationManager;

        public QuanLyKhoThuoc()
        {
            InitializeComponent();
            medicationManager = new Medication();
            LoadData();
            LoadComboBoxes();
        }

        private void SetupDataGridView()
        {
            DataGridView_KhoThuoc.Columns["ID"].HeaderText = "ID";
            DataGridView_KhoThuoc.Columns["Type"].HeaderText = "Kiểu hàng";
            DataGridView_KhoThuoc.Columns["Group"].HeaderText = "Nhóm hàng";
            DataGridView_KhoThuoc.Columns["GoodsCode"].HeaderText = "Mã hàng";
            DataGridView_KhoThuoc.Columns["BarCode"].HeaderText = "Mã vạch";
            DataGridView_KhoThuoc.Columns["CommodityName"].HeaderText = "Tên hàng";
            DataGridView_KhoThuoc.Columns["Number"].HeaderText = "Số lượng";
            DataGridView_KhoThuoc.Columns["DugCode"].HeaderText = "Mã thuốc";
            DataGridView_KhoThuoc.Columns["ActiveElement"].HeaderText = "Hoạt chất";
            DataGridView_KhoThuoc.Columns["Manufacturer"].HeaderText = "Nhà sản xuất";
            DataGridView_KhoThuoc.Columns["Packaging"].HeaderText = "Đóng gói";
            DataGridView_KhoThuoc.Columns["Packaging2"].HeaderText = "Đóng gói 2";
            DataGridView_KhoThuoc.Columns["Cost"].HeaderText = "Giá nhập";
            DataGridView_KhoThuoc.Columns["Iventory"].HeaderText = "Tồn kho";
            DataGridView_KhoThuoc.Columns["Description"].HeaderText = "Mô tả";
            DataGridView_KhoThuoc.Columns["Consignment"].HeaderText = "Lô hàng";
            DataGridView_KhoThuoc.Columns["ExpiryDate"].HeaderText = "Ngày hết hạn";

            DataGridView_KhoThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DataGridView_KhoThuoc.ColumnHeadersVisible = true;
            DataGridView_KhoThuoc.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            DataGridView_KhoThuoc.ColumnHeadersHeight = 40;
        }

        private void LoadData()
        {
            try
            {
                dtSanPham = medicationManager.GetAllMedications();
                DataGridView_KhoThuoc.DataSource = dtSanPham;
                SetupDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                DataTable dtType = medicationManager.GetDistinctTypes();

                DataTable dtTypeFilter = dtType.Copy();
                DataRow typeFilterRow = dtTypeFilter.NewRow();
                typeFilterRow["Type"] = "Không lọc";
                dtTypeFilter.Rows.InsertAt(typeFilterRow, 0);

                cmbType.DataSource = dtType;
                cmbType.DisplayMember = "Type";
                cmbType.ValueMember = "Type";
                cmbType.SelectedIndex = -1;

                cmbLockieuhang.DataSource = dtTypeFilter;
                cmbLockieuhang.DisplayMember = "Type";
                cmbLockieuhang.ValueMember = "Type";
                cmbLockieuhang.SelectedIndex = 0;

                DataTable dtGroup = medicationManager.GetDistinctGroups();

                DataTable dtGroupFilter = dtGroup.Copy();
                DataRow groupFilterRow = dtGroupFilter.NewRow();
                groupFilterRow["Group"] = "Không lọc";
                dtGroupFilter.Rows.InsertAt(groupFilterRow, 0);

                cmbGroup.DataSource = dtGroup;
                cmbGroup.DisplayMember = "Group";
                cmbGroup.ValueMember = "Group";
                cmbGroup.SelectedIndex = -1;

                cmbLocnhomhang.DataSource = dtGroupFilter;
                cmbLocnhomhang.DisplayMember = "Group";
                cmbLocnhomhang.ValueMember = "Group";
                cmbLocnhomhang.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            try
            {
                string typeFilter = cmbLockieuhang.Text;
                string groupFilter = cmbLocnhomhang.Text;

                if (typeFilter == "Không lọc" && groupFilter == "Không lọc")
                {
                    LoadData();
                }
                else
                {
                    dtSanPham = medicationManager.FilterMedications(typeFilter, groupFilter);
                    DataGridView_KhoThuoc.DataSource = dtSanPham;
                    SetupDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView_KhoThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DataGridView_KhoThuoc.Rows[e.RowIndex];

                txtID.Text = row.Cells["ID"].Value?.ToString() ?? "";
                cmbType.Text = row.Cells["Type"].Value?.ToString() ?? "";
                cmbGroup.Text = row.Cells["Group"].Value?.ToString() ?? "";
                txtGoodsCode.Text = row.Cells["GoodsCode"].Value?.ToString() ?? "";
                txtName.Text = row.Cells["CommodityName"].Value?.ToString() ?? "";
                txtActiveElement.Text = row.Cells["ActiveElement"].Value?.ToString() ?? "";
                txtManufacturer.Text = row.Cells["Manufacturer"].Value?.ToString() ?? "";
                txtPackaging.Text = row.Cells["Packaging"].Value?.ToString() ?? "";
                txtCost.Text = row.Cells["Cost"].Value?.ToString() ?? "";
                txtIventory.Text = row.Cells["Iventory"].Value?.ToString() ?? "";

                if (row.Cells["ExpiryDate"].Value != DBNull.Value)
                {
                    DateTime expiryDate = Convert.ToDateTime(row.Cells["ExpiryDate"].Value);
                    txtExpiryDate.Text = expiryDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    txtExpiryDate.Text = "";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtGoodsCode.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc (Tên thuốc, Mã hàng)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                medicationManager.AddMedication(
                    cmbType.Text,
                    cmbGroup.Text,
                    txtGoodsCode.Text,
                    txtName.Text,
                    txtActiveElement.Text,
                    txtManufacturer.Text,
                    txtPackaging.Text,
                    txtCost.Text,
                    txtIventory.Text,
                    txtExpiryDate.Text
                );

                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                LoadComboBoxes();
                ClearFields();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int result = medicationManager.UpdateMedication(
                    txtID.Text,
                    cmbType.Text,
                    cmbGroup.Text,
                    txtGoodsCode.Text,
                    txtName.Text,
                    txtActiveElement.Text,
                    txtManufacturer.Text,
                    txtPackaging.Text,
                    txtCost.Text,
                    txtIventory.Text,
                    txtExpiryDate.Text
                );

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int rowsAffected = medicationManager.DeleteMedication(txtID.Text);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearFields()
        {
            txtID.Text = "";
            cmbType.SelectedIndex = -1;
            cmbGroup.SelectedIndex = -1;
            txtGoodsCode.Text = "";
            txtName.Text = "";
            txtActiveElement.Text = "";
            txtManufacturer.Text = "";
            txtPackaging.Text = "";
            txtCost.Text = "";
            txtIventory.Text = "";
            txtExpiryDate.Text = "";
        }

        private void cmbLocnhomhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cmbLockieuhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuanLyKhoThuoc_Load(object sender, EventArgs e)
        {

        }
    }
}