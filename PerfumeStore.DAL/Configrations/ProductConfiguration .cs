using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeStore.DAL.Configrations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.BarcodeNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.BarcodeImageUrl)
                .HasMaxLength(500);

            builder.Property(p => p.ProductType)
                .IsRequired()
                .HasConversion<string>(); // Store as string in DB

            builder.Property(p => p.BasePrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.PricePerMg)
                .HasColumnType("decimal(18,6)");

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(p => p.BarcodeNumber)
                .IsUnique();

            builder.HasIndex(p => p.ProductType);
            builder.HasIndex(p => p.IsActive);
            builder.HasIndex(p => p.Name);
        }
    }
}
