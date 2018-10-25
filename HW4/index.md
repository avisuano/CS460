# Homework Four

The requirements for this assignment can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW4_1819.html).

The repository of code can be found [here](https://github.com/avisuano/CS460/tree/master/HW4).

First things first. I created an empty project in Visual Studio, and pushed that to the repository. After that, a new branch was created and work began on Homework Four.

```git
git checkout -b hw4_main
```
After some initial work on the desktop, I decided to hone my Git skills and move to my laptop.

```git
git fetch origin hw4_main
git pull origin hw4_main
git checkout hw4_main
```

### Part One -- Mile Converter

The first step was to was to get the view set up. I started by putting everything in a div class to split the miles input section and the unit selector into columns. Getting the input box type to "number" and the ```step="any"``` allowed. The view page was pretty simple and quick to get set up.

```html
<!-- Miles input text field -->
<div class="column1">
    <label for="miles">Enter miles: </label>
    <input type="number" step="any" name="inputmiles" value="miles" required />
</div>

<!-- Radio buttons to select metric unit -->
<div class="column1">
    <h5>Select unit: </h5>
    <label for="mm"><input type="radio" name="units" value="mm" /> Millimeters </label><br />
    <label for="cm"><input type="radio" name="units" value="cm" /> Centimeters </label><br />
    <label for="m"><input type="radio" name="units" value="m" /> Meters </label><br />
    <label for="km"><input type="radio" name="units" value="km" /> Kilometers </label><br />
    <input type="submit" value="CONVERT" />
    <br />
</div>
```

The @ViewBag was put AFTER the form, as inside the form was creating all sorts of issues.
```html
</form>
<!-- Converstion results go here -->
@if (ViewBag.ConversionResult){
    <h3 style="color:crimson">@ViewBag.Results</h3>
}
</div>
```

Next was to work on the controller. This was a bit of a struggle. I had a lot of issues making sure everything was in the correct order, and initialized correctly. It was also important to ```ViewBag.ConversionResult = false;```, this made sure to clear the results header when the page was loaded. I also had a convoluted process of initialize the variables, assigning the query string to the variables and then converting the variables. A much simpler way, was to just do it all at once.

```cs
double inputmiles = Convert.ToDouble(Request.QueryString["inputmiles"]);
string units = Request.QueryString["units"];
```

One of the most biggest issues was with selecting the correct metric unit parameter. I initially was using if and else if statements, but was having a number of problems. Lots of code unreachable, not actually grabbing the specific metric unit. After many hours of browsing stack overflow, and scouring Dr. Google's knowledge, I decided to try the switch case method. This was far simpler to understand, and fixed most of the problems. Although, I did forget the default case, which lead to a great deal of hand-wringing that should have been avoided. When I made the decision to go with a switch case, I also realized I was wasting my time trying to convert the units parameter. I just needed to check which parameter (radio button) was selected.

```cs
switch (units)
{
    case "mm":
        conversion = inputmiles * 1609344;
        ViewBag.ConversionResult = true;
        break;
    case "cm":
        conversion = inputmiles * 160934.4;
        ViewBag.ConversionResult = true;
        break;
    case "m":
        conversion = inputmiles * 1609.344;
        ViewBag.ConversionResult = true;
        break;
    case "km":
        conversion = inputmiles * 1.609344;
        ViewBag.ConversionResult = true;
        break;
    // Important to have this one... fixes a lot of errors
    default:
        conversion = -1;
        break;
}
```
The final step was to create a ViewBag message to pass to the view page after the miles where converted to metric.

```cs
string message = inputmiles + " miles converts to: " + conversion + units;
ViewBag.Results = message;
```

Finally, after what took entirely too long, it was working!

![It's alive!](https://avisuano.github.io/CS460/HW4/MileConverterWorking.PNG)

### Part Two -- Color Mixer

This part was quite a doozy. I spent many hours reading, and re-reading the [documentation](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color?view=netframework-4.7.2) from Microsoft. It was pretty complex for one that is not very good at coding. The first step was creating a new branch to get started. I had to merge the master into hw4_color in order to fix some conflicts that were happening. After the merge, work began.

```git
git checkout -b hw4_color
git merge master
```

Using html helpers for part two was fairly strait forward. The biggest issue was getting the pattern matching down. The next area was making sure the spacing was correct for when the colors would be pushed to the view.

```cs
@using (Html.BeginForm("Colors", "Home", FormMethod.Post))

<div>
    @Html.Label("firstcolor", "First Color ")<br />
    @Html.TextBox("FirstColor", null, htmlAttributes: new { type = "text", pattern = "#[0-9a-fA-F]{3,6}", required = "required" })
</div>
```
This next part took a little bit longer, but that was mostly just getting the positions and sizing down.

```cs
@if (ViewBag.ColorResult)
{
    <div class="row">
        <div class="col-sm-7" style="@ViewBag.Color1"></div>
        <div class="col-sm-7" style="width:75px; height: 75px;"><h1> + </h1></div>
        <div class="col-sm-7" style="@ViewBag.Color2"></div>
        <div class="col-sm-7" style="width:75px; height: 75px;"><h1> = </h1></div>
        <div class="col-sm-7" style="@ViewBag.MixedColors"></div>
   </div>
}
```

The real struggle was with the controller. The first view was the easy part.

```cs
[HttpGet]
public ActionResult Colors()
{       
    ViewBag.ColorResult = false;
    return View();
}

[HttpPost]
[ActionName("Colors")]
public ActionResult Colors(string FirstColor, string SecondColor)
```

Creating the action name, meant that I would need to make thins any more complicated than they already were. Grabbing the user input was also fairly straight forward. It was very similar to the mile converter, just using ```Request.Form();``` instead of ```Request.QueryString```. The next step was to "translate" those strings into ARBG values that could be check and combined.

```cs
// Grab the hexadecimal values from the user
FirstColor = Request.Form["FirstColor"];
SecondColor = Request.Form["SecondColor"];

// This converts the hexadecimal values into their alpha, red, blue, and green values
Color color1 = ColorTranslator.FromHtml(FirstColor);
Color color2 = ColorTranslator.FromHtml(SecondColor);

// Initialize the values needed for error checking
int color_alpha, color_red, color_blue, color_green;
```

I first tried to just slam the values together and then push those values to the user. However, that results in many, many problems when values go above 255. This portion easily took the longest amount of time to get working correctly. That was mostly because of my inability to read the documentation. Finally, I got it figured out. You need to check each value (ARBG) and make sure they are at or below 255. When using the color struct, and translating these FromHtml, made things incredibly simple once I understood what the problem was. Using the color struct it meant I could use .A, .R, .B, and .G with both colors to check each value individually.

```cs
// This is needed to check for values above 255 -- lots of errors if these aren't checked
// Started with alpha...
if (color1.A + color2.A >= 255)
{
    color_alpha = 255;
}
else
{
    color_alpha = color1.A + color2.A;
}
// Next the red values are checked
if (color1.R + color2.R >= 255)
{
    color_red = 255;
}
else
{
    color_red = color1.R + color2.R;
}
// Next the blue values are checked
if (color1.B + color2.B >= 255)
{
    color_blue = 255;
}
else
{
    color_blue = color1.B + color2.B;
}
// Finally the green values are checked
if (color1.G + color2.G >= 255)
{
    color_green = 255;
}
else
{
    color_green = color1.G + color2.G;
}
```

Finally, I just need to combine everything and set up the ViewBags to push the first color, the second color, and the mixed colors to the view.

```cs
string MixedColors = ColorTranslator.ToHtml(Color.FromArgb(color_alpha, color_red, color_blue, color_green));

if (FirstColor != null && SecondColor != null)
{
    ViewBag.ColorResult = true;
    ViewBag.Color1 = "width:75px; height:75px; border: 1px soild #000; background:" + FirstColor;
    ViewBag.Color2 = "width:75px; height:75px; border: 1px soild #000; background:" + SecondColor;
    ViewBag.MixedColors = "width:75px; height:75px; border: 1px soild #000; background:" + MixedColors;
}
```

After what took, entirely too long, it was actually working!

![It's also alive!](https://avisuano.github.io/CS460/HW4/ColorCreatorWorking.PNG)
