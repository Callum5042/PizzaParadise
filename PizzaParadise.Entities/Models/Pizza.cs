using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PizzaParadise.Entities.Models
{
    public class Pizza
    {
        public Pizza(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public int Id { get; protected set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; }

        protected class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
        {
            public void Configure(EntityTypeBuilder<Pizza> builder)
            {
                builder.ToTable("PIZZAS");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id)
                    .HasColumnName("BOSS_ID");
                builder.Property(x => x.Name)
                    .HasColumnName("NAME")
                    .IsUnicode(false)
                    .HasMaxLength(50);
                builder.Property(x => x.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(255);
                builder.Property(x => x.Price)
                    .HasColumnName("PRICE")
                    .HasPrecision(19, 4);
                builder.Property(x => x.Active)
                    .HasColumnName("ACTIVE");
            }
        }
    }
}
