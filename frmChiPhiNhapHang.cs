using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;

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
            try
            {
                if (dgvPhieuNhap.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo thư mục Report nếu chưa tồn tại
                string reportFolder = @"C:\Users\DELL\source\repos\CNPM_Project\Report";
                if (!Directory.Exists(reportFolder))
                {
                    Directory.CreateDirectory(reportFolder);
                }

                // Tạo tên file với định dạng ddMMyyyy_ChiPhiNhapHang
                string fileName = DateTime.Now.ToString("ddMMyyyy") + "_ChiPhiNhapHang.xlsx";
                string filePath = Path.Combine(reportFolder, fileName);

                // Tạo workbook mới
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Chi phí nhập hàng");

                    // Tiêu đề báo cáo
                    worksheet.Cell(1, 1).Value = "BÁO CÁO CHI PHÍ NHẬP HÀNG";
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                    worksheet.Range(1, 1, 1, 6).Merge();
                    worksheet.Range(1, 1, 1, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Thời gian báo cáo
                    worksheet.Cell(2, 1).Value = $"Từ ngày: {dtpTuNgay.Value:dd/MM/yyyy} - Đến ngày: {dtpDenNgay.Value:dd/MM/yyyy}";
                    worksheet.Range(2, 1, 2, 6).Merge();
                    worksheet.Range(2, 1, 2, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Header
                    int headerRow = 4;
                    worksheet.Cell(headerRow, 1).Value = "Mã phiếu";
                    worksheet.Cell(headerRow, 2).Value = "Ngày nhập";
                    worksheet.Cell(headerRow, 3).Value = "Nhà cung cấp";
                    worksheet.Cell(headerRow, 4).Value = "SĐT";
                    worksheet.Cell(headerRow, 5).Value = "Người tạo";
                    worksheet.Cell(headerRow, 6).Value = "Tổng tiền (VNĐ)";

                    // Style cho header
                    var headerRange = worksheet.Range(headerRow, 1, headerRow, 6);
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Dữ liệu
                    DataTable dt = (DataTable)dgvPhieuNhap.DataSource;
                    int currentRow = headerRow + 1;
                    decimal tongChiPhi = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        worksheet.Cell(currentRow, 1).Value = row["MaPhieuNhap"].ToString();
                        worksheet.Cell(currentRow, 2).Value = Convert.ToDateTime(row["NgayNhap"]).ToString("dd/MM/yyyy HH:mm");
                        worksheet.Cell(currentRow, 3).Value = row["TenNhaCungCap"].ToString();
                        worksheet.Cell(currentRow, 4).Value = row["SoDienThoai"].ToString();
                        worksheet.Cell(currentRow, 5).Value = row["NguoiTao"].ToString();
                        
                        decimal tongTien = Convert.ToDecimal(row["TongTien"]);
                        worksheet.Cell(currentRow, 6).Value = tongTien;
                        worksheet.Cell(currentRow, 6).Style.NumberFormat.Format = "#,##0";
                        
                        tongChiPhi += tongTien;
                        currentRow++;
                    }

                    // Tổng cộng
                    int totalRow = currentRow;
                    worksheet.Cell(totalRow, 5).Value = "TỔNG CỘNG:";
                    worksheet.Cell(totalRow, 5).Style.Font.Bold = true;
                    worksheet.Cell(totalRow, 6).Value = tongChiPhi;
                    worksheet.Cell(totalRow, 6).Style.Font.Bold = true;
                    worksheet.Cell(totalRow, 6).Style.NumberFormat.Format = "#,##0";
                    worksheet.Cell(totalRow, 6).Style.Fill.BackgroundColor = XLColor.LightYellow;

                    // Border cho dữ liệu
                    var dataRange = worksheet.Range(headerRow, 1, totalRow, 6);
                    dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Auto-fit columns
                    worksheet.Columns().AdjustToContents();

                    // Lưu file
                    workbook.SaveAs(filePath);
                }

                MessageBox.Show($"Xuất báo cáo thành công!\n\nĐường dẫn: {filePath}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Mở file Excel
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
