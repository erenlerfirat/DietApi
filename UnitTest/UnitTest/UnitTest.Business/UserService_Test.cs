using Business.Concrete;
using Core.Abstract;
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
        }
        
    }
}
