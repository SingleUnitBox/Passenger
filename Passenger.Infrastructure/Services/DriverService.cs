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
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public async Task<DriverDto> GetAsync(Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);
            DriverDto driverDto = new()
            {
                UserId = driver.UserId,
            };
            return driverDto;
        }

        public async Task CreateAsync(Guid userId, string brand, string name, int seats)
        {
            var user = (await _driverRepository.GetAllAsync())
                .SingleOrDefault(x => x.UserId == userId);
            if (user != null)
            {
                throw new Exception($"Driver with Id {userId} already exists.");
            }
            Vehicle vehicle = Vehicle.Create(brand, name, seats);
            var driver = new Driver(userId, vehicle);
            await _driverRepository.AddAsync(driver);
        }
    }
}
