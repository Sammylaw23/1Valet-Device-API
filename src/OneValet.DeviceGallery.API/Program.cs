using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using OneValet.DeviceGallery.API.Extensions;
using OneValet.DeviceGallery.API.Middlewares;
using OneValet.DeviceGallery.Application;
using OneValet.DeviceGallery.Application.Interfaces.Services;
using OneValet.DeviceGallery.Application.Services;
using OneValet.DeviceGallery.Infrastructure;
using OneValet.DeviceGallery.Infrastructure.Contexts;
using OneValet.DeviceGallery.Infrastructure.Persistence;
using Serilog;
using Microsoft.AspNetCore.Builder;

//TODO.......................
//If User is failing remove  public bool EmailConfirmed { get; set; }

////Read Configuration from appSettings
//var config = new ConfigurationBuilder()
//    .AddJsonFile("appsettings.json")
//    .Build();

////Initialize Logger
//Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(config)
//    .CreateLogger();



Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");


try
{
    var builder = WebApplication.CreateBuilder(args);


    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .ReadFrom.Configuration(ctx.Configuration));




    // Add services to the container.
    IConfiguration configuration = builder.Configuration;
    //IWebHostEnvironment environment = builder.Environment;
    //var services = builder.Services;
    builder.Services.AddInfrastructure(configuration);
    builder.Services.AddApplicationLayer();
    builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder.WithOrigins(configuration["AllowedUrl"]).AllowAnyHeader().AllowAnyMethod()));



    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAuthentication("BasicAuthentication")
        .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
    builder.Services.AddScoped<IApplicationDataSeed, ApplicationDataSeed>();

    // Wait 30 seconds for graceful shutdown
    //builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(30));

    //var temp = builder.Services.Where(x => x.ServiceType.Name == "IUserService");

    //var userService = builder.Services.GetRequiredService<IUserService>();


    var app = builder.Build();
    app.UseSerilogRequestLogging();
    app.Logger.LogInformation("The application started");
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseApiErrorHandler();
    //app.ApplicationServices.GetRequiredService<IUserService>();

    
    using (var scope = app.Services.CreateScope())
    {
        var appServices = scope.ServiceProvider;
        var applicationDbContext = appServices.GetRequiredService<DeviceDbContext>();
        applicationDbContext.Database.Migrate();

        var userService = appServices.GetRequiredService<IUserService>();
        var deviceService = appServices.GetRequiredService<DeviceService>();
        var repositoryProvider = appServices.GetRequiredService<RepositoryProvider>();
        //await appServices.GetRequiredService<IApplicationDataSeed>()
        //    .DefaultUsersAsync(userService, repositoryProvider);

        await ApplicationDataSeed.DefaultUsersAsync(userService, repositoryProvider);
        await ApplicationDataSeed.DefaultDeviceTypesAsync(applicationDbContext);
        await ApplicationDataSeed.DefaultDevicesAsync(applicationDbContext);
        Log.Information("Finished Seeding Default Data");

    }



    app.Run();


}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}