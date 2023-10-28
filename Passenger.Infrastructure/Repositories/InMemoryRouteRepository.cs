using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryRouteRepository : IRouteRepository
    {
        private static ISet<Route> _routes = new HashSet<Route>();
        public async Task AddAsync(Route route)
        {
            _routes.Add(route);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Route>> GetAllAsync()
            => await Task.FromResult(_routes);

        public async Task<Route> GetAsync(Guid routeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Route> GetByNameAsync(string name)
            => await Task.FromResult(_routes.FirstOrDefault(r => r.Name == name));

        public async Task UpdateAsync(Route route)
        {
            throw new NotImplementedException();
        }
    }
}
