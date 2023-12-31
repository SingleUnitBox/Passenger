﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;
using System.Text.Json.Serialization;

namespace Passenger.Api.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService,
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            return Json(users);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetAsync(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        [HttpPost("")]
        public async Task<IActionResult> PostAsync([FromBody] CreateUser command)
        {
            await DispatchAsync(command);

            return Created($"users/{command.Email}", null);
        }
    }
}
