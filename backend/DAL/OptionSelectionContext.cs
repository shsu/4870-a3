using backend.Models;
using backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace backend.DAL
{
    public class OptionSelectionContext : DbContext
    {
        public OptionSelectionContext() : base() { }

        public DbSet<Choice> Choices { get; set; }

        public DbSet<Option> Options { get; set; }

        public DbSet<Term> Terms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}