-- Sử dụng Database đã tạo
USE NhaThuocDB;
GO

-- ==============================================================
-- DỮ LIỆU MẪU ĐÃ SỬA - PHẦN KẾ TOÁN
-- ==============================================================

-- ================================
-- 9. Bảng Nhà cung cấp (NhaCungCap)
-- ================================
INSERT INTO NhaCungCap (TenNhaCungCap, SoDienThoai, DiaChi, Email) VALUES
(N'Công ty Cổ phần Dược Hậu Giang', '02923891433', N'288 Bis Nguyễn Văn Cừ, An Hòa, Ninh Kiều, Cần Thơ', 'dhgpharma@dhgpharma.com.vn'),
(N'Công ty Cổ phần Traphaco', '02436816063', N'75 Yên Ninh, Ba Đình, Hà Nội', 'info@traphaco.com.vn'),
(N'Công ty TNHH Sanofi-Aventis Việt Nam', '02838298526', N'10 Hàm Nghi, Bến Nghé, Quận 1, TP.HCM', 'contact.vn@sanofi.com'),
(N'Văn phòng đại diện GSK Pte Ltd', '02838235005', N'Tầng 20, Tòa nhà Bitexco, 2 Hải Triều, Bến Nghé, Quận 1, TP.HCM', 'gsk.vietnam@gsk.com'),
(N'Công ty Cổ phần Hóa Dược phẩm Mekophar', '02838650357', N'297/5 Lý Thường Kiệt, Phường 15, Quận 11, TP.HCM', 'info@mekophar.com.vn'),
(N'Công ty Cổ phần Dược phẩm OPC', '02838753719', N'1017 Hồng Bàng, Phường 12, Quận 6, TP.HCM', 'info@opcpharma.com'),
(N'Công ty Cổ phần Dược phẩm Imexpharm', '02773852154', N'4 Đường 30/4, Phường 1, TP. Cao Lãnh, Đồng Tháp', 'info@imexpharm.com'),
(N'Công ty TNHH Dược phẩm Vimedimex 2', '02437227563', N'246 Cống Quỳnh, Phạm Ngũ Lão, Quận 1, TP.HCM', 'contact@vimedimex.com.vn'),
(N'Công ty Cổ phần Pymepharco', '02573829165', N'166-170 Nguyễn Huệ, Phường 7, TP. Tuy Hòa, Phú Yên', 'pymepharco@pymepharco.com'),
(N'Công ty TNHH Dược phẩm Hisamitsu Việt Nam', '02513991080', N'Số 14-15, Đường 2A, KCN Biên Hòa 2, Đồng Nai', 'info@hisamitsu.vn');
GO

-- ================================
-- 10. Bảng Phiếu nhập hàng (PhieuNhapHang) - ĐÃ SỬA
-- MaNguoiTao: 
--   - 7 = Đặng Minh Long (Nhân viên kho)
--   - 3 = Lê Minh Cường (Nhân viên kho)
-- ================================
INSERT INTO PhieuNhapHang (MaNhaCungCap, MaNguoiTao, NgayNhap, TongTien) VALUES
(1, 7, '2025-09-01 10:00:00', 5000000),
(4, 7, '2025-09-02 11:30:00', 9500000),
(6, 7, '2025-09-05 14:00:00', 5400000),
(2, 7, '2025-09-06 09:00:00', 3300000),
(3, 7, '2025-09-10 16:20:00', 12000000),
(10, 7, '2025-09-12 15:00:00', 6500000),
(5, 7, '2025-09-15 10:45:00', 3500000),
(8, 7, '2025-09-18 08:30:00', 1500000),
(9, 7, '2025-09-20 13:00:00', 8400000),
(7, 7, '2025-09-22 11:00:00', 28000000);
GO

-- ================================
-- 11. Bảng Chi tiết phiếu nhập (ChiTietPhieuNhap) - CHẠY NGAY SAU BLOCK 10
-- ================================
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSanPham, SoLuongNhap, DonGiaNhap) VALUES
(1, 1, 200, 25000),
(2, 2, 100, 95000),
(3, 3, 300, 18000),
(4, 4, 150, 22000),
(5, 5, 100, 120000),
(6, 6, 100, 65000),
(7, 7, 100, 35000),
(8, 8, 1000, 1500),
(9, 9, 120, 70000),
(10, 10, 80, 350000);
GO

-- ================================
-- 12. Bảng Thông số lương (ThongSoLuong)
-- 5 chức vụ x 12 tháng năm 2025
-- Mỗi chức vụ có hệ số lương và phụ cấp khác nhau
-- ================================

-- Quản lý - Hệ số cao nhất, phụ cấp cao nhất
INSERT INTO ThongSoLuong (ChucVu, HeSoLuongCoBan, PhuCapChucVu, TyLeBHXH, TyLeBHYT, TyLeBHTN, Thang, Nam) VALUES
(N'Quản lý', 8000000, 2000000, 8.0, 1.5, 1.0, 1, 2025),
(N'Quản lý', 8000000, 2000000, 8.0, 1.5, 1.0, 2, 2025),
(N'Quản lý', 8000000, 2000000, 8.0, 1.5, 1.0, 3, 2025),
(N'Quản lý', 8000000, 2000000, 8.0, 1.5, 1.0, 4, 2025),
(N'Quản lý', 8000000, 2000000, 8.0, 1.5, 1.0, 5, 2025),
(N'Quản lý', 8000000, 2000000, 8.0, 1.5, 1.0, 6, 2025),
(N'Quản lý', 8200000, 2100000, 8.0, 1.5, 1.0, 7, 2025), -- Tăng lương từ tháng 7
(N'Quản lý', 8200000, 2100000, 8.0, 1.5, 1.0, 8, 2025),
(N'Quản lý', 8200000, 2100000, 8.0, 1.5, 1.0, 9, 2025),
(N'Quản lý', 8200000, 2100000, 8.0, 1.5, 1.0, 10, 2025),
(N'Quản lý', 8200000, 2100000, 8.0, 1.5, 1.0, 11, 2025),
(N'Quản lý', 8200000, 2100000, 8.0, 1.5, 1.0, 12, 2025);

-- Kế toán - Hệ số cao, phụ cấp trung bình
INSERT INTO ThongSoLuong (ChucVu, HeSoLuongCoBan, PhuCapChucVu, TyLeBHXH, TyLeBHYT, TyLeBHTN, Thang, Nam) VALUES
(N'Kế toán', 6000000, 800000, 8.0, 1.5, 1.0, 1, 2025),
(N'Kế toán', 6000000, 800000, 8.0, 1.5, 1.0, 2, 2025),
(N'Kế toán', 6000000, 800000, 8.0, 1.5, 1.0, 3, 2025),
(N'Kế toán', 6000000, 800000, 8.0, 1.5, 1.0, 4, 2025),
(N'Kế toán', 6000000, 800000, 8.0, 1.5, 1.0, 5, 2025),
(N'Kế toán', 6000000, 800000, 8.0, 1.5, 1.0, 6, 2025),
(N'Kế toán', 6200000, 850000, 8.0, 1.5, 1.0, 7, 2025), -- Tăng lương từ tháng 7
(N'Kế toán', 6200000, 850000, 8.0, 1.5, 1.0, 8, 2025),
(N'Kế toán', 6200000, 850000, 8.0, 1.5, 1.0, 9, 2025),
(N'Kế toán', 6200000, 850000, 8.0, 1.5, 1.0, 10, 2025),
(N'Kế toán', 6200000, 850000, 8.0, 1.5, 1.0, 11, 2025),
(N'Kế toán', 6200000, 850000, 8.0, 1.5, 1.0, 12, 2025);

-- Nhân viên bán hàng - Hệ số trung bình, phụ cấp thấp (vì có hoa hồng)
INSERT INTO ThongSoLuong (ChucVu, HeSoLuongCoBan, PhuCapChucVu, TyLeBHXH, TyLeBHYT, TyLeBHTN, Thang, Nam) VALUES
(N'Nhân viên bán hàng', 5000000, 500000, 8.0, 1.5, 1.0, 1, 2025),
(N'Nhân viên bán hàng', 5000000, 500000, 8.0, 1.5, 1.0, 2, 2025),
(N'Nhân viên bán hàng', 5000000, 500000, 8.0, 1.5, 1.0, 3, 2025),
(N'Nhân viên bán hàng', 5000000, 500000, 8.0, 1.5, 1.0, 4, 2025),
(N'Nhân viên bán hàng', 5000000, 500000, 8.0, 1.5, 1.0, 5, 2025),
(N'Nhân viên bán hàng', 5000000, 500000, 8.0, 1.5, 1.0, 6, 2025),
(N'Nhân viên bán hàng', 5200000, 550000, 8.0, 1.5, 1.0, 7, 2025), -- Tăng lương từ tháng 7
(N'Nhân viên bán hàng', 5200000, 550000, 8.0, 1.5, 1.0, 8, 2025),
(N'Nhân viên bán hàng', 5200000, 550000, 8.0, 1.5, 1.0, 9, 2025),
(N'Nhân viên bán hàng', 5200000, 550000, 8.0, 1.5, 1.0, 10, 2025),
(N'Nhân viên bán hàng', 5200000, 550000, 8.0, 1.5, 1.0, 11, 2025),
(N'Nhân viên bán hàng', 5200000, 550000, 8.0, 1.5, 1.0, 12, 2025);

-- Nhân viên kho - Hệ số trung bình, phụ cấp trung bình
INSERT INTO ThongSoLuong (ChucVu, HeSoLuongCoBan, PhuCapChucVu, TyLeBHXH, TyLeBHYT, TyLeBHTN, Thang, Nam) VALUES
(N'Nhân viên kho', 5500000, 600000, 8.0, 1.5, 1.0, 1, 2025),
(N'Nhân viên kho', 5500000, 600000, 8.0, 1.5, 1.0, 2, 2025),
(N'Nhân viên kho', 5500000, 600000, 8.0, 1.5, 1.0, 3, 2025),
(N'Nhân viên kho', 5500000, 600000, 8.0, 1.5, 1.0, 4, 2025),
(N'Nhân viên kho', 5500000, 600000, 8.0, 1.5, 1.0, 5, 2025),
(N'Nhân viên kho', 5500000, 600000, 8.0, 1.5, 1.0, 6, 2025),
(N'Nhân viên kho', 5700000, 650000, 8.0, 1.5, 1.0, 7, 2025), -- Tăng lương từ tháng 7
(N'Nhân viên kho', 5700000, 650000, 8.0, 1.5, 1.0, 8, 2025),
(N'Nhân viên kho', 5700000, 650000, 8.0, 1.5, 1.0, 9, 2025),
(N'Nhân viên kho', 5700000, 650000, 8.0, 1.5, 1.0, 10, 2025),
(N'Nhân viên kho', 5700000, 650000, 8.0, 1.5, 1.0, 11, 2025),
(N'Nhân viên kho', 5700000, 650000, 8.0, 1.5, 1.0, 12, 2025);

-- Nhân viên chăm sóc khách hàng - Hệ số trung bình thấp, phụ cấp trung bình
INSERT INTO ThongSoLuong (ChucVu, HeSoLuongCoBan, PhuCapChucVu, TyLeBHXH, TyLeBHYT, TyLeBHTN, Thang, Nam) VALUES
(N'Nhân viên chăm sóc khách hàng', 4800000, 500000, 8.0, 1.5, 1.0, 1, 2025),
(N'Nhân viên chăm sóc khách hàng', 4800000, 500000, 8.0, 1.5, 1.0, 2, 2025),
(N'Nhân viên chăm sóc khách hàng', 4800000, 500000, 8.0, 1.5, 1.0, 3, 2025),
(N'Nhân viên chăm sóc khách hàng', 4800000, 500000, 8.0, 1.5, 1.0, 4, 2025),
(N'Nhân viên chăm sóc khách hàng', 4800000, 500000, 8.0, 1.5, 1.0, 5, 2025),
(N'Nhân viên chăm sóc khách hàng', 4800000, 500000, 8.0, 1.5, 1.0, 6, 2025),
(N'Nhân viên chăm sóc khách hàng', 5000000, 550000, 8.0, 1.5, 1.0, 7, 2025), -- Tăng lương từ tháng 7
(N'Nhân viên chăm sóc khách hàng', 5000000, 550000, 8.0, 1.5, 1.0, 8, 2025),
(N'Nhân viên chăm sóc khách hàng', 5000000, 550000, 8.0, 1.5, 1.0, 9, 2025),
(N'Nhân viên chăm sóc khách hàng', 5000000, 550000, 8.0, 1.5, 1.0, 10, 2025),
(N'Nhân viên chăm sóc khách hàng', 5000000, 550000, 8.0, 1.5, 1.0, 11, 2025),
(N'Nhân viên chăm sóc khách hàng', 5000000, 550000, 8.0, 1.5, 1.0, 12, 2025);
GO

-- ================================
-- 13. Bảng Lương nhân viên (BangLuong) - ĐÃ SỬA
-- Dữ liệu lương tháng 9/2025 cho các nhân viên
-- MaNhanVien tham chiếu đến Taikhoan.Manguoidung (INT)
-- 
-- Danh sách nhân viên (từ Insert.sql gốc):
-- 1 = Nguyễn Văn An - Quản lý
-- 2 = Trần Thị Bích - Nhân viên chăm sóc khách hàng
-- 3 = Lê Minh Cường - Nhân viên kho
-- 4 = Phạm Thị Dung - Nhân viên bán hàng
-- 5 = Hoàng Văn Em - Nhân viên bán hàng
-- 6 = Vũ Thị Hà - Kế toán
-- 7 = Đặng Minh Long - Nhân viên kho
-- 8 = Bùi Thị Kiều - Nhân viên bán hàng
-- 9 = Ngô Tuấn Anh - Nhân viên chăm sóc khách hàng
-- 10 = Đỗ Phương Thảo - Kế toán
-- ================================
INSERT INTO BangLuong (MaNhanVien, Thang, Nam, SoNgayCongThucTe, LuongCoBan, PhuCap, KhauTruBaoHiem, ThucLinh) VALUES
(6, 9, 2025, 26, 6200000, 850000, 740250, 6309750),   -- Kế toán (Vũ Thị Hà)
(5, 9, 2025, 25, 5200000, 550000, 603750, 5146250),   -- Nhân viên bán hàng (Hoàng Văn Em)
(4, 9, 2025, 26, 5200000, 550000, 603750, 5146250),   -- Nhân viên bán hàng (Phạm Thị Dung)
(2, 9, 2025, 24, 5000000, 550000, 582750, 4967250),   -- Nhân viên chăm sóc khách hàng (Trần Thị Bích)
(7, 9, 2025, 25, 5700000, 650000, 666750, 5683250),   -- Nhân viên kho (Đặng Minh Long)
(9, 9, 2025, 26, 5000000, 550000, 582750, 4967250),   -- Nhân viên chăm sóc khách hàng (Ngô Tuấn Anh)
(1, 9, 2025, 26, 8200000, 2100000, 1081500, 9218500); -- Quản lý (Nguyễn Văn An)
GO

-- ================================
-- 14. Bảng Công nợ (CongNo) - ĐÃ SỬA
-- MaNguoiTao tham chiếu đến Taikhoan.Manguoidung (INT)
-- 1 = Nguyễn Văn An (Quản lý)
-- 6 = Vũ Thị Hà (Kế toán)
-- 10 = Đỗ Phương Thảo (Kế toán)
-- ================================
INSERT INTO CongNo (LoaiDoiTuong, MaDoiTuong, SoTienNo, NgayPhatSinh, LyDo, TrangThai, MaNguoiTao) VALUES
(N'NhaCungCap', '1', 50000000, '2025-08-15', N'Tiền hàng đợt 1 tháng 8', N'Chưa thanh toán', 6),
(N'NhaCungCap', '3', 35000000, '2025-08-20', N'Tiền hàng đợt 2 tháng 8', N'Đã thanh toán', 10),
(N'KhachHang', '0346543219', 500000, '2025-09-10', N'Mua thuốc nợ', N'Chưa thanh toán', 1),
(N'KhachHang', '0369871234', 250000, '2025-09-12', N'Mua thiếu tiền', N'Đã thanh toán', 1),
(N'NhaCungCap', '2', 42000000, '2025-09-01', N'Công nợ gối đầu tháng 9', N'Chưa thanh toán', 6),
(N'NhaCungCap', '5', 15000000, '2025-09-05', N'Tiền nhập hàng TPCN', N'Chưa thanh toán', 10),
(N'KhachHang', '0398765432', 120000, '2025-09-25', N'Khách quen mua nợ', N'Chưa thanh toán', 1),
(N'NhaCungCap', '7', 20000000, '2025-09-28', N'Công nợ cuối tháng 9', N'Đã thanh toán', 6),
(N'KhachHang', '0381234567', 85000, '2025-10-01', N'Khách hàng quên mang tiền', N'Đã thanh toán', 1),
(N'KhachHang', '0337894561', 300000, '2025-10-05', N'Nợ tiền thuốc bổ', N'Chưa thanh toán', 1);
GO

-- ================================
-- KẾT THÚC PHẦN CHÈN DỮ LIỆU KẾ TOÁN
-- ================================
