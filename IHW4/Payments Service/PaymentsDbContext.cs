using Microsoft.EntityFrameworkCore;

namespace Payments_Service
{
    public class PaymentsDbContext : DbContext
    {
        public DbSet<Commons.Models.Objects.Account> Accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = accounts.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commons.Models.Objects.Account>().HasKey(settings => settings.AccountId);
        }
    }
}