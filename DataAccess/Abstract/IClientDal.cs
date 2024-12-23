using Entity.Domain;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IClientDal : IEntityRepository<Client>
    {
        Task<Client> GetByUserIdAsync(long userId);
    }
}
