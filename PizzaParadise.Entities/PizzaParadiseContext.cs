using Microsoft.EntityFrameworkCore;
using PizzaParadise.Entities.Models;

namespace PizzaParadise.Entities
{
    public class PizzaParadiseContext : DbContext
    {
        public PizzaParadiseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Pizza> Pizzas => Set<Pizza>();
    }
}
