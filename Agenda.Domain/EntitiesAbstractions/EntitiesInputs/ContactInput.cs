namespace Agenda.Domain.EntitiesAbstractions.EntitiesInputs
{
    public class ContactInput(string name, string surname, string email, string cPF, Guid userId, ICollection<PhoneNumberInput> phoneNumbers)
    {
        public string Name { get; set; } = name;
        public string Surname { get; set; } = surname;
        public string Email { get; set; } = email;
        public string CPF { get; set; } = cPF;
        public Guid UserId { get; set; } = userId;
        public virtual ICollection<PhoneNumberInput> PhoneNumbers { get; set; } = phoneNumbers;
    }
}
