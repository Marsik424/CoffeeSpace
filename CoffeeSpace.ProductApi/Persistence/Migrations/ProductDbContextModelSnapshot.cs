﻿// <auto-generated />
using CoffeeSpace.ProductApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoffeeSpace.ProductApi.Persistence.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CoffeeSpace.Domain.Products.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("character varying(200)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("bytea");

                    b.Property<int>("Quantity")
                        .IsUnicode(false)
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("character varying(64)");

                    b.Property<float>("UnitPrice")
                        .HasPrecision(2)
                        .IsUnicode(false)
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Products", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
