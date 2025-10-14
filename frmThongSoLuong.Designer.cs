namespace CNPM_Project
{
    partial class frmThongSoLuong
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.lblThang = new System.Windows.Forms.Label();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.lblNam = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.lblHeSoLuong = new System.Windows.Forms.Label();
            this.txtHeSoLuong = new System.Windows.Forms.TextBox();
            this.lblPhuCap = new System.Windows.Forms.Label();
            this.txtPhuCapChucVu = new System.Windows.Forms.TextBox();
            this.lblBHXH = new System.Windows.Forms.Label();
            this.txtTyLeBHXH = new System.Windows.Forms.TextBox();
            this.lblBHYT = new System.Windows.Forms.Label();
            this.txtTyLeBHYT = new System.Windows.Forms.TextBox();
            this.lblBHTN = new System.Windows.Forms.Label();
            this.txtTyLeBHTN = new System.Windows.Forms.TextBox();
            this.dgvThongSoLuong = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongSoLuong)).BeginInit();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(320, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 24);
            this.lblTitle.Text = "QUẢN LÝ THÔNG SỐ LƯƠNG";
            
            // lblChucVu
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Location = new System.Drawing.Point(30, 60);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(55, 13);
            this.lblChucVu.Text = "Chức vụ:";
            
            // cboChucVu
            this.cboChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Location = new System.Drawing.Point(120, 57);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(250, 21);
            
            // lblThang
            this.lblThang.AutoSize = true;
            this.lblThang.Location = new System.Drawing.Point(400, 60);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(41, 13);
            this.lblThang.Text = "Tháng:";
            
            // numThang
            this.numThang.Location = new System.Drawing.Point(450, 58);
            this.numThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            this.numThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numThang.Name = "numThang";
            this.numThang.Size = new System.Drawing.Size(60, 20);
            this.numThang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            
            // lblNam
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(530, 60);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(32, 13);
            this.lblNam.Text = "Năm:";
            
            // numNam
            this.numNam.Location = new System.Drawing.Point(570, 58);
            this.numNam.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numNam.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(70, 20);
            this.numNam.Value = new decimal(new int[] { 2025, 0, 0, 0 });
            
            // lblHeSoLuong
            this.lblHeSoLuong.AutoSize = true;
            this.lblHeSoLuong.Location = new System.Drawing.Point(30, 95);
            this.lblHeSoLuong.Name = "lblHeSoLuong";
            this.lblHeSoLuong.Size = new System.Drawing.Size(130, 13);
            this.lblHeSoLuong.Text = "Hệ số lương cơ bản (VNĐ):";
            
            // txtHeSoLuong
            this.txtHeSoLuong.Location = new System.Drawing.Point(170, 92);
            this.txtHeSoLuong.Name = "txtHeSoLuong";
            this.txtHeSoLuong.Size = new System.Drawing.Size(200, 20);
            
            // lblPhuCap
            this.lblPhuCap.AutoSize = true;
            this.lblPhuCap.Location = new System.Drawing.Point(400, 95);
            this.lblPhuCap.Name = "lblPhuCap";
            this.lblPhuCap.Size = new System.Drawing.Size(130, 13);
            this.lblPhuCap.Text = "Phụ cấp chức vụ (VNĐ):";
            
            // txtPhuCapChucVu
            this.txtPhuCapChucVu.Location = new System.Drawing.Point(540, 92);
            this.txtPhuCapChucVu.Name = "txtPhuCapChucVu";
            this.txtPhuCapChucVu.Size = new System.Drawing.Size(200, 20);
            this.txtPhuCapChucVu.Text = "0";
            
            // lblBHXH
            this.lblBHXH.AutoSize = true;
            this.lblBHXH.Location = new System.Drawing.Point(30, 125);
            this.lblBHXH.Name = "lblBHXH";
            this.lblBHXH.Size = new System.Drawing.Size(140, 13);
            this.lblBHXH.Text = "Tỷ lệ bảo hiểm xã hội (%):";
            
            // txtTyLeBHXH
            this.txtTyLeBHXH.Location = new System.Drawing.Point(170, 122);
            this.txtTyLeBHXH.Name = "txtTyLeBHXH";
            this.txtTyLeBHXH.Size = new System.Drawing.Size(100, 20);
            
            // lblBHYT
            this.lblBHYT.AutoSize = true;
            this.lblBHYT.Location = new System.Drawing.Point(300, 125);
            this.lblBHYT.Name = "lblBHYT";
            this.lblBHYT.Size = new System.Drawing.Size(130, 13);
            this.lblBHYT.Text = "Tỷ lệ BHYT (%):";
            
            // txtTyLeBHYT
            this.txtTyLeBHYT.Location = new System.Drawing.Point(400, 122);
            this.txtTyLeBHYT.Name = "txtTyLeBHYT";
            this.txtTyLeBHYT.Size = new System.Drawing.Size(100, 20);
            
            // lblBHTN
            this.lblBHTN.AutoSize = true;
            this.lblBHTN.Location = new System.Drawing.Point(530, 125);
            this.lblBHTN.Name = "lblBHTN";
            this.lblBHTN.Size = new System.Drawing.Size(90, 13);
            this.lblBHTN.Text = "Tỷ lệ BHTN (%):";
            
            // txtTyLeBHTN
            this.txtTyLeBHTN.Location = new System.Drawing.Point(630, 122);
            this.txtTyLeBHTN.Name = "txtTyLeBHTN";
            this.txtTyLeBHTN.Size = new System.Drawing.Size(100, 20);
            
            // dgvThongSoLuong
            this.dgvThongSoLuong.AllowUserToAddRows = false;
            this.dgvThongSoLuong.AllowUserToDeleteRows = false;
            this.dgvThongSoLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongSoLuong.Location = new System.Drawing.Point(30, 210);
            this.dgvThongSoLuong.MultiSelect = false;
            this.dgvThongSoLuong.Name = "dgvThongSoLuong";
            this.dgvThongSoLuong.ReadOnly = true;
            this.dgvThongSoLuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongSoLuong.Size = new System.Drawing.Size(940, 340);
            this.dgvThongSoLuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongSoLuong_CellClick);
            
            // btnThem
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(30, 160);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.Text = "➕ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            
            // btnSua
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(150, 160);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.Text = "✏️ Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            
            // btnXoa
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(270, 160);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.Text = "🗑️ Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            
            // btnLamMoi
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(390, 160);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 35);
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            
            // btnDong
            this.btnDong.BackColor = System.Drawing.Color.Gray;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(640, 160);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 35);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            
            // frmThongSoLuong
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvThongSoLuong);
            this.Controls.Add(this.txtTyLeBHTN);
            this.Controls.Add(this.lblBHTN);
            this.Controls.Add(this.txtTyLeBHYT);
            this.Controls.Add(this.lblBHYT);
            this.Controls.Add(this.txtTyLeBHXH);
            this.Controls.Add(this.lblBHXH);
            this.Controls.Add(this.txtPhuCapChucVu);
            this.Controls.Add(this.lblPhuCap);
            this.Controls.Add(this.txtHeSoLuong);
            this.Controls.Add(this.lblHeSoLuong);
            this.Controls.Add(this.numNam);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.numThang);
            this.Controls.Add(this.lblThang);
            this.Controls.Add(this.cboChucVu);
            this.Controls.Add(this.lblChucVu);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmThongSoLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thông số lương";
            this.Load += new System.EventHandler(this.frmThongSoLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Label lblHeSoLuong;
        private System.Windows.Forms.TextBox txtHeSoLuong;
        private System.Windows.Forms.Label lblPhuCap;
        private System.Windows.Forms.TextBox txtPhuCapChucVu;
        private System.Windows.Forms.Label lblBHXH;
        private System.Windows.Forms.TextBox txtTyLeBHXH;
        private System.Windows.Forms.Label lblBHYT;
        private System.Windows.Forms.TextBox txtTyLeBHYT;
        private System.Windows.Forms.Label lblBHTN;
        private System.Windows.Forms.TextBox txtTyLeBHTN;
        private System.Windows.Forms.DataGridView dgvThongSoLuong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDong;
    }
}
