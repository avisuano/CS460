# Homework Three

The requirements for this assignment can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW3.html).

The repository of code can be found [here](https://github.com/avisuano/CS460/tree/master/HW3).


## Getting started

The first thing to do was to create a new branch to begin work.

```bash
  git checkout -b hw3
  mkdir HW3
  cd HW3
  touch index.md
```

Next, the Java code was downloaded, compiled and then tested.

![Java](https://avisuano.github.io/CS460/HW3/test1.PNG)


After that, Visual Studios was installed and a .gitignore file was added to the repository to prevent it from getting dominated with extra files that are generated with a solution is built with Visual Studio. Nothing worse than using git status and seeing the terminal get flooded with red text.

Then I began (slowly) turning the Java language into C# language. Most of it was pretty straight forward, as Java and C# are very similar. There were a couple areas that proved a little challenging. Node.java was the most simple. The C# was virtually the same, only added the namespace for easier management purposes. QueueInterface.java and QueueUnderflowException.java were also both pretty simple to knock out. QueueInterface only needed a name change, IQueueInterface and the methods used capitalized.

For QueueUnderflowException the trick was going from:
```Java
public class QueueUnderflowException extends RuntimeException
{
  public QueueUnderflowException(String message)
  {
    super(message);
  }
}
```

I found the easiest way was to do:
```cs

public class QueueUnderflowExcpetion : SystemException
{
    public QueueUnderflowExcpetion(String message) : base(message) { }
}
```
IQueueInterface was also fairly simple:
```cs
public interface IQueueInterface<T>
{
    T Push(T element);

    T Pop();

    bool IsEmpty();
}
```

Originally I had put IQueueInterface and QueueUnderflowException in the same file as LinkedQueue, but decided to follow conventional wisdom and create individual files for each class. Which was because of the struggle of getting LinkedQueue working. It should have been straight forward, but there are some differently used exceptions and syntax. I'm also not great at this.

For instance, the push (Push) method, Java prefers the: ```throw new NullPointerException();```. While C# preferred the ```throw new System.ArguementNullException();```. There was also the issue of nullables and parameters that are and are not allowed to be null. Such as this line in Java: ```T tmp = null;```, while C# wanted something more like this: ```T tmp = default;```.

Most of the Main.java was fairly straight forward, changing things like: ```system.out.println();``` or ```system.out.print();``` to: ```Console.Write();``` and ```Console.WriteLine();```. The largest issue was with the main method. Specifically, this section:

```Java
int maxLength = output.getLast().length();
for(String s : output)
{
    for(int i = 0; i < maxLength - s.length(); ++i)
    {
        System.out.print(" ");
    }
    System.out.println(s);
}
```
C# had a lot of issues with the syntax and exceptions and variables. I know that var is not wise to use, but I was at a loss and just happy that it was actually working.
```cs
int maxLength = output.Count;
foreach (var s in output)
{
    for (int i = 0; i < maxLength - s.Count(); i++)
    {
        Console.Write(" ");
    }
    Console.WriteLine(s);
}
```

Finally after what felt like hours, I was able to get it working. I did have issues with alignment and spacing for some reason.
![C#](https://avisuano.github.io/CS460/HW3/test2.PNG)
