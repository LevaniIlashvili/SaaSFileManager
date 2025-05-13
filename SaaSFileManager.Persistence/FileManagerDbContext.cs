using Microsoft.EntityFrameworkCore;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Persistence
{
    public class FileManagerDbContext : DbContext
    {
        public FileManagerDbContext(DbContextOptions<FileManagerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompanyFileAccess>()
                .HasOne(fa => fa.Employee)
                .WithMany()
                .HasForeignKey(fa => fa.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompanyFileAccess>()
                .HasOne(fa => fa.File)
                .WithMany()
                .HasForeignKey(fa => fa.FileId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanySubscription>()
                .HasIndex(cs => cs.CompanyId)
                .HasFilter("CanceledAt IS NULL")
                .IsUnique();

            modelBuilder.Entity<SubscriptionPlan>().HasData(
                    new SubscriptionPlan
                    {
                        Id = new Guid("6523feb5-b2e5-44f0-86b1-f3029a966310"),
                        Name = "Free",
                        FileLimitPerMonth = 10,
                        UserLimit = 1,
                        StartingPrice = 0,
                        AllowExtraFiles = false,
                    },
                    new SubscriptionPlan
                    {
                        Id = new Guid("12455643-90a2-4477-9aaa-fa212163bb5f"),
                        Name = "Basic",
                        FileLimitPerMonth = 100,
                        UserLimit = 10,
                        StartingPrice = 0,
                        PricePerUser = 5,
                        AllowExtraFiles = false,
                    },
                    new SubscriptionPlan
                    {
                        Id = new Guid("3ea029f3-bdd3-4ca4-9331-78f269d0d742"),
                        Name = "Premium",
                        FileLimitPerMonth = 1000,
                        UserLimit = null,
                        StartingPrice = 300,
                        AllowExtraFiles = true,
                        PricePerExtraFile = 0.5M
                    });
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CompanyFile> CompanyFiles { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<CompanySubscription> CompanySubscriptions { get; set; }
        public DbSet<BillingRecord> BillingRecords { get; set; }
        public DbSet<CompanyFileAccess> FileAccesses { get; set; }

        // TODO: override SaveChangesAsync method later
    }
}
