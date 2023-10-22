using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.DTO
{
    public class JwtDto
    {
        public string Token { get; set; }
        public long Expiry { get; set; }
    }
}
