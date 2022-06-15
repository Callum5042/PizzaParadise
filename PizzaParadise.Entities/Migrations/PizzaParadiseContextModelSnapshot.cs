﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaParadise.Entities;

#nullable disable

namespace PizzaParadise.Entities.Migrations
{
    [DbContext(typeof(PizzaParadiseContext))]
    partial class PizzaParadiseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PizzaParadise.Entities.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PRODUCT_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME");

                    b.Property<decimal>("Price")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal(19,4)")
                        .HasColumnName("PRICE");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("PRODUCTS", (string)null);
                });

            modelBuilder.Entity("PizzaParadise.Entities.Models.ProductCategory", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PRODUCT_CATEGORY_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("PRODUCT_CATEGORIES", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Starters"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sides"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Drinks"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Desserts"
                        });
                });

            modelBuilder.Entity("PizzaParadise.Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("EMAILADDRESS");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("FIRSTNAME");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("LASTNAME");

                    b.HasKey("Id");

                    b.ToTable("USER", (string)null);
                });

            modelBuilder.Entity("PizzaParadise.Entities.Models.Product", b =>
                {
                    b.HasOne("PizzaParadise.Entities.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("PizzaParadise.Entities.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}