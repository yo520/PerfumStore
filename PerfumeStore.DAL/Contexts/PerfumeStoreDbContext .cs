using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PerfumeStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeStore.DAL.Contexts
{
    public class PerfumeStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public PerfumeStoreDbContext(DbContextOptions<PerfumeStoreDbContext> options)
            : base(options)
        {
        }

        // DbSets (Remove Employee DbSet)
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<CustomPerfumeDetail> CustomPerfumeDetails { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call base to configure Identity tables
            base.OnModelCreating(modelBuilder);

            // Apply all configurations from assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PerfumeStoreDbContext).Assembly);

            // Global query filters
            modelBuilder.Entity<Branch>().HasQueryFilter(b => b.IsActive);
            modelBuilder.Entity<Product>().HasQueryFilter(p => p.IsActive);
            modelBuilder.Entity<ApplicationUser>().HasQueryFilter(u => u.IsActive);
            modelBuilder.Entity<Sale>().HasQueryFilter(s => !s.IsVoided);

            // Customize Identity table names (optional)
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserRole<string>>().ToTable("UserRoles");

            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityRoleClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();

            //modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserClaim<string>>().ToTable("UserClaims");
            //modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserLogin<string>>().ToTable("UserLogins");
            //modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>>().ToTable("RoleClaims");
            //modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserToken<string>>().ToTable("UserTokens");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Auto-update LastUpdated for Stock entities
            var stockEntries = ChangeTracker.Entries<Stock>()
                .Where(e => e.State == EntityState.Modified);

            foreach (var entry in stockEntries)
            {
                entry.Entity.LastUpdated = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
