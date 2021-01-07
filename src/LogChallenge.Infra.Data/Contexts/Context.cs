using LogChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Infra.Data.Contexts
{
    class Context : DbContext
    {
        public DbSet<Log> Calculadora { get; set; }
        public IDbContextTransaction Transaction { get; private set; }

        public Context(DbContextOptions<Context> options): base(options)      
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new LogMap());
        }
    }
}
