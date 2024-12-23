using DataAccess.Abstract;
using Entity.Domain;

namespace DataAccess.Concrete.Dal
{
    public class DietDal : EntityRepositoryBase<Diet, TodoContext>, IDietDal
    {
        public DietDal(TodoContext context) : base(context)
        {

        }

    }
}
