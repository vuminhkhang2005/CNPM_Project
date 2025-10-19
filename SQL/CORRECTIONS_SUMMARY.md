# Tóm tắt các sửa đổi trong SQL - Corrections Summary

## Vấn đề chính / Main Issues

Code SQL gốc của bạn sử dụng **chuỗi văn bản (NVARCHAR)** cho các ID nhân viên, nhưng database schema định nghĩa `Manguoidung` trong bảng `Taikhoan` là kiểu **INT IDENTITY(1,1)**.

Your original SQL code used **text strings (NVARCHAR)** for employee IDs, but the database schema defines `Manguoidung` in the `Taikhoan` table as **INT IDENTITY(1,1)** type.

---

## Chi tiết sửa đổi / Detailed Corrections

### 1. Bảng PhieuNhapHang (Import Receipts)

**Trước (Sai):**
```sql
INSERT INTO PhieuNhapHang (MaNhaCungCap, MaNguoiTao, NgayNhap, TongTien) VALUES
(1, N'NhanVienKho_0123456789', '2025-09-01 10:00:00', 5000000),
...
```

**Sau (Đúng):**
```sql
INSERT INTO PhieuNhapHang (MaNhaCungCap, MaNguoiTao, NgayNhap, TongTien) VALUES
(1, 7, '2025-09-01 10:00:00', 5000000),  -- 7 = Đặng Minh Long (Nhân viên kho)
...
```

### 2. Bảng BangLuong (Salary Table)

**Trước (Sai):**
```sql
INSERT INTO BangLuong (MaNhanVien, Thang, Nam, ...) VALUES
(N'KeToan_0918273645', 9, 2025, ...),
(N'NV001', 9, 2025, ...),
...
```

**Sau (Đúng):**
```sql
INSERT INTO BangLuong (MaNhanVien, Thang, Nam, ...) VALUES
(6, 9, 2025, ...),  -- 6 = Vũ Thị Hà (Kế toán)
(5, 9, 2025, ...),  -- 5 = Hoàng Văn Em (Nhân viên bán hàng)
...
```

### 3. Bảng CongNo (Debt Table)

**Trước (Sai):**
```sql
INSERT INTO CongNo (..., MaNguoiTao) VALUES
(..., N'KeToan_0918273645'),
(..., N'QuanLy_0799513501'),
...
```

**Sau (Đúng):**
```sql
INSERT INTO CongNo (..., MaNguoiTao) VALUES
(..., 6),  -- 6 = Vũ Thị Hà (Kế toán)
(..., 1),  -- 1 = Nguyễn Văn An (Quản lý)
...
```

---

## Mapping ID nhân viên / Employee ID Mapping

Dựa vào file `Insert.sql` gốc, đây là danh sách nhân viên với ID số:

| ID | Họ và Tên | Chức vụ |
|----|-----------|---------|
| 1 | Nguyễn Văn An | Quản lý |
| 2 | Trần Thị Bích | Nhân viên chăm sóc khách hàng |
| 3 | Lê Minh Cường | Nhân viên kho |
| 4 | Phạm Thị Dung | Nhân viên bán hàng |
| 5 | Hoàng Văn Em | Nhân viên bán hàng |
| 6 | Vũ Thị Hà | Kế toán |
| 7 | Đặng Minh Long | Nhân viên kho |
| 8 | Bùi Thị Kiều | Nhân viên bán hàng |
| 9 | Ngô Tuấn Anh | Nhân viên chăm sóc khách hàng |
| 10 | Đỗ Phương Thảo | Kế toán |

---

## Cách sử dụng / How to Use

1. Chạy file `CreateTable.sql` trước để tạo database structure
2. Chạy file `Insert.sql` gốc để insert dữ liệu cơ bản (bảng 1-8)
3. Chạy file `Insert_Corrected.sql` để insert dữ liệu phần kế toán (bảng 9-14)

**Lưu ý:** File `Insert_Corrected.sql` đã được sửa để phù hợp với schema database INT-based IDs.

---

## Tại sao lỗi? / Why the Error?

Foreign key constraints yêu cầu kiểu dữ liệu phải khớp:
- `PhieuNhapHang.MaNguoiTao` → `Taikhoan.Manguoidung` (INT)
- `BangLuong.MaNhanVien` → `Taikhoan.Manguoidung` (INT)
- `CongNo.MaNguoiTao` → `Taikhoan.Manguoidung` (INT)

Không thể dùng chuỗi `N'KeToan_0918273645'` khi foreign key mong đợi số nguyên `6`.

Foreign key constraints require matching data types. You cannot use string `N'KeToan_0918273645'` when the foreign key expects integer `6`.
