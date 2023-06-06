Create database QuanLyBanHang

use QuanLyBanHang

Create table Hang
(
	MaHang char(10) not null,
	TenHang nvarchar(50),
	MaChatLieu char(10) not null,
	SoLuong int,
	DonGiaNhap int,
	DonGiaBan int,
	Anh nvarchar(30),
	GhiChu nvarchar(50)
)
Create table NhanVien
(
	MaNV char(10) not null,
	TenNV nvarchar(50),
	GioiTinh nvarchar(3),
	DiaChi nvarchar(50),
	DienThoai nvarchar(10),
	NgaySinh dateTime
)
Create table ChiTietHDBan
(
	MaHDBan char(10) not null,
	MaHang char(10) not null,
	SoLuong int,
	DonGia int,
	GiamGia int,
	ThanhTien int
)
Create table HDBan
(
	MaHDBan nvarchar(10) not null,
	MaNV nvarchar(10) not null,
	MaHang nvarchar(10) not null,
	NgayBan dateTime,
	MaKhach nvarchar(10) not null,
	TongTien int
)
Create table Khach
(
	MaKhach char(10) not null,
	TenKhach char(10),
	DiaChi nvarchar(50),
	DienThoai nvarchar(10)
)
Create table ChatLieu
(
	MaChatLieu char(10) not null,
	TenChatLieu nvarchar(50) 
)
-- khóa chính
Alter table Hang 
	Add constraint PK_Hang primary key(MaHang)
Alter table NhanVien
	Add constraint PK_NhanVien primary key(MaNV)
Alter table ChiTietHDBan
	Add constraint PK_ChiTietHDBan primary key(MaHDBan,MaHang)
Alter table HDBan
	Add constraint PK_HDBan primary key(MaHDBan)
Alter table Khach
	Add constraint PK_Khach primary key(MaKhach)
Alter table ChatLieu
	Add constraint PK_ChatLieu primary key(MaChatLieu)

--add dữ liệu
Insert into Hang(MaHang,TenHang,MaChatLieu,SoLuong,DonGiaNhap,Anh,GhiChu)
Values	('CC','Ca chua','SD',3,3000,'cc.jpg','ca chua heo'),
		('DH','Dua hau','SB',4,2000,'dh.jpg','dua khong hat'),
		('CR','Ca rot','K',5,4000,'cr.jpg','ca rot hu');

Insert into NhanVien(MaNV,TenNV,GioiTinh,DiaChi,DienThoai,NgaySinh)
Values	('01','Huy','Nam','Binh Dinh','0836647384','03/08/2003'),
		('02','Tien','Nu','Lam Dong con','0963748123','06/11/2002'),
		('03','Thien','Nam','Bac ky','0343867481','06/02/2005'),
		('04','Vuong','Nu','Bao dong nai','0963547123','12/03/2002');

Insert into ChiTietHDBan(MaHDBan,MaHang,SoLuong,DonGia,GiamGia,ThanhTien)
Values	('001','CC',2,3000,300,2700),
		('002','DH',3,4000,400,3600),
		('003','CR',4,5000,600,4400);

Insert into HDBan(MaHDBan,MaNV,MaHang,NgayBan,MaKhach,TongTien)
Values	('001','01','CC','09/10/2012','KH01',2700),
		('002','02','DH','12/09/2002','KH02',3600),
		('003','03','CR','04/11/2014','KH03',4400);

Insert into Khach(MaKhach,TenKhach,DiaChi,DienThoai)
Values	('KH01','Tien','Lam Dong con','0832321475'),
		('KH02','Thien','Bac ky','0763748271'),
		('KH03','Vuong','Bao dong nai','0875437631');

Insert into ChatLieu(MaChatLieu,TenChatLieu)
Values	('SB','Sua bao'),
		('SD','Sua dac'),
		('K','Kem');
--Lấy dữ liệu từ database về table--
create proc getDataFrom(@nameTable nvarchar(20))
as
	exec ('select * From dbo.['+@nameTable+']');
--NHÂN VIÊN-------------
	exec getDataFrom'NhanVien';
--add
create proc insertDataNhanVien(@MaNV char(10), @TenNV nvarchar(30), @GioiTinh nvarchar(3), @DiaChi nvarchar(50), @DienThoai nvarchar(10), @NgaySinh datetime)
as
	insert into NhanVien(MaNV,TenNV,GioiTinh,DiaChi,DienThoai,NgaySinh) Values(@MaNV,@TenNV,@GioiTinh,@DiaChi,@DienThoai,@NgaySinh);
	exec insertDataNhanVien '06','Huy','Nam','Binh Dinh','0836647384','03/08/2003'
--update
create proc updateDataNhanVien(@MaNV char(10), @TenNV nvarchar(30), @GioiTinh nvarchar(3), @DiaChi nvarchar(50),@DienThoai nvarchar(10), @NgaySinh datetime)
as
	update NhanVien set TenNV= @TenNV, GioiTinh= @GioiTinh, DiaChi= @DiaChi,DienThoai= @DienThoai, NgaySinh= @NgaySinh WHERE MaNV= @MaNV;
	exec updateDataNhanVien '12','Hai','Nam','Binh Dinh','0836647384','03/08/2003'
--delete
create proc deleteDataNhanVien(@MaNV char(10))
as
	delete from NhanVien WHERE MaNV= @MaNV;
	exec deleteDataNhanVien'12';
--find
create proc findDataNhanVien(@TenNV nvarchar(30))
as
	select * from NhanVien Where TenNV like '%'+@TenNV+'%'
	exec findDataNhanVien'Huy';


--KHACH------------
--Thêm dữ liệu vào bảng khách--
create proc insertDataKhach(@maKhach nvarchar(10), @tenKhach nvarchar(50), @diaChi nvarchar(50), @dThoai nvarchar (10))
as
	insert into Khach(MaKhach, TenKhach, DiaChi, DienThoai) values (@maKhach, @tenKhach, @diaChi, @dThoai)

--Sửa thông tin bảng Khách--
create proc updateDataKhach(@maKhach nvarchar(10), @tenKhach nvarchar(50), @diaChi nvarchar(50), @dThoai nvarchar (10))
as 
	update Khach set TenKhach = @tenKhach, DiaChi = @diaChi, DienThoai = @dThoai where MaKhach = @maKhach

--Xóa thông tin bảng khách--
create proc deleteDataKhach(@maKhach nvarchar(10))
as
	delete from Khach where MaKhach = @maKhach

--Tìm kiếm thông tin bảng khách--
create proc findDataKhach(@ma nvarchar(10))
as
	select * from Khach where MaKhach like '%'+@ma+'%' or TenKhach like '%'+@ma+'%'

	exec findDataKhach'Thien'

--Them du lieu vao bang chat lieu
create proc insertDataChatLieu(@maClieu nvarchar(10), @tenClieu nvarchar(50))
as
	insert into ChatLieu(MaChatLieu, TenChatLieu) values (@maClieu, @tenClieu)

--Sửa thông tin bảng Chất Liệu--
create proc updateDataChatLieu(@maClieu nvarchar(10), @tenClieu nvarchar(50))
as 
	update ChatLieu set TenChatLieu = @tenClieu where MaChatLieu = @maClieu

--Xóa thông tin bảng Chất Liệu--
create proc deleteDataChatLieu(@maClieu nvarchar(10))
as
	delete from ChatLieu where MaChatLieu = @maClieu

--Tìm kiếm thông tin bảng Chất Liệu--
create proc findDataChatLieu(@ma nvarchar(10))
as
	select * from ChatLieu where MaChatLieu like '%'+@ma+'%'
--CHẤT LIỆU-----------

--Them du lieu vao bang chat lieu
create proc insertDataChatLieu(@maClieu nvarchar(10), @tenClieu nvarchar(50))
as
	insert into ChatLieu(MaChatLieu, TenChatLieu) values (@maClieu, @tenClieu)

--Sửa thông tin bảng Chất Liệu--
create proc updateDataChatLieu(@maClieu nvarchar(10), @tenClieu nvarchar(50))
as 
	update ChatLieu set TenChatLieu = @tenClieu where MaChatLieu = @maClieu

--Xóa thông tin bảng Chất Liệu--
create proc deleteDataChatLieu(@maClieu nvarchar(10))
as
	delete from ChatLieu where MaChatLieu = @maClieu

--Tìm kiếm thông tin bảng Chất Liệu--
create proc findDataChatLieu(@ma nvarchar(10))
as
	select * from ChatLieu where MaChatLieu like '%'+@ma+'%'

--HÀNG----------------
--thêm Hàng
create proc insertDataHang(@MaHang nvarchar(10),@TenHang nvarchar(50),@MaChatLieu nvarchar(10),@SoLuong int,@DonGiaNhap int, @DonGiaBan int,@Anh nvarchar(30),@GhiChu nvarchar(50))
as 
insert into Hang (MaHang,TenHang,MaChatLieu,SoLuong,DonGiaNhap,DonGiaBan,Anh,GhiChu) values (@MaHang,@TenHang,@MaChatLieu,@SoLuong,@DonGiaNhap,@DonGiaBan,@Anh,@GhiChu)
 exec insertDataHang 'CC11','Ca chua','SD',3,3000,3000,'cc.jpg','ca chua heo'

--xóa hàng
create proc deleteDataHang(@MaHang nvarchar(10))
as
delete from Hang where MaHang = @MaHang
exec deleteDataHang 'CC'

--xoa hang
create proc updateDataHang(@MaHang nvarchar(10),@TenHang nvarchar(50),@MaChatLieu nvarchar(10),@SoLuong int,@DonGiaNhap int, @DonGiaBan int,@Anh nvarchar(30),@GhiChu nvarchar(50))
as
update Hang set TenHang = @TenHang, MaChatLieu = @MaChatLieu, SoLuong = @SoLuong, DonGiaNhap =  @DonGiaNhap, DonGiaBan = @DonGiaBan, Anh = @Anh, GhiChu = @GhiChu where MaHang = @MaHang
exec updateDataHang 'CC12','Ca chua1','SD1',3,3000,3000,'cc.jpg','ca chua heo'

-- tìm hàng
create proc findDataHang(@TenHang nvarchar(50))
as
select * from Hang, ChatLieu where TenHang like '%'+@TenHang+'%' AND Hang.MaChatLieu = ChatLieu.MaChatLieu
exec findDataHang 'Ca chua1'



-----HÓA ĐƠN------------


create proc insertDataHoaDon(@MaHDBan nvarchar(10),@MaNV nvarchar(10),@MaHang nvarchar(10),@NgayBan dateTime,@MaKhach nvarchar(10),@TongTien int)
as
	insert into HDBan(MaHDBan ,MaNV ,MaHang ,NgayBan,MaKhach ,TongTien)  values(@MaHDBan,@MaNV,@MaHang,@NgayBan ,@MaKhach ,@TongTien)
	exec insertDataHoaDon'0044','01','CC','09/10/2012','KH01',2700
go


create proc updateDataHoaDon(@MaHDBan nvarchar(10),@MaNV nvarchar(10),@MaHang nvarchar(10),@NgayBan dateTime,@MaKhach nvarchar(10),@TongTien int)
as
	update HDBan  set MaNV = @MaNV, MaHang = @MaHang, NgayBan = @NgayBan, MaKhach = @MaKhach, TongTien = @TongTien where MaHDBan = @MaHDBan
	exec updateDataHoaDon'004','01','CC','09/10/2012','KH01',2800
go


create proc deleteDataHoaDon(@MaHDBan nvarchar(10))
as
	delete from HDBan where MaHDBan = @MaHDBan
	exec deteleDataHoaDon'004'
go

create proc findDataHoaDon(@Ma nvarchar(10))
as
	select * from HDBan where MaHDBan like '%'+@Ma+'%' or MaHang like '%'+@Ma+'%' or MaKhach like '%'+@Ma+'%'
	exec findDataHoaDon'c'
go