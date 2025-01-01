using Entity.Abstract;

namespace Entity.Dtos
{
    public class UserTokenRequest : IDto
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public short RoleType { get; set; }

    }
}
