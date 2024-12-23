using DataAccess.Abstract;
using Entity.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dal
{
    public class ClientDal : EntityRepositoryBase<Client, TodoContext>, IClientDal
    {
        private readonly TodoContext _context;
        public ClientDal(TodoContext context) : base(context)
        {
            _context = context;
        }

        public Task<Client> GetByUserIdAsync(long userId)
        {
            return _context.Set<Client>().FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
