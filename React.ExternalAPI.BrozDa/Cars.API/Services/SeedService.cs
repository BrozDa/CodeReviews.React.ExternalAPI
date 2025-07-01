using Cars.API.Data;
using Cars.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;

namespace Cars.API.Services
{
    public class SeedService
    {

        public IEnumerable<CarDetail>? GetSeedData()
        {

            try
            {
                var projectRoot = Environment.GetEnvironmentVariable("PROJECT_ROOT");

                string path = Path.Combine(projectRoot ?? Directory.GetCurrentDirectory(), "Resources", "CarDetails.json");

                if (!File.Exists(path)) { throw new FileNotFoundException("File with seed data not found"); }

                string rawData = File.ReadAllText(path);
                var cars = JsonSerializer.Deserialize<IEnumerable<CarDetail>>(rawData);
                return cars ?? throw new JsonException("Unable to deserialize list with seed data");


            }
            catch (Exception ex) when (
                    ex is FileNotFoundException ||
                    ex is IOException ||
                    ex is JsonException)
               {
                Console.WriteLine($"[Seed Error] {ex.GetType().Name}: {ex.Message}");
                throw;
            };

        }



    }
}
