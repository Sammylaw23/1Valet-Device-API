using _1Valet.Device.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Valet.Device.Application.Interfaces
{
    public interface IRepositoryProvider
    {
        public IDeviceRepository DeviceRepository { get; }

        

        Task SaveChangesAsync();
    }
}
