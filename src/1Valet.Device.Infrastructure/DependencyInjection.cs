using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using _1Valet.Device.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace _1Valet.Device.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string appConnectionString = configuration.GetConnectionString("ApplicationDbConnectionString");


            services.AddDbContext<DeviceDbContext>(options => options.UseSqlServer(appConnectionString,
                x => x.MigrationsAssembly(typeof(DeviceDbContext).Assembly.FullName)));
        }
    }
}
