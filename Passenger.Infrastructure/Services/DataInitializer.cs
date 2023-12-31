﻿using Microsoft.Extensions.Logging;
using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly IDriverService _driverService;
        private readonly IRouteService _routeService;
        private readonly IDriverRouteService _driverRouteService;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(IUserService userService,
            IDriverService driverService,
            IRouteService routeService,
            IDriverRouteService driverRouteService,
            ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _driverService = driverService;
            _routeService = routeService;
            _driverRouteService = driverRouteService;
            _logger = logger;
        }
        public async Task SeedAsync()
        {
            _logger.LogTrace("Initializing data...");

            var tasks = new List<Task>();
            //users
            for (var i = 1; i <= 10; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}";

                tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com", username, "secret", "user"));
                tasks.Add(_driverService.CreateAsync(userId).ContinueWith(task =>
                {
                    if (task.Exception != null)
                    {
                        _logger.LogError($"Error creating driver for user {userId}: {task.Exception}");
                    }
                }));
                tasks.Add(_driverService.SetVehicleAsync(userId, "BMW", $"i{i}"));
                tasks.Add(_driverRouteService.AddAsync(userId, "default route", 1, 1, 2, 2));
                tasks.Add(_driverRouteService.AddAsync(userId, "job route", 11, 11, 21, 21));
            }
            //admin
            for (var i = 1; i <= 3; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";

                tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com", username, "secret", "admin"));
            }
            //routes
            for (var j = 1; j <= 5; j++)
            {
                var startNode = new Node($"StartStreet{j}", (double)j / 3, (double)j / 4);
                var endNode = new Node($"EndStreet{j}", (double)j / 7, (double)j / 15);
                tasks.Add(_routeService.CreateAsync(Route.Create($"route{j}", startNode, endNode, 1000)));
            }
            await Task.WhenAll(tasks);

            _logger.LogTrace("Data has been initialized.");

        }
    }
}
