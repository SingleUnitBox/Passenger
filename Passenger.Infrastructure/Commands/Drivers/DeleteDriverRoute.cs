using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class DeleteDriverRoute : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
