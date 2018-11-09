using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework6.Models.Required
{   
    /// <summary>
    /// Required model that is to also help aid in searching the database
    /// </summary>
    public class WWViewModel
    {
        public Person GetPerson { get; set; }

        public Customer GetCustomer { get; set; }

        public List<InvoiceLine> GetInvoiceLine { get; set; }
    }
}