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
        private const int nr_max = 250;
        private string numeFisier;
        public ManagementAgenda_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AdaugaEveniment(Eveniment eveniment, ref int nrEvenimente)
        {
            Eveniment[] evenimente = GetEvenimente(out nrEvenimente);

            eveniment.Id = nrEvenimente;
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(eveniment.ConversieLaSir_PentruFisier());
            }
            nrEvenimente++;
        }

        public Eveniment[] GetEvenimente(out int nrEvenimente)
        {
            Eveniment[] evenimente = new Eveniment[nr_max];

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrEvenimente = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    evenimente[nrEvenimente++] = new Eveniment(linieFisier);
                }
            }

            Array.Resize(ref evenimente, nrEvenimente);

            return evenimente;
        }

        public void StergeEvenimente(string titlu)
        {
            string[] liniiFisier = File.ReadAllLines(numeFisier);

            using (StreamWriter streamWriter = new StreamWriter(numeFisier))
            {
                foreach (string linie in liniiFisier)
                {
                    if (!linie.Contains(titlu))
                    {
                        streamWriter.WriteLine(linie);
                    }
                }
            }
        }

        public Eveniment CautaEvenimentinFisier(string titlu)
        {
            Eveniment ev;
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    ev = new Eveniment(line);
                    if(ev.Titlu == titlu)
                    {
                        return ev;
                    }
                }
            }
            return null;

        }

    }

}
