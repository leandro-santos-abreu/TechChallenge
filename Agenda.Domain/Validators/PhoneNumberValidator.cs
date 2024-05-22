using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using FluentValidation;

namespace Agenda.Domain.Validators
{
    public class PhoneNumberValidator : AbstractValidator<PhoneNumberInput>
    {
        public PhoneNumberValidator()
        {
            RuleFor(phoneNumber => phoneNumber.AreaCode)
                .NotEmpty()
                .WithMessage("Field 'AreaCode' Needs to Be Filed")
                .Length(2)
                .WithMessage("Field 'AreaCode' Needs to Have It's Lenght Equals To 2 Characters");

            RuleFor(phoneNumber => phoneNumber.CellPhone)
                .NotEmpty()
                .WithMessage("Field 'CellPhone' Needs to Be Filed")
                .Length(9)
                .WithMessage("Field 'CellPhone' Needs to Have It's Lenght Equals To 9 Characters");

            RuleFor(phoneNumber => phoneNumber.ContactId)
                .NotEmpty()
                .WithMessage("Field 'ContactId' Needs to Be Filed");
        }
    }
}
