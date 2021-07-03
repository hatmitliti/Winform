create database QuanLiSinhVien 

use QuanLiSinhVien 
-- create table sinh vien--- 
create table SinhVien 
(
   MaSVID char(6) not null
   ,HoSV nvarchar(30)
   ,TenSV nvarchar(15)
   ,GioiTinh nvarchar(6)
   ,NgaySinh date
   ,NoiSinh nvarchar(50)
   ,DiaChi nvarchar(50)
   ,MaKhoa char(6)
 )
alter table SinhVien add constraint PK_SinhVien primary key (MaSVID)

-- create table Khoa--- 
create table Khoa
(
MaKhoaID char(6) not null
,TenKhoa nvarchar(30)
)
alter table Khoa add constraint PK_Khoa primary key (MaKhoaID)

-- create table Giang Vien--- 
create table GiangVien
(
    MaGVID char(6) not null
   ,TenGV nvarchar(45)
   ,GioiTinh nvarchar(6)
   ,MaKhoa char(6)
)
alter table GiangVien add constraint PK_GiangVien primary key (MaGVID)

-- create table Mon Hoc--- 
create table MonHoc
(
MaMHID char(6) not null
,TenMH nvarchar(30)
,SoTiet int
,MaKhoa char(6)
,MaGV char(6)
)
alter table MonHoc add constraint PK_MonHoc primary key (MaMHID)

-- create table Ket Qua---
create table KetQua 
(
MaSVID char(6) not null
,MaMHID char(6) not null
,TenMH nvarchar(30)
,DiemThi Decimal(4,2)
) 
alter table KetQua add constraint PK_KetQua primary key (MaSVID,MaMHID)

-- create table Thoi Khoa Bieu---
create table ThoiKhoaBieu
(
MaLopID char(10) not null
,MaSV char(6) 
,Thu nvarchar(15)
,buoi nvarchar(15)
,ThoiGian nvarchar(15)
,Phong varchar(10)
,MaMH char(6)
,MaGV char(6)
)
alter table ThoiKhoaBieu add constraint PK_ThoiKhoaBieu primary key (MaLopID)

-- create table account---
create table Account
(
TaiKhoan char(6) not null
,MatKhau char(50)not null
,PhanQuyen nvarchar(30)
)
alter table account add constraint PK_Account primary key(TaiKhoan)

--- drop table --- 
drop table SinhVien
Drop table Khoa
drop table GiangVien
drop table MonHoc
drop table KetQua
drop table ThoiKhoaBieu
-- Foreignkey-- 
alter table KetQua add constraint FK_SinhVien_KetQua foreign key (MaSVID) references SinhVien(MaSVID)
alter table KetQua add constraint FK_MonHoc_KetQua foreign key (MaMHID) references MonHoc(MaMHID)
alter table SinhVien add constraint FK_Khoa_SinhVien foreign key (MaKhoa) references Khoa(MaKhoaID)
alter table MonHoc add constraint FK_Khoa_MonHoc foreign key (MaKhoa) references Khoa(MaKhoaID)
alter table GiangVien add constraint FK_Khoa_GiangVien foreign key (MaKhoa) references Khoa(MaKhoaID)
alter table MonHoc add constraint FK_GiangVien_MonHoc foreign key (MaGV) references GiangVien(MaGVID)
alter table ThoiKhoaBieu add constraint FK_ThoiKhoaBieu_MonHoc foreign key (MaMH) references MonHoc(MaMHID)
alter table ThoiKhoaBieu add constraint FK_ThoiKhoaBieu_GiangVien foreign key (MaGV) references GiangVien(MaGVID)
alter table ThoiKhoaBieu add constraint FK_ThoiKhoaBieu_SinhVien foreign key (MaSV) references SinhVien(MaSVID)
-- drop key -- 
alter table KetQua drop constraint FK_SinhVien_KetQua
alter table KetQua drop constraint FK_MonHoc_KetQua
alter table Khoa drop constraint FK_Khoa_SinhVien



insert into Khoa(MaKhoaID,TenKhoa)
	values('TT',N'Công NGhệ Thông Tin')
	,('OTO',N'Công Nghệ Kĩ Thuật ÔTô')
	,('CNC',N'Kỹ Thuật Cơ Khí')
	,('TA',N'Tiếng Anh')
	,('DL',N'Du Lịch')
	,('NH',N'Nhà Hàng')
	,('DCN',N'Điện Công Nghiệp')

-- Giang Vien CNTT -- 
insert into GiangVien(MaGVID,TenGV,GioiTinh,MaKhoa)
values('GV1',N'Phạm Ngọc Đại',N'Nam','TT')
,('GV2',N'Phan Gia Phước',N'Nam','TT')
,('GV3',N'Mai Kỷ Tuyên',N'Nữ','TT')
-- Giang Vien TA -- 
insert into GiangVien(MaGVID,TenGV,GioiTinh,MaKhoa)
values('GV4',N'Phạm Ngọc Anh Chương',N'Nam','TA')
,('GV5',N'Phan Gia Minh',N'Nam','TA')
,('GV6',N'Mai Kỷ Nguyên',N'Nữ','TA')
-- Giang Vien DL-- 
insert into GiangVien(MaGVID,TenGV,GioiTinh,MaKhoa)
values('GV7',N'Phạm Ngọc Thạch',N'Nam','DL')
,('GV8',N'Phan Gia Huy',N'Nam','DL')
,('GV9',N'Mai Kỷ Hà',N'Nữ','DL')

-- Giang Vien OTO -- 
insert into GiangVien(MaGVID,TenGV,GioiTinh,MaKhoa)
values('GV10',N'Phạm Ngọc Nam',N'Nam','OTO')
,('GV11',N'Phan Gia Anh',N'Nam','OTO')
,('GV12',N'Mai Kỷ Lý',N'Nữ','OTO')

-- Giang Vien CK -- 
insert into GiangVien(MaGVID,TenGV,GioiTinh,MaKhoa)
values('GV13',N'Phạm Ngọc Chí',N'Nam','CNC')
,('GV14',N'Phan Gia Tuấn',N'Nam','CNC')
,('GV15',N'Mai Hoàng Thảo',N'Nữ','CNC')
-- Giang Vien DCN -- 
insert into GiangVien(MaGVID,TenGV,GioiTinh,MaKhoa)
values('GV16',N'Phạm Ngọc Hiếu',N'Nam','DCN')
,('GV17',N'Phan Gia Đáng',N'Nam','DCN')
,('GV18',N'Mai Hoàng Hồ',N'Nữ','DCN')
-- Giang Vien NH -- 
insert into GiangVien(MaGVID,TenGV,GioiTinh,MaKhoa)
values('GV19',N'Phạm Ngọc Thuận',N'Nữ','NH')
,('GV20',N'Phan Gia Thắng',N'Nam','NH')
,('GV21',N'Mai Hoàng Hậu',N'Nữ','NH')


insert into SinhVien(MaSVID,HoSV,TenSV,GioiTinh,NgaySinh,NoiSinh,DiaChi,MaKhoa)
values('TT1485',N'Trần Ngọc',N'Nam',N'Nam','2001/01/25',N'Đồng Nai',N'Xuân Lộc, Đồng Nai','TT')
,('OTO123',N'Trần Ngọc', N'Quân',N'Nam','2001/12/01',N'Kiên Giang',N'Xuân Lộc, Kiên Giang','OTO')
,('NH124',N'Trần Ngọc ',N'Thái',N'Nam','2001/02/25',N'Bà Rịa Vũng Tàu',N'Xuân Lộc, Bà Rịa Vũng Tàu','NH')
,('TA129',N'Trần Ngọc ',N'Hiền',N'Nữ','2001/02/25',N'Quãng Ngãi',N'Xuân Lộc, Quãng Ngãi','TA')
,('CNC127',N'Trần Ngọc' ,N'Toàn',N'Nam','2001/02/25',N'Bình Định',N'Xuân Lộc, Bình Định','CNC')
,('DCN115',N'Trần Ngọc' ,N'Vũ',N'Nam','2001/02/25',N'Ninh Thuận',N'Xuân Lộc, Ninh Thuận','DCN')
,('DL127',N'Trần Ngọc' ,N'Quý',N'Nam','2001/02/25',N'Bình Thuận',N'Xuân Lộc, Bình Thuận','DL')

--Mon Hoc Nganh CNTT --- 
insert into MonHoc(MaMHID,TenMH,SoTiet,MaKhoa,MaGV)
values('LTHDT',N'Lập Trình Hướng Đối Tượng','3','TT','GV1')
,('CTDLGT',N'Cấu Trúc Dữ Liệu và Giải Thuật','3','TT','GV1')
,('CSDL',N'Cơ Sở Dữ Liệu','3','TT','GV2')
,('LTFE1',N'Lập Trình FrontEnd1','3','TT','GV3')
--Mon Hoc Nganh Co Khi --- 
insert into MonHoc(MaMHID,TenMH,SoTiet,MaKhoa,MaGV)
values('KTCK',N'Kỹ Thuật Cơ Khí','2','CNC','GV13')
,('KTH',N'Kỹ Thuật Hàn','2','CNC','GV13')
,('VKT',N'Vẽ Kỹ Thuật','2','CNC','GV14')
,('CNKL',N'Công Nghệ Kim Loại','2','CNC','GV15')
--Mon Hoc Nganh NN Anh --- 
insert into MonHoc(MaMHID,TenMH,SoTiet,MaKhoa,MaGV)
values('RD',N'Reading','3','TA','GV4')
,('WT',N'Writing','3','TA','GV4')
,('LN',N'Listening','3','TA','GV5')
,('CMN',N'Comunication','3','TA','GV6')
--Mon Hoc Nganh Nha Hang --- 
insert into MonHoc(MaMHID,TenMH,SoTiet,MaKhoa,MaGV)
values('TVNH',N'Tạp Vụ Nhà Hàng','3','NH','GV19')
,('KTCBMA',N'Kỹ Thuật Chế Biến Món Ăn','3','NH','GV19')
,('KTTTMA',N'Kỹ Thuật Trang Trí Món Ăn','3','NH','GV20')
,('KTPC',N'Kỹ Thuật Pha Chế','3','NH','GV21')
--Mon Hoc Nganh Dien Cong NGhiep --- 
insert into MonHoc(MaMHID,TenMH,SoTiet,MaKhoa,MaGV)
values('KTDCB',N'Kỹ Thuật Điện Cơ Bản','3','DCN','GV16')
,('ATD',N'An Toàn Điện','3','DCN','GV16')
,('TKHTD',N'thiết kế hệ thống Điện','3','DCN','GV17')
,('VHHTD',N'vận hành hệ thống điện','3','DCN','GV18')
--Mon Hoc Nganh Ky thuat oto --- 
insert into MonHoc(MaMHID,TenMH,SoTiet,MaKhoa,MaGV)
values('CKOTO',N'Cơ khí Ô tô','3','OTO','GV10')
,('A3D',N'Autocad 3D','3','OTO','GV10')
,('LTGOTO',N'Lý thuyết gầm Ô tô','3','OTO','GV11')
,('TTDC1',N'Thực tập động cơ 1','3','OTO','GV12')
--Mon Hoc Nganh Du lich --- 
insert into MonHoc(MaMHID,TenMH,SoTiet,MaKhoa,MaGV)
values('DLVNTG',N'Địa Lí Việt Nam và Thế Giới','3','DL','GV7')
,('QHQTLT',N'Quan Hệ Quốc Tế và  Lễ Tân','3','DL','GV7')
,('GTKD',N'Giao Tiếp Kinh Doanh','3','DL','GV8')
,('TLDL',N'Tâm Lí Du Lịch','3','DL','GV9')



------------ Kết Quả ------------------------

insert into KetQua(MaSVID,MaMHID,TenMH,DiemThi)
values('TT1485','LTHDT',N'Lập Trình Hướng Đối Tượng','9')
,('TT1485','CTDLGT',N'Cấu Trúc Dữ Liệu và Giải Thuật','10')
,('TT1485','CSDL',N'Cơ Sở Dữ Liệu', '8.5')
,('TT1485','LTFE1',N'Lập Trình FrontEnd1','8.0')



insert into KetQua(MaSVID,MaMHID,TenMH,DiemThi)
values('OTO123','CKOTO',N'Cơ khí Ô tô','9')
,('OTO123','A3D',N'Autocad 3D','10')
,('OTO123','LTGOTO',N'Lý thuyết gầm Ô tô', '8.5')
,('OTO123','TTDC1',N'Thực tập động cơ 1','8.0')


insert into KetQua(MaSVID,MaMHID,TenMH,DiemThi)
values('NH124','TVNH',N'Tạp Vụ Nhà Hàng','9')
,('NH124','KTTTMA',N'Kỹ Thuật Trang Trí Món Ăn','10')
,('NH124','KTCBMA',N'Kỹ Thuật Chế Biến Món Ăn', '8.5')
,('NH124','KTPC',N'Kỹ Thuật Pha Chế','8.0')

insert into KetQua(MaSVID,MaMHID,TenMH,DiemThi)
values('TA129','RD',N'Reading','9')
,('TA129','WT',N'Writing','10')
,('TA129','LN',N'Listening', '8.5')
,('TA129','CMN',N'Comunication','8.0')


insert into KetQua(MaSVID,MaMHID,TenMH,DiemThi)
values('CNC127','KTCK',N'Kỹ Thuật Cơ Khí','9')
,('CNC127','KTH',N'Kỹ Thuật Hàn','10')
,('CNC127','VKT',N'Vẽ Kỹ Thuật', '8.5')
,('CNC127','CNKL',N'Công Nghệ Kim Loại','8.0')


insert into KetQua(MaSVID,MaMHID,TenMH,DiemThi)
values('DCN115','KTDCB',N'Kỹ Thuật Điện Cơ Bản','9')
,('DCN115','ATD',N'An Toàn Điện','10')
,('DCN115','TKHTD',N'thiết kế hệ thống Điện', '8.5')
,('DCN115','VHHTD',N'vận hành hệ thống điện','8.0')



insert into KetQua(MaSVID,MaMHID,TenMH,DiemThi)
values('DL127','DLVNTG',N'Địa Lí Việt Nam và Thế Giới','9')
,('DL127','QHQTLT',N'Quan Hệ Quốc Tế và  Lễ Tân','10')
,('DL127','GTKD',N'Giao Tiếp Kinh Doanh', '8.5')
,('DL127','TLDL',N'Tâm Lí Du Lịch','8.0')
----------------ACount--------------------------------------------------- 
insert into Account(TaiKhoan,MatKhau,PhanQuyen)
values('admin','123','GV')
,('TT1485','124','SV')
,('OTO123','125','SV')
,('NH124','126','SV')
,('TA129','127','SV')
,('CNC127','128','SV')
,('DCN115','129','SV')
,('DL127','130','SV')
--------------------------- Thời Khóa Biểu ------------------------------
insert into ThoiKhoaBieu(MaLopID,MaSV,Thu,buoi,ThoiGian,Phong,MaMH,MaGV)
values('OOTOO1','OTO123',N'Hai',N'Chiều','12h45 - 17h30','C102A','CKOTO','GV10')
,('OOTOO2','OTO123',N'Ba',N'Sáng','7h00 - 11h45','C202A','A3D','GV10')
,('OOTOO3','OTO123',N'Tư',N'Chiều','12h45 - 17h30','C202B','LTGOTO','GV11')
,('OOTOO4','OTO123',N'Năm',N'Sáng','7h00 - 11h45','C203B','TTDC1','GV12')


insert into ThoiKhoaBieu(MaLopID,MaSV,Thu,buoi,ThoiGian,Phong,MaMH,MaGV)
values('TTTT1','TT1485',N'Hai',N'Chiều','12h45 - 17h30','B102A','LTHDT','GV1')
,('TTTT2','TT1485',N'Ba',N'Sáng','7h00 - 11h45','B202A','CTDLGT','GV1')
,('TTTT3','TT1485',N'Tư',N'Chiều','12h45 - 17h30','B202B','CSDL','GV2')
,('TTTT4','TT1485',N'Năm',N'Sáng','7h00 - 11h45','B203B','LTFE1','GV3')


insert into ThoiKhoaBieu(MaLopID,MaSV,Thu,buoi,ThoiGian,Phong,MaMH,MaGV)
values('NHHH1','NH124',N'Hai',N'Chiều','12h45 - 17h30','D102A','TVNH','GV19')
,('NHHH2','NH124',N'Ba',N'Sáng','7h00 - 11h45','D202A','KTCBMA','GV19')
,('NHHH3','NH124',N'Tư',N'Chiều','12h45 - 17h30','D202B','KTTTMA','GV20')
,('NHHH4','NH124',N'Năm',N'Sáng','7h00 - 11h45','D203B','KTPC','GV21')

insert into ThoiKhoaBieu(MaLopID,MaSV,Thu,buoi,ThoiGian,Phong,MaMH,MaGV)
values('TAAA1','TA129',N'Hai',N'Chiều','12h45 - 17h30','A102A','RD','GV4')
,('TAAA2','TA129',N'Ba',N'Sáng','7h00 - 11h45','A202A','WT','GV4')
,('TAAA3','TA129',N'Tư',N'Chiều','12h45 - 17h30','A202B','LN','GV5')
,('TAAA4','TA129',N'Năm',N'Sáng','7h00 - 11h45','A203B','CMN','GV6')

insert into ThoiKhoaBieu(MaLopID,MaSV,Thu,buoi,ThoiGian,Phong,MaMH,MaGV)
values('CNCC1','CNC127',N'Hai',N'Chiều','12h45 - 17h30','A102A','KTCK','GV13')
,('CNCC2','CNC127',N'Ba',N'Sáng','7h00 - 11h45','A202A','KTH','GV13')
,('CNCC3','CNC127',N'Tư',N'Chiều','12h45 - 17h30','A202B','VKT','GV14')
,('CNCC4','CNC127',N'Năm',N'Sáng','7h00 - 11h45','A203B','CNKL','GV15')

insert into ThoiKhoaBieu(MaLopID,MaSV,Thu,buoi,ThoiGian,Phong,MaMH,MaGV)
values('DCNN1','DCN115',N'Hai',N'Chiều','12h45 - 17h30','A102A','KTDCB','GV16')
,('DCNN2','DCN115',N'Ba',N'Sáng','7h00 - 11h45','A202A','ATD','GV16')
,('DCNN3','DCN115',N'Tư',N'Chiều','12h45 - 17h30','A202B','TKHTD','GV17')
,('DCNN4','DCN115',N'Năm',N'Sáng','7h00 - 11h45','A203B','VHHTD','GV18')

insert into ThoiKhoaBieu(MaLopID,MaSV,Thu,buoi,ThoiGian,Phong,MaMH,MaGV)
values('DLLL1','DL127',N'Hai',N'Chiều','12h45 - 17h30','A102A','DLVNTG','GV7')
,('DLLL2','DL127',N'Ba',N'Sáng','7h00 - 11h45','A202A','QHQTLT','GV7')
,('DLLL3','DL127',N'Tư',N'Chiều','12h45 - 17h30','A202B','GTKD','GV8')
,('DLLL4','DL127',N'Năm',N'Sáng','7h00 - 11h45','A203B','TLDL','GV9')



-- -------------------------------------------------------procedure sinhvien---------------------------------------------
Create procedure sp_getDataFromsSinhVien

as 
begin 
		select * from SinhVien
end 
---------------------------------------------------
Create procedure sp_getDataFromsSinhVienByID1
as 
begin 
		select MaSVID, HoSV, TenSV, MaKhoa from SinhVien 
end 

----------------------------------------------------
Create procedure sp_getDataFromsSinhVienByID2
@MaSVID varchar(6)
as 
begin 
		select sv.MaSVID,sv.HoSV,sv.TenSV,sv.GioiTinh,sv.NgaySinh,sv.NoiSinh,sv.DiaChi,ka.TenKhoa
		from SinhVien as sv join Khoa as ka on sv.MaKhoa = ka.MaKhoaID 
		where MaSVID = @MaSVID
end 
----------------------------------------------------
create procedure sp_updateDataSinhVien
 @MaSVID char(6) 
,@HoSV nvarchar(30)
,@TenSV nvarchar(15)
,@GioiTinh char (3)
,@NgaySinh date
,@NoiSinh nvarchar(50)
,@DiaChi nvarchar(50)
,@MaKhoa char(6)
as 
begin

update SinhVien set  HoSV = @HoSV, TenSV = @TenSV, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, NoiSinh = @NoiSinh, DiaChi = @DiaChi, MaKhoa = @MaKhoa
where MaSVID = @MaSVID
end 
-- ------------------------------- -- 
create procedure sp_insertDataSinhVien
 @MaSVID char(6) 
,@HoSV nvarchar(30)
,@TenSV nvarchar(15)
,@GioiTinh char (3)
,@NgaySinh date
,@NoiSinh nvarchar(50)
,@DiaChi nvarchar(50)
,@MaKhoa char(6)
as 
begin
insert into SinhVien(MaSVID,HoSV,TenSV,GioiTinh,NgaySinh,NoiSinh,DiaChi,MaKhoa) 
values(@MaSVID,@HoSV,@TenSV,@GioiTinh,@NgaySinh,@NoiSinh,@DiaChi,@MaKhoa)

end

------------------------------------------------------

create procedure sp_removeDataSV
@MaSVID char(6)
as 
begin 
delete from SinhVien where MaSVID = @MaSVID
end 
----------------------------------------------------------------- Thời Khóa Biểu ------------------------------------
create procedure sp_getDataTKB
@MaSVID char(10)
as 
begin 
select tkb.MaLopID ,tkb.Thu, tkb.buoi, tkb.ThoiGian, tkb.Phong, mh.TenMH,gv.TenGV from ThoiKhoaBieu as tkb join MonHoc as mh on tkb.MaMH = mh.MaMHID
join GiangVien as gv on tkb.MaGV = gv.MaGVID
where MaSV  = @MaSVID
end

drop procedure sp_getDataTKB
-----------------------------------------------------------

create procedure sp_insertDataTKB
@MaLopID char(10)
,@MaSVID char(6) 
,@Thu nvarchar(15)
,@buoi nvarchar(15)
,@ThoiGian nvarchar(15)
,@Phong varchar(10)
,@MaMH char(6)
,@MaGV char(6)
as 
begin 
insert into ThoiKhoaBieu(MaLopID,MaSV,Thu,buoi,ThoiGian,Phong,MaMH,MaGV)
values(@MaLopID,@MaSVID,@Thu,@buoi,@ThoiGian,@Phong,@MaMH,@MaGV)
end


---------------------------------------------
create procedure sp_updateDataTKB
@MaLopID char(10)
,@MaSVID char(6) 
,@Thu nvarchar(15)
,@buoi nvarchar(15)
,@ThoiGian nvarchar(15)
,@Phong varchar(10)
,@MaMH char(6)
,@MaGV char(6)
as 
begin 
update ThoiKhoaBieu set MaSV = @MaSVID,Thu = @Thu,buoi = @buoi,ThoiGian = @ThoiGian ,Phong = @Phong,MaMH = @MaMH,MaGV = @MaGV
where MaLopID = @MaLopID
end
--------------------------------------------------

create procedure sp_removeDataTKB
@MaLopID char(6)
as 
begin 
Delete from ThoiKhoaBieu
where MaLopID = @MaLopID
end
---------------------------------------------------------procedure Ket Qua --------------------------------------------------
Create procedure sp_GetDataFromTableKetQuaByID
(
@MaSVID char (6)
)
as 
begin 
	Select * From KetQua where MaSVID = @MaSVID
end 

-----------------------------------------------------

create  procedure sp_insertKQ
 @MaSVID char(6) 
,@MaMHID char(6)
,@TenMH nvarchar(30)
,@DiemThi int

As
Begin 
insert into KetQua(MaSVID,MaMHID,TenMH,DiemThi)
values( @MaSVID,@MaMHID,@TenMH,@DiemThi)
end


---------------------------------------------------------

create  procedure sp_removeDataKQ
@MaSVID char(6)
,@MaMHID char(6)
as 
begin 
Delete From KetQua where MaSVID = @MaSVID and  MaMHID = @MaMHID
end 

--------------------------------------------------------


create  procedure sp_updateKQ
 @MaSVID char(6) 
,@MaMHID char(6)
,@TenMH nvarchar(30)
,@DiemThi int

As
Begin 
update KetQua set TenMH = @TenMH,DiemThi = @DiemThi
Where MaSVID = @MaSVID and  MaMHID = @MaMHID
end


---------------------------------------------------------procedure Mon hoc --------------------------------------------------

--Create procedure sp_GetDataFromTable
--(
--@tablename nvarchar(30)
--)
--as 
--begin 
--exec('Select * From  ' + @tablename)
--end 

--------------------

Create procedure sp_GetDataFromTableMH
@TenMH nvarchar(30)
as 
begin 
Select mh.MaMHID From  MonHoc as mh Where mh.TenMH =  @TenMH
end 

----------------------------------------------

Create procedure sp_GetDataFromTableMH1
@maKhoa char(6)
as 
begin 
 select MaMHID from MonHoc Where MaKhoa = @maKhoa
end 
--------------------------------------------

Create procedure sp_GetDataFromTable2
@maKhoa char(6)
as 
begin 
 select mh.MaMHID,mh.TenMH,SoTiet,ka.TenKhoa,gv.TenGV
 from MonHoc as mh join Khoa as ka on mh.MaKhoa = ka.MaKhoaID
 join GiangVien as gv on mh.MaGV  = gv.MaGVID
 Where mh.MaKhoa = @maKhoa
end 
-------------------------------------------------------

create  procedure sp_insertMH
 @MaMHID char(6)
,@TenMH nvarchar(30)
,@SoTiet int
,@MaKhoa char(6)
,@MaGV char(6)

As
Begin 
insert into MonHoc(MaMHID,TenMH,SoTiet,MaKhoa,MaGV)
values( @MaMHID,@TenMH,@SoTiet,@MaKhoa,@MaGV)
end

-------------------------------------------------

create  procedure sp_removeDataMH
@MaMHID char(6)
as 
begin 
Delete From MonHoc where MaMHID = @MaMHID
end 

--------------------------------------------------

create  procedure sp_updateMH
 @MaMHID char(6)
,@TenMH nvarchar(30)
,@SoTiet int
,@MaKhoa char(6)
,@MaGV char(6)

As
Begin 
update MonHoc set TenMH = @TenMH,SoTiet = @SoTiet,MaKhoa = @MaKhoa,MaGV = @MaGV
Where MaMHID = @MaMHID
end




-----------------------------------------
Create procedure sp_GetDataFromTableGV
@MaKhoa char(6)
as 
begin 
Select gv.MaGVID From  GiangVien as gv join Khoa as ka on gv.MaKhoa = ka.MaKhoaID
Where gv.MaKhoa = @MaKhoa
end 

---------------------------------------------------------procedure Account --------------------------------------------------
create procedure sp_getDataFromTableAccount
as
begin 
select * from Account 
end
----------------------------------------------
create procedure sp_insertDataFromAccount
@TaiKhoan char(6)
,@MatKhau char(50)
,@PhanQuyen nvarchar(30)
as
begin
insert into Account(TaiKhoan,MatKhau,PhanQuyen)
values (@TaiKhoan,@MatKhau,@PhanQuyen)
end
-------------------------------------------------
create procedure sp_upadateDataFromAccount
@TaiKhoan char(6)
,@MatKhau char(50)
,@PhanQuyen nvarchar(30)
as
begin
update Account set MatKhau = @MatKhau, PhanQuyen = @PhanQuyen
where TaiKhoan = @TaiKhoan
end
--------------------------------------------------
create procedure sp_removeDataFromAccount
@TaiKhoan char(6)
as
begin
Delete from Account  where TaiKhoan = @TaiKhoan
end


create procedure sp_getDataFromTableAccount1
@TaiKhoan char(6)
,@MatKhau char(50)
as
begin 
select * from Account where TaiKhoan = @TaiKhoan and MatKhau = @MatKhau 
end

---------------------------------------------------------procedure Khoa --------------------------------------------------
create procedure sp_getDataKhoa
as 
begin
SELECT * From Khoa
end
-------------------------------------------
create procedure sp_insertKhoa
@MaKhoaID char(6)
,@TenKhoa nvarchar(30)
as 
begin
insert into Khoa(MaKhoaID,TenKhoa)
values(@MaKhoaID,@TenKhoa)
end
--------------------------------------------
create procedure sp_updateKhoa
@MaKhoaID char(6)
,@TenKhoa nvarchar(30)
as 
begin
update Khoa set TenKhoa = @TenKhoa
where MaKhoaID = @MaKhoaID
end
--------------------------------------------
create procedure sp_removeKhoa
@MaKhoaID char(6)
as 
begin
Delete from Khoa where MaKhoaID = @MaKhoaID
end
---------------------------------------------------------procedure Giảng Viên --------------------------------------------------

create procedure sp_getDataGiangVien
as 
begin 
SELECT gv.MaGVID, gv.TenGV,gv.GioiTinh,ka.TenKhoa From GiangVien as gv 
join Khoa as ka on gv.MaKhoa = ka.MaKhoaID
end
--------------------------------------
create procedure sp_getDataGiangVien1
@MaKhoa char(6)
as 
begin 
SELECT MaGVID,TenGV From GiangVien
where MaKHoa = @MaKhoa
end

--------------------------------------
create procedure sp_getDataGiangVien2
@MaKhoa char(6)
as 
begin 
SELECT gv.MaGVID, gv.TenGV,gv.GioiTinh,ka.TenKhoa From GiangVien as gv 
join Khoa as ka on gv.MaKhoa = ka.MaKhoaID
where Makhoa = @MaKhoa
end

-------------------------------------
create procedure sp_insertGiangVien
@MaGVID char(6)
,@TenGV nvarchar(45)
,@GioiTinh nvarchar(6)
,@MaKhoa char(6)
as 
begin 
insert into GiangVien(MaGVID,TenGV,GioiTinh,MaKhoa)
values(@MaGVID,@TenGV,@GioiTinh,@MaKhoa)
end
-------------------------------------
create procedure sp_updateGiangVien
@MaGVID char(6) 
,@TenGV nvarchar(45)
,@GioiTinh nvarchar(6)
,@MaKhoa char(6)
as 
begin 
update GiangVien set TenGV = @TenGV,GioiTinh = @GioiTinh,MaKhoa = @MaKhoa
where MaGVID = @MaGVID
end
-------------------------------------
create procedure sp_removeGiangVien
@MaGVID char(6)
as 
begin 
Delete from GiangVien 	where MaGVID = @MaGVID
end
