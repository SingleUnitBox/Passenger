using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    public class DriverController : ApiControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(ICommandDispatcher commandDispatcher,
            IDriverService driverService) : base(commandDispatcher)
        {
            _driverService = driverService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var drivers = await _driverService.GetAllAsync();
            return Json(drivers);

        }

        [HttpPost]
        public async Task<IActionResult> CreateDriverAsync([FromBody] CreateDriver command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}
