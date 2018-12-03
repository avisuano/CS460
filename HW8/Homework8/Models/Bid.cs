namespace Homework8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bid
    {
        [Display(Name = "Bid Id:")]
        public int BidID { get; set; }

        [Display(Name = "Item Id:")]
        public int ItemID { get; set; }

        [Display(Name = "Buyer Id:")]
        public int BuyerID { get; set; }

        [Display(Name = "Current price:")]
        public decimal Price { get; set; }

        // SQL and C# were clashing
        private DateTime Date = DateTime.Now;
        [Display(Name = "Most recent:")]
        public DateTime Timestamp { get { return Date; } set { Date = value; } }

        public virtual Item Item { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}
