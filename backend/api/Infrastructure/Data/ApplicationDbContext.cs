using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.API.Domain.Entities;

namespace SalesOrderManagement.API.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<SalesOrder> SalesOrders { get; set; }
    public DbSet<SalesOrderItem> SalesOrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>()
            .HasMany(c => c.SalesOrders)
            .WithOne(o => o.Client)
            .HasForeignKey(o => o.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SalesOrder>()
            .HasMany(o => o.SalesOrderItems)
            .WithOne(i => i.SalesOrder)
            .HasForeignKey(i => i.SalesOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Item>()
            .HasMany(i => i.SalesOrderItems)
            .WithOne(soi => soi.Item)
            .HasForeignKey(soi => soi.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Item>()
            .HasIndex(i => i.ItemCode)
            .IsUnique();

        modelBuilder.Entity<SalesOrder>()
            .HasIndex(o => o.OrderNumber)
            .IsUnique();
    }
}