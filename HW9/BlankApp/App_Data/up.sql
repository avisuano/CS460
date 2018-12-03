CREATE TABLE [dbo].[SimpleTable]
(
	[ID] INT IDENTITY(1,1) NOT NULL,
	[FirstName] NVARCHAR(32) NOT NULl,
	[LastName] NVARCHAR(32) NOT NULL,
	CONSTRAINT [PK_dbo.SimpleTable] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[SimpleTable] VALUES
	('John', 'Candy'),
	('Frank', 'Jones'),
	('Jane', 'Doe')