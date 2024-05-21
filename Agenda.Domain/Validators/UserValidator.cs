using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using FluentValidation;

namespace Agenda.Domain.Validators
{
    public class UserValidator : AbstractValidator<UserInput>
    {
        public UserValidator() 
        {
            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Field 'Password' Needs to Be Filed")
                .MinimumLength(8)
                .WithMessage("Field 'Password' Needs to Have It's Lenght Equal Or Higher Than 8 Characters")
                .MaximumLength(150)
                .WithMessage("Field 'Password' Needs to Have It's Lenght Equal Or Lower Than 150 Characters");
            RuleFor(user => user.UserName)
                .NotEmpty()
                .WithMessage("Field 'UserName' Needs to Be Filed")
                .MinimumLength(8)
                .WithMessage("Field 'UserName' Needs to Have It's Lenght Equal Or Higher Than 8 Characters")
                .MaximumLength(150)
                .WithMessage("Field 'UserName' Needs to Have It's Lenght Equal Or Lower Than 150 Characters");
        }
    }
}
