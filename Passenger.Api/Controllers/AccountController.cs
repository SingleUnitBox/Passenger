using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;
using System.Windows.Input;

namespace Passenger.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IJwtHandler _jwtHandler;

        public AccountController(ICommandDispatcher commandDispatcher,
            IJwtHandler jwtHandler) : base(commandDispatcher) 
        {
            _jwtHandler = jwtHandler;
        }
        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> PutAsync([FromBody] ChangeUserPassword command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return NoContent();
        }
        [HttpGet]
        [Route("token")]
        public IActionResult GetToken()
        {
            var token = _jwtHandler.CreateToken("user@gmail.com", "user");

            return Json(token);
        }
        [HttpGet]
        [Route("auth")]
        [Authorize]
        public IActionResult GetAuth()
        {
            return Ok("auth");
        }
    }
}
