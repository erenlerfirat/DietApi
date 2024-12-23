using Core.Utilities.Results;
using Entity.Domain;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDietService
    {
        Task<IResult> AddAsync(Diet diet);
        Task<IDataResult<Diet>> GetByIdAsync(int id);
        Task<IResult> UpdateAsync(Diet user);
        Task<IResult> DeleteAsync(int id);
    }
}
