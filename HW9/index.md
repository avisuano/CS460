# Homework Nine

The requirements for this assignment can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW9_1819.html)

The repository can be found [here](https://github.com/avisuano/CS460/tree/master/HW9/).

---

I created a new blank project, as I got so excited after getting homework 8 not only finished, but working, that I published it to Azure before grabbing some screen shots. Just a generic database with one table and an up/down script to push. The table is just a table with ID, FirstName, and LastName. The only real contents are the index view with a table of names, followed by a way to add names.


The first step is to create a new resource group, or just create a new SQL database, which allows for the creation of a new resource group.
![Azure](https://avisuano.github.io/CS460/HW9/hw9.1.PNG)

Click the add button
![Azure](https://avisuano.github.io/CS460/HW9/hw9.2.PNG)

This is where you can create a new resource group.
![Azure](https://avisuano.github.io/CS460/HW9/hw9.3.PNG)

![Azure](https://avisuano.github.io/CS460/HW9/hw9.4.PNG)

Now you need to connect to a server, this also allows for the creation of a new server while setting up the database.
![Azure](https://avisuano.github.io/CS460/HW9/hw9.5.PNG)

Next step is to set up a few things with the database
![Azure](https://avisuano.github.io/CS460/HW9/hw9.6.PNG)

Need to set the connection string and make sure there's a firewall exemption (though this only needs to be done one)
![Azure](https://avisuano.github.io/CS460/HW9/hw9.7.PNG)

Here you just need to replace your username/password with your server username and password (no curly brackets).
![Azure](https://avisuano.github.io/CS460/HW9/hw9.8.PNG)

Closing in on the end. Next step is to set up the a new web app.
![Azure](https://avisuano.github.io/CS460/HW9/hw9.11.PNG)

![Azure](https://avisuano.github.io/CS460/HW9/hw9.12.PNG)

Finally we need to set up the connection string for the web app its self. Need to make sure the name of the string is the name of the database. Lots of problems and failed loadings when it is not.
![Azure](https://avisuano.github.io/CS460/HW9/hw9.13.PNG)

From here, the next best step is to connect the up and down script and run some connection tests.
![Azure](https://avisuano.github.io/CS460/HW9/hw9.14.PNG)

![Azure](https://avisuano.github.io/CS460/HW9/hw9.15.PNG)

![Azure](https://avisuano.github.io/CS460/HW9/hw9.16.PNG)

When creating a new publish, just a few options like selecting the resource group, drop down menu to select the sql database and then click publish. From here it pushes the build!
