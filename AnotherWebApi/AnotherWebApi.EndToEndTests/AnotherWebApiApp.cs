using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherWebApi.EndToEndTests
{
    //internal class AnotherWebApiApp : IClassFixture<WebApplicationFactory<Program>>
    //{
    //    private readonly WebApplicationFactory<Program> _factory;
    //    public AnotherWebApiApp(WebApplicationFactory<Program> factory)
    //    {
    //        _factory = factory;
    //    }

    //}
    internal class AnotherWebApiApp : WebApplicationFactory<Program>
    {

    }
}

