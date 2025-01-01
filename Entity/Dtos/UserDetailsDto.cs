using Entity.Abstract;

namespace Entity.Dtos
{
    public class UserDetailsDto : IDto
    {
        public long UserId { get; set; }
        public long Role { get; set; }
    }
}
