# Homework Seven

The requirements for this assignment can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW7_1819.html)

The repository can be found [here](https://github.com/avisuano/CS460/tree/master/HW7/).

---

The problems that ended homework six followed me to homework seven. After another round of intense Googling, it turned out to be a simple fix. Just needed to clear out some files that most likely got corrupted when the drama was underway with homework six. When everything was working correctly, a new branch ```git checkout -b hw7_main``` was created, and work began.

After several days of not being able to figure out what was wrong. I realized I had failed to add a new controller, a proper web route and a few other things. At this point the project had become unwieldy, and so I decided to start over and do things... slower.

First step was to set up a file outside the repository that would store the API key, and then I would link that through the web config file. I also created the database and up/down scripts.

```cs
<appSettings file="..\..\nothingtoseehere.config">
```

After that was finished I added a new route.
```cs
routes.MapRoute
(
    name: "SearchGiphy",
    url: "{controller}/{action}/{search}",
    defaults: new 
        { 
        controller = "Request", 
        action = "SearchGiphy",
        search = UrlParameter.Optional 
        }
);
```

When that was finished I created a very simple view, as again, my design and layout skills are in dire need of improvement. 
```html
<div class="text-center">
    <h2>Internet Language Translator</h2><br />
    <div class="col-lg-10">
        <form action="/" method="get">
            <input class="form-control" id="translate" placeholder="Translate" type="text" oninput="syncText('translate','destination')">
            <button type="submit" id="trans" value="Submit">Submit</button>
            <button type="reset" value="Clear" onclick="window.location.reload()">Clear</button>
            <br />

            <div id="tippitytype">

            </div><br /><br />

            <div id="searches">

            </div>
        </form>
    </div>
</div><br />

@section scripts
{
    <script type="text/javascript" src="~/Scripts/translate.js"></script>
}
```

From there I decided to tackle the search controller. Here was the first major struggle. It only contains two methods. One that is supposed to search Giphy with the words from the dictionary and then log those searches into the database. 

```cs
public JsonResult SearchGiphy(string search)
{
    LogSearch(search);

    string getKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];
    string qurl = "http://api.giphy.com/vq/stickers/translate?api_key=" + getKey + "&s=" + search;

    WebRequest searchRequest = WebRequest.Create(qurl);
    HttpWebResponse searchResponse = (HttpWebResponse)searchRequest.GetResponse();
    Stream dataStream = searchRequest.GetResponse().GetResponseStream();
    StreamReader reader = new StreamReader(dataStream);
    
    string convertData = new StreamReader(dataStream).ReadToEnd();

    reader.Close();
    searchResponse.Close();
    dataStream.Close();

    var dataSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    var results = dataSerializer.DeserializeObject(convertData);

    return Json(results, JsonRequestBehavior.AllowGet);
}

private void LogSearch(string search)
{
	SearchLog temp = new SearchLog
        {
        	Search = search,
            SearchIP = Request.UserHostAddress,
            SearchB = Request.UserAgent,
            TimeStamp = DateTime.Now
        };
        searchLog.SearchLogs.Add(temp);
        searchLog.SaveChanges();
}
```

From here the rest was trying to get the scripts working correctly. I created a simple script at first to just add what the user was typing to the DOM as it was being typed. Fairly simple and straight forward. 

```js
$("#translate").keyup(function (event) 
{
    var txt = $(this).val();
    $("#tippitytype").text(txt);
});
```

After that I created a very simply dictionary. I needed to make sure to use

However, after heavy testing, something is going wrong. I'll attempt to troubleshoot further, but at this point I'm again running low on time and really need to get started on the next assignment. The Javascript/jQuery is clearly wrong, and I've been at it too long to see the problem staring me in the face. 