using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Eveniment
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int TITLU = 0;
        private const int DATA = 1;
        private const int DESCRIERE = 2;

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

        public Eveniment(string linieFisier)
        {
            string[] date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            Titlu = date[TITLU];
            Data = DateTime.Parse(date[DATA]);
            Descriere = date[DESCRIERE];
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectStudentPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                Titlu ?? "NECUNOSCUT",
                Data.ToString("dd/MM/yyyy HH:mm") ?? "NECUNOSCUT",
                Descriere ?? "NECUNOSCUT");

            return obiectStudentPentruFisier;
        }
    }
}
