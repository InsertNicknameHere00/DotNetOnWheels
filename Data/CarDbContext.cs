using CarManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManagerAPI.Data
{
    public class CarDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }

        public CarDbContext(DbContextOptions<CarDbContext> options,IConfiguration configuration)
            :base (options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("LibraryContext"));
        }
    }
}
