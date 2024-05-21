using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using FluentValidation;

namespace Agenda.Domain.Validators
{
    public class ContactValidator : AbstractValidator<ContactInput>
    {
        public ContactValidator() 
        {
            RuleFor(contact => contact.Name)
                .NotEmpty()
                .WithMessage("Field 'Name' Needs to Be Filed")
                .MaximumLength(150)
                .WithMessage("Field 'Name' Needs to Have It's Lenght Equal Or Lower Than 150 Characters");

            RuleFor(contact => contact.Surname)
                .NotEmpty()
                .WithMessage("Field 'Surname' Needs to Be Filed")
                .MaximumLength(150)
                .WithMessage("Field 'Surname' Needs to Have It's Lenght Equal Or Lower Than 150 Characters");

            RuleFor(contact => contact.CPF)
                .NotEmpty()
                .WithMessage("Field 'CPF' Needs to Be Filed")
                .Length(11)
                .WithMessage("Field 'CPF' Is Invalid")
                .Must(ValidateCpf)
                .WithMessage("Field 'CPF' Is Invalid");

            RuleFor(contact => contact.Email)
                .NotEmpty()
                .WithMessage("Field 'Email' Needs to Be Filed")
                .MinimumLength(8)
                .WithMessage("Field 'Email' Needs to Have It's Lenght Equal Or Higher Than 8 Characters")
                .MaximumLength(150)
                .WithMessage("Field 'Email' Needs to Have It's Lenght Equal Or Lower Than 150 Characters")
                .EmailAddress()
                .WithMessage("Field 'Email' Is Invalid");

            RuleFor(contact => contact.UserId)
                .NotEmpty()
                .WithMessage("Field 'UserId' Needs to Be Filed");

        }

        private bool ValidateCpf(string cpf)
        {
            if (cpf is null)
                return false;

            int[] multiplier = [10, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] secondMultiplier = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string auxCpf = cpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(auxCpf[i].ToString()) * multiplier[i];

            int remainder = sum % 11;
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            string digito = remainder.ToString();
            auxCpf = auxCpf + digito;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(auxCpf[i].ToString()) * secondMultiplier[i];

            remainder = sum % 11;
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            digito = digito + remainder.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
