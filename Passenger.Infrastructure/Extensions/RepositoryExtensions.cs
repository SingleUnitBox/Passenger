using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Driver> GetOrFailAsync(this IDriverRepository driverRepository, Guid userId)
        {
            var driver = await driverRepository.GetAsync(userId);
            if (driver == null)
            {
                throw new Exception($"Driver with Id {userId} cannot be found.");
            }
            return driver;
        }
        public static async Task<User> GetOrFailAsync(this IUserRepository userRepository, Guid userId)
        {
            var user = await userRepository.GetAsync(userId);
            if (user == null)
            {
                throw new Exception($"User with Id {userId} cannot be found.");
            }
            return user;
        }
    }
}
