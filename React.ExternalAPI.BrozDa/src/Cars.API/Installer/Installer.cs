using Cars.API.Data;
using Cars.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Cars.API.Installer
{
    public static class Installer
    {
        public static IServiceCollection InitializeApi
            (this IServiceCollection services, IConfigurationRoot configuration)
        {
            var connectionString = configuration.GetConnectionString("Cars") ?? throw new InvalidOperationException("Missing connection string for 'Cars'.");

            services.AddDbContext<CarContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });


            services.AddTransient<SeedService>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            return services;

        }
        public static WebApplication AddSwagger(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            return app;
        }

        public static WebApplication SetUpDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<CarContext>();
            context.Database.Migrate();

            if (!context.Cars.Any())
            {
                try
                {
                    var seedService = services.GetRequiredService<SeedService>();
                    var cars = seedService.GetSeedData();
                    context.Cars.AddRange(cars!);
                    context.SaveChanges();
                    Console.WriteLine("[Seed] Database successfully seeded with initial car data.");
                }
                catch (Exception ex) when (
                ex is FileNotFoundException ||
                ex is IOException ||
                ex is JsonException)
                {
                    Console.WriteLine($"[Seed Error] {ex.GetType().Name}: {ex.Message}");
                }
                catch (Exception ex) { 
                    Console.WriteLine($"[Unhandled Error] {ex.GetType().Name}: {ex.Message}");
                }
            }
            return app;
        }

    }
}
