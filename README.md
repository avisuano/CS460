# Welcome To My Portfolio
This is a collection of my attempt to code.


## About Me

I am a Computer Science major at [Western Oregon University](http://www.wou.edu/). I have some general IT experience, three years as a Cyber Network Operator ([MOS 0651](http://mosmanual.com/pages/mos/06/0651.php)) in the United States Marine Corps. Unfortunately most of this experience doesn't translate to coding.

## Code Storage
I have repositories here: [GitHub](https://github.com/avisuano/CS460) and here: [BitBucket](https://bitbucket.org/avisuano15/cs460/src/master/). The later is mostly a back up for now, but will be transitioned into the main storage after CS460.
***
### Homework For CS460
1. **Homework One - Git, HTML/CSS, Bootstrap**
    - Requirements can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW1.html).
    - The completed assignment can be found [here](https://avisuano.github.io/CS460/HW1/main.html).
    - Explanation of what I did can be found [here](https://avisuano.github.io/CS460/HW1/).
2. **Homework Two - HTML, Javascript, jQuery**
    - Requirements can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW2.html).
    - Currently in progress... will be finished before long (hopefully)
3. **Homework Three - C# console, translate app**
    - Requirements can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW3_1819.html).
    - The rational used to complete the assignment can be found [here](https://avisuano.github.io/CS460/HW3/).
4. **Homework Four - MCV app 1, no dB**
    - Requirements can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW4.html).
    - How this assignment was completed can be found [here](https://avisuano.github.io/CS460/HW4/).
5. **Homework Five - MVC app 2, simple dB**
    - Requirements can be found [here](http://wou.edu/~morses/classes/cs46x/assignments/HW5_1819.html).
    - What I did can be found [here](https://avisuano.github.io/CS460/HW5/).
6. **Homework Six - MVC app 3, pre-existing relational dB**
    - Requirements can be found [here](http://wou.edu/~morses/classes/cs46x/assignments/HW6_1819.html).
    - The rationalization of what went wrong [here](https://avisuano.github.io/CS460/HW6/).
7. **Homework Seven - MVC app 4, AJAX single page app**
    - Requirements can be found [here](http://wou.edu/~morses/classes/cs46x/assignments/HW7_1819.html).
    - The journey can be found [here](https://avisuano.github.io/CS460/HW7/).    
8. **Homework Eight - MVC app 5, DIY multi-table/relational dB**
    - Requirements can be found [here](http://wou.edu/~morses/classes/cs46x/assignments/HW8_1819.html).   
    - The blog can be found [here](https://avisuano.github.io/CS460/HW8/)
9. **Homework Nine - MVC app 6, Cloud Deployment**
    - Requirements can be found [here](http://wou.edu/~morses/classes/cs46x/assignments/HW9_1819.html).
    - Screen shots can be found [here](https://avisuano.github.io/CS460/HW9/)
    - Working website (uuuugly) can be found [here](http://hw8app.azurewebsites.net/)

***

## Notes for the final

GitHub [cheat sheet](https://services.github.com/on-demand/downloads/github-git-cheat-sheet.pdf)

Bootstrap [documentation](https://getbootstrap.com/docs/3.3/css/)

JQuery [cheat sheet](https://oscarotero.com/jquery/)

Javascript [and strings](https://www.digitalocean.com/community/tutorials/how-to-index-split-and-manipulate-strings-in-javascript)

C# [and strings](http://www.csharp-examples.net/string-format-datetime/)

LINQ [cheat sheet](https://weblogs.asp.net/bradvincent/linq-cheat-sheet)

Razor [cheat sheet](https://haacked.com/archive/2011/01/06/razor-syntax-quick-reference.aspx/)

.NET [API](https://docs.microsoft.com/en-us/dotnet/api/index?view=netframework-4.7.2)

UP and DOWN script from Homework 8 for a syntax guide/reminder
```sql
------------------
-- BUYERS TABLE --
------------------
CREATE TABLE [dbo].[Buyers]
(
	BuyerID		INT	IDENTITY(1,1) NOT NULL,
	BuyerName	NVARCHAR(32) NOT NULL,
	CONSTRAINT[PK_dbo.Buyers] PRIMARY KEY CLUSTERED (BuyerID ASC)
);

-------------------
-- SELLERS TABLE --
-------------------
CREATE TABLE [dbo].[Sellers]
(
	SellerID	INT IDENTITY(1,1) NOT NULL,
	SellerName	NVARCHAR(32) NOT NULL,
	CONSTRAINT[PK_dbo.Sellers] PRIMARY KEY CLUSTERED (SellerID ASC)
);

-----------------
-- ITEMS TABLE --
-----------------
CREATE TABLE [dbo].[Items]
(
	ItemID			INT IDENTITY(101,1) NOT NULL,
	ItemName		NVARCHAR(32) NOT NULL,
	ItemDescription	NVARCHAR(500) NOT NULL,
	SellerID		INT	NOT NULL,
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
	BidID		INT	IDENTITY(1,1)	NOT NULL,
	ItemID		INT	NOT NULL,
	BuyerID		INT	NOT	NULL,
	Price		DECIMAL	NOT NULL,
	[Timestamp]	DATETIME	NOT NULL,
	CONSTRAINT[PK_dbo.Bids]	 PRIMARY KEY CLUSTERED (BidID ASC),
	CONSTRAINT[FK1_dbo.Bids] FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT[FK2_dbo.Bids] FOREIGN KEY (BuyerID) REFERENCES Buyers(BuyerID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

--------------------------------
-- SOME SILLY/GENERIC ITEMS --
--------------------------------
INSERT INTO [dbo].[Buyers](BuyerName) VALUES
	('John Smith'),
	('Franklin Rose'),
	('Lourie Joe')

INSERT INTO [dbo].[Sellers](SellerName) VALUES
	('Mary Ann'),
	('Jon Appleton')

INSERT INTO [dbo].[Items](ItemName,ItemDescription, SellerID) VALUES
	('Blob of Gum','An 18 year old collection of used gum!',1),
	('Space Gun','A working space lazer pistol! May cause burns, skin irritation, and blindness',2),
	('Painting','Painting from a young, ungifted child',2)

  ----------------------
  -- CLEAR THE TABLES --
  ----------------------
  DROP TABLE IF EXISTS [dbo].[Bids]
  DROP TABLE IF EXISTS [dbo].[Buyers]
  DROP TABLE IF EXISTS [dbo].[Items]
  DROP TABLE IF EXISTS [dbo].[Sellers]
```

Generate an Entity Relationship Diagram
  1. Go to SMMS >
  2. Object Explorer >
  3. Databases >
  4. Choose your database
  5. Right click -> 'Database Diagrams' -> 'New Database Diagram'
  6. Choose the tables from the menu
  7. Add
  8. Finished
