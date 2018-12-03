# Homework Two

The requirements for this assignment can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW2.html).

The repository of code can be found [here](https://github.com/avisuano/CS460/tree/master/HW2).

Finally, the actual site can be found [here](https://avisuano.github.io/CS460/HW2/main.html).

---

This proved to be quite the dozy, that ultimately failed to work. I decided to cut my losses and move on before I fell too far behind.

The main goal was to create a simple (VERY SIMPLE) online pizza order form. It's also quite ugly, and I will need to spend down time this winter working on my design skills. The bulk of the page was fairly straight forward with div's and classes to try and keep everything in order.

```html
<div id="box">
  <div class="sizes">
    <h4 id="space">Size</h4>
    <input type="radio" name="size" value="Large"> Large <br>
    <input type="radio" name="size" value="Medium"> Medium <br>
    <input type="radio" name="size" value="Small"> Small <br>
  </div>
</div>
<div id="box">
  <div class="sauces">
    <h4 id="space">Sauce</h4>
    <input type="radio" name="sauce" value="Marinara"> Marinara <br>
    <input type="radio" name="sauce" value="Garlic"> Garlic <br>
    <input type="radio" name="sauce" value="Spicy"> Spicy <br>
  </div>
</div>
<div id="box">
    <h4 id="space">Toppings</h4>
    <div class="meats">
      <h6 id="space">Meat</h6>
      <input type="checkbox" name="meat" value="Pepperoni"> Pepperoni <br>
      <input type="checkbox" name="meat" value="Bacon"> Bacon <br>
      <input type="checkbox" name="meat" value="Sausage"> Sausage <br>
    </div>
    <div class="veggies">
      <h6 id="space">Veggies</h6>
      <input type="checkbox" name="veg" value="Olives"> Olives <br>
      <input type="checkbox" name="veg" value="Mushrooms"> Mushrooms <br>
      <input type="checkbox" name="veg" value="Green Peppers"> Green Peppers <br>
  </div>
</div>
```

I also used some css to shape the boxes and add some "flavor" to the page.

```css
.column1 {
  margin: 10px;
  padding: 10px;
  float: right;
}
.row {
  margin-left: 10px;
  border: solid;
  border-width: 1px;
  border-radius: 15px;
  width: 250px;
}
```

The real struggle, which ultimately failed was the attempt to set up Javascript and JQuery. The first step was to attempt to grab all the radio and checkboxes on the document.
```js
var size = document.querySelector('input[name="size"]:checked').value;
var sauce = document.querySelector('input[name="sauce"]:checked').value;
var meat = document.getElementsByName("meat");
var veg = document.getElementsByName("veg")
```

I used radio buttons for the size and sauce selector, which was to make things even more simple.
```js
var sizePrice = 0;
if (size === "Large") { sizePrice = 13; }
if (size === "Medium") { sizePrice = 10; }
if (size === "Small") { sizePrice = 9;}

var saucePrice = 0;
if (sauce === "Marinara") { saucePrice = 0; }
if (sauce === "Garlic") { saucePrice = 1; }
if (sauce === "Spicy") { saucePrice = 1;}
```

The real struggle began with trying to grab the meat and veggie choices. Both methods are virtually the same.
```js
// check the checkboxes
for (var i =0; i < meat.length; i++)
{
  if(meat[i].checked)
    {
       meatSelect.push(meat[i].value);
    };
};
// Start the process to find the meat price...
if(meatSelect.length === 0) { meatChoice = "No meat selected."; }
if(meatSelect.length === 1) { meatChoice = meatSelect[0]; }
else if (meatSelect > 1)
{
      for (i = 0; i < meatSelect.length; i++)
      {
              meatChoice += meatSelect[i];
              if(i < meatSelect.length - 1)
              {
                  meatChoice += ", ";
              };
      };
};
meatPrice = meatSelect.length * 1.5;
```

The final step was to push the results to the table.
```js
$('#size').html(size+" Pizza");
$('#sizePrice').html(" $"+sizePrice+".00");
$('#sauce').html(suace + " Sauce");
$('#saucePrice').html("+" +saucePrice+".00");
$('#meat').html(meatChoice);
$('#meatPrice').html("+" +meatPrice+".00");
$('#veg').html(vegChoice);
$('#vegPrice').html("+" +vegPrice+".00");
$('#total').html(" $"+totalPrice+".00");
```

There is a couple of small things that aren't correct. After several days and many hours, I wasn't able to figure it out in a reasonable time. At this point it's best to cut my losses, and move forward. This term is ending quickly, and I can't afford to fall behind.
