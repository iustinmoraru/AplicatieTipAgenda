using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class ManagementAgenda_FisierText
    {
        private string numeFisier;
        public ManagementAgenda_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AdaugaEveniment(Eveniment eveniment)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(eveniment.ConversieLaSir_PentruFisier());
            }
        }

        public Eveniment[] GetEvenimente(out int nrEvenimente)
        {
            List<Eveniment> evenimente = new List<Eveniment>();

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrEvenimente = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    evenimente.Add(new Eveniment(linieFisier));
                    nrEvenimente++;
                }
            }

            return evenimente.ToArray();
        }
    }
}
