using Microsoft.EntityFrameworkCore;
using PizzaParadise.Entities;
using PizzaParadise.Entities.Models;

namespace PizzaParadise.Blazor.Data
{
    public class ProductCreateActionModel
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Price { get; set; }

        public int? ProductCategoryId { get; set; }
    }

    public class ProductCreateAction
    {
        private readonly IDbContextFactory<PizzaParadiseContext> _contextFactory;

        public ProductCreateAction(IDbContextFactory<PizzaParadiseContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async ValueTask ExecuteAsync(ProductCreateActionModel model)
        {
            using var context = _contextFactory.CreateDbContext();
            
            var category = await context.ProductCategories.FindAsync(model.ProductCategoryId);
            context.Products.Add(new Product(model.Name, decimal.Parse(model.Price), category)
            {
                Description = model.Description
            });

            await context.SaveChangesAsync();
        }
    }
}
