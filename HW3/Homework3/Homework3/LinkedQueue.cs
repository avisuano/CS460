namespace Homework3
{
    /// <summary>
    /// 
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public T Push(T element)
        {
            if (element == null)
            {
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

        public T Pop()
        {
            T tmp = default;

            if (IsEmpty())
            {
                throw new QueueUnderflowExcpetion("The queue is empty");
            }

            else if (front == rear)
            {
                tmp = front.data;
                front = null;
                rear = null;
            }

            else
            {
                tmp = front.data;
                front = front.next;
            }

            return tmp;
        }

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