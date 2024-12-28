using Entity.Domain;
using Entity.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(t => t.FirstName).NotEmpty().NotNull();
            RuleFor(t => t.LastName).NotEmpty().NotNull();
            RuleFor(t => t.Email).NotEmpty().NotNull();
            RuleFor(t => t.Phone).NotEmpty().NotNull();
            RuleFor(t => t.Password).NotEmpty().NotNull();            
        }        
    }
}
