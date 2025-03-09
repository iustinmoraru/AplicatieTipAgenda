using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieTipAgenda
{
    class Eveniment
    {
        public string Titlu { get; set; }
        public DateTime Data { get; set; }
        public string Descriere { get; set; }

        // Constructor
        public Eveniment(string _Titlu, DateTime? _Data = null, string _Descriere = "")
        {
            Titlu = _Titlu;
            Data = _Data ?? DateTime.Now;  // Dacă _Data este null, setează la data curentă (DateTime.Now)
            Descriere = _Descriere;
        }

        public override string ToString()
        {
            return $"Eveniment: {Titlu} Data: {Data.ToString("dd/MM/yyyy HH:mm")} Descriere: {Descriere}\n";
        }

    }
}
