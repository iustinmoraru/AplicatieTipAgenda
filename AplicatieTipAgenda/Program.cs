using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieTipAgenda
{
    class Program
    {
        static void Main()
        {
            Eveniment ev1 = new Eveniment("as", new DateTime(2025, 2, 1), "asdasd");
            Console.WriteLine(ev1.ToString());

            Agenda agenda = new Agenda();
        }
    }
}
