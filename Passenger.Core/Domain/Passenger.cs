﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class Passenger
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public Node NodeAddress { get; protected set; }
    }
}
