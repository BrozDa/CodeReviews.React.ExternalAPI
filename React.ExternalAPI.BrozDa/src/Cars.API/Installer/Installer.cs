using Cars.API.Data;
using Cars.API.Services;
using Microsoft.EntityFrameworkCore;

namespace Cars.API.Installer
{
    public static class Installer
    {
        public static IServiceCollection InitializeApi
            (this IServiceCollection services, IConfigurationRoot configuration)
        {
            var connectionString = configuration.GetConnectionString("Cars") ?? null;

            if (connectionString is null) { throw new ArgumentNullException("Connection string not found"); }

            services.AddDbContext<CarContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });


            services.AddTransient<SeedService>();

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            return services;

        }
        public static WebApplication AddMiddleware(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            return app;
        }

        public static WebApplication SetUpDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<CarContext>();
            context.Database.Migrate();

            var seedService = services.GetRequiredService<SeedService>();

            var cars = seedService.GetSeedData();

            context.Cars.AddRange(cars);
            context.SaveChanges();


            return app;
        }

    }
}
