﻿using OneValet.DeviceGallery.Application.Interfaces;
using OneValet.DeviceGallery.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneValet.DeviceGallery.Domain.Entities;
using OneValet.DeviceGallery.Domain.Entities.RequestFeatures;
using OneValet.DeviceGallery.Application.Wrappers;
using OneValet.DeviceGallery.Application.DTOs.Device;
using EFCore.BulkExtensions;

namespace OneValet.DeviceGallery.Infrastructure.Persistence.Repositories
{
    public class DeviceRepository : RepositoryBase<Domain.Entities.Device>, IDeviceRepository
    {
        public DeviceRepository(IApplicationDbContext dbContext) : base(dbContext) { }
        public async Task CreateDeviceAsync(Domain.Entities.Device device)
        {
            await AddAsync(device);
        }


        public async Task<PagedList<Domain.Entities.Device>> GetAllDeviceAsync(DeviceParameters deviceParameters)
        {
             var devices = await Get()
                .OrderBy(x => x.Id)                
                .ToListAsync();

            return PagedList<Domain.Entities.Device>.ToPagedList(devices, deviceParameters.PageNumber, deviceParameters.PageSize);

            //await Get(includeProperties: "Currency").ToListAsync();
        }


   




        //public async Task<Domain.Entities.Device> GetDeviceByDeviceNoAsync(int deviceId) =>
        //    await _dbContext.Devices
        //    .Where(a => a.Id == deviceId)
        //    .AsNoTracking()
        //    //.Include(a => a.)
        //    .FirstOrDefaultAsync();


        public async Task<Domain.Entities.Device> GetDeviceByIdAsync(int id) =>
            await _dbContext.Devices.Where(a => a.Id == id)
            .AsNoTracking()
            //.Include(a => a.)
            .FirstOrDefaultAsync();


        public void UpdateDevice(Domain.Entities.Device device) => Update(device);


        public void DeleteDevice(Device device) => Delete(device);

        public async Task AddMultipleDevicesAsync(IEnumerable<Device> devices)
            => await _dbContext.BulkInsertAsync(devices.ToList());
        
    }
}
