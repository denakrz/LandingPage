USE [master]
GO
/****** Object:  Database [LU-G3]    Script Date: 12/05/2018 14:55:40 ******/
CREATE DATABASE [LU-G3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LU-G3', FILENAME = N'C:\Users\Lagash\LU-G3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LU-G3_log', FILENAME = N'C:\Users\Lagash\LU-G3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LU-G3] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LU-G3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LU-G3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LU-G3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LU-G3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LU-G3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LU-G3] SET ARITHABORT OFF 
GO
ALTER DATABASE [LU-G3] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LU-G3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LU-G3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LU-G3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LU-G3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LU-G3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LU-G3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LU-G3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LU-G3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LU-G3] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LU-G3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LU-G3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LU-G3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LU-G3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LU-G3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LU-G3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LU-G3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LU-G3] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LU-G3] SET  MULTI_USER 
GO
ALTER DATABASE [LU-G3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LU-G3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LU-G3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LU-G3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LU-G3] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LU-G3] SET QUERY_STORE = OFF
GO
USE [LU-G3]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 12/05/2018 14:55:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Home] [varchar](50) NOT NULL,
	[Number] [varchar](10) NOT NULL,
	[Postalcode] [varchar](10) NULL,
	[IdLocation] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attached]    Script Date: 12/05/2018 14:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attached](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Link] [varbinary](max) NOT NULL,
	[IdTypeAttached] [int] NOT NULL,
 CONSTRAINT [PK_Attached] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instance]    Script Date: 12/05/2018 14:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Instance] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProgressInstance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 12/05/2018 14:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Location] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 12/05/2018 14:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[LoginType] [int] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[SecurityStamp] [varchar](max) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Login] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meeting]    Script Date: 12/05/2018 14:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdInstance] [int] NOT NULL,
	[IdPostulant] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Instance_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Instance] UNIQUE NONCLUSTERED 
(
	[IdInstance] ASC,
	[IdPostulant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Postulant]    Script Date: 12/05/2018 14:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Postulant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Lastname] [varchar](50) NOT NULL,
	[Dni] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Birthday] [date] NOT NULL,
	[IdAddress] [int] NULL,
	[PhoneHome] [varchar](20) NULL,
	[PhoneMobile] [varchar](20) NOT NULL,
	[GitHub] [varchar](50) NULL,
	[LinkedIn] [varchar](50) NULL,
	[IdState] [int] NOT NULL,
	[Iteration] [int] NOT NULL,
	[Country] [int] NOT NULL,
 CONSTRAINT [PK_Postulant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Postulant] UNIQUE NONCLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostulantAttached]    Script Date: 12/05/2018 14:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostulantAttached](
	[IdPostulant] [int] NOT NULL,
	[IdAttached] [int] NOT NULL,
 CONSTRAINT [PK_PostulantAttached] PRIMARY KEY CLUSTERED 
(
	[IdPostulant] ASC,
	[IdAttached] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostulantLogin]    Script Date: 12/05/2018 14:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostulantLogin](
	[IdPostulant] [int] NOT NULL,
	[IdLogin] [int] NOT NULL,
 CONSTRAINT [PK_PostulantLogin] PRIMARY KEY CLUSTERED 
(
	[IdPostulant] ASC,
	[IdLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Result]    Script Date: 12/05/2018 14:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Form] [varbinary](max) NOT NULL,
	[IdMeeting] [int] NOT NULL,
	[Observation] [varchar](max) NULL,
	[OK] [bit] NOT NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 12/05/2018 14:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[State] [varchar](50) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Studies]    Script Date: 12/05/2018 14:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Studies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdStudy] [int] NOT NULL,
	[Institution] [varchar](50) NOT NULL,
	[Career] [varchar](50) NOT NULL,
	[IdPostulant] [int] NOT NULL,
	[Year] [int] NULL,
	[IdStudiesState] [int] NOT NULL,
 CONSTRAINT [PK_Studies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Location] FOREIGN KEY([IdLocation])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Location]
GO
ALTER TABLE [dbo].[Meeting]  WITH CHECK ADD  CONSTRAINT [FK_Instance_ProgressInstance1] FOREIGN KEY([IdInstance])
REFERENCES [dbo].[Instance] ([Id])
GO
ALTER TABLE [dbo].[Meeting] CHECK CONSTRAINT [FK_Instance_ProgressInstance1]
GO
ALTER TABLE [dbo].[Meeting]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_Postulant] FOREIGN KEY([IdPostulant])
REFERENCES [dbo].[Postulant] ([Id])
GO
ALTER TABLE [dbo].[Meeting] CHECK CONSTRAINT [FK_Meeting_Postulant]
GO
ALTER TABLE [dbo].[Postulant]  WITH CHECK ADD  CONSTRAINT [FK_Postulant_Address] FOREIGN KEY([IdAddress])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Postulant] CHECK CONSTRAINT [FK_Postulant_Address]
GO
ALTER TABLE [dbo].[Postulant]  WITH CHECK ADD  CONSTRAINT [FK_Postulant_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[Postulant] CHECK CONSTRAINT [FK_Postulant_State]
GO
ALTER TABLE [dbo].[PostulantAttached]  WITH CHECK ADD  CONSTRAINT [FK_PostulantAttached_Attached] FOREIGN KEY([IdAttached])
REFERENCES [dbo].[Attached] ([Id])
GO
ALTER TABLE [dbo].[PostulantAttached] CHECK CONSTRAINT [FK_PostulantAttached_Attached]
GO
ALTER TABLE [dbo].[PostulantAttached]  WITH CHECK ADD  CONSTRAINT [FK_PostulantAttached_Postulant] FOREIGN KEY([IdPostulant])
REFERENCES [dbo].[Postulant] ([Id])
GO
ALTER TABLE [dbo].[PostulantAttached] CHECK CONSTRAINT [FK_PostulantAttached_Postulant]
GO
ALTER TABLE [dbo].[PostulantLogin]  WITH CHECK ADD  CONSTRAINT [FK_PostulantLogin_Login] FOREIGN KEY([IdLogin])
REFERENCES [dbo].[Login] ([Id])
GO
ALTER TABLE [dbo].[PostulantLogin] CHECK CONSTRAINT [FK_PostulantLogin_Login]
GO
ALTER TABLE [dbo].[PostulantLogin]  WITH CHECK ADD  CONSTRAINT [FK_PostulantLogin_Postulant] FOREIGN KEY([IdPostulant])
REFERENCES [dbo].[Postulant] ([Id])
GO
ALTER TABLE [dbo].[PostulantLogin] CHECK CONSTRAINT [FK_PostulantLogin_Postulant]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Instance] FOREIGN KEY([IdMeeting])
REFERENCES [dbo].[Meeting] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Instance]
GO
ALTER TABLE [dbo].[Studies]  WITH CHECK ADD  CONSTRAINT [FK_Studies_Postulant] FOREIGN KEY([IdPostulant])
REFERENCES [dbo].[Postulant] ([Id])
GO
ALTER TABLE [dbo].[Studies] CHECK CONSTRAINT [FK_Studies_Postulant]
GO
USE [master]
GO
ALTER DATABASE [LU-G3] SET  READ_WRITE 
GO
