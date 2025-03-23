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
        private const int ID = 0;
        private const int TITLU = 1;
        private const int DATA = 2;
        private const int DESCRIERE = 3;

        public int Id { get; set; }
        public string Titlu { get; set; }
        public DateTime Data { get; set; }
        public string Descriere { get; set; }

        // Constructor 
        public Eveniment(int _Id, string _Titlu, DateTime? _Data = null, string _Descriere = "")
        {
            Id = _Id;
            Titlu = _Titlu;
            Data = _Data ?? DateTime.Now;
            Descriere = _Descriere;
        }

        public override string ToString()
        {
            return $"ID: {Id} Eveniment: {Titlu} Data: {Data:dd/MM/yyyy HH:mm} Descriere: {Descriere}\n";
        }

        public Eveniment(string linieFisier)
        {
            string[] date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            Id = int.Parse(date[ID]);
            Titlu = date[TITLU];
            Data = DateTime.Parse(date[DATA]);
            Descriere = date[DESCRIERE];
        }

        public string ConversieLaSir_PentruFisier()
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}",
                SEPARATOR_PRINCIPAL_FISIER,
                Id,
                Titlu ?? "NECUNOSCUT",
                Data.ToString("dd/MM/yyyy HH:mm") ?? "NECUNOSCUT",
                Descriere ?? "NECUNOSCUT");
        }

    }
}

