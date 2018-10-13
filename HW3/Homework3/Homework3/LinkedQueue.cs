namespace Homework3
{
    /// <summary>
    /// This is a singly Linked FIFO Queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedQueue<T> : IQueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;

        public LinkedQueue()
        {
            front = null;
            rear = null;
        }

        // Pushes a value into the queue
        public T Push(T element)
        {
            if (element == null)
            {
                // C#'s version of the NullPointerException...?
                throw new System.ArgumentNullException();
            }

            if (IsEmpty())
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

        // Start popping those values out of the queue
        public T Pop()
        {
            // Problem area since Java can just use T tmp = null;
            T tmp = default;

            if (IsEmpty())
            {
                throw new QueueUnderflowExcpetion("The queue is empty");
            }

            // If one item is in the queue
            else if (front == rear)
            {
                tmp = front.data;
                front = null;
                rear = null;
            }

            // This would be the general case
            else
            {
                tmp = front.data;
                front = front.next;
            }

            return tmp;
        }

        // Simple test to make sure the queue has something in it
        public bool IsEmpty()
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
}