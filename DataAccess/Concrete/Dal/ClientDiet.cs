using DataAccess.Abstract;
using Entity.Domain;

namespace DataAccess.Concrete.Dal
{
    public class ClientDietDal : EntityRepositoryBase<ClientDiet, TodoContext>, IClientDietDal
    {
        public ClientDietDal(TodoContext context) : base(context)
        {

        }

    }
}
