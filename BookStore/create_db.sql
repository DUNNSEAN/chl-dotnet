CREATE DATABASE [BookStore]
GO

USE [BookStore]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 04/19/2010 15:44:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books] (
    [id]     INT            IDENTITY (1, 1) NOT NULL,
    [Author] NVARCHAR (100) NOT NULL,
    [Title]  NVARCHAR (100) NOT NULL,
    [Price]  NUMERIC (5, 2) NOT NULL,
    [Bib_key] NVARCHAR(50) NOT NULL DEFAULT 0000000000, 
    [Info_url] NVARCHAR(100) NULL, 
    [Preview] NCHAR(10) NULL, 
    [Preview_url] NVARCHAR(100) NULL, 
    [Thumbnail_url] NVARCHAR(100) NULL, 
    [Url] NVARCHAR(100) NULL, 
    [Subtitle] NVARCHAR(100) NULL, 
    [Identifiers] NVARCHAR(100) NULL, 
    [Classifications] NVARCHAR(100) NULL, 
    [Subjects] NVARCHAR(100) NULL, 
    [Subject_places] NVARCHAR(100) NULL, 
    [Subject_people] NVARCHAR(100) NULL, 
    [Subject_times] NVARCHAR(100) NULL, 
    [Publishers] NVARCHAR(100) NULL, 
    [Publish_places] NVARCHAR(100) NULL, 
    [Publish_date] NVARCHAR(100) NULL, 
    [Excerpts] NVARCHAR(MAX) NULL, 
    [Links] NVARCHAR(100) NULL, 
    [Cover] NVARCHAR(100) NULL, 
    [Ebooks] NVARCHAR(100) NULL, 
    [Number_of_pages] NVARCHAR(100) NULL, 
    [Weight] NVARCHAR(100) NULL, 
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([id] ASC)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 04/19/2010 15:44:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Price]      NUMERIC (5, 2) NOT NULL,
    [Status]     NVARCHAR (10)  NULL,
    [FirstName]  NVARCHAR (50)  NULL,
    [LastName]   NVARCHAR (50)  NULL,
    [Address]    NVARCHAR (MAX) NULL,
    [City]       NVARCHAR (MAX) NULL,
    [State]      NVARCHAR (50)  NULL,
    [PostalCode] NCHAR (10)     NULL,
    [Country]    NVARCHAR (50)  NULL,
    [Phone]      NVARCHAR (50)  NULL,
    [Email]      NVARCHAR (50)  NULL,
    [OrderDate]  DATETIME       NULL,
    [Title]  NVARCHAR (50)  DEFAULT ('') NOT NULL,
    [Author] NVARCHAR(50) NOT NULL DEFAULT (''), 
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderLines]    Script Date: 04/19/2010 15:44:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLines](
	[BookId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_LineItem] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC,
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_OrderLines_Books]    Script Date: 04/19/2010 15:44:30 ******/
ALTER TABLE [dbo].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLines_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT [FK_OrderLines_Books]
GO
/****** Object:  ForeignKey [FK_OrderLines_Orders]    Script Date: 04/19/2010 15:44:30 ******/
ALTER TABLE [dbo].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLines_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT [FK_OrderLines_Orders]
GO

INSERT [Books] ([Author], [Title], [Price], [Bib_key]) VALUES (N'Mark Twain', N'The Adventures of Tom Sawyer', CAST(46.34 AS Numeric(5, 2)), 0451526538)
INSERT [Books] ([Author], [Title], [Price], [Bib_key]) VALUES (N'J.R.R. Tolkien', N'The Lord of the Rings', CAST(50.20 AS Numeric(5, 2)), 9780544003415)
INSERT [Books] ([Author], [Title], [Price], [Bib_key]) VALUES (N'J.K. Rowling', N'Harry Potter', CAST(24.75 AS Numeric(5, 2)), 9788700631625)
INSERT [Books] ([Author], [Title], [Price], [Bib_key]) VALUES (N'Eoin Colfer', N'Artemis Fowl: The Time Paradox', CAST(31.49 AS Numeric(5, 2)), 9783844903379)