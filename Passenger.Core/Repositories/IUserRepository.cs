using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(string email);
        Task<User> GetAsync(Guid id);
        Task AddAsync(User user);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
