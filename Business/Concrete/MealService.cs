using Business.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Domain;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MealService : IMealService
    {
        private readonly IMealDal _mealDal;
        public MealService(IMealDal mealDal)
        {
            _mealDal = mealDal;
        }
        public async Task<IResult> AddAsync(Meal meal)
        {
            var result = await _mealDal.AddAsync(meal);

            if (result is not null)
                return new SuccessResult(Messages.Success);

            return new ErrorResult(Messages.Error);
        }
        public async Task<IDataResult<Meal>> GetByIdAsync(int id)
        {
            var result = await _mealDal.GetByIdAsync(id);

            if (result is not null)
                return new SuccessDataResult<Meal>(Messages.Success);

            return new ErrorDataResult<Meal>(Messages.Error);
        }
        public async Task<IResult> DeleteAsync(int id)
        {
            await _mealDal.DeleteAsync(id);
            return new SuccessResult(Messages.Success);
        }

        public async Task<IResult> UpdateAsync(Meal meal)
        {
            var result = await _mealDal.UpdateAsync(meal);
            return new SuccessDataResult<Meal>(result);
        }
    }
}
