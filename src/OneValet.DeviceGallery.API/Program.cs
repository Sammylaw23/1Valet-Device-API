using OneValet.DeviceGallery.API.Extensions;
using OneValet.DeviceGallery.Application;
using OneValet.DeviceGallery.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
IConfiguration configuration = builder.Configuration;
//IWebHostEnvironment environment = builder.Environment;
var services = builder.Services;
services.AddInfrastructure(configuration);
services.AddApplicationLayer();
services.AddCors(options => options.AddDefaultPolicy(builder => builder.WithOrigins(configuration["AllowedUrl"]).AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Wait 30 seconds for graceful shutdown
builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(30));










var app = builder.Build();
app.Logger.LogInformation("The application started");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseApiErrorHandler();
app.Run();
