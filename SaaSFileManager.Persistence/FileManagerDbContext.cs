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
