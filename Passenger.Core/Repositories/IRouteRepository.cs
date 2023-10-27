using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Repositories
{
    public interface IRouteRepository : IRepository
    {
        Task<Route> GetAsync(Guid routeId);
        Task AddAsync(Route route);
        Task UpdateAsync(Route route);
        Task<IEnumerable<Route>> GetAllAsync();
    }
}
