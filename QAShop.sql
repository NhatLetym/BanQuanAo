
Create Database QAShop
Use QAShop

CREATE TABLE LoaiQA_PhuKien(
	MaLoai CHAR(50) PRIMARY KEY,
	TenLoai NVARCHAR(100) NOT NULL
)
GO
CREATE TABLE SanPham(
	MaSanPham CHAR(50) PRIMARY KEY,
	TenSanPham NVARCHAR(100) NOT NULL,
	--KichCo CHAR(5) NOT NULL,
	--Mau NVARCHAR(30) NOT NULL,
	SoLuong INT  CHECK (SOLUONG >0) NOT NULL,
	MoTa NVARCHAR(3000) NOT NULL,
	HinhAnh NVARCHAR(max),
	MaLoai CHAR(50) FOREIGN KEY(MaLoai) REFERENCES LoaiQA_PhuKien(MaLoai)
)
GO
CREATE TABLE GiaBan(
	MaSanPham CHAR(50) FOREIGN KEY(MASANPHAM) REFERENCES SANPHAM(MASANPHAM),
	PRIMARY KEY( MASANPHAM),
	GiaBan INT NOT NULL,
	NgayCapNhat DATETIME NOT NULL
)
GO 
--CREATE TABLE KHACHHANG(
--	MAKHACHHANG CHAR(50) PRIMARY KEY,
--	TENKHACHHANG NVARCHAR(100) NOT NULL,
--	SDT CHAR(10) NOT NULL,
--	EMAIL CHAR(100) NOT NULL,
--	DIACHI NVARCHAR(100) NOT NULL,
--	--QUYEN INT NOT NULL CHECK (QUYEN = 2)
--)
--GO

CREATE TABLE NhaCungCap(
	MaNhaCungCap CHAR(50) PRIMARY KEY,
	TenNhaCungCap NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(100) NOT NULL,
	Email CHAR(100),
	SDT CHAR(10) NOT NULL
)
GO
CREATE TABLE DonHangNhap(
	MaDonHangNhap CHAR(50) PRIMARY KEY,
	MaNhaCungCap CHAR(50) FOREIGN KEY(MANHACUNGCAP) REFERENCES NHACUNGCAP(MANHACUNGCAP),
	NgayNhap  DATETIME NOT NULL,
	ThanhTien INT NOT NULL
)
GO
CREATE TABLE ChiTietNhapHang(
	MaDonHangNhap CHAR(50) FOREIGN KEY (MADONHANGNHAP) REFERENCES DONHANGNHAP(MADONHANGNHAP),
	MaSanPham CHAR(50) FOREIGN KEY (MASANPHAM) REFERENCES SANPHAM(MASANPHAM),
	PRIMARY KEY (MADONHANGNHAP, MASANPHAM),
	SoLuong INT NOT NULL CHECK(SOLUONG >0),
	DongGia INT NOT NULL
)
GO 
CREATE TABLE DonXuat(
	MaDonHangXuat CHAR(50) PRIMARY KEY,
	MaKhachHang CHAR(50) FOREIGN KEY (MAKHACHHANG) REFERENCES KHACHHANG(MAKHACHHANG),
	NgayDatHang DATETIME NOT NULL,
	ThanhTien INT NOT NULL,
	DiaChiGiaoHang NVARCHAR (200),
	SDTNguoiNhan CHAR(10),
	TrangThaiDonHang NVARCHAR(100)
)
GO
CREATE TABLE ChiTietDonXuat(
	MaDonHangXuat CHAR(50) FOREIGN KEY (MADONHANGXUAT) REFERENCES DONXUAT(MADONHANGXUAT),
	MaSanPham CHAR(50) FOREIGN KEY (MASANPHAM) REFERENCES SANPHAM(MASANPHAM),
	PRIMARY KEY (MADONHANGXUAT, MASANPHAM),
	SoLuong INT NOT NULL CHECK(SOLUONG >0),
	DonGia INT NOT NULL
)
GO

--CREATE TABLE NHANVIEN(
--	MANHANVIEN CHAR(50) PRIMARY KEY,
--	TENNHANVIEN NVARCHAR(100) NOT NULL,
--	SDT CHAR(10) NOT NULL,
--	EMAIL CHAR(100) NOT NULL,
--	DIACHI NVARCHAR(200) NOT NULL,
--	CHUCVU NVARCHAR(50) NOT NULL,
--	QUYEN INT NOT NULL CHECK(QUYEN =0 OR QUYEN =1)
--)
--GO
--CREATE TABLE BAIVIET(
--	MABAIVIET CHAR(50) PRIMARY KEY,
--	MANHANVIEN CHAR(50) FOREIGN KEY (MANHANVIEN) REFERENCES NHANVIEN(MANHANVIEN),
--	TIEUDE NVARCHAR(200) NOT NULL,
--	NOIDUNG NVARCHAR(3000) NOT NULL,
--	THOIGIANDANG DATETIME NOT NULL
--)
--GO

create table NGUOIDUNG(
	USERNAME CHAR(10) PRIMARY KEY,
	PASS CHAR(50) NOT NULL
)

INSERT INTO GiaBan
VALUES ('ANam1',10000,'2/2/2021'),
('ANu1',20000,'3/2/2021'),
('QNam1',30000,'4/2/2021'),
('TL1',40000,'5/2/2021')

INSERT INTO LoaiQA_PhuKien
VALUES ('QNu', N'Quần nữ'),
		('TL',N'Thắt lưng'),
		('QNam',N'Quần nam'),
		('ANam',N'Áo nam'),
		('ANu',N'Áo nữ'),
		('DH',N'Đồng hồ'),
		('QA',N'Quần áo'),
		('PK',N'Phụ kiện')
		

INSERT INTO SanPham(MaSanPham, TenSanPham, MaLoai, MoTa, SoLuong )
VALUES ('CV1',N'Chân váy xẻ tà Hàn Quốc','QNu','Stylish Chân Váy Nữ Ulzzang !!!
		màu váy  : 3 màu ( Xanh, Nâu Đất,Hồng Đất )
		S: eo: 65, mông:86, dài: 43
		M: so: 67, mông: 88, dài: 44',300),
('ANam1',N'Áo phông nam','ANam',N'- Áo thun nam, áo phông nam có cổ, áo polo nam big size Burberry, Dior, Fendi, Dolce Gabbana D&G, Gucci.. Bản Replica Like Authentic 1:1 cam kết form chuẩn như hãng, chất đẹp ~ hàng Auth, sắc nét từng đường kim mũi chỉ.
										- Đủ size cho quý khách lựa chọn (Từ 50kg - 140kg big size lớn cho người to béo mập)
										- Hàng đặt xưởng làm riêng nên shop đảm bảo những mẫu này cực ít nơi có.
										- Đường may đẹp mắt, cẩn thận tỉ mỉ, tạo sự thanh lịch, lịch lãm, trông bạn như một người thành đạt đầy thu hút.
										- Màu sắc nam tính, dễ phối đồ với nhiều kiểu quần tây nam Dolce Gabbana, quần âu nam Fendi, quần vải nam Dior, hoặc thắt lưng nam Hermes, thắt lưng LV Louis Vuitton nam hoặc thắt lưng Versace nam, thắt lưng Burberry nam, thắt lưng Gucci nam... Ngoài ra quý khách có thể phối đồ kết hợp cùng giày tây nam LV Louis Vuitton, giày lười nam Dior
										- Đổi size thoải mái nếu quý khách mặc chật hoặc rộng
										- Hình ảnh sản phẩm được chụp từ mẫu thực. Chất lượng sản phẩm được sản xuất và thiết kế theo xu hướng thời trang mới nhất trong tháng',
										100), --'img.anh1.jpg'
		('ANu1',N'Áo phông nữ','ANu',N'áo thun das hàng cambodia. Áo được may từ 100% cotton 4 chiều cao cấp, co giãn tốt, mịn mát thoải mái!
												Sản phẩm dành cho cả nam và nữ, thiết kế thời trang, dễ dàng phối với quần ngắn quần dài, thích hợp mang trong mọi hoạt động.
												SIZE tham khảo: (Áo dáng thụng nên các bạn lưu ý)
												- S: 40-52 kg
												- M: 53-65 kg
												- L: 66-78 kg',
												200), --'img.anh2.jpeg'
		('QNam1',N'Quần bò rách nam','QNam',N'Quần jean nam rách mang đến cho bạn sự thoải mái không kém phần lịch lãm.
													Sự kết hợp cùng một chiếc áo thun, áo sơ mi giúp bạn thể hiện phong cách riêng mỗi khi xuất hiện. 
													Chất jean cotton dày mịn và co giãn tốt, vận động suốt cả ngày, không gây bức bí, khó chịu. 
													Quần có nhiều size từ 28 đến 32 để các chàng lựa chọn phù hợp với cân nặng và chiều cao của mình',
													300), --'img.anh3.jpg'
		('TL1',N'Thắt lưng da nam','TL',N'Thắt lưng nam da cá sấu cao cấp – TLDT0124S – Là dòng sản phẩm cao cấp của Olagood. Được làm từ 100% da cá sấu nhập khẩu, sợi liền nguyên con, hai cạnh được may gấp mép cuốn viền rất tỉ mỉ , đầu khóa được làm từ thép nguyên khối không gỉ tiện theo công nghệ CNC. Khác biệt hoàn toàn với các dòng thông thường sản xuất trong nước.
													– Mặt ngoài: Được làm từ da cá sấu nhập khẩu 100%.
													– Mặt trong: Được làm từ da bò Ý.
													– Kích thước: 3,4cm x 125cm
													– Bảo hành 24 tháng và được đổi trả trong vòng 15 ngày.',
													400) --'img.anh4.jpg'


UPDATE SanPham SET HinhAnh='img.anh1' WHERE MaSanPham='ANam1'

