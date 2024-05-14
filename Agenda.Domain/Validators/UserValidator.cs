using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using FluentValidation;

namespace Agenda.Domain.Validators
{
    public class UserValidator : AbstractValidator<UserInput>
    {
        public UserValidator() 
        {
            RuleFor(user => user.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(150);
            RuleFor(user => user.UserName).NotNull().NotEmpty().MaximumLength(150);
        }
    }
}
