using Business.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Domain;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DietService : IDietService
    {
        private readonly IDietDal _dietDal;
        public DietService(IDietDal dietDal)
        {
                _dietDal = dietDal;
        }
        public async Task<IResult> AddAsync(Diet client)
        {
            var result = await _dietDal.AddAsync(client);

            if (result is not null)
                return new SuccessResult(Messages.Success);

            return new ErrorResult(Messages.Error);
        }
        public async Task<IDataResult<Diet>> GetByIdAsync(int id)
        {
            var result = await _dietDal.GetByIdAsync(id);

            if (result is not null)
                return new SuccessDataResult<Diet>(Messages.Success);

            return new ErrorDataResult<Diet>(Messages.Error);
        }
        public async Task<IResult> DeleteAsync(int id)
        {
            await _dietDal.DeleteAsync(id);
            return new SuccessResult(Messages.Success);
        }

        public async Task<IResult> UpdateAsync(Diet client)
        {
            var result = await _dietDal.UpdateAsync(client);
            return new SuccessDataResult<Diet>(result);
        }
    }
}
