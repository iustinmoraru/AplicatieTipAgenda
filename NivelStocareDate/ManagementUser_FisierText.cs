using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

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
            user.Id_User = GetUsers().Count;
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

        public User CautaUserinFisier(string _nume, string _prenume)
        {
            var users = GetUsers();
            return users.FirstOrDefault(u => u.Nume == _nume && u.Prenume == _prenume);
        }
    }
}
