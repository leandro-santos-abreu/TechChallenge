using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Infrastructure.Interfaces
{
    public interface IDatabaseConfig
    {
        string ConnectionString { get; set; }
    }
}
