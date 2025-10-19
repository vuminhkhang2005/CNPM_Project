# THAY ĐỔI SCHEMA DATABASE - MANGUOIDUNG

## Tổng quan
Database đã được cập nhật để thay đổi cấu trúc bảng `Taikhoan`:
- **TRƯỚC**: `Manguoidung INT PRIMARY KEY IDENTITY(1,1)` (số tự động tăng)
- **SAU**: `Manguoidung NVARCHAR(255) PRIMARY KEY` (chuỗi định danh như 'KeToan_0918273645', 'NhanVienKho_0123456789')

## Các thay đổi trong Database (SQL)

### 1. Bảng Taikhoan
```sql
-- CŨ:
Manguoidung INT PRIMARY KEY IDENTITY(1,1)

-- MỚI:
Manguoidung NVARCHAR(255) PRIMARY KEY
```

### 2. Các bảng có khóa ngoại tới Taikhoan
Tất cả các cột khóa ngoại tham chiếu đến `Taikhoan.Manguoidung` đã được đổi từ `INT` sang `NVARCHAR(255)`:

- **Thongtinkhachhang.Manhanvien**: INT → NVARCHAR(255)
- **Phanhoikhachhang.Manhanvien**: INT → NVARCHAR(255)
- **PhieuNhapHang.MaNguoiTao**: INT → NVARCHAR(255)
- **BangLuong.MaNhanVien**: INT → NVARCHAR(255)
- **CongNo.MaNguoiTao**: INT → NVARCHAR(255)

### 3. Dữ liệu mẫu mới
Các tài khoản trong dữ liệu INSERT:
```sql
('KeToan_0918273645', 'Vũ Minh Khang', '0918273645', '123', '2004-05-26', 'Kế toán')
('NV001', 'Nhân viên mặc định', '0000000000', '123456', NULL, 'Nhân viên bán hàng')
('NhanVienBanHang_0987654321', 'Lê Thị Thảo', '0987654321', '123', '2002-04-17', 'Nhân viên bán hàng')
('NhanVienChamSocKhachHang_0192837465', 'Huỳnh Hoài Phương', '0192837465', '123', '2004-08-17', 'Nhân viên chăm sóc khách hàng')
('NhanVienKho_0123456789', 'Huỳnh Thanh Nhân', '0123456789', '123', '2001-03-19', 'Nhân viên kho')
('Nhân viên chăm sóc khách hàng_0344969876', 'Huỳnh Hoài Phương', '0344969876', '1234', '1991-02-08', 'Nhân viên chăm sóc khách hàng')
('QuanLy_0799513501', 'Lê Vũ Hải', '0799513501', '123', '2005-03-03', 'Quản lý')
```

## Các thay đổi trong Code C#

### 1. frmQuanLyBangLuongMoi.cs
**Thay đổi:**
- `int maNhanVien` → `string maNhanVien`
- Hàm `LoadBangLuongToGrid(int? maNhanVien)` → `LoadBangLuongToGrid(string maNhanVien)`
- Hàm `TinhLuong(int maNhanVien, ...)` → `TinhLuong(string maNhanVien, ...)`
- ComboBox default value: `-1` → `""` (empty string)
- Các điều kiện kiểm tra: `maNhanVien > 0` → `!string.IsNullOrEmpty(maNhanVien)`

### 2. frmThemCongNo.cs
**Thay đổi:**
- `int maNguoiDung` → `string maNguoiDung`
- Constructor: `frmThemCongNo(int maNguoiDung)` → `frmThemCongNo(string maNguoiDung)`

### 3. frmMenuChinh.cs
**Thay đổi:**
- `private int maNguoiDung = 1` → `private string maNguoiDung = "KeToan_0918273645"`
- Constructor: `frmMenuChinh(int maNguoiDung)` → `frmMenuChinh(string maNguoiDung)`

### 4. frmChiPhiBanHang.cs
**Thay đổi:**
- Xóa CAST trong query JOIN: `CAST(TK.Manguoidung AS NVARCHAR)` → `TK.Manguoidung`

### 5. frmChiPhiNhapHang.cs
**Không cần thay đổi** - chỉ hiển thị dữ liệu từ JOIN

### 6. frmXoaCongNo.cs
**Không cần thay đổi** - không sử dụng MaNguoiTao

## Các file đã được cập nhật

### SQL Files:
1. ✅ `/workspace/SQL/CreateTable.sql` - Schema mới
2. ✅ `/workspace/SQL/Insert.sql` - Dữ liệu mới với string IDs

### C# Files:
1. ✅ `/workspace/frmQuanLyBangLuongMoi.cs`
2. ✅ `/workspace/frmThemCongNo.cs`
3. ✅ `/workspace/frmMenuChinh.cs`
4. ✅ `/workspace/frmChiPhiBanHang.cs`

## Hướng dẫn sử dụng

### 1. Tạo lại Database
```sql
-- Chạy file CreateTable.sql để tạo schema mới
-- Chạy file Insert.sql để thêm dữ liệu mẫu
```

### 2. Build lại project C#
- Mở solution trong Visual Studio
- Build solution (F6)
- Chạy ứng dụng (F5)

### 3. Kiểm tra
- Mở form Quản lý bảng lương: Combobox nhân viên hiển thị đúng
- Thêm bảng lương mới: Dữ liệu được lưu với MaNhanVien là string
- Xem báo cáo chi phí nhập hàng/bán hàng: Dữ liệu hiển thị đúng

## Lưu ý
- ⚠️ Database cũ sẽ không tương thích với code mới
- ⚠️ Phải chạy lại CreateTable.sql và Insert.sql để tạo database hoàn toàn mới
- ⚠️ Connection string vẫn giữ nguyên: `Data Source=DESKTOP-MJLB0BP\SQLEXPRESS;Initial Catalog=NhaThuocDB`
