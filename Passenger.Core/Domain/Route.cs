using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class Route
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Node StartNode { get; protected set; }
        public Node EndNode { get; protected set;}
        public double Distance { get; protected set; }
        protected Route()
        {
            Id = Guid.NewGuid();
        }
        public Route(string name, Node startNode, Node endNode, double distance)
        {
            Name = name;
            StartNode = startNode;
            EndNode = endNode;
            Distance = distance;
        }
        public static Route Create(string name, Node startNode, Node endNode, double distance)
            => new Route(name, startNode, endNode, distance);
    }
}
