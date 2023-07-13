using CoreAngular.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreAngular.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<AppUser> Users{ get; set; }
    }
}

