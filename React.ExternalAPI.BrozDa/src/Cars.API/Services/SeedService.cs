using Cars.API.Models;
using System.Text.Json;

namespace Cars.API.Services
{
    public class SeedService
    {

        public SeedService() 
        { 
        }

        public IEnumerable<Car> GetSeedData()
        {
            string projectRoot = Environment.GetEnvironmentVariable("PROJECT_ROOT") ?? "";
            string path  = Path.Combine(projectRoot ?? Directory.GetCurrentDirectory(), "Resources", "CarDetails.json");
            string rawData = File.ReadAllText(path);

            var cars = JsonSerializer.Deserialize<IEnumerable<Car>>(rawData) ?? null;

            return cars;
        }



    }
}
