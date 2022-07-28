using Microsoft.EntityFrameworkCore;

namespace cam_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<AssignedAsset>()
            // .HasOne(p => p.Asset)
            // .WithMany(b => b.AssignedAsset);
        }

        public DbSet<Asset> Assets => Set<Asset>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<AssignedAsset> AssignedAssets => Set<AssignedAsset>();

    }
}