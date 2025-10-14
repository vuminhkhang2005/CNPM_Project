# THAY ĐỔI HỆ THỐNG THÔNG SỐ LƯƠNG

## 📋 Tổng quan
Hệ thống thông số lương đã được thay đổi hoàn toàn để hỗ trợ:
- ✅ Thông số lương theo **THÁNG và NÀM** (không còn theo ngày)
- ✅ **5 chức vụ** có thông số lương khác nhau
- ✅ Dữ liệu đầy đủ cho **12 tháng năm 2025**
- ✅ Khi thông số lương thay đổi → Lương nhân viên cũng thay đổi theo

## 🔄 Những thay đổi chính

### 1. Cấu trúc bảng ThongSoLuong (SQL/CreateTable.sql)

#### **TRƯỚC:**
```sql
CREATE TABLE ThongSoLuong (
    ID INT PRIMARY KEY IDENTITY(1,1),
    HeSoLuongCoBan DECIMAL(10, 2) NOT NULL,
    PhuCapChucVu DECIMAL(18, 2) DEFAULT 0,
    TyLeBHXH DECIMAL(5, 2) NOT NULL,
    TyLeBHYT DECIMAL(5, 2) NOT NULL,
    TyLeBHTN DECIMAL(5, 2) NOT NULL,
    NgayApDung DATE NOT NULL  -- ❌ Theo NGÀY
);
```

#### **SAU:**
```sql
CREATE TABLE ThongSoLuong (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ChucVu NVARCHAR(50) NOT NULL,  -- ✅ Thêm chức vụ
    HeSoLuongCoBan DECIMAL(10, 2) NOT NULL,
    PhuCapChucVu DECIMAL(18, 2) DEFAULT 0,
    TyLeBHXH DECIMAL(5, 2) NOT NULL,
    TyLeBHYT DECIMAL(5, 2) NOT NULL,
    TyLeBHTN DECIMAL(5, 2) NOT NULL,
    Thang INT NOT NULL,  -- ✅ Theo THÁNG
    Nam INT NOT NULL,    -- ✅ Theo NÀM
    CONSTRAINT UQ_ThongSoLuong UNIQUE (ChucVu, Thang, Nam)
);
```

**Thay đổi:**
- ➕ Thêm cột `ChucVu` để phân biệt thông số cho từng chức vụ
- ➕ Thêm cột `Thang` và `Nam` thay cho `NgayApDung`
- ➕ Thêm UNIQUE constraint để đảm bảo mỗi chức vụ chỉ có 1 thông số/tháng/năm

### 2. Dữ liệu mẫu (SQL/Insert.sql)

#### **5 Chức vụ với thông số lương khác nhau:**

| Chức vụ | Hệ số lương (T1-6) | Phụ cấp (T1-6) | Hệ số lương (T7-12) | Phụ cấp (T7-12) |
|---------|-------------------|----------------|---------------------|-----------------|
| **Quản lý** | 8,000,000 | 2,000,000 | 8,200,000 | 2,100,000 |
| **Kế toán** | 6,000,000 | 800,000 | 6,200,000 | 850,000 |
| **Nhân viên bán hàng** | 5,000,000 | 500,000 | 5,200,000 | 550,000 |
| **Nhân viên kho** | 5,500,000 | 600,000 | 5,700,000 | 650,000 |
| **NV chăm sóc KH** | 4,800,000 | 500,000 | 5,000,000 | 550,000 |

**Đặc điểm:**
- ✅ Tất cả 5 chức vụ đều có đủ 12 tháng năm 2025
- ✅ Lương TĂNG từ tháng 7/2025 (mô phỏng tăng lương giữa năm)
- ✅ Tỷ lệ bảo hiểm giống nhau: BHXH 8%, BHYT 1.5%, BHTN 1%

### 3. Form Quản lý Bảng Lương (frmQuanLyBangLuongMoi.cs)

#### **Hàm TinhLuong() - TRƯỚC:**
```csharp
// Lấy thông số lương mới nhất (không phân biệt chức vụ, tháng)
string query = "SELECT TOP 1 * FROM ThongSoLuong ORDER BY NgayApDung DESC";
```

#### **Hàm TinhLuong() - SAU:**
```csharp
// 1. Lấy chức vụ của nhân viên
string getChucVuQuery = "SELECT Chucvu FROM Taikhoan WHERE Manguoidung = @MaNV";

// 2. Lấy thông số lương theo chức vụ, tháng và năm
string query = @"SELECT TOP 1 * FROM ThongSoLuong 
               WHERE ChucVu = @ChucVu AND Thang = @Thang AND Nam = @Nam";
```

**Thay đổi:**
- ✅ Lấy chức vụ của nhân viên trước
- ✅ Lấy thông số lương phù hợp với chức vụ và tháng/năm đang tính
- ✅ Hiển thị lỗi rõ ràng nếu chưa có thông số cho chức vụ trong tháng đó

### 4. Form Thông Số Lương (frmThongSoLuong)

#### **Giao diện cũ:**
- ❌ Chỉ có DateTimePicker để chọn ngày
- ❌ Không phân biệt chức vụ
- ❌ Chỉ hiển thị 1 thông số mới nhất

#### **Giao diện mới:**
```
┌─────────────────────────────────────────────────────────────┐
│           QUẢN LÝ THÔNG SỐ LƯƠNG                            │
├─────────────────────────────────────────────────────────────┤
│ Chức vụ: [ComboBox]  Tháng: [1-12]  Năm: [2025]           │
│ Hệ số lương: [_______]  Phụ cấp: [_______]                 │
│ BHXH: [__]  BHYT: [__]  BHTN: [__]                         │
│                                                              │
│ [➕ Thêm] [✏️ Sửa] [🗑️ Xóa] [🔄 Làm mới] [Đóng]        │
│                                                              │
│ ┌─ Danh sách thông số lương ────────────────────────────┐  │
│ │ Chức vụ │ Hệ số │ Phụ cấp │ BHXH │ BHYT │ Tháng │ Năm │  │
│ │ Quản lý │ 8M    │ 2M      │ 8%   │ 1.5% │  1    │2025 │  │
│ │ Quản lý │ 8M    │ 2M      │ 8%   │ 1.5% │  2    │2025 │  │
│ │ ...                                                      │  │
│ └─────────────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────────┘
```

**Tính năng mới:**
- ✅ **Chọn chức vụ** từ ComboBox (5 chức vụ)
- ✅ **Chọn tháng** (1-12) và **năm** (2020-2100)
- ✅ **DataGridView** hiển thị tất cả thông số lương
- ✅ **Thêm/Sửa/Xóa** thông số lương
- ✅ **Click vào bảng** để tự động load dữ liệu vào form
- ✅ **Validation** đầy đủ, không cho trùng lặp

## 💡 Cách hoạt động

### Kịch bản 1: Tính lương cho Quản lý tháng 3/2025
1. Chọn nhân viên (chức vụ: Quản lý)
2. Chọn tháng 3, năm 2025
3. Nhập số ngày công: 26
4. Hệ thống:
   - Lấy thông số lương của **Quản lý** trong **tháng 3/2025**
   - Hệ số: **8,000,000**, Phụ cấp: **2,000,000**
   - Tính: Lương CB = 8,000,000 × (26/26) = 8,000,000
   - BHXH+BHYT+BHTN = 8,000,000 × 10.5% = 840,000
   - Thực lĩnh = 8,000,000 + 2,000,000 - 840,000 = **9,160,000 VNĐ**

### Kịch bản 2: Tính lương cho Quản lý tháng 8/2025
1. Chọn cùng nhân viên (Quản lý)
2. Chọn tháng 8, năm 2025
3. Nhập số ngày công: 26
4. Hệ thống:
   - Lấy thông số lương của **Quản lý** trong **tháng 8/2025** (đã tăng!)
   - Hệ số: **8,200,000**, Phụ cấp: **2,100,000**
   - Tính: Lương CB = 8,200,000 × (26/26) = 8,200,000
   - Khấu trừ = 8,200,000 × 10.5% = 861,000
   - Thực lĩnh = 8,200,000 + 2,100,000 - 861,000 = **9,439,000 VNĐ**

➡️ **Kết quả:** Lương tăng 279,000 VNĐ do thông số lương thay đổi! ✅

### Kịch bản 3: Thêm thông số lương mới
1. Mở form "⚙️ Thông số"
2. Chọn chức vụ: **Kế toán**
3. Chọn tháng: **6**, năm: **2026**
4. Nhập:
   - Hệ số lương: 6,500,000
   - Phụ cấp: 900,000
   - BHXH: 8%, BHYT: 1.5%, BHTN: 1%
5. Click **➕ Thêm**
6. ✅ Thông số mới được lưu, áp dụng cho tất cả Kế toán từ 6/2026

## 🎯 Lợi ích của hệ thống mới

| Tính năng | Trước | Sau |
|-----------|-------|-----|
| **Phân biệt chức vụ** | ❌ Không | ✅ 5 chức vụ khác nhau |
| **Theo tháng/năm** | ❌ Theo ngày | ✅ Theo tháng và năm |
| **Tính lương chính xác** | ⚠️ Dùng chung 1 thông số | ✅ Theo chức vụ và thời điểm |
| **Tăng lương linh hoạt** | ❌ Khó | ✅ Dễ dàng thêm/sửa |
| **Quản lý thông số** | ❌ Không có form | ✅ Form đầy đủ CRUD |
| **Dữ liệu mẫu** | ⚠️ 10 bản ghi hỗn loạn | ✅ 60 bản ghi (5×12) rõ ràng |

## 📊 Bảng thông số lương mẫu (Tóm tắt)

### Tháng 1-6/2025:
- **Quản lý:** 8,000,000 + 2,000,000
- **Kế toán:** 6,000,000 + 800,000
- **NV Bán hàng:** 5,000,000 + 500,000
- **NV Kho:** 5,500,000 + 600,000
- **NV CSKH:** 4,800,000 + 500,000

### Tháng 7-12/2025 (Tăng lương):
- **Quản lý:** 8,200,000 + 2,100,000 ⬆️
- **Kế toán:** 6,200,000 + 850,000 ⬆️
- **NV Bán hàng:** 5,200,000 + 550,000 ⬆️
- **NV Kho:** 5,700,000 + 650,000 ⬆️
- **NV CSKH:** 5,000,000 + 550,000 ⬆️

## 🚀 Hướng dẫn sử dụng

### Bước 1: Chạy lại database
```sql
-- Chạy 2 file này theo thứ tự:
1. SQL/CreateTable.sql  -- Tạo lại bảng với cấu trúc mới
2. SQL/Insert.sql       -- Insert 60 bản ghi (5 chức vụ × 12 tháng)
```

### Bước 2: Sử dụng form Thông Số Lương
1. Từ form Quản lý Bảng Lương, click **⚙️ Thông số**
2. Xem danh sách thông số lương đã có
3. Để thêm mới:
   - Chọn chức vụ
   - Chọn tháng/năm
   - Nhập các giá trị
   - Click **➕ Thêm**
4. Để sửa:
   - Click vào dòng cần sửa
   - Chỉnh sửa thông tin
   - Click **✏️ Sửa**
5. Để xóa:
   - Click vào dòng cần xóa
   - Click **🗑️ Xóa**
   - Xác nhận

### Bước 3: Tính lương nhân viên
1. Chọn nhân viên (hệ thống tự động lấy chức vụ)
2. Chọn tháng/năm cần tính
3. Nhập số ngày công
4. Click **💰 Tính Lương** hoặc **➕ Thêm**
5. Hệ thống tự động:
   - Lấy thông số lương phù hợp với chức vụ và tháng/năm
   - Tính lương chính xác
   - Lưu vào database

## ⚠️ Lưu ý quan trọng

1. **Phải có thông số lương trước khi tính:**
   - Nếu tính lương tháng 5/2025 cho Kế toán
   - Phải có thông số lương của Kế toán trong tháng 5/2025
   - Nếu không có → Báo lỗi rõ ràng

2. **Không thể trùng lặp:**
   - 1 chức vụ chỉ có 1 thông số lương cho 1 tháng/năm
   - Ví dụ: Không thể có 2 thông số Quản lý tháng 3/2025

3. **Xóa thông số lương cẩn thận:**
   - Nếu xóa thông số của tháng 5/2025
   - Sẽ không thể tính lương cho tháng đó
   - Nên sửa thay vì xóa

## 🎉 Kết luận

Hệ thống thông số lương đã được nâng cấp hoàn toàn:
- ✅ Theo tháng/năm thay vì ngày
- ✅ Phân biệt 5 chức vụ rõ ràng
- ✅ Dữ liệu đầy đủ 12 tháng năm 2025
- ✅ Khi thông số thay đổi → Lương thay đổi theo
- ✅ Form quản lý đầy đủ tính năng CRUD
- ✅ Validation chặt chẽ, không lỗi

**Giờ đây bạn có thể:**
- Thay đổi thông số lương theo từng tháng
- Tăng lương riêng cho từng chức vụ
- Tính lương chính xác dựa trên chức vụ và thời điểm
- Quản lý lịch sử thông số lương dễ dàng

🎊 Hệ thống đã sẵn sàng sử dụng!
