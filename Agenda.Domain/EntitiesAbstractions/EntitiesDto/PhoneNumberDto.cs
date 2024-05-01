using Agenda.Domain.Entities;
using Agenda.Domain.ValueObjects;

namespace Agenda.Domain.EntitiesAbstractions.EntitiesDto
{
    public class PhoneNumberDto
    {
        public Guid ContactId { get; set; }
        public string AreaCode { get; set; }
        public string CellPhone { get; set; }
        public virtual AreaCodeDto AreaCodeEntity { get; set; }

    }
}
