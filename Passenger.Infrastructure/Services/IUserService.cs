using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetAsync(string email);
        Task RegisterAsync(Guid userId, string email, string username, string password, string role);
        Task LoginAsync(string email, string password);
    }
}
