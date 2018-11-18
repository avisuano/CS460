------------------------------
-- Table of logged searches --
------------------------------
CREATE TABLE [dbo].[SearchLogs]
(
	[ID]		INT	IDENTITY (1,1)	NOT NULL,
	[Search]	NVARCHAR(255)		NOT NULL,
	[SearchIP]	NVARCHAR(15)		NOT NULL,
	[SearchB]	NVARCHAR(100)		NOT NULL,
	[TimeStamp]	DateTime			NOT NULL,

	CONSTRAINT [PK.dbo.SearchLogs] PRIMARY KEY CLUSTERED ([ID] ASC)
);