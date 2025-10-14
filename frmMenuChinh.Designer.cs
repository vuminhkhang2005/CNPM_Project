namespace CNPM_Project
{
    partial class frmMenuChinh
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.groupBoxLuong = new System.Windows.Forms.GroupBox();
            this.btnQuanLyBangLuong = new System.Windows.Forms.Button();
            this.btnChinhSuaThongSoLuong = new System.Windows.Forms.Button();
            this.groupBoxCongNo = new System.Windows.Forms.GroupBox();
            this.btnThemCongNo = new System.Windows.Forms.Button();
            this.btnXoaCongNo = new System.Windows.Forms.Button();
            this.groupBoxBaoCao = new System.Windows.Forms.GroupBox();
            this.btnChiPhiNhapHang = new System.Windows.Forms.Button();
            this.btnChiPhiBanHang = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBoxLuong.SuspendLayout();
            this.groupBoxCongNo.SuspendLayout();
            this.groupBoxBaoCao.SuspendLayout();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.lblTitle.Location = new System.Drawing.Point(200, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 29);
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ KẾ TOÁN";
            
            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblWelcome.Location = new System.Drawing.Point(220, 60);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(360, 18);
            this.lblWelcome.Text = "Chào mừng bạn đến với hệ thống quản lý kế toán";
            
            // groupBoxLuong
            this.groupBoxLuong.Controls.Add(this.btnQuanLyBangLuong);
            this.groupBoxLuong.Controls.Add(this.btnChinhSuaThongSoLuong);
            this.groupBoxLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxLuong.Location = new System.Drawing.Point(40, 100);
            this.groupBoxLuong.Name = "groupBoxLuong";
            this.groupBoxLuong.Size = new System.Drawing.Size(350, 150);
            this.groupBoxLuong.Text = "Quản lý bảng lương";
            
            // btnQuanLyBangLuong
            this.btnQuanLyBangLuong.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnQuanLyBangLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuanLyBangLuong.ForeColor = System.Drawing.Color.White;
            this.btnQuanLyBangLuong.Location = new System.Drawing.Point(20, 35);
            this.btnQuanLyBangLuong.Name = "btnQuanLyBangLuong";
            this.btnQuanLyBangLuong.Size = new System.Drawing.Size(300, 45);
            this.btnQuanLyBangLuong.Text = "Cập nhật bảng lương";
            this.btnQuanLyBangLuong.UseVisualStyleBackColor = false;
            this.btnQuanLyBangLuong.Click += new System.EventHandler(this.btnQuanLyBangLuong_Click);
            
            // btnChinhSuaThongSoLuong
            this.btnChinhSuaThongSoLuong.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnChinhSuaThongSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnChinhSuaThongSoLuong.ForeColor = System.Drawing.Color.White;
            this.btnChinhSuaThongSoLuong.Location = new System.Drawing.Point(20, 90);
            this.btnChinhSuaThongSoLuong.Name = "btnChinhSuaThongSoLuong";
            this.btnChinhSuaThongSoLuong.Size = new System.Drawing.Size(300, 45);
            this.btnChinhSuaThongSoLuong.Text = "Chỉnh sửa thông số bảng lương";
            this.btnChinhSuaThongSoLuong.UseVisualStyleBackColor = false;
            this.btnChinhSuaThongSoLuong.Click += new System.EventHandler(this.btnChinhSuaThongSoLuong_Click);
            
            // groupBoxCongNo
            this.groupBoxCongNo.Controls.Add(this.btnThemCongNo);
            this.groupBoxCongNo.Controls.Add(this.btnXoaCongNo);
            this.groupBoxCongNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxCongNo.Location = new System.Drawing.Point(420, 100);
            this.groupBoxCongNo.Name = "groupBoxCongNo";
            this.groupBoxCongNo.Size = new System.Drawing.Size(350, 150);
            this.groupBoxCongNo.Text = "Quản lý công nợ";
            
            // btnThemCongNo
            this.btnThemCongNo.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            this.btnThemCongNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnThemCongNo.ForeColor = System.Drawing.Color.White;
            this.btnThemCongNo.Location = new System.Drawing.Point(20, 35);
            this.btnThemCongNo.Name = "btnThemCongNo";
            this.btnThemCongNo.Size = new System.Drawing.Size(300, 45);
            this.btnThemCongNo.Text = "Thêm công nợ mới";
            this.btnThemCongNo.UseVisualStyleBackColor = false;
            this.btnThemCongNo.Click += new System.EventHandler(this.btnThemCongNo_Click);
            
            // btnXoaCongNo
            this.btnXoaCongNo.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.btnXoaCongNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoaCongNo.ForeColor = System.Drawing.Color.White;
            this.btnXoaCongNo.Location = new System.Drawing.Point(20, 90);
            this.btnXoaCongNo.Name = "btnXoaCongNo";
            this.btnXoaCongNo.Size = new System.Drawing.Size(300, 45);
            this.btnXoaCongNo.Text = "Xóa công nợ";
            this.btnXoaCongNo.UseVisualStyleBackColor = false;
            this.btnXoaCongNo.Click += new System.EventHandler(this.btnXoaCongNo_Click);
            
            // groupBoxBaoCao
            this.groupBoxBaoCao.Controls.Add(this.btnChiPhiNhapHang);
            this.groupBoxBaoCao.Controls.Add(this.btnChiPhiBanHang);
            this.groupBoxBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxBaoCao.Location = new System.Drawing.Point(40, 270);
            this.groupBoxBaoCao.Name = "groupBoxBaoCao";
            this.groupBoxBaoCao.Size = new System.Drawing.Size(730, 100);
            this.groupBoxBaoCao.Text = "Báo cáo & Thống kê";
            
            // btnChiPhiNhapHang
            this.btnChiPhiNhapHang.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.btnChiPhiNhapHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnChiPhiNhapHang.ForeColor = System.Drawing.Color.White;
            this.btnChiPhiNhapHang.Location = new System.Drawing.Point(40, 35);
            this.btnChiPhiNhapHang.Name = "btnChiPhiNhapHang";
            this.btnChiPhiNhapHang.Size = new System.Drawing.Size(300, 45);
            this.btnChiPhiNhapHang.Text = "Xem chi phí nhập hàng";
            this.btnChiPhiNhapHang.UseVisualStyleBackColor = false;
            this.btnChiPhiNhapHang.Click += new System.EventHandler(this.btnChiPhiNhapHang_Click);
            
            // btnChiPhiBanHang
            this.btnChiPhiBanHang.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.btnChiPhiBanHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnChiPhiBanHang.ForeColor = System.Drawing.Color.White;
            this.btnChiPhiBanHang.Location = new System.Drawing.Point(380, 35);
            this.btnChiPhiBanHang.Name = "btnChiPhiBanHang";
            this.btnChiPhiBanHang.Size = new System.Drawing.Size(300, 45);
            this.btnChiPhiBanHang.Text = "Xem chi phí bán hàng";
            this.btnChiPhiBanHang.UseVisualStyleBackColor = false;
            this.btnChiPhiBanHang.Click += new System.EventHandler(this.btnChiPhiBanHang_Click);
            
            // btnThoat
            this.btnThoat.BackColor = System.Drawing.Color.Gray;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(330, 400);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(150, 50);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            
            // frmMenuChinh
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.groupBoxBaoCao);
            this.Controls.Add(this.groupBoxCongNo);
            this.Controls.Add(this.groupBoxLuong);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmMenuChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý kế toán";
            this.Load += new System.EventHandler(this.frmMenuChinh_Load);
            this.groupBoxLuong.ResumeLayout(false);
            this.groupBoxCongNo.ResumeLayout(false);
            this.groupBoxBaoCao.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.GroupBox groupBoxLuong;
        private System.Windows.Forms.Button btnQuanLyBangLuong;
        private System.Windows.Forms.Button btnChinhSuaThongSoLuong;
        private System.Windows.Forms.GroupBox groupBoxCongNo;
        private System.Windows.Forms.Button btnThemCongNo;
        private System.Windows.Forms.Button btnXoaCongNo;
        private System.Windows.Forms.GroupBox groupBoxBaoCao;
        private System.Windows.Forms.Button btnChiPhiNhapHang;
        private System.Windows.Forms.Button btnChiPhiBanHang;
        private System.Windows.Forms.Button btnThoat;
    }
}
