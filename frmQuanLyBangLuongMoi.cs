using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CNPM_Project
{
    public partial class frmQuanLyBangLuongMoi : Form
    {
        string connectionString = @"Data Source=DESKTOP-MJLB0BP\SQLEXPRESS;Initial Catalog=NhaThuocDB;Integrated Security=True;TrustServerCertificate=True";
        private int selectedMaBangLuong = -1; // Lưu mã bảng lương đang chọn

        public frmQuanLyBangLuongMoi()
        {
            InitializeComponent();
        }

        private void frmQuanLyBangLuongMoi_Load(object sender, EventArgs e)
        {
            LoadData();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            // Thiết lập chế độ chọn cả dòng
            dgvBangLuong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBangLuong.MultiSelect = false;
            dgvBangLuong.ReadOnly = true;
            dgvBangLuong.AllowUserToAddRows = false;
        }

        private void LoadData()
        {
            LoadNhanVienToComboBox();
            LoadBangLuongToGrid();
        }

        private void LoadNhanVienToComboBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Manguoidung, Hovaten FROM Taikhoan ORDER BY Hovaten";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thêm dòng "Chọn nhân viên" ở đầu
                    DataRow row = dt.NewRow();
                    row["Manguoidung"] = "";
                    row["Hovaten"] = "-- Chọn nhân viên --";
                    dt.Rows.InsertAt(row, 0);

                    cboNhanVien.DataSource = dt;
                    cboNhanVien.DisplayMember = "Hovaten";
                    cboNhanVien.ValueMember = "Manguoidung";
                    cboNhanVien.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBangLuongToGrid(int? thang = null, int? nam = null, string maNhanVien = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    string query = @"
                        SELECT 
                            BL.MaBangLuong,
                            BL.MaNhanVien, 
                            TK.Hovaten,
                            TK.Chucvu,
                            BL.Thang,
                            BL.Nam,
                            BL.SoNgayCongThucTe,
                            BL.LuongCoBan, 
                            BL.PhuCap,
                            BL.KhauTruBaoHiem,
                            BL.ThucLinh,
                            BL.NgayTinhLuong
                        FROM BangLuong AS BL
                        JOIN Taikhoan AS TK ON BL.MaNhanVien = TK.Manguoidung
                        WHERE 1=1";

                    // Thêm điều kiện lọc nếu có
                    if (thang.HasValue && thang.Value > 0)
                        query += " AND BL.Thang = @Thang";
                    
                    if (nam.HasValue && nam.Value > 0)
                        query += " AND BL.Nam = @Nam";
                    
                    if (!string.IsNullOrEmpty(maNhanVien))
                        query += " AND BL.MaNhanVien = @MaNV";

                    query += " ORDER BY BL.MaNhanVien";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    
                    if (thang.HasValue && thang.Value > 0)
                        cmd.Parameters.AddWithValue("@Thang", thang.Value);
                    
                    if (nam.HasValue && nam.Value > 0)
                        cmd.Parameters.AddWithValue("@Nam", nam.Value);
                    
                    if (!string.IsNullOrEmpty(maNhanVien))
                        cmd.Parameters.AddWithValue("@MaNV", maNhanVien);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvBangLuong.DataSource = dt;

                    if (dgvBangLuong.Columns.Count > 0)
                    {
                        // Ẩn cột ID
                        dgvBangLuong.Columns["MaBangLuong"].Visible = false;
                        
                        // Đặt tên cột
                        dgvBangLuong.Columns["MaNhanVien"].HeaderText = "Mã NV";
                        dgvBangLuong.Columns["Hovaten"].HeaderText = "Họ và Tên";
                        dgvBangLuong.Columns["Chucvu"].HeaderText = "Chức vụ";
                        dgvBangLuong.Columns["Thang"].HeaderText = "Tháng";
                        dgvBangLuong.Columns["Nam"].HeaderText = "Năm";
                        dgvBangLuong.Columns["SoNgayCongThucTe"].HeaderText = "Ngày công";
                        dgvBangLuong.Columns["LuongCoBan"].HeaderText = "Lương Cơ Bản";
                        dgvBangLuong.Columns["PhuCap"].HeaderText = "Phụ Cấp";
                        dgvBangLuong.Columns["KhauTruBaoHiem"].HeaderText = "Khấu trừ BH";
                        dgvBangLuong.Columns["ThucLinh"].HeaderText = "Thực Lĩnh";
                        dgvBangLuong.Columns["NgayTinhLuong"].HeaderText = "Ngày tính";

                        // Định dạng tiền tệ
                        dgvBangLuong.Columns["LuongCoBan"].DefaultCellStyle.Format = "N0";
                        dgvBangLuong.Columns["PhuCap"].DefaultCellStyle.Format = "N0";
                        dgvBangLuong.Columns["KhauTruBaoHiem"].DefaultCellStyle.Format = "N0";
                        dgvBangLuong.Columns["ThucLinh"].DefaultCellStyle.Format = "N0";

                        // Định dạng ngày
                        dgvBangLuong.Columns["NgayTinhLuong"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                        // Thiết lập độ rộng cột
                        dgvBangLuong.Columns["MaNhanVien"].Width = 60;
                        dgvBangLuong.Columns["Hovaten"].Width = 130;
                        dgvBangLuong.Columns["Chucvu"].Width = 140;
                        dgvBangLuong.Columns["Thang"].Width = 60;
                        dgvBangLuong.Columns["Nam"].Width = 60;
                        dgvBangLuong.Columns["SoNgayCongThucTe"].Width = 80;
                    }

                    lblTongSoBanGhi.Text = $"Tổng số: {dt.Rows.Count} bản ghi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bảng lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                string maNhanVien = cboNhanVien.SelectedValue?.ToString();
                int soNgayCong = Convert.ToInt32(txtSoNgayCong.Text);

                decimal luongThucLinh = TinhLuong(maNhanVien, soNgayCong, out decimal luongCoBan, out decimal phuCap, out decimal khauTru);

                if (luongThucLinh > 0)
                {
                    string message = $"KẾT QUẢ TÍNH LƯƠNG\n\n" +
                                   $"Nhân viên: {cboNhanVien.Text}\n" +
                                   $"Số ngày công: {soNgayCong}\n" +
                                   $"━━━━━━━━━━━━━━━━━━━━━━\n" +
                                   $"Lương cơ bản: {luongCoBan:N0} VNĐ\n" +
                                   $"Phụ cấp: {phuCap:N0} VNĐ\n" +
                                   $"Khấu trừ BH: {khauTru:N0} VNĐ\n" +
                                   $"━━━━━━━━━━━━━━━━━━━━━━\n" +
                                   $"THỰC LĨNH: {luongThucLinh:N0} VNĐ";
                    
                    MessageBox.Show(message, "Kết quả tính lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {                
                string maNhanVien = cboNhanVien.SelectedValue?.ToString();
                int thang = Convert.ToInt32(numThang.Value);
                int nam = Convert.ToInt32(numNam.Value);
                int soNgayCong = Convert.ToInt32(txtSoNgayCong.Text);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra trùng
                    string checkQuery = "SELECT COUNT(*) FROM BangLuong WHERE MaNhanVien = @MaNV AND Thang = @Thang AND Nam = @Nam";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@MaNV", maNhanVien);
                    checkCmd.Parameters.AddWithValue("@Thang", thang);
                    checkCmd.Parameters.AddWithValue("@Nam", nam);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Bảng lương cho nhân viên này trong tháng/năm này đã tồn tại!", 
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tính lương
                    decimal luongThucLinh = TinhLuong(maNhanVien, soNgayCong, out decimal luongCoBan, out decimal phuCap, out decimal khauTru);

                    if (luongThucLinh <= 0)
                        return;

                    // Lưu vào database
                    string insertQuery = @"INSERT INTO BangLuong 
                                        (MaNhanVien, Thang, Nam, SoNgayCongThucTe, LuongCoBan, PhuCap, KhauTruBaoHiem, ThucLinh) 
                                        VALUES (@MaNV, @Thang, @Nam, @SoNgayCong, @LuongCoBan, @PhuCap, @KhauTru, @ThucLinh)";
                    
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@MaNV", maNhanVien);
                    insertCmd.Parameters.AddWithValue("@Thang", thang);
                    insertCmd.Parameters.AddWithValue("@Nam", nam);
                    insertCmd.Parameters.AddWithValue("@SoNgayCong", soNgayCong);
                    insertCmd.Parameters.AddWithValue("@LuongCoBan", luongCoBan);
                    insertCmd.Parameters.AddWithValue("@PhuCap", phuCap);
                    insertCmd.Parameters.AddWithValue("@KhauTru", khauTru);
                    insertCmd.Parameters.AddWithValue("@ThucLinh", luongThucLinh);

                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm bảng lương thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    LoadBangLuongToGrid();
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm bảng lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedMaBangLuong < 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi từ bảng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                string maNhanVien = cboNhanVien.SelectedValue?.ToString();
                int thang = Convert.ToInt32(numThang.Value);
                int nam = Convert.ToInt32(numNam.Value);
                int soNgayCong = Convert.ToInt32(txtSoNgayCong.Text);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra trùng (trừ bản ghi đang sửa)
                    string checkQuery = @"SELECT COUNT(*) FROM BangLuong 
                                        WHERE MaNhanVien = @MaNV AND Thang = @Thang AND Nam = @Nam 
                                        AND MaBangLuong != @MaBangLuong";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@MaNV", maNhanVien);
                    checkCmd.Parameters.AddWithValue("@Thang", thang);
                    checkCmd.Parameters.AddWithValue("@Nam", nam);
                    checkCmd.Parameters.AddWithValue("@MaBangLuong", selectedMaBangLuong);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Bảng lương cho nhân viên này trong tháng/năm này đã tồn tại!", 
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tính lại lương
                    decimal luongThucLinh = TinhLuong(maNhanVien, soNgayCong, out decimal luongCoBan, out decimal phuCap, out decimal khauTru);

                    if (luongThucLinh <= 0)
                        return;

                    // Cập nhật
                    string updateQuery = @"UPDATE BangLuong 
                                         SET MaNhanVien = @MaNV, 
                                             Thang = @Thang, 
                                             Nam = @Nam, 
                                             SoNgayCongThucTe = @SoNgayCong, 
                                             LuongCoBan = @LuongCoBan, 
                                             PhuCap = @PhuCap, 
                                             KhauTruBaoHiem = @KhauTru, 
                                             ThucLinh = @ThucLinh,
                                             NgayTinhLuong = GETDATE()
                                         WHERE MaBangLuong = @MaBangLuong";
                    
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@MaNV", maNhanVien);
                    updateCmd.Parameters.AddWithValue("@Thang", thang);
                    updateCmd.Parameters.AddWithValue("@Nam", nam);
                    updateCmd.Parameters.AddWithValue("@SoNgayCong", soNgayCong);
                    updateCmd.Parameters.AddWithValue("@LuongCoBan", luongCoBan);
                    updateCmd.Parameters.AddWithValue("@PhuCap", phuCap);
                    updateCmd.Parameters.AddWithValue("@KhauTru", khauTru);
                    updateCmd.Parameters.AddWithValue("@ThucLinh", luongThucLinh);
                    updateCmd.Parameters.AddWithValue("@MaBangLuong", selectedMaBangLuong);

                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật bảng lương thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    LoadBangLuongToGrid();
                    ClearInput();
                    selectedMaBangLuong = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật bảng lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedMaBangLuong < 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi từ bảng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", 
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM BangLuong WHERE MaBangLuong = @MaBangLuong";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaBangLuong", selectedMaBangLuong);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Xóa bản ghi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBangLuongToGrid();
                        ClearInput();
                        selectedMaBangLuong = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa bản ghi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int? thang = chkThang.Checked && numThang.Value > 0 ? (int?)numThang.Value : null;
            int? nam = chkNam.Checked && numNam.Value > 0 ? (int?)numNam.Value : null;
            string maNV = cboNhanVien.SelectedValue != null && !string.IsNullOrEmpty(cboNhanVien.SelectedValue.ToString()) 
                        ? cboNhanVien.SelectedValue.ToString() 
                        : null;

            LoadBangLuongToGrid(thang, nam, maNV);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadBangLuongToGrid();
            ClearInput();
        }

        private void btnThongSoLuong_Click(object sender, EventArgs e)
        {
            frmThongSoLuong frm = new frmThongSoLuong();
            frm.ShowDialog();
        }

        private void dgvBangLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBangLuong.Rows[e.RowIndex].Cells["MaBangLuong"].Value != null)
            {
                try
                {
                    DataGridViewRow row = dgvBangLuong.Rows[e.RowIndex];
                    
                    selectedMaBangLuong = Convert.ToInt32(row.Cells["MaBangLuong"].Value);
                    
                    // Điền dữ liệu vào form
                    cboNhanVien.SelectedValue = row.Cells["MaNhanVien"].Value.ToString();
                    numThang.Value = Convert.ToInt32(row.Cells["Thang"].Value);
                    numNam.Value = Convert.ToInt32(row.Cells["Nam"].Value);
                    txtSoNgayCong.Text = row.Cells["SoNgayCongThucTe"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn bản ghi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private decimal TinhLuong(string maNhanVien, int soNgayCong, out decimal luongCoBan, out decimal phuCap, out decimal khauTru)
        {
            luongCoBan = 0;
            phuCap = 0;
            khauTru = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy chức vụ của nhân viên
                    string getChucVuQuery = "SELECT Chucvu FROM Taikhoan WHERE Manguoidung = @MaNV";
                    SqlCommand cmdChucVu = new SqlCommand(getChucVuQuery, conn);
                    cmdChucVu.Parameters.AddWithValue("@MaNV", maNhanVien);
                    string chucVu = cmdChucVu.ExecuteScalar()?.ToString();

                    if (string.IsNullOrEmpty(chucVu))
                    {
                        MessageBox.Show("Không tìm thấy chức vụ của nhân viên!", 
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }

                    // Lấy thông số lương theo chức vụ, tháng và năm
                    int thang = Convert.ToInt32(numThang.Value);
                    int nam = Convert.ToInt32(numNam.Value);
                    
                    string query = @"SELECT TOP 1 * FROM ThongSoLuong 
                                   WHERE ChucVu = @ChucVu AND Thang = @Thang AND Nam = @Nam";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ChucVu", chucVu);
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.Read())
                    {
                        MessageBox.Show($"Chưa có thông số lương cho chức vụ '{chucVu}' trong tháng {thang}/{nam}!\nVui lòng thiết lập trước.", 
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        reader.Close();
                        return 0;
                    }

                    decimal heSoLuong = Convert.ToDecimal(reader["HeSoLuongCoBan"]);
                    phuCap = Convert.ToDecimal(reader["PhuCapChucVu"]);
                    decimal tyLeBHXH = Convert.ToDecimal(reader["TyLeBHXH"]);
                    decimal tyLeBHYT = Convert.ToDecimal(reader["TyLeBHYT"]);
                    decimal tyLeBHTN = Convert.ToDecimal(reader["TyLeBHTN"]);
                    reader.Close();

                    // Tính lương cơ bản (giả sử 1 tháng = 26 ngày công)
                    luongCoBan = heSoLuong * soNgayCong / 26;
                    
                    // Tính tổng bảo hiểm
                    khauTru = luongCoBan * (tyLeBHXH + tyLeBHYT + tyLeBHTN) / 100;

                    // Tính thực lĩnh
                    decimal thucLinh = luongCoBan + phuCap - khauTru;

                    return thucLinh;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private bool ValidateInput()
        {
            if (cboNhanVien.SelectedValue == null || string.IsNullOrEmpty(cboNhanVien.SelectedValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhanVien.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoNgayCong.Text))
            {
                MessageBox.Show("Vui lòng nhập số ngày công!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoNgayCong.Focus();
                return false;
            }

            int soNgayCong;
            if (!int.TryParse(txtSoNgayCong.Text, out soNgayCong) || soNgayCong < 0 || soNgayCong > 31)
            {
                MessageBox.Show("Số ngày công phải là số nguyên từ 0 đến 31!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoNgayCong.Focus();
                return false;
            }

            return true;
        }

        private void ClearInput()
        {
            cboNhanVien.SelectedIndex = 0;
            txtSoNgayCong.Clear();
            numThang.Value = DateTime.Now.Month;
            numNam.Value = DateTime.Now.Year;
            selectedMaBangLuong = -1;
            chkThang.Checked = false;
            chkNam.Checked = false;
        }
    }
}
