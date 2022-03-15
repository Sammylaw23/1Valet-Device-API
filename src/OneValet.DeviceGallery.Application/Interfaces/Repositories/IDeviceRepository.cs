using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneValet.DeviceGallery.Application.Interfaces.Repositories
{
    public  interface IDeviceRepository
    {
        Task CreateDeviceAsync(Domain.Entities.Device device);
        Task<Domain.Entities.Device> GetDeviceByIdAsync(int id);
        //Task<Domain.Entities.Device> GetDeviceByDeviceNoAsync(int deviceId);
        Task<IEnumerable<Domain.Entities.Device>> GetAllDeviceAsync();
        void UpdateDevice(Domain.Entities.Device device);
        void DeleteDevice(Domain.Entities.Device device);
    }
}
