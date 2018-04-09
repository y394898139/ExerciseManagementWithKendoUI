using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AimyCompetition.Models
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext() : base("name = MyConnection") {

        }

        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}