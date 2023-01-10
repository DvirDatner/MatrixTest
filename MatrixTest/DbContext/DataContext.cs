using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MatrixTest
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Data Source=DESKTOP-U2ESN12;Initial Catalog=MatrixTestDB;Integrated Security=True")
        {

        }

        public virtual DbSet<Trainer> Trainers { get; set; }

        public virtual DbSet<Hero> Heroes { get; set; }
    }
}