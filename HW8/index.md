# Homework Eight

The requirements for this assignment can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW8_1819.html)

The repository can be found [here](https://github.com/avisuano/CS460/tree/master/HW8/).

---

This assignment proved to be quite the struggle. It started like most of the others, created a new web app, push the empty project and then checkout a new branch ```git checkout -b hw8_main```. First things I needed to tackle was the up and down SQL scripts. The most complicated part was making sure what primary and foreign keys are correct. The bids table was probably to most difficult. Overall, the database side of the project was straight forward and took the least amount of time.

```sql
CREATE TABLE [dbo].[Bids]
(
	BidID		INT	IDENTITY(1,1)	NOT NULL,
	ItemID		INT					NOT NULL,
	BuyerID		INT					NOT	NULL,
	Price		DECIMAL				NOT NULL,
	[Timestamp]	DATETIME			NOT NULL,
	CONSTRAINT[PK_dbo.Bids]	 PRIMARY KEY CLUSTERED (BidID ASC),
	CONSTRAINT[FK1_dbo.Bids] FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT[FK2_dbo.Bids] FOREIGN KEY (BuyerID) REFERENCES Buyers(BuyerID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
```

After the database was set up, and tested, work began on the model/context classes. Fortunately, it was fairly straight forward. I did end up creating another model class, solely to act as the middle guy for the Buyer and Bid class. I was having trouble getting the correct sequence for pushing/pulling data between the database and the browser. Creating another model class, made it easier for me to visualize what was going on.

Simple, straight-forward, easy for a dummy like myself.
```cs
public class GrabTheBids
{
    public string BuyerName { get; set; }

    public decimal Price { get; set; }
}
```

The first and largest struggle was getting the AJAX/JQuery/Javascript working correctly. The first thing I needed to do, was make sure the correct id data was being passed to the controller. I tried to use .val(), which from what I read should have worked. Thankfully, .html() does work. The way I found to grab the id, was to add a section to the details page, that the script would then pull from the page, and push that to the controller, ```var id = parseInt($('#itemId').html().trim());```.

The main function:
```javascript
var getList = function () {
    // Make sure integers are
    var id = parseInt($('#itemId').html().trim());

    // More trouble shooting
    console.log('item id: ' + id);

    // Send to ItemController
    var src = "/Items/ListBids?Id=" + id;

    // Can we get an ajax call?
    console.log("step 1");

    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: src,
        success: display,
        error: oops
    });
};
```

I used a lot of ```console.log()``` with this assignment. This was a real struggle, and I ended up just putting them every step of the way to figure out where each spot was failing. The display function was to push the findings into a table via Json. It was quite the doozy, but finally got it working 100% after I was almost completely finished with the project.


```javascript
// If successful push to page
function display(data) {

    // Is the data actually the data we need?
    console.log('the data: ' + data);

    // Convert to a Json object
    var tmp = JSON.parse(data);

    // Set up the display table
    $('.displayBids').empty();
    $('.displayBids').append('<tr><th> Current Bidders: </th> <th> Bid Price </th> </tr>');

    // Fill the table
    for (var i = 0; i < tmp.length; i++)
    {
        $('.displayBids').append('<tr> <td>' + tmp[i].BuyerName + '</td><td>' + tmp[i].Price + '</td></tr>');
    }

    // Did we get anything?
    console.log("maybe we can get somewhere");
}
```

While working on the Javascript (and taking lots of frustrated breaks), I also got started on the method to grab the buyer's name and price from the database, and return it to the browser. This is where the extra model class comes into play. I tried simplier ways, but just couldn't get the logic correct. For some reason, using a middle man class was able to click.

```cs
public JsonResult ListBids(int? id)
{
    // Let's find each item by id
    var bids = db.Bids.Where(a => a.ItemID == id)
        .OrderByDescending(d => d.Price)
        .ToList();

    // New class object to grab Name (Buyer) and Price (Bid)
    List<GrabTheBids> bidTable = new List<GrabTheBids>();
    GrabTheBids tmp;

    // Fill that up with the Buyer name and the current bid Prices
    foreach (Bid bid in bids)
    {
        tmp = new GrabTheBids
        {
            BuyerName = bid.Buyer.BuyerName,
            Price = bid.Price                    
        };
        bidTable.Add(tmp);
    }

    // Convert back to a json object to send through
    string toJson = JsonConvert.SerializeObject(bidTable, Newtonsoft.Json.Formatting.Indented);
    return Json(toJson, JsonRequestBehavior.AllowGet);
}
```
The trick was to convert the string back into a Json object! I was running into a good number of issues, with data either being wrong, or being gibberish for some reason. Using ```JsonConvert``` solved the issue I was having. I have a feeling this is easier than I made it out to be, but I'm not very good at this.

The next part was creating the ability to place bids. I tried many different, and difficult ways. When it finally dawned me to just scaffold ability to generate the code and then tweak it to work with my none sense code. Which was really just renaming it, to better highlight what exactly it's doing.

Next was to work on building the table to display the 10 latest searches, displaying the hour:minute:seconds format. First things first was setting the item name as an action link. This turned out to be fairly simple, ```@Html.ActionLink(bid.Item.ItemName, "Details", "Items", new { id = bid.Item.ItemID }, null)``` . Getting the date format was quite a challenge. I discovered it doesn't always have to be ```DateTime.Now``` but there's also ```DateTime.Today``` ! Ready about the format of using today instead of now, I was able to make sure it was grabbing the time in the right format, if it was placed that day.

```Html
@if (bid.Timestamp.Date == DateTime.Today)
{
    @(string.Format("{0:T}", bid.Timestamp))
}
else
{
    @Html.DisplayFor(current => bid.Timestamp)
}
```

The next step was installing OBS and try to record a video of it actually working. Although this might have to wait for assignment nine. As I moved on very quickly after I finally got it working, and published it before recording it working.

The quality of the video is very poor, I just could not get OBS working correctly. I used a Chrome extension to record the video and hopefully it actually displays correctly. Boy oh boy is this website ugly. I definitely need to work on my design skills over winter break!

[![work!](https://github.com/avisuano/CS460/blob/master/HW8/thumbnail.PNG)](https://www.useloom.com/share/a6b869b0b0604bf6b2b7b6821de5ac7c)

Oh and of course the E-R diagram for the database!

![finished](https://github.com/avisuano/CS460/blob/master/HW8/ERDigram.PNG)
