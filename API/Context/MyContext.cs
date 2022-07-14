using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
