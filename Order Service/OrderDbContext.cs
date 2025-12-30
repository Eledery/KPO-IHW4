using Microsoft.EntityFrameworkCore;


namespace Order_Service
{
    public sealed class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Commons.Models.Objects.Order> Orders { get; set; }
        public DbSet<Commons.Models.Messages.OrderOutboxMessage> Messages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = orders.db");
        }
    }
}
