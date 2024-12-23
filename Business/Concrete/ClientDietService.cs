using Business.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Domain;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClientDietService : IClientDietService
    {   
        private readonly IClientDietDal _clientDietDal;
        public ClientDietService(IClientDietDal clientDietDal)
        {
            _clientDietDal = clientDietDal;
        }
        public async Task<IResult> AddAsync(ClientDiet clientDiet)
        {
            var result = await _clientDietDal.AddAsync(clientDiet);

            if (result is not null)
                return new SuccessResult(Messages.Success);

            return new ErrorResult(Messages.Error);
        }
        public async Task<IDataResult<ClientDiet>> GetByIdAsync(int id)
        {
            var result = await _clientDietDal.GetByIdAsync(id);

            if (result is not null)
                return new SuccessDataResult<ClientDiet>(Messages.Success);

            return new ErrorDataResult<ClientDiet>(Messages.Error);
        }
        public async Task<IResult> DeleteAsync(int id)
        {
            await _clientDietDal.DeleteAsync(id);
            return new SuccessResult(Messages.Success);
        }

        public async Task<IResult> UpdateAsync(ClientDiet clientDiet)
        {
            var result = await _clientDietDal.UpdateAsync(clientDiet);
            return new SuccessDataResult<ClientDiet>(result);
        }
    }
}
