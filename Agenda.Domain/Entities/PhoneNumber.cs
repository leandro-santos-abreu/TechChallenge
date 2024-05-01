using Agenda.Domain.ValueObjects;

namespace Agenda.Domain.Entities
{
    public class PhoneNumber : BaseEntity
    {
        public string AreaCode { get; set; }
        public string CellPhone { get; set; }

        public virtual AreaCode AreaCodeEntity { get; set; }
        public virtual Contact Contact { get; set; }

        public Guid ContactId { get; set; }
    }
}
