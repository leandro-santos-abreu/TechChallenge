namespace Agenda.Domain.Entities
{
    public class User: BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
