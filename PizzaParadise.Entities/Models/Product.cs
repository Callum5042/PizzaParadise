using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PizzaParadise.Entities.Models
{
    public class Product
    {
        public Product(string name, decimal price, ProductCategory productCategory)
        {
            Name = name;
            Price = price;
            ProductCategory = productCategory;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Product() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public ProductCategory ProductCategory { get; protected set; }

        protected class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                builder.ToTable("PRODUCTS");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id)
                    .HasColumnName("PRODUCT_ID");
                builder.Property(x => x.Name)
                    .HasColumnName("NAME")
                    .IsUnicode(false)
                    .HasMaxLength(50);
                builder.Property(x => x.Description)
                    .HasColumnName("DESCRIPTION")
                    .IsUnicode(false)
                    .HasMaxLength(50);
                builder.Property(x => x.Price)
                    .HasColumnName("PRICE")
                    .HasPrecision(19, 4);
                builder.HasOne(x => x.ProductCategory)
                    .WithMany(x => x.Products);
            }
        }
    }
}
