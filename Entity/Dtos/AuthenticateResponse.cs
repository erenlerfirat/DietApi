using Entity.Abstract;
using Entity.Domain;

namespace Entity.Dtos
{
    public class AuthenticateResponse : IDto
    {
        public string Token { get; set; }


        public AuthenticateResponse( string token)
        {
            
            Token = token;
        }
    }
}
