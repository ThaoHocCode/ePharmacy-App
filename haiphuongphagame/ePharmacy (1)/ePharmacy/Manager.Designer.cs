namespace ePharmacy
{
    partial class Manager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnInventory = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuanLyNhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.btnDoanhThu = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblManagerName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Button1
            // 
            this.guna2Button1.AutoRoundedCorners = true;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(1100, 534);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(118, 37);
            this.guna2Button1.TabIndex = 1;
            this.guna2Button1.Text = "Đăng xuất";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.AutoRoundedCorners = true;
            this.btnInventory.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnInventory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInventory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInventory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInventory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnInventory.ForeColor = System.Drawing.Color.Black;
            this.btnInventory.Image = global::ePharmacy.Properties.Resources.warehouse;
            this.btnInventory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInventory.ImageOffset = new System.Drawing.Point(8, 0);
            this.btnInventory.ImageSize = new System.Drawing.Size(30, 30);
            this.btnInventory.Location = new System.Drawing.Point(12, 382);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(267, 53);
            this.btnInventory.TabIndex = 14;
            this.btnInventory.Text = "Quản lý kho thuốc";
            this.btnInventory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnInventory.TextOffset = new System.Drawing.Point(-8, 0);
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnQuanLyNhanVien
            // 
            this.btnQuanLyNhanVien.AutoRoundedCorners = true;
            this.btnQuanLyNhanVien.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnQuanLyNhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQuanLyNhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQuanLyNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQuanLyNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQuanLyNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuanLyNhanVien.ForeColor = System.Drawing.Color.Black;
            this.btnQuanLyNhanVien.Image = global::ePharmacy.Properties.Resources.warehouse;
            this.btnQuanLyNhanVien.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQuanLyNhanVien.ImageOffset = new System.Drawing.Point(8, 0);
            this.btnQuanLyNhanVien.ImageSize = new System.Drawing.Size(30, 30);
            this.btnQuanLyNhanVien.Location = new System.Drawing.Point(12, 269);
            this.btnQuanLyNhanVien.Name = "btnQuanLyNhanVien";
            this.btnQuanLyNhanVien.Size = new System.Drawing.Size(267, 53);
            this.btnQuanLyNhanVien.TabIndex = 13;
            this.btnQuanLyNhanVien.Text = "Quản lý nhân viên";
            this.btnQuanLyNhanVien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnQuanLyNhanVien.TextOffset = new System.Drawing.Point(-8, 0);
            this.btnQuanLyNhanVien.Click += new System.EventHandler(this.btnQuanLyNhanVien_Click);
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.AutoRoundedCorners = true;
            this.btnDoanhThu.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnDoanhThu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDoanhThu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDoanhThu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDoanhThu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDoanhThu.ForeColor = System.Drawing.Color.Black;
            this.btnDoanhThu.Image = global::ePharmacy.Properties.Resources.warehouse;
            this.btnDoanhThu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDoanhThu.ImageOffset = new System.Drawing.Point(8, 0);
            this.btnDoanhThu.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDoanhThu.Location = new System.Drawing.Point(12, 167);
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(267, 53);
            this.btnDoanhThu.TabIndex = 12;
            this.btnDoanhThu.Text = "Doanh thu bán hàng";
            this.btnDoanhThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnDoanhThu.TextOffset = new System.Drawing.Point(-8, 0);
            this.btnDoanhThu.Click += new System.EventHandler(this.btnDoanhThu_Click);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::ePharmacy.Properties.Resources.customer_service;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(81, 12);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(106, 105);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 15;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // lblManagerName
            // 
            this.lblManagerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblManagerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblManagerName.Location = new System.Drawing.Point(97, 134);
            this.lblManagerName.Name = "lblManagerName";
            this.lblManagerName.Size = new System.Drawing.Size(149, 22);
            this.lblManagerName.TabIndex = 16;
            this.lblManagerName.Text = "guna2HtmlLabel1";
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1230, 663);
            this.Controls.Add(this.lblManagerName);
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnQuanLyNhanVien);
            this.Controls.Add(this.btnDoanhThu);
            this.Controls.Add(this.guna2Button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager";
            this.Load += new System.EventHandler(this.Manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btnDoanhThu;
        private Guna.UI2.WinForms.Guna2Button btnQuanLyNhanVien;
        private Guna.UI2.WinForms.Guna2Button btnInventory;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblManagerName;
    }
}