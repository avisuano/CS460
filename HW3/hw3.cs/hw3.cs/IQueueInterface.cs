using System;

public interface IQueueInterface<T>
{
    T push(T element);

    T pop()  throw new QueueUnderflowException;

    bool isEmpty();
}
