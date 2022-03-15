using AutoMapper;
using OneValet.DeviceGallery.Application.Common.Exceptions;
using OneValet.DeviceGallery.Application.DTOs.Device;
using OneValet.DeviceGallery.Application.Interfaces;
using OneValet.DeviceGallery.Application.Interfaces.Services;
using OneValet.DeviceGallery.Application.Wrappers;
using OneValet.DeviceGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneValet.DeviceGallery.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IMapper _mapper;

        public DeviceService(IRepositoryProvider repositoryProvider, IMapper mapper)
        {
            _repositoryProvider = repositoryProvider;
            _mapper = mapper;
        }
        public async Task<Response<DeviceResponse>> AddDeviceAsync(DeviceRequest deviceRequest)
        {
            var device = _mapper.Map<Domain.Entities.Device>(deviceRequest);
            if (deviceRequest.Online)
                device.Status = "Available";
            await _repositoryProvider.DeviceRepository.CreateDeviceAsync(device);
            await _repositoryProvider.SaveChangesAsync();
            return new Response<DeviceResponse>(_mapper.Map<DeviceResponse>(device));
            //var device = new Domain.Entities.Device
            //{
            //    Name = deviceRequest.Name,
            //    //DeviceType = DeviceType
            //    TemperatureC = deviceRequest.TemperatureC,
            //    Online = deviceRequest.Online,
            //    IconBase64String = deviceRequest.IconBase64String
            //};

            //return new Response<DeviceResponse>(new DeviceResponse
            //{
            //    DeviceId = device.Id,   
            //    Name = deviceRequest.Name,
            //    IconBase64String= deviceRequest.IconBase64String,
            //    Online = deviceRequest.Online,
            //    Status = device.Status,
            //    TemperatureC = device.TemperatureC
            //}, "Success"); //Use Automapper


            //var device = new Domain.Entities.Device
            //{
            //    Name = "Nokia 7 Plus",
            //    //DeviceType = DeviceType
            //    TemperatureC = 15.1,
            //    Online = true,
            //    IconBase64String = "dwjkjkjkjhjHHghKhHhjkHkGHGhgJhgHhjHJhgHh",
            //};
        }

        public async Task<Response<IEnumerable<DeviceResponse>>> GetAllDevicesAsync()
        {
            var devices = await _repositoryProvider.DeviceRepository.GetAllDeviceAsync();
            return new Response<IEnumerable<DeviceResponse>>(_mapper.Map<IEnumerable<DeviceResponse>>(devices));
        }

        public async Task<Response<DeviceResponse>> GetDeviceByIdAsync(int id)
        {
            var device = await _repositoryProvider.DeviceRepository.GetDeviceByIdAsync(id);
            return device == null ? throw new NotFoundException() : new Response<DeviceResponse>(_mapper.Map<DeviceResponse>(device));
        }


        public async Task UpdateDeviceAsync(int id, DeviceRequest deviceRequest)
        {
            var device = await _repositoryProvider.DeviceRepository.GetDeviceByIdAsync(id);
            if(device == null)
                throw new NotFoundException();
            if (device.Name != deviceRequest.Name)
                throw new ArgumentException("Invalid device name.");
            _mapper.Map(deviceRequest, device);
             _repositoryProvider.DeviceRepository.UpdateDevice(device);
            await _repositoryProvider.SaveChangesAsync();

        }
        public async Task ToggleAvailability(int id)
        {
            var device = await _repositoryProvider.DeviceRepository.GetDeviceByIdAsync(id);
            if (device == null)
                throw new NotFoundException();
            if (device.Online)
            {
                device.Online = false;
                device.Status = "Offline"; //TODO: Let Status be updated automatically once Online property is set so you don't have to hardcode in different parts of the application
            }
            else
            {
                device.Online = true;
                device.Status = "Available"; //TODO: Let Status be updated automatically once Online property is set so you don't have to hardcode in different parts of the application
            }

            _repositoryProvider.DeviceRepository.UpdateDevice(device);
            await _repositoryProvider.SaveChangesAsync();
        }

        public async Task DeleteDeviceAsync(int id)
        {
            var device = await _repositoryProvider.DeviceRepository.GetDeviceByIdAsync(id);
            if (device == null)
                throw new NotFoundException("Device not found!");
            _repositoryProvider.DeviceRepository.DeleteDevice(device);
            await _repositoryProvider.SaveChangesAsync();
        }
    }
}
