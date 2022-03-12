using _1Valet.Device.Application.DTOs.Device;
using _1Valet.Device.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Valet.Device.Application.Interfaces.Services
{
   public interface IDeviceService
    {

        Task<Response<long>> AddDeviceAsync(DeviceRequest deviceRequest);
        Task UpdateDeviceAsync(long id, DeviceRequest deviceRequest);
        Task<Response<DeviceResponse>> GetDeviceAsync(long id);
        Task<Response<IEnumerable<DeviceResponse>>> GetDevicesAsync();
        //Task<Response<OrderResponse>> PlaceOrderAsync(NewOrderRequest request);
        //Task<Response<OrderDto>> GetOrderAsync(long id);
        //Task<Response<IEnumerable<OrderDto>>> GetOrdersAsync(OrderFilterOption filter);
    }
}