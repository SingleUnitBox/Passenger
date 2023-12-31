﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class PassengerNode
    {
        public Node Node { get; protected set; }
        public Passenger Passenger { get; protected set; }

        protected PassengerNode() { }
        public PassengerNode(Passenger passenger, Node node)
        {
            Passenger = passenger;
            Node = node;
        }
        public static PassengerNode Create(Passenger passenger, Node node)
            => new PassengerNode(passenger, node);
    }
}
