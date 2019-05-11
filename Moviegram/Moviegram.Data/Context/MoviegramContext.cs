using Moviegram.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Moviegram.Data.Context
{
     public class MoviegramContext : DbContext
     {
        public MoviegramContext() : base("DummyDB")
        { 
        }

        public MoviegramContext(string connectionString) : base(connectionString)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
     }
}
