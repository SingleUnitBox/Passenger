using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Extensions;

namespace Passenger.Api.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public LoginController(ICommandDispatcher commandDispatcher,
            IMemoryCache memoryCache) : base(commandDispatcher)
        {
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] LoginUser loginUserCommand)
        {
            loginUserCommand.TokenId = Guid.NewGuid();
            await DispatchAsync(loginUserCommand);
            var jwt = _memoryCache.GetJwt(loginUserCommand.TokenId);

            return Json(jwt);
        }
    }
}
