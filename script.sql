USE [master]
GO
/****** Object:  Database [WebApiSaleOrder]    Script Date: 12/11/2024 8:23:39 PM ******/
CREATE DATABASE [WebApiSaleOrder]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebApiSaleOrder', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER2012\MSSQL\DATA\WebApiSaleOrder.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WebApiSaleOrder_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER2012\MSSQL\DATA\WebApiSaleOrder_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WebApiSaleOrder] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebApiSaleOrder].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebApiSaleOrder] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebApiSaleOrder] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebApiSaleOrder] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebApiSaleOrder] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebApiSaleOrder] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WebApiSaleOrder] SET  MULTI_USER 
GO
ALTER DATABASE [WebApiSaleOrder] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebApiSaleOrder] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebApiSaleOrder] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebApiSaleOrder] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [WebApiSaleOrder]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/11/2024 8:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customerId] [uniqueidentifier] NOT NULL,
	[customerName] [nvarchar](50) NOT NULL,
	[customerPhoneNo] [nvarchar](50) NOT NULL,
	[customerAddress] [nvarchar](50) NOT NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleOrder]    Script Date: 12/11/2024 8:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleOrder](
	[soId] [int] IDENTITY(1,1) NOT NULL,
	[soCustomer] [nvarchar](50) NOT NULL,
	[soTotalAmount] [float] NOT NULL,
	[soDate] [date] NULL,
 CONSTRAINT [PK_SaleOrder] PRIMARY KEY CLUSTERED 
(
	[soId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleOrderDetail]    Script Date: 12/11/2024 8:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleOrderDetail](
	[soDetailId] [int] IDENTITY(1,1) NOT NULL,
	[soId] [int] NOT NULL,
	[stockId] [nvarchar](50) NOT NULL,
	[qty] [int] NOT NULL,
	[total] [float] NOT NULL,
 CONSTRAINT [PK_SaleOrderDetail] PRIMARY KEY CLUSTERED 
(
	[soDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 12/11/2024 8:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[stockId] [uniqueidentifier] NOT NULL,
	[stockName] [nvarchar](50) NOT NULL,
	[stockDescription] [nvarchar](50) NOT NULL,
	[stockPrice] [float] NOT NULL,
	[stockOnHandQty] [int] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[stockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([customerId], [customerName], [customerPhoneNo], [customerAddress], [isDeleted]) VALUES (N'36108309-b900-4737-bc43-17c6acc1303b', N'string 30', N'string 30', N'string 30', 1)
INSERT [dbo].[Customer] ([customerId], [customerName], [customerPhoneNo], [customerAddress], [isDeleted]) VALUES (N'197089db-7db8-41b2-9dc3-2b11fcd50d12', N'Customer 1', N'0912345678', N'Address 1', 0)
INSERT [dbo].[Customer] ([customerId], [customerName], [customerPhoneNo], [customerAddress], [isDeleted]) VALUES (N'2861cc64-c698-4341-8fcd-597e0b0f9297', N'Customer 2', N'09345666644', N'customer Address 2', 0)
INSERT [dbo].[Customer] ([customerId], [customerName], [customerPhoneNo], [customerAddress], [isDeleted]) VALUES (N'55a5c54b-09bb-46af-92fe-8d22b73bfec3', N'string', N'123456789', N'string', 1)
INSERT [dbo].[Customer] ([customerId], [customerName], [customerPhoneNo], [customerAddress], [isDeleted]) VALUES (N'5a74698e-491e-4130-bf5f-b98847ead4e8', N'string', N'string', N'string', 1)
INSERT [dbo].[Customer] ([customerId], [customerName], [customerPhoneNo], [customerAddress], [isDeleted]) VALUES (N'725ef691-61a9-443f-9c19-bbb649517379', N'Customer 3', N'string 2', N'string 3', 0)
INSERT [dbo].[Customer] ([customerId], [customerName], [customerPhoneNo], [customerAddress], [isDeleted]) VALUES (N'9a1f965d-18dc-406d-8392-f2b463818c46', N'string', N'string', N'Address', 1)
SET IDENTITY_INSERT [dbo].[SaleOrder] ON 

INSERT [dbo].[SaleOrder] ([soId], [soCustomer], [soTotalAmount], [soDate]) VALUES (1, N'Customer 1', 100, NULL)
SET IDENTITY_INSERT [dbo].[SaleOrder] OFF
SET IDENTITY_INSERT [dbo].[SaleOrderDetail] ON 

INSERT [dbo].[SaleOrderDetail] ([soDetailId], [soId], [stockId], [qty], [total]) VALUES (1, 1, N'E37356AF-AF46-47EF-189B-08DD177BB5B9', 1, 200)
INSERT [dbo].[SaleOrderDetail] ([soDetailId], [soId], [stockId], [qty], [total]) VALUES (2, 1, N'767C7E7C-313A-465F-F752-08DD1867B4A9', 2, 300)
SET IDENTITY_INSERT [dbo].[SaleOrderDetail] OFF
INSERT [dbo].[Stock] ([stockId], [stockName], [stockDescription], [stockPrice], [stockOnHandQty]) VALUES (N'e37356af-af46-47ef-189b-08dd177bb5b9', N'stockName 1', N'stockDescription 1', 200, 10)
INSERT [dbo].[Stock] ([stockId], [stockName], [stockDescription], [stockPrice], [stockOnHandQty]) VALUES (N'767c7e7c-313a-465f-f752-08dd1867b4a9', N'stockName 2', N'stockDescription 2', 300, 40)
INSERT [dbo].[Stock] ([stockId], [stockName], [stockDescription], [stockPrice], [stockOnHandQty]) VALUES (N'a154ca1f-9097-4db8-d798-08dd19de9335', N'Stock 3', N'Description 3', 600, 20)
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[SaleOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_SaleOrderDetail_Orders] FOREIGN KEY([soId])
REFERENCES [dbo].[SaleOrder] ([soId])
GO
ALTER TABLE [dbo].[SaleOrderDetail] CHECK CONSTRAINT [FK_SaleOrderDetail_Orders]
GO
ALTER TABLE [dbo].[SaleOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_SaleOrderDetails_Orders] FOREIGN KEY([soId])
REFERENCES [dbo].[SaleOrder] ([soId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SaleOrderDetail] CHECK CONSTRAINT [FK_SaleOrderDetails_Orders]
GO
USE [master]
GO
ALTER DATABASE [WebApiSaleOrder] SET  READ_WRITE 
GO
