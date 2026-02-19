using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeStore.DAL.Configrations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Quantity)
                .HasColumnType("decimal(18,3)")
                .IsRequired();

            builder.Property(s => s.MinimumLevel)
                .HasColumnType("decimal(18,3)")
                .HasDefaultValue(0);

            builder.Property(s => s.LastUpdated)
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(s => s.Product)
                .WithMany(p => p.Stocks)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Branch)
                .WithMany(b => b.Stocks)
                .HasForeignKey(s => s.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(s => new { s.ProductId, s.BranchId })
                .IsUnique(); // One stock record per product per branch

            builder.HasIndex(s => s.BranchId);
        }
    }
}
