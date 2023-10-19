using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<UserDto> GetAsync(string email)
            => await _userService.GetAsync(email);

        [HttpPost("")]
        public async Task PostAsync([FromBody]CreateUser request)
        {
            await _userService.RegisterAsync(request.Email, request.Username, request.Password);
        }
    }
}
