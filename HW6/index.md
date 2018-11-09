# Homework Six

The requirements for this assignment can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW6_1819.html)

The repository can be found [here](https://github.com/avisuano/CS460/tree/master/HW6/).

This assignment turned out to be a doozy for me. It started as with the previous ones, ```git checkout -b hw6_main``` and work got started. The first task was to download the database backup and restore it. This is where to first issue arrived. This first step took entirely too long. I was hit with version issues, permission issues, and other technical issues. It turned out to be an easy fix.

There was another issue with getting LINQPad to work! Eventually I was forced to give up on LINQPad as time was starting to catch up with me. It became a trial by fire, as variable after variable, and lambda equation after lambda equation; I was able to figure out what to do! Eventually, I was finally able to get started on the project itself.

The first thing to here was to build the model classes. This was done with the handy, ADO.NET Entity Data Model builder, using the code first approach. That made the start very simple. After the models were finished, I added the DAL folder and moved the context class created by the data model into this folder.

Next I created a new folder inside the Models, called Required, to store a required model class to also aid with the searching of the database.

```cs
public class WWViewModel
{
    public Person GetPerson { get; set; }

    public Customer GetCustomer { get; set; }

    public List<InvoiceLine> GetInvoiceLine { get; set; }
}
```

Next I removed all the default action method and views, and cleaned up the navbar. After that was done, I created a couple empty action results and created the empty views, Customer and Details. The first is to search the database, which passes that result into the Details action result. First things first, I needed to figure out how to search the database. This was the first nut to crack. I just needed to return the database objects that contain the string that was submitted.

```cs
// Quick check to make sure something is actually passed
if (searchResults == null || searchResults == "")
{
    ViewBag.Customer = false;
    return View();
}
// The first doozy to crack.
else
{
    ViewBag.Customer = true;
    return View(db.People.Where(a => a.FullName.ToUpper().Contains(searchResults.ToUpper())).ToList());
}    
```

The real problem was tracing the lines to find all the required gross, profit and the 10 most profitable items. It was here I discovered the usage of ctrl-clicking to help trace through the logic. There were so many variables being passed, I decided to just use the alphabet. This was to aid in keeping track of how I was digging through the database for the information.

```cs
ViewBag.Found = true;
// Uses the required model to grab the customers ID and begin digging through the database
int GetCustomerID = vmd.GetPerson.Customers2.FirstOrDefault().CustomerID;
vmd.GetCustomer = db.Customers.Find(GetCustomerID);

// The real problem child of the assignment without LINQPad it was mostly trial and error
ViewBag.GrossSales = vmd.GetCustomer.Orders.SelectMany(b => b.Invoices).SelectMany(c => c.InvoiceLines).Sum(d => d.ExtendedPrice);
ViewBag.GrossProfit = vmd.GetCustomer.Orders.SelectMany(e => e.Invoices).SelectMany(f => f.InvoiceLines).Sum(g => g.LineProfit);
vmd.GetInvoiceLine = vmd.GetCustomer.Orders.SelectMany(h => h.Invoices).SelectMany(i => i.InvoiceLines).OrderByDescending(j => j.LineProfit).Take(10).ToList();
```

This would take the longest amount of time. Eventually I was able to work through it, but not without tremendous help from Dr. Google and others.

The Customer view turned out to be fairly straight forward. I used Razor to generate the form and text box. ``` @using (Html.BeginForm("Customer", "Home", FormMethod.Get)) ``` and then ``` @Html.TextBox("Search", "", new { @class = "form-control", placeholder = "Customer Search", required = "required" }) ```. The next step was to pass the results from the Action Result to browser.

```cs
<!-- This is what is returned after the search -->
if (ViewBag.Customer)
{
    <!-- If nothing was matched -->
    if (Model.Count() == 0)
    {
        <h2 style="color: crimson"> Sorry no customers found.</h2>
    }
    else
    {
        <div><h3>Customer:</h3></div><br />
        <!-- This is to pass what is returned if a customer is found -->
        foreach (var person in Model)
        {
            <div>
                <!-- This passes the searched name to the Details action method, with the ID -->
                <a class="text-info" href="Home/Details/@person.PersonID" role="button">@person.FullName (@person.PreferredName)</a>
            </div>
        }
    }
}
```

The details view turned out to be fairly similar to assignment 5. Leaflet was used to help with my poor design tastes. I just broke everything up into three sections. The personal information, the customer information, and the most profitable items.

This view turned out to be not too difficult.
```cs
<dt>@Html.DisplayNameFor(model => model.GetCustomer.CustomerName)</dt>
<dd>@Html.DisplayFor(model => model.GetCustomer.CustomerName)</dd>

<dt>@Html.DisplayNameFor(model => model.GetCustomer.PhoneNumber)</dt>
<dd>@Html.DisplayFor(model => model.GetCustomer.PhoneNumber)</dd>

<dt>@Html.DisplayNameFor(model => model.GetCustomer.FaxNumber)</dt>
<dd>@Html.DisplayFor(model => model.GetCustomer.FaxNumber)</dd>

<dt>@Html.DisplayNameFor(model => model.GetCustomer.WebsiteURL)</dt>
<dd>@Html.DisplayFor(model => model.GetCustomer.WebsiteURL)</dd>

<dt>@Html.DisplayNameFor(model => model.GetCustomer.ValidFrom)</dt>
<dd>@Html.DisplayFor(model => model.GetCustomer.ValidFrom)</dd>

@* For the time when photos are added to the database
<dt>@Html.DisplayNameFor(model => model.GetCustomer.Photo)</dt>
<dd>@Html.DisplayFor(model => model.GetCustomer.Photo)</dd>
*@
```

And for the top items...

```case
@foreach (var product in Model.GetInvoiceLine)
{
    <tbody>
        <tr>
            <td>@Html.DisplayFor(item => product.StockItemID)</td>
            <td>@Html.DisplayFor(item => product.Description)</td>
            <td>@string.Format("{0:C}",product.LineProfit)</td>
            <td>@Html.DisplayFor(item => product.Invoice.Person4.FullName)</td>
        </tr>
    </tbody>
}
```

After this everything went south. I wasn't paying close enough attention to my branches, and which machine I was working on. This lead in an incredible number of version issues, made worse by attempts to undo the damage. I attempted to checkout an earlier commit, save that to a new branch, and then merge that into the master, but then things spiraled out of control. Eventually I was forced to concede defeat and move on. Even small things such as; the namespace was no longer working, @Html was now broken, random lines of text were inserted into config files. I spent almost 10 hours trying to fix the mess. With time running out, I chose to move on to assignment seven. Less I fall even further behind.
