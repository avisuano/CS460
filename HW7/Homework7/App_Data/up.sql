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