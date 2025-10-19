-- ================================
-- Xóa database cũ nếu tồn tại
-- ================================
IF DB_ID('NhaThuocDB') IS NOT NULL
BEGIN 
    ALTER DATABASE NhaThuocDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE NhaThuocDB;
END
GO

-- ================================
-- Tạo Database mới
-- ================================
CREATE DATABASE NhaThuocDB;
GO
USE NhaThuocDB;
GO

-- ================================
-- 1. Bảng Tài khoản
-- ================================
CREATE TABLE Taikhoan (
    Manguoidung NVARCHAR(255) PRIMARY KEY,
    Hovaten NVARCHAR(255) NOT NULL,
    Sodienthoai NVARCHAR(20) NOT NULL UNIQUE,
    Matkhau NVARCHAR(255) NOT NULL,
    Ngaysinh DATE,
    Chucvu NVARCHAR(50) NOT NULL
);

-- ================================
-- 2. Bảng Thông tin khách hàng
-- ================================
CREATE TABLE Thongtinkhachhang (
    Sodienthoai NVARCHAR(20) PRIMARY KEY,
    Hovaten NVARCHAR(255) NOT NULL,
    Diemtichluy INT DEFAULT 0,
    Manhanvien NVARCHAR(255) NOT NULL,
    CONSTRAINT FK_KH_NV FOREIGN KEY (Manhanvien) REFERENCES Taikhoan(Manguoidung)
);

-- ================================
-- 3. Bảng Nhóm thuốc
-- ================================
CREATE TABLE NhomThuoc (
    MaNhom INT PRIMARY KEY IDENTITY(1,1),
    TenNhom NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(255)
);

-- ================================
-- 4. Bảng Loại thuốc
-- ================================
CREATE TABLE LoaiThuoc (
    MaLoai INT PRIMARY KEY IDENTITY(1,1),
    TenLoai NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(255),
    MaNhom INT NOT NULL,
    CONSTRAINT FK_LoaiThuoc_Nhom FOREIGN KEY (MaNhom) REFERENCES NhomThuoc(MaNhom)
);

-- ================================
-- 5. Bảng Sản phẩm thuốc
-- ================================
CREATE TABLE Sanphamthuoc (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaLoai INT NOT NULL,
    Mahanghoa NVARCHAR(50),
    Mavach NVARCHAR(50),
    Tenhang NVARCHAR(255) NOT NULL,
    Soluong INT DEFAULT 0,
    Mathuoc NVARCHAR(50),
    Thanhphan NVARCHAR(255),
    Nhasanxuat NVARCHAR(255),
    Donggoi NVARCHAR(255),
    Gianhap DECIMAL(18,2) NOT NULL,   -- giá nhập
    Kho INT DEFAULT 0,
    Mota NVARCHAR(500),
    Lohang NVARCHAR(100),
    Ngayhethan DATE,
    Giaban DECIMAL(18,2) NOT NULL,     -- giá bán
    CONSTRAINT FK_SP_Loai FOREIGN KEY (MaLoai) REFERENCES LoaiThuoc(MaLoai)
);

-- ================================
-- 6. Bảng Đơn hàng
-- ================================
CREATE TABLE Donhang (
    Madonhang INT PRIMARY KEY IDENTITY(1,1),
    Sodienthoaikhachhang NVARCHAR(20) NOT NULL,
	Manhanvien nvarchar(255) not null,
    Ngaytaodon DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_DH_KH FOREIGN KEY (Sodienthoaikhachhang) REFERENCES Thongtinkhachhang(Sodienthoai)
);

-- ================================
-- 7. Bảng Chi tiết đơn hàng
-- ================================
CREATE TABLE Chitietdonhang (
    Madonhang INT NOT NULL,
    Masanpham INT NOT NULL,
    Soluong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,   -- giá bán tại thời điểm đặt
    Tongtiensanpham AS (Soluong * DonGia) PERSISTED, -- cột tính toán
    CONSTRAINT PK_CTDH PRIMARY KEY (Madonhang, Masanpham),
    CONSTRAINT FK_CTDH_DH FOREIGN KEY (Madonhang) REFERENCES Donhang(Madonhang) ON DELETE CASCADE,
    CONSTRAINT FK_CTDH_SP FOREIGN KEY (Masanpham) REFERENCES Sanphamthuoc(ID)
);

-- ================================
-- 8. Bảng Phản hồi khách hàng
-- ================================
CREATE TABLE Phanhoikhachhang (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Hovaten NVARCHAR(255) NOT NULL,
    Sodienthoai NVARCHAR(20) NOT NULL,
    Manhanvien NVARCHAR(255) NOT NULL,
    Phanhoi NVARCHAR(1000),
    Ngaytao DATETIME DEFAULT GETDATE(),
	Trangthai nvarchar(100),
    CONSTRAINT FK_PHKH_NV FOREIGN KEY (Manhanvien) REFERENCES Taikhoan(Manguoidung),
    CONSTRAINT FK_PHKH_KH FOREIGN KEY (Sodienthoai) REFERENCES Thongtinkhachhang(Sodienthoai)
);

-- ================================
-- PHẦN KẾ TOÁN
-- ================================

-- ================================
-- 9. Bảng Nhà cung cấp
-- ================================
CREATE TABLE NhaCungCap (
    MaNhaCungCap INT PRIMARY KEY IDENTITY(1,1),
    TenNhaCungCap NVARCHAR(255) NOT NULL,
    SoDienThoai NVARCHAR(20),
    DiaChi NVARCHAR(500),
    Email NVARCHAR(255)
);

-- ================================
-- 10. Bảng Phiếu nhập hàng
-- ================================
CREATE TABLE PhieuNhapHang (
    MaPhieuNhap INT PRIMARY KEY IDENTITY(1,1),
    MaNhaCungCap INT NOT NULL,
    MaNguoiTao NVARCHAR(255) NOT NULL, -- Kế toán hoặc nhân viên kho
    NgayNhap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18, 2) NOT NULL,
    CONSTRAINT FK_PNH_NCC FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap),
    CONSTRAINT FK_PNH_NguoiTao FOREIGN KEY (MaNguoiTao) REFERENCES Taikhoan(Manguoidung)
);

-- ================================
-- 11. Bảng Chi tiết phiếu nhập
-- ================================
CREATE TABLE ChiTietPhieuNhap (
    MaPhieuNhap INT NOT NULL,
    MaSanPham INT NOT NULL,
    SoLuongNhap INT NOT NULL,
    DonGiaNhap DECIMAL(18, 2) NOT NULL, -- Giá tại thời điểm nhập
    ThanhTien AS (SoLuongNhap * DonGiaNhap) PERSISTED,
    CONSTRAINT PK_CTPN PRIMARY KEY (MaPhieuNhap, MaSanPham),
    CONSTRAINT FK_CTPN_PN FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhapHang(MaPhieuNhap) ON DELETE CASCADE,
    CONSTRAINT FK_CTPN_SP FOREIGN KEY (MaSanPham) REFERENCES Sanphamthuoc(ID)
);

-- ================================
-- 12. Bảng Thông số lương
-- ================================
CREATE TABLE ThongSoLuong (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ChucVu NVARCHAR(50) NOT NULL, -- Chức vụ áp dụng
    HeSoLuongCoBan DECIMAL(10, 2) NOT NULL, -- Hệ số lương cơ bản
    PhuCapChucVu DECIMAL(18, 2) DEFAULT 0, -- Phụ cấp chức vụ
    TyLeBHXH DECIMAL(5, 2) NOT NULL, -- Tỷ lệ Bảo hiểm xã hội
    TyLeBHYT DECIMAL(5, 2) NOT NULL, -- Tỷ lệ Bảo hiểm y tế
    TyLeBHTN DECIMAL(5, 2) NOT NULL, -- Tỷ lệ Bảo hiểm thất nghiệp
    Thang INT NOT NULL, -- Tháng áp dụng (1-12)
    Nam INT NOT NULL, -- Năm áp dụng
    CONSTRAINT UQ_ThongSoLuong UNIQUE (ChucVu, Thang, Nam) -- Mỗi chức vụ chỉ có 1 thông số/tháng/năm
);

-- ================================
-- 13. Bảng Lương nhân viên
-- ================================
CREATE TABLE BangLuong (
    MaBangLuong INT PRIMARY KEY IDENTITY(1,1),
    MaNhanVien NVARCHAR(255) NOT NULL,
    Thang INT NOT NULL,
    Nam INT NOT NULL,
    SoNgayCongThucTe INT NOT NULL,
    LuongCoBan DECIMAL(18, 2) NOT NULL, -- Lương theo hệ số tại thời điểm tính
    PhuCap DECIMAL(18, 2) DEFAULT 0,
    KhauTruBaoHiem DECIMAL(18, 2) DEFAULT 0,
    ThucLinh DECIMAL(18, 2) NOT NULL,
    NgayTinhLuong DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_BL_NV FOREIGN KEY (MaNhanVien) REFERENCES Taikhoan(Manguoidung),
    CONSTRAINT UQ_BangLuong UNIQUE (MaNhanVien, Thang, Nam) -- Đảm bảo mỗi nhân viên chỉ có 1 bảng lương/tháng
);

-- ================================
-- 14. Bảng Công nợ
-- ================================
CREATE TABLE CongNo (
    MaCongNo INT PRIMARY KEY IDENTITY(1,1),
    LoaiDoiTuong NVARCHAR(50) NOT NULL, -- 'KhachHang' hoặc 'NhaCungCap'
    MaDoiTuong NVARCHAR(20) NOT NULL, -- Sodienthoai của KH hoặc MaNhaCungCap
    SoTienNo DECIMAL(18, 2) NOT NULL,
    NgayPhatSinh DATE NOT NULL,
    LyDo NVARCHAR(500),
    TrangThai NVARCHAR(100) DEFAULT N'Chưa thanh toán', -- Ví dụ: 'Chưa thanh toán', 'Đã thanh toán'
    MaNguoiTao NVARCHAR(255) NOT NULL,
    CONSTRAINT FK_CN_NguoiTao FOREIGN KEY (MaNguoiTao) REFERENCES Taikhoan(Manguoidung)
);