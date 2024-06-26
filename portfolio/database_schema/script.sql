USE [master]
GO
/****** Object:  Database [TodoManagement]    Script Date: 2024-04-29 오전 12:48:29 ******/
CREATE DATABASE [TodoManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TodoManagement', FILENAME = N'C:\Datas\MSSQL16.MSSQLSERVER\MSSQL\DATA\TodoManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TodoManagement_log', FILENAME = N'C:\Datas\MSSQL16.MSSQLSERVER\MSSQL\DATA\TodoManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TodoManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TodoManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TodoManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TodoManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TodoManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TodoManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TodoManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [TodoManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TodoManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TodoManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TodoManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TodoManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TodoManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TodoManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TodoManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TodoManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TodoManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TodoManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TodoManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TodoManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TodoManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TodoManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TodoManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TodoManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TodoManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [TodoManagement] SET  MULTI_USER 
GO
ALTER DATABASE [TodoManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TodoManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TodoManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TodoManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TodoManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TodoManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TodoManagement', N'ON'
GO
ALTER DATABASE [TodoManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [TodoManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TodoManagement]
GO
/****** Object:  Table [dbo].[departmenttbl]    Script Date: 2024-04-29 오전 12:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departmenttbl](
	[depIdx] [int] IDENTITY(1,1) NOT NULL,
	[depNames] [varchar](20) NOT NULL,
 CONSTRAINT [PK_departmenttbl] PRIMARY KEY CLUSTERED 
(
	[depIdx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[todotbl]    Script Date: 2024-04-29 오전 12:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[todotbl](
	[TodoIdx] [int] IDENTITY(1,1) NOT NULL,
	[userIdx] [int] NOT NULL,
	[Todo] [varchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Place] [varchar](50) NULL,
	[Detail] [varchar](500) NULL,
	[Division] [varchar](10) NOT NULL,
	[Complete] [char](3) NULL,
 CONSTRAINT [PK__todotbl__7006900C829A2559] PRIMARY KEY CLUSTERED 
(
	[TodoIdx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usertbl]    Script Date: 2024-04-29 오전 12:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usertbl](
	[userIdx] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[department] [int] NULL,
	[userId] [varchar](20) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[lastLoginDateTime] [datetime] NULL,
 CONSTRAINT [PK__usertbl__BC880B88801E67BF] PRIMARY KEY CLUSTERED 
(
	[userIdx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[departmenttbl] ON 

INSERT [dbo].[departmenttbl] ([depIdx], [depNames]) VALUES (1, N'생산')
INSERT [dbo].[departmenttbl] ([depIdx], [depNames]) VALUES (2, N'재무')
INSERT [dbo].[departmenttbl] ([depIdx], [depNames]) VALUES (3, N'마케팅')
INSERT [dbo].[departmenttbl] ([depIdx], [depNames]) VALUES (4, N'R&D')
INSERT [dbo].[departmenttbl] ([depIdx], [depNames]) VALUES (5, N'영업')
SET IDENTITY_INSERT [dbo].[departmenttbl] OFF
GO
SET IDENTITY_INSERT [dbo].[todotbl] ON 

INSERT [dbo].[todotbl] ([TodoIdx], [userIdx], [Todo], [StartDate], [EndDate], [Place], [Detail], [Division], [Complete]) VALUES (2, 1, N'ToyProject', CAST(N'2024-04-24' AS Date), CAST(N'2024-04-25' AS Date), NULL, NULL, N'Public', N'N  ')
INSERT [dbo].[todotbl] ([TodoIdx], [userIdx], [Todo], [StartDate], [EndDate], [Place], [Detail], [Division], [Complete]) VALUES (3, 2, N'ADsP', CAST(N'2024-04-20' AS Date), CAST(N'2024-05-10' AS Date), NULL, NULL, N'Private', N'N  ')
INSERT [dbo].[todotbl] ([TodoIdx], [userIdx], [Todo], [StartDate], [EndDate], [Place], [Detail], [Division], [Complete]) VALUES (4, 2, N'Interview', CAST(N'2024-04-21' AS Date), CAST(N'2024-04-28' AS Date), NULL, NULL, N'Public', N'N  ')
INSERT [dbo].[todotbl] ([TodoIdx], [userIdx], [Todo], [StartDate], [EndDate], [Place], [Detail], [Division], [Complete]) VALUES (5, 1, N'Home', CAST(N'2024-04-20' AS Date), CAST(N'2024-04-23' AS Date), NULL, NULL, N'Public', N'N  ')
INSERT [dbo].[todotbl] ([TodoIdx], [userIdx], [Todo], [StartDate], [EndDate], [Place], [Detail], [Division], [Complete]) VALUES (7, 1, N'abc', CAST(N'2024-04-24' AS Date), CAST(N'2024-04-25' AS Date), N'abcx', N'abc', N'Private', N'Y  ')
SET IDENTITY_INSERT [dbo].[todotbl] OFF
GO
SET IDENTITY_INSERT [dbo].[usertbl] ON 

INSERT [dbo].[usertbl] ([userIdx], [name], [department], [userId], [password], [lastLoginDateTime]) VALUES (1, N'Yoo', 2, N'admin', N'admin', NULL)
INSERT [dbo].[usertbl] ([userIdx], [name], [department], [userId], [password], [lastLoginDateTime]) VALUES (2, N'Kim', 3, N'manager', N'manager', NULL)
INSERT [dbo].[usertbl] ([userIdx], [name], [department], [userId], [password], [lastLoginDateTime]) VALUES (3, N'Lee', 1, N'asdf', N'asdf', NULL)
SET IDENTITY_INSERT [dbo].[usertbl] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__usertbl__CB9A1CFEC3577916]    Script Date: 2024-04-29 오전 12:48:29 ******/
ALTER TABLE [dbo].[usertbl] ADD  CONSTRAINT [UQ__usertbl__CB9A1CFEC3577916] UNIQUE NONCLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[todotbl]  WITH CHECK ADD  CONSTRAINT [FK_todotbl_usertbl] FOREIGN KEY([userIdx])
REFERENCES [dbo].[usertbl] ([userIdx])
GO
ALTER TABLE [dbo].[todotbl] CHECK CONSTRAINT [FK_todotbl_usertbl]
GO
ALTER TABLE [dbo].[usertbl]  WITH CHECK ADD  CONSTRAINT [FK_usertbl_departmenttbl] FOREIGN KEY([department])
REFERENCES [dbo].[departmenttbl] ([depIdx])
GO
ALTER TABLE [dbo].[usertbl] CHECK CONSTRAINT [FK_usertbl_departmenttbl]
GO
USE [master]
GO
ALTER DATABASE [TodoManagement] SET  READ_WRITE 
GO
