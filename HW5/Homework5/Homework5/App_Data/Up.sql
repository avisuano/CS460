-------------------------------
-- TENANT REQUEST FORM/TABLE --
-------------------------------
CREATE TABLE [dbo].[RequestForms]
(
	[ID]		INT	IDENTITY (1,1)  NOT NULL,
	[FirstName]	NVARCHAR(64)		NOT NULL,
	[LastName]	NVARCHAR(64)		NOT NULL,
	[Phone]		NVARCHAR(10)		NOT NULL,
	[Apt_Name]	NVARCHAR(64)		NOT NULL,
	[Unit]		INT					NOT NULL,
	[Request]	NVARCHAR(MAX)		NOT NULL,
	[Req_Date]	DATETIME			NOT NULL,
	CONSTRAINT [PK.dbo.RequestForm] PRIMARY KEY CLUSTERED ([ID] ASC)
);

---------------------------------
-- MAKING SURE THE TABLE WORKS --
---------------------------------
INSERT INTO [dbo].[RequestForms] (FirstName,LastName,Phone,Apt_Name,Unit,Request,Req_Date) VALUES
	('John','Doe','5035551234','Wolf Den','203','Toilet exploded','10/20/2018'),
	('Jane','Doe','8665559832','Crystal Lake Apartments','666','Doors and windows keep opening up','10/31/2018')
GO