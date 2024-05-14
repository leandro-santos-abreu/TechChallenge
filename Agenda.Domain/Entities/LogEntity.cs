using Agenda.Domain;

namespace Agenda.Domain.Entities
{
    public class LogEntity: BaseEntity
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string LogLevel { get; set; }
        public required string Description { get; set; }
    }
}
