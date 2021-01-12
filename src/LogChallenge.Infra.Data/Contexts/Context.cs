using LogChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogChallenge.Infra.Data.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Log> Log { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=password;");
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new LogMap());
        }
    }
}
