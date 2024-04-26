using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Entities
{
    public class Contact: BaseEntity
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string? CellPhone { get; set; }
        public required string Email { get; set; }
        public required string CPF { get; set; }
        public virtual required User User { get; set; }
        public required Guid UserId { get; set; }
    }
}
