using Microsoft.EntityFrameworkCore;
using smsa_mig_ap.Data.Entities;

namespace smsa_mig_ap.Data
{
    public class MigContext: DbContext
    {
        public MigContext(DbContextOptions<MigContext> options)
        : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SalesLT"); 
        }
    }
}
