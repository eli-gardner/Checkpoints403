using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using dbBlowOut.Models;

namespace dbBlowOut.DAL
{
    public class BlowOutContext : DbContext
    {
        public BlowOutContext() : base("BlowOutContext")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<instrument> Instruments { get; set; }
    }
}