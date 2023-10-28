using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    [Route("{routes}")]
    public class DriverRouteController : ApiControllerBase
    {
        public DriverRouteController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateDriverRoute command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
        [HttpDelete]
        [Route("{name}")]
        public async Task<IActionResult> DeleteAsync(string name)
        {
            var command = new DeleteDriverRoute
            {
                Name = name,
            };
            await DispatchAsync(command);

            return NoContent();
        }
    }
}
