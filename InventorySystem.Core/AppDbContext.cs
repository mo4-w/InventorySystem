using InventorySystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Core;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // الكيانات الأساسية
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RestockHeader> RestockHeaders { get; set; }
    public DbSet<RestockDetail> RestockDetails { get; set; }
    public DbSet<Expense> Expenses { get; set; }

    // ➕ الجداول التي تسببت في الأخطاء حسب الصورة
    public DbSet<Sale> Sales { get; set; }                  // لحل مشكلة SalesController
    public DbSet<MenuItem> MenuItems { get; set; }          // لحل مشكلة DbInitializer و MenusController
    public DbSet<InventoryAudit> InventoryAudits { get; set; } // لحل مشكلة InventoryAudits

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // توحيد أسماء الجداول
        modelBuilder.Entity<RestockHeader>().ToTable("RestockHeaders");
        modelBuilder.Entity<RestockDetail>().ToTable("RestockDetails");
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<Expense>().ToTable("Expenses");
        modelBuilder.Entity<User>().ToTable("Users");

        // تعيين أسماء الجداول المضافة
        modelBuilder.Entity<Sale>().ToTable("Sales");
        modelBuilder.Entity<MenuItem>().ToTable("MenuItems");
        modelBuilder.Entity<InventoryAudit>().ToTable("InventoryAudits");

        // العلاقات
        modelBuilder.Entity<RestockDetail>()
            .HasOne(d => d.RestockHeader)
            .WithMany(h => h.Details)
            .HasForeignKey(d => d.RestockHeaderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RestockDetail>()
            .HasOne(d => d.Product)
            .WithMany()
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}