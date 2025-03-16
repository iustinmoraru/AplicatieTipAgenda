using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class User
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int NUME = 0;
        private const int PRENUME = 1;

        public string Nume { get; set; }
        public string Prenume { get; set; }

        public User(string nume, string prenume)
        {
            Nume = nume;
            Prenume = prenume;
        }

        public override string ToString()
        {
            return $"Nume: {Nume} Prenume: {Prenume}\n";
        }

        public User(string linieFisier)
        {
            string[] date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            Nume = date[NUME];
            Prenume = date[PRENUME];
        }

        public string ConversieLaSir_PentruFisier()
        {
            string userPentruFisier = string.Format("{1}{0}{2}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                Nume ?? "NECUNOSCUT",
                Prenume ?? "NECUNOSCUT");

            return userPentruFisier;
        }
    }
}
