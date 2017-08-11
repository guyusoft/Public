﻿USE IMS
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[NavigationMenu]') and OBJECTPROPERTY(id, N'IsTable') = 1)
BEGIN
	CREATE TABLE NavigationMenu(
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	Href NVARCHAR(500) NOT NULL,
	[Text] NVARCHAR(50) NOT NULL)
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[UserDetail]') and OBJECTPROPERTY(id, N'IsTable') = 1)
BEGIN
	CREATE TABLE UserDetail(
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	LoginName NVARCHAR(20) NOT NULL,
	LoginPwd NVARCHAR(50) NOT NULL,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	EmailAddress NVARCHAR(200) NOT NULL,
	PostAddress NVARCHAR(1000) NULL)
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[NewsCategory]') and OBJECTPROPERTY(id, N'IsTable') = 1)
BEGIN
	CREATE TABLE NewsCategory(
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	ParentId INT NULL,
	CategoryName NVARCHAR(100) NOT NULL)
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[ProductCategory]') and OBJECTPROPERTY(id, N'IsTable') = 1)
BEGIN
	CREATE TABLE ProductCategory(
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	ParentId INT NULL,
	CategoryName NVARCHAR(100) NOT NULL)
END
GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[News]') and OBJECTPROPERTY(id, N'IsTable') = 1)
BEGIN
	CREATE TABLE News(
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	Title NVARCHAR(500) NOT NULL,
	NewsCategoryId INT NOT NULL,
	UserId INT NOT NULL,
	Content NVARCHAR(MAX) NOT NULL
	)
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[Product]') and OBJECTPROPERTY(id, N'IsTable') = 1)
BEGIN
	CREATE TABLE Product(
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	ProductName NVARCHAR(200) NOT NULL,
	ProductDesc NVARCHAR(MAX) NULL,
	ProductCategoryId INT NOT NULL
	)
END
GO