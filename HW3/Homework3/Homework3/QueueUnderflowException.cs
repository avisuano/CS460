using System;

namespace Homework3
{
    /// <summary>
    /// 
    /// </summary>
    public class QueueUnderflowExcpetion : SystemException
    {
        public QueueUnderflowExcpetion() : base() { }

        public QueueUnderflowExcpetion(String message) : base(message) { }
    }
}
