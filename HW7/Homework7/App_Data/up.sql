------------------------------
-- Table of logged searches --
------------------------------
CREATE TABLE [dbo].[SearchLogs]
(
	[ID]		INT	IDENTITY (1,1)	NOT NULL,
	[Search]	NVARCHAR(128)		NOT NULL,
	[SearchIP]	NVARCHAR(15)		NOT NULL,
	[TimeStamp]	DateTime			NOT NULL,
	CONSTRAINT [PK.dbo.SearchLogs] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[SearchLogs] (Search,SearchIP,TimeStamp) VALUES
	('put somthing to display','192.168.1.1','2018-11-15 00:00:00')
GO