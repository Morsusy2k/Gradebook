/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [Max.Gradebook]    Script Date: 12/19/2017 2:08:01 PM ******/
CREATE DATABASE [Max.Gradebook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Max.Gradebook', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Max.Gradebook.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Max.Gradebook_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Max.Gradebook_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Max.Gradebook] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Max.Gradebook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Max.Gradebook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Max.Gradebook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Max.Gradebook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Max.Gradebook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Max.Gradebook] SET ARITHABORT OFF 
GO
ALTER DATABASE [Max.Gradebook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Max.Gradebook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Max.Gradebook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Max.Gradebook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Max.Gradebook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Max.Gradebook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Max.Gradebook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Max.Gradebook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Max.Gradebook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Max.Gradebook] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Max.Gradebook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Max.Gradebook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Max.Gradebook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Max.Gradebook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Max.Gradebook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Max.Gradebook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Max.Gradebook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Max.Gradebook] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Max.Gradebook] SET  MULTI_USER 
GO
ALTER DATABASE [Max.Gradebook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Max.Gradebook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Max.Gradebook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Max.Gradebook] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Max.Gradebook] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Max.Gradebook] SET QUERY_STORE = OFF
GO
USE [Max.Gradebook]
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
USE [Max.Gradebook]
GO
/****** Object:  Table [dbo].[FieldOfStudy]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldOfStudy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FieldOfStudyHasSubjects]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldOfStudyHasSubjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FieldOfStudyId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gradebook]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gradebook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PClassId] [int] NOT NULL,
	[SchoolYearStart] [datetime] NOT NULL,
	[SchoolYearEnd] [datetime] NOT NULL,
	[Editable] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mark]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mark](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MarksId] [int] NOT NULL,
	[Grade] [int] NOT NULL,
	[Type] [nchar](30) NOT NULL,
	[Important] [bit] NOT NULL,
	[Final] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marks]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PupilId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[FinalMark] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PClass]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FieldOfStudyId] [int] NOT NULL,
	[Generation] [nvarchar](7) NOT NULL,
	[Year] [nvarchar](4) NOT NULL,
	[PClassIndex] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pupil]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pupil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PClassId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectLesson]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectLesson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GradebookId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[LessonTheme] [nvarchar](254) NULL,
	[Date] [datetime] NOT NULL,
	[TimeOfLesson] [nvarchar](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectLessonsHaveAbsentees]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectLessonsHaveAbsentees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subjectLessonId] [int] NOT NULL,
	[pupilId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_SUBJECTLESSONSHAVEABSENTEES] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[Surname] [nvarchar](25) NOT NULL,
	[Username] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](254) NOT NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserHasRoles]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserHasRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_UserHasRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FieldOfStudy] ON 

INSERT [dbo].[FieldOfStudy] ([Id], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (1, N'Information Technology', 95, NULL, CAST(N'2017-12-01' AS Date), NULL)
INSERT [dbo].[FieldOfStudy] ([Id], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (2, N'Computer Mathematics', 95, 113, CAST(N'2017-12-01' AS Date), CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudy] ([Id], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (3, N'Software Development', 95, NULL, CAST(N'2017-12-01' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[FieldOfStudy] OFF
SET IDENTITY_INSERT [dbo].[FieldOfStudyHasSubjects] ON 

INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (16, 1, 12, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (17, 1, 13, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (26, 2, 1, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (27, 2, 3, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (18, 1, 14, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (19, 1, 15, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (20, 1, 16, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (21, 1, 17, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (22, 1, 18, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (23, 1, 19, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (24, 1, 20, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (25, 1, 21, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (28, 2, 12, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (29, 2, 13, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (30, 2, 14, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (31, 2, 17, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (32, 2, 18, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (33, 2, 19, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (34, 2, 20, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (35, 2, 21, 113, CAST(N'2017-12-14' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (36, 3, 2, 113, CAST(N'2017-12-16' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (37, 3, 3, 113, CAST(N'2017-12-16' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (38, 3, 4, 113, CAST(N'2017-12-16' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (39, 3, 12, 113, CAST(N'2017-12-16' AS Date))
INSERT [dbo].[FieldOfStudyHasSubjects] ([Id], [FieldOfStudyId], [SubjectId], [CreatedBy], [CreatedDate]) VALUES (40, 3, 13, 113, CAST(N'2017-12-16' AS Date))
SET IDENTITY_INSERT [dbo].[FieldOfStudyHasSubjects] OFF
SET IDENTITY_INSERT [dbo].[Gradebook] ON 

INSERT [dbo].[Gradebook] ([Id], [PClassId], [SchoolYearStart], [SchoolYearEnd], [Editable], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (1, 1, CAST(N'2017-12-05T00:00:00.000' AS DateTime), CAST(N'2016-12-05T00:00:00.000' AS DateTime), 0, 95, 113, CAST(N'2017-12-06' AS Date), CAST(N'2017-12-15' AS Date))
INSERT [dbo].[Gradebook] ([Id], [PClassId], [SchoolYearStart], [SchoolYearEnd], [Editable], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (7, 5, CAST(N'2017-12-04T00:00:00.000' AS DateTime), CAST(N'2017-12-05T00:00:00.000' AS DateTime), 0, 113, NULL, CAST(N'2017-12-15' AS Date), NULL)
INSERT [dbo].[Gradebook] ([Id], [PClassId], [SchoolYearStart], [SchoolYearEnd], [Editable], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (3, 2, CAST(N'2014-01-01T00:00:00.000' AS DateTime), CAST(N'2018-01-01T00:00:00.000' AS DateTime), 0, 95, 113, CAST(N'2017-12-06' AS Date), CAST(N'2017-12-15' AS Date))
SET IDENTITY_INSERT [dbo].[Gradebook] OFF
SET IDENTITY_INSERT [dbo].[Mark] ON 

INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (1, 1, 5, N'Predavanja                    ', 0, 0, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (2, 1, 4, N'Predavanja                    ', 0, 0, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (3, 1, 5, N'Vezbe                         ', 1, 0, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (4, 1, 3, N'Vezbe                         ', 0, 0, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (5, 2, 4, N'Predavanja                    ', 0, 0, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (6, 2, 2, N'Vezbe                         ', 0, 0, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (7, 2, 4, N'Predavanja                    ', 0, 0, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (8, 2, 4, N'Vezbe                         ', 0, 0, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (9, 2, 5, N'Vezbe                         ', 0, 1, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (10, 1, 5, N'Aktivnost                     ', 0, 0, 95, NULL, CAST(N'2017-12-09' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (11, 1, 4, N'Aktivnost                     ', 1, 0, 95, NULL, CAST(N'2017-12-09' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (12, 1, 5, N'Aktivnost                     ', 0, 0, 95, NULL, CAST(N'2017-12-09' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (17, 12, 5, N'Vezbe                         ', 0, 0, 113, NULL, CAST(N'2017-12-16' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (18, 12, 5, N'Vezbe                         ', 0, 0, 113, NULL, CAST(N'2017-12-17' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (19, 12, 5, N'Predavanja                    ', 0, 0, 113, NULL, CAST(N'2017-12-17' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (20, 12, 4, N'Predavanja                    ', 1, 0, 113, NULL, CAST(N'2017-12-17' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (21, 12, 4, N'Vezbe                         ', 0, 1, 113, NULL, CAST(N'2017-12-17' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (22, 12, 5, N'Predavanja                    ', 0, 1, 113, NULL, CAST(N'2017-12-17' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (13, 1, 3, N'Aktivnost                     ', 1, 0, 95, NULL, CAST(N'2017-12-09' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (14, 1, 2, N'Aktivnost                     ', 0, 0, 95, NULL, CAST(N'2017-12-09' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (15, 1, 3, N'Aktivnost                     ', 0, 1, 95, NULL, CAST(N'2017-12-09' AS Date), NULL)
INSERT [dbo].[Mark] ([Id], [MarksId], [Grade], [Type], [Important], [Final], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (16, 1, 4, N'Predavanja                    ', 0, 1, 95, NULL, CAST(N'2017-12-09' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Mark] OFF
SET IDENTITY_INSERT [dbo].[Marks] ON 

INSERT [dbo].[Marks] ([Id], [PupilId], [SubjectId], [FinalMark], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (1, 1, 1, 4, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Marks] ([Id], [PupilId], [SubjectId], [FinalMark], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (2, 1, 2, NULL, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Marks] ([Id], [PupilId], [SubjectId], [FinalMark], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (3, 1, 3, NULL, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Marks] ([Id], [PupilId], [SubjectId], [FinalMark], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (4, 1, 4, NULL, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Marks] ([Id], [PupilId], [SubjectId], [FinalMark], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (5, 2, 1, NULL, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Marks] ([Id], [PupilId], [SubjectId], [FinalMark], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (6, 2, 1, NULL, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Marks] ([Id], [PupilId], [SubjectId], [FinalMark], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (7, 2, 1, NULL, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Marks] ([Id], [PupilId], [SubjectId], [FinalMark], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (8, 3, 1, NULL, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Marks] ([Id], [PupilId], [SubjectId], [FinalMark], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (9, 3, 1, NULL, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Marks] ([Id], [PupilId], [SubjectId], [FinalMark], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (10, 2, 3, 5, 95, NULL, CAST(N'2017-12-07' AS Date), NULL)
INSERT [dbo].[Marks] ([Id], [PupilId], [SubjectId], [FinalMark], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (11, 2, 3, 5, 95, NULL, CAST(N'2017-12-09' AS Date), NULL)
INSERT [dbo].[Marks] ([Id], [PupilId], [SubjectId], [FinalMark], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (12, 1, 12, 5, 113, 113, CAST(N'2017-12-16' AS Date), CAST(N'2017-12-17' AS Date))
INSERT [dbo].[Marks] ([Id], [PupilId], [SubjectId], [FinalMark], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (13, 1, 13, NULL, 113, NULL, CAST(N'2017-12-17' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Marks] OFF
SET IDENTITY_INSERT [dbo].[PClass] ON 

INSERT [dbo].[PClass] ([Id], [UserId], [FieldOfStudyId], [Generation], [Year], [PClassIndex], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (1, 95, 1, N'2014', N'III', 1, 95, 113, CAST(N'2017-12-01' AS Date), CAST(N'2017-12-15' AS Date))
INSERT [dbo].[PClass] ([Id], [UserId], [FieldOfStudyId], [Generation], [Year], [PClassIndex], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (2, 111, 1, N'2013', N'IV', 2, 95, 113, CAST(N'2017-12-01' AS Date), CAST(N'2017-12-15' AS Date))
INSERT [dbo].[PClass] ([Id], [UserId], [FieldOfStudyId], [Generation], [Year], [PClassIndex], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (5, 111, 2, N'2015', N'I', 1, 113, NULL, CAST(N'2017-12-15' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[PClass] OFF
SET IDENTITY_INSERT [dbo].[Pupil] ON 

INSERT [dbo].[Pupil] ([Id], [PClassId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (1, 1, N'Darko Matic', 95, 113, CAST(N'2017-12-01' AS Date), CAST(N'2017-12-14' AS Date))
INSERT [dbo].[Pupil] ([Id], [PClassId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (2, 1, N'Vanja Grubic', 95, NULL, CAST(N'2017-12-01' AS Date), NULL)
INSERT [dbo].[Pupil] ([Id], [PClassId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (3, 1, N'Una Miric', 95, NULL, CAST(N'2017-12-01' AS Date), NULL)
INSERT [dbo].[Pupil] ([Id], [PClassId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (4, 1, N'Djordje Savin', 95, NULL, CAST(N'2017-12-01' AS Date), NULL)
INSERT [dbo].[Pupil] ([Id], [PClassId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (5, 1, N'Milan Ivanov', 95, NULL, CAST(N'2017-12-01' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Pupil] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Administrator')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (1008, N'Professor')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([Id], [UserId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (1, 95, N'Basic Programming 2', 95, 113, CAST(N'2017-12-05' AS Date), CAST(N'2017-12-16' AS Date))
INSERT [dbo].[Subject] ([Id], [UserId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (2, 112, N'Basic Electronics', 95, 113, CAST(N'2017-12-05' AS Date), CAST(N'2017-12-14' AS Date))
INSERT [dbo].[Subject] ([Id], [UserId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (3, 112, N'Technical Drawing', 95, 113, CAST(N'2017-12-05' AS Date), CAST(N'2017-12-14' AS Date))
INSERT [dbo].[Subject] ([Id], [UserId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (4, 112, N'Electronics 3', 95, 113, CAST(N'2017-12-05' AS Date), CAST(N'2017-12-14' AS Date))
INSERT [dbo].[Subject] ([Id], [UserId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (12, 112, N'Information Technology', 113, 113, CAST(N'2017-12-14' AS Date), CAST(N'2017-12-16' AS Date))
INSERT [dbo].[Subject] ([Id], [UserId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (13, 111, N'Mathematical Logic', 113, 113, CAST(N'2017-12-14' AS Date), CAST(N'2017-12-14' AS Date))
INSERT [dbo].[Subject] ([Id], [UserId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (14, 111, N'Mathematics 1', 113, 113, CAST(N'2017-12-14' AS Date), CAST(N'2017-12-14' AS Date))
INSERT [dbo].[Subject] ([Id], [UserId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (15, 111, N'Probability and Statistic', 113, 113, CAST(N'2017-12-14' AS Date), CAST(N'2017-12-14' AS Date))
INSERT [dbo].[Subject] ([Id], [UserId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (16, 95, N'Introduction to Technology', 113, NULL, CAST(N'2017-12-14' AS Date), NULL)
INSERT [dbo].[Subject] ([Id], [UserId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (17, 111, N'Mathematics 2', 113, 113, CAST(N'2017-12-14' AS Date), CAST(N'2017-12-14' AS Date))
INSERT [dbo].[Subject] ([Id], [UserId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (18, 95, N'Basic Programming ', 113, NULL, CAST(N'2017-12-14' AS Date), NULL)
INSERT [dbo].[Subject] ([Id], [UserId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (19, 95, N'Computer Systems', 113, NULL, CAST(N'2017-12-14' AS Date), NULL)
INSERT [dbo].[Subject] ([Id], [UserId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (20, 114, N'English 1', 113, 113, CAST(N'2017-12-14' AS Date), CAST(N'2017-12-14' AS Date))
INSERT [dbo].[Subject] ([Id], [UserId], [Name], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (21, 114, N'English 2', 113, 113, CAST(N'2017-12-14' AS Date), CAST(N'2017-12-14' AS Date))
SET IDENTITY_INSERT [dbo].[Subject] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Surname], [Username], [Password], [Email]) VALUES (95, N'Dragan', N'Ilić', N'Morsus', N'5f4dcc3b5aa765d61d8327deb882cf99', N'morsy2k@gmail.com')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Username], [Password], [Email]) VALUES (114, N'Milena', N'Kostić', N'Milena', N'5f4dcc3b5aa765d61d8327deb882cf99', N'milena@gmail.com')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Username], [Password], [Email]) VALUES (111, N'Milan', N'Milic', N'MileMile', N'5f4dcc3b5aa765d61d8327deb882cf99', N'mile@gmail.com')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Username], [Password], [Email]) VALUES (112, N'Dusan', N'Jović', N'Profesor1', N'5f4dcc3b5aa765d61d8327deb882cf99', N'prof@gmail.com')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Username], [Password], [Email]) VALUES (113, N'Admin', N'Istrator', N'Admin', N'5f4dcc3b5aa765d61d8327deb882cf99', N'admin@gmail.com')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserHasRoles] ON 

INSERT [dbo].[UserHasRoles] ([Id], [UserId], [RoleId], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (1007, 113, 1, 113, NULL, CAST(N'2017-12-11' AS Date), NULL)
INSERT [dbo].[UserHasRoles] ([Id], [UserId], [RoleId], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (1017, 112, 1008, 113, NULL, CAST(N'2017-12-16' AS Date), NULL)
INSERT [dbo].[UserHasRoles] ([Id], [UserId], [RoleId], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (1031, 114, 1008, 113, NULL, CAST(N'2017-12-16' AS Date), NULL)
INSERT [dbo].[UserHasRoles] ([Id], [UserId], [RoleId], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (1032, 111, 1008, 113, NULL, CAST(N'2017-12-16' AS Date), NULL)
INSERT [dbo].[UserHasRoles] ([Id], [UserId], [RoleId], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (1033, 95, 1, 113, NULL, CAST(N'2017-12-16' AS Date), NULL)
INSERT [dbo].[UserHasRoles] ([Id], [UserId], [RoleId], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (1034, 95, 1008, 113, NULL, CAST(N'2017-12-16' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[UserHasRoles] OFF
/****** Object:  Index [PK_FIELDOFSTUDY]    Script Date: 12/19/2017 2:08:02 PM ******/
ALTER TABLE [dbo].[FieldOfStudy] ADD  CONSTRAINT [PK_FIELDOFSTUDY] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_FIELDOFSTUDYHASSUBJECTS]    Script Date: 12/19/2017 2:08:02 PM ******/
ALTER TABLE [dbo].[FieldOfStudyHasSubjects] ADD  CONSTRAINT [PK_FIELDOFSTUDYHASSUBJECTS] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_GRADEBOOK]    Script Date: 12/19/2017 2:08:02 PM ******/
ALTER TABLE [dbo].[Gradebook] ADD  CONSTRAINT [PK_GRADEBOOK] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_MARK]    Script Date: 12/19/2017 2:08:02 PM ******/
ALTER TABLE [dbo].[Mark] ADD  CONSTRAINT [PK_MARK] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_MARKS]    Script Date: 12/19/2017 2:08:02 PM ******/
ALTER TABLE [dbo].[Marks] ADD  CONSTRAINT [PK_MARKS] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_PCLASS]    Script Date: 12/19/2017 2:08:02 PM ******/
ALTER TABLE [dbo].[PClass] ADD  CONSTRAINT [PK_PCLASS] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_PUPIL]    Script Date: 12/19/2017 2:08:02 PM ******/
ALTER TABLE [dbo].[Pupil] ADD  CONSTRAINT [PK_PUPIL] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_ROLE]    Script Date: 12/19/2017 2:08:02 PM ******/
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [PK_ROLE] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_SUBJECT]    Script Date: 12/19/2017 2:08:02 PM ******/
ALTER TABLE [dbo].[Subject] ADD  CONSTRAINT [PK_SUBJECT] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_SUBJECTLESSON]    Script Date: 12/19/2017 2:08:02 PM ******/
ALTER TABLE [dbo].[SubjectLesson] ADD  CONSTRAINT [PK_SUBJECTLESSON] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_USER]    Script Date: 12/19/2017 2:08:02 PM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [PK_USER] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FieldOfStudy]  WITH CHECK ADD  CONSTRAINT [FK_FieldOfStudy_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FieldOfStudy] CHECK CONSTRAINT [FK_FieldOfStudy_User]
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects]  WITH NOCHECK ADD  CONSTRAINT [FK_FieldOfStudyHasSubjects_FieldOfStudy] FOREIGN KEY([FieldOfStudyId])
REFERENCES [dbo].[FieldOfStudy] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects] CHECK CONSTRAINT [FK_FieldOfStudyHasSubjects_FieldOfStudy]
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects]  WITH NOCHECK ADD  CONSTRAINT [FK_FieldOfStudyHasSubjects_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects] CHECK CONSTRAINT [FK_FieldOfStudyHasSubjects_Subject]
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects]  WITH CHECK ADD  CONSTRAINT [FK_FieldOfStudyHasSubjects_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects] CHECK CONSTRAINT [FK_FieldOfStudyHasSubjects_User]
GO
ALTER TABLE [dbo].[Gradebook]  WITH CHECK ADD  CONSTRAINT [FK_Gradebook_PClass] FOREIGN KEY([PClassId])
REFERENCES [dbo].[PClass] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Gradebook] CHECK CONSTRAINT [FK_Gradebook_PClass]
GO
ALTER TABLE [dbo].[Gradebook]  WITH CHECK ADD  CONSTRAINT [FK_Gradebook_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Gradebook] CHECK CONSTRAINT [FK_Gradebook_User]
GO
ALTER TABLE [dbo].[Mark]  WITH NOCHECK ADD  CONSTRAINT [FK_Mark_Marks] FOREIGN KEY([MarksId])
REFERENCES [dbo].[Marks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mark] CHECK CONSTRAINT [FK_Mark_Marks]
GO
ALTER TABLE [dbo].[Mark]  WITH CHECK ADD  CONSTRAINT [FK_Mark_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Mark] CHECK CONSTRAINT [FK_Mark_User]
GO
ALTER TABLE [dbo].[Marks]  WITH NOCHECK ADD  CONSTRAINT [FK_Marks_Pupil] FOREIGN KEY([PupilId])
REFERENCES [dbo].[Pupil] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Pupil]
GO
ALTER TABLE [dbo].[Marks]  WITH NOCHECK ADD  CONSTRAINT [FK_Marks_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Subject]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_Marks_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_User]
GO
ALTER TABLE [dbo].[PClass]  WITH NOCHECK ADD  CONSTRAINT [FK_PClass_FieldOfStudy] FOREIGN KEY([FieldOfStudyId])
REFERENCES [dbo].[FieldOfStudy] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PClass] CHECK CONSTRAINT [FK_PClass_FieldOfStudy]
GO
ALTER TABLE [dbo].[PClass]  WITH NOCHECK ADD  CONSTRAINT [FK_PClass_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PClass] CHECK CONSTRAINT [FK_PClass_User]
GO
ALTER TABLE [dbo].[Pupil]  WITH NOCHECK ADD  CONSTRAINT [FK_Pupil_PClass] FOREIGN KEY([PClassId])
REFERENCES [dbo].[PClass] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pupil] CHECK CONSTRAINT [FK_Pupil_PClass]
GO
ALTER TABLE [dbo].[Subject]  WITH NOCHECK ADD  CONSTRAINT [FK_Subject_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_User]
GO
ALTER TABLE [dbo].[SubjectLesson]  WITH CHECK ADD  CONSTRAINT [FK_SubjectLesson_Gradebook] FOREIGN KEY([GradebookId])
REFERENCES [dbo].[Gradebook] ([Id])
GO
ALTER TABLE [dbo].[SubjectLesson] CHECK CONSTRAINT [FK_SubjectLesson_Gradebook]
GO
ALTER TABLE [dbo].[SubjectLesson]  WITH NOCHECK ADD  CONSTRAINT [FK_SubjectLesson_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectLesson] CHECK CONSTRAINT [FK_SubjectLesson_Subject]
GO
ALTER TABLE [dbo].[SubjectLesson]  WITH CHECK ADD  CONSTRAINT [FK_SubjectLesson_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SubjectLesson] CHECK CONSTRAINT [FK_SubjectLesson_User]
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees]  WITH NOCHECK ADD  CONSTRAINT [FK_SubjectLessonsHaveAbsentees_Pupil] FOREIGN KEY([pupilId])
REFERENCES [dbo].[Pupil] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees] CHECK CONSTRAINT [FK_SubjectLessonsHaveAbsentees_Pupil]
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees]  WITH NOCHECK ADD  CONSTRAINT [FK_SubjectLessonsHaveAbsentees_SubjectLesson] FOREIGN KEY([subjectLessonId])
REFERENCES [dbo].[SubjectLesson] ([Id])
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees] CHECK CONSTRAINT [FK_SubjectLessonsHaveAbsentees_SubjectLesson]
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees]  WITH CHECK ADD  CONSTRAINT [FK_SubjectLessonsHaveAbsentees_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees] CHECK CONSTRAINT [FK_SubjectLessonsHaveAbsentees_User]
GO
ALTER TABLE [dbo].[UserHasRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserHasRoles_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserHasRoles] CHECK CONSTRAINT [FK_UserHasRoles_Role]
GO
ALTER TABLE [dbo].[UserHasRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserHasRoles_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserHasRoles] CHECK CONSTRAINT [FK_UserHasRoles_User]
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyDelete]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyDelete]
(@Id int, @Version timestamp)
AS
DELETE FROM FieldOfStudy WHERE Id = @Id	  AND [Version] = @Version	
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyDeleteSubject]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyDeleteSubject]
@FieldId int
AS
DELETE FROM FieldOfStudyHasSubjects WHERE FieldOfStudyId = @FieldId
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyDeleteSubjects]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyDeleteSubjects]
@FieldId int
AS
DELETE FROM FieldOfStudyHasSubjects WHERE FieldOfStudyId = @FieldId
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyGetAll]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyGetAll]
AS
SELECT * FROM FieldOfStudy
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyGetById]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyGetById]
@Id int
AS
SELECT * FROM FieldOfStudy WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyGetSubjectsById_del]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyGetSubjectsById_del]
@Id int
AS
SELECT * FROM FieldOfStudyHasSubjects WHERE fieldOfStudyId = @Id
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyInsert]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyInsert]
(	
	@Id int OUTPUT,
	@Name nvarchar(50),
	@CreatedBy int,
	@ModifiedBy int = null,
	@CreatedDate date,
	@ModifiedDate date = null,
	@Version timestamp OUTPUT
)
AS
BEGIN

	INSERT INTO FieldOfStudy(Name, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
		VALUES(@Name, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)

	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM FieldOfStudy WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyInsertSubject]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyInsertSubject]
@FieldId int,
@SubjectId int,
@CreatedBy int,
@CreatedDate Date
AS
INSERT INTO FieldOfStudyHasSubjects(FieldOfStudyId, SubjectId, CreatedBy, CreatedDate) 
VALUES (@FieldId, @SubjectId, @CreatedBy, @CreatedDate)
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyUpdate]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyUpdate]
(
	@Id int,
	@Name nvarchar(50),
	@ModifiedBy int,
	@ModifiedDate date,
	@Version timestamp OUTPUT
)
AS
BEGIN
	UPDATE [dbo].[FieldOfStudy]
		SET Name = @Name, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate
		WHERE Id = @Id AND [Version] = @Version
		SELECT @Version = [Version] FROM [dbo].[FieldOfStudy] WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GradebookDelete]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookDelete]
(@Id int, @Version timestamp)
AS
DELETE FROM Gradebook WHERE Id = @Id AND [Version] = @Version	
GO
/****** Object:  StoredProcedure [dbo].[GradebookGetAll]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookGetAll]
AS
SELECT * FROM Gradebook
GO
/****** Object:  StoredProcedure [dbo].[GradebookGetAllEditable]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookGetAllEditable]
AS
SELECT * FROM Gradebook WHERE Editable = 'true'
GO
/****** Object:  StoredProcedure [dbo].[GradebookGetByClassId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookGetByClassId]
@ClassId int
AS
SELECT * FROM Gradebook WHERE PClassId = @ClassId
GO
/****** Object:  StoredProcedure [dbo].[GradebookGetById]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookGetById]
@Id int
AS
SELECT * FROM Gradebook WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GradebookInsert]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookInsert]
@Id int OUTPUT,
@PClassId int,
@SchoolYearStart DateTime,
@SchoolYearEnd DateTime,
@Editable bit,
@CreatedBy int,
@ModifiedBy int = null,
@CreatedDate date,
@ModifiedDate date = null,
@Version timestamp OUTPUT
AS
BEGIN
INSERT INTO Gradebook (PClassId, SchoolYearStart, SchoolYearEnd, Editable, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) 
VALUES(@PClassId, @SchoolYearStart, @SchoolYearEnd, @Editable, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)
	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM Gradebook WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GradebookUpdate]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookUpdate]
@Id int,
@PClassId int,
@SchoolYearStart DateTime,
@SchoolYearEnd DateTime,
@Editable bit,
@ModifiedBy int,
@ModifiedDate date,
@Version timestamp OUTPUT
AS
UPDATE Gradebook SET PClassId = @PClassId, SchoolYearStart = @SchoolYearStart, SchoolYearEnd = @SchoolYearEnd,Editable = @Editable, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate

WHERE Id = @Id AND [Version] = @Version
SELECT @Version = [Version] FROM [dbo].[Gradebook] WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[ListAll]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListAll]
AS
EXEC sp_MSFOREACHTABLE 'SELECT * FROM ?'
GO
/****** Object:  StoredProcedure [dbo].[MarkDelete]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkDelete]
@Id int, @Version timestamp
AS
DELETE FROM Mark WHERE Id = @Id AND [Version] = @Version	
GO
/****** Object:  StoredProcedure [dbo].[MarkGetAll]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkGetAll]
AS
SELECT * FROM Mark
GO
/****** Object:  StoredProcedure [dbo].[MarkGetAllByMarksId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkGetAllByMarksId]
@Id int
AS
SELECT * FROM Mark WHERE MarksId = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarkGetAllTypes]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkGetAllTypes]
AS
SELECT DISTINCT Type FROM Mark
GO
/****** Object:  StoredProcedure [dbo].[MarkGetAverageByPupilId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkGetAverageByPupilId]
@PupilId int
AS
SELECT ISNULL(AVG(CAST(Grade AS DECIMAL(10,2))),0 ) FROM Marks M INNER JOIN Mark ON MarksId=M.Id 
WHERE PupilId = @PupilId AND Final = 'False'
GO
/****** Object:  StoredProcedure [dbo].[MarkGetById]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkGetById]
@Id int
AS
SELECT * FROM Mark WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarkGetTypesByMarksId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkGetTypesByMarksId]
@MarksId int
AS
SELECT DISTINCT Type FROM Mark WHERE MarksId = @MarksId
GO
/****** Object:  StoredProcedure [dbo].[MarkInsert]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkInsert]
@Id int OUTPUT,
@MarksId int,
@Grade int,
@Type nvarchar(30),
@Important bit,
@Final bit,
@CreatedBy int,
@ModifiedBy int = null,
@CreatedDate date,
@ModifiedDate date = null,
@Version timestamp OUTPUT
AS
BEGIN
INSERT INTO Mark (MarksId, Grade, Type, Important, Final, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) 
VALUES(@MarksId, @Grade, @Type, @Important, @Final, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)
	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM Mark WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[MarksDelete]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksDelete]
@Id int, @Version timestamp
AS
DELETE FROM Marks WHERE Id = @Id AND [Version] = @Version	
GO
/****** Object:  StoredProcedure [dbo].[MarksGetAll]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksGetAll]
AS
SELECT * FROM Marks
GO
/****** Object:  StoredProcedure [dbo].[MarksGetAllByPupilId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksGetAllByPupilId]
@Id int
AS
SELECT * FROM Marks WHERE PupilId = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarksGetById]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksGetById]
@Id int
AS
SELECT * FROM Marks WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarksGetByPupilIdAndSubjectId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksGetByPupilIdAndSubjectId]
@PupilId int,
@SubjectId int
AS
SELECT * FROM Marks WHERE PupilId = @PupilId AND SubjectId = @SubjectId
GO
/****** Object:  StoredProcedure [dbo].[MarksInsert]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksInsert]
@Id int OUTPUT,
@PupilId int,
@SubjectId int,
@FinalMark int = null,
@CreatedBy int,
@ModifiedBy int = null,
@CreatedDate date,
@ModifiedDate date = null,
@Version timestamp OUTPUT
AS
BEGIN
INSERT INTO Marks (PupilId, SubjectId, FinalMark, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) 
VALUES(@PupilId, @SubjectId, @FinalMark, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)
	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM Marks WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[MarksUpdate]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksUpdate]
@Id int,
@PupilId int,
@SubjectId int,
@FinalMark int = null,
@ModifiedBy int,
@ModifiedDate date,
@Version timestamp OUTPUT
AS
UPDATE Marks SET PupilId = @PupilId, SubjectId = @SubjectId, FinalMark = @FinalMark, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate

WHERE Id = @Id AND [Version] = @Version
SELECT @Version = [Version] FROM [dbo].[Marks] WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarkUpdate]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkUpdate]
@Id int,
@Grade int,
@Type nvarchar(30),
@Important bit,
@Final bit,
@ModifiedBy int,
@ModifiedDate date,
@Version timestamp OUTPUT
AS
UPDATE Mark SET Grade = @Grade, Type = @Type, Important = @Important, Final = @Final, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PClassDelete]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassDelete]
@Id int, @Version timestamp
AS
DELETE FROM PClass WHERE Id = @Id AND [Version] = @Version	
GO
/****** Object:  StoredProcedure [dbo].[PClassGetAll]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassGetAll]
AS
SELECT * FROM PClass
GO
/****** Object:  StoredProcedure [dbo].[PClassGetAllByUserId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassGetAllByUserId]
@Id int
AS
SELECT * FROM PClass WHERE userId = @Id
GO
/****** Object:  StoredProcedure [dbo].[PClassGetById]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassGetById]
@Id int
AS
SELECT * FROM PClass WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PClassGetByYear]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassGetByYear] 
@Year nvarchar(4)
AS
SELECT * FROM PClass WHERE Year = @Year
GO
/****** Object:  StoredProcedure [dbo].[PClassInsert]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassInsert]
@Id int OUTPUT,
@UserId int,
@FieldOfStudyId int,
@Generation nvarchar(7),
@Year nvarchar(4),
@PClassIndex int,
@CreatedBy int,
@ModifiedBy int = null,
@CreatedDate date,
@ModifiedDate date = null,
@Version timestamp OUTPUT
AS
BEGIN
INSERT INTO PClass (UserId, FieldOfStudyId, Generation, Year, PClassIndex, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) 
VALUES(@UserId, @FieldOfStudyId, @Generation, @Year, @PClassIndex, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)
	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM PClass WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[PClassUpdate]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassUpdate]
@Id int,
@UserId int,
@FieldOfStudyId int,
@Generation nvarchar(4),
@Year nvarchar(4),
@PClassIndex int,
@ModifiedBy int,
@ModifiedDate date,
@Version timestamp OUTPUT
AS
UPDATE PClass SET UserId = @UserId, FieldOfStudyId = @FieldOfStudyId, Generation = @Generation, Year = @Year, PClassIndex = @PClassIndex , ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate

WHERE Id = @Id AND [Version] = @Version
SELECT @Version = [Version] FROM [dbo].[PClass] WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PupilDelete]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilDelete]
@Id int, @Version timestamp
AS
DELETE FROM Pupil WHERE Id = @Id AND [Version] = @Version	
GO
/****** Object:  StoredProcedure [dbo].[PupilGetAll]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilGetAll]
AS
SELECT * FROM Pupil
GO
/****** Object:  StoredProcedure [dbo].[PupilGetByClassId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilGetByClassId]
@PClassId int
AS
SELECT * FROM Pupil WHERE PClassId = @PClassId
GO
/****** Object:  StoredProcedure [dbo].[PupilGetById]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilGetById]
@Id int
AS
SELECT * FROM Pupil WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PupilInsert]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilInsert]
@Id int OUTPUT,
@PClassId int,
@Name nvarchar(50),
@CreatedBy int,
@ModifiedBy int = null,
@CreatedDate date,
@ModifiedDate date = null,
@Version timestamp OUTPUT
AS
BEGIN
INSERT INTO Pupil (PClassId, Name, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) 
VALUES(@PClassId, @Name, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)
	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM Pupil WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[PupilUpdate]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilUpdate]
@Id int,
@PClassId int,
@Name nvarchar(50),
@ModifiedBy int,
@ModifiedDate date,
@Version timestamp OUTPUT
AS
UPDATE Pupil SET PClassId = @PClassId, Name = @Name, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate

WHERE Id = @Id AND [Version] = @Version
SELECT @Version = [Version] FROM [dbo].[Pupil] WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleDelete]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleDelete]
@Id int
AS
DELETE FROM Role WHERE id = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleDeleteAllByUserId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleDeleteAllByUserId]
@UserId int
AS
DELETE FROM UserHasRoles WHERE UserId = @UserId
GO
/****** Object:  StoredProcedure [dbo].[RoleGetAll]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleGetAll]
AS
SELECT * FROM Role
GO
/****** Object:  StoredProcedure [dbo].[RoleGetAllByUserId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleGetAllByUserId]
@Id int
AS
SELECT * FROM Role INNER JOIN UserHasRoles ON Role.id = UserHasRoles.roleId WHERE userId = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleGetById]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleGetById]
@Id int
AS
SELECT * FROM Role WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleGetByUserId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleGetByUserId]
@UserId int
AS
SELECT R.Id, R.Name FROM Role R INNER JOIN UserHasRoles ON R.Id = UserHasRoles.RoleId WHERE UserId = @UserId
GO
/****** Object:  StoredProcedure [dbo].[RoleInsert]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleInsert]
(	
	@Id int OUTPUT,
	@Name nvarchar(50)
)
AS
BEGIN

	INSERT INTO [dbo].[Role] (Name)
		VALUES(@Name)

	SET @Id =  SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[RoleUpdate]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleUpdate]
@Id int,
@Name nvarchar(15)
AS
UPDATE Role SET name = @Name WHERE id = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleUpdate1]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleUpdate1]
(
    @Id int,
    @Name nvarchar(15),
	@ModifiedBy int,
	@ModifiedDate datetime,
	@Version timestamp OUTPUT
)
AS
BEGIN


	UPDATE Role
		SET  
			name = @Name,
			ModifiedBy = @ModifiedBy,
			ModifiedDate = @ModifiedDate
			 
		WHERE id = @Id AND [Version] = @Version

		SELECT @Version = [Version] FROM Role WHERE id = Id
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectDelete]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectDelete]
@Id int, @Version timestamp
AS
DELETE FROM Subject WHERE Id = @Id AND [Version] = @Version	
GO
/****** Object:  StoredProcedure [dbo].[SubjectGetAll]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectGetAll]
AS
SELECT * FROM Subject
GO
/****** Object:  StoredProcedure [dbo].[SubjectGetAllByUserId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectGetAllByUserId]
@Id int
AS
SELECT * FROM Subject WHERE userId = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectGetByFieldId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectGetByFieldId]
@FieldId int
AS
SELECT Sub.Id, Sub.UserId, Sub.Name, Sub.CreatedBy, Sub.ModifiedBy, Sub.CreatedDate, Sub.ModifiedDate, Sub.Version FROM Subject Sub 
INNER JOIN FieldOfStudyHasSubjects HasSub 
ON Sub.Id = HasSub.SubjectId 
WHERE FieldOfStudyId = @FieldId
GO
/****** Object:  StoredProcedure [dbo].[SubjectGetById]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectGetById]
@Id int
AS
SELECT * FROM Subject WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectInsert]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectInsert]
@Id int OUTPUT,
@UserId int,
@Name nvarchar(50),
@CreatedBy int,
@ModifiedBy int = null,
@CreatedDate date,
@ModifiedDate date = null,
@Version timestamp OUTPUT
AS
BEGIN
INSERT INTO Subject (UserId, Name, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) 
VALUES(@UserId, @Name, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)
	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM Subject WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonAbsenteesGetAllById]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonAbsenteesGetAllById]
@Id int
AS
SELECT * FROM SubjectLessonsHaveAbsentees WHERE subjectLessonId = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonDelete]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonDelete]
@Id int, @Version timestamp
AS
DELETE FROM SubjectLesson WHERE Id = @Id AND [Version] = @Version	
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonDeleteAbsentee]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonDeleteAbsentee]
@Id int
AS
DELETE FROM SubjectLessonsHaveAbsentees WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonGetAll]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonGetAll]
AS
SELECT * FROM SubjectLesson
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonGetAllByGradebookId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonGetAllByGradebookId]
@Id int
AS
SELECT * FROM SubjectLesson WHERE gradebookId = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonGetById]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonGetById]
@Id int
AS
SELECT * FROM SubjectLesson WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonInsert]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonInsert]
@Id int OUTPUT,
@GradebookId int,
@SubjectId int,
@LessonTheme nvarchar(254),
@Date datetime,
@TimeOfLesson nvarchar(3),
@CreatedBy int,
@ModifiedBy int = null,
@CreatedDate date,
@ModifiedDate date = null,
@Version timestamp OUTPUT
AS
BEGIN
INSERT INTO SubjectLesson (GradebookId, SubjectId,LessonTheme ,Date,TimeOfLesson, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) 
VALUES(@GradebookId, @SubjectId,@LessonTheme,@Date,@TimeOfLesson, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)
	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM Subject WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonInsertAbsentee]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonInsertAbsentee]
@subjectLessonId int,
@pupilId int
AS
INSERT INTO SubjectLessonsHaveAbsentees (subjectLessonId, pupilId) VALUES(@subjectLessonId, @pupilId)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonUpdate]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonUpdate]
@Id int,
@GradebookId int,
@SubjectId int,
@LessonTheme nvarchar(254),
@Date datetime,
@TimeOfLesson nvarchar(3),
@ModifiedBy int,
@ModifiedDate date ,
@Version timestamp OUTPUT
AS
UPDATE SubjectLesson SET GradebookId = @GradebookId, SubjectId = @SubjectId, LessonTheme = @LessonTheme,Date = @Date,TimeOfLesson = @TimeOfLesson , ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate

WHERE Id = @Id AND [Version] = @Version
SELECT @Version = [Version] FROM [dbo].[SubjectLesson] WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectUpdate]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectUpdate]
@Id int,
@UserId int,
@Name nvarchar(50),
@ModifiedBy int,
@ModifiedDate date,
@Version timestamp OUTPUT
AS
UPDATE Subject SET UserId = @UserId, Name = @Name, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate

WHERE Id = @Id AND [Version] = @Version
SELECT @Version = [Version] FROM [dbo].[Subject] WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[TruncateAll]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TruncateAll]
AS
EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
EXEC sp_MSForEachTable 'ALTER TABLE ? DISABLE TRIGGER ALL'
EXEC sp_MSForEachTable 'DELETE FROM ?'
EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'
EXEC sp_MSForEachTable 'ALTER TABLE ? ENABLE TRIGGER ALL'
EXEC sp_MSFOREACHTABLE 'SELECT * FROM ?'
GO
/****** Object:  StoredProcedure [dbo].[UserDelete]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserDelete] (@Id int, @Version timestamp)
AS
BEGIN
	DELETE FROM [dbo].[User] WHERE Id = @Id	  AND [Version] = @Version	
END

GO
/****** Object:  StoredProcedure [dbo].[UserGetAll]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserGetAll]
AS
SELECT * FROM [User]
GO
/****** Object:  StoredProcedure [dbo].[UserGetAllProfessors]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserGetAllProfessors]
AS
SELECT 
U.Id, U.Name, U.Surname, U.Username, U.Email, U.Password, U.Version
FROM (Role R INNER JOIN
UserHasRoles UHR ON R.Id = UHR.RoleId)
INNER JOIN [User] U ON U.Id = UHR.UserId 
WHERE R.Name = 'Professor'
GO
/****** Object:  StoredProcedure [dbo].[UserGetByCredentials]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserGetByCredentials]
@Username nvarchar(30),
@Password nvarchar(50)
AS
SELECT * FROM [User] WHERE Username = @Username AND Password = @Password
GO
/****** Object:  StoredProcedure [dbo].[UserGetById]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserGetById]
@Id int
AS
SELECT * FROM [User] WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[UserGetByUsername]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserGetByUsername]
@Username nvarchar(30)
AS
SELECT * FROM [User] WHERE Username = @Username
GO
/****** Object:  StoredProcedure [dbo].[UserInsert]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserInsert]
(	
@Id int OUTPUT,
@Name nvarchar(25),
@Surname nvarchar(25),
@Username nvarchar(30),
@Password nvarchar(50),
@Email nvarchar(254),
@Version timestamp OUTPUT
)
AS
BEGIN

	INSERT INTO [dbo].[User] (Name,Surname,Username,Password,Email)
		VALUES(@Name,@Surname,@Username,@Password,@Email)

	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM [dbo].[User] WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UserRoleDelete]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserRoleDelete] (@Id int, @Version timestamp)
AS
BEGIN
	DELETE FROM UserHasRoles WHERE Id = @Id	  AND [Version] = @Version	
END

GO
/****** Object:  StoredProcedure [dbo].[UserRoleGetById]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserRoleGetById]
@Id int
AS
BEGIN
SELECT * FROM UserHasRoles WHERE @Id = Id
END

GO
/****** Object:  StoredProcedure [dbo].[UserRoleInsert]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserRoleInsert]
(	
	@Id int OUTPUT,
	@UserId int,
	@RoleId int,
	@CreatedBy int,
	@ModifiedBy int = null,
	@CreatedDate date,
	@ModifiedDate date = null,
	@Version timestamp OUTPUT
)
AS
BEGIN

	INSERT INTO UserHasRoles(UserId, RoleId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
		VALUES(@UserId, @RoleId, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)

	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM UserHasRoles WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[UserRolesGetByUserId]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserRolesGetByUserId]
@Id int
AS
SELECT * FROM UserHasRoles WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[UserRolesGetByUsername]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserRolesGetByUsername]
@Username nvarchar(30)
AS
SELECT R.name FROM (
[UserHasRoles] INNER JOIN [User] ON [UserHasRoles].UserId = [User].Id) 
INNER JOIN [Role] R 
ON [UserHasRoles].RoleId = R.id 
WHERE [User].Username = @Username
GO
/****** Object:  StoredProcedure [dbo].[UserUpdate]    Script Date: 12/19/2017 2:08:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserUpdate]
(
    @Id int,
	@Name nvarchar(25),
	@Surname nvarchar(25),
	@Username nvarchar(30),
	@Password nvarchar(50),
	@Email nvarchar(254),
	@Version timestamp OUTPUT
)
AS
BEGIN
	UPDATE [dbo].[User]
		SET Name = @Name, Surname = @Surname, Username = @Username, Password = @Password, Email = @Email 
		WHERE Id = @Id AND [Version] = @Version
		SELECT @Version = [Version] FROM [dbo].[User] WHERE Id = @Id
END
GO
USE [master]
GO
ALTER DATABASE [Max.Gradebook] SET  READ_WRITE 
GO
