using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;

namespace CNPM_Project
{
    public partial class frmChiPhiBanHang : Form
    {
        string connectionString = @"Data Source=DESKTOP-MJLB0BP\SQLEXPRESS;Initial Catalog=NhaThuocDB;Integrated Security=True;TrustServerCertificate=True";

        public frmChiPhiBanHang()
        {
            InitializeComponent();
        }

        private void frmChiPhiBanHang_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho ngày
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // Đầu tháng
            dtpDenNgay.Value = DateTime.Now; // Hôm nay
            
            LoadChiPhiBanHang();
        }

        private void LoadChiPhiBanHang()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Query để lấy thông tin đơn hàng và chi phí bán
                    string query = @"
                        SELECT 
                            DH.Madonhang,
                            DH.Ngaytaodon,
                            KH.Hovaten AS TenKhachHang,
                            KH.Sodienthoai,
                            TK.Hovaten AS NhanVienBan,
                            SUM(CTDH.Tongtiensanpham) AS DoanhThu,
                            SUM(CTDH.Soluong * SP.Gianhap) AS GiaVon,
                            SUM(CTDH.Tongtiensanpham) - SUM(CTDH.Soluong * SP.Gianhap) AS LoiNhuan
                        FROM Donhang AS DH
                        INNER JOIN Thongtinkhachhang AS KH ON DH.Sodienthoaikhachhang = KH.Sodienthoai
                        INNER JOIN Taikhoan AS TK ON DH.Manhanvien = TK.Manguoidung
                        INNER JOIN Chitietdonhang AS CTDH ON DH.Madonhang = CTDH.Madonhang
                        INNER JOIN Sanphamthuoc AS SP ON CTDH.Masanpham = SP.ID
                        WHERE DH.Ngaytaodon BETWEEN @TuNgay AND @DenNgay
                        GROUP BY DH.Madonhang, DH.Ngaytaodon, KH.Hovaten, KH.Sodienthoai, TK.Hovaten
                        ORDER BY DH.Ngaytaodon DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                    da.SelectCommand.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));
                    
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvDonHang.DataSource = dt;

                    // Tùy chỉnh tên cột
                    if (dgvDonHang.Columns.Count > 0)
                    {
                        dgvDonHang.Columns["Madonhang"].HeaderText = "Mã ĐH";
                        dgvDonHang.Columns["Ngaytaodon"].HeaderText = "Ngày bán";
                        dgvDonHang.Columns["TenKhachHang"].HeaderText = "Khách hàng";
                        dgvDonHang.Columns["Sodienthoai"].HeaderText = "SĐT";
                        dgvDonHang.Columns["NhanVienBan"].HeaderText = "NV bán";
                        dgvDonHang.Columns["DoanhThu"].HeaderText = "Doanh thu";
                        dgvDonHang.Columns["GiaVon"].HeaderText = "Giá vốn";
                        dgvDonHang.Columns["LoiNhuan"].HeaderText = "Lợi nhuận";

                        // Định dạng tiền tệ
                        dgvDonHang.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
                        dgvDonHang.Columns["GiaVon"].DefaultCellStyle.Format = "N0";
                        dgvDonHang.Columns["LoiNhuan"].DefaultCellStyle.Format = "N0";
                        
                        // Định dạng ngày
                        dgvDonHang.Columns["Ngaytaodon"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                        // Màu cho cột lợi nhuận (xanh nếu > 0, đỏ nếu < 0)
                        dgvDonHang.Columns["LoiNhuan"].DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
                    }

                    // Tính tổng chi phí
                    decimal tongDoanhThu = 0;
                    decimal tongGiaVon = 0;
                    decimal tongLoiNhuan = 0;
                    
                    foreach (DataRow row in dt.Rows)
                    {
                        tongDoanhThu += Convert.ToDecimal(row["DoanhThu"]);
                        tongGiaVon += Convert.ToDecimal(row["GiaVon"]);
                        tongLoiNhuan += Convert.ToDecimal(row["LoiNhuan"]);
                    }
                    
                    lblTongDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu:N0} VNĐ";
                    lblTongGiaVon.Text = $"Tổng giá vốn: {tongGiaVon:N0} VNĐ";
                    lblTongLoiNhuan.Text = $"Tổng lợi nhuận: {tongLoiNhuan:N0} VNĐ";
                    
                    // Tính tỷ lệ lợi nhuận
                    if (tongDoanhThu > 0)
                    {
                        decimal tyLeLoiNhuan = (tongLoiNhuan / tongDoanhThu) * 100;
                        lblTyLeLoiNhuan.Text = $"Tỷ lệ lợi nhuận: {tyLeLoiNhuan:F2}%";
                    }
                    else
                    {
                        lblTyLeLoiNhuan.Text = "Tỷ lệ lợi nhuận: 0%";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi phí bán hàng: " + ex.Message, "Lỗi");
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadChiPhiBanHang();
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDonHang.Rows.Count == 0)
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

                // Tạo tên file với định dạng ddMMyyyy_ChiPhiBanHang
                string fileName = DateTime.Now.ToString("ddMMyyyy") + "_ChiPhiBanHang.xlsx";
                string filePath = Path.Combine(reportFolder, fileName);

                // Tạo workbook mới
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Chi phí bán hàng");

                    // Tiêu đề báo cáo
                    worksheet.Cell(1, 1).Value = "BÁO CÁO CHI PHÍ VÀ LỢI NHUẬN BÁN HÀNG";
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                    worksheet.Range(1, 1, 1, 8).Merge();
                    worksheet.Range(1, 1, 1, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Thời gian báo cáo
                    worksheet.Cell(2, 1).Value = $"Từ ngày: {dtpTuNgay.Value:dd/MM/yyyy} - Đến ngày: {dtpDenNgay.Value:dd/MM/yyyy}";
                    worksheet.Range(2, 1, 2, 8).Merge();
                    worksheet.Range(2, 1, 2, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Header
                    int headerRow = 4;
                    worksheet.Cell(headerRow, 1).Value = "Mã ĐH";
                    worksheet.Cell(headerRow, 2).Value = "Ngày bán";
                    worksheet.Cell(headerRow, 3).Value = "Khách hàng";
                    worksheet.Cell(headerRow, 4).Value = "SĐT";
                    worksheet.Cell(headerRow, 5).Value = "NV bán";
                    worksheet.Cell(headerRow, 6).Value = "Doanh thu (VNĐ)";
                    worksheet.Cell(headerRow, 7).Value = "Giá vốn (VNĐ)";
                    worksheet.Cell(headerRow, 8).Value = "Lợi nhuận (VNĐ)";

                    // Style cho header
                    var headerRange = worksheet.Range(headerRow, 1, headerRow, 8);
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Dữ liệu
                    DataTable dt = (DataTable)dgvDonHang.DataSource;
                    int currentRow = headerRow + 1;
                    decimal tongDoanhThu = 0;
                    decimal tongGiaVon = 0;
                    decimal tongLoiNhuan = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        worksheet.Cell(currentRow, 1).Value = row["Madonhang"].ToString();
                        worksheet.Cell(currentRow, 2).Value = Convert.ToDateTime(row["Ngaytaodon"]).ToString("dd/MM/yyyy HH:mm");
                        worksheet.Cell(currentRow, 3).Value = row["TenKhachHang"].ToString();
                        worksheet.Cell(currentRow, 4).Value = row["Sodienthoai"].ToString();
                        worksheet.Cell(currentRow, 5).Value = row["NhanVienBan"].ToString();
                        
                        decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                        decimal giaVon = Convert.ToDecimal(row["GiaVon"]);
                        decimal loiNhuan = Convert.ToDecimal(row["LoiNhuan"]);
                        
                        worksheet.Cell(currentRow, 6).Value = doanhThu;
                        worksheet.Cell(currentRow, 6).Style.NumberFormat.Format = "#,##0";
                        
                        worksheet.Cell(currentRow, 7).Value = giaVon;
                        worksheet.Cell(currentRow, 7).Style.NumberFormat.Format = "#,##0";
                        
                        worksheet.Cell(currentRow, 8).Value = loiNhuan;
                        worksheet.Cell(currentRow, 8).Style.NumberFormat.Format = "#,##0";
                        worksheet.Cell(currentRow, 8).Style.Font.FontColor = loiNhuan >= 0 ? XLColor.Green : XLColor.Red;
                        
                        tongDoanhThu += doanhThu;
                        tongGiaVon += giaVon;
                        tongLoiNhuan += loiNhuan;
                        currentRow++;
                    }

                    // Tổng cộng
                    int totalRow = currentRow;
                    worksheet.Cell(totalRow, 5).Value = "TỔNG CỘNG:";
                    worksheet.Cell(totalRow, 5).Style.Font.Bold = true;
                    
                    worksheet.Cell(totalRow, 6).Value = tongDoanhThu;
                    worksheet.Cell(totalRow, 6).Style.Font.Bold = true;
                    worksheet.Cell(totalRow, 6).Style.NumberFormat.Format = "#,##0";
                    worksheet.Cell(totalRow, 6).Style.Fill.BackgroundColor = XLColor.LightYellow;
                    
                    worksheet.Cell(totalRow, 7).Value = tongGiaVon;
                    worksheet.Cell(totalRow, 7).Style.Font.Bold = true;
                    worksheet.Cell(totalRow, 7).Style.NumberFormat.Format = "#,##0";
                    worksheet.Cell(totalRow, 7).Style.Fill.BackgroundColor = XLColor.LightYellow;
                    
                    worksheet.Cell(totalRow, 8).Value = tongLoiNhuan;
                    worksheet.Cell(totalRow, 8).Style.Font.Bold = true;
                    worksheet.Cell(totalRow, 8).Style.NumberFormat.Format = "#,##0";
                    worksheet.Cell(totalRow, 8).Style.Fill.BackgroundColor = XLColor.LightGreen;

                    // Tỷ lệ lợi nhuận
                    int ratioRow = totalRow + 2;
                    worksheet.Cell(ratioRow, 1).Value = "Tỷ lệ lợi nhuận:";
                    worksheet.Cell(ratioRow, 1).Style.Font.Bold = true;
                    if (tongDoanhThu > 0)
                    {
                        decimal tyLe = (tongLoiNhuan / tongDoanhThu) * 100;
                        worksheet.Cell(ratioRow, 2).Value = $"{tyLe:F2}%";
                        worksheet.Cell(ratioRow, 2).Style.Font.Bold = true;
                        worksheet.Cell(ratioRow, 2).Style.Font.FontColor = XLColor.Green;
                    }
                    else
                    {
                        worksheet.Cell(ratioRow, 2).Value = "0%";
                    }

                    // Border cho dữ liệu
                    var dataRange = worksheet.Range(headerRow, 1, totalRow, 8);
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

        private void dgvDonHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xem chi tiết đơn hàng khi double-click
            if (e.RowIndex >= 0)
            {
                int maDonHang = Convert.ToInt32(dgvDonHang.Rows[e.RowIndex].Cells["Madonhang"].Value);
                XemChiTietDonHang(maDonHang);
            }
        }

        private void XemChiTietDonHang(int maDonHang)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            SP.Tenhang,
                            CTDH.Soluong,
                            CTDH.DonGia AS GiaBan,
                            SP.Gianhap AS GiaVon,
                            CTDH.Tongtiensanpham AS ThanhTien,
                            (CTDH.Tongtiensanpham - (CTDH.Soluong * SP.Gianhap)) AS LoiNhuan
                        FROM Chitietdonhang AS CTDH
                        INNER JOIN Sanphamthuoc AS SP ON CTDH.Masanpham = SP.ID
                        WHERE CTDH.Madonhang = @MaDonHang";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaDonHang", maDonHang);
                    
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Hiển thị chi tiết trong MessageBox hoặc form mới
                    string details = $"Chi tiết đơn hàng #{maDonHang}:\n\n";
                    decimal tongLoiNhuan = 0;
                    
                    foreach (DataRow row in dt.Rows)
                    {
                        decimal loiNhuan = Convert.ToDecimal(row["LoiNhuan"]);
                        tongLoiNhuan += loiNhuan;
                        
                        details += $"- {row["Tenhang"]}\n";
                        details += $"  SL: {row["Soluong"]}, Giá bán: {Convert.ToDecimal(row["GiaBan"]):N0}, Giá vốn: {Convert.ToDecimal(row["GiaVon"]):N0}\n";
                        details += $"  Thành tiền: {Convert.ToDecimal(row["ThanhTien"]):N0}, Lợi nhuận: {loiNhuan:N0} VNĐ\n\n";
                    }
                    
                    details += $"Tổng lợi nhuận: {tongLoiNhuan:N0} VNĐ";

                    MessageBox.Show(details, "Chi tiết đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xem chi tiết: " + ex.Message, "Lỗi");
            }
        }
    }
}
