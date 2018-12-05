------------------
-- ARTIST TABLE --
------------------
CREATE TABLE [dbo].[Artist]
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	ArtistName NVARCHAR(128),
	BirthDate DATETIME2,
	BirthCity NVARCHAR(128)
);

-----------------
-- GENRE TABLE --
-----------------
CREATE TABLE [dbo].[Genre]
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	GenreName NVARCHAR(64) UNIQUE
);

-------------------
-- ARTWORK TABLE --
-------------------
CREATE TABLE [dbo].[Artwork]
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Title NVARCHAR(255),
	ArtistID INT FOREIGN KEY REFERENCES Artist
);

--------------------------
-- CLASSIFICATION TABLE --
--------------------------
CREATE TABLE [dbo].[Classification]
(
	ID INT IDENTITY(1,1) NOT NULL,
	ArtworkID INT FOREIGN KEY REFERENCES Artwork,
	GenreID INT FOREIGN KEY REFERENCES Genre,
	CONSTRAINT [pk.dbo.Classifications] PRIMARY KEY CLUSTERED (ID ASC)
);

INSERT INTO Artist(ArtistName, BirthDate, BirthCity) VALUES
	('M.C Escher','1898-6-17','Leeuwarden, Netherlands'),
	('Leonardo Da Vinci','1519-5-2','Vinci, Italy'),
	('Hatip Mehmed Efendi','1680-11-18','Unknown'),
	('Salvador Dali','1904-05-11','Figueres, Spain');

INSERT INTO Genre(GenreName) VALUES
	('Tesselation'),
	('Surrealism'),
	('Portrait'),
	('Renaissance');

INSERT INTO Artwork(Title, ArtistID) VALUES
	('Circle Limit III', 1),
	('Twon Tree', 1),
	('Mona Lisa', 2),
	('The Vitruvian Man',2),
	('Ebru', 3),
	('Honey Is Sweeter Than Blood', 4);

INSERT INTO Classification(ArtworkID, GenreID) VALUES
	(1,1),
	(2,1),
	(2,2), 
	(3,3),
	(3,4),
	(4,4),
	(5,1),
	(6,2);

SELECT * FROM Artist;
SELECT Title, ArtistName FROM Artwork JOIN Artist ON Artwork.ArtistID=Artist.ID;