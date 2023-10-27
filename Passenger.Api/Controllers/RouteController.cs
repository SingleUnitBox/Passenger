using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    public class RouteController : ApiControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(ICommandDispatcher commandDispatcher,
            IRouteService routeService) : base(commandDispatcher)
        {
            _routeService = routeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var routes = await _routeService.GetAllAsync();
            return Json(routes);
        }
    }
}
