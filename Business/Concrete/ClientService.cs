using Business.Abstract;
using Core.Abstract;
using Core.Attributes.JWT;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Domain;
using Entity.Dtos;
using System;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [Authorize]
    public class ClientService : IClientService
    {
        private readonly IClientDal _clientDal;
        private readonly IJwtHelper _jwtHelper;
        public ClientService(IClientDal clientDal,IJwtHelper jwtHelper)
        {

                _clientDal = clientDal;
                _jwtHelper = jwtHelper;
        }
        
        public async Task<IResult> AddAsync(ClientAddRequest request)
        {
            
            var user = _jwtHelper.UserDetailsDto;

            long roleId = (long)UserRoleEnum.admin == user.Role ? request.UserId : user.UserId;

            Client client = new() 
            {  
                UserId = user.UserId,
                UserRoleId = roleId,
                Age = request.Age,
                Weight = request.Weight,
                Height = request.Height,
                Gender = request.Gender,
                IsDeleted = false,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            };
            var result = await  _clientDal.AddAsync(client);

            if (result is not null)
                return new SuccessResult(Messages.Success);

            return new ErrorResult(Messages.Error);
        }
        public async Task<IDataResult<Client>> GetByIdAsync(long id)
        {
            var result = await _clientDal.GetByIdAsync(id);

            if (result is not null)
                return new SuccessDataResult<Client>(Messages.Success);

            return new ErrorDataResult<Client>(Messages.Error);
        }
        public async Task<IResult> DeleteAsync(long id)
        {
            await _clientDal.DeleteAsync(id);
            return new SuccessResult(Messages.Success);
        }

        public async Task<IResult> UpdateAsync(Client client)
        {
            var result = await _clientDal.UpdateAsync(client);
            return new SuccessDataResult<Client>(result);
        }

        public async Task<IDataResult<Client>> GetByUserIdAsync(long userId)
        {
            var result = await _clientDal.GetByUserIdAsync(userId);

            if (result is not null)
                return new SuccessDataResult<Client>(result);

            return new ErrorDataResult<Client>(Messages.Error);
        }
    }
}
