namespace Homework8.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Homework8.Models;

    public partial class AuctionHouseContextDb : DbContext
    {
        public AuctionHouseContextDb()
            : base("name=AuctionHouseContextDb")
        {
        }

        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bid>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);
        }
    }
}
