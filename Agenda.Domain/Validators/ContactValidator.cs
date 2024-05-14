using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using FluentValidation;

namespace Agenda.Domain.Validators
{
    public class ContactValidator : AbstractValidator<ContactInput>
    {
        public ContactValidator() 
        {
            RuleFor(contact => contact.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(contact => contact.Surname)
                .NotNull()
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(contact => contact.CPF)
                .NotNull()
                .NotEmpty()
                .MaximumLength(11)
                .Must(ValidateCpf)
                .WithMessage("Invalid CPF.");

            RuleFor(contact => contact.Email)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(150)
                .EmailAddress();

            RuleFor(contact => contact.UserId)
                .NotNull()
                .NotEmpty();

        }

        private bool ValidateCpf(string cpf)
        {
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
