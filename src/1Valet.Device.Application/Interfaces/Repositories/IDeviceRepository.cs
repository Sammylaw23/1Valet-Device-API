using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Valet.Device.Application.Interfaces.Repositories
{
    public  interface IDeviceRepository
    {
        Task CreateDeviceAsync(Domain.Entities.Device device);
        Task<Domain.Entities.Device> GetDeviceByIdAsync(long id);
        Task<Domain.Entities.Device> GetDeviceByDeviceNoAsync(long deviceId);
        Task<IEnumerable<Domain.Entities.Device>> GetAllDeviceAsync();
        void UpdateDevice(Domain.Entities.Device device);
    }
}
