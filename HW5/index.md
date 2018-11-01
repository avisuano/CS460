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

After the tables were created and data was inserted into the table, the next thing needed was to set up the connection string into the web.config file.
```html
<connectionStrings>
	<add name="RequestContext"
			 connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\CS460\HW5\Homework5\Homework5\App_Data\Request_DB.mdf;Integrated Security=True"
			 providerName="System.Data.SqlClient"/>
</connectionStrings>
```

The next thing to get started on was the context and model. First a DAL file was created to contain the database context. The context and model table were both fairly straight forward.

```cs
public class RequestContext : DbContext
{
		public RequestContext() : base("name=RequestContext") { }
		public virtual DbSet<Request> Requests { get; set; }
}
```
And then the model class...
```cs
/// <summary>
/// Request object for maintenance requests
/// </summary>
public class Request
{
		/// <summary>
		/// Primary key, automatically generated
		/// </summary>
		[Required]
		public int ID { get; set; }

		/// <summary>
		/// First name of the individual requesting maintenance
		/// </summary>
		[Required]
		[StringLength(64)]
		[Display(Name = "First Name: ")]
		public string FirstName { get; set; }

		/// <summary>
		/// Last name of the individual requesting maintenance
		/// </summary>
		[Required]
		[StringLength(64)]
		[Display(Name = "Last Name: ")]
		public string LastName { get; set; }

		/// <summary>
		/// Phone number of the individual requesting maintenance
		/// </summary>
		[Required]
		[StringLength(10)]
		[Display(Name = "Phone Number: ")]
		public string Phone { get; set; }

		/// <summary>
		/// Name of the apartment in need of maintenance
		/// </summary>
		[Required]
		[StringLength(64)]
		[Display(Name = "Apartment Name: ")]
		public string Apt_Name { get; set; }

		/// <summary>
		/// Specific room/area in need of maintenance
		/// </summary>
		[Required]
		[Display(Name = "Unit Number: ")]
		public int Unit { get; set; }

		/// <summary>
		/// Brief summary of what needs repaired
		/// </summary>
		[Required]
		[Display(Name = "Request: ")]
		public string Req_Box { get; set; }

		/// <summary>
		/// Date request was submitted
		/// </summary>
		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Date of Request:")]
		public DateTime Req_Date { get; set; }

		/// <summary>
		/// Override for the ToString method to output this model
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
				return $"(base.ToString()): {FirstName} {LastName} Phone = {Phone} Apt_Name = {Apt_Name} Req_Box = {Req_Box}";
		}
}
```

Next I decided to tackle something that could push the database table to the view. I decided to do a very simple view, I'm not a designer, nor very creative.

```cs
private RequestContext rc = new RequestContext();

public ActionResult RequestQueue()
{
		return View(rc.Requests.ToList());
}
```
```html
<table>
    <tr>
        <th>@Html.DisplayNameFor(model => model.Apt_Name) </th>
        <th style="padding: 0px 0px 0px 15px">@Html.DisplayNameFor(model => model.Req_Box) </th>
        <th style="padding: 0px 0px 0px 15px">@Html.DisplayNameFor(model => model.Req_Date) </th>
    </tr>
    <!-- Puts the data into the table -->
    @foreach (var item in Model)
    {
    <tr>
        <td>@Html.DisplayFor(model => item.Apt_Name) </td>
        <td style="padding: 0px 0px 0px 15px">@Html.DisplayFor(model => item.Req_Box) </td>
        <td style="padding: 0px 0px 0px 15px">@Html.DisplayFor(model => item.Req_Date) </td>
    </tr>
    }
</table>
```
![firststep](https://avisuano.github.io/CS460/HW5/stepone.PNG)


After the data was being pushed, I had to hunker down and work on a view to push the information from the browser to the database table. It took, as usual, way longer than it needed to. After many hours of scouring the internet and stack overflow for every error along the way, I was able to finally get it to work.

The trick, was in the controller. With just a few simple lines, it was finally working. The largest issue was not sending the object to the view. After that everything was actually doing what it was supposed to!

```cs
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult SubmitRequest(Request requests)
{
		if (ModelState.IsValid)
		{

				rc.Requests.Add(requests);
				rc.SaveChanges();

				RedirectToAction("RequestQueue");
		}

		return View(requests);
}
```
The view was very straight forward, and very ugly. I spent so long trying to figure out the logic, that the design of the view took a big hit... it's ugly. If I had more time, I would have devoted several more hours to really clean it up and make something that would be nice to look at.

```html
@Html.LabelFor(model => model.FirstName, htmlAttributes: new { @class = "control-label col-md-2" })
@Html.EditorFor(model => model.FirstName, new { htmlAttributes = new { @class = "form-control" } })
```

![It's working!](https://avisuano.github.io/CS460/HW5/steptwo.PNG)

After that I checked both the database and that the new insertions were actually getting pushed to the view.

![It's working!](https://avisuano.github.io/CS460/HW5/stepfour.PNG)

![It's working!](https://avisuano.github.io/CS460/HW5/stepthree.PNG)

At this point I have been working on this project for far too long, and had to move on to project six or risk falling even further behind. 
