create database CoffeeApp
go

use CoffeeApp
go

create table dbo.LoaiSanPham(
	id_loai int identity primary key,
	tenloai	nvarchar(200) not null,
	mota	nvarchar(MAX),
	hinhanh varchar(max)
)
go
create table dbo.SanPham(
	id_sanpham int identity primary key,
	tensanpham nvarchar(200) not null,
	id_loai	int,
	hinhanh varchar(max),
	gia float,
	mota nvarchar(max),
	soluong int,
)
go
create table dbo.KhachHang(
	id_khachhang int identity primary key,
	id_taikhoan int,
	hoten		nvarchar(50),
	gioitinh	nvarchar(10) check(gioitinh in('Nam',N'Nữ')),
	diachi		nvarchar(250),
	sdt			int,
	diem float
)
go
create table dbo.TaiKhoan(
	id_taikhoan int identity primary key,
	loaitk	nvarchar(15) check(loaitk in(N'Nhân Viên',N'Quản Lý',N'Khách Hàng')) default N'Khách Hàng',
	taikhoan	nvarchar(50),
	matkhau		nvarchar(50),	
)

create table dbo.NhanVien(
	id_nhanvien int identity primary key,
	id_taikhoan int,
	id_calamviec int,
	hoten		nvarchar(50),
	gioitinh	nvarchar(10) check(gioitinh in('Nam',N'Nữ')),
	diachi		nvarchar(250),
	sdt			int,
	tonggiolam int,
	tongtien float,
)
go
create table dbo.CaLamViec(
	id_calamviec int identity primary key,
	tenca	nvarchar(100),
	thoigianbatdau	datetime,
	thoigianketthuc	datetime,
	luong	float
)
go
create table dbo.HoaDon(
	id_hoadon int identity primary key,
	id_khachhang int,
	thoigian varchar(50),
	tonggia float,
	discount int,
	diemcong float,
	soluong int,
	trangthai nvarchar(50) check(trangthai in(N'Chưa Thanh Toán',N'Đã Thanh Toán')) default N'Chưa Thanh Toán',

)
go
create table dbo.HoaDonCT(
	id_hoadonct int identity primary key,
	id_hoadon int,
	id_sanpham int,
	id_loai int,
	soluong int,
	discount int default 0,
	dongia float
)
go
create table dbo.OutBill(
	id_outbill int identity primary key,
	thoigian datetime,
	id_sanpham int,
	id_loai int,
	id_khachhang int,
	tensanpham nvarchar(200),
	tenloai nvarchar(200),
	trangthai nvarchar(50) default N'Đã Xuất Bill',
	dongia float,
	tonggia float
)
go
create table dbo.History(
	id_history int identity primary key,
	actions nvarchar(50) check(actions in('Add','Delete','Update','OutBill')),
	thoigian datetime,
	tensanpham nvarchar(200)
)
go
create table dbo.ThongKe(
	id_thongke int identity primary key,
	thoigian			datetime,
	sltonkho				int,
	slxuatkho				int,
	nvtongluong			int,
	nvungtruoc			int,
	nvtichcuc			int,
	tongchi				float,
	tongthu				float,
	doanhthu			float,
)
go

create table [dbo.Table](
	id_table int identity primary key,
	id_nhanvien int,
	tentable nvarchar(15),
	null_full nvarchar(50) check(null_full in(N'Bàn Trống',N'Đã Có Khách')) default N'Đã Có Khách',
	yesbill_nobill nvarchar(50) check(yesbill_nobill in(N'Chưa Thanh Toán',N'Đã Thanh Toán')) default N'Chưa Thanh Toán',
	thoigian datetime DEFAULT GETDATE(),
	int_out nvarchar(50) check(int_out in(N'Chưa Rời Đi',N'Đã Rời Đi')) default N'Chưa Rời Đi',
)
go

ALTER TABLE [dbo.Table]
ADD CONSTRAINT FK_Table_NhanVien
FOREIGN KEY (id_nhanvien) REFERENCES dbo.NhanVien(id_nhanvien) ON DELETE SET NULL

create table dbo.TableCT(
	id_tablect int identity primary key,
	id_table int,
	loaisanpham nvarchar(200),
	tensanpham nvarchar(200),
	gia float,
	soluong int,
	thanhtien float
)
ALTER TABLE dbo.TableCT
ADD CONSTRAINT FK_TableCT_Table
FOREIGN KEY (id_table) REFERENCES [dbo.Table](id_table) ON DELETE SET NULL

ALTER TABLE dbo.KhachHang
ADD CONSTRAINT FK_KhachHang_TaiKhoan
FOREIGN KEY (id_taikhoan) REFERENCES dbo.TaiKhoan(id_taikhoan) ON DELETE SET NULL

ALTER TABLE dbo.NhanVien
ADD CONSTRAINT FK_NhanVien_TaiKhoan
FOREIGN KEY (id_taikhoan) REFERENCES dbo.TaiKhoan(id_taikhoan) ON DELETE SET NULL

ALTER TABLE dbo.NhanVien
ADD CONSTRAINT FK_NhanVien_CaLamViec
FOREIGN KEY (id_calamviec) REFERENCES dbo.CaLamViec(id_calamviec) ON DELETE SET NULL

ALTER TABLE dbo.SanPham
ADD CONSTRAINT FK_SanPham_LoaiSanPham
FOREIGN KEY (id_loai) REFERENCES dbo.LoaiSanPham(id_loai) ON DELETE SET NULL

ALTER TABLE dbo.HoaDon
ADD CONSTRAINT FK_HoaDon_KhachHang
FOREIGN KEY (id_khachhang) REFERENCES dbo.KhachHang(id_khachhang) ON DELETE SET NULL

ALTER TABLE dbo.HoaDonCT
ADD CONSTRAINT FK_HoaDonCT_HoaDon
FOREIGN KEY (id_hoadon) REFERENCES dbo.HoaDon(id_hoadon) ON DELETE SET NULL
ALTER TABLE dbo.HoaDonCT
ADD CONSTRAINT FK_HoaDonCT_SanPham
FOREIGN KEY (id_sanpham) REFERENCES dbo.SanPham(id_sanpham) ON DELETE SET NULL
ALTER TABLE dbo.HoaDonCT
ADD CONSTRAINT FK_HoaDonCT_LoaiSanPham
FOREIGN KEY (id_loai) REFERENCES dbo.LoaiSanPham(id_loai) ON DELETE SET NULL

create table dbo.Coupon(
	id_coupon int identity primary key,
	id_khachhang int,
	tencoupon nvarchar(150),
	lifetime varchar(10),
	thestart varchar(20),
	theend varchar(20),
	discount varchar(10),
	status nvarchar(50) check(status in(N'Chưa Sử Dụng',N'Đã Sử Dụng',N'Đã Hết Hạn')) default N'Chưa Sử Dụng',
	Ma_Coupon varchar(50)
)

ALTER TABLE dbo.Coupon
ADD CONSTRAINT FK_Coupon_KhachHang
FOREIGN KEY (id_khachhang) REFERENCES dbo.KhachHang(id_khachhang) ON DELETE SET NULL
go

alter trigger trg_RamdomCoupon on dbo.Coupon after insert
as declare @ramdom varchar(50)
begin
	set @ramdom = ''
	SELECT @ramdom = SUBSTRING(CONVERT(varchar(50), NEWID()),0,9)

	if(@ramdom!='')
		begin 
			update dbo.Coupon set Ma_Coupon= @ramdom
			where id_coupon = (select id_coupon from inserted)
		end
end
go

select *from dbo.HoaDon
select *from dbo.TaiKhoan
SELECT MONTH(CAST('11/12/2020' AS date)) AS Result;

alter table dbo.ThongKe
add tenthongke nvarchar(10)