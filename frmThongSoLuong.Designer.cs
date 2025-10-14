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
            this.lblNgayApDung = new System.Windows.Forms.Label();
            this.dtpNgayApDung = new System.Windows.Forms.DateTimePicker();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(120, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 24);
            this.lblTitle.Text = "CHỈNH SỬA THÔNG SỐ BẢNG LƯƠNG";
            
            // lblHeSoLuong
            this.lblHeSoLuong.AutoSize = true;
            this.lblHeSoLuong.Location = new System.Drawing.Point(30, 70);
            this.lblHeSoLuong.Name = "lblHeSoLuong";
            this.lblHeSoLuong.Size = new System.Drawing.Size(130, 13);
            this.lblHeSoLuong.Text = "Hệ số lương cơ bản (VNĐ):";
            
            // txtHeSoLuong
            this.txtHeSoLuong.Location = new System.Drawing.Point(200, 67);
            this.txtHeSoLuong.Name = "txtHeSoLuong";
            this.txtHeSoLuong.Size = new System.Drawing.Size(280, 20);
            
            // lblPhuCap
            this.lblPhuCap.AutoSize = true;
            this.lblPhuCap.Location = new System.Drawing.Point(30, 105);
            this.lblPhuCap.Name = "lblPhuCap";
            this.lblPhuCap.Size = new System.Drawing.Size(130, 13);
            this.lblPhuCap.Text = "Phụ cấp chức vụ (VNĐ):";
            
            // txtPhuCapChucVu
            this.txtPhuCapChucVu.Location = new System.Drawing.Point(200, 102);
            this.txtPhuCapChucVu.Name = "txtPhuCapChucVu";
            this.txtPhuCapChucVu.Size = new System.Drawing.Size(280, 20);
            this.txtPhuCapChucVu.Text = "0";
            
            // lblBHXH
            this.lblBHXH.AutoSize = true;
            this.lblBHXH.Location = new System.Drawing.Point(30, 140);
            this.lblBHXH.Name = "lblBHXH";
            this.lblBHXH.Size = new System.Drawing.Size(140, 13);
            this.lblBHXH.Text = "Tỷ lệ bảo hiểm xã hội (%):";
            
            // txtTyLeBHXH
            this.txtTyLeBHXH.Location = new System.Drawing.Point(200, 137);
            this.txtTyLeBHXH.Name = "txtTyLeBHXH";
            this.txtTyLeBHXH.Size = new System.Drawing.Size(280, 20);
            
            // lblBHYT
            this.lblBHYT.AutoSize = true;
            this.lblBHYT.Location = new System.Drawing.Point(30, 175);
            this.lblBHYT.Name = "lblBHYT";
            this.lblBHYT.Size = new System.Drawing.Size(130, 13);
            this.lblBHYT.Text = "Tỷ lệ bảo hiểm y tế (%):";
            
            // txtTyLeBHYT
            this.txtTyLeBHYT.Location = new System.Drawing.Point(200, 172);
            this.txtTyLeBHYT.Name = "txtTyLeBHYT";
            this.txtTyLeBHYT.Size = new System.Drawing.Size(280, 20);
            
            // lblBHTN
            this.lblBHTN.AutoSize = true;
            this.lblBHTN.Location = new System.Drawing.Point(30, 210);
            this.lblBHTN.Name = "lblBHTN";
            this.lblBHTN.Size = new System.Drawing.Size(160, 13);
            this.lblBHTN.Text = "Tỷ lệ bảo hiểm thất nghiệp (%):";
            
            // txtTyLeBHTN
            this.txtTyLeBHTN.Location = new System.Drawing.Point(200, 207);
            this.txtTyLeBHTN.Name = "txtTyLeBHTN";
            this.txtTyLeBHTN.Size = new System.Drawing.Size(280, 20);
            
            // lblNgayApDung
            this.lblNgayApDung.AutoSize = true;
            this.lblNgayApDung.Location = new System.Drawing.Point(30, 245);
            this.lblNgayApDung.Name = "lblNgayApDung";
            this.lblNgayApDung.Size = new System.Drawing.Size(80, 13);
            this.lblNgayApDung.Text = "Ngày áp dụng:";
            
            // dtpNgayApDung
            this.dtpNgayApDung.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayApDung.Location = new System.Drawing.Point(200, 242);
            this.dtpNgayApDung.Name = "dtpNgayApDung";
            this.dtpNgayApDung.Size = new System.Drawing.Size(280, 20);
            
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
            
            // frmThongSoLuong
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 360);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dtpNgayApDung);
            this.Controls.Add(this.lblNgayApDung);
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
            this.Controls.Add(this.lblTitle);
            this.Name = "frmThongSoLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh sửa thông số bảng lương";
            this.Load += new System.EventHandler(this.frmThongSoLuong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
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
        private System.Windows.Forms.Label lblNgayApDung;
        private System.Windows.Forms.DateTimePicker dtpNgayApDung;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}
