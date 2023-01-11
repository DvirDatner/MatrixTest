using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MatrixTest
{
    public class DataContext : DbContext
    {
        private static readonly string ConnectionString = "Data Source=DESKTOP-U2ESN12;Initial Catalog=MatrixTestDB;Integrated Security=True";

        public DataContext() : base(ConnectionString)
        {

        }

        public virtual DbSet<Trainer> Trainers { get; set; }

        public virtual DbSet<Hero> Heroes { get; set; }
    }
}