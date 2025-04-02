using Microsoft.EntityFrameworkCore;
using SaaSFileManager.Core.Entities;

namespace SaaSFileManager.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<UploadedFile> Files { get; set; }
        public DbSet<Billing> Billings { get; set; }

    }
}
