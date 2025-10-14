namespace CNPM_Project
{
    partial class frmQuanLyBangLuongMoi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.chkNam = new System.Windows.Forms.CheckBox();
            this.chkThang = new System.Windows.Forms.CheckBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblThang = new System.Windows.Forms.Label();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.lblNam = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.lblSoNgayCong = new System.Windows.Forms.Label();
            this.txtSoNgayCong = new System.Windows.Forms.TextBox();
            
            this.gbChucNang = new System.Windows.Forms.GroupBox();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThongSoLuong = new System.Windows.Forms.Button();
            
            this.dgvBangLuong = new System.Windows.Forms.DataGridView();
            this.lblTongSoBanGhi = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();

            this.gbThongTin.SuspendLayout();
            this.gbChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangLuong)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTitle.Location = new System.Drawing.Point(280, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ BẢNG LƯƠNG NHÂN VIÊN";

            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.chkNam);
            this.gbThongTin.Controls.Add(this.chkThang);
            this.gbThongTin.Controls.Add(this.lblNhanVien);
            this.gbThongTin.Controls.Add(this.cboNhanVien);
            this.gbThongTin.Controls.Add(this.lblThang);
            this.gbThongTin.Controls.Add(this.numThang);
            this.gbThongTin.Controls.Add(this.lblNam);
            this.gbThongTin.Controls.Add(this.numNam);
            this.gbThongTin.Controls.Add(this.lblSoNgayCong);
            this.gbThongTin.Controls.Add(this.txtSoNgayCong);
            this.gbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gbThongTin.Location = new System.Drawing.Point(15, 55);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(900, 120);
            this.gbThongTin.TabIndex = 1;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin bảng lương";

            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNhanVien.Location = new System.Drawing.Point(20, 35);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(90, 15);
            this.lblNhanVien.TabIndex = 0;
            this.lblNhanVien.Text = "Chọn nhân viên:";

            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(130, 32);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(250, 23);
            this.cboNhanVien.TabIndex = 1;

            // 
            // chkThang
            // 
            this.chkThang.AutoSize = true;
            this.chkThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.chkThang.Location = new System.Drawing.Point(420, 35);
            this.chkThang.Name = "chkThang";
            this.chkThang.Size = new System.Drawing.Size(15, 14);
            this.chkThang.TabIndex = 2;
            this.chkThang.UseVisualStyleBackColor = true;

            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblThang.Location = new System.Drawing.Point(440, 35);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(45, 15);
            this.lblThang.TabIndex = 3;
            this.lblThang.Text = "Tháng:";

            // 
            // numThang
            // 
            this.numThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.numThang.Location = new System.Drawing.Point(490, 33);
            this.numThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            this.numThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numThang.Name = "numThang";
            this.numThang.Size = new System.Drawing.Size(70, 21);
            this.numThang.TabIndex = 4;
            this.numThang.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // 
            // chkNam
            // 
            this.chkNam.AutoSize = true;
            this.chkNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.chkNam.Location = new System.Drawing.Point(590, 35);
            this.chkNam.Name = "chkNam";
            this.chkNam.Size = new System.Drawing.Size(15, 14);
            this.chkNam.TabIndex = 5;
            this.chkNam.UseVisualStyleBackColor = true;

            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNam.Location = new System.Drawing.Point(610, 35);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(35, 15);
            this.lblNam.TabIndex = 6;
            this.lblNam.Text = "Năm:";

            // 
            // numNam
            // 
            this.numNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.numNam.Location = new System.Drawing.Point(650, 33);
            this.numNam.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numNam.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(90, 21);
            this.numNam.TabIndex = 7;
            this.numNam.Value = new decimal(new int[] { 2025, 0, 0, 0 });

            // 
            // lblSoNgayCong
            // 
            this.lblSoNgayCong.AutoSize = true;
            this.lblSoNgayCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSoNgayCong.Location = new System.Drawing.Point(20, 75);
            this.lblSoNgayCong.Name = "lblSoNgayCong";
            this.lblSoNgayCong.Size = new System.Drawing.Size(85, 15);
            this.lblSoNgayCong.TabIndex = 8;
            this.lblSoNgayCong.Text = "Số ngày công:";

            // 
            // txtSoNgayCong
            // 
            this.txtSoNgayCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtSoNgayCong.Location = new System.Drawing.Point(130, 72);
            this.txtSoNgayCong.Name = "txtSoNgayCong";
            this.txtSoNgayCong.Size = new System.Drawing.Size(120, 21);
            this.txtSoNgayCong.TabIndex = 9;

            // 
            // gbChucNang
            // 
            this.gbChucNang.Controls.Add(this.btnTinhLuong);
            this.gbChucNang.Controls.Add(this.btnThem);
            this.gbChucNang.Controls.Add(this.btnSua);
            this.gbChucNang.Controls.Add(this.btnXoa);
            this.gbChucNang.Controls.Add(this.btnTimKiem);
            this.gbChucNang.Controls.Add(this.btnLamMoi);
            this.gbChucNang.Controls.Add(this.btnThongSoLuong);
            this.gbChucNang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gbChucNang.Location = new System.Drawing.Point(15, 185);
            this.gbChucNang.Name = "gbChucNang";
            this.gbChucNang.Size = new System.Drawing.Size(900, 80);
            this.gbChucNang.TabIndex = 2;
            this.gbChucNang.TabStop = false;
            this.gbChucNang.Text = "Chức năng";

            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTinhLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTinhLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnTinhLuong.ForeColor = System.Drawing.Color.White;
            this.btnTinhLuong.Location = new System.Drawing.Point(20, 28);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Size = new System.Drawing.Size(110, 38);
            this.btnTinhLuong.TabIndex = 0;
            this.btnTinhLuong.Text = "💰 Tính Lương";
            this.btnTinhLuong.UseVisualStyleBackColor = false;
            this.btnTinhLuong.Click += new System.EventHandler(this.btnTinhLuong_Click);

            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(145, 28);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 38);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "➕ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(270, 28);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 38);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "✏️ Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(395, 28);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 38);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "🗑️ Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(520, 28);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(110, 38);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "🔍 Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(645, 28);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 38);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // 
            // btnThongSoLuong
            // 
            this.btnThongSoLuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnThongSoLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnThongSoLuong.ForeColor = System.Drawing.Color.White;
            this.btnThongSoLuong.Location = new System.Drawing.Point(770, 28);
            this.btnThongSoLuong.Name = "btnThongSoLuong";
            this.btnThongSoLuong.Size = new System.Drawing.Size(110, 38);
            this.btnThongSoLuong.TabIndex = 6;
            this.btnThongSoLuong.Text = "⚙️ Thông số";
            this.btnThongSoLuong.UseVisualStyleBackColor = false;
            this.btnThongSoLuong.Click += new System.EventHandler(this.btnThongSoLuong_Click);

            // 
            // dgvBangLuong
            // 
            this.dgvBangLuong.AllowUserToAddRows = false;
            this.dgvBangLuong.AllowUserToDeleteRows = false;
            this.dgvBangLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBangLuong.BackgroundColor = System.Drawing.Color.White;
            this.dgvBangLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangLuong.Location = new System.Drawing.Point(15, 275);
            this.dgvBangLuong.Name = "dgvBangLuong";
            this.dgvBangLuong.ReadOnly = true;
            this.dgvBangLuong.RowHeadersWidth = 51;
            this.dgvBangLuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBangLuong.Size = new System.Drawing.Size(900, 320);
            this.dgvBangLuong.TabIndex = 3;
            this.dgvBangLuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBangLuong_CellClick);

            // 
            // lblTongSoBanGhi
            // 
            this.lblTongSoBanGhi.AutoSize = true;
            this.lblTongSoBanGhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.lblTongSoBanGhi.Location = new System.Drawing.Point(15, 605);
            this.lblTongSoBanGhi.Name = "lblTongSoBanGhi";
            this.lblTongSoBanGhi.Size = new System.Drawing.Size(100, 15);
            this.lblTongSoBanGhi.TabIndex = 4;
            this.lblTongSoBanGhi.Text = "Tổng số: 0 bản ghi";

            // 
            // frmQuanLyBangLuongMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(930, 630);
            this.Controls.Add(this.lblTongSoBanGhi);
            this.Controls.Add(this.dgvBangLuong);
            this.Controls.Add(this.gbChucNang);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmQuanLyBangLuongMoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Bảng Lương Nhân Viên";
            this.Load += new System.EventHandler(this.frmQuanLyBangLuongMoi_Load);
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.gbChucNang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.CheckBox chkThang;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.CheckBox chkNam;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Label lblSoNgayCong;
        private System.Windows.Forms.TextBox txtSoNgayCong;
        private System.Windows.Forms.GroupBox gbChucNang;
        private System.Windows.Forms.Button btnTinhLuong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThongSoLuong;
        private System.Windows.Forms.DataGridView dgvBangLuong;
        private System.Windows.Forms.Label lblTongSoBanGhi;
    }
}
