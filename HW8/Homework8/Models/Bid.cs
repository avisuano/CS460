namespace Homework8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bid
    {
        public int BidID { get; set; }

        public int ItemID { get; set; }

        public int BuyerID { get; set; }

        public decimal Price { get; set; }

        // SQL and C# were clashing
        private DateTime Date = DateTime.Now;
        public DateTime Timestamp { get { return Date; } set { Date = value; } }

        public virtual Item Item { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}
