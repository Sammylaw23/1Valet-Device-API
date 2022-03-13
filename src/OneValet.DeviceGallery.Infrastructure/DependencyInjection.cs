using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OneValet.DeviceGallery.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using OneValet.DeviceGallery.Application.Interfaces;

namespace OneValet.DeviceGallery.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            configuration.GetValue<bool>("UseInMemoryDatabase");

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                //services.AddDbContext<DeviceDbContext>(options =>
                //    options.UseInMemoryDatabase("OneValetDeviceGalleryDB"));
            }
            else
            {
                string appConnectionString = configuration.GetConnectionString("ApplicationDbConnectionString");
                services.AddDbContext<DeviceDbContext>(options => options.UseSqlServer(appConnectionString,
                    x => x.MigrationsAssembly(typeof(DeviceDbContext).Assembly.FullName)));
            }








            "UseInMemoryDatabase": false,
  "ConnectionStrings": {
                "DefaultConnection": "Data Source=DESKTOP-QCM5AL0;Initial Catalog=CleanArchitectureApplicationDb;Integrated Security=True;MultipleActiveResultSets=True",
    "IdentityConnection": "Data Source=DESKTOP-QCM5AL0;Initial Catalog=identityDb;Integrated Security=True;MultipleActiveResultSets=True"
        }
        }
    }
