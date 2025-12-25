using Microsoft.EntityFrameworkCore;


namespace Order_Service
{
    public sealed class OrderDbContext : DbContext
    {
        public DbSet<Commons.Models.Objects.Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = orders.db");
        }
    }
}
