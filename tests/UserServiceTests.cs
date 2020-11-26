

using AutoMapper;
using Hermes.Identity.Auth;
using Hermes.Identity.Entities;
using Hermes.Identity.Mongo.Documents;
using Hermes.Identity.Repository;
using Hermes.Identity.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Hermes.Identity.Tests.Unit
{
    public class UserServiceTests
    {
        [Fact]
        public async Task update_should_invoke_update_async_on_repository()
        {
            var userRepository = new Mock<ICosmosRepository>();
            userRepository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new User());
            var mapper = new Mock<IMapper>();
            var passwordService = new Mock<IPasswordService>();
            var userService = new UserService(userRepository.Object, passwordService.Object, mapper.Object);
            await userService.Update(Guid.Parse("75994b75-5412-419e-8fb6-bd22e930fca8"), "Krissss", "krzysztof2.lach@icloud.com", "password");
            userRepository.Verify(x => x.Update(It.IsAny<UserDocument>()), Times.Once);
        }
    }
}
