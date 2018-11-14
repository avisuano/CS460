------------------------------
-- Table of logged searches --
------------------------------
CREATE TABLE [dbo].[SearchLogs]
(
	[ID]		INT	IDENTITY (1,1)	NOT NULL,
	[Search]	NVARCHAR(MAX)		NOT NULL,
	[SearchIP]	NVARCHAR			NOT NULL,
	[Date]		DateTime			NOT NULL,
	CONSTRAINT [PK.dbo.SearchLogs] PRIMARY KEY CLUSTERED ([ID] ASC)
);