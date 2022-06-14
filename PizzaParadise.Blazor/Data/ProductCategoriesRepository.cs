using Mapster;
using Microsoft.EntityFrameworkCore;
using PizzaParadise.Entities;

namespace PizzaParadise.Blazor.Data
{
    public class ProductCategoryModel
    {
        public int? Id { get; set; }

        public string? Name { get; set; }
    }

    public class ProductCategoriesRepository
    {
        private readonly IDbContextFactory<PizzaParadiseContext> _contextFactory;

        public ProductCategoriesRepository(IDbContextFactory<PizzaParadiseContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async ValueTask<IList<ProductCategoryModel>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            var list = await context.ProductCategories
                .ProjectToType<ProductCategoryModel>()
                .ToListAsync();

            return list;
        }
    }
}
