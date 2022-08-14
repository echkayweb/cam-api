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

        }

        public DbSet<Asset> Assets => Set<Asset>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<AssignedAsset> AssignedAssets => Set<AssignedAsset>();
        public DbSet<User> Users => Set<User>();

    }
}