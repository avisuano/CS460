using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework5.Models;

namespace Homework5.DAL
{
    /// <summary>
    /// Context to interact with the database
    /// </summary>
    public class RequestContext : DbContext
    {
        public RequestContext() : base("name=RequestContext") { }
        public virtual DbSet<Request> Requests { get; set; }
    }
}