﻿namespace Homework3
{
    /// <summary>
    /// Singly linked node class
    /// </summary>
    /// <typeparam name="T">The data being stored (numbers)</typeparam>
    public class Node<T>
    {
        public T data;
        public Node<T> next;

        /// Basic Constructor for the Node class
        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
    }
}