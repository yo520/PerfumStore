using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeStore.DAL.Configrations
{
    public class StockMovementConfiguration
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.ToTable("StockMovements");

            builder.HasKey(sm => sm.Id);

            builder.Property(sm => sm.EmployeeId)
                .IsRequired(); // Now string type

            builder.Property(sm => sm.MovementType)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(sm => sm.QuantityChanged)
                .HasColumnType("decimal(18,3)")
                .IsRequired();

            builder.Property(sm => sm.QuantityBefore)
                .HasColumnType("decimal(18,3)")
                .IsRequired();

            builder.Property(sm => sm.QuantityAfter)
                .HasColumnType("decimal(18,3)")
                .IsRequired();

            builder.Property(sm => sm.ReferenceType)
                .HasMaxLength(50);

            builder.Property(sm => sm.Notes)
                .HasMaxLength(500);

            builder.Property(sm => sm.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(sm => sm.Branch)
                .WithMany(b => b.StockMovements)
                .HasForeignKey(sm => sm.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sm => sm.Product)
                .WithMany(p => p.StockMovements)
                .HasForeignKey(sm => sm.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sm => sm.Employee)
                .WithMany(e => e.StockMovements)
                .HasForeignKey(sm => sm.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(sm => sm.BranchId);
            builder.HasIndex(sm => sm.ProductId);
            builder.HasIndex(sm => sm.MovementType);
            builder.HasIndex(sm => sm.CreatedAt);
            builder.HasIndex(sm => new { sm.ReferenceType, sm.ReferenceId });
            builder.HasIndex(sm => sm.EmployeeId);
        }
    }


}
