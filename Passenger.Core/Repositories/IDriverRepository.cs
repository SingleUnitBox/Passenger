using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Repositories
{
    public interface IDriverRepository
    {
        Driver Get(Guid userId);
        void Add(Driver driver);
        void Update(Driver driver);
        IEnumerable<Driver> GetAll();
    }
}
