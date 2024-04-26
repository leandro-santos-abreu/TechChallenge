using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Entities
{
    public class User: BaseEntity
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
