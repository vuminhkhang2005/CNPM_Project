namespace CNPM_Project
{
    partial class frmChiPhiBanHang
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
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dgvDonHang = new System.Windows.Forms.DataGridView();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.lblTongGiaVon = new System.Windows.Forms.Label();
            this.lblTongLoiNhuan = new System.Windows.Forms.Label();
            this.lblTyLeLoiNhuan = new System.Windows.Forms.Label();
            this.btnXuatBaoCao = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.panelThongKe = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            this.panelThongKe.SuspendLayout();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(280, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 24);
            this.lblTitle.Text = "THỐNG KÊ CHI PHÍ VÀ LỢI NHUẬN";
            
            // lblTuNgay
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(30, 70);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(55, 13);
            this.lblTuNgay.Text = "Từ ngày:";
            
            // dtpTuNgay
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(100, 67);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 20);
            
            // lblDenNgay
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(280, 70);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(63, 13);
            this.lblDenNgay.Text = "Đến ngày:";
            
            // dtpDenNgay
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(350, 67);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 20);
            
            // btnThongKe
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(530, 62);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(100, 30);
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            
            // lblHuongDan
            this.lblHuongDan.AutoSize = true;
            this.lblHuongDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.lblHuongDan.ForeColor = System.Drawing.Color.Gray;
            this.lblHuongDan.Location = new System.Drawing.Point(30, 105);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(350, 13);
            this.lblHuongDan.Text = "* Double-click vào một đơn hàng để xem chi tiết";
            
            // dgvDonHang
            this.dgvDonHang.AllowUserToAddRows = false;
            this.dgvDonHang.AllowUserToDeleteRows = false;
            this.dgvDonHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonHang.Location = new System.Drawing.Point(30, 130);
            this.dgvDonHang.Name = "dgvDonHang";
            this.dgvDonHang.ReadOnly = true;
            this.dgvDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonHang.Size = new System.Drawing.Size(840, 300);
            this.dgvDonHang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonHang_CellDoubleClick);
            
            // panelThongKe
            this.panelThongKe.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelThongKe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongKe.Controls.Add(this.lblTongDoanhThu);
            this.panelThongKe.Controls.Add(this.lblTongGiaVon);
            this.panelThongKe.Controls.Add(this.lblTongLoiNhuan);
            this.panelThongKe.Controls.Add(this.lblTyLeLoiNhuan);
            this.panelThongKe.Location = new System.Drawing.Point(30, 450);
            this.panelThongKe.Name = "panelThongKe";
            this.panelThongKe.Size = new System.Drawing.Size(840, 80);
            
            // lblTongDoanhThu
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(15, 10);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(200, 17);
            this.lblTongDoanhThu.Text = "Tổng doanh thu: 0 VNĐ";
            
            // lblTongGiaVon
            this.lblTongGiaVon.AutoSize = true;
            this.lblTongGiaVon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongGiaVon.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.lblTongGiaVon.Location = new System.Drawing.Point(430, 10);
            this.lblTongGiaVon.Name = "lblTongGiaVon";
            this.lblTongGiaVon.Size = new System.Drawing.Size(180, 17);
            this.lblTongGiaVon.Text = "Tổng giá vốn: 0 VNĐ";
            
            // lblTongLoiNhuan
            this.lblTongLoiNhuan.AutoSize = true;
            this.lblTongLoiNhuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongLoiNhuan.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            this.lblTongLoiNhuan.Location = new System.Drawing.Point(15, 45);
            this.lblTongLoiNhuan.Name = "lblTongLoiNhuan";
            this.lblTongLoiNhuan.Size = new System.Drawing.Size(210, 18);
            this.lblTongLoiNhuan.Text = "Tổng lợi nhuận: 0 VNĐ";
            
            // lblTyLeLoiNhuan
            this.lblTyLeLoiNhuan.AutoSize = true;
            this.lblTyLeLoiNhuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblTyLeLoiNhuan.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            this.lblTyLeLoiNhuan.Location = new System.Drawing.Point(430, 45);
            this.lblTyLeLoiNhuan.Name = "lblTyLeLoiNhuan";
            this.lblTyLeLoiNhuan.Size = new System.Drawing.Size(180, 18);
            this.lblTyLeLoiNhuan.Text = "Tỷ lệ lợi nhuận: 0%";
            
            // btnXuatBaoCao
            this.btnXuatBaoCao.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            this.btnXuatBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnXuatBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXuatBaoCao.Location = new System.Drawing.Point(600, 550);
            this.btnXuatBaoCao.Name = "btnXuatBaoCao";
            this.btnXuatBaoCao.Size = new System.Drawing.Size(130, 40);
            this.btnXuatBaoCao.Text = "Xuất báo cáo";
            this.btnXuatBaoCao.UseVisualStyleBackColor = false;
            this.btnXuatBaoCao.Click += new System.EventHandler(this.btnXuatBaoCao_Click);
            
            // btnDong
            this.btnDong.BackColor = System.Drawing.Color.Gray;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(750, 550);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 40);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            
            // frmChiPhiBanHang
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 620);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnXuatBaoCao);
            this.Controls.Add(this.panelThongKe);
            this.Controls.Add(this.dgvDonHang);
            this.Controls.Add(this.lblHuongDan);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmChiPhiBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem chi phí bán hàng";
            this.Load += new System.EventHandler(this.frmChiPhiBanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            this.panelThongKe.ResumeLayout(false);
            this.panelThongKe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DataGridView dgvDonHang;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label lblTongGiaVon;
        private System.Windows.Forms.Label lblTongLoiNhuan;
        private System.Windows.Forms.Label lblTyLeLoiNhuan;
        private System.Windows.Forms.Button btnXuatBaoCao;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.Panel panelThongKe;
    }
}
