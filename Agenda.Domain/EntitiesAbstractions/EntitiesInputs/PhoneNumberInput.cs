using Agenda.Domain.Entities;
using Agenda.Domain.ValueObjects;

namespace Agenda.Domain.EntitiesAbstractions.EntitiesInputs
{
    public class PhoneNumberInput(Guid contactId, string areaCode, string cellPhone)
    {
        public Guid ContactId { get; set; } = contactId;
        public string AreaCode { get; set; } = areaCode;
        public string CellPhone { get; set; } = cellPhone;
    }
}
