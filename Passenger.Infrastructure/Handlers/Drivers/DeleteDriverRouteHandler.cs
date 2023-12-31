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
    public class DeleteDriverRouteHandler : ICommandHandler<DeleteDriverRoute>
    {
        private readonly IDriverRouteService _driverRouteService;

        public DeleteDriverRouteHandler(IDriverRouteService driverRouteService)
        {
            _driverRouteService = driverRouteService;
        }
        public async Task HandleAsync(DeleteDriverRoute command)
        {
            await _driverRouteService.DeleteAsync(command.UserId, command.Name);
        }
    }
}
