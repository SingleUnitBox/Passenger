using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
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

    public class AccountControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task GivenCurrentPasswordAndNewPassword_ChangesPassword()
        {           
            var command = new ChangeUserPassword
            {
                CurrentPassword = "password",
                NewPassword = "password"
            };
            
            //var app = new PassengerApp();
            //var client = app.CreateClient();

            var payload = GetPayload(command);
            var response = await Client.PutAsync("account/password", payload);
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task GetUserTest()
        {
            
            var response = await Client.GetAsync("user/user@gmail.com");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }
        //protected static StringContent GetPayload(object data)
        //{
        //    var json = JsonConvert.SerializeObject(data);

        //    return new StringContent(json, Encoding.UTF8, "application/json");
        //}
    }
}
