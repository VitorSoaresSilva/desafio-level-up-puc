using Microsoft.EntityFrameworkCore;

namespace DesafioLevelUp.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options): base(options) {
            ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
