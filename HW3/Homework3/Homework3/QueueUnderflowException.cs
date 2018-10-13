using System;

namespace Homework3
{
    /// <summary>
    /// Custem exception to make sure the queue can't do anthing funky
    /// </summary>
    public class QueueUnderflowExcpetion : SystemException
    {
        // The trick was to move base(), because this extends the base class
        public QueueUnderflowExcpetion() : base() { }
        public QueueUnderflowExcpetion(String message) : base(message) { }
    }
}
