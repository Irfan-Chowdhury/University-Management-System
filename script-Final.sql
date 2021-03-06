USE [master]
GO
/****** Object:  Database [Mvc_project_DB]    Script Date: 09/30/2018 12:29:31 ******/
CREATE DATABASE [Mvc_project_DB] ON  PRIMARY 
( NAME = N'Mvc_project_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Mvc_project_DB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Mvc_project_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Mvc_project_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Mvc_project_DB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mvc_project_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mvc_project_DB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Mvc_project_DB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Mvc_project_DB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Mvc_project_DB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Mvc_project_DB] SET ARITHABORT OFF
GO
ALTER DATABASE [Mvc_project_DB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Mvc_project_DB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Mvc_project_DB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Mvc_project_DB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Mvc_project_DB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Mvc_project_DB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Mvc_project_DB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Mvc_project_DB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Mvc_project_DB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Mvc_project_DB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Mvc_project_DB] SET  DISABLE_BROKER
GO
ALTER DATABASE [Mvc_project_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Mvc_project_DB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Mvc_project_DB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Mvc_project_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Mvc_project_DB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Mvc_project_DB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Mvc_project_DB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Mvc_project_DB] SET  READ_WRITE
GO
ALTER DATABASE [Mvc_project_DB] SET RECOVERY FULL
GO
ALTER DATABASE [Mvc_project_DB] SET  MULTI_USER
GO
ALTER DATABASE [Mvc_project_DB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Mvc_project_DB] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Mvc_project_DB', N'ON'
GO
USE [Mvc_project_DB]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 09/30/2018 12:29:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [varchar](50) NULL,
	[DepartmentName] [varchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON
INSERT [dbo].[Department] ([Id], [DepartmentCode], [DepartmentName]) VALUES (1, N'CSE', N'Computer Science & Engineering')
INSERT [dbo].[Department] ([Id], [DepartmentCode], [DepartmentName]) VALUES (2, N'EEE', N'Electrical & Electronics Engineering ')
INSERT [dbo].[Department] ([Id], [DepartmentCode], [DepartmentName]) VALUES (3, N'ETE', N'Electronics & Telecommunication Engineering')
INSERT [dbo].[Department] ([Id], [DepartmentCode], [DepartmentName]) VALUES (4, N'CIVIL', N'Civil Engineering')
INSERT [dbo].[Department] ([Id], [DepartmentCode], [DepartmentName]) VALUES (5, N'ME', N'Mechanical Engineering')
SET IDENTITY_INSERT [dbo].[Department] OFF
/****** Object:  Table [dbo].[Day]    Script Date: 09/30/2018 12:29:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Day](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DayName] [varchar](50) NULL,
 CONSTRAINT [PK_Day] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Day] ON
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (1, N'Sat')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (2, N'Sun')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (3, N'Mon')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (4, N'Thu')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (5, N'Wed')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (6, N'Thu')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (7, N'Fri')
SET IDENTITY_INSERT [dbo].[Day] OFF
/****** Object:  Table [dbo].[Designation]    Script Date: 09/30/2018 12:29:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [varchar](50) NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Designation] ON
INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (1, N'Professor')
INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (2, N'Associate Professor')
INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (3, N'Assistance Professor')
INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (4, N'Lecturer')
SET IDENTITY_INSERT [dbo].[Designation] OFF
/****** Object:  Table [dbo].[Grade]    Script Date: 09/30/2018 12:29:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [varchar](50) NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Grade] ON
INSERT [dbo].[Grade] ([Id], [Grade]) VALUES (1, N'A+')
INSERT [dbo].[Grade] ([Id], [Grade]) VALUES (2, N'A')
INSERT [dbo].[Grade] ([Id], [Grade]) VALUES (3, N'A-')
INSERT [dbo].[Grade] ([Id], [Grade]) VALUES (4, N'B')
INSERT [dbo].[Grade] ([Id], [Grade]) VALUES (5, N'B+')
INSERT [dbo].[Grade] ([Id], [Grade]) VALUES (6, N'C')
INSERT [dbo].[Grade] ([Id], [Grade]) VALUES (7, N'F')
SET IDENTITY_INSERT [dbo].[Grade] OFF
/****** Object:  Table [dbo].[Semester]    Script Date: 09/30/2018 12:29:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SemesterName] [varchar](50) NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Semester] ON
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (1, N'1st')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (2, N'2nd')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (3, N'3rd')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (4, N'4th')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (5, N'5th')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (6, N'6th')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (7, N'7th')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (8, N'8th')
SET IDENTITY_INSERT [dbo].[Semester] OFF
/****** Object:  Table [dbo].[Room]    Script Date: 09/30/2018 12:29:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](50) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (1, N'C-101')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (2, N'C-102')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (3, N'C-103')
SET IDENTITY_INSERT [dbo].[Room] OFF
/****** Object:  Table [dbo].[TestingTable]    Script Date: 09/30/2018 12:29:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestingTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeptId] [int] NULL,
	[CourseId] [int] NULL,
	[RoomId] [int] NULL,
	[DayId] [int] NULL,
	[FromTime] [varchar](50) NULL,
	[ToTime] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_TestingTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TestingTable] ON
INSERT [dbo].[TestingTable] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (27, 1, 1, 1, 1, N'09/20/2018 10:30 AM', N'09/20/2018 11:00 AM', NULL)
INSERT [dbo].[TestingTable] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (28, 1, 1, 2, 1, N'09/20/2018 11:00 AM', N'09/20/2018 12:00 PM', NULL)
INSERT [dbo].[TestingTable] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (29, 2, 2, 3, 1, N'09/20/2018 1:00 PM', N'09/19/2018 1:45 PM', NULL)
INSERT [dbo].[TestingTable] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (31, 1, 2, 3, 4, N'12:13', N'12:32', N'Allocated')
INSERT [dbo].[TestingTable] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (32, 3, 3, 3, 3, N'09/24/2018 2:15 PM', N'09/24/2018 3:15 PM', N'Allocated')
SET IDENTITY_INSERT [dbo].[TestingTable] OFF
/****** Object:  Table [dbo].[Teacher]    Script Date: 09/30/2018 12:29:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[DesignationId] [int] NULL,
	[DepartmentId] [int] NULL,
	[CreditToBeTaken] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (1, N'Shamsul Alam', N'ssss@gmail.com', N'chawkbazar', N'0101010100', 1, NULL, CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (2, N'Karim Uddin', N'eee@gmail.com', N'muradpur', N'01919100', 2, NULL, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (3, N'Irfanul Haque', N'Chittagong', N'irfan@gmail.com', N'123456', 1, 5, CAST(6.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (4, N'Md Shafullah', N'Chawakbazar', N'shafi@gmail.com', N'0184543555', 3, 1, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (5, N'Md Sanaullah', N'Chawakbazar', N'sanaul@gmail.com', N'0184543555', 2, 1, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (6, N'Tanvir Ahsan', N'Chawakbazar', N'tanvir123@gmail.com', N'0184543555', 2, 1, CAST(13.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (7, N'Tanvir Ahsan Mulla', N'Chawakbazar', N'tanvir13@gmail.com', N'0184543552', 1, 2, CAST(13.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (8, N' Ahsan Mulla', N'Chawakbazar', N'tanir13@gmail.com', N'0184543552', 2, 2, CAST(13.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (9, N'Jasim Uddin', N'Chawakbazar', N'jasim@gmail.com', N'0197467655', 3, 2, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (10, N'Ataur Rahman', N'Chawakbazar', N'ata@gmail.com', N'01974676551', 2, 2, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (11, N'Ataur Rahman Chy', N'Chawakbazar', N'ata123@gmail.com', N'01974676551', 4, 2, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (12, N'Mumen Munna', N'Chawakbazar', N'munna@gmail.com', N'0197467650', 1, 3, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (13, N'Arshadul Alam', N'Chawakbazar', N'alam098@gmail.com', N'0197467650', 3, 3, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (14, N'Arshadul Anwar', N'Chawakbazar', N'anw@gmail.com', N'01974676551', 4, 3, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (15, N'Touhidul Alam', N'Chawakbazar', N'tohid886@gmail.com', N'01974676551', 3, 4, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (16, N'Mohiuddin Alam', N'Muradpur', N'mohi@gmail.com', N'0184543555', 4, 4, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (17, N'Sikandar Alam', N'Muradpur', N'sikandar@gmail.com', N'0184543555', 2, 4, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (18, N'Mahadi Hasan', N'Muradpur', N'maha@gmail.com', N'0184543555', 2, 5, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (19, N'Md Kafil', N'Muradpur', N'kafi@gmail.com', N'0184543555', 4, 5, CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [Address], [Contact], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (20, N'Md Rimon Uddin', N'Muradpur', N'rimon@gmail.com', N'0184543552', 3, 5, CAST(13.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Teacher] OFF
/****** Object:  Table [dbo].[RegisterStudent]    Script Date: 09/30/2018 12:29:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RegisterStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[ContactNo] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[DeptId] [int] NULL,
	[RegNo] [varchar](50) NULL,
 CONSTRAINT [PK_RegisterStudent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[RegisterStudent] ON
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (2, N'Warid bin Azad', N'cse@gmail.com', N'0101010101', N'25-03-18', N'Muradpur', 1, N'CSE-2012-001')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (3, N'Ruhul', N'eee@gmail.com', N'0101010101', N'25-03-18', N'Muradpur', 2, N'EEE-2012-001')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (4, N'Karir', N'ete&gmail.com', N'9090909009', N'25-03-18', N'Chawkbazar', 3, N'ETE-2013-001')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (5, N'Irfan Chowdhury', N'chowdhury@gmail.com', N'01829498634', N'Sep 23 2018 12:00AM', N'Chittagong', 5, N'ME-2018-002')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (6, N'Md Pias', N'pias@gmail.com', N'123456', N'Sep 24 2018 12:00AM', N'Chittagong', 5, N'ME-2018-003')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (7, N'Karim', N'karim@gmail.com', N'01719178178', N'Mar 23 2018 12:00AM', N'Muradpur', 1, N'CSE-2018-002')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (8, N'Karim Mia', N'karimmia@gmail.com', N'01781718791', N'Mar 25 2018 12:00AM', N'Muradpur', 1, N'CSE-2018-003')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (9, N'Karim Junior', N'karimJ@gmail.com', N'01982624357', N'Mar 25 2019 12:00AM', N'Muradpur', 1, N'CSE-2019-002')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (10, N'Aniss Zaman', N'azaman@gmail.com', N'0197467655', N'Aug 30 2017 12:00AM', N'Chawakbazar', 5, N'ME-2017-002')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (11, N'Hasan Abdullah', N'hasan65263@gmail.com', N'0197467655', N'Sep 30 2016 12:00AM', N'Chawakbazar', 4, N'CIVIL-2016-002')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (12, N'Abrar Ibn Ali', N'abrarali@gmail.com', N'0184543555', N'Aug 30 2015 12:00AM', N'Chawakbazar', 2, N'EEE-2015-001')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (13, N'Abrar Bin Ivan', N'ivan@gmail.com', N'0184543555', N'Aug 30 2015 12:00AM', N'Chawakbazar', 5, N'ME-2015-001')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (14, N'Wasim Jafar', N'wasim@gmail.com', N'01974676551', N'Sep 30 2019 12:00AM', N'Muradpur', 4, N'CIVIL-2019-001')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (15, N'Azmain Chy', N'azma090@gmail.com', N'0197467655', N'Sep 22 2020 12:00AM', N'Muradpur', 3, N'ETE-2020-001')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (16, N'Hasnat Karim', N'hasnat@gmail.com', N'0197467658', N'Sep 30 2017 12:00AM', N'Muradpur', 3, N'ETE-2017-001')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (17, N'Hasnat Karim Chy', N'hasnachyt@gmail.com', N'0197467658', N'Sep 30 2016 12:00AM', N'Muradpur', 3, N'ETE-2016-001')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (18, N'Ishtiaq Ahmed', N'isti@gmail.com', N'0197467655', N'Sep 20 2000 12:00AM', N'Chawakbazar', 4, N'CIVIL-2000-001')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (19, N'Ishtiaq Ahmed Shovan', N'isadati@gmail.com', N'0197467655', N'Sep 20 2000 12:00AM', N'Chawakbazar', 5, N'ME-2000-001')
INSERT [dbo].[RegisterStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DeptId], [RegNo]) VALUES (20, N'Helal Abdullah', N'helo@gmail.com', N'0197467655', N'Jul 30 2008 12:00AM', N'Muradpur', 4, N'CIVIL-2008-001')
SET IDENTITY_INSERT [dbo].[RegisterStudent] OFF
/****** Object:  Table [dbo].[Course]    Script Date: 09/30/2018 12:29:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [varchar](50) NULL,
	[CourseName] [varchar](50) NULL,
	[CourseCredit] [decimal](18, 2) NULL,
	[CourseDescription] [varchar](50) NULL,
	[DeptId] [int] NULL,
	[SemesterId] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1, N'CSE101', N'OOP 1', CAST(3.50 AS Decimal(18, 2)), N'Core', 1, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (2, N'EEE101', N'Circuit Theory', CAST(2.00 AS Decimal(18, 2)), N'Core', 2, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1003, N'CSE102', N'Java Programming', CAST(2.00 AS Decimal(18, 2)), N'Core', 1, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1004, N'ETE101', N'Fundamental of Electronics', CAST(3.50 AS Decimal(18, 2)), N'Core', 3, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1005, N'CE-101', N'Civil Fundamental', CAST(3.00 AS Decimal(18, 2)), N'Core', 4, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1006, N'ME-1', N'Mechanical Fundamental', CAST(3.00 AS Decimal(18, 2)), N'good', 5, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1007, N'ME-2', N'Mechanihal Function', CAST(3.00 AS Decimal(18, 2)), N'good', 5, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1008, N'CSE-5', N'Pulse Technique', CAST(3.00 AS Decimal(18, 2)), N'good', 1, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1009, N'CE-103', N'Civil Law', CAST(3.00 AS Decimal(18, 2)), N'Core', 4, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1010, N'CE-104', N'Building Architecture', CAST(3.00 AS Decimal(18, 2)), N'Core', 4, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1011, N'CSE-102', N'Algorithm', CAST(3.00 AS Decimal(18, 2)), N'Core', 1, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1012, N'CSE-103', N'Algorithm Sessional', CAST(1.00 AS Decimal(18, 2)), N'Core', 1, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1013, N'CSE-104', N'Data Structure ', CAST(3.00 AS Decimal(18, 2)), N'Core', 1, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1014, N'EEE-102', N'EEE-2', CAST(3.00 AS Decimal(18, 2)), N'Core', 2, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1015, N'EEE-103', N'AC Theory', CAST(3.00 AS Decimal(18, 2)), N'Core', 2, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1016, N'EEE-104', N'DC Theory', CAST(3.00 AS Decimal(18, 2)), N'Core', 2, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1017, N'EEE-105', N'DC Motor', CAST(3.00 AS Decimal(18, 2)), N'Core', 2, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1018, N'ETE-103', N'Networking 1', CAST(3.00 AS Decimal(18, 2)), N'Core', 3, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1019, N'ETE-104', N'Networking 2', CAST(3.00 AS Decimal(18, 2)), N'Core', 3, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1020, N'ETE-105', N'Networking in Electronics', CAST(3.00 AS Decimal(18, 2)), N'Core', 3, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1021, N'CE-102', N'Civil Drawing', CAST(3.00 AS Decimal(18, 2)), N'Core', 4, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1022, N'ME-103', N'Physics 1', CAST(3.00 AS Decimal(18, 2)), N'Good', 5, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1023, N'ME-104', N'Physics 2', CAST(3.00 AS Decimal(18, 2)), N'Good', 5, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DeptId], [SemesterId]) VALUES (1024, N'ME-105', N'Polymer ', CAST(3.00 AS Decimal(18, 2)), N'Good', 5, 1)
SET IDENTITY_INSERT [dbo].[Course] OFF
/****** Object:  Table [dbo].[EnrollACourse]    Script Date: 09/30/2018 12:29:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EnrollACourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[CourseId] [int] NULL,
	[GradeId] [int] NULL,
	[Date] [varchar](50) NULL,
	[DeptId] [int] NULL,
 CONSTRAINT [PK_EnrollACourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[EnrollACourse] ON
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (2, 2, 1, 1, N'25-03-18', 1)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1005, 3, 2, 2, N'24-09-2018', 2)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1006, 4, 1004, 3, N'24-09-2018', 3)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1007, 6, 1007, 2, N'24-09-2018', 5)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1008, 2, 1008, 6, N'24-09-2018', 1)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1009, 2, 1003, 1, N'24-09-2018', 1)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1010, 7, 1, 1, N'2018-03-25', 1)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1011, 7, 1003, 4, N'03/25/2018', 1)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1012, 7, 1008, 5, N'03/25/2018', 1)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1013, 8, 1, 2, N'03/25/2018', 1)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1014, 8, 1003, 1, N'02/03/25', 1)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1015, 9, 1, 1, N'03/25/2018', 1)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1016, 9, 1003, NULL, N'03/25/2018', 1)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1017, 13, 1006, NULL, N'08/29/2018', 5)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1018, 13, 1023, NULL, N'08/28/2018', 5)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1019, 14, 1010, 2, N'08/15/2018', 4)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1020, 14, 1021, 7, N'09/04/2018', 4)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1021, 19, 1007, 2, N'09/19/2018', 5)
INSERT [dbo].[EnrollACourse] ([Id], [StudentId], [CourseId], [GradeId], [Date], [DeptId]) VALUES (1022, 18, 1009, 1, N'09/19/2018', 4)
SET IDENTITY_INSERT [dbo].[EnrollACourse] OFF
/****** Object:  View [dbo].[DepartmentView]    Script Date: 09/30/2018 12:29:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DepartmentView]
AS
SELECT        d.Id AS DepartmentId, d.DepartmentCode, d.DepartmentName, c.Id AS CourseId, c.CourseCode, c.CourseName, c.CourseCredit, c.CourseDescription, c.DeptId, c.SemesterId
FROM            dbo.Department AS d INNER JOIN
                         dbo.Course AS c ON d.Id = c.DeptId
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "d"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 167
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 260
               Bottom = 199
               Right = 446
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DepartmentView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DepartmentView'
GO
/****** Object:  Table [dbo].[ClassRoomAllocate]    Script Date: 09/30/2018 12:29:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassRoomAllocate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeptId] [int] NULL,
	[CourseId] [int] NULL,
	[RoomId] [int] NULL,
	[DayId] [int] NULL,
	[FromTime] [varchar](50) NULL,
	[ToTime] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_ClassRoom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ClassRoomAllocate] ON
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (26, 1, 1, 1, 1, N'10:00 AM', N'11:00 AM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (27, 1, 1003, 2, 1, N'11:00 AM', N'12:00 PM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (28, 2, 2, 3, 1, N'1:00 PM', N'2:00 PM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (29, 1, 1, 1, 1, N'7:16 PM', N'7:16 PM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (30, 2, 2, 1, 3, N'7:27 PM', N'7:27 PM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (31, 1, 1, 1, 1, N'7:39 PM', N'7:39 PM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (32, 2, 2, 1, 2, N'7:57 PM', N'7:57 PM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (33, 4, 1005, 3, 7, N'7:57 PM', N'7:57 PM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (34, 2, 2, 1, 1, N'7:59 PM', N'7:59 PM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (35, 4, 1005, 3, 6, N'8:00 PM', N'8:00 PM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (36, 2, 2, 1, 1, N'8:04 PM', N'8:04 PM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (37, 1, 1, 1, 2, N'8:13 PM', N'8:13 PM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (38, 1, 1, 1, 2, N'8:34 PM', N'8:34 PM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (39, 4, 1005, 1, 1, N'8:50 PM', N'8:50 PM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (40, 1, 1, 3, 1, N'8:54 PM', N'8:54 PM', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (41, 1, 1, 1, 1, N'1:00am', N'2:00am', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (42, 5, 1006, 1, 1, N'10:00am', N'11:00am', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (43, 5, 1006, 1, 1, N'7:00pm', N'8:00pm', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (44, 4, 1005, 2, 2, N'7:30pm', N'8:00pm', N'Unallocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (45, 1, 1011, 2, 3, N'11:00am', N'12:00pm', N'Allocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (46, 4, 1010, 2, 3, N'10:30am', N'11:00am', N'Allocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (47, 5, 1007, 2, 3, N'10:30am', N'11:30am', N'Allocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (48, 5, 1023, 1, 1, N'11:00am', N'12:00pm', N'Allocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (49, 5, 1024, 1, 1, N'11:30am', N'12:00pm', N'Allocated')
INSERT [dbo].[ClassRoomAllocate] ([Id], [DeptId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime], [Status]) VALUES (50, 5, 1007, 1, 1, N'11:30am', N'12:30pm', N'Allocated')
SET IDENTITY_INSERT [dbo].[ClassRoomAllocate] OFF
/****** Object:  Table [dbo].[CourseAssignToTeacher]    Script Date: 09/30/2018 12:29:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourseAssignToTeacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NULL,
	[CourseId] [int] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_CourseAssignToTeacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CourseAssignToTeacher] ON
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (1, 1, 1, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (2, 2, 2, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (3, 3, 1006, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (4, 13, 1020, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (5, 6, 1008, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (6, 5, 1011, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (7, 14, 1019, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (8, 16, 1009, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (9, 5, 1012, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (10, 16, 1021, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (11, 6, 1013, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (12, 9, 1015, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (13, 3, 1007, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (14, 17, 1010, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (15, 4, 1003, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (16, 15, 1005, N'Assigned')
INSERT [dbo].[CourseAssignToTeacher] ([Id], [TeacherId], [CourseId], [Status]) VALUES (17, 10, 1016, N'Assigned')
SET IDENTITY_INSERT [dbo].[CourseAssignToTeacher] OFF
/****** Object:  ForeignKey [FK_Department_Department]    Script Date: 09/30/2018 12:29:33 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Department] FOREIGN KEY([Id])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Department]
GO
/****** Object:  ForeignKey [FK_Teacher_Department]    Script Date: 09/30/2018 12:29:33 ******/
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Department]
GO
/****** Object:  ForeignKey [FK_Teacher_Designation]    Script Date: 09/30/2018 12:29:33 ******/
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Designation]
GO
/****** Object:  ForeignKey [FK_RegisterStudent_Department]    Script Date: 09/30/2018 12:29:33 ******/
ALTER TABLE [dbo].[RegisterStudent]  WITH CHECK ADD  CONSTRAINT [FK_RegisterStudent_Department] FOREIGN KEY([DeptId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[RegisterStudent] CHECK CONSTRAINT [FK_RegisterStudent_Department]
GO
/****** Object:  ForeignKey [FK_Course_Department]    Script Date: 09/30/2018 12:29:33 ******/
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department] FOREIGN KEY([DeptId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department]
GO
/****** Object:  ForeignKey [FK_Course_Semester]    Script Date: 09/30/2018 12:29:33 ******/
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Semester] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Semester]
GO
/****** Object:  ForeignKey [FK_EnrollACourse_Course]    Script Date: 09/30/2018 12:29:33 ******/
ALTER TABLE [dbo].[EnrollACourse]  WITH CHECK ADD  CONSTRAINT [FK_EnrollACourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[EnrollACourse] CHECK CONSTRAINT [FK_EnrollACourse_Course]
GO
/****** Object:  ForeignKey [FK_EnrollACourse_Grade]    Script Date: 09/30/2018 12:29:33 ******/
ALTER TABLE [dbo].[EnrollACourse]  WITH CHECK ADD  CONSTRAINT [FK_EnrollACourse_Grade] FOREIGN KEY([GradeId])
REFERENCES [dbo].[Grade] ([Id])
GO
ALTER TABLE [dbo].[EnrollACourse] CHECK CONSTRAINT [FK_EnrollACourse_Grade]
GO
/****** Object:  ForeignKey [FK_EnrollACourse_RegisterStudent]    Script Date: 09/30/2018 12:29:33 ******/
ALTER TABLE [dbo].[EnrollACourse]  WITH CHECK ADD  CONSTRAINT [FK_EnrollACourse_RegisterStudent] FOREIGN KEY([StudentId])
REFERENCES [dbo].[RegisterStudent] ([Id])
GO
ALTER TABLE [dbo].[EnrollACourse] CHECK CONSTRAINT [FK_EnrollACourse_RegisterStudent]
GO
/****** Object:  ForeignKey [FK_ClassRoom_Course]    Script Date: 09/30/2018 12:29:34 ******/
ALTER TABLE [dbo].[ClassRoomAllocate]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoom_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[ClassRoomAllocate] CHECK CONSTRAINT [FK_ClassRoom_Course]
GO
/****** Object:  ForeignKey [FK_ClassRoom_Day]    Script Date: 09/30/2018 12:29:34 ******/
ALTER TABLE [dbo].[ClassRoomAllocate]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoom_Day] FOREIGN KEY([DayId])
REFERENCES [dbo].[Day] ([Id])
GO
ALTER TABLE [dbo].[ClassRoomAllocate] CHECK CONSTRAINT [FK_ClassRoom_Day]
GO
/****** Object:  ForeignKey [FK_ClassRoom_Department]    Script Date: 09/30/2018 12:29:34 ******/
ALTER TABLE [dbo].[ClassRoomAllocate]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoom_Department] FOREIGN KEY([DeptId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[ClassRoomAllocate] CHECK CONSTRAINT [FK_ClassRoom_Department]
GO
/****** Object:  ForeignKey [FK_ClassRoom_Room]    Script Date: 09/30/2018 12:29:34 ******/
ALTER TABLE [dbo].[ClassRoomAllocate]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoom_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[ClassRoomAllocate] CHECK CONSTRAINT [FK_ClassRoom_Room]
GO
/****** Object:  ForeignKey [FK_CourseAssignToTeacher_Course]    Script Date: 09/30/2018 12:29:34 ******/
ALTER TABLE [dbo].[CourseAssignToTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignToTeacher_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[CourseAssignToTeacher] CHECK CONSTRAINT [FK_CourseAssignToTeacher_Course]
GO
/****** Object:  ForeignKey [FK_CourseAssignToTeacher_Teacher]    Script Date: 09/30/2018 12:29:34 ******/
ALTER TABLE [dbo].[CourseAssignToTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignToTeacher_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[CourseAssignToTeacher] CHECK CONSTRAINT [FK_CourseAssignToTeacher_Teacher]
GO
