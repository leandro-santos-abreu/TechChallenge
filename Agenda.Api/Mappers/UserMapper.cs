using Agenda.Domain.Entities;
using Agenda.Domain.Inputs;
using Riok.Mapperly.Abstractions;

namespace Agenda.Api.Mappers
{
    [Mapper]
    public partial class UserMapper
    {
        public partial User UserInputToUser(UserInput userInput);
    }
}
