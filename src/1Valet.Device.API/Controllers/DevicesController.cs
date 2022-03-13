using _1Valet.Device.Application.DTOs.Device;
using _1Valet.Device.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace _1Valet.Device.API.Controllers
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
            return Ok(await _deviceService.GetDevicesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceById(long id) =>
           Ok(await _deviceService.GetDeviceAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddDevice(DeviceRequest request)
        {
            //return Ok(await _deviceService.AddDeviceAsync(request));
            var response = await _deviceService.AddDeviceAsync(request);
            return CreatedAtAction(nameof(GetDeviceById), new { id = response.Data }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(long id, DeviceRequest request)
        {
            await _deviceService.UpdateDeviceAsync(id, request);
            return NoContent();
        }

        [HttpPost("toggledeviceavailability")]
        public async Task<IActionResult> ToggleDeviceAvailability(DeviceRequest request)
        {
            return NoContent();
        }



        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }
}