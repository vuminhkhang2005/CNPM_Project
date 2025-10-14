using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CNPM_Project
{
    public partial class frmChiPhiNhapHang : Form
    {
        string connectionString = @"Data Source=DESKTOP-MJLB0BP\SQLEXPRESS;Initial Catalog=NhaThuocDB;Integrated Security=True;TrustServerCertificate=True";

        public frmChiPhiNhapHang()
        {
            InitializeComponent();
        }

        private void frmChiPhiNhapHang_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho ngày
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // Đầu tháng
            dtpDenNgay.Value = DateTime.Now; // Hôm nay
            
            LoadChiPhiNhapHang();
        }

        private void LoadChiPhiNhapHang()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            PNH.MaPhieuNhap,
                            PNH.NgayNhap,
                            NCC.TenNhaCungCap,
                            NCC.SoDienThoai,
                            TK.Hovaten AS NguoiTao,
                            PNH.TongTien
                        FROM PhieuNhapHang AS PNH
                        INNER JOIN NhaCungCap AS NCC ON PNH.MaNhaCungCap = NCC.MaNhaCungCap
                        INNER JOIN Taikhoan AS TK ON PNH.MaNguoiTao = TK.Manguoidung
                        WHERE PNH.NgayNhap BETWEEN @TuNgay AND @DenNgay
                        ORDER BY PNH.NgayNhap DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                    da.SelectCommand.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));
                    
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPhieuNhap.DataSource = dt;

                    // Tùy chỉnh tên cột
                    if (dgvPhieuNhap.Columns.Count > 0)
                    {
                        dgvPhieuNhap.Columns["MaPhieuNhap"].HeaderText = "Mã phiếu";
                        dgvPhieuNhap.Columns["NgayNhap"].HeaderText = "Ngày nhập";
                        dgvPhieuNhap.Columns["TenNhaCungCap"].HeaderText = "Nhà cung cấp";
                        dgvPhieuNhap.Columns["SoDienThoai"].HeaderText = "SĐT";
                        dgvPhieuNhap.Columns["NguoiTao"].HeaderText = "Người tạo";
                        dgvPhieuNhap.Columns["TongTien"].HeaderText = "Tổng tiền";

                        // Định dạng tiền tệ
                        dgvPhieuNhap.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                        
                        // Định dạng ngày
                        dgvPhieuNhap.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }

                    // Tính tổng chi phí
                    decimal tongChiPhi = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        tongChiPhi += Convert.ToDecimal(row["TongTien"]);
                    }
                    lblTongChiPhi.Text = $"Tổng chi phí nhập hàng: {tongChiPhi:N0} VNĐ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi phí nhập hàng: " + ex.Message, "Lỗi");
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadChiPhiNhapHang();
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            // Tính năng xuất báo cáo (có thể xuất Excel, PDF...)
            MessageBox.Show("Chức năng xuất báo cáo đang được phát triển!", "Thông báo");
            
            // TODO: Implement export to Excel/PDF
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPhieuNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xem chi tiết phiếu nhập khi double-click
            if (e.RowIndex >= 0)
            {
                int maPhieuNhap = Convert.ToInt32(dgvPhieuNhap.Rows[e.RowIndex].Cells["MaPhieuNhap"].Value);
                XemChiTietPhieuNhap(maPhieuNhap);
            }
        }

        private void XemChiTietPhieuNhap(int maPhieuNhap)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            SP.Tenhang,
                            CTPN.SoLuongNhap,
                            CTPN.DonGiaNhap,
                            CTPN.ThanhTien
                        FROM ChiTietPhieuNhap AS CTPN
                        INNER JOIN Sanphamthuoc AS SP ON CTPN.MaSanPham = SP.ID
                        WHERE CTPN.MaPhieuNhap = @MaPhieuNhap";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                    
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Hiển thị chi tiết trong MessageBox hoặc form mới
                    string details = $"Chi tiết phiếu nhập #{maPhieuNhap}:\n\n";
                    foreach (DataRow row in dt.Rows)
                    {
                        details += $"- {row["Tenhang"]}: {row["SoLuongNhap"]} x {Convert.ToDecimal(row["DonGiaNhap"]):N0} = {Convert.ToDecimal(row["ThanhTien"]):N0} VNĐ\n";
                    }

                    MessageBox.Show(details, "Chi tiết phiếu nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xem chi tiết: " + ex.Message, "Lỗi");
            }
        }
    }
}
