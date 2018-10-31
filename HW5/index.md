# Homework Five

The requirements for this assignment can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW5_1819.html)

The repository can be found [here](https://github.com/avisuano/CS460/tree/master/HW5).

The first step was to checkout a new branch, ```git checkout -b hw5_main``` and then start a new project in Visual Studio. The first step was to start a create a new database and table. After that was finished, I created the up.sql and down.sql files.

```sql
-------------------------------
-- TENANT REQUEST FORM/TABLE --
-------------------------------
CREATE TABLE [dbo].[Requests]
(
	[ID]		INT	IDENTITY (1,1)  NOT NULL,
	[FirstName]	NVARCHAR(64)		NOT NULL,
	[LastName]	NVARCHAR(64)		NOT NULL,
	[Phone]		NVARCHAR(10)		NOT NULL,
	[Apt_Name]	NVARCHAR(64)		NOT NULL,
	[Unit]		INT					NOT NULL,
	[Req_Box]	NVARCHAR(MAX)		NOT NULL,
	[Req_Date]	DATETIME			NOT NULL,
	CONSTRAINT [PK.dbo.RequestForm] PRIMARY KEY CLUSTERED ([ID] ASC)
);
```

After that was completed, I put a couple entries into the table, and then did a quick query to make sure the everything was working on the database side of things. Just a quick ```SELECT * FROM dbo.Requests``` to make sure the table was populated.

```sql
---------------------------------
-- MAKING SURE THE TABLE WORKS --
---------------------------------
INSERT INTO [dbo].[Requests] (FirstName,LastName,Phone,Apt_Name,Unit,Req_Box,Req_Date) VALUES
	('John','Doe','5035551234','Wolf Den','203','Toilet exploded','10/20/2018'),
	('Jane','Doe','8665559832','Crystal Lake Apartments','666','Doors and windows keep opening up','10/31/2018')
GO
```
