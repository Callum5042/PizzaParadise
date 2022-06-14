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

            // Seed product categories
            var productCategoriesData = new List<ProductCategory>();
            productCategoriesData.Add(new ProductCategory("Pizza") { Id = 1 });

            modelBuilder.Entity<ProductCategory>().HasData(productCategoriesData);
        }

        public DbSet<Pizza> Pizzas => Set<Pizza>();

        public DbSet<User> Users => Set<User>();

        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();

        public DbSet<Product> Products => Set<Product>();
    }
}
