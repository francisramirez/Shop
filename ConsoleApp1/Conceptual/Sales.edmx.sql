
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/27/2022 18:01:58
-- Generated from EDMX file: C:\Cursos\Shop-main\Shop-main\ConsoleApp1\Conceptual\Sales.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Shop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[Production].[FK_Products_Categories]', 'F') IS NOT NULL
    ALTER TABLE [Production].[Products] DROP CONSTRAINT [FK_Products_Categories];
GO
IF OBJECT_ID(N'[Production].[FK_Products_Suppliers]', 'F') IS NOT NULL
    ALTER TABLE [Production].[Products] DROP CONSTRAINT [FK_Products_Suppliers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[Production].[Categories]', 'U') IS NOT NULL
    DROP TABLE [Production].[Categories];
GO
IF OBJECT_ID(N'[Production].[Products]', 'U') IS NOT NULL
    DROP TABLE [Production].[Products];
GO
IF OBJECT_ID(N'[Production].[Suppliers]', 'U') IS NOT NULL
    DROP TABLE [Production].[Suppliers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [categoryid] int IDENTITY(1,1) NOT NULL,
    [categoryname] nvarchar(15)  NOT NULL,
    [description] nvarchar(200)  NOT NULL,
    [creation_date] datetime  NOT NULL,
    [creation_user] int  NOT NULL,
    [modify_date] datetime  NULL,
    [modify_user] int  NULL,
    [delete_user] int  NULL,
    [delete_date] datetime  NULL,
    [deleted] bit  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [productid] int IDENTITY(1,1) NOT NULL,
    [productname] nvarchar(40)  NOT NULL,
    [supplierid] int  NOT NULL,
    [categoryid] int  NOT NULL,
    [unitprice] decimal(19,4)  NOT NULL,
    [discontinued] bit  NOT NULL,
    [creation_date] datetime  NOT NULL,
    [creation_user] int  NOT NULL,
    [modify_date] datetime  NULL,
    [modify_user] int  NULL,
    [delete_user] int  NULL,
    [delete_date] datetime  NULL,
    [deleted] bit  NOT NULL
);
GO

-- Creating table 'Suppliers'
CREATE TABLE [dbo].[Suppliers] (
    [supplierid] int IDENTITY(1,1) NOT NULL,
    [companyname] nvarchar(40)  NOT NULL,
    [contactname] nvarchar(30)  NOT NULL,
    [contacttitle] nvarchar(30)  NOT NULL,
    [address] nvarchar(60)  NOT NULL,
    [city] nvarchar(15)  NOT NULL,
    [region] nvarchar(15)  NULL,
    [postalcode] nvarchar(10)  NULL,
    [country] nvarchar(15)  NOT NULL,
    [phone] nvarchar(24)  NOT NULL,
    [fax] nvarchar(24)  NULL,
    [creation_date] datetime  NOT NULL,
    [creation_user] int  NOT NULL,
    [modify_date] datetime  NULL,
    [modify_user] int  NULL,
    [delete_user] int  NULL,
    [delete_date] datetime  NULL,
    [deleted] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [categoryid] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([categoryid] ASC);
GO

-- Creating primary key on [productid] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([productid] ASC);
GO

-- Creating primary key on [supplierid] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [PK_Suppliers]
    PRIMARY KEY CLUSTERED ([supplierid] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [categoryid] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Products_Categories]
    FOREIGN KEY ([categoryid])
    REFERENCES [dbo].[Categories]
        ([categoryid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Products_Categories'
CREATE INDEX [IX_FK_Products_Categories]
ON [dbo].[Products]
    ([categoryid]);
GO

-- Creating foreign key on [supplierid] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Products_Suppliers]
    FOREIGN KEY ([supplierid])
    REFERENCES [dbo].[Suppliers]
        ([supplierid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Products_Suppliers'
CREATE INDEX [IX_FK_Products_Suppliers]
ON [dbo].[Products]
    ([supplierid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------