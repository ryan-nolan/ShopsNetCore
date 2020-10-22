using Microsoft.EntityFrameworkCore;
using ShopsNetCore.Core;

namespace ShopsNetCore.Data
{
    public class ShopsDbContext : DbContext
    {
        public ShopsDbContext(DbContextOptions<ShopsDbContext> options) : base(options)
        { }

        public DbSet<Shop> Shops { get; set; }
    }
}
