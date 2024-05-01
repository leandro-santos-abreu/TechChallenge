using Agenda.Domain.Entities;
using Agenda.Domain.EntitiesAbstractions.EntitiesDto;
using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using Riok.Mapperly.Abstractions;

namespace Agenda.Api.Mappers
{
    [Mapper]
    public partial class UserMapper
    {
        public partial User UserInputToUser(UserInput userInput);
        public partial UserDto UserToUserDto(User user);
        public partial User UserDtoToUser(UserDto user);
    }
}
