using Microsoft.EntityFrameworkCore;
using RouterFinder.Domain.Entities;
using RouterFinder.Infra.EntityConfig;

namespace RouterFinder.Infra.Context
{
    public class RouterFinderContext : DbContext
    {
        // DbSet<T> é uma propriedade do DbContext que representa uma tabela do banco de dados.
        public DbSet<Route> Routes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // set the database path
            optionsBuilder.UseSqlServer(@"Data Source=.;User ID=xxx; Password=xxx;Initial Catalog=RouterFinder");

            // set the options
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // set the entity configurations
            modelBuilder.ApplyConfiguration(new RouteConfiguration());
        }
    }
}
