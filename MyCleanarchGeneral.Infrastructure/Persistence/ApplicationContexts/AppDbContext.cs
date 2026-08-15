using Microsoft.EntityFrameworkCore;
using MyCleanarchGeneral.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MyCleanarchGeneral.Infrastructure.Persistence.ApplicationContexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CustomerName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.TotalAmount).HasPrecision(18, 2);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime2(0)");
        });
    }



}
