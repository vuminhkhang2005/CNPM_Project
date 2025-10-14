// frmQuanLyBangLuongMoi.Designer.cs

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
            // Khởi tạo các control
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblThang = new System.Windows.Forms.Label();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.lblNam = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.lblSoNgayCong = new System.Windows.Forms.Label();
            this.txtSoNgayCong = new System.Windows.Forms.TextBox();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSuaThongSo = new System.Windows.Forms.Button();
            this.dgvBangLuong = new System.Windows.Forms.DataGridView();

            // Tạm dừng layout để cấu hình
            this.gbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangLuong)).BeginInit();
            this.SuspendLayout();

            // =========== GroupBox Nhập liệu ===========
            this.gbThongTin.Controls.Add(this.lblNhanVien);
            this.gbThongTin.Controls.Add(this.cboNhanVien);
            this.gbThongTin.Controls.Add(this.lblThang);
            this.gbThongTin.Controls.Add(this.numThang);
            this.gbThongTin.Controls.Add(this.lblNam);
            this.gbThongTin.Controls.Add(this.numNam);
            this.gbThongTin.Controls.Add(this.lblSoNgayCong);
            this.gbThongTin.Controls.Add(this.txtSoNgayCong);
            this.gbThongTin.Controls.Add(this.btnTinhLuong);
            this.gbThongTin.Controls.Add(this.btnLuu);
            this.gbThongTin.Controls.Add(this.btnSuaThongSo);
            this.gbThongTin.Location = new System.Drawing.Point(15, 15);
            this.gbThongTin.Size = new System.Drawing.Size(760, 120);
            this.gbThongTin.Text = "Thông tin tính lương";

            // --- Cấu hình các control trong GroupBox ---
            this.lblNhanVien.Location = new System.Drawing.Point(20, 30);
            this.lblNhanVien.Text = "Chọn nhân viên:";
            this.cboNhanVien.Location = new System.Drawing.Point(120, 28);
            this.cboNhanVien.Size = new System.Drawing.Size(200, 21);

            // Tháng
            this.lblThang.Location = new System.Drawing.Point(350, 30);
            this.lblThang.Text = "Tháng:";
            this.numThang.Location = new System.Drawing.Point(400, 28);
            this.numThang.Size = new System.Drawing.Size(60, 21);
            this.numThang.Minimum = 1;
            this.numThang.Maximum = 12;
            this.numThang.Value = DateTime.Now.Month;
            
            // Năm
            this.lblNam.Location = new System.Drawing.Point(490, 30);
            this.lblNam.Text = "Năm:";
            this.numNam.Location = new System.Drawing.Point(530, 28);
            this.numNam.Size = new System.Drawing.Size(80, 21);
            this.numNam.Minimum = 2020;
            this.numNam.Maximum = 2100;
            this.numNam.Value = DateTime.Now.Year;

            this.lblSoNgayCong.Location = new System.Drawing.Point(20, 70);
            this.lblSoNgayCong.Text = "Số ngày công:";
            this.txtSoNgayCong.Location = new System.Drawing.Point(120, 68);
            this.txtSoNgayCong.Size = new System.Drawing.Size(100, 21);

            this.btnTinhLuong.Location = new System.Drawing.Point(350, 65);
            this.btnTinhLuong.Text = "Tính Lương";
            this.btnTinhLuong.Click += new System.EventHandler(this.btnTinhLuong_Click);

            this.btnLuu.Location = new System.Drawing.Point(450, 65);
            this.btnLuu.Text = "Lưu Bảng Lương";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            this.btnSuaThongSo.Location = new System.Drawing.Point(570, 65);
            this.btnSuaThongSo.Text = "Sửa thông số";
            this.btnSuaThongSo.Click += new System.EventHandler(this.btnSuaThongSo_Click);


            // =========== DataGridView ===========
            this.dgvBangLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangLuong.Location = new System.Drawing.Point(15, 150);
            this.dgvBangLuong.Size = new System.Drawing.Size(760, 300);
            this.dgvBangLuong.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right);
            this.dgvBangLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBangLuong.ReadOnly = true;

            // =========== Cấu hình Form chính ===========
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 461);
            this.Controls.Add(this.dgvBangLuong);
            this.Controls.Add(this.gbThongTin);
            this.Name = "frmQuanLyBangLuongMoi";
            this.Text = "Quản Lý Bảng Lương Nhân Viên";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Tiếp tục layout
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangLuong)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // Khai báo control
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Label lblSoNgayCong;
        private System.Windows.Forms.TextBox txtSoNgayCong;
        private System.Windows.Forms.Button btnTinhLuong;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSuaThongSo;
        private System.Windows.Forms.DataGridView dgvBangLuong;
    }
}