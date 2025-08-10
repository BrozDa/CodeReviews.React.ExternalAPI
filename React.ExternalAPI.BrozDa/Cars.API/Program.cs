
using Cars.API.Data;
using Cars.API.Installer;
using Cars.API.Models;
using Cars.API.Services;
using Cars.API.Endpoints;
namespace Cars.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.InitializeApi(builder.Configuration);

            var app = builder.Build();
            app.SetUpDatabase();

            app.AddMiddleWare();

            app.AddCarEndpoints();

            app.Run();
        }
    }
}
