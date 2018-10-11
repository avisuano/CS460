using System;

/// <summary>
///
/// </summary>
class Main
{
    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}

/// <summary>
///
/// </summary>
/// <typeparam name="T"></typeparam>
class Node<T>
{
    public T data;
    public Node<T> next;

    public Node(T data, Node<T> next)
    {
        this.data = data;
        this.next = next;
    }
}

/// <summary>
///
/// </summary>
/// <typeparam name="T"></typeparam>
class LinkedQueue<T> : IQueueInterface<T>
{
    public Node<T> front;
    public Node<T> rear;

    public LinkedQueue()
    {
        front = null;
        rear = null;
    }

    public T push(T element)
    {
        if (element == null)
        {
            throw new NullPointerException();
        }

        if (isEmpty())
        {
            Node<T> tmp = new Node<T>(element, null);
            rear = front = tmp;
        }
        else
        {
            Node<T> tmp = new Node<T>(element, null);
            rear.next = tmp;
            rear = tmp;
        }

        return element;
    }

    public T pop()
    {
        T tmp = null;

        if (isEmpty())
        {
            throw new QueueUnderflowException("The queue is empty");
        }
        else if (front == rear)
        {
            tmp = front.data;
            front = front.next;
        }

        return tmp;
    }

    public bool isEmpty()
    {
        if (front == null && rear == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

/// <summary>
///
/// </summary>
/// <typeparam name="T"></typeparam>
class IQueueInterface<T>
{
    T push(T element);

    T pop() { throw new QueueUnderflowException("The stack was empty"); }

    bool isEmpty();
}
