using Microsoft.EntityFrameworkCore;
using PizzaParadise.Entities.Models;

namespace PizzaParadise.Entities
{
    public class PizzaParadiseContext : DbContext
    {
        public PizzaParadiseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PizzaParadiseContext).Assembly);
        }

        public DbSet<Pizza> Pizzas => Set<Pizza>();

        public DbSet<User> Users => Set<User>();

        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
    }
}
