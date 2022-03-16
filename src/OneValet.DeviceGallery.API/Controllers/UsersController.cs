using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneValet.DeviceGallery.Application.DTOs.User;
using OneValet.DeviceGallery.Application.Interfaces.Services;
using OneValet.DeviceGallery.API.Middlewares;
namespace OneValet.DeviceGallery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegisterUser(UserRequest user)
        {
            var response = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = response.Data.Id }, response);
        }


        [HttpPost("authentication")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateUser(AuthenticationRequest request)
        {
            return Ok(await _userService.AuthenticateAsync(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
           return Ok(await _userService.GetUserByIdAsync(id));
        }

        [HttpGet()]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequest userRequest)
        {
            return Ok(await _userService.AddUserAsync(userRequest));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
