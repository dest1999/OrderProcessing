using Microsoft.EntityFrameworkCore;

namespace OrderProcessing
{
    public class DataContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
