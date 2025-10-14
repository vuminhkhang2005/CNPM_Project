using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CNPM_Project
{
    public partial class frmThemCongNo : Form
    {
        string connectionString = @"Data Source=DESKTOP-MJLB0BP\SQLEXPRESS;Initial Catalog=NhaThuocDB;Integrated Security=True;TrustServerCertificate=True";
        int maNguoiDung; // Mã kế toán đang đăng nhập

        public frmThemCongNo(int maNguoiDung)
        {
            InitializeComponent();
            this.maNguoiDung = maNguoiDung;
        }

        private void frmThemCongNo_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho loại đối tượng
            cboLoaiDoiTuong.Items.Add("KhachHang");
            cboLoaiDoiTuong.Items.Add("NhaCungCap");
            cboLoaiDoiTuong.SelectedIndex = 0;

            // Load danh sách khách hàng và nhà cung cấp
            LoadDoiTuong();
        }

        private void LoadDoiTuong()
        {
            string loaiDoiTuong = cboLoaiDoiTuong.SelectedItem?.ToString();
            
            if (string.IsNullOrEmpty(loaiDoiTuong))
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "";
                    
                    if (loaiDoiTuong == "KhachHang")
                    {
                        query = "SELECT Sodienthoai, Hovaten FROM Thongtinkhachhang";
                    }
                    else // NhaCungCap
                    {
                        query = "SELECT CAST(MaNhaCungCap AS NVARCHAR) AS MaNhaCungCap, TenNhaCungCap FROM NhaCungCap";
                    }

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboDoiTuong.DataSource = dt;
                    if (loaiDoiTuong == "KhachHang")
                    {
                        cboDoiTuong.DisplayMember = "Hovaten";
                        cboDoiTuong.ValueMember = "Sodienthoai";
                    }
                    else
                    {
                        cboDoiTuong.DisplayMember = "TenNhaCungCap";
                        cboDoiTuong.ValueMember = "MaNhaCungCap";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách: " + ex.Message, "Lỗi");
            }
        }

        private void cboLoaiDoiTuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDoiTuong();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate dữ liệu
                if (cboLoaiDoiTuong.SelectedItem == null || cboDoiTuong.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Cảnh báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSoTien.Text))
                {
                    MessageBox.Show("Vui lòng nhập số tiền nợ!", "Cảnh báo");
                    return;
                }

                string loaiDoiTuong = cboLoaiDoiTuong.SelectedItem.ToString();
                string maDoiTuong = cboDoiTuong.SelectedValue.ToString();
                decimal soTienNo = decimal.Parse(txtSoTien.Text);
                DateTime ngayPhatSinh = dtpNgayPhatSinh.Value;
                string lyDo = txtLyDo.Text;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO CongNo 
                                    (LoaiDoiTuong, MaDoiTuong, SoTienNo, NgayPhatSinh, LyDo, MaNguoiTao) 
                                    VALUES (@LoaiDoiTuong, @MaDoiTuong, @SoTienNo, @NgayPhatSinh, @LyDo, @MaNguoiTao)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LoaiDoiTuong", loaiDoiTuong);
                    cmd.Parameters.AddWithValue("@MaDoiTuong", maDoiTuong);
                    cmd.Parameters.AddWithValue("@SoTienNo", soTienNo);
                    cmd.Parameters.AddWithValue("@NgayPhatSinh", ngayPhatSinh);
                    cmd.Parameters.AddWithValue("@LyDo", string.IsNullOrWhiteSpace(lyDo) ? DBNull.Value : (object)lyDo);
                    cmd.Parameters.AddWithValue("@MaNguoiTao", maNguoiDung);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm công nợ thành công!", "Thành công");
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Số tiền phải là số hợp lệ!", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm công nợ: " + ex.Message, "Lỗi");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
