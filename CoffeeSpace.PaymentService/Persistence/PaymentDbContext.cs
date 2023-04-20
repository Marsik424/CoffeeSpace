using System.Reflection;
using CoffeeSpace.PaymentService.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoffeeSpace.PaymentService.Persistence;

internal sealed class PaymentDbContext : DbContext
{
    public required DbSet<PaymentHistory> PaymentHistories { get; init; }
    
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}