using Agenda.Domain.Entities;
using Agenda.Domain.EntitiesAbstractions.EntitiesDto;
using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using Riok.Mapperly.Abstractions;

namespace Agenda.Api.Mappers
{
    [Mapper]
    public partial class ContactMapper
    {
        public partial Contact ContactInputToContact(ContactInput contactInput);

        public partial ContactDto ContactToContactDto(Contact contact);

        public partial Contact ContactDtoToContact(ContactDto contact);
    }
}
