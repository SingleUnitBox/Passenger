using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{  
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        public RouteService(IRouteRepository routeRepositry,
            IMapper mapper)
        {
            _routeRepository = routeRepositry;
            _mapper = mapper;
        }
        public async Task CreateAsync(Route route)
        {
            await _routeRepository.AddAsync(route);
        }

        public async Task<IEnumerable<RouteDto>> GetAllAsync()
        {
            var routes = await _routeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Route>, IEnumerable<RouteDto>>(routes);
        }

        public Task<RouteDto> GetAsync(Guid routeId)
        {
            throw new NotImplementedException();
        }

        public async Task<RouteDto> GetByNameAsync(string name)
        {
            var route = await _routeRepository.GetByNameAsync(name);
            return _mapper.Map<Route, RouteDto>(route);
        }

    }
}
