using Passenger.Infrastructure.Commands.Drivers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class CreateDriver : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
        public DriverVehicle Vehicle { get; set; }

    }
}
