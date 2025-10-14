# HƯỚNG DẪN SỬ DỤNG HỆ THỐNG KẾ TOÁN

## Tổng quan
Hệ thống quản lý kế toán cho nhà thuốc với đầy đủ các chức năng:
- Quản lý bảng lương nhân viên
- Quản lý công nợ
- Báo cáo chi phí nhập/bán hàng

## Các chức năng đã triển khai

### 1. **Use Case: Chỉnh sửa thông số bảng lương**
- **Form:** `frmThongSoLuong.cs`
- **Chức năng:** 
  - Cho phép Kế toán điều chỉnh các thông số bảng lương của nhân viên
  - Hệ số lương cơ bản (VNĐ)
  - Phụ cấp chức vụ (VNĐ)
  - Tỷ lệ bảo hiểm xã hội (%)
  - Tỷ lệ bảo hiểm y tế (%)
  - Tỷ lệ bảo hiểm thất nghiệp (%)
  - Ngày áp dụng
- **Lưu ý:** Hệ thống sẽ lưu lịch sử thông số lương, áp dụng thông số mới nhất khi tính lương

### 2. **Use Case: Cập nhật bảng lương**
- **Form:** `frmQuanLyBangLuongMoi.cs`
- **Chức năng:**
  - Chọn nhân viên cần tính lương
  - Chọn tháng/năm và nhập số ngày công thực tế
  - Tính toán và cập nhật bảng lương
  - Hiển thị danh sách bảng lương đã tạo
- **Công thức tính:**
  - Lương cơ bản = Hệ số lương × Số ngày công / 26
  - Tổng bảo hiểm = Lương cơ bản × (BHXH% + BHYT% + BHTN%) / 100
  - Thực lĩnh = Lương cơ bản + Phụ cấp - Tổng bảo hiểm

### 3. **Use Case: Thêm công nợ**
- **Form:** `frmThemCongNo.cs`
- **Chức năng:**
  - Thêm khoản nợ mới cho Khách hàng hoặc Nhà cung cấp
  - Chọn loại đối tượng (Khách hàng/NCC)
  - Nhập số tiền nợ, ngày phát sinh, lý do
  - Hệ thống tự động ghi nhận người tạo

### 4. **Use Case: Xóa công nợ**
- **Form:** `frmXoaCongNo.cs`
- **Chức năng:**
  - Hiển thị danh sách công nợ
  - Tìm kiếm công nợ theo tên đối tượng hoặc lý do
  - Xóa khoản công nợ đã thanh toán
  - Xác nhận trước khi xóa

### 5. **Use Case: Xem chi phí nhập hàng**
- **Form:** `frmChiPhiNhapHang.cs`
- **Chức năng:**
  - Thống kê chi phí nhập hàng theo khoảng thời gian
  - Hiển thị danh sách phiếu nhập hàng
  - Tính tổng chi phí nhập hàng
  - Double-click để xem chi tiết từng phiếu nhập
  - Xuất báo cáo (đang phát triển)

### 6. **Use Case: Xem chi phí bán hàng**
- **Form:** `frmChiPhiBanHang.cs`
- **Chức năng:**
  - Thống kê doanh thu, giá vốn, lợi nhuận theo khoảng thời gian
  - Hiển thị danh sách đơn hàng với thông tin:
    - Doanh thu (tổng tiền bán)
    - Giá vốn (tổng tiền nhập)
    - Lợi nhuận (Doanh thu - Giá vốn)
  - Tính tỷ lệ lợi nhuận (%)
  - Double-click để xem chi tiết từng đơn hàng
  - Xuất báo cáo (đang phát triển)

## Cấu trúc dự án

### Files chính
1. **frmMenuChinh.cs** - Menu điều hướng chính
2. **frmQuanLyBangLuongMoi.cs** - Quản lý bảng lương
3. **frmThongSoLuong.cs** - Chỉnh sửa thông số lương
4. **frmThemCongNo.cs** - Thêm công nợ mới
5. **frmXoaCongNo.cs** - Quản lý và xóa công nợ
6. **frmChiPhiNhapHang.cs** - Thống kê chi phí nhập hàng
7. **frmChiPhiBanHang.cs** - Thống kê chi phí bán hàng

### Database
- **CreateTable.sql** - Script tạo database
- **Insert.sql** - Script insert dữ liệu mẫu
- **Connection String:** Đã cấu hình trong mỗi form

## Hướng dẫn sử dụng

### Bước 1: Chuẩn bị Database
1. Mở SQL Server Management Studio
2. Chạy script `SQL/CreateTable.sql` để tạo database
3. Chạy script `SQL/Insert.sql` để thêm dữ liệu mẫu

### Bước 2: Cấu hình Connection String
Cập nhật connection string trong các file form nếu cần:
```csharp
string connectionString = @"Data Source=YOUR_SERVER;Initial Catalog=NhaThuocDB;Integrated Security=True;TrustServerCertificate=True";
```

### Bước 3: Chạy ứng dụng
1. Build solution trong Visual Studio
2. Chạy ứng dụng
3. Form menu chính sẽ hiển thị với các chức năng đã được phân nhóm

## Luồng sử dụng gợi ý

### Quy trình tính lương nhân viên
1. **Thiết lập thông số lương** (lần đầu hoặc khi có thay đổi)
   - Mở "Chỉnh sửa thông số bảng lương"
   - Nhập các thông số và lưu
   
2. **Cập nhật bảng lương hàng tháng**
   - Mở "Cập nhật bảng lương"
   - Chọn nhân viên, tháng/năm
   - Nhập số ngày công
   - Nhấn "Tính Lương" để xem preview
   - Nhấn "Lưu Bảng Lương" để lưu vào database

### Quy trình quản lý công nợ
1. **Thêm công nợ mới**
   - Mở "Thêm công nợ mới"
   - Chọn loại đối tượng (Khách hàng/NCC)
   - Nhập thông tin và lưu
   
2. **Xóa công nợ đã thanh toán**
   - Mở "Xóa công nợ"
   - Tìm kiếm khoản nợ cần xóa
   - Chọn và xóa

### Quy trình báo cáo
1. **Xem chi phí nhập hàng**
   - Chọn khoảng thời gian
   - Nhấn "Thống kê"
   - Xem tổng chi phí và chi tiết

2. **Xem chi phí bán hàng**
   - Chọn khoảng thời gian
   - Nhấn "Thống kê"
   - Xem doanh thu, giá vốn, lợi nhuận

## Ghi chú kỹ thuật

### Validation
- Tất cả các form đều có validation đầu vào
- Kiểm tra trùng lặp bảng lương (1 nhân viên/tháng/năm)
- Xác nhận trước khi xóa dữ liệu

### Tính toán
- Sử dụng DECIMAL(18,2) cho các giá trị tiền tệ
- Computed columns trong database cho các tổng tiền
- Tính toán lợi nhuận = Doanh thu - Giá vốn

### Hiển thị
- Format tiền tệ: N0 (không có số thập phân, có dấu phân cách hàng nghìn)
- Format ngày: dd/MM/yyyy hoặc dd/MM/yyyy HH:mm
- Màu sắc phân biệt: Xanh cho lợi nhuận, Đỏ cho chi phí

## Mở rộng tương lai
- Export báo cáo ra Excel/PDF
- Gửi email thông báo lương
- Tính thuế thu nhập cá nhân
- Quản lý phép năm, overtime
- Dashboard tổng quan

## Liên hệ hỗ trợ
Nếu có vấn đề kỹ thuật, vui lòng kiểm tra:
1. Connection string đã đúng chưa
2. Database đã được tạo và có dữ liệu chưa
3. Các reference trong project đã đầy đủ chưa
