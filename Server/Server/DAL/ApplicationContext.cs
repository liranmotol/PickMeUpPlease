using Server.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Server.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("AuthContext")
        { 
        }

        public DbSet<contacts> Contacts { get; set; }
        public DbSet<students> Students { get; set; }
        public DbSet<branches> Branches { get; set; }


    }
}