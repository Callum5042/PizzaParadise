using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PizzaParadise.Entities.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EmailAddress { get; set; }

        private class UserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.ToTable("USER");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id)
                    .HasColumnName("USER_ID");
                builder.Property(x => x.FirstName)
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(x => x.LastName)
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
                builder.Property(x => x.EmailAddress)
                    .HasColumnName("EMAILADDRESS")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            }
        }
    }
}
