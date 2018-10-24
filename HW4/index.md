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

The first step was to was to get the view set up. I started by putting everything in a div class to split the miles input section and the unit selector into columns. Getting the input box type to "number" and the step="any" allowed. The view page was pretty simple and quick to get set up.

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
