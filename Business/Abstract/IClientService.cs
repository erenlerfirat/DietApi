using Core.Utilities.Results;
using Entity.Domain;
using Entity.Dtos;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IClientService
    {
        Task<IResult> AddAsync(ClientAddRequest client);
        Task<IDataResult<Client>> GetByIdAsync(long id);
        Task<IDataResult<Client>> GetByUserIdAsync(long userId);
        Task<IResult> UpdateAsync(Client client);
        Task<IResult> DeleteAsync(long id);
    }
}
