using OneValet.DeviceGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneValet.DeviceGallery.Application.Interfaces;

namespace OneValet.DeviceGallery.Infrastructure.Contexts
{
    public class DeviceDbContext : DbContext, IApplicationDbContext
    {
        public DeviceDbContext(DbContextOptions<DeviceDbContext> options) : base(options)
        {
        }

        public DbSet<DeviceUser> DeviceUsers { get; set; }
        public DbSet<Domain.Entities.Device> Devices { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var userDevice = modelBuilder.Entity<DeviceUserDevice>().ToTable("UserDevices");
            //userDevice.HasKey(ud => new { ud.DeviceId, ud.DeviceUserId });

            var deviceUser = modelBuilder.Entity<DeviceUser>().ToTable("DeviceUsers");
            deviceUser.HasKey(u => u.Id);
            deviceUser.Property(x => x.Id).UseIdentityColumn();
            deviceUser.HasData(
                 new DeviceUser
                 {
                     Id = 1,
                     FirstName = "One",
                     LastName = "Valet",
                     UserName = "onevalet",
                     Email = "onevalet@gmail.com",
                     Password = "sapass123$",
                 });



            //deviceUser.HasOne<Domain.Entities.Device>(x => x.Device)
            //    .WithOne(x => x.DeviceUser)
            //    .HasForeignKey<Domain.Entities.Device>(x => x.DeviceUserId);


            var devices = new List<Device>
            {
                  new Device {
                    Id = 1,
                    Name = "Nokia 7 Plus",
                    TemperatureC =  49,
                    IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                    Online = true
                  },
                  new Device {
                      Id=2,
                    Name = "iPad 11",
                    TemperatureC =  67,
                    IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                    Online = false
                  },
                  new Device {
                      Id=3,
                    Name = "HP Elitebook",
                    TemperatureC =  72,
                    IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                    Online = false
                  },
                  new Device {
                      Id=4,
                    Name = "Samsung Tablet",
                    TemperatureC =  31,
                    IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                    Online = false
                  },
                  new Device {
                      Id=5,
                    Name = "DELL 205",
                    TemperatureC =  55,
                    IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                    Online = false
                  },
                  new Device {
                      Id=6,
                    Name = "Tecno Spark 6",
                    TemperatureC =  84,
                    IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                    Online = false
                  },
                  new Device {
                      Id=7,
                    Name = "iPhone 13 Pro Max",
                    TemperatureC =  50,
                    IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                    Online = true
                  },
                  new Device {
                      Id = 8,
                    Name = "Nokia 3310",
                    TemperatureC =  37,
                    IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                    Online = false
                  }
            };
            var device = modelBuilder.Entity<Domain.Entities.Device>().ToTable("Devices");
            device.HasKey(x => x.Id);
            device.Property(x => x.Id).UseIdentityColumn();
            device.HasData(devices);



            var deviceTypes = new List<DeviceType>
            {
                new DeviceType {
                     DeviceTypeId = 1,
                    Name = "Phone",
                    Description = "A pocket-sized device"
                },
                 new DeviceType {
                     DeviceTypeId = 2,
                    Name = "Tablet",
                    Description = "A palm-sized device"
                },
                  new DeviceType {
                        DeviceTypeId= 3,
                    Name = "PC",
                    Description = "A personal computer"
                },
            };


            var deviceType = modelBuilder.Entity<DeviceType>().ToTable("DeviceTypes");
            deviceType.HasKey(x => x.DeviceTypeId);
            deviceType.Property(x => x.DeviceTypeId).UseIdentityColumn();
            deviceType.HasData(deviceTypes);
        }












        //public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
