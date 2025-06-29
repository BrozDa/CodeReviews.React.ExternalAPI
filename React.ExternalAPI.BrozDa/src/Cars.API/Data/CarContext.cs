using Cars.API.Models;
using Cars.API.Services;
using Microsoft.EntityFrameworkCore;

namespace Cars.API.Data
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

            optionsBuilder.UseSqlite(config["Cars:ConnectionString"]);

            

        }

    }
}
