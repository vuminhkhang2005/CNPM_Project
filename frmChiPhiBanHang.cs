using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
                        INNER JOIN Taikhoan AS TK ON DH.Manhanvien = CAST(TK.Manguoidung AS NVARCHAR)
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
            // Tính năng xuất báo cáo (có thể xuất Excel, PDF...)
            MessageBox.Show("Chức năng xuất báo cáo đang được phát triển!", "Thông báo");
            
            // TODO: Implement export to Excel/PDF
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
