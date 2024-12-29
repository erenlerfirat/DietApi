using Business.Concrete;
using Core.Abstract;
using Core.Constants;
using Core.Helpers;
using DataAccess.Abstract;
using Entity.Domain;
using Entity.Dtos;
using Moq;
using System.Linq.Expressions;

namespace UnitTest.UnitTest.Business
{
    
    public class UserService_Test
    {

        [Fact]
        public async Task Register_Fail_When_UserExist_ExpectedFalse()
        {
            var userDal = new Mock<IUserDal>();

            userDal.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<User, bool>>>())).Returns(Task.FromResult(true));

            var userService = new UserService(userDal.Object, new Mock<IJwtHelper>().Object, new Mock<IHashHelper>().Object, new Mock<IRoleHelper>().Object);
            
            var result = await userService.RegisterAsync(new UserForRegisterDto() { Email = "firat" });

            Assert.False(result.Success);
            Assert.True(result.Message == Messages.UserAlreadyExists);
        }

        [Fact]
        public async Task Register_Fail_When_AdminRegister_ExpectedFalse()
        {
            var userDal = new Mock<IUserDal>();
            userDal.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<User, bool>>>())).Returns(Task.FromResult(false));
            userDal.Setup(x => x.AddAsync(It.IsAny<User>())).Returns(Task.FromResult(new User()));

            var hashHelper = new Mock<IHashHelper>();
            hashHelper.Setup(x => x.Encrypt(It.IsAny<string>())).Returns(string.Empty);

            var userService = new UserService(userDal.Object, new Mock<IJwtHelper>().Object, hashHelper.Object, new RoleHelper());

            var result = await userService.RegisterAsync(new UserForRegisterDto());

            Assert.False(result.Success);
            Assert.True(result.Message == Messages.RoleTypeError);
        }

        [Fact]
        public async Task Register_Success_ExpectedTrue()
        {
            var userDal = new Mock<IUserDal>();
            userDal.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<User, bool>>>())).Returns(Task.FromResult(false));
            userDal.Setup(x => x.AddAsync(It.IsAny<User>())).Returns(Task.FromResult(new User()));

            var hashHelper = new Mock<IHashHelper>();
            hashHelper.Setup(x => x.Encrypt(It.IsAny<string>())).Returns(string.Empty);

            var roleHelper = new Mock<IRoleHelper>();
            roleHelper.Setup(x => x.GetRole(It.IsAny<string>())).Returns(UserRoleEnum.client);

            var userService = new UserService(userDal.Object, new Mock<IJwtHelper>().Object, hashHelper.Object, roleHelper.Object);

            var result = await userService.RegisterAsync(new UserForRegisterDto());

            Assert.True(result.Success);
        }

    }
}
