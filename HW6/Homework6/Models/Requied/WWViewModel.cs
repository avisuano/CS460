using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Homework6.Models.Required
{   
    /// <summary>
    /// 
    /// </summary>
    public class WWViewModel
    {
        public Person GetPerson { get; set; }

        public Customer GetCustomer { get; set; }

        public List<InvoiceLine> GetInvoiceLine { get; set; }
    }
}