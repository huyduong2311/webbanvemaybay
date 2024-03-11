USE [csdl_doanpm]
GO
/****** Object:  Table [dbo].[ChuyenBay]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenBay](
	[MaChuyenBay] [int] NOT NULL,
	[SoHieuChuyenBay] [varchar](10) NULL,
	[ThoiGianKhoiHanh] [datetime] NULL,
	[ThoiGianDen] [datetime] NULL,
	[SoLuongKhach] [int] NULL,
	[Gia] [int] NULL,
	[HinhMoTa] [varchar](100) NULL,
	[ThanhPhoDi] [nvarchar](50) NULL,
	[ThanhPhoDen] [nvarchar](50) NULL,
	[hangmaybay] [varchar](50) NULL,
 CONSTRAINT [PK_ChuyenBay] PRIMARY KEY CLUSTERED 
(
	[MaChuyenBay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[Email] [varchar](100) NULL,
	[DienThoai] [varchar](15) NULL,
	[quoctich] [varchar](50) NULL,
	[Gioitinh] [nvarchar](4) NULL,
	[Ngaysinh] [date] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[IDTaikhoan] [int] NOT NULL,
	[Username] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[IDTaikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VeMayBay]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VeMayBay](
	[MaVe] [int] NOT NULL,
	[MaKhachHang] [int] NULL,
	[MaChuyenBay] [int] NULL,
	[HTTT] [nvarchar](50) NULL,
 CONSTRAINT [PK_VeMayBay] PRIMARY KEY CLUSTERED 
(
	[MaVe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[VeMayBay]  WITH CHECK ADD  CONSTRAINT [FK_VeMayBay_ChuyenBay] FOREIGN KEY([MaChuyenBay])
REFERENCES [dbo].[ChuyenBay] ([MaChuyenBay])
GO
ALTER TABLE [dbo].[VeMayBay] CHECK CONSTRAINT [FK_VeMayBay_ChuyenBay]
GO
ALTER TABLE [dbo].[VeMayBay]  WITH CHECK ADD  CONSTRAINT [FK_VeMayBay_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[VeMayBay] CHECK CONSTRAINT [FK_VeMayBay_KhachHang]
GO
/****** Object:  StoredProcedure [dbo].[DANGKI]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DANGKI] @Username varchar(100), @Password varchar(100)
AS
BEGIN
DECLARE @IDTAIKHOAN INT;
SELECT @IDTAIKHOAN=MAX(IDTAIKHOAN) FROM TAIKHOAN;
SET @IDTAIKHOAN=@IDTAIKHOAN+1;
INSERT INTO TAIKHOAN
VALUES(@IDTAIKHOAN,@Username,@Password)
END
GO
/****** Object:  StoredProcedure [dbo].[DANGKI3]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DANGKI3] @Username varchar(100), @Password varchar(100)
AS
BEGIN
INSERT INTO TaiKhoan(Username,Password)
VALUES(@Username,@Password)
END
GO
/****** Object:  StoredProcedure [dbo].[LayKHMoiNhat]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LayKHMoiNhat]
AS
BEGIN
    SELECT TOP 1 *
    FROM KHACHHANG
    ORDER BY MaKhachHang DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[SUAVE]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SUAVE] @MAKH INT,
				@MACB INT,
				@HTTT NVARCHAR(50),
				@MAVE INT
AS
BEGIN
UPDATE VEMAYBAY
SET MaKhachHang=@MAKH,
MaChuyenBay=@MACB,
HTTT=@HTTT
WHERE MAVE=@MAVE
END
GO
/****** Object:  StoredProcedure [dbo].[THEMCB01]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[THEMCB01] @SH VARCHAR(10),
					@TGDI varchar(50),
					@TGDEN varchar(50),
					@SL INT,
					@GIA INT,
					@HINH VARCHAR(100),
					@TPDI nvarchar(50),
					@TPDEN nvarchar(50),
					@HMB varchar(50)
AS
BEGIN
DECLARE @MaChuyenBay INT;
SELECT @MaChuyenBay=MAX(MaChuyenBay) FROM CHUYENBAY;
SET @MaChuyenBay=@MaChuyenBay+1;
INSERT INTO CHUYENBAY
VALUES(@MaChuyenBay,@SH,@TGDI,@TGDEN,@SL,@GIA,@HINH,@TPDI,@TPDEN,@HMB)
END
GO
/****** Object:  StoredProcedure [dbo].[THEMKHACH1]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[THEMKHACH1] @TEN NVARCHAR(100),
					  @EMAIL varchar(100),
					  @SDT varchar(50),
					  @QT varchar(50),
					  @GT NVARCHAR(4),
					  @NGAYSINH varchar(20)
AS
BEGIN
DECLARE @MaKhachHang INT;
SELECT @MaKhachHang=MAX(MaKhachHang) FROM KHACHHANG;
SET @MaKhachHang=@MaKhachHang+1;
INSERT INTO KHACHHANG
VALUES(@MaKhachHang,@TEN,@EMAIL,@SDT,@QT,@GT,@NGAYSINH)
END
GO
/****** Object:  StoredProcedure [dbo].[THEMVMB1]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[THEMVMB1] @MAKH NVARCHAR(100),
					@MACB INT,
					@HTTT NVARCHAR(50)
AS
BEGIN
DECLARE @MAVE INT;
SELECT @MAVE=MAX(MAVE) FROM VEMAYBAY;
SET @MAVE=@MAVE+1;
INSERT INTO VEMAYBAY
VALUES(@MAVE,@MAKH,@MACB,@HTTT)
END
GO
/****** Object:  StoredProcedure [dbo].[TIMKIEMCHUYENBAYTHEOID]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TIMKIEMCHUYENBAYTHEOID] @ID INT
AS
BEGIN
SELECT *
FROM CHUYENBAY
WHERE MACHUYENBAY=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[TIMKIEMCHUYENBAYTHEOTENTP]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TIMKIEMCHUYENBAYTHEOTENTP] @TEN NVARCHAR(30)
AS
BEGIN
    SELECT *
    FROM CHUYENBAY
    WHERE LEN(@TEN) >= 1 AND CHARINDEX(@TEN, ThanhPhoDen) > 0
END
GO
/****** Object:  StoredProcedure [dbo].[TIMKIEMKHACHHANGTHEOID]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TIMKIEMKHACHHANGTHEOID] @ID INT
AS
BEGIN
SELECT *
FROM KHACHHANG
WHERE MAKHACHHANG=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[TIMKIEMVETHEOID]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TIMKIEMVETHEOID] @ID INT
AS
BEGIN
SELECT *
FROM VEMAYBAY
WHERE MAVE=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[XOACB]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XOACB] @ID INT
AS
BEGIN
DELETE FROM CHUYENBAY
WHERE MACHUYENBAY=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[XOAKH]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XOAKH] @ID INT
AS
BEGIN
DELETE FROM KHACHHANG
WHERE MAKHACHHANG=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[XOATK]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XOATK] @ID INT
AS
BEGIN
DELETE FROM TAIKHOAN
WHERE IDTAIKHOAN=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[XOAVE]    Script Date: 2/25/2024 7:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XOAVE] @ID INT
AS
BEGIN
DELETE FROM VEMAYBAY
WHERE MAVE=@ID
END
GO
