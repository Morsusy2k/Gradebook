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
/****** Object:  Database [Max.Gradebook]    Script Date: 11/19/2017 3:06:48 PM ******/
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
/****** Object:  Table [dbo].[FieldOfStudy]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldOfStudy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FieldOfStudyHasSubjects]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldOfStudyHasSubjects](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fieldOfStudyId] [int] NOT NULL,
	[subjectId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gradebook]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gradebook](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pClassId] [int] NOT NULL,
	[schoolYearStart] [datetime] NOT NULL,
	[schoolYearEnd] [datetime] NOT NULL,
	[editable] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mark]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mark](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[marksId] [int] NOT NULL,
	[mark] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marks]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pupilId] [int] NOT NULL,
	[subjectId] [int] NOT NULL,
	[finalMark] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PClass]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PClass](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[fieldOfStudyId] [int] NOT NULL,
	[generation] [datetime] NOT NULL,
	[Year] [nvarchar](4) NOT NULL,
	[PClassIndex] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pupil]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pupil](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pClassId] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectLesson]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectLesson](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[gradebookId] [int] NOT NULL,
	[subjectId] [int] NOT NULL,
	[lessonTheme] [nvarchar](254) NULL,
	[date] [datetime] NOT NULL,
	[timeOfLesson] [nvarchar](3) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[Version] [timestamp] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectLessonsHaveAbsentees]    Script Date: 11/19/2017 3:06:48 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 11/19/2017 3:06:48 PM ******/
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
/****** Object:  Table [dbo].[UserHasRoles]    Script Date: 11/19/2017 3:06:48 PM ******/
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
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [name]) VALUES (1, N'Moderator')
INSERT [dbo].[Role] ([id], [name]) VALUES (5, N'Student')
INSERT [dbo].[Role] ([id], [name]) VALUES (6, N'Teacher')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Surname], [Username], [Password], [Email]) VALUES (95, N'Dragan', N'Ilic', N'Morsus', N'password', N'morsy2k@gmail.com')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Username], [Password], [Email]) VALUES (96, N'Dragance-Updated', N'Ilic', N'Morsus', N'password1', N'dilic993@gmail.com')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Username], [Password], [Email]) VALUES (97, N'Kmilka-Updated', N'Kostic', N'KMilka', N'password2', N'kosticeva@gmail.com')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserHasRoles] ON 

INSERT [dbo].[UserHasRoles] ([Id], [UserId], [RoleId], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (5, 95, 1, 95, NULL, CAST(N'2017-11-18' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[UserHasRoles] OFF
/****** Object:  Index [PK_FIELDOFSTUDY]    Script Date: 11/19/2017 3:06:48 PM ******/
ALTER TABLE [dbo].[FieldOfStudy] ADD  CONSTRAINT [PK_FIELDOFSTUDY] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_FIELDOFSTUDYHASSUBJECTS]    Script Date: 11/19/2017 3:06:48 PM ******/
ALTER TABLE [dbo].[FieldOfStudyHasSubjects] ADD  CONSTRAINT [PK_FIELDOFSTUDYHASSUBJECTS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_GRADEBOOK]    Script Date: 11/19/2017 3:06:48 PM ******/
ALTER TABLE [dbo].[Gradebook] ADD  CONSTRAINT [PK_GRADEBOOK] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_MARK]    Script Date: 11/19/2017 3:06:48 PM ******/
ALTER TABLE [dbo].[Mark] ADD  CONSTRAINT [PK_MARK] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_MARKS]    Script Date: 11/19/2017 3:06:48 PM ******/
ALTER TABLE [dbo].[Marks] ADD  CONSTRAINT [PK_MARKS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_PCLASS]    Script Date: 11/19/2017 3:06:48 PM ******/
ALTER TABLE [dbo].[PClass] ADD  CONSTRAINT [PK_PCLASS] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_PUPIL]    Script Date: 11/19/2017 3:06:48 PM ******/
ALTER TABLE [dbo].[Pupil] ADD  CONSTRAINT [PK_PUPIL] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_ROLE]    Script Date: 11/19/2017 3:06:48 PM ******/
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [PK_ROLE] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_SUBJECT]    Script Date: 11/19/2017 3:06:48 PM ******/
ALTER TABLE [dbo].[Subject] ADD  CONSTRAINT [PK_SUBJECT] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_SUBJECTLESSON]    Script Date: 11/19/2017 3:06:48 PM ******/
ALTER TABLE [dbo].[SubjectLesson] ADD  CONSTRAINT [PK_SUBJECTLESSON] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_USER]    Script Date: 11/19/2017 3:06:48 PM ******/
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
ALTER TABLE [dbo].[FieldOfStudy]  WITH CHECK ADD  CONSTRAINT [FK_FieldOfStudy_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FieldOfStudy] CHECK CONSTRAINT [FK_FieldOfStudy_User1]
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects]  WITH NOCHECK ADD  CONSTRAINT [FK_FieldOfStudyHasSubjects_FieldOfStudy] FOREIGN KEY([fieldOfStudyId])
REFERENCES [dbo].[FieldOfStudy] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects] CHECK CONSTRAINT [FK_FieldOfStudyHasSubjects_FieldOfStudy]
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects]  WITH NOCHECK ADD  CONSTRAINT [FK_FieldOfStudyHasSubjects_Subject] FOREIGN KEY([subjectId])
REFERENCES [dbo].[Subject] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects] CHECK CONSTRAINT [FK_FieldOfStudyHasSubjects_Subject]
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects]  WITH CHECK ADD  CONSTRAINT [FK_FieldOfStudyHasSubjects_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects] CHECK CONSTRAINT [FK_FieldOfStudyHasSubjects_User]
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects]  WITH CHECK ADD  CONSTRAINT [FK_FieldOfStudyHasSubjects_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FieldOfStudyHasSubjects] CHECK CONSTRAINT [FK_FieldOfStudyHasSubjects_User1]
GO
ALTER TABLE [dbo].[Gradebook]  WITH NOCHECK ADD  CONSTRAINT [FK_Gradebook_PClass] FOREIGN KEY([pClassId])
REFERENCES [dbo].[PClass] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Gradebook] CHECK CONSTRAINT [FK_Gradebook_PClass]
GO
ALTER TABLE [dbo].[Gradebook]  WITH CHECK ADD  CONSTRAINT [FK_Gradebook_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Gradebook] CHECK CONSTRAINT [FK_Gradebook_User]
GO
ALTER TABLE [dbo].[Gradebook]  WITH CHECK ADD  CONSTRAINT [FK_Gradebook_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Gradebook] CHECK CONSTRAINT [FK_Gradebook_User1]
GO
ALTER TABLE [dbo].[Mark]  WITH NOCHECK ADD  CONSTRAINT [FK_Mark_Marks] FOREIGN KEY([marksId])
REFERENCES [dbo].[Marks] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mark] CHECK CONSTRAINT [FK_Mark_Marks]
GO
ALTER TABLE [dbo].[Mark]  WITH CHECK ADD  CONSTRAINT [FK_Mark_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Mark] CHECK CONSTRAINT [FK_Mark_User]
GO
ALTER TABLE [dbo].[Mark]  WITH CHECK ADD  CONSTRAINT [FK_Mark_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Mark] CHECK CONSTRAINT [FK_Mark_User1]
GO
ALTER TABLE [dbo].[Marks]  WITH NOCHECK ADD  CONSTRAINT [FK_Marks_Pupil] FOREIGN KEY([pupilId])
REFERENCES [dbo].[Pupil] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Pupil]
GO
ALTER TABLE [dbo].[Marks]  WITH NOCHECK ADD  CONSTRAINT [FK_Marks_Subject] FOREIGN KEY([subjectId])
REFERENCES [dbo].[Subject] ([id])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Subject]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_Marks_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_User]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_Marks_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_User1]
GO
ALTER TABLE [dbo].[PClass]  WITH NOCHECK ADD  CONSTRAINT [FK_PClass_FieldOfStudy] FOREIGN KEY([fieldOfStudyId])
REFERENCES [dbo].[FieldOfStudy] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PClass] CHECK CONSTRAINT [FK_PClass_FieldOfStudy]
GO
ALTER TABLE [dbo].[PClass]  WITH NOCHECK ADD  CONSTRAINT [FK_PClass_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PClass] CHECK CONSTRAINT [FK_PClass_User]
GO
ALTER TABLE [dbo].[PClass]  WITH CHECK ADD  CONSTRAINT [FK_PClass_User1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PClass] CHECK CONSTRAINT [FK_PClass_User1]
GO
ALTER TABLE [dbo].[PClass]  WITH CHECK ADD  CONSTRAINT [FK_PClass_User2] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PClass] CHECK CONSTRAINT [FK_PClass_User2]
GO
ALTER TABLE [dbo].[Pupil]  WITH NOCHECK ADD  CONSTRAINT [FK_Pupil_PClass] FOREIGN KEY([pClassId])
REFERENCES [dbo].[PClass] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pupil] CHECK CONSTRAINT [FK_Pupil_PClass]
GO
ALTER TABLE [dbo].[Subject]  WITH NOCHECK ADD  CONSTRAINT [FK_Subject_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_User]
GO
ALTER TABLE [dbo].[SubjectLesson]  WITH NOCHECK ADD  CONSTRAINT [FK_SubjectLesson_Gradebook] FOREIGN KEY([gradebookId])
REFERENCES [dbo].[Gradebook] ([id])
GO
ALTER TABLE [dbo].[SubjectLesson] CHECK CONSTRAINT [FK_SubjectLesson_Gradebook]
GO
ALTER TABLE [dbo].[SubjectLesson]  WITH NOCHECK ADD  CONSTRAINT [FK_SubjectLesson_Subject] FOREIGN KEY([subjectId])
REFERENCES [dbo].[Subject] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectLesson] CHECK CONSTRAINT [FK_SubjectLesson_Subject]
GO
ALTER TABLE [dbo].[SubjectLesson]  WITH CHECK ADD  CONSTRAINT [FK_SubjectLesson_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SubjectLesson] CHECK CONSTRAINT [FK_SubjectLesson_User]
GO
ALTER TABLE [dbo].[SubjectLesson]  WITH CHECK ADD  CONSTRAINT [FK_SubjectLesson_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SubjectLesson] CHECK CONSTRAINT [FK_SubjectLesson_User1]
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees]  WITH NOCHECK ADD  CONSTRAINT [FK_SubjectLessonsHaveAbsentees_Pupil] FOREIGN KEY([pupilId])
REFERENCES [dbo].[Pupil] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees] CHECK CONSTRAINT [FK_SubjectLessonsHaveAbsentees_Pupil]
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees]  WITH NOCHECK ADD  CONSTRAINT [FK_SubjectLessonsHaveAbsentees_SubjectLesson] FOREIGN KEY([subjectLessonId])
REFERENCES [dbo].[SubjectLesson] ([id])
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees] CHECK CONSTRAINT [FK_SubjectLessonsHaveAbsentees_SubjectLesson]
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees]  WITH CHECK ADD  CONSTRAINT [FK_SubjectLessonsHaveAbsentees_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees] CHECK CONSTRAINT [FK_SubjectLessonsHaveAbsentees_User]
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees]  WITH CHECK ADD  CONSTRAINT [FK_SubjectLessonsHaveAbsentees_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SubjectLessonsHaveAbsentees] CHECK CONSTRAINT [FK_SubjectLessonsHaveAbsentees_User1]
GO
ALTER TABLE [dbo].[UserHasRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserHasRoles_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([id])
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
/****** Object:  StoredProcedure [dbo].[FieldOfStudyDelete]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyDelete]
@Id int
AS
DELETE FROM FieldOfStudy WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyDeleteSubject]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyDeleteSubject]
@Id int
AS
DELETE FROM FieldOfStudyHasSubjects WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyGetAll]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyGetAll]
AS
SELECT * FROM FieldOfStudy
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyGetById]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyGetById]
@Id int
AS
SELECT * FROM FieldOfStudy WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyGetSubjectsById]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyGetSubjectsById]
@Id int
AS
SELECT * FROM FieldOfStudyHasSubjects WHERE fieldOfStudyId = @Id
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyInsert]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyInsert]
@Name nvarchar(50)
AS
INSERT INTO FieldOfStudy (name) VALUES(@Name)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyInsertSubject]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyInsertSubject]
@fieldOfStudy int,
@subjectId int
AS
INSERT INTO FieldOfStudyHasSubjects (fieldOfStudyId, subjectId) VALUES(@fieldOfStudy, @subjectId)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[FieldOfStudyUpdate]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldOfStudyUpdate]
@Id int,
@Name nvarchar(50)
AS
UPDATE FieldOfStudy SET name = @Name WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GradebookDelete]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookDelete]
@Id int
AS
DELETE FROM Gradebook WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GradebookGetAll]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookGetAll]
AS
SELECT * FROM Gradebook
GO
/****** Object:  StoredProcedure [dbo].[GradebookGetAllEditable]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookGetAllEditable]
AS
SELECT * FROM Gradebook WHERE Editable = 'true'
GO
/****** Object:  StoredProcedure [dbo].[GradebookGetById]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookGetById]
@Id int
AS
SELECT * FROM Gradebook WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GradebookInsert]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookInsert]
@PClassId int,
@SchoolYearStart datetime,
@SchoolYearEnd datetime,
@Editable bit
AS
INSERT INTO Gradebook (pClassId, schoolYearStart, schoolYearEnd, editable) VALUES(@PClassId, @SchoolYearStart, @SchoolYearEnd, @Editable)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[GradebookUpdate]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GradebookUpdate]
@Id int,
@PClassId int,
@SchoolYearStart datetime,
@SchoolYearEnd datetime,
@Editable bit
AS
UPDATE Gradebook SET pClassId = @PClassId, schoolYearStart = @SchoolYearStart, schoolYearEnd = @SchoolYearEnd, editable = @Editable WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[ListAll]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListAll]
AS
EXEC sp_MSFOREACHTABLE 'SELECT * FROM ?'
GO
/****** Object:  StoredProcedure [dbo].[MarkDelete]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkDelete]
@Id int
AS
DELETE FROM Mark WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarkGetAll]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkGetAll]
AS
SELECT * FROM Mark
GO
/****** Object:  StoredProcedure [dbo].[MarkGetAllByMarksId]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkGetAllByMarksId]
@Id int
AS
SELECT * FROM Mark WHERE marksId = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarkGetById]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkGetById]
@Id int
AS
SELECT * FROM Mark WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarkInsert]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkInsert]
@MarksId int,
@Mark int
AS
INSERT INTO Mark (marksId, mark) VALUES(@MarksId, @Mark)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[MarksDelete]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksDelete]
@Id int
AS
DELETE FROM Marks WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarksGetAll]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksGetAll]
AS
SELECT * FROM Marks
GO
/****** Object:  StoredProcedure [dbo].[MarksGetAllByPupilId]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksGetAllByPupilId]
@Id int
AS
SELECT * FROM Marks WHERE pupilId = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarksGetById]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksGetById]
@Id int
AS
SELECT * FROM Marks WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarksInsert]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksInsert]
@PupilId int,
@SubjectId int,
@FinalMark int
AS
INSERT INTO Marks (pupilId, subjectId, finalMark) VALUES(@PupilId,@SubjectId,@FinalMark)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[MarksUpdate]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarksUpdate]
@Id int,
@PupilId int,
@SubjectId int,
@FinalMark int
AS
UPDATE Marks SET pupilId = @PupilId, subjectId = @SubjectId, finalMark = @FinalMark WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[MarkUpdate]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkUpdate]
@Id int,
@MarksId int,
@Mark int
AS
UPDATE Mark SET marksId = @MarksId, mark = @Mark WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PClassDelete]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassDelete]
@Id int
AS
DELETE FROM PClass WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PClassGetAll]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassGetAll]
AS
SELECT * FROM PClass
GO
/****** Object:  StoredProcedure [dbo].[PClassGetAllByUserId]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassGetAllByUserId]
@Id int
AS
SELECT * FROM PClass WHERE userId = @Id
GO
/****** Object:  StoredProcedure [dbo].[PClassGetById]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassGetById]
@Id int
AS
SELECT * FROM PClass WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PClassGetByYear]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassGetByYear] 
@Year nvarchar(4)
AS
SELECT * FROM PClass WHERE Year = @Year
GO
/****** Object:  StoredProcedure [dbo].[PClassInsert]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassInsert]
@userId int,
@fieldOfStudyId int,
@generation datetime,
@Year nvarchar(4),
@PClassIndex int
AS
INSERT INTO PClass (userId, fieldOfStudyId, generation, Year, PClassIndex) VALUES(@userId, @fieldOfStudyId, @generation, @Year, @PClassIndex)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[PClassUpdate]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PClassUpdate]
@Id int,
@userId int,
@fieldOfStudyId int,
@generation datetime,
@Year nvarchar(4),
@PClassIndex int
AS
UPDATE PClass SET userId = @userId, fieldOfStudyId = @fieldOfStudyId, generation = @generation, Year = @Year, PClassIndex = @PClassIndex WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PupilDelete]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilDelete]
@Id int
AS
DELETE FROM Pupil WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PupilGetAll]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilGetAll]
AS
SELECT * FROM Pupil
GO
/****** Object:  StoredProcedure [dbo].[PupilGetById]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilGetById]
@Id int
AS
SELECT * FROM Pupil WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[PupilInsert]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilInsert]
@PClassId int,
@Name nvarchar(50)
AS
INSERT INTO Pupil (pClassId, name) VALUES(@PClassId, @Name)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[PupilUpdate]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PupilUpdate]
@Id int,
@PClassId int,
@Name nvarchar(50)
AS
UPDATE Pupil SET pClassId = @PClassId, name = @Name WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleDelete]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleDelete]
@Id int
AS
DELETE FROM Role WHERE id = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleGetAll]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleGetAll]
AS
SELECT * FROM Role
GO
/****** Object:  StoredProcedure [dbo].[RoleGetAllByUserId]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleGetAllByUserId]
@Id int
AS
SELECT * FROM Role INNER JOIN UserHasRoles ON Role.id = UserHasRoles.roleId WHERE userId = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleGetById]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleGetById]
@Id int
AS
SELECT * FROM Role WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleInsert]    Script Date: 11/19/2017 3:06:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[RoleUpdate]    Script Date: 11/19/2017 3:06:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[RoleUpdate1]    Script Date: 11/19/2017 3:06:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SubjectDelete]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectDelete]
@Id int
AS
DELETE FROM Subject WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectGetAll]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectGetAll]
AS
SELECT * FROM Subject
GO
/****** Object:  StoredProcedure [dbo].[SubjectGetAllByUserId]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectGetAllByUserId]
@Id int
AS
SELECT * FROM Subject WHERE userId = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectGetById]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectGetById]
@Id int
AS
SELECT * FROM Subject WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectInsert]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectInsert]
@userId int,
@name nvarchar(50)
AS
INSERT INTO Subject (userId,name) VALUES(@userId,@name)
SELECT CAST(SCOPE_IDENTITY() AS int)
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonAbsenteesGetAllById]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonAbsenteesGetAllById]
@Id int
AS
SELECT * FROM SubjectLessonsHaveAbsentees WHERE subjectLessonId = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonDelete]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonDelete]
@Id int
AS
DELETE FROM SubjectLesson WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonDeleteAbsentee]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonDeleteAbsentee]
@Id int
AS
DELETE FROM SubjectLessonsHaveAbsentees WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonGetAll]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonGetAll]
AS
SELECT * FROM SubjectLesson
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonGetAllByGradebookId]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonGetAllByGradebookId]
@Id int
AS
SELECT * FROM SubjectLesson WHERE gradebookId = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonGetById]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonGetById]
@Id int
AS
SELECT * FROM SubjectLesson WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonInsert]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectLessonInsert]
@GradebookId int,
@SubjectId int,
@LessonTheme nvarchar(254),
@Date datetime,
@TimeOfLesson nvarchar(3)
AS
INSERT INTO SubjectLesson (gradebookId,subjectId,lessonTheme,date,timeOfLesson) VALUES(@GradebookId,@SubjectId,@LessonTheme,@Date,@TimeOfLesson)
SELECT CAST(SCOPE_IDENTITY() as INT)
GO
/****** Object:  StoredProcedure [dbo].[SubjectLessonInsertAbsentee]    Script Date: 11/19/2017 3:06:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SubjectLessonUpdate]    Script Date: 11/19/2017 3:06:48 PM ******/
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
@TimeOfLesson nvarchar(3)
AS
UPDATE SubjectLesson SET gradebookId = @GradebookId, subjectId = @SubjectId, lessonTheme = @LessonTheme, date = @Date, timeOfLesson = @TimeOfLesson WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SubjectUpdate]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SubjectUpdate]
@Id int,
@userId int,
@name nvarchar(50)
AS
UPDATE Subject SET userId = @userId, name = @name WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[TruncateAll]    Script Date: 11/19/2017 3:06:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserDelete]    Script Date: 11/19/2017 3:06:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserGetAll]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserGetAll]
AS
SELECT * FROM [User]
GO
/****** Object:  StoredProcedure [dbo].[UserGetById]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserGetById]
@Id int
AS
SELECT * FROM [User] WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[UserInsert]    Script Date: 11/19/2017 3:06:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserRoleDelete]    Script Date: 11/19/2017 3:06:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserRoleGetById]    Script Date: 11/19/2017 3:06:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UserRoleInsert]    Script Date: 11/19/2017 3:06:48 PM ******/
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

	INSERT INTO UserHasRoles(Id, UserId, RoleId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
		VALUES(@Id, @UserId, @RoleId, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)

	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM UserHasRoles WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[UserRolesGetByUserId]    Script Date: 11/19/2017 3:06:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserRolesGetByUserId]
@Id int
AS
SELECT * FROM UserHasRoles WHERE userId = @Id
GO
/****** Object:  StoredProcedure [dbo].[UserUpdate]    Script Date: 11/19/2017 3:06:48 PM ******/
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
