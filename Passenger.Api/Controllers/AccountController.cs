using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;
using System.Windows.Input;

namespace Passenger.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        public AccountController(ICommandDispatcher commandDispatcher) : base(commandDispatcher) 
        {
        }
        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> PutAsync([FromBody] ChangeUserPassword command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}
