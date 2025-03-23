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
        private const int ID = 0;
        private const int NUME = 1;
        private const int PRENUME = 2;

        public int Id_User { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public User(int id, string nume, string prenume)
        {
            Id_User = id;
            Nume = nume;
            Prenume = prenume;
        }

        public override string ToString()
        {
            return $"ID: {Id_User} Nume: {Nume} Prenume: {Prenume}\n";
        }

        public User(string linieFisier)
        {
            string[] date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            Id_User = int.Parse(date[ID]);
            Nume = date[NUME];
            Prenume = date[PRENUME];
        }

        public string ConversieLaSir_PentruFisier()
        {
            string userPentruFisier = string.Format("{1}{0}{2}{0}{3}",
                SEPARATOR_PRINCIPAL_FISIER,
                Id_User,
                Nume ?? "NECUNOSCUT",
                Prenume ?? "NECUNOSCUT");

            return userPentruFisier;
        }
    }
}
