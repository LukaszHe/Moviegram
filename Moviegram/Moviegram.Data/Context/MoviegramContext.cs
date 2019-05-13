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
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MoviegramContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
