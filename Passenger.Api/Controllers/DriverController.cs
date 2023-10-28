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
            //throw new Exception("upssss");
            var drivers = await _driverService.GetAllAsync();
            return Json(drivers);

        }
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetAsync(Guid userId)
        {
            var driver = await _driverService.GetAsync(userId);
            if (driver == null)
            {
                return NotFound();
            }
            return Json(driver);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriverAsync([FromBody] CreateDriver command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
        [HttpDelete]
        [Route("me")]
        public async Task<IActionResult> DeleteAsync()
        {
            await DispatchAsync(new DeleteDriver());

            return NoContent();
        }
        [HttpPut("me")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateDriver command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
    }
}
