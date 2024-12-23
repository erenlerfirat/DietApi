using DataAccess.Abstract;
using Entity.Domain;

namespace DataAccess.Concrete.Dal
{
    public class MealDal : EntityRepositoryBase<Meal, TodoContext>, IMealDal
    {
        public MealDal(TodoContext context) : base(context)
        {

        }

    }
}
