﻿
namespace Passenger.Core.Domain
{
    public class Driver
    {
        public Guid UserId { get; protected set; }
        public string Name { get; set; }
        public Vehicle Vehicle { get; protected set; }
        public IEnumerable<Route> Routes { get; protected set; }
        public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Driver()
        {
            
        }
        public Driver(User user)
        {
            UserId = user.Id;
            Name = user.UserName;
        }

        public void SetVehicle(Vehicle vehicle)
        {
            Vehicle = vehicle;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
