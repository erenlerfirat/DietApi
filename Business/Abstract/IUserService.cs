using Core.Entity.Concrete;
using Core.Utilities.Results;
using Entity.Domain;
using Entity.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<User>> GetByMailAsync(string email); 
        Task<IResult> RegisterAsync(UserForRegisterDto user);
        Task<IResult> UpdateAsync(User user);
        Task<IResult> ChangePassword(UserPasswordChangeRequest request);
        Task<IResult> ForgotPassword(UserPasswordResetRequest request);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<User>> GetByIdAync(long id);
        Task<IDataResult<AuthenticateResponse>> Authenticate(AuthenticateRequest request);        
    }
}
