using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CNPM_Project
{
    public partial class frmXoaCongNo : Form
    {
        string connectionString = @"Data Source=DESKTOP-MJLB0BP\SQLEXPRESS;Initial Catalog=NhaThuocDB;Integrated Security=True;TrustServerCertificate=True";

        public frmXoaCongNo()
        {
            InitializeComponent();
        }

        private void frmXoaCongNo_Load(object sender, EventArgs e)
        {
            LoadCongNo();
        }

        private void LoadCongNo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            CN.MaCongNo,
                            CN.LoaiDoiTuong,
                            CASE 
                                WHEN CN.LoaiDoiTuong = 'KhachHang' THEN KH.Hovaten
                                WHEN CN.LoaiDoiTuong = 'NhaCungCap' THEN NCC.TenNhaCungCap
                            END AS TenDoiTuong,
                            CN.SoTienNo,
                            CN.NgayPhatSinh,
                            CN.LyDo,
                            CN.TrangThai
                        FROM CongNo AS CN
                        LEFT JOIN Thongtinkhachhang AS KH ON CN.MaDoiTuong = KH.Sodienthoai AND CN.LoaiDoiTuong = 'KhachHang'
                        LEFT JOIN NhaCungCap AS NCC ON CN.MaDoiTuong = CAST(NCC.MaNhaCungCap AS NVARCHAR) AND CN.LoaiDoiTuong = 'NhaCungCap'
                        ORDER BY CN.NgayPhatSinh DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCongNo.DataSource = dt;

                    // Tùy chỉnh tên cột
                    if (dgvCongNo.Columns.Count > 0)
                    {
                        dgvCongNo.Columns["MaCongNo"].HeaderText = "Mã";
                        dgvCongNo.Columns["LoaiDoiTuong"].HeaderText = "Loại";
                        dgvCongNo.Columns["TenDoiTuong"].HeaderText = "Tên đối tượng";
                        dgvCongNo.Columns["SoTienNo"].HeaderText = "Số tiền nợ";
                        dgvCongNo.Columns["NgayPhatSinh"].HeaderText = "Ngày phát sinh";
                        dgvCongNo.Columns["LyDo"].HeaderText = "Lý do";
                        dgvCongNo.Columns["TrangThai"].HeaderText = "Trạng thái";

                        // Định dạng tiền tệ
                        dgvCongNo.Columns["SoTienNo"].DefaultCellStyle.Format = "N0";
                        
                        // Định dạng ngày
                        dgvCongNo.Columns["NgayPhatSinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách công nợ: " + ex.Message, "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvCongNo.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khoản công nợ cần xóa!", "Cảnh báo");
                return;
            }

            // Xác nhận xóa
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa khoản công nợ này?", 
                "Xác nhận", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                int maCongNo = Convert.ToInt32(dgvCongNo.CurrentRow.Cells["MaCongNo"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Kiểm tra điều kiện xóa (có thể xóa nếu đã thanh toán hoặc theo quy tắc khác)
                    string checkQuery = "SELECT TrangThai FROM CongNo WHERE MaCongNo = @MaCongNo";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@MaCongNo", maCongNo);
                    string trangThai = checkCmd.ExecuteScalar()?.ToString();

                    // Xóa công nợ
                    string deleteQuery = "DELETE FROM CongNo WHERE MaCongNo = @MaCongNo";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                    deleteCmd.Parameters.AddWithValue("@MaCongNo", maCongNo);
                    
                    int rowsAffected = deleteCmd.ExecuteNonQuery();
                    
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa công nợ thành công!", "Thành công");
                        LoadCongNo(); // Reload lại danh sách
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa công nợ!", "Lỗi");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa công nợ: " + ex.Message, "Lỗi");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            // Tìm kiếm công nợ
            string keyword = txtTimKiem.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadCongNo();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            CN.MaCongNo,
                            CN.LoaiDoiTuong,
                            CASE 
                                WHEN CN.LoaiDoiTuong = 'KhachHang' THEN KH.Hovaten
                                WHEN CN.LoaiDoiTuong = 'NhaCungCap' THEN NCC.TenNhaCungCap
                            END AS TenDoiTuong,
                            CN.SoTienNo,
                            CN.NgayPhatSinh,
                            CN.LyDo,
                            CN.TrangThai
                        FROM CongNo AS CN
                        LEFT JOIN Thongtinkhachhang AS KH ON CN.MaDoiTuong = KH.Sodienthoai AND CN.LoaiDoiTuong = 'KhachHang'
                        LEFT JOIN NhaCungCap AS NCC ON CN.MaDoiTuong = CAST(NCC.MaNhaCungCap AS NVARCHAR) AND CN.LoaiDoiTuong = 'NhaCungCap'
                        WHERE KH.Hovaten LIKE @Keyword OR NCC.TenNhaCungCap LIKE @Keyword OR CN.LyDo LIKE @Keyword
                        ORDER BY CN.NgayPhatSinh DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCongNo.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi");
            }
        }
    }
}
