using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Repositories
{
    public interface IUserRepository
    {
        User Get(string email);
        User Get(Guid id);
        void Add(User user);
        void Remove(Guid id);
        void Update(User user);
        IEnumerable<User> GetAll();
    }
}
