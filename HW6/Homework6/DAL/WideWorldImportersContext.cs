using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Homework6.Models;

namespace Homework6.DAL
{
    public class WideWorldImportersContext : DbContext
    {
        public WideWorldImportersContext() : base("name=WideWorldImportersEntities") { }

        public virtual DbSet<WideWorldImportersEntity> WideWorldImportersEntities { get; set; }
    }
}