USE [master]
GO
/****** Object:  Database [LKMT]    Script Date: 12/08/2023 10:40:37 AM ******/
CREATE DATABASE [LKMT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LKMT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LKMT.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LKMT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LKMT_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LKMT] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LKMT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LKMT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LKMT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LKMT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LKMT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LKMT] SET ARITHABORT OFF 
GO
ALTER DATABASE [LKMT] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LKMT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LKMT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LKMT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LKMT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LKMT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LKMT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LKMT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LKMT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LKMT] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LKMT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LKMT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LKMT] SET TRUSTWORTHY ON 
GO
ALTER DATABASE [LKMT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LKMT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LKMT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LKMT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LKMT] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LKMT] SET  MULTI_USER 
GO
ALTER DATABASE [LKMT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LKMT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LKMT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LKMT] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LKMT] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LKMT] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LKMT] SET QUERY_STORE = OFF
GO
USE [LKMT]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 12/08/2023 10:40:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[id_admin] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](40) NOT NULL,
	[matkhau] [varchar](32) NOT NULL,
	[ten] [nvarchar](128) NOT NULL,
	[sodienthoai] [varchar](11) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_admin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khachhang]    Script Date: 12/08/2023 10:40:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachhang](
	[id_khachhang] [int] NOT NULL,
	[email] [varchar](40) NOT NULL,
	[matkhau] [varchar](32) NOT NULL,
	[ten] [nvarchar](128) NOT NULL,
	[sodienthoai] [varchar](11) NOT NULL,
	[diachi] [nvarchar](128) NOT NULL,
	[ngaytao] [date] NOT NULL,
	[ngaycapnhat] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_khachhang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loaisanpham]    Script Date: 12/08/2023 10:40:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaisanpham](
	[id_loai] [char](5) NOT NULL,
	[id_nhom] [char](5) NOT NULL,
	[tenloai] [nvarchar](32) NOT NULL,
	[ngaytao] [date] NOT NULL,
	[ngaycapnhat] [date] NOT NULL,
 CONSTRAINT [PK__loaisanp__9A03AA72048FEF17] PRIMARY KEY CLUSTERED 
(
	[id_loai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhomsanpham]    Script Date: 12/08/2023 10:40:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhomsanpham](
	[id_nhom] [char](5) NOT NULL,
	[tennhom] [nvarchar](32) NOT NULL,
	[ngaytao] [date] NOT NULL,
	[ngaycapnhat] [date] NOT NULL,
 CONSTRAINT [PK__nhomsanp__284B2F9CF7871E75] PRIMARY KEY CLUSTERED 
(
	[id_nhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phieugiaohang]    Script Date: 12/08/2023 10:40:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phieugiaohang](
	[id_pgh] [int] IDENTITY(1,1) NOT NULL,
	[ngaygiaohang] [date] NOT NULL,
	[diachi] [nvarchar](50) NULL,
	[tenkhachhang] [nvarchar](128) NOT NULL,
	[sodienthoai] [varchar](11) NOT NULL,
	[maphieuxuat] [varchar](250) NOT NULL,
	[ghichu] [nvarchar](158) NULL,
	[phigiaohang] [decimal](18, 0) NOT NULL,
	[tongtienpx] [decimal](18, 0) NULL,
	[tongtienthanhtoan] [decimal](18, 0) NULL,
	[phuongthucthanhtoanId] [int] NULL,
 CONSTRAINT [PK__phieugia__6FC812FC24A1E8F0] PRIMARY KEY CLUSTERED 
(
	[id_pgh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phieunhap]    Script Date: 12/08/2023 10:40:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phieunhap](
	[id_phieunhap] [int] IDENTITY(1,1) NOT NULL,
	[id_sanpham] [char](10) NOT NULL,
	[soluongsp] [int] NOT NULL,
	[gianhap] [decimal](18, 0) NOT NULL,
	[ngaynhap] [datetime] NOT NULL,
 CONSTRAINT [PK__phieunha__5D76C1A2DD67B3BB] PRIMARY KEY CLUSTERED 
(
	[id_phieunhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phuongthucthanhtoan]    Script Date: 12/08/2023 10:40:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phuongthucthanhtoan](
	[id_thanhtoan] [int] IDENTITY(1,1) NOT NULL,
	[tenthanhtoan] [nvarchar](48) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_thanhtoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sanpham]    Script Date: 12/08/2023 10:40:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanpham](
	[id_sanpham] [char](10) NOT NULL,
	[tensanpham] [nvarchar](52) NOT NULL,
	[id_loai] [char](5) NOT NULL,
	[gia] [decimal](15, 4) NOT NULL,
	[id_thuonghieu] [int] NOT NULL,
	[baohanh] [int] NOT NULL,
	[khuyenmai] [int] NOT NULL,
	[hinh] [varchar](128) NOT NULL,
	[soluong] [int] NOT NULL,
	[mota] [text] NULL,
	[ngaytao] [date] NOT NULL,
	[ngaycapnhat] [date] NOT NULL,
 CONSTRAINT [PK__sanpham__5D76C1A215590820] PRIMARY KEY CLUSTERED 
(
	[id_sanpham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thuonghieu]    Script Date: 12/08/2023 10:40:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thuonghieu](
	[id_thuonghieu] [int] IDENTITY(1,1) NOT NULL,
	[id_nhom] [char](5) NULL,
	[tenthuonghieu] [nvarchar](40) NOT NULL,
	[ngaytao] [date] NOT NULL,
	[ngaycapnhat] [date] NOT NULL,
 CONSTRAINT [PK__thuonghi__8FCB194C617C9384] PRIMARY KEY CLUSTERED 
(
	[id_thuonghieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[xuatkho]    Script Date: 12/08/2023 10:40:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[xuatkho](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[maphieuxuat] [nvarchar](500) NULL,
	[id_sanpham] [char](10) NOT NULL,
	[soluong] [int] NOT NULL,
	[ngayxuat] [date] NULL,
	[sotien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_xuatkho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[admin] ON 

INSERT [dbo].[admin] ([id_admin], [email], [matkhau], [ten], [sodienthoai]) VALUES (1, N'admin@gmail.com', N'123456', N'admin', N'0997752127')
SET IDENTITY_INSERT [dbo].[admin] OFF
GO
INSERT [dbo].[khachhang] ([id_khachhang], [email], [matkhau], [ten], [sodienthoai], [diachi], [ngaytao], [ngaycapnhat]) VALUES (0, N'addmin12@gmail.com', N'123456', N'admin121', N'0997752127', N'Hà Nội', CAST(N'2023-12-06' AS Date), CAST(N'2023-12-08' AS Date))
GO
INSERT [dbo].[loaisanpham] ([id_loai], [id_nhom], [tenloai], [ngaytao], [ngaycapnhat]) VALUES (N'L3042', N'A01  ', N'Loại số 1', CAST(N'2023-12-06' AS Date), CAST(N'2023-12-06' AS Date))
GO
INSERT [dbo].[nhomsanpham] ([id_nhom], [tennhom], [ngaytao], [ngaycapnhat]) VALUES (N'A01  ', N'A01', CAST(N'2023-12-06' AS Date), CAST(N'2023-12-06' AS Date))
INSERT [dbo].[nhomsanpham] ([id_nhom], [tennhom], [ngaytao], [ngaycapnhat]) VALUES (N'A02  ', N'Nhóm A021', CAST(N'2023-12-06' AS Date), CAST(N'2023-12-08' AS Date))
GO
SET IDENTITY_INSERT [dbo].[phieugiaohang] ON 

INSERT [dbo].[phieugiaohang] ([id_pgh], [ngaygiaohang], [diachi], [tenkhachhang], [sodienthoai], [maphieuxuat], [ghichu], [phigiaohang], [tongtienpx], [tongtienthanhtoan], [phuongthucthanhtoanId]) VALUES (1, CAST(N'2023-12-07' AS Date), N'Hà Nội', N'admin', N'098765432', N'231007101001942', N'oke', CAST(50000 AS Decimal(18, 0)), CAST(80000000 AS Decimal(18, 0)), CAST(80050000 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[phieugiaohang] OFF
GO
SET IDENTITY_INSERT [dbo].[phieunhap] ON 

INSERT [dbo].[phieunhap] ([id_phieunhap], [id_sanpham], [soluongsp], [gianhap], [ngaynhap]) VALUES (1, N'SP61238357', 10, CAST(2000000 AS Decimal(18, 0)), CAST(N'2023-12-06T20:51:31.920' AS DateTime))
INSERT [dbo].[phieunhap] ([id_phieunhap], [id_sanpham], [soluongsp], [gianhap], [ngaynhap]) VALUES (2, N'SP61238357', 15, CAST(60000000 AS Decimal(18, 0)), CAST(N'2023-12-07T22:08:39.510' AS DateTime))
SET IDENTITY_INSERT [dbo].[phieunhap] OFF
GO
SET IDENTITY_INSERT [dbo].[phuongthucthanhtoan] ON 

INSERT [dbo].[phuongthucthanhtoan] ([id_thanhtoan], [tenthanhtoan]) VALUES (1, N'Tiền mặt đô')
SET IDENTITY_INSERT [dbo].[phuongthucthanhtoan] OFF
GO
INSERT [dbo].[sanpham] ([id_sanpham], [tensanpham], [id_loai], [gia], [id_thuonghieu], [baohanh], [khuyenmai], [hinh], [soluong], [mota], [ngaytao], [ngaycapnhat]) VALUES (N'SP61238357', N'aaa', N'L3042', CAST(500000.0000 AS Decimal(15, 4)), 1, 2, 2, N'unnamed.jpg', 5, N'aaaaaaa', CAST(N'2023-12-06' AS Date), CAST(N'2023-12-08' AS Date))
GO
SET IDENTITY_INSERT [dbo].[thuonghieu] ON 

INSERT [dbo].[thuonghieu] ([id_thuonghieu], [id_nhom], [tenthuonghieu], [ngaytao], [ngaycapnhat]) VALUES (1, N'A01  ', N'Adidas1', CAST(N'2023-12-06' AS Date), CAST(N'2023-12-08' AS Date))
SET IDENTITY_INSERT [dbo].[thuonghieu] OFF
GO
SET IDENTITY_INSERT [dbo].[xuatkho] ON 

INSERT [dbo].[xuatkho] ([Id], [maphieuxuat], [id_sanpham], [soluong], [ngayxuat], [sotien]) VALUES (2, N'231007101001942', N'SP61238357', 10, CAST(N'2023-12-07' AS Date), CAST(80000000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[xuatkho] OFF
GO
/****** Object:  Index [UQ__admin__89472E94A77B8EBE]    Script Date: 12/08/2023 10:40:38 AM ******/
ALTER TABLE [dbo].[admin] ADD UNIQUE NONCLUSTERED 
(
	[id_admin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__admin__AB6E6164FD19EC8A]    Script Date: 12/08/2023 10:40:38 AM ******/
ALTER TABLE [dbo].[admin] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__khachhan__63966DBC81D3C195]    Script Date: 12/08/2023 10:40:38 AM ******/
ALTER TABLE [dbo].[khachhang] ADD UNIQUE NONCLUSTERED 
(
	[id_khachhang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__khachhan__AB6E616419B55886]    Script Date: 12/08/2023 10:40:38 AM ******/
ALTER TABLE [dbo].[khachhang] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__loaisanp__9A03AA738235F7FA]    Script Date: 12/08/2023 10:40:38 AM ******/
ALTER TABLE [dbo].[loaisanpham] ADD  CONSTRAINT [UQ__loaisanp__9A03AA738235F7FA] UNIQUE NONCLUSTERED 
(
	[id_loai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__nhomsanp__284B2F9D5A0A0C86]    Script Date: 12/08/2023 10:40:38 AM ******/
ALTER TABLE [dbo].[nhomsanpham] ADD  CONSTRAINT [UQ__nhomsanp__284B2F9D5A0A0C86] UNIQUE NONCLUSTERED 
(
	[id_nhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__phuongth__257DA41B96FE8CD1]    Script Date: 12/08/2023 10:40:38 AM ******/
ALTER TABLE [dbo].[phuongthucthanhtoan] ADD UNIQUE NONCLUSTERED 
(
	[id_thanhtoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__sanpham__5D76C1A309251C86]    Script Date: 12/08/2023 10:40:38 AM ******/
ALTER TABLE [dbo].[sanpham] ADD  CONSTRAINT [UQ__sanpham__5D76C1A309251C86] UNIQUE NONCLUSTERED 
(
	[id_sanpham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__thuonghi__8FCB194D809D9205]    Script Date: 12/08/2023 10:40:38 AM ******/
ALTER TABLE [dbo].[thuonghieu] ADD  CONSTRAINT [UQ__thuonghi__8FCB194D809D9205] UNIQUE NONCLUSTERED 
(
	[id_thuonghieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[sanpham] ADD  CONSTRAINT [DF__sanpham__khuyenm__47DBAE45]  DEFAULT ((0)) FOR [khuyenmai]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ReportSanPham]    Script Date: 12/08/2023 10:40:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_ReportSanPham] 
AS
BEGIN
	SELECT sp.id_sanpham, sp.tensanpham
	, SUM(ISNULL(pn.soluongsp, 0)) as TongSoLuongNhap
	, SUM(ISNULL(xk.soluong, 0)) as TongSoLuongXuat
	, SUM(ISNULL(pn.gianhap, 0)) as TongTienNhap
	, SUM(ISNULL(xk.sotien, 0)) as TongTienXuat
	FROM phieunhap pn
	LEFT JOIN xuatkho xk ON xk.id_sanpham = pn.id_sanpham
	LEFT JOIN sanpham sp ON sp.id_sanpham = pn.id_sanpham
	GROUP BY sp.id_sanpham, sp.tensanpham
END
GO
USE [master]
GO
ALTER DATABASE [LKMT] SET  READ_WRITE 
GO
