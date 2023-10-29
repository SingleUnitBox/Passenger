using FluentAssertions;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Commands.Drivers.Models;
using Passenger.Infrastructure.Commands.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class DriverControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task PostRequest_CreatesDriverAndReturnsNoContent()
        {
            var command = new CreateDriver
            {
                //UserId = Guid.Parse("bfbe16a5-164d-4a7c-8506-d51992f74be8"),
                UserId = Guid.NewGuid(),
                Vehicle = new DriverVehicle()
                { 
                    Brand = "bmw",
                    Name = "z3",
                    //Seats = 4
                }
            };

            //var app = new PassengerApp();
            //var client = app.CreateClient();

            var payload = GetPayload(command);
            var response = await Client.PostAsync("driver", payload);
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
