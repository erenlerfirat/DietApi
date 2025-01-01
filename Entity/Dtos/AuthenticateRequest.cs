using Entity.Abstract;

namespace Entity.Dtos
{
    public class AuthenticateRequest : IDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
