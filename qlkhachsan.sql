USE [master]
GO
/****** Object:  Database [qlkhachsan]    Script Date: 04/01/2022 3:55:24 CH ******/
CREATE DATABASE [qlkhachsan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'qlkhachsan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\qlkhachsan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'qlkhachsan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\qlkhachsan_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [qlkhachsan] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [qlkhachsan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [qlkhachsan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [qlkhachsan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [qlkhachsan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [qlkhachsan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [qlkhachsan] SET ARITHABORT OFF 
GO
ALTER DATABASE [qlkhachsan] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [qlkhachsan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [qlkhachsan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [qlkhachsan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [qlkhachsan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [qlkhachsan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [qlkhachsan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [qlkhachsan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [qlkhachsan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [qlkhachsan] SET  DISABLE_BROKER 
GO
ALTER DATABASE [qlkhachsan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [qlkhachsan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [qlkhachsan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [qlkhachsan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [qlkhachsan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [qlkhachsan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [qlkhachsan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [qlkhachsan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [qlkhachsan] SET  MULTI_USER 
GO
ALTER DATABASE [qlkhachsan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [qlkhachsan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [qlkhachsan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [qlkhachsan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [qlkhachsan] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [qlkhachsan] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [qlkhachsan] SET QUERY_STORE = OFF
GO
USE [qlkhachsan]
GO
/****** Object:  Table [dbo].[hoadon]    Script Date: 04/01/2022 3:55:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoadon](
	[mahoadon] [int] IDENTITY(1,1) NOT NULL,
	[maphong] [int] NOT NULL,
	[tenkhachhang] [nvarchar](255) NOT NULL,
	[cmnd] [nvarchar](50) NOT NULL,
	[tongtien] [int] NULL,
	[batdau] [datetime] NULL,
	[ketthuc] [datetime] NULL,
	[trangthai] [nvarchar](255) NULL,
 CONSTRAINT [PK_hoadon] PRIMARY KEY CLUSTERED 
(
	[mahoadon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phong]    Script Date: 04/01/2022 3:55:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phong](
	[maphong] [int] IDENTITY(1,1) NOT NULL,
	[tenphong] [nvarchar](50) NOT NULL,
	[giaphong] [int] NOT NULL,
	[trangthai] [nvarchar](255) NULL,
 CONSTRAINT [PK_phong] PRIMARY KEY CLUSTERED 
(
	[maphong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[hoadon] ON 

INSERT [dbo].[hoadon] ([mahoadon], [maphong], [tenkhachhang], [cmnd], [tongtien], [batdau], [ketthuc], [trangthai]) VALUES (22, 2, N'vinh', N'123', 876000000, CAST(N'2021-01-01T21:02:00.000' AS DateTime), CAST(N'2022-01-01T21:05:08.000' AS DateTime), N'Đã thanh toán')
INSERT [dbo].[hoadon] ([mahoadon], [maphong], [tenkhachhang], [cmnd], [tongtien], [batdau], [ketthuc], [trangthai]) VALUES (25, 4, N'bá hiếu', N'123', 0, CAST(N'2022-01-01T21:06:14.000' AS DateTime), CAST(N'2022-01-01T21:07:42.000' AS DateTime), N'Đã thanh toán')
INSERT [dbo].[hoadon] ([mahoadon], [maphong], [tenkhachhang], [cmnd], [tongtien], [batdau], [ketthuc], [trangthai]) VALUES (27, 4, N'trưng', N'12311', 0, CAST(N'2022-01-01T21:08:55.000' AS DateTime), CAST(N'2022-01-01T21:09:00.000' AS DateTime), N'Đã thanh toán')
INSERT [dbo].[hoadon] ([mahoadon], [maphong], [tenkhachhang], [cmnd], [tongtien], [batdau], [ketthuc], [trangthai]) VALUES (29, 3, N'vinh', N'123', 930000, CAST(N'2022-01-02T08:41:44.000' AS DateTime), CAST(N'2022-01-02T18:00:19.000' AS DateTime), N'Đã thanh toán')
INSERT [dbo].[hoadon] ([mahoadon], [maphong], [tenkhachhang], [cmnd], [tongtien], [batdau], [ketthuc], [trangthai]) VALUES (31, 3, N'AA', N'111111', 3681000, CAST(N'2022-01-02T22:18:14.000' AS DateTime), CAST(N'2022-01-04T11:07:51.000' AS DateTime), N'Đã thanh toán')
INSERT [dbo].[hoadon] ([mahoadon], [maphong], [tenkhachhang], [cmnd], [tongtien], [batdau], [ketthuc], [trangthai]) VALUES (33, 3, N'Vinh', N'123456789', NULL, CAST(N'2022-01-04T13:37:01.000' AS DateTime), NULL, N'Được đặt trước')
INSERT [dbo].[hoadon] ([mahoadon], [maphong], [tenkhachhang], [cmnd], [tongtien], [batdau], [ketthuc], [trangthai]) VALUES (34, 5, N'Trưng', N'987654321', 263000, CAST(N'2022-01-04T13:37:10.000' AS DateTime), CAST(N'2022-01-04T14:56:47.000' AS DateTime), N'Đã thanh toán')
INSERT [dbo].[hoadon] ([mahoadon], [maphong], [tenkhachhang], [cmnd], [tongtien], [batdau], [ketthuc], [trangthai]) VALUES (35, 5, N'Quốc Việt', N'111222333', 6000, CAST(N'2022-01-04T15:00:36.000' AS DateTime), CAST(N'2022-01-04T15:03:16.000' AS DateTime), N'Đang thuê')
SET IDENTITY_INSERT [dbo].[hoadon] OFF
GO
SET IDENTITY_INSERT [dbo].[phong] ON 

INSERT [dbo].[phong] ([maphong], [tenphong], [giaphong], [trangthai]) VALUES (1, N'P.201', 100000, N'Trống')
INSERT [dbo].[phong] ([maphong], [tenphong], [giaphong], [trangthai]) VALUES (2, N'P.202', 100000, N'Trống')
INSERT [dbo].[phong] ([maphong], [tenphong], [giaphong], [trangthai]) VALUES (3, N'P.203', 100000, N'Được đặt trước')
INSERT [dbo].[phong] ([maphong], [tenphong], [giaphong], [trangthai]) VALUES (4, N'P.204', 150000, N'Trống')
INSERT [dbo].[phong] ([maphong], [tenphong], [giaphong], [trangthai]) VALUES (5, N'P.205', 200000, N'Đang thuê')
INSERT [dbo].[phong] ([maphong], [tenphong], [giaphong], [trangthai]) VALUES (6, N'P.206', 100000, N'Trống')
INSERT [dbo].[phong] ([maphong], [tenphong], [giaphong], [trangthai]) VALUES (7, N'P.301', 100000, N'Trống')
INSERT [dbo].[phong] ([maphong], [tenphong], [giaphong], [trangthai]) VALUES (16, N'P.302', 1000000, N'Trống')
SET IDENTITY_INSERT [dbo].[phong] OFF
GO
ALTER TABLE [dbo].[hoadon]  WITH CHECK ADD  CONSTRAINT [FK_hoadon_phong] FOREIGN KEY([maphong])
REFERENCES [dbo].[phong] ([maphong])
GO
ALTER TABLE [dbo].[hoadon] CHECK CONSTRAINT [FK_hoadon_phong]
GO
USE [master]
GO
ALTER DATABASE [qlkhachsan] SET  READ_WRITE 
GO
