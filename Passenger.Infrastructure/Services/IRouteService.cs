using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IRouteService : IService
    {
        Task<RouteDto> GetAsync(Guid routeId);
        Task<IEnumerable<RouteDto>> GetAllAsync();
        Task CreateAsync(Route route);
    }
}
