using Entity.Abstract;

namespace Entity.Dtos
{
    public class UserPasswordResetRequest : IDto
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string ResetKey { get; set; }
        public string NewPassword { get; set; }
    }
}
