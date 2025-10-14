using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CNPM_Project
{
    public partial class frmThongSoLuong : Form
    {
        string connectionString = @"Data Source=DESKTOP-MJLB0BP\SQLEXPRESS;Initial Catalog=NhaThuocDB;Integrated Security=True;TrustServerCertificate=True";
        private int selectedID = -1; // Lưu ID đang chọn

        public frmThongSoLuong()
        {
            InitializeComponent();
        }

        private void frmThongSoLuong_Load(object sender, EventArgs e)
        {
            LoadChucVuToComboBox();
            LoadThongSoLuongToGrid();
            numThang.Value = DateTime.Now.Month;
            numNam.Value = DateTime.Now.Year;
        }

        private void LoadChucVuToComboBox()
        {
            try
            {
                cboChucVu.Items.Clear();
                cboChucVu.Items.Add("-- Chọn chức vụ --");
                cboChucVu.Items.Add("Quản lý");
                cboChucVu.Items.Add("Kế toán");
                cboChucVu.Items.Add("Nhân viên bán hàng");
                cboChucVu.Items.Add("Nhân viên kho");
                cboChucVu.Items.Add("Nhân viên chăm sóc khách hàng");
                cboChucVu.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chức vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThongSoLuongToGrid()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT ID, ChucVu, HeSoLuongCoBan, PhuCapChucVu, 
                                   TyLeBHXH, TyLeBHYT, TyLeBHTN, Thang, Nam 
                                   FROM ThongSoLuong 
                                   ORDER BY Nam DESC, Thang DESC, ChucVu";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvThongSoLuong.DataSource = dt;

                    if (dgvThongSoLuong.Columns.Count > 0)
                    {
                        // Ẩn cột ID
                        dgvThongSoLuong.Columns["ID"].Visible = false;
                        
                        // Đặt tên cột
                        dgvThongSoLuong.Columns["ChucVu"].HeaderText = "Chức vụ";
                        dgvThongSoLuong.Columns["HeSoLuongCoBan"].HeaderText = "Hệ số lương";
                        dgvThongSoLuong.Columns["PhuCapChucVu"].HeaderText = "Phụ cấp";
                        dgvThongSoLuong.Columns["TyLeBHXH"].HeaderText = "BHXH (%)";
                        dgvThongSoLuong.Columns["TyLeBHYT"].HeaderText = "BHYT (%)";
                        dgvThongSoLuong.Columns["TyLeBHTN"].HeaderText = "BHTN (%)";
                        dgvThongSoLuong.Columns["Thang"].HeaderText = "Tháng";
                        dgvThongSoLuong.Columns["Nam"].HeaderText = "Năm";

                        // Định dạng tiền tệ
                        dgvThongSoLuong.Columns["HeSoLuongCoBan"].DefaultCellStyle.Format = "N0";
                        dgvThongSoLuong.Columns["PhuCapChucVu"].DefaultCellStyle.Format = "N0";

                        // Thiết lập độ rộng cột
                        dgvThongSoLuong.Columns["ChucVu"].Width = 180;
                        dgvThongSoLuong.Columns["Thang"].Width = 60;
                        dgvThongSoLuong.Columns["Nam"].Width = 60;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thông số lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                string chucVu = cboChucVu.SelectedItem.ToString();
                int thang = Convert.ToInt32(numThang.Value);
                int nam = Convert.ToInt32(numNam.Value);
                decimal heSoLuong = decimal.Parse(txtHeSoLuong.Text);
                decimal phuCap = string.IsNullOrWhiteSpace(txtPhuCapChucVu.Text) ? 0 : decimal.Parse(txtPhuCapChucVu.Text);
                decimal tyLeBHXH = decimal.Parse(txtTyLeBHXH.Text);
                decimal tyLeBHYT = decimal.Parse(txtTyLeBHYT.Text);
                decimal tyLeBHTN = decimal.Parse(txtTyLeBHTN.Text);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Kiểm tra trùng lặp
                    string checkQuery = "SELECT COUNT(*) FROM ThongSoLuong WHERE ChucVu = @ChucVu AND Thang = @Thang AND Nam = @Nam";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@ChucVu", chucVu);
                    checkCmd.Parameters.AddWithValue("@Thang", thang);
                    checkCmd.Parameters.AddWithValue("@Nam", nam);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show($"Thông số lương cho chức vụ '{chucVu}' trong tháng {thang}/{nam} đã tồn tại!", 
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = @"INSERT INTO ThongSoLuong 
                                    (ChucVu, HeSoLuongCoBan, PhuCapChucVu, TyLeBHXH, TyLeBHYT, TyLeBHTN, Thang, Nam) 
                                    VALUES (@ChucVu, @HeSo, @PhuCap, @BHXH, @BHYT, @BHTN, @Thang, @Nam)";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ChucVu", chucVu);
                    cmd.Parameters.AddWithValue("@HeSo", heSoLuong);
                    cmd.Parameters.AddWithValue("@PhuCap", phuCap);
                    cmd.Parameters.AddWithValue("@BHXH", tyLeBHXH);
                    cmd.Parameters.AddWithValue("@BHYT", tyLeBHYT);
                    cmd.Parameters.AddWithValue("@BHTN", tyLeBHTN);
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thông số lương thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    LoadThongSoLuongToGrid();
                    ClearInput();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm thông số lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedID < 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi từ bảng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                string chucVu = cboChucVu.SelectedItem.ToString();
                int thang = Convert.ToInt32(numThang.Value);
                int nam = Convert.ToInt32(numNam.Value);
                decimal heSoLuong = decimal.Parse(txtHeSoLuong.Text);
                decimal phuCap = string.IsNullOrWhiteSpace(txtPhuCapChucVu.Text) ? 0 : decimal.Parse(txtPhuCapChucVu.Text);
                decimal tyLeBHXH = decimal.Parse(txtTyLeBHXH.Text);
                decimal tyLeBHYT = decimal.Parse(txtTyLeBHYT.Text);
                decimal tyLeBHTN = decimal.Parse(txtTyLeBHTN.Text);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Kiểm tra trùng lặp (trừ bản ghi đang sửa)
                    string checkQuery = @"SELECT COUNT(*) FROM ThongSoLuong 
                                        WHERE ChucVu = @ChucVu AND Thang = @Thang AND Nam = @Nam AND ID != @ID";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@ChucVu", chucVu);
                    checkCmd.Parameters.AddWithValue("@Thang", thang);
                    checkCmd.Parameters.AddWithValue("@Nam", nam);
                    checkCmd.Parameters.AddWithValue("@ID", selectedID);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show($"Thông số lương cho chức vụ '{chucVu}' trong tháng {thang}/{nam} đã tồn tại!", 
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = @"UPDATE ThongSoLuong 
                                   SET ChucVu = @ChucVu, 
                                       HeSoLuongCoBan = @HeSo, 
                                       PhuCapChucVu = @PhuCap, 
                                       TyLeBHXH = @BHXH, 
                                       TyLeBHYT = @BHYT, 
                                       TyLeBHTN = @BHTN, 
                                       Thang = @Thang, 
                                       Nam = @Nam 
                                   WHERE ID = @ID";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ChucVu", chucVu);
                    cmd.Parameters.AddWithValue("@HeSo", heSoLuong);
                    cmd.Parameters.AddWithValue("@PhuCap", phuCap);
                    cmd.Parameters.AddWithValue("@BHXH", tyLeBHXH);
                    cmd.Parameters.AddWithValue("@BHYT", tyLeBHYT);
                    cmd.Parameters.AddWithValue("@BHTN", tyLeBHTN);
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    cmd.Parameters.AddWithValue("@ID", selectedID);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông số lương thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    LoadThongSoLuongToGrid();
                    ClearInput();
                    selectedID = -1;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông số lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedID < 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi từ bảng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông số lương này?\n\nLưu ý: Việc xóa có thể ảnh hưởng đến tính lương của nhân viên!", 
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM ThongSoLuong WHERE ID = @ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", selectedID);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Xóa thông số lương thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadThongSoLuongToGrid();
                        ClearInput();
                        selectedID = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa thông số lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadThongSoLuongToGrid();
            ClearInput();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvThongSoLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvThongSoLuong.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                try
                {
                    DataGridViewRow row = dgvThongSoLuong.Rows[e.RowIndex];
                    
                    selectedID = Convert.ToInt32(row.Cells["ID"].Value);
                    
                    // Điền dữ liệu vào form
                    cboChucVu.SelectedItem = row.Cells["ChucVu"].Value.ToString();
                    numThang.Value = Convert.ToInt32(row.Cells["Thang"].Value);
                    numNam.Value = Convert.ToInt32(row.Cells["Nam"].Value);
                    txtHeSoLuong.Text = row.Cells["HeSoLuongCoBan"].Value.ToString();
                    txtPhuCapChucVu.Text = row.Cells["PhuCapChucVu"].Value.ToString();
                    txtTyLeBHXH.Text = row.Cells["TyLeBHXH"].Value.ToString();
                    txtTyLeBHYT.Text = row.Cells["TyLeBHYT"].Value.ToString();
                    txtTyLeBHTN.Text = row.Cells["TyLeBHTN"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn bản ghi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInput()
        {
            if (cboChucVu.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn chức vụ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucVu.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHeSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập hệ số lương cơ bản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHeSoLuong.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTyLeBHXH.Text) ||
                string.IsNullOrWhiteSpace(txtTyLeBHYT.Text) ||
                string.IsNullOrWhiteSpace(txtTyLeBHTN.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tỷ lệ bảo hiểm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearInput()
        {
            cboChucVu.SelectedIndex = 0;
            txtHeSoLuong.Clear();
            txtPhuCapChucVu.Text = "0";
            txtTyLeBHXH.Clear();
            txtTyLeBHYT.Clear();
            txtTyLeBHTN.Clear();
            numThang.Value = DateTime.Now.Month;
            numNam.Value = DateTime.Now.Year;
            selectedID = -1;
        }
    }
}
