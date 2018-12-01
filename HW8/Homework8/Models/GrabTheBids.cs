using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework8.Models
{
    /// <summary>
    /// Model class to grab from the Bid and Buyer model classes
    /// </summary>
    public class GrabTheBids
    {
        public string BuyerName { get; set; }

        public decimal Price { get; set; }
    }
}