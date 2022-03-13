using OneValet.DeviceGallery.Application.Interfaces;
using OneValet.DeviceGallery.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneValet.DeviceGallery.Infrastructure.Persistence.Repositories
{
    public class DeviceRepository : RepositoryBase<Domain.Entities.Device>, IDeviceRepository
    {
        public DeviceRepository(IApplicationDbContext dbContext) : base(dbContext) { }
        public async Task CreateDeviceAsync(Domain.Entities.Device device)
        {
            await AddAsync(device);
        }

        public async Task<IEnumerable<Domain.Entities.Device>> GetAllDeviceAsync()
        {
           return await Get().ToListAsync();
            //await Get(includeProperties: "Currency").ToListAsync();
        }

        public async Task<Domain.Entities.Device> GetDeviceByDeviceNoAsync(long deviceId) =>
            await _dbContext.Devices
            .Where(a => a.Id == deviceId)
            .AsNoTracking()
            //.Include(a => a.)
            .FirstOrDefaultAsync();


        public async Task<Domain.Entities.Device> GetDeviceByIdAsync(long id) =>
            await _dbContext.Devices.Where(a => a.Id == id)
            .AsNoTracking()
            //.Include(a => a.)
            .FirstOrDefaultAsync();


        public void UpdateDevice(Domain.Entities.Device device) => Update(device);
    }
}
