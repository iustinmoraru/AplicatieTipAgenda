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
        private const int nr_max = 50;
        private string numeFisier;

        public ManagementUser_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AdaugaUser(User user, ref int nrUseri)
        {
            user.Id_User = nrUseri++;
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(user.ConversieLaSir_PentruFisier());
            }
        }

        public User[] GetUsers(out int nrUsers)
        {
            User[] users = new User[nr_max];

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrUsers = 0;
                while((linieFisier = streamReader.ReadLine()) != null)
                {
                    users[nrUsers++] = new User(linieFisier);
                }
            }
            return users;
        }

        public void StergeUser(string nume, string prenume)
        {
            string[] liniiFisier = File.ReadAllLines(numeFisier);
            using (StreamWriter streamWriter = new StreamWriter(numeFisier))
            {
                foreach (string linie in liniiFisier)
                {
                    if (!linie.Contains(nume) && !linie.Contains(prenume))
                    {
                        streamWriter.WriteLine(linie);
                    }
                }
            }
        }

        public User CautaUserinFisier(string _nume, string _prenume)
        {
            User user;
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = streamReader.ReadLine()) != null)
                {
                    user = new User(linie);
                    if (user.Nume == _nume && user.Prenume == _prenume)
                    {
                        return user;
                    }
                }
            }
            return null;
        }
    }
}
