using Agenda.Domain.Entities;

namespace Agenda.Domain.Inputs
{
    public class ContactInput
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string? CellPhone { get; set; }
        public required string Email { get; set; }
        public required string CPF { get; set; }
        public required Guid UserId { get; set; }
        public required User User { get; set; }
    }
}
