-- Sử dụng Database đã tạo
USE NhaThuocDB;
GO

-- ==============================================================
-- CHÈN DỮ LIỆU MẪU
-- ==============================================================

-- ================================
-- PHẦN KẾ TOÁN
-- ================================

INSERT INTO Taikhoan (Manguoidung, Hovaten, Sodienthoai, Matkhau, Ngaysinh, Chucvu) 
VALUES
(N'KeToan_0918273645', N'Vũ Minh Khang', '0918273645', '123', '2004-05-26', N'Kế toán'),
(N'NV001', N'Nhân viên mặc định', '0000000000', '123456', NULL, N'Nhân viên bán hàng'),
(N'NhanVienBanHang_0987654321', N'Lê Thị Thảo', '0987654321', '123', '2002-04-17', N'Nhân viên bán hàng'),
(N'NhanVienChamSocKhachHang_0192837465', N'Huỳnh Hoài Phương', '0192837465', '123', '2004-08-17', N'Nhân viên chăm sóc khách hàng'),
(N'NhanVienKho_0123456789', N'Huỳnh Thanh Nhân', '0123456789', '123', '2001-03-19', N'Nhân viên kho'),
(N'Nhân viên chăm sóc khách hàng_0344969876', N'Huỳnh Hoài Phương', '0344969876', '1234', '1991-02-08', N'Nhân viên chăm sóc khách hàng'),
(N'QuanLy_0799513501', N'Lê Vũ Hải', '0799513501', '123', '2005-03-03', N'Quản lý');
GO

-- ================================
-- 2. Bảng Thông tin khách hàng (Thongtinkhachhang)
-- Manhanvien được gán ngẫu nhiên từ các nhân viên đã tạo ở trên
-- ================================
INSERT INTO Thongtinkhachhang (Sodienthoai, Hovaten, Diemtichluy, Manhanvien) VALUES
('0398765432', N'Trần Văn Hùng', 150, N'NhanVienBanHang_0987654321'),
('0381234567', N'Lê Thị Mai', 200, N'NhanVienBanHang_0987654321'),
('0376549871', N'Nguyễn Hoàng Anh', 50, N'NhanVienBanHang_0987654321'),
('0369871234', N'Phạm Minh Tuấn', 320, N'NhanVienBanHang_0987654321'),
('0351237896', N'Đặng Thị Lan', 80, N'NhanVienBanHang_0987654321'),
('0346543219', N'Vũ Ngọc Sơn', 450, N'NhanVienBanHang_0987654321'),
('0337894561', N'Bùi Thanh Trúc', 120, N'NhanVienBanHang_0987654321'),
('0329876543', N'Hoàng Thị Thu', 250, N'NhanVienBanHang_0987654321'),
('0861234567', N'Ngô Gia Bảo', 10, N'NhanVienBanHang_0987654321'),
('0887654321', N'Đỗ Mỹ Linh', 95, N'NhanVienBanHang_0987654321');
GO

-- ================================
-- 3. Bảng Nhóm thuốc (NhomThuoc)
-- ================================
INSERT INTO NhomThuoc (TenNhom, MoTa) VALUES
(N'Kháng sinh', N'Các loại thuốc dùng để điều trị nhiễm khuẩn'),
(N'Giảm đau, hạ sốt', N'Thuốc giảm các triệu chứng đau, sốt'),
(N'Vitamin và khoáng chất', N'Bổ sung vitamin và các chất cần thiết cho cơ thể'),
(N'Thuốc tim mạch', N'Thuốc điều trị các bệnh liên quan đến tim và mạch máu'),
(N'Thuốc tiêu hóa', N'Thuốc hỗ trợ và điều trị các vấn đề về đường tiêu hóa'),
(N'Thuốc ho và cảm cúm', N'Thuốc điều trị các triệu chứng ho, cảm lạnh, cúm'),
(N'Thuốc ngoài da', N'Thuốc dùng để bôi, điều trị các bệnh về da'),
(N'Thuốc mắt, tai, mũi', N'Dung dịch nhỏ mắt, tai, mũi'),
(N'Thuốc tiểu đường', N'Thuốc điều trị bệnh đái tháo đường'),
(N'Thực phẩm chức năng', N'Sản phẩm hỗ trợ sức khỏe, không phải là thuốc');
GO

-- ================================
-- 4. Bảng Loại thuốc (LoaiThuoc)
-- ================================
INSERT INTO LoaiThuoc (TenLoai, MoTa, MaNhom) VALUES
(N'Kháng sinh Penicillin', N'Nhóm kháng sinh beta-lactam', 1),
(N'Paracetamol', N'Hoạt chất giảm đau, hạ sốt phổ biến', 2),
(N'Vitamin C', N'Bổ sung Vitamin C, tăng cường đề kháng', 3),
(N'Thuốc huyết áp', N'Thuốc điều trị cao huyết áp', 4),
(N'Men vi sinh', N'Bổ sung lợi khuẩn cho đường ruột', 5),
(N'Siro ho thảo dược', N'Thuốc ho chiết xuất từ thảo dược tự nhiên', 6),
(N'Thuốc bôi trị nấm', N'Kem bôi điều trị nhiễm nấm ngoài da', 7),
(N'Nước muối sinh lý', N'Dung dịch NaCl 0.9% dùng để nhỏ mắt, mũi', 8),
(N'Metformin', N'Thuốc điều trị tiểu đường type 2', 9),
(N'Dầu cá Omega-3', N'Bổ sung acid béo Omega-3', 10);
GO

-- ================================
-- 5. Bảng Sản phẩm thuốc (Sanphamthuoc)
-- ================================
INSERT INTO Sanphamthuoc (MaLoai, Tenhang, Soluong, Thanhphan, Nhasanxuat, Donggoi, Gianhap, Giaban, Ngayhethan, Lohang) VALUES
(1, N'Amoxicillin 500mg DOMESCO', 200, N'Amoxicillin trihydrat 500mg', N'DOMESCO', N'Hộp 10 vỉ x 10 viên', 25000, 35000, '2026-10-15', 'AMX2510A'),
(2, N'Panadol Extra', 500, N'Paracetamol 500mg, Caffeine 65mg', N'GSK', N'Hộp 15 vỉ x 12 viên', 95000, 115000, '2027-05-20', 'PNDL2705B'),
(3, N'Vitamin C 500mg OPC', 300, N'Acid ascorbic 500mg', N'OPC Pharma', N'Chai 100 viên', 18000, 25000, '2026-08-30', 'VTC2608C'),
(4, N'Amlodipin 5mg Traphaco', 150, N'Amlodipin besilat 5mg', N'Traphaco', N'Hộp 3 vỉ x 10 viên', 22000, 30000, '2026-11-10', 'AML2611D'),
(5, N'Enterogermina', 250, N'Bacillus clausii 2 tỷ lợi khuẩn/5ml', N'Sanofi', N'Hộp 20 ống x 5ml', 120000, 145000, '2027-01-25', 'ENTG2701E'),
(6, N'Siro ho Prospan', 180, N'Cao khô lá thường xuân', N'Engelhard Arzneimittel', N'Chai 100ml', 65000, 78000, '2026-09-18', 'PROS2609F'),
(7, N'Nizoral Cream 10g', 100, N'Ketoconazole 2%', N'Janssen-Cilag', N'Tuýp 10g', 35000, 45000, '2026-12-01', 'NIZ2612G'),
(8, N'Natri Clorid 0.9% 10ml', 1000, N'Natri clorid 0.9g/100ml', N'Dược phẩm 3/2', N'Lọ 10ml', 1500, 3000, '2027-03-14', 'NACL2703H'),
(9, N'Glucophage 850mg', 120, N'Metformin hydrochloride 850mg', N'Merck', N'Hộp 10 vỉ x 10 viên', 70000, 85000, '2026-10-22', 'GLU2610I'),
(10, N'Blackmores Omega Daily', 80, N'Dầu cá tự nhiên 1034mg', N'Blackmores', N'Lọ 90 viên', 350000, 420000, '2027-06-01', 'BLM2706K');
GO

-- ================================
-- 6. Bảng Đơn hàng (Donhang)
-- ================================
INSERT INTO Donhang (Sodienthoaikhachhang, Manhanvien, Ngaytaodon) VALUES
('0398765432', N'NhanVienBanHang_0987654321', '2025-10-10 09:30:00'),
('0381234567', N'NhanVienBanHang_0987654321', '2025-10-10 10:15:00'),
('0376549871', N'NhanVienBanHang_0987654321', '2025-10-11 14:00:00'),
('0369871234', N'NhanVienBanHang_0987654321', '2025-10-11 15:20:00'),
('0351237896', N'NhanVienBanHang_0987654321', '2025-10-12 08:45:00'),
('0346543219', N'NhanVienBanHang_0987654321', '2025-10-12 11:05:00'),
('0337894561', N'NhanVienBanHang_0987654321', '2025-10-13 16:30:00'),
('0329876543', N'NhanVienBanHang_0987654321', '2025-10-13 17:00:00'),
('0861234567', N'NhanVienBanHang_0987654321', '2025-10-14 09:00:00'),
('0887654321', N'NhanVienBanHang_0987654321', '2025-10-14 10:10:00');
GO

-- ================================
-- 7. Bảng Chi tiết đơn hàng (Chitietdonhang)
-- Đơn giá lấy từ giá bán của sản phẩm tại thời điểm tạo
-- ================================
INSERT INTO Chitietdonhang (Madonhang, Masanpham, Soluong, DonGia) VALUES
(1, 2, 1, 115000), -- Panadol Extra
(1, 6, 1, 78000),  -- Siro ho Prospan
(2, 5, 2, 145000), -- Enterogermina
(3, 8, 5, 3000),   -- Nước muối sinh lý
(4, 1, 1, 35000),  -- Amoxicillin
(5, 10, 1, 420000),-- Blackmores Omega Daily
(6, 3, 2, 25000),  -- Vitamin C
(7, 4, 1, 30000),  -- Amlodipin
(8, 7, 1, 45000),  -- Nizoral Cream
(9, 9, 1, 85000);  -- Glucophage
GO

-- ================================
-- 8. Bảng Phản hồi khách hàng (Phanhoikhachhang)
-- ================================
INSERT INTO Phanhoikhachhang (Hovaten, Sodienthoai, Manhanvien, Phanhoi, Trangthai) VALUES
(N'Trần Văn Hùng', '0398765432', N'NhanVienChamSocKhachHang_0192837465', N'Nhân viên tư vấn nhiệt tình, sản phẩm tốt.', N'Đã xử lý'),
(N'Lê Thị Mai', '0381234567', N'NhanVienChamSocKhachHang_0192837465', N'Nhà thuốc nên có thêm nhiều loại thực phẩm chức năng hơn.', N'Mới'),
(N'Nguyễn Hoàng Anh', '0376549871', N'NhanVienChamSocKhachHang_0192837465', N'Giá cả hợp lý, sẽ quay lại ủng hộ.', N'Đã xử lý'),
(N'Phạm Minh Tuấn', '0369871234', N'Nhân viên chăm sóc khách hàng_0344969876', N'Dược sĩ tư vấn rất kỹ về tác dụng phụ của thuốc.', N'Đã xử lý'),
(N'Đặng Thị Lan', '0351237896', N'NhanVienChamSocKhachHang_0192837465', N'Thời gian chờ thanh toán hơi lâu.', N'Đang xem xét'),
(N'Vũ Ngọc Sơn', '0346543219', N'NhanVienChamSocKhachHang_0192837465', N'Hài lòng với dịch vụ.', N'Đã xử lý'),
(N'Bùi Thanh Trúc', '0337894561', N'Nhân viên chăm sóc khách hàng_0344969876', N'Tìm thuốc rất dễ dàng, nhà thuốc sắp xếp gọn gàng.', N'Đã xử lý'),
(N'Hoàng Thị Thu', '0329876543', N'NhanVienChamSocKhachHang_0192837465', N'Sản phẩm này có khuyến mãi gì không?', N'Mới'),
(N'Ngô Gia Bảo', '0861234567', N'NhanVienChamSocKhachHang_0192837465', N'Hỏi về một loại thuốc nhưng nhà thuốc đã hết hàng.', N'Đang xem xét'),
(N'Đỗ Mỹ Linh', '0887654321', N'Nhân viên chăm sóc khách hàng_0344969876', N'Dược sĩ rất thân thiện và chuyên nghiệp.', N'Đã xử lý');
GO

-- ================================
-- PHẦN KẾ TOÁN
-- ================================

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
-- ================================
INSERT INTO PhieuNhapHang (MaNhaCungCap, MaNguoiTao, NgayNhap, TongTien) VALUES
(1, N'NhanVienKho_0123456789', '2025-09-01 10:00:00', 5000000),
(4, N'NhanVienKho_0123456789', '2025-09-02 11:30:00', 9500000),
(6, N'NhanVienKho_0123456789', '2025-09-05 14:00:00', 5400000),
(2, N'NhanVienKho_0123456789', '2025-09-06 09:00:00', 3300000),
(3, N'NhanVienKho_0123456789', '2025-09-10 16:20:00', 12000000),
(10, N'NhanVienKho_0123456789', '2025-09-12 15:00:00', 6500000),
(5, N'NhanVienKho_0123456789', '2025-09-15 10:45:00', 3500000),
(8, N'NhanVienKho_0123456789', '2025-09-18 08:30:00', 1500000),
(9, N'NhanVienKho_0123456789', '2025-09-20 13:00:00', 8400000),
(7, N'NhanVienKho_0123456789', '2025-09-22 11:00:00', 28000000);
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
-- 13. Bảng Lương nhân viên (BangLuong)
-- Dữ liệu lương tháng 9/2025 cho 10 nhân viên
-- Giả sử Lương cơ bản = 5,000,000. Khấu trừ BH (10.5%) = 525,000
-- ThucLinh = LuongCoBan + PhuCap - KhauTruBaoHiem
-- ================================
INSERT INTO BangLuong (MaNhanVien, Thang, Nam, SoNgayCongThucTe, LuongCoBan, PhuCap, KhauTruBaoHiem, ThucLinh) VALUES
(N'KeToan_0918273645', 9, 2025, 26, 6200000, 850000, 740250, 6309750),
(N'NV001', 9, 2025, 25, 5200000, 550000, 603750, 5146250),
(N'NhanVienBanHang_0987654321', 9, 2025, 26, 5200000, 550000, 603750, 5146250),
(N'NhanVienChamSocKhachHang_0192837465', 9, 2025, 24, 5000000, 550000, 582750, 4967250),
(N'NhanVienKho_0123456789', 9, 2025, 25, 5700000, 650000, 666750, 5683250),
(N'Nhân viên chăm sóc khách hàng_0344969876', 9, 2025, 26, 5000000, 550000, 582750, 4967250),
(N'QuanLy_0799513501', 9, 2025, 26, 8200000, 2100000, 1081500, 9218500);
GO

-- ================================
-- 14. Bảng Công nợ (CongNo)
-- Sửa MaNguoiTao = 1 thành N'QuanLy_0799513501'
-- Sửa MaNguoiTao = 6 và 10 thành N'KeToan_0918273645'
-- ================================
INSERT INTO CongNo (LoaiDoiTuong, MaDoiTuong, SoTienNo, NgayPhatSinh, LyDo, TrangThai, MaNguoiTao) VALUES
(N'NhaCungCap', '1', 50000000, '2025-08-15', N'Tiền hàng đợt 1 tháng 8', N'Chưa thanh toán', N'KeToan_0918273645'),
(N'NhaCungCap', '3', 35000000, '2025-08-20', N'Tiền hàng đợt 2 tháng 8', N'Đã thanh toán', N'KeToan_0918273645'),
(N'KhachHang', '0346543219', 500000, '2025-09-10', N'Mua thuốc nợ', N'Chưa thanh toán', N'QuanLy_0799513501'),
(N'KhachHang', '0369871234', 250000, '2025-09-12', N'Mua thiếu tiền', N'Đã thanh toán', N'QuanLy_0799513501'),
(N'NhaCungCap', '2', 42000000, '2025-09-01', N'Công nợ gối đầu tháng 9', N'Chưa thanh toán', N'KeToan_0918273645'),
(N'NhaCungCap', '5', 15000000, '2025-09-05', N'Tiền nhập hàng TPCN', N'Chưa thanh toán', N'KeToan_0918273645'),
(N'KhachHang', '0398765432', 120000, '2025-09-25', N'Khách quen mua nợ', N'Chưa thanh toán', N'QuanLy_0799513501'),
(N'NhaCungCap', '7', 20000000, '2025-09-28', N'Công nợ cuối tháng 9', N'Đã thanh toán', N'KeToan_0918273645'),
(N'KhachHang', '0381234567', 85000, '2025-10-01', N'Khách hàng quên mang tiền', N'Đã thanh toán', N'QuanLy_0799513501'),
(N'KhachHang', '0337894561', 300000, '2025-10-05', N'Nợ tiền thuốc bổ', N'Chưa thanh toán', N'QuanLy_0799513501');
GO
