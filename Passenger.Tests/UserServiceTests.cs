using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Configuration.UserSecrets;
using Moq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;
using Xunit;

namespace Passenger.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task ValidRegisteredEmail_ReturnsExistingUser()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockEncrypter = new Mock<IEncrypter>();

            var email = "user1@test.com";
            User user = new(Guid.NewGuid(), email, "user", "password", "salt", "role");

            mockUserRepository.Setup(x => x.GetAsync(email))
                .ReturnsAsync(user);

            //mapper doesn't work properly for some reason
            mockMapper.Setup(x => x.Map<User, UserDto>(user))
                .Returns(new UserDto() { Email = email });

            var userService = new UserService(mockUserRepository.Object, mockEncrypter.Object, mockMapper.Object);
           
            var userFromService = await userService.GetAsync(email);

            userFromService.Email.Should().Be(email);
        }
        [Fact]
        public async Task RegisterAsync_ShouldInvokeAddAsyncOnRepository()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockEncrypter = new Mock<IEncrypter>();

            var userService = new UserService(mockUserRepository.Object, mockEncrypter.Object, mockMapper.Object);

            var userId = Guid.NewGuid();
            await userService.RegisterAsync(userId, "user1@test.com", "user1", "secret", "user");

            mockUserRepository.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

    }
}
