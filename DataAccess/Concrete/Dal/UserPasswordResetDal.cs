using DataAccess.Abstract;
using Entity.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dal
{
    public class UserPasswordResetDal : EntityRepositoryBase<UserPasswordReset, TodoContext>, IUserPasswordResetDal
    {
        private readonly TodoContext _context;
        public UserPasswordResetDal(TodoContext context) : base(context)
        {
            _context = context;
        }
    }
}
