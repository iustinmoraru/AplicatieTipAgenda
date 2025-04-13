using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfataUtilizator_WindowsForms
{
    [Flags]
    public enum CodEroare
    {
        Corect = 0,
        NumeIncorect = 1,
        DataIncorecta = 2,
        DescriereIncorecta = 4,
        PrioritateIncorecta = 8,
        ZileIncorecte = 16
    }
}
