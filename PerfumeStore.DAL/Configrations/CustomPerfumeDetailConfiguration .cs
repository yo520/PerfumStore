using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeStore.DAL.Configrations
{
    public class CustomPerfumeDetailConfiguration : IEntityTypeConfiguration<CustomPerfumeDetail>
    {
        public void Configure(EntityTypeBuilder<CustomPerfumeDetail> builder)
        {
            builder.ToTable("CustomPerfumeDetails");

            builder.HasKey(cpd => cpd.Id);

            builder.Property(cpd => cpd.QuantityInMg)
                .HasColumnType("decimal(18,3)")
                .IsRequired();

            builder.Property(cpd => cpd.AlcoholPrice)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(cpd => cpd.LiquidPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(cpd => cpd.BottlePrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(cpd => cpd.TotalPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // Relationships
            builder.HasOne(cpd => cpd.SaleItem)
                .WithOne(si => si.CustomPerfumeDetail)
                .HasForeignKey<CustomPerfumeDetail>(cpd => cpd.SaleItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cpd => cpd.LiquidProduct)
                .WithMany(p => p.LiquidUsages)
                .HasForeignKey(cpd => cpd.LiquidProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cpd => cpd.BottleProduct)
                .WithMany(p => p.BottleUsages)
                .HasForeignKey(cpd => cpd.BottleProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(cpd => cpd.SaleItemId)
                .IsUnique();

            builder.HasIndex(cpd => cpd.LiquidProductId);
            builder.HasIndex(cpd => cpd.BottleProductId);
        }
    }
}
