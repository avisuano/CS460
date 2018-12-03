namespace BlankApp.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using BlankApp.Models;

    public partial class SimpleDbContext : DbContext
    {
        public SimpleDbContext()
            : base("name=SimpleDbContext")
        {
        }

        public virtual DbSet<SimpleTable> SimpleTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
