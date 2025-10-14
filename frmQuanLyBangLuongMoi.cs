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

        // --- Các hàm xử lý sự kiện cho nút bấm (giữ nguyên) ---
        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển!");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã lưu (demo)!");
        }

        private void btnSuaThongSo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở form chỉnh sửa thông số lương!");
        }
    }
}