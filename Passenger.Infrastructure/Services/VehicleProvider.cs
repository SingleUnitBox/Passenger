﻿using Microsoft.Extensions.Caching.Memory;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public class VehicleProvider : IVehicleProvider
    {
        private readonly IMemoryCache _memoryCache;
        private readonly static string CacheKey = "vehicles";
        private static readonly IDictionary<string, IEnumerable<VehicleDetails>> availableVehicles =
            new Dictionary<string, IEnumerable<VehicleDetails>>
            {
                ["Audi"] = new List<VehicleDetails>
                {
                    new VehicleDetails("RS8", 5),
                },
                ["BMW"] = new List<VehicleDetails>
                {
                    new VehicleDetails("i8", 3),
                    new VehicleDetails("e36", 5),
                },
                ["Ford"] = new List<VehicleDetails>
                {
                    new VehicleDetails("Fiest", 5),
                },
                ["Skoda"] = new List<VehicleDetails>
                {
                    new VehicleDetails("Octavia", 5),
                    new VehicleDetails("Rapid", 5),
                },
                ["VW"] = new List<VehicleDetails>
                {
                    new VehicleDetails("Passat", 5),
                }
            };

        public VehicleProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<VehicleDto> GetAsync(string brand, string name)
        {
            if (!availableVehicles.ContainsKey(brand))
            {
                throw new Exception($"Vehicle brand {brand} is not available.");
            }
            var vehicles = availableVehicles[brand];
            var vehicle = vehicles.SingleOrDefault(x => x.Name == name);
            if (vehicle == null)
            {
                throw new Exception($"Vehicle: {name}, for brand {brand} does not exist.");
            }

            return await Task.FromResult(new VehicleDto
            {
                Brand = brand,
                Name = vehicle.Name,
                Seats = vehicle.Seats,
            });
        }
        public async Task<IEnumerable<VehicleDto>> BrowseAsync()
        {
            var vehicles = _memoryCache.Get<IEnumerable<VehicleDto>>(CacheKey);
            if (vehicles == null)
            {
                Console.WriteLine("from database");
                vehicles = await GetAllAsync();
                _memoryCache.Set(CacheKey, vehicles);
            }
            else
            {
                Console.WriteLine("from cache");
            }
            return vehicles;
        }
        public async Task<IEnumerable<VehicleDto>> GetAllAsync()
            => await Task.FromResult(availableVehicles.GroupBy(x => x.Key)
                .SelectMany(g => g.SelectMany(v => v.Value.Select(c => new VehicleDto
                {
                    Brand = v.Key,
                    Name = c.Name,
                    Seats = c.Seats,
                }))));
        private class VehicleDetails
        {
            public string Name { get; }
            public int Seats { get; }
            public VehicleDetails(string name, int seats)
            {
                Name = name;
                Seats = seats;
            }
        }
    }
}
