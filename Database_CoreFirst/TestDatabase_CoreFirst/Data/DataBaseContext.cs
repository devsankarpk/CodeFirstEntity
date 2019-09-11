using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestDatabase_CoreFirst.Models;

namespace TestDatabase_CoreFirst.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DefaultConnection")
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

    }
}