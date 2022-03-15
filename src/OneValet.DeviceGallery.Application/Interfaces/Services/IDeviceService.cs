using OneValet.DeviceGallery.Application.DTOs.Device;
using OneValet.DeviceGallery.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneValet.DeviceGallery.Application.Interfaces.Services
{
   public interface IDeviceService
    {

        Task<Response<DeviceResponse>> AddDeviceAsync(DeviceRequest deviceRequest);
        Task UpdateDeviceAsync(int id, DeviceRequest deviceRequest);
        Task<Response<DeviceResponse>> GetDeviceByIdAsync(int id);
        Task<Response<IEnumerable<DeviceResponse>>> GetAllDevicesAsync();

        Task ToggleAvailability(int id);

        Task DeleteDeviceAsync(int id);
        //Task<Response<NewWalletResponse>> CreateWalletAsync(NewWalletRequest accountRequest);
        //Task<Response<IEnumerable<WalletDto>>> GetAllWalletAsync();
        //Task<Response<WalletDto>> GetWalletByAccountNoAsync(string accountNumber);
        //Task<Response<WalletDto>> GetWalletByIdAsync(Guid id);
        //Task FundWalletAsync(Guid accountId, FundWalletRequest request);
    }
}