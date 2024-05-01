using Agenda.Domain.Entities;

namespace Agenda.Domain.EntitiesAbstractions.EntitiesDto
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public Guid UserId { get; set; }
        public virtual ICollection<PhoneNumberDto>? PhoneNumbers { get; set; }

    }
}
