------------------
-- BUYERS TABLE --
------------------
CREATE TABLE [dbo].[Buyers]
(
	BuyerID		INT	IDENTITY(1,1)		NOT NULL,
	[Name]		NVARCHAR(32)			NOT NULL,
	CONSTRAINT[PK_dbo.Buyers] PRIMARY KEY CLUSTERED (BuyerID ASC)
);

-------------------
-- SELLERS TABLE --
-------------------
CREATE TABLE [dbo].[Sellers]
(
	SellerID	INT IDENTITY(1,1)		NOT NULL,
	[Name]		NVARCHAR(32)			NOT NULL,
	CONSTRAINT[PK_dbo.Sellers] PRIMARY KEY CLUSTERED (SellerID ASC)
);

-----------------
-- ITEMS TABLE --
-----------------
CREATE TABLE [dbo].[Items]
(
	ItemID			INT IDENTITY(101,1)		NOT NULL,
	[Name]			NVARCHAR(32)			NOT NULL,
	[Description]	NVARCHAR(500)			NOT NULL,
	SellerID		INT						NOT NULL,
	CONSTRAINT[PK_dbo.Items] PRIMARY KEY CLUSTERED (ItemID ASC),
	CONSTRAINT[FK_dbo.Items] FOREIGN KEY (SellerID) REFERENCES Sellers(SellerID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

----------------
-- BIDS TABLE --
----------------
CREATE TABLE [dbo].[Bids]
(
	BidID		INT	IDENTITY(1,1)		NOT NULL,
	Price		DECIMAL					NOT NULL,
	[Timestamp]	DATETIME				NOT NULL,
	ItemID		INT						NOT NULL,
	BuyerID		INT						NOT	NULL,
	CONSTRAINT[PK_dbo.Bids]	 PRIMARY KEY CLUSTERED (BidID ASC),
	CONSTRAINT[FK1_dbo.Bids] FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT[FK2_dbo.Bids] FOREIGN KEY (BuyerID) REFERENCES Buyers(BuyerID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

INSERT INTO [dbo].[Buyers]([Name]) VALUES
	('John Smith'),
	('Franklin Rose'),
	('Lourie Joe')

INSERT INTO [dbo].[Sellers]([Name]) VALUES
	('Mary Ann'),
	('Jon Appleton')

INSERT INTO [dbo].[Items]([Name],[Description], SellerID) VALUES
	('Blob of Gum','An 18 year old collection of used gum!',1),
	('Space Gun','A working space lazer pistol! May cause burns, skin irritation, and blindness',2),
	('Painting','Painting from a young, ungifted child',2)

INSERT INTO [dbo].[Bids](ItemID, BuyerID, Price, [Timestamp]) VALUES
	(101,1,800.50,'11/20/2018 00:00:01'),
	(102,2,1000,'11/20/2018 06:30:31'),
	(103,2,100,'11/20/2018 06:40:01'),
	(101,3,10000,'11/20/2018 07:01:04')