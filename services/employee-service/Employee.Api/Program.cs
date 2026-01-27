
using Employee.Api.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Employee.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); //Think of builder as: “setup mode”


            builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);

            var conn = builder.Configuration.GetConnectionString("EmployeeDb");
            if (string.IsNullOrWhiteSpace(conn))
                throw new InvalidOperationException("Missing connection string: ConnectionStrings:EmployeeDb");

            builder.Services.AddDbContext<EmployeeDbContext>(opt => opt.UseNpgsql(conn));

            // Add services to the container.
            // These lines prepare what your app can do.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

           


            var app = builder.Build(); // Now the app is created.

            Console.WriteLine($"ENV = {app.Environment.EnvironmentName}");
            Console.WriteLine($"DB  = {builder.Configuration.GetConnectionString("EmployeeDb")}");


            app.UseSwagger();
                app.UseSwaggerUI();
            
            // Only in Development environment: creates / swagger / v1 / swagger.json shows Swagger UI at / swagger So Swagger is not enabled in production by default(security best practice).
            
            app.UseHttpsRedirection(); // If someone hits HTTP, redirect to HTTPS and  Helps with security

            app.UseAuthorization(); //Adds authorization layer


            app.MapControllers(); // “Scan Controllers folder, find route attributes, and make them available.”

            app.Run(); // This starts Kestrel web server and begins listening on ports from launchSettings.json.
        }
    }
}
