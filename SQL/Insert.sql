-- Sử dụng Database đã tạo
USE NhaThuocDB;
GO

-- ==============================================================
-- CHÈN DỮ LIỆU MẪU
-- ==============================================================

-- ================================
-- 1. Bảng Tài khoản (Taikhoan)
-- Chức vụ: Quản lý, Dược sĩ, Nhân viên bán hàng, Kế toán, Nhân viên kho
-- ================================
INSERT INTO Taikhoan (Hovaten, Sodienthoai, Matkhau, Ngaysinh, Chucvu) VALUES
(N'Nguyễn Văn An', '0912345678', 'password123', '1985-05-20', N'Quản lý'),
(N'Trần Thị Bích', '0987654321', 'password123', '1990-11-15', N'Nhân viên chăm sóc khách hàng'),
(N'Lê Minh Cường', '0905112233', 'password123', '1992-02-10', N'Nhân viên kho'),
(N'Phạm Thị Dung', '0934567890', 'password123', '1995-07-30', N'Nhân viên bán hàng'),
(N'Hoàng Văn Em', '0978123456', 'password123', '1998-09-05', N'Nhân viên bán hàng'),
(N'Vũ Thị Hà', '0915654789', 'password123', '1991-03-25', N'Kế toán'),
(N'Đặng Minh Long', '0945789123', 'password123', '1993-08-12', N'Nhân viên kho'),
(N'Bùi Thị Kiều', '0965432198', 'password123', '1996-01-18', N'Nhân viên bán hàng'),
(N'Ngô Tuấn Anh', '0923456789', 'password123', '1994-06-22', N'Nhân viên chăm sóc khách hàng'),
(N'Đỗ Phương Thảo', '0956789123', 'password123', '1988-12-01', N'Kế toán');
GO

-- ================================
-- 2. Bảng Thông tin khách hàng (Thongtinkhachhang)
-- Manhanvien được gán ngẫu nhiên từ các nhân viên đã tạo ở trên
-- ================================
INSERT INTO Thongtinkhachhang (Sodienthoai, Hovaten, Diemtichluy, Manhanvien) VALUES
('0398765432', N'Trần Văn Hùng', 150, 4),
('0381234567', N'Lê Thị Mai', 200, 5),
('0376549871', N'Nguyễn Hoàng Anh', 50, 4),
('0369871234', N'Phạm Minh Tuấn', 320, 8),
('0351237896', N'Đặng Thị Lan', 80, 5),
('0346543219', N'Vũ Ngọc Sơn', 450, 4),
('0337894561', N'Bùi Thanh Trúc', 120, 8),
('0329876543', N'Hoàng Thị Thu', 250, 5),
('0861234567', N'Ngô Gia Bảo', 10, 4),
('0887654321', N'Đỗ Mỹ Linh', 95, 8);
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
('0398765432', 4, '2025-10-10 09:30:00'),
('0381234567', 5, '2025-10-10 10:15:00'),
('0376549871', 4, '2025-10-11 14:00:00'),
('0369871234', 8, '2025-10-11 15:20:00'),
('0351237896', 5, '2025-10-12 08:45:00'),
('0346543219', 4, '2025-10-12 11:05:00'),
('0337894561', 8, '2025-10-13 16:30:00'),
('0329876543', 5, '2025-10-13 17:00:00'),
('0861234567', 4, '2025-10-14 09:00:00'),
('0887654321', 8, '2025-10-14 10:10:00');
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
(N'Trần Văn Hùng', '0398765432', 2, N'Nhân viên tư vấn nhiệt tình, sản phẩm tốt.', N'Đã xử lý'),
(N'Lê Thị Mai', '0381234567', 3, N'Nhà thuốc nên có thêm nhiều loại thực phẩm chức năng hơn.', N'Mới'),
(N'Nguyễn Hoàng Anh', '0376549871', 2, N'Giá cả hợp lý, sẽ quay lại ủng hộ.', N'Đã xử lý'),
(N'Phạm Minh Tuấn', '0369871234', 9, N'Dược sĩ tư vấn rất kỹ về tác dụng phụ của thuốc.', N'Đã xử lý'),
(N'Đặng Thị Lan', '0351237896', 2, N'Thời gian chờ thanh toán hơi lâu.', N'Đang xem xét'),
(N'Vũ Ngọc Sơn', '0346543219', 3, N'Hài lòng với dịch vụ.', N'Đã xử lý'),
(N'Bùi Thanh Trúc', '0337894561', 9, N'Tìm thuốc rất dễ dàng, nhà thuốc sắp xếp gọn gàng.', N'Đã xử lý'),
(N'Hoàng Thị Thu', '0329876543', 2, N'Sản phẩm này có khuyến mãi gì không?', N'Mới'),
(N'Ngô Gia Bảo', '0861234567', 3, N'Hỏi về một loại thuốc nhưng nhà thuốc đã hết hàng.', N'Đang xem xét'),
(N'Đỗ Mỹ Linh', '0887654321', 9, N'Dược sĩ rất thân thiện và chuyên nghiệp.', N'Đã xử lý');
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
-- 10. Bảng Phiếu nhập hàng (PhieuNhapHang)
-- MaNguoiTao là Kế toán (6, 10) hoặc Nhân viên kho (7)
-- ================================
INSERT INTO PhieuNhapHang (MaNhaCungCap, MaNguoiTao, NgayNhap, TongTien) VALUES
(1, 7, '2025-09-01 10:00:00', 5000000), -- NCC Dược Hậu Giang, SP Amoxicillin
(4, 7, '2025-09-02 11:30:00', 9500000), -- NCC GSK, SP Panadol Extra
(6, 7, '2025-09-05 14:00:00', 5400000), -- NCC OPC, SP Vitamin C
(2, 7, '2025-09-06 09:00:00', 3300000), -- NCC Traphaco, SP Amlodipin
(3, 7, '2025-09-10 16:20:00', 12000000),-- NCC Sanofi, SP Enterogermina
(10, 7, '2025-09-12 15:00:00', 6500000),-- NCC Hisamitsu (giả định), SP Prospan
(5, 7, '2025-09-15 10:45:00', 3500000), -- NCC Mekophar (giả định), SP Nizoral
(8, 7, '2025-09-18 08:30:00', 1500000), -- NCC Vimedimex (giả định), SP Nước muối
(9, 7, '2025-09-20 13:00:00', 8400000), -- NCC Pymepharco (giả định), SP Glucophage
(7, 7, '2025-09-22 11:00:00', 28000000);-- NCC Imexpharm (giả định), SP Blackmores
GO

-- ================================
-- 11. Bảng Chi tiết phiếu nhập (ChiTietPhieuNhap)
-- DonGiaNhap lấy từ Gianhap của sản phẩm
-- ================================
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSanPham, SoLuongNhap, DonGiaNhap) VALUES
(1, 1, 200, 25000),   -- Tổng: 5,000,000
(2, 2, 100, 95000),   -- Tổng: 9,500,000
(3, 3, 300, 18000),   -- Tổng: 5,400,000
(4, 4, 150, 22000),   -- Tổng: 3,300,000
(5, 5, 100, 120000),  -- Tổng: 12,000,000
(6, 6, 100, 65000),   -- Tổng: 6,500,000
(7, 7, 100, 35000),   -- Tổng: 3,500,000
(8, 8, 1000, 1500),  -- Tổng: 1,500,000
(9, 9, 120, 70000),   -- Tổng: 8,400,000
(10, 10, 80, 350000); -- Tổng: 28,000,000
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
(1, 9, 2025, 26, 8000000, 1000000, 840000, 8160000), -- Quản lý
(2, 9, 2025, 25, 7000000, 500000, 735000, 6765000),  -- Dược sĩ
(3, 9, 2025, 26, 7000000, 500000, 735000, 6765000),  -- Dược sĩ
(4, 9, 2025, 24, 5500000, 0, 577500, 4922500),      -- Nhân viên
(5, 9, 2025, 26, 5500000, 0, 577500, 4922500),      -- Nhân viên
(6, 9, 2025, 26, 6000000, 300000, 630000, 5670000),  -- Kế toán
(7, 9, 2025, 25, 5800000, 200000, 609000, 5391000),  -- Nhân viên kho
(8, 9, 2025, 26, 5500000, 0, 577500, 4922500),      -- Nhân viên
(9, 9, 2025, 26, 7000000, 500000, 735000, 6765000),  -- Dược sĩ
(10, 9, 2025, 25, 6000000, 300000, 630000, 5670000); -- Kế toán
GO

-- ================================
-- 14. Bảng Công nợ (CongNo)
-- MaDoiTuong là Sodienthoai (KhachHang) hoặc MaNhaCungCap (NhaCungCap)
-- MaNguoiTao là Kế toán (6, 10) hoặc Quản lý (1)
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
