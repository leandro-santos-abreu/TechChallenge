using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Entities
{
    [Table("Contacts")]
    public class Contact: BaseEntity
    {
        [MaxLength(150)]
        [Required]
        public required string Name { get; set; }

        [MaxLength(150)]
        [Required]
        public required string Surname { get; set; }

        [MaxLength(14)]
        [Required]
        public string? CellPhone { get; set; }

        [EmailAddress]
        [MaxLength(150)]
        public required string Email { get; set; }

        [MaxLength(11)]
        [Required]
        public required string CPF { get; set; }
    }
}
