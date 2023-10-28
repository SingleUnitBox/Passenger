using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.DTO
{
    public class RouteDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }
        public double Distance { get; set; }
    }
}
