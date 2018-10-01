
# Homework One

The requirements for this assignment can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW1.html).

The repository of code can be found [here](https://github.com/avisuano/CS460/tree/master/HW1).

Finally, the actual site can be found [here](https://avisuano.github.io/CS460/HW1/main.html).

## Getting Started

To get started there was a good deal of downloading required. First Git Bash was installed, followed by going to GitHub and creating a repository. Finally I downloaded my preferred IDE, which is Atom. I also installed plugins such as the preview HTML and a few others. Most of the plugins just make life a little easier.

## After installations

The first thing to do was initialize the repository and set up some global configs
```bash
  cd /c/
  mkdir CS460
  cd cs460
  git init
  git config --global user.name "Anthony Visuano"
  git config --global email "schoolemail@wou.edu"
  git remote add origin https://github.com/avisuano/cs460
  git remote add backup https://avisuano15@bitbucket.org/avisuano15/cs460.git
  git touch README.md
  git add README.md
  git commit -m "Initialize the repo and push a file to both"
  git push origin master
  git push backup master
```

After checking both repositories to make sure they were initialized and that the README file was successfully pushed to both. Work than began on the assignment.

```bash
  mkdir HW1
  cd HW1
  touch index.html
  touch about.html
  touch contacts.html
  touch styles.css
  touch README.md
  git add .
  git commit -m "Getting started"
  git push origin master
  git push backup master
```

With the base files created and pushed, I began on the index page. Starting with a navbar set up with bootstrap and then adjusted a bit.

```html
<!-- Navigation -->
<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <a class="navbar-brand" href="#"></a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
  <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarNav">
    <ul class="navbar-nav">
      <li class="nav-item active">
      <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
      <a class="nav-link" href="about.html">Lists </a>
      </li>
      <li class="nav-item">
      <a class="nav-link" href="contacts.html">Contacts </a>
      </li>
    </ul>
  </div>
</nav>
```

I grabbed some random photos from Google image search and used a Latin text generator to fill in some text. After finishing up the main page, I moved on to the about page. I ended up making this page for lists, which were updated on the navbar, but I didn't rename the file. Partly because I forgot, but also because all the links were working and didn't want to risk breaking something.
I created two columns and two lists: a description list and an ordered list.

```html
<div class="row">
  <div class="column">
    <p>Some Latin phrases.
      <dl>
      <dt>Semper Fidelis</dt>
        <dd> -"Always Faithful"</dd>
      <dt>Carpe Diem</dt>
        <dd> -"Seize the day."</dd>
      <dt>Vivamus, Moriendum Est</dt>
        <dd>-"Let us live, since we must die."</dd>
      <dt>Alea Jacta Est</dt>
        <dd>-"The die is cast."</dd>
      </dl></p>
    </div>
  <div class="column">
    <p>
      Some of the most important Roman Cities.
      <ol type="i">
        <li>Rome</li>
        <li>Alexandria</li>
        <li>Antioch</li>
        <li>Carthage</li>
        <li>Ephesus</li>
      </ol>
    </p>
  </div>
</div>
```

When finished with the about (lists) page, I moved on to the contacts pages. This time I decided to use bootstrap again to create a generic table with hover highlighting. I then just filled in the rows and columns with fake names, numbers and email addresses.

```html
<table class="table table-hover table-#efefef">
  <thead>
    <tr>
      <th scope="col"></th>
      <th scope="col">First</th>
      <th scope="col">Last</th>
      <th scope="col">Phone</th>
      <th scope="col">Email</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">1</th>
      <td>John</td>
      <td>Doe</td>
      <td>503-555-1234</td>
      <td>johnd@example.com</td>
    </tr>
```

I then created a small styles.css page to make sure everything was uniform, and at least had a professional feel to the pages. Although I am not an artist or a designer, so I stuck with something simple and plain.

```css
.center {
    display: block;
    margin-left: auto;
    margin-right: auto;
}

.row {
    display: flex;
}

.column {
    margin-left: 25px;
    margin-right: 25px;
}

body {
    background-color: #efefef;
}

p {
  margin-left: 10px;
  margin-right: 10px;
}
```

After finishing up the pages I started work on this blog for homework one, and updated the links for the gateway blog of my work. I pushed everything to both repos and then began the testing of all the pages. I had to go back a few times to correct spellings and broken links. Fortunately, I was actually able to remember how most of this was supposed to go. I then made sure my GitHub pages were set up, and again checked that all the links were updated and working.
