using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    public class VehicleController : ApiControllerBase
    {
        private readonly IVehicleProvider _vehicleProvider;

        public VehicleController(ICommandDispatcher commandDispatcher,
            IVehicleProvider vehicleProvider) : base(commandDispatcher)
        {
            _vehicleProvider = vehicleProvider;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var vehicles = await _vehicleProvider.BrowseAsync();
            return Json(vehicles);
        }
    }
}
