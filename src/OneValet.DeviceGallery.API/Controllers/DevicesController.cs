using OneValet.DeviceGallery.Application.DTOs.Device;
using OneValet.DeviceGallery.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace OneValet.DeviceGallery.API.Controllers
{
    [Route("api/devices")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DevicesController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDevices()
        {
            return Ok(await _deviceService.GetAllDevicesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceById(int id) =>
           Ok(await _deviceService.GetDeviceByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddDevice(DeviceRequest request)
        {
            //return Ok(await _deviceService.AddDeviceAsync(request));
            var response = await _deviceService.AddDeviceAsync(request);
            return CreatedAtAction(nameof(GetDeviceById), new { id = response.Data }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(int id, DeviceRequest request)
        {
            await _deviceService.UpdateDeviceAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deviceService.DeleteDeviceAsync(id);
            return NoContent();
        }

        [HttpPut("toggledeviceavailability/{id}")]
        public async Task<IActionResult> ToggleDeviceAvailability(int id)
        {
            await _deviceService.ToggleAvailability(id);
            return NoContent();
        }


       

    }
}