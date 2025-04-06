using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    [Flags]
    public enum EnumPentruZiuaSaptamanii
    {
        Luni = 1 << 0,    // 0000001
        Marti = 1 << 1,   // 0000010
        Miercuri = 1 << 2, // 0000100
        Joi = 1 << 3,     // 0001000
        Vineri = 1 << 4,   // 0010000
        Sambata = 1 << 5,  // 0100000
        Duminica = 1 << 6, // 1000000
        Toate = Luni | Marti | Miercuri | Joi | Vineri | Sambata | Duminica  // 1111111
    }
}
