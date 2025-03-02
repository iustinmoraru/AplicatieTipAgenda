using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieTipAgenda
{
    // Clasa Agenda va stoca o lista de evenimente si va oferi metode pentru: adaugarea, stergerea, visualizarea si cautarea evenimentelor
    class Agenda
    {
        //Lista de evenimente
        public List<Eveniment> Evenimente;

        //Constructor
        public Agenda()
        {
            Evenimente = new List<Eveniment>();
        }
    }
}
