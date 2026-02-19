using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeStore.DAL.Configrations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.SaleNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.EmployeeId)
                .IsRequired(); // Now string type

            builder.Property(s => s.TotalAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(s => s.DiscountAmount)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(s => s.NetAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(s => s.SaleDate)
                .IsRequired();

            builder.Property(s => s.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(s => s.IsVoided)
                .HasDefaultValue(false);

            builder.Property(s => s.Notes)
                .HasMaxLength(200);

            // Relationships
            builder.HasOne(s => s.Branch)
                .WithMany(b => b.Sales)
                .HasForeignKey(s => s.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Employee)
                .WithMany(e => e.Sales)
                .HasForeignKey(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(s => s.SaleNumber).IsUnique();
            builder.HasIndex(s => s.SaleDate);
            builder.HasIndex(s => s.BranchId);
            builder.HasIndex(s => s.EmployeeId);
            builder.HasIndex(s => s.IsVoided);
        }
    }
}
