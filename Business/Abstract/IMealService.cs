using Core.Utilities.Results;
using Entity.Domain;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMealService
    {
        Task<IResult> AddAsync(Meal meal);
        Task<IDataResult<Meal>> GetByIdAsync(int id);
        Task<IResult> UpdateAsync(Meal meal);
        Task<IResult> DeleteAsync(int id);
    }
}
