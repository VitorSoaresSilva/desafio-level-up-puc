using Microsoft.EntityFrameworkCore;

namespace DesafioLevelUp.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options): base(options){ }

        public DbSet<Order> Orders { get; set; }
    }
}
