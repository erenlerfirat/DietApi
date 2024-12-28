using Entity.Domain;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(t => t.Id).NotEmpty().NotNull();
            RuleFor(t => t.FirstName).NotEmpty().NotNull();
            RuleFor(t => t.LastName).NotEmpty().NotNull();
            RuleFor(t => t.Email).NotEmpty().NotNull();
            RuleFor(t => t.Phone).NotEmpty().NotNull();
            RuleFor(t => t.PasswordHash).NotEmpty().NotNull();
            
        }
        
    }
}
