using Cars.API.Models;
using Cars.API.Services;
using Microsoft.EntityFrameworkCore;

namespace Cars.API.Data
{
    public class CarContext : DbContext
    {
        public DbSet<CarDetail> Cars { get; set; } = null!;

        public CarContext(DbContextOptions options) : base(options) { }

    }
}
