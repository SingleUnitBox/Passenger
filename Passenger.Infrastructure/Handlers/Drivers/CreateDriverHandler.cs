﻿using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Drivers
{
    public class CreateDriverHandler : ICommandHandler<CreateDriver>
    {
        private readonly IDriverService _driverService;

        public CreateDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public async Task HandleAsync(CreateDriver command)
        {
            await _driverService.CreateAsync(command.UserId, command.Vehicle.Brand, command.Vehicle.Name, command.Vehicle.Seats);
        }
    }
}
