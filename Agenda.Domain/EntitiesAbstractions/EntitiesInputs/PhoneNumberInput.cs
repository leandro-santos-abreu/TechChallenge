using Agenda.Domain.Entities;
using Agenda.Domain.ValueObjects;

namespace Agenda.Domain.EntitiesAbstractions.EntitiesInputs
{
    public class PhoneNumberInput
    {
        public Guid ContactId { get; set; }
        public string AreaCode { get; set; }
        public string CellPhone { get; set; }
    }
}
