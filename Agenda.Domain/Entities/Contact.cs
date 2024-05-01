using System.Collections.ObjectModel;

namespace Agenda.Domain.Entities
{
    public class Contact: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual ICollection<PhoneNumber>? PhoneNumbers { get; set; } = new Collection<PhoneNumber>();
    }
}
