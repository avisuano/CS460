namespace Homework3
{
    /// <summary>
    /// FIFO queue interface for a singly linked queue
    /// </summary>
    /// <typeparam name="T">The data being manipulated</typeparam>
    public interface IQueueInterface<T>
    {
        T Push(T element);

        T Pop();

        bool IsEmpty();
    }
}
