using System;
using System.Data; // Thêm thư viện này để dùng DataTable
using System.Data.SqlClient; // Thêm thư viện này để kết nối SQL Server
using System.Windows.Forms;

namespace CNPM_Project
{
    public partial class frmQuanLyBangLuongMoi : Form
    {
        string connectionString = @"Data Source=DESKTOP-MJLB0BP\SQLEXPRESS;Initial Catalog=NhaThuocDB;Integrated Security=True;TrustServerCertificate=True";

        public frmQuanLyBangLuongMoi()
        {
            InitializeComponent();
        }

        // Sửa lại sự kiện Form_Load để gọi LoadData()
        private void frmQuanLyBangLuongMoi_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // ✅ VIẾT LẠI HOÀN TOÀN PHƯƠNG THỨC NÀY
        private void LoadData()
        {
            // Tải danh sách nhân viên vào ComboBox
            LoadNhanVienToComboBox();

            // Tải dữ liệu bảng lương vào DataGridView
            LoadBangLuongToGrid();
        }

        private void LoadNhanVienToComboBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Manguoidung, Hovaten FROM Taikhoan WHERE Chucvu = N'Nhân viên'";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thiết lập DataSource cho ComboBox
                    cboNhanVien.DataSource = dt;
                    cboNhanVien.DisplayMember = "Hovaten"; // Hiển thị cột Họ và tên
                    cboNhanVien.ValueMember = "Manguoidung"; // Giá trị ẩn là Mã người dùng
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi Cơ sở dữ liệu");
            }
        }

        private void LoadBangLuongToGrid()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Câu lệnh JOIN để lấy được tên nhân viên từ bảng Taikhoan
                    string query = @"
                        SELECT 
                            BL.MaNhanVien, 
                            TK.Hovaten, 
                            CAST(BL.Thang AS VARCHAR) + '/' + CAST(BL.Nam AS VARCHAR) AS KyLuong,
                            BL.SoNgayCongThucTe,
                            BL.LuongCoBan, 
                            BL.ThucLinh
                        FROM BangLuong AS BL
                        JOIN Taikhoan AS TK ON BL.MaNhanVien = TK.Manguoidung";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Gán thẳng DataTable làm nguồn dữ liệu cho DataGridView
                    dgvBangLuong.DataSource = dt;

                    // Tùy chỉnh tên cột cho đẹp hơn (tùy chọn)
                    if (dgvBangLuong.Columns.Count > 0)
                    {
                        dgvBangLuong.Columns["MaNhanVien"].HeaderText = "Mã NV";
                        dgvBangLuong.Columns["Hovaten"].HeaderText = "Họ và Tên";
                        dgvBangLuong.Columns["KyLuong"].HeaderText = "Kỳ Lương";
                        dgvBangLuong.Columns["SoNgayCongThucTe"].HeaderText = "Ngày công";
                        dgvBangLuong.Columns["LuongCoBan"].HeaderText = "Lương Cơ Bản";
                        dgvBangLuong.Columns["ThucLinh"].HeaderText = "Thực Lĩnh";

                        // Định dạng cột tiền tệ
                        dgvBangLuong.Columns["LuongCoBan"].DefaultCellStyle.Format = "N0";
                        dgvBangLuong.Columns["ThucLinh"].DefaultCellStyle.Format = "N0";
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bảng lương: " + ex.Message, "Lỗi Cơ sở dữ liệu");
            }
        }

        // --- Các hàm xử lý sự kiện cho nút bấm ---
        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Cảnh báo");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoNgayCong.Text))
            {
                MessageBox.Show("Vui lòng nhập số ngày công!", "Cảnh báo");
                return;
            }

            try
            {
                int maNhanVien = Convert.ToInt32(cboNhanVien.SelectedValue);
                int thang = Convert.ToInt32(numThang.Value);
                int nam = Convert.ToInt32(numNam.Value);
                int soNgayCong = Convert.ToInt32(txtSoNgayCong.Text);

                // Tính lương
                decimal luongThucLinh = TinhLuong(maNhanVien, soNgayCong, thang, nam);

                if (luongThucLinh > 0)
                {
                    MessageBox.Show($"Lương thực lĩnh của nhân viên: {luongThucLinh:N0} VNĐ", "Kết quả tính lương");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Số ngày công phải là số nguyên!", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính lương: " + ex.Message, "Lỗi");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Cảnh báo");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoNgayCong.Text))
            {
                MessageBox.Show("Vui lòng nhập số ngày công!", "Cảnh báo");
                return;
            }

            try
            {                
                int maNhanVien = Convert.ToInt32(cboNhanVien.SelectedValue);
                int thang = Convert.ToInt32(numThang.Value);
                int nam = Convert.ToInt32(numNam.Value);
                int soNgayCong = Convert.ToInt32(txtSoNgayCong.Text);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra xem đã có bảng lương cho nhân viên này trong tháng/năm này chưa
                    string checkQuery = "SELECT COUNT(*) FROM BangLuong WHERE MaNhanVien = @MaNV AND Thang = @Thang AND Nam = @Nam";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@MaNV", maNhanVien);
                    checkCmd.Parameters.AddWithValue("@Thang", thang);
                    checkCmd.Parameters.AddWithValue("@Nam", nam);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Bảng lương cho nhân viên này trong tháng/năm này đã tồn tại!", "Cảnh báo");
                        return;
                    }

                    // Lấy thông số lương mới nhất
                    string queryThongSo = "SELECT TOP 1 * FROM ThongSoLuong ORDER BY NgayApDung DESC";
                    SqlCommand cmdThongSo = new SqlCommand(queryThongSo, conn);
                    SqlDataReader reader = cmdThongSo.ExecuteReader();

                    if (!reader.Read())
                    {
                        MessageBox.Show("Chưa có thông số lương trong hệ thống! Vui lòng thiết lập trước.", "Lỗi");
                        reader.Close();
                        return;
                    }

                    decimal heSoLuong = Convert.ToDecimal(reader["HeSoLuongCoBan"]);
                    decimal phuCap = Convert.ToDecimal(reader["PhuCapChucVu"]);
                    decimal tyLeBHXH = Convert.ToDecimal(reader["TyLeBHXH"]);
                    decimal tyLeBHYT = Convert.ToDecimal(reader["TyLeBHYT"]);
                    decimal tyLeBHTN = Convert.ToDecimal(reader["TyLeBHTN"]);
                    reader.Close();

                    // Tính lương cơ bản theo số ngày công (giả sử 1 tháng = 26 ngày công)
                    decimal luongCoBan = heSoLuong * soNgayCong / 26;
                    
                    // Tính tổng bảo hiểm
                    decimal tongBaoHiem = luongCoBan * (tyLeBHXH + tyLeBHYT + tyLeBHTN) / 100;

                    // Tính thực lĩnh
                    decimal thucLinh = luongCoBan + phuCap - tongBaoHiem;

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
                    insertCmd.Parameters.AddWithValue("@KhauTru", tongBaoHiem);
                    insertCmd.Parameters.AddWithValue("@ThucLinh", thucLinh);

                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật bảng lương thành công!", "Thành công");
                    
                    // Reload dữ liệu
                    LoadBangLuongToGrid();
                    
                    // Clear input
                    txtSoNgayCong.Clear();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số!", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu bảng lương: " + ex.Message, "Lỗi");
            }
        }

        private void btnSuaThongSo_Click(object sender, EventArgs e)
        {
            frmThongSoLuong frm = new frmThongSoLuong();
            frm.ShowDialog();
        }

        // Hàm tính lương
        private decimal TinhLuong(int maNhanVien, int soNgayCong, int thang, int nam)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy thông số lương mới nhất
                    string query = "SELECT TOP 1 * FROM ThongSoLuong ORDER BY NgayApDung DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.Read())
                    {
                        MessageBox.Show("Chưa có thông số lương trong hệ thống!", "Lỗi");
                        reader.Close();
                        return 0;
                    }

                    decimal heSoLuong = Convert.ToDecimal(reader["HeSoLuongCoBan"]);
                    decimal phuCap = Convert.ToDecimal(reader["PhuCapChucVu"]);
                    decimal tyLeBHXH = Convert.ToDecimal(reader["TyLeBHXH"]);
                    decimal tyLeBHYT = Convert.ToDecimal(reader["TyLeBHYT"]);
                    decimal tyLeBHTN = Convert.ToDecimal(reader["TyLeBHTN"]);
                    reader.Close();

                    // Tính lương cơ bản (giả sử 1 tháng = 26 ngày công)
                    decimal luongCoBan = heSoLuong * soNgayCong / 26;
                    
                    // Tính tổng bảo hiểm
                    decimal tongBaoHiem = luongCoBan * (tyLeBHXH + tyLeBHYT + tyLeBHTN) / 100;

                    // Tính thực lĩnh
                    decimal thucLinh = luongCoBan + phuCap - tongBaoHiem;

                    return thucLinh;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính lương: " + ex.Message, "Lỗi");
                return 0;
            }
        }
    }
}