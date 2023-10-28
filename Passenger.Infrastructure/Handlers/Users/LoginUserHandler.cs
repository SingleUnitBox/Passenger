using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Extensions;
using Passenger.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Passenger.Infrastructure.Handlers.Users
{
    public class LoginUserHandler : ICommandHandler<LoginUser>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _memoryCache;

        public LoginUserHandler(IUserService userService,
            IJwtHandler jwtHandler,
            IMemoryCache memoryCache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _memoryCache = memoryCache;
        }

        public async Task HandleAsync(LoginUser command)
        {
            await _userService.LoginAsync(command.Email, command.Password);
            var user = await _userService.GetAsync(command.Email);
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            _memoryCache.SetJwt(command.TokenId, jwt);
        }
    }
}
