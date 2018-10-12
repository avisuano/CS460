using System;


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
    public interface IQueueInterface<T>
    {
        T push(T element);

        T pop();

        bool isEmpty();
    }

    /// <summary>
    /// 
    /// </summary>
    public class QueueUnderflowExcpetion : SystemException
    {
        public QueueUnderflowExcpetion()
        {
        }

        public QueueUnderflowExcpetion(String message) : base(message)
        {
        }
    }
}
