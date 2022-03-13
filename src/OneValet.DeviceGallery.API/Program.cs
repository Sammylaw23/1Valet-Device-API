using OneValet.DeviceGallery.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

IConfiguration configuration = builder.Configuration;
//IWebHostEnvironment environment = builder.Environment;

var services = builder.Services;
services.AddInfrastructure(configuration);

configuration.GetValue<bool>("UseInMemoryDatabase");








builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.Run();
