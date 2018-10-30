using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Homework5.DAL
{
    public class RequestContext : DbContext
    {
        public RequestContext() : base("name=TenantRequestContext") { }

        public virtual DbSet<RequestContext> Requests { get; set; }
    }
}