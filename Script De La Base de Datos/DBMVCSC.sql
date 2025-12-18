/* =========================================================
   1. CREAR BASE DE DATOS
========================================================= */
USE [master];
GO

CREATE DATABASE [DBMVCSC]
 ON  PRIMARY 
(
    NAME = N'DBMVCSC',
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DBMVCSC.mdf',
    SIZE = 8192KB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 65536KB
)
 LOG ON 
(
    NAME = N'DBMVCSC_log',
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DBMVCSC_log.ldf',
    SIZE = 8192KB,
    MAXSIZE = 2048GB,
    FILEGROWTH = 65536KB
);
GO

ALTER DATABASE [DBMVCSC] SET COMPATIBILITY_LEVEL = 160;
GO

USE [DBMVCSC];
GO

/* =========================================================
   2. TABLA mStatu (PADRE – SE CREA PRIMERO)
========================================================= */
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

CREATE TABLE [dbo].[mStatu](
    [IdStatus] INT IDENTITY(1,1) NOT NULL,
    [Descripcion] NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_mStatu PRIMARY KEY CLUSTERED ([IdStatus])
);
GO

SET IDENTITY_INSERT [dbo].[mStatu] ON;
GO
INSERT INTO [dbo].[mStatu] ([IdStatus], [Descripcion]) VALUES (1, N'Activo');
INSERT INTO [dbo].[mStatu] ([IdStatus], [Descripcion]) VALUES (2, N'Inactivo');
GO
SET IDENTITY_INSERT [dbo].[mStatu] OFF;
GO

/* =========================================================
   3. TABLA USERS
========================================================= */
CREATE TABLE [dbo].[USERS](
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Nombre] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(150) NOT NULL,
    [Password] NVARCHAR(255) NOT NULL,
    [Edad] INT NULL,
    [idEstatus] INT NOT NULL,
    CONSTRAINT PK_USERS PRIMARY KEY CLUSTERED ([ID])
);
GO

SET IDENTITY_INSERT [dbo].[USERS] ON;
GO
INSERT INTO [dbo].[USERS]
([ID], [Nombre], [Email], [Password], [Edad], [idEstatus])
VALUES
(1, N'Admin', N'admin@local.com', N'1234', 30, 1);
GO
SET IDENTITY_INSERT [dbo].[USERS] OFF;
GO

/* =========================================================
   4. TABLA AUTOS
========================================================= */
CREATE TABLE [dbo].[AUTOS](
    [IdAuto] INT IDENTITY(1,1) NOT NULL,
    [Marca] NVARCHAR(100) NOT NULL,
    [Modelo] NVARCHAR(100) NOT NULL,
    [Anio] NVARCHAR(10) NOT NULL,
    [Color] NVARCHAR(50) NOT NULL,
    [ImgRuta] NVARCHAR(255) NOT NULL,
    [Precio] FLOAT NOT NULL,
    [TipoVehiculo] NVARCHAR(50) NOT NULL,
    [Direccion] NVARCHAR(255) NOT NULL,
    [miEstatus] INT NOT NULL,
    CONSTRAINT PK_AUTOS PRIMARY KEY CLUSTERED ([IdAuto])
);
GO

SET IDENTITY_INSERT [dbo].[AUTOS] ON;
GO
INSERT INTO [dbo].[AUTOS]
([IdAuto], [Marca], [Modelo], [Anio], [Color], [ImgRuta], [Precio], [TipoVehiculo], [Direccion], [miEstatus])
VALUES
(1, N'Toyota', N'Corolla', N'2020', N'Blanco', N'https://localhost:44345/Content/Img/Toyota.jpg', 18500, N'Sedan', N'Santo Domingo', 1),
(2, N'Honda', N'Civic', N'2019', N'Negro', N'https://localhost:44345/Content/Img/HondaCivic.jpg', 17800, N'Sedan', N'Santiago', 1),
(3, N'Hyundai', N'Elantra', N'2021', N'Gris', N'https://localhost:44345/Content/Img/Hyundai.png', 19500, N'Sedan', N'La Vega', 2),
(4, N'Ford', N'Escape', N'2018', N'Rojo', N'/img/escape.jpg', 16200, N'SUV', N'San Cristobal', 2),
(5, N'Buggatti', N'Bayron', N'2020', N'Negro', N'https://localhost:44345/Content/Img/Bugatti.jpg', 1000000, N'Sedan', N'Santo Domingo', 1);
GO
SET IDENTITY_INSERT [dbo].[AUTOS] OFF;
GO

/* =========================================================
   5. TABLA VHESTAU (INDEPENDIENTE)
========================================================= */
CREATE TABLE [dbo].[VHESTAU](
    [IDEstatus] INT IDENTITY(1,1) NOT NULL,
    [Descripcion] NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_VHESTAU PRIMARY KEY CLUSTERED ([IDEstatus])
);
GO

/* =========================================================
   6. FOREIGN KEYS (AL FINAL)
========================================================= */
ALTER TABLE [dbo].[AUTOS]
ADD CONSTRAINT FK_AUTOS_mStatu
FOREIGN KEY ([miEstatus]) REFERENCES [dbo].[mStatu] ([IdStatus]);
GO

ALTER TABLE [dbo].[USERS]
ADD CONSTRAINT FK_USERS_mStatu
FOREIGN KEY ([idEstatus]) REFERENCES [dbo].[mStatu] ([IdStatus]);
GO

/* =========================================================
   7. FINAL
========================================================= */
USE [master];
GO
ALTER DATABASE [DBMVCSC] SET READ_WRITE;
GO
