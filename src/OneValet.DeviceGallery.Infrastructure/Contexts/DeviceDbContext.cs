﻿using OneValet.DeviceGallery.Domain.Entities;
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
            //deviceUser.HasOne<Domain.Entities.Device>(x => x.Device)
            //    .WithOne(x => x.DeviceUser)
            //    .HasForeignKey<Domain.Entities.Device>(x => x.DeviceUserId);

            var device = modelBuilder.Entity<Domain.Entities.Device>().ToTable("Devices");
            device.HasKey(x => x.Id);
            

            var deviceType = modelBuilder.Entity<DeviceType>().ToTable("DeviceTypes");
            deviceType.HasKey(x => x.DeviceTypeId);
        }












        //public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
