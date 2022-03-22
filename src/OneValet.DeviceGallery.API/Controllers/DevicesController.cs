using OneValet.DeviceGallery.Application.DTOs.Device;
using OneValet.DeviceGallery.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OneValet.DeviceGallery.Domain.Entities.RequestFeatures;
using Newtonsoft.Json;
using OneValet.DeviceGallery.Application.ResourceParameters;

namespace OneValet.DeviceGallery.API.Controllers
{
    [Route("api/devices")]
    [ApiController]
    [Authorize]

    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DevicesController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDevicesAsync([FromQuery] DevicesResourceParameters devicesResourceParameters)
        {
            var devices = await _deviceService.GetAllDevicesAsync(devicesResourceParameters);
            return Ok(devices);
        }
                
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceByIdAsync(int id) =>
           Ok(await _deviceService.GetDeviceByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddDeviceAsync(DeviceRequest request)
        {
            var response = await _deviceService.AddDeviceAsync(request);
            return Ok(response);
                //CreatedAtAction(nameof(GetDeviceByIdAsync), new { id = response.Data }, response);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> AddMultipleDevicesAsync(IEnumerable<DeviceRequest> requests)
        {
            var response = await _deviceService.AddMultipleDevicesAsync(requests);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeviceAsync(int id, DeviceRequest request)
        {
            await _deviceService.UpdateDeviceAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceAsync(int id)
        {
            await _deviceService.DeleteDeviceAsync(id);
            return NoContent();
        }

        [HttpPut("toggledeviceavailability/{id}")]
        public async Task<IActionResult> ToggleDeviceAvailabilityAsync(int id)
        {
            await _deviceService.ToggleAvailability(id);
            return NoContent();
        }

    }
}