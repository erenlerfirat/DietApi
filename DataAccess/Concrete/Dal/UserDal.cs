using Core.Entity.Concrete;
using DataAccess.Abstract;
using Entity.Domain;

namespace DataAccess.Concrete.Dal
{
    public class UserDal : EntityRepositoryBase<User, TodoContext>, IUserDal
    {
        private readonly TodoContext _context;
        public UserDal(TodoContext context) : base(context)
        {
            _context = context;
        }


    }
}
