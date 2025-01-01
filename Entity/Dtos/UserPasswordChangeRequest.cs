using Entity.Abstract;

namespace Entity.Dtos
{
    public class UserPasswordChangeRequest : IDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Email { get; set; }
    }
}
