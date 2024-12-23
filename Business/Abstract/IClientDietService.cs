using Core.Utilities.Results;
using Entity.Domain;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IClientDietService
    {
        Task<IResult> AddAsync(ClientDiet client);
        Task<IDataResult<ClientDiet>> GetByIdAsync(int id);
        Task<IResult> UpdateAsync(ClientDiet client);
        Task<IResult> DeleteAsync(int id);
    }
}
