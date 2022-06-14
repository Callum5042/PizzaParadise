using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PizzaParadise.Entities.Models
{
    public class ProductCategory
    {
        public ProductCategory(string name)
        {
            Name = name;
        }

        public int Id { get; protected set; }

        public string Name { get; protected set; }

        protected class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
        {
            public void Configure(EntityTypeBuilder<ProductCategory> builder)
            {
                builder.ToTable("PRODUCT_CATEGORIES");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id)
                    .HasColumnName("PRODUCT_CATEGORY_ID");
                builder.Property(x => x.Name)
                    .HasColumnName("NAME")
                    .IsUnicode(false)
                    .HasMaxLength(50);
            }
        }
    }
}
