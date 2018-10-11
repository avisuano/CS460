using System;


namespace hw3.cs
{
    public interface IQueueInterface<T>
    {
        T Push(T element);

        T Pop() throw new QueueUnderflowException;

    bool IsEmpty();
    }
}
