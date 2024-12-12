using Microsoft.EntityFrameworkCore;
using ProAtividade.Domain.Entities;
using ProAtividade.Data.Mapping;

namespace ProAtividade.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapActivity());
        }

    }
}