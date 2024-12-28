using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Abstract;
using Core.Aspects.Autofac.Validation;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Domain;
using Entity.Dtos;
using System;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IHashHelper _hashHelper;
        private readonly IJwtHelper _jwtHelper;
        private readonly IRoleHelper _roleHelper;

        public UserService(IUserDal userDal,IJwtHelper jwtHelper ,IHashHelper hashHelper, IRoleHelper roleHelper)
        {
            _userDal = userDal;
            _hashHelper = hashHelper;
            _jwtHelper = jwtHelper;
            _roleHelper = roleHelper;
        }

        [ValidationAspect(typeof(UserRegisterValidator))]
        public async Task<IResult> RegisterAsync(UserForRegisterDto userDto)
        {
            var isUserExist = await _userDal.AnyAsync(x => x.Email == userDto.Email);

            if (isUserExist)
                return new ErrorResult(Messages.UserAlreadyExists);

            string passwordHash = _hashHelper.Encrypt(userDto.Password);

            var userRole = _roleHelper.GetRole(userDto.Role);

            var user = new User
            {
                Email = userDto.Email,
                Phone = userDto.Phone,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PasswordHash = passwordHash,
                FailedTryCount = 0,
                UserRoleId = (long)userRole,
                IsDeleted = false,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            };

            var result = await _userDal.AddAsync(user);

            if(result is not null)
             return new SuccessResult(Messages.Success);

            return new ErrorResult(Messages.Error);
        }

        public async Task<IDataResult<AuthenticateResponse>> Authenticate(AuthenticateRequest request)
        {
            var user = await _userDal.FirstOrDefaultAsync(x => x.Email == request.Email);

            bool isPasswordValid = _hashHelper.Validate(request.Password,user.PasswordHash);
                        
            if (!isPasswordValid) return new ErrorDataResult<AuthenticateResponse>(Messages.Error);

            var tokenRequest = new UserTokenRequest
            {
                Email = request.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserId = user.Id,
            };
            string token = _jwtHelper.CreateToken(tokenRequest);

            return new SuccessDataResult<AuthenticateResponse>(new AuthenticateResponse(token));
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            await _userDal.DeleteAsync(id);
            return new SuccessResult(Messages.Success);
        }

        public async Task<IDataResult<User>> GetByIdAync(long id)
        {
            var result = await _userDal.GetByIdAsync(id);
            return new SuccessDataResult<User>(result);
        }

        public async Task<IDataResult<User>> GetByMailAsync(string email)
        {
            var result = await _userDal.FirstOrDefaultAsync(x => x.Email == email);
            return new SuccessDataResult<User>(result);
        }

        public async Task<IResult> UpdateAsync(User user)
        {
            var result = await _userDal.UpdateAsync(user);
            return new SuccessDataResult<User>(result);
        }
    }
}
