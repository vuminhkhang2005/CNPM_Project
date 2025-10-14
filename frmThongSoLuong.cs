using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CNPM_Project
{
    public partial class frmThongSoLuong : Form
    {
        string connectionString = @"Data Source=DESKTOP-MJLB0BP\SQLEXPRESS;Initial Catalog=NhaThuocDB;Integrated Security=True;TrustServerCertificate=True";

        public frmThongSoLuong()
        {
            InitializeComponent();
        }

        private void frmThongSoLuong_Load(object sender, EventArgs e)
        {
            LoadThongSoLuong();
        }

        // Load dữ liệu thông số lương hiện tại
        private void LoadThongSoLuong()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Lấy thông số lương mới nhất
                    string query = @"SELECT TOP 1 * FROM ThongSoLuong ORDER BY NgayApDung DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtHeSoLuong.Text = reader["HeSoLuongCoBan"].ToString();
                        txtPhuCapChucVu.Text = reader["PhuCapChucVu"].ToString();
                        txtTyLeBHXH.Text = reader["TyLeBHXH"].ToString();
                        txtTyLeBHYT.Text = reader["TyLeBHYT"].ToString();
                        txtTyLeBHTN.Text = reader["TyLeBHTN"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Chưa có thông số lương trong hệ thống!", "Thông báo");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông số lương: " + ex.Message, "Lỗi");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(txtHeSoLuong.Text) ||
                    string.IsNullOrWhiteSpace(txtTyLeBHXH.Text) ||
                    string.IsNullOrWhiteSpace(txtTyLeBHYT.Text) ||
                    string.IsNullOrWhiteSpace(txtTyLeBHTN.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo");
                    return;
                }

                decimal heSoLuong = decimal.Parse(txtHeSoLuong.Text);
                decimal phuCap = string.IsNullOrWhiteSpace(txtPhuCapChucVu.Text) ? 0 : decimal.Parse(txtPhuCapChucVu.Text);
                decimal tyLeBHXH = decimal.Parse(txtTyLeBHXH.Text);
                decimal tyLeBHYT = decimal.Parse(txtTyLeBHYT.Text);
                decimal tyLeBHTN = decimal.Parse(txtTyLeBHTN.Text);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO ThongSoLuong 
                                    (HeSoLuongCoBan, PhuCapChucVu, TyLeBHXH, TyLeBHYT, TyLeBHTN, NgayApDung) 
                                    VALUES (@HeSo, @PhuCap, @BHXH, @BHYT, @BHTN, @NgayApDung)";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HeSo", heSoLuong);
                    cmd.Parameters.AddWithValue("@PhuCap", phuCap);
                    cmd.Parameters.AddWithValue("@BHXH", tyLeBHXH);
                    cmd.Parameters.AddWithValue("@BHYT", tyLeBHYT);
                    cmd.Parameters.AddWithValue("@BHTN", tyLeBHTN);
                    cmd.Parameters.AddWithValue("@NgayApDung", dtpNgayApDung.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông số bảng lương thành công!", "Thành công");
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số!", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông số lương: " + ex.Message, "Lỗi");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
