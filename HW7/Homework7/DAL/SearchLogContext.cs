namespace Homework7.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Homework7.Models;

    public partial class SearchLogContext : DbContext
    {
        public SearchLogContext() : base("name=SearchLogs") { }

        public virtual DbSet<SearchLog> SearchLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }
    }
}
