
namespace Passenger.Core.Domain
{
    public class Driver
    {
        private ISet<Route> _routes = new HashSet<Route>();
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }       
        public Vehicle Vehicle { get; protected set; }
        public IEnumerable<Route> Routes
        {   get { return _routes; }
            set { _routes = new HashSet<Route>(value); }
        }
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
        public void AddRoute(string name, Node start, Node end, double distance)
        {
            var route = _routes.SingleOrDefault(x => x.Name == name);
            if (route != null)
            {
                throw new Exception($"Route with name {name} already exists for driver {Name}");
            }
            _routes.Add(Route.Create(name, start, end, distance));
            UpdatedAt = DateTime.UtcNow;
        }

        public void DeleteRoute(string name)
        {
            var route = _routes.SingleOrDefault(x => x.Name == name);
            if (route == null)
            {
                throw new Exception($"Route with name {name} for driver {Name} cannot be found.");
            }
            _routes.Remove(route);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
