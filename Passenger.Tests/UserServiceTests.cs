using AutoMapper;
using Moq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services;
using Xunit;

namespace Passenger.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task RegisterAsync_ShouldInvokeAddAsyncOnRepository()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockEncrypter = new Mock<IEncrypter>();

            var userService = new UserService(mockUserRepository.Object, mockEncrypter.Object, mockMapper.Object);

            await userService.RegisterAsync("user@gmail.com", "user", "password");

            mockUserRepository.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
