USE [master]
GO
/****** Object:  Database [Terna_Jewellery]    Script Date: 02.12.2023 14:05:44 ******/
CREATE DATABASE [Terna_Jewellery]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Terna_Jewellery', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Terna_Jewellery.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Terna_Jewellery_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Terna_Jewellery_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Terna_Jewellery] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Terna_Jewellery].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Terna_Jewellery] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET ARITHABORT OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Terna_Jewellery] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Terna_Jewellery] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Terna_Jewellery] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Terna_Jewellery] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET RECOVERY FULL 
GO
ALTER DATABASE [Terna_Jewellery] SET  MULTI_USER 
GO
ALTER DATABASE [Terna_Jewellery] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Terna_Jewellery] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Terna_Jewellery] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Terna_Jewellery] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Terna_Jewellery] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Terna_Jewellery', N'ON'
GO
ALTER DATABASE [Terna_Jewellery] SET QUERY_STORE = OFF
GO
USE [Terna_Jewellery]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Terna_Jewellery]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 02.12.2023 14:05:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticuleId] [int] NULL,
	[ProductName] [nvarchar](100) NULL,
	[UnitOfMeasurement] [nvarchar](10) NULL,
	[Price] [float] NULL,
	[MaxDiscount] [int] NULL,
	[Manufacturer] [nvarchar](100) NULL,
	[Provider] [nvarchar](100) NULL,
	[Category] [nvarchar](50) NULL,
	[Discount] [int] NULL,
	[InStock] [int] NULL,
	[Description] [nvarchar](255) NULL,
	[ProductPhoto] [nvarchar](255) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ProductView]    Script Date: 02.12.2023 14:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE View [dbo].[ProductView]
as 
Select p.ArticuleId as 'Артикуль', p.ProductName as 'Название', p.Category as 'Категория', p.Price as 'Цена', p.Description as 'Описание' 
from Product as p;
GO
/****** Object:  Table [dbo].[Order]    Script Date: 02.12.2023 14:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderPrID] [int] NULL,
	[OrderDate] [date] NULL,
	[OrderDeliveryDate] [date] NULL,
	[OrderPickupPoint] [int] NULL,
	[ClientID] [int] NULL,
	[CodeToGet] [int] NULL,
	[OrderStatus] [nvarchar](30) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Pr]    Script Date: 02.12.2023 14:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Pr](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProdArticleNumb] [nvarchar](255) NULL,
	[Amount] [int] NULL,
	[Order_id] [int] NULL,
 CONSTRAINT [PK_Order_Pr] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PointOfIssue]    Script Date: 02.12.2023 14:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PointOfIssue](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Index] [int] NULL,
	[City] [nvarchar](30) NULL,
	[Street] [nvarchar](50) NULL,
	[StreetNumb] [int] NULL,
 CONSTRAINT [PK_PointOfIssue] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 02.12.2023 14:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 02.12.2023 14:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[Patronymic] [nvarchar](255) NULL,
	[Login] [nvarchar](255) NULL,
	[Password] [nvarchar](255) NULL,
	[Role_id] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Order_Pr] FOREIGN KEY([OrderPrID])
REFERENCES [dbo].[Order_Pr] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Order_Pr]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([ClientID])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[Order_Pr]  WITH CHECK ADD  CONSTRAINT [FK_Order_Pr_Order] FOREIGN KEY([Order_id])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[Order_Pr] CHECK CONSTRAINT [FK_Order_Pr_Order]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([Role_id])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
/****** Object:  StoredProcedure [dbo].[AddProd]    Script Date: 02.12.2023 14:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[AddProd]

@Articule int,
@ProductName nvarchar(100),
@UnitOfMeasurement nvarchar(100),
@Price float,
@MaxDiscount int,
@Manufacturer nvarchar(100),
@Provider nvarchar(100),
@Category nvarchar(100),
@Discount int,
@inStock int,
@Description nvarchar(255),
@ProductPhoto nvarchar(255)

as
Insert into Product(ArticuleId, ProductName, UnitOfMeasurement, Price, MaxDiscount, Manufacturer, Provider, Category, Discount, InStock, Description, ProductPhoto)
Values(@Articule, @ProductName, @UnitOfMeasurement, @Price, @MaxDiscount, @Manufacturer, @Provider, @Category, @Discount, @InStock, @Description, @ProductPhoto)
GO
/****** Object:  StoredProcedure [dbo].[Enter]    Script Date: 02.12.2023 14:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[Enter]
@login nvarchar(255),
@password nvarchar(255)

as 

Select [Login], [Password]
From [User]
where [Login] = @login and [Password] = @password;
GO
USE [master]
GO
ALTER DATABASE [Terna_Jewellery] SET  READ_WRITE 
GO
