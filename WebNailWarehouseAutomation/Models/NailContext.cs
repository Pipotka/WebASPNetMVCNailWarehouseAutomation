using Microsoft.EntityFrameworkCore;

namespace WebNailWarehouseAutomation.Models
{
    public class NailContext : DbContext
    {
        public DbSet<Nail> Nails { get; set; } = null!;

        public NailContext(DbContextOptions<NailContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
