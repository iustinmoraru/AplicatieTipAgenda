using LibrarieModele;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NivelStocareDate
{
    public class ManagementUser_FisierText
    {
        private string numeFisier;

        public ManagementUser_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AdaugaUser(User user)
        {
            var users = GetUsers();
            int idNou = users.Count > 0 ? users.Max(u => u.Id_User) + 1 : 1;
            user.Id_User = idNou;
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(user.ConversieLaSir_PentruFisier());
            }
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while((linieFisier = streamReader.ReadLine()) != null)
                {
                    users.Add(new User(linieFisier));
                }
            }

            return users;
        }

        public void StergeUser(string nume, string prenume)
        {
            var users = GetUsers();
            var usersFiltrati = users.Where(u => !(u.Nume == nume && u.Prenume == prenume)).ToList(); //pentru fiecare u gasit excludem acel User (functie Lambda)

            using (StreamWriter streamWriter = new StreamWriter(numeFisier))
            {
                foreach (var user in usersFiltrati)
                {
                    streamWriter.WriteLine(user.ConversieLaSir_PentruFisier());
                }
            }
        }

        public List<User> CautaUseriDupaNumePrenume(string nume, string prenume)
        {
            var users = GetUsers();
            return users.Where(u => u.Nume == nume && u.Prenume == prenume).ToList();
        }

        public void SalveazaUseri(List<User> useri)
        {
            using (StreamWriter writer = new StreamWriter(numeFisier, false))
            {
                foreach (User user in useri)
                {
                    writer.WriteLine(user.ConversieLaSir_PentruFisier());
                }
            }
        }
        public void StergeUser(User userDeSters)
        {
            var useri = GetUsers();
            // Cauta si elimina primul user care se potriveste 
            var userGasit = useri.FirstOrDefault(u =>
                u.Nume == userDeSters.Nume &&
                u.Prenume == userDeSters.Prenume &&
                u.Gen == userDeSters.Gen
            );
            if (userGasit != null)
            {
                useri.Remove(userGasit);
                SalveazaUseri(useri);
            }
        }
    }
}
