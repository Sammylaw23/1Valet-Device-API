using _1Valet.Device.Application.Interfaces;
using _1Valet.Device.Application.Interfaces.Repositories;
using _1Valet.Device.Infrastructure.Contexts;
using _1Valet.Device.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Valet.Device.Infrastructure.Persistence
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private readonly IApplicationDbContext _dbContext;
        private IDeviceRepository _deviceRepository;

        public RepositoryProvider(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IDeviceRepository DeviceRepository => _deviceRepository ??= new DeviceRepository(_dbContext);

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
