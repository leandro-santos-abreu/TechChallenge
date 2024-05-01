using Agenda.Domain.Entities;

namespace Agenda.Domain.EntitiesAbstractions.EntitiesDto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    }
}
