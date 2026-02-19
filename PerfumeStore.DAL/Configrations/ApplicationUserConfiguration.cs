using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeStore.DAL.Configrations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.IsActive)
                .HasDefaultValue(true);
            // Relationships
            builder.HasOne(u => u.Branch)
                .WithMany(b => b.Employees)  // Now it references the collection
                .HasForeignKey(u => u.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(u => u.BranchId);
            builder.HasIndex(u => u.Email);
        }
    }
}
