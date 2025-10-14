namespace CNPM_Project
{
    partial class frmThemCongNo
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
            this.lblLoaiDoiTuong = new System.Windows.Forms.Label();
            this.cboLoaiDoiTuong = new System.Windows.Forms.ComboBox();
            this.lblDoiTuong = new System.Windows.Forms.Label();
            this.cboDoiTuong = new System.Windows.Forms.ComboBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.lblNgayPhatSinh = new System.Windows.Forms.Label();
            this.dtpNgayPhatSinh = new System.Windows.Forms.DateTimePicker();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(160, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 24);
            this.lblTitle.Text = "THÊM CÔNG NỢ MỚI";
            
            // lblLoaiDoiTuong
            this.lblLoaiDoiTuong.AutoSize = true;
            this.lblLoaiDoiTuong.Location = new System.Drawing.Point(30, 70);
            this.lblLoaiDoiTuong.Name = "lblLoaiDoiTuong";
            this.lblLoaiDoiTuong.Size = new System.Drawing.Size(90, 13);
            this.lblLoaiDoiTuong.Text = "Loại đối tượng:";
            
            // cboLoaiDoiTuong
            this.cboLoaiDoiTuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiDoiTuong.FormattingEnabled = true;
            this.cboLoaiDoiTuong.Location = new System.Drawing.Point(160, 67);
            this.cboLoaiDoiTuong.Name = "cboLoaiDoiTuong";
            this.cboLoaiDoiTuong.Size = new System.Drawing.Size(300, 21);
            this.cboLoaiDoiTuong.SelectedIndexChanged += new System.EventHandler(this.cboLoaiDoiTuong_SelectedIndexChanged);
            
            // lblDoiTuong
            this.lblDoiTuong.AutoSize = true;
            this.lblDoiTuong.Location = new System.Drawing.Point(30, 105);
            this.lblDoiTuong.Name = "lblDoiTuong";
            this.lblDoiTuong.Size = new System.Drawing.Size(115, 13);
            this.lblDoiTuong.Text = "Khách hàng/NCC:";
            
            // cboDoiTuong
            this.cboDoiTuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoiTuong.FormattingEnabled = true;
            this.cboDoiTuong.Location = new System.Drawing.Point(160, 102);
            this.cboDoiTuong.Name = "cboDoiTuong";
            this.cboDoiTuong.Size = new System.Drawing.Size(300, 21);
            
            // lblSoTien
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new System.Drawing.Point(30, 140);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(95, 13);
            this.lblSoTien.Text = "Số tiền nợ (VNĐ):";
            
            // txtSoTien
            this.txtSoTien.Location = new System.Drawing.Point(160, 137);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(300, 20);
            
            // lblNgayPhatSinh
            this.lblNgayPhatSinh.AutoSize = true;
            this.lblNgayPhatSinh.Location = new System.Drawing.Point(30, 175);
            this.lblNgayPhatSinh.Name = "lblNgayPhatSinh";
            this.lblNgayPhatSinh.Size = new System.Drawing.Size(90, 13);
            this.lblNgayPhatSinh.Text = "Ngày phát sinh:";
            
            // dtpNgayPhatSinh
            this.dtpNgayPhatSinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayPhatSinh.Location = new System.Drawing.Point(160, 172);
            this.dtpNgayPhatSinh.Name = "dtpNgayPhatSinh";
            this.dtpNgayPhatSinh.Size = new System.Drawing.Size(300, 20);
            
            // lblLyDo
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Location = new System.Drawing.Point(30, 210);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(40, 13);
            this.lblLyDo.Text = "Lý do:";
            
            // txtLyDo
            this.txtLyDo.Location = new System.Drawing.Point(160, 207);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(300, 60);
            
            // btnLuu
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(150, 290);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(120, 40);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            
            // btnHuy
            this.btnHuy.BackColor = System.Drawing.Color.Gray;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(290, 290);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 40);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            
            // frmThemCongNo
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 360);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtLyDo);
            this.Controls.Add(this.lblLyDo);
            this.Controls.Add(this.dtpNgayPhatSinh);
            this.Controls.Add(this.lblNgayPhatSinh);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.lblSoTien);
            this.Controls.Add(this.cboDoiTuong);
            this.Controls.Add(this.lblDoiTuong);
            this.Controls.Add(this.cboLoaiDoiTuong);
            this.Controls.Add(this.lblLoaiDoiTuong);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmThemCongNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm công nợ";
            this.Load += new System.EventHandler(this.frmThemCongNo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLoaiDoiTuong;
        private System.Windows.Forms.ComboBox cboLoaiDoiTuong;
        private System.Windows.Forms.Label lblDoiTuong;
        private System.Windows.Forms.ComboBox cboDoiTuong;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label lblNgayPhatSinh;
        private System.Windows.Forms.DateTimePicker dtpNgayPhatSinh;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}
