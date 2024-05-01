namespace Agenda.Domain.EntitiesAbstractions.EntitiesInputs
{
    public class ContactInput
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public Guid UserId { get; set; }
        public virtual ICollection<PhoneNumberInput> PhoneNumbers { get; set;}
    }
}
