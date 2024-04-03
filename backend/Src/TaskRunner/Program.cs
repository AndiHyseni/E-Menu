
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using TaskRunner.Tasks;
using System.Reflection;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {

        config.SetBasePath(Directory.GetCurrentDirectory()!)
        .AddEnvironmentVariables()
        .AddUserSecrets<Program>();

    }).ConfigureServices((context, services) =>
    {
        var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));
        services.AddScoped<UserInput>();
        services.AddScoped<DbInitialization>();
    })
.Build();

using var services = builder.Services.CreateScope();

var userInput = services.ServiceProvider.GetRequiredService<UserInput>();

await userInput.GetAsync();
