using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherWebApi.EndToEndTests
{

    public class PhoneControllerTests
    {

        ////localhost:7225/Phone/1
        //[Fact]
        //public void FirstTestOnGet()
        //{
        //    var client = _factory.CreateClient();

        //    var response = client.GetAsync("/Phone/1");
        //}
        [Fact]
        public async void FirstTestOnGet()
        {
            var app = new AnotherWebApiApp();
            var client = app.CreateClient();

            var response = await client.GetAsync("/Phone/1");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
        }
    }
}
