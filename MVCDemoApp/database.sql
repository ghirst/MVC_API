USE [master]
GO
/****** Object:  Database [myAPITestDB]    Script Date: 27/05/2020 18:26:18 ******/
CREATE DATABASE [myAPITestDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'myAPITestDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\myAPITestDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'myAPITestDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\myAPITestDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [myAPITestDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [myAPITestDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [myAPITestDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [myAPITestDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [myAPITestDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [myAPITestDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [myAPITestDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [myAPITestDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [myAPITestDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [myAPITestDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [myAPITestDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [myAPITestDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [myAPITestDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [myAPITestDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [myAPITestDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [myAPITestDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [myAPITestDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [myAPITestDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [myAPITestDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [myAPITestDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [myAPITestDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [myAPITestDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [myAPITestDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [myAPITestDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [myAPITestDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [myAPITestDB] SET  MULTI_USER 
GO
ALTER DATABASE [myAPITestDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [myAPITestDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [myAPITestDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [myAPITestDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [myAPITestDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [myAPITestDB] SET QUERY_STORE = OFF
GO
USE [myAPITestDB]
GO
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 27/05/2020 18:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](max) NULL,
	[LastName] [varchar](max) NULL,
	[KnownAs] [varchar](max) NULL,
	[Department] [varchar](20) NULL,
	[DateStart] [datetime2](7) NULL,
	[DateEnd] [datetime2](7) NULL,
	[Gender] [nchar](10) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spAddEmployee]    Script Date: 27/05/2020 18:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spAddEmployee]     
(    
    @FirstName VARCHAR(100),     
    @LastName VARCHAR(100),    
    @KnownAs VARCHAR(100),    
    @Department VARCHAR(100),
	@DateStart DateTime,
	@DateEnd DateTime,
	@Gender VARCHAR(10)
	
)    
as     
Begin     
    Insert into tblEmployee (FirstName,	LastName,KnownAs, Department,DateStart, DateEnd, Gender)     
    Values (@FirstName,@LastName,
	@KnownAs, @Department,
	@DateStart,
	@DateEnd,
	@Gender)     
End   
GO
/****** Object:  StoredProcedure [dbo].[spDeleteEmployee]    Script Date: 27/05/2020 18:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spDeleteEmployee]     
(      
   @EmpId int      
)      
as       
begin      
   Delete from tblEmployee where EmployeeId=@EmpId      
End   
GO
/****** Object:  StoredProcedure [dbo].[spGetAllEmployees]    Script Date: 27/05/2020 18:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spGetAllEmployees]    
as    
Begin    
    select *    
    from tblEmployee    
End  
GO
/****** Object:  StoredProcedure [dbo].[spUpdateEmployee]    Script Date: 27/05/2020 18:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spUpdateEmployee]      
(      
   @EmpId INTEGER ,    
    @FirstName VARCHAR(100),     
    @LastName VARCHAR(100),    
    @KnownAs VARCHAR(100),    
    @Department VARCHAR(100),
	@DateStart DateTime,
	@DateEnd DateTime,
	@Gender VARCHAR(10)
)      
as      
begin      
   Update tblEmployee       
   set FirstName=@FirstName,      
   LastName=@LastName,      
   KnownAs=@KnownAs,    
   Department=@Department,
    DateStart=@DateStart,
	 DateEnd=@DateEnd,
	  Gender=@Gender   
   where EmployeeId=@EmpId      
End  
GO
USE [master]
GO
ALTER DATABASE [myAPITestDB] SET  READ_WRITE 
GO
