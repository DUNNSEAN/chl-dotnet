CREATE DATABASE [BookStore]
GO

USE [BookStore]
GO

/* [dbo].[Books] */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Author] [nvarchar](100) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Price] [numeric](5,2) NOT NULL,
CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED
(
	[Id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/* [dbo].[Orders] */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [numeric](5,2) NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED
(
	[Id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/* [dbo].[OrderLines] */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLines](
	[BookId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED
(
	[BookId] ASC,
	[OrderId] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/* [FK_OrderLines_Books] */
ALTER TABLE [dbo].[OrderLines] WITH CHECK ADD CONSTRAINT [FK_OrderLines_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books]([Id])
GO
ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT[FK_OrderLines_Books]
GO

/* [FK_OrderLines_Orders] */
ALTER TABLE [dbo].[OrderLines] WITH CHECK ADD CONSTRAINT [FK_OrderLines_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders]([Id])
GO
ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT[FK_OrderLines_Orders]
GO

INSERT [Books] ([Author], [Title], [Price]) VALUES (N'Eric Evans', N'Domain Driven Design', CAST(46.34 AS NUMERIC(5,2)))
INSERT [Books] ([Author], [Title], [Price]) VALUES (N'Martin Fowler', N'Analysis Patterns', CAST(50.20 AS NUMERIC(5,2)))
INSERT [Books] ([Author], [Title], [Price]) VALUES (N'Gojko Adzic', N'Bridging the Communication Gap', CAST(24.75 AS NUMERIC(5,2)))
INSERT [Books] ([Author], [Title], [Price]) VALUES (N'Ted Pattison', N'Inside Windows SharePoint Services', CAST(31.49 AS NUMERIC(5,2)))