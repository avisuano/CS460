using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Homework6.Models;

namespace Homework6.DAL
{
    public class WWIContext : DbContext
    {
        public WWIContext() : base("name=WideWorldImportersEntities") { }

        public virtual DbSet<WideWorldImportersEntitie> WideWorldImportersEntities { get; set; }
    }
}