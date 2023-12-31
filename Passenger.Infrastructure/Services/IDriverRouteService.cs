﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverRouteService
    {
        Task AddAsync(Guid userId, string name,
            double startLatitude, double startLongitude,
            double endLatitude, double endLongitude);
        Task DeleteAsync(Guid userId, string name);
    }
}
