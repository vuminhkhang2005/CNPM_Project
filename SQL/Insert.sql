-- Chèn dữ liệu mẫu
USE NhaThuocDB;
GO

-- 1. Thêm tài khoản: 1 Kế toán và 2 Nhân viên
-- Lưu ý: Trong thực tế, mật khẩu phải được mã hóa (hashed)
INSERT INTO Taikhoan (Hovaten, Sodienthoai, Matkhau, Ngaysinh, Chucvu) VALUES
(N'Nguyễn Văn An', '0901112222', 'ketoan123', '1990-05-15', N'Kế toán'),
(N'Trần Thị Bình', '0903334444', 'nhanvien123', '1995-08-20', N'Nhân viên'),
(N'Lê Minh Cường', '0905556666', 'nhanvien456', '1998-01-10', N'Nhân viên');
GO

-- 2. Thêm khách hàng
INSERT INTO Thongtinkhachhang (Sodienthoai, Hovaten, Diemtichluy, Manhanvien) VALUES
('0987654321', N'Phạm Thị Dung', 50, 2);
GO

-- 3. Thêm Nhóm thuốc và Loại thuốc
INSERT INTO NhomThuoc (TenNhom, MoTa) VALUES (N'Thuốc giảm đau', N'Các loại thuốc dùng để giảm đau');
INSERT INTO LoaiThuoc (TenLoai, MoTa, MaNhom) VALUES (N'Giảm đau, hạ sốt', N'Thuốc không kê đơn', 1);
GO

-- 4. Thêm sản phẩm thuốc
INSERT INTO Sanphamthuoc (MaLoai, Tenhang, Soluong, Gianhap, Giaban, Ngayhethan) VALUES
(1, N'Paracetamol 500mg', 100, 800.00, 1000.00, '2027-10-01'),
(1, N'Panadol Extra', 50, 1200.00, 1500.00, '2026-12-15');
GO

-- 5. Thêm nhà cung cấp
INSERT INTO NhaCungCap (TenNhaCungCap, SoDienThoai, DiaChi) VALUES
(N'Công ty Dược Hậu Giang', '02923891433', N'288 Bis Nguyễn Văn Cừ, An Hòa, Ninh Kiều, Cần Thơ'),
(N'Công ty cổ phần Traphaco', '18006612', N'75 Yên Ninh, Ba Đình, Hà Nội');
GO

-- 6. Thêm thông số lương (áp dụng từ đầu năm)
INSERT INTO ThongSoLuong (HeSoLuongCoBan, TyLeBHXH, TyLeBHYT, TyLeBHTN, NgayApDung) VALUES
(4500000.00, 8.0, 1.5, 1.0, '2025-01-01');
GO

-- 7. Thêm một phiếu nhập hàng do Kế toán tạo
-- Giả sử Kế toán có Manguoidung = 1
INSERT INTO PhieuNhapHang (MaNhaCungCap, MaNguoiTao, TongTien) VALUES (1, 1, 140000.00);
GO
-- Thêm chi tiết cho phiếu nhập hàng vừa tạo (MaPhieuNhap = 1)
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSanPham, SoLuongNhap, DonGiaNhap) VALUES
(1, 1, 100, 800.00),  -- 100 hộp Paracetamol
(1, 2, 50, 1200.00); -- 50 hộp Panadol
GO

-- 8. Thêm một bản ghi lương cho nhân viên Trần Thị Bình cho tháng 9/2025
-- Giả sử MaNhanVien của Bình là 2
INSERT INTO BangLuong (MaNhanVien, Thang, Nam, SoNgayCongThucTe, LuongCoBan, KhauTruBaoHiem, ThucLinh) VALUES
(2, 9, 2025, 24, 4500000.00, 472500.00, 4027500.00); -- Lương đã tính toán trước
GO

-- 9. Thêm công nợ: 1 từ khách hàng, 1 cho nhà cung cấp
-- Giả sử Kế toán có Manguoidung = 1
-- Khách hàng '0987654321' nợ tiền thuốc
INSERT INTO CongNo (LoaiDoiTuong, MaDoiTuong, SoTienNo, NgayPhatSinh, LyDo, MaNguoiTao) VALUES
('KhachHang', '0987654321', 150000.00, '2025-10-10', N'Mua thuốc chưa trả tiền', 1);
-- Nợ tiền nhập hàng từ nhà cung cấp Dược Hậu Giang (MaNhaCungCap = 1)
INSERT INTO CongNo (LoaiDoiTuong, MaDoiTuong, SoTienNo, NgayPhatSinh, LyDo, MaNguoiTao) VALUES
('NhaCungCap', '1', 5000000.00, '2025-10-05', N'Tiền hàng đợt 1', 1);
GO