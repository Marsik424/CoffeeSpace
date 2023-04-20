﻿// <auto-generated />
using System;
using CoffeeSpace.OrderingApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoffeeSpace.OrderingApi.Persistence.Migrations.SagaDbContext
{
    [DbContext(typeof(OrderStateSagaDbContext))]
    partial class OrderStateSagaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CoffeeSpace.OrderingApi.Application.Messaging.Masstransit.Sagas.OrderStateInstance", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("char(36)");

                    b.Property<int>("CurrentState")
                        .HasColumnType("int");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("PaymentSuccess")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("StockValidationSuccess")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CorrelationId");

                    b.ToTable("OrderStateInstance");
                });
#pragma warning restore 612, 618
        }
    }
}
