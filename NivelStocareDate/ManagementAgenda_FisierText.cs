using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            List<Eveniment> evenimente = GetEvenimente();
            eveniment.Id = evenimente.Count;
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(eveniment.ConversieLaSir_PentruFisier());
            }
        }

        public List<Eveniment> GetEvenimente()
        {
            List<Eveniment> evenimente = new List<Eveniment>();

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    evenimente.Add(new Eveniment(linieFisier));
                }
            }

            return evenimente;
        }

        public void StergeEvenimente(string titlu)
        {
            List<string> liniiFisier = File.ReadAllLines(numeFisier).ToList();

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

        public void SalveazaEvenimente(List<Eveniment> evenimente)
        {
            using (StreamWriter writer = new StreamWriter(numeFisier, false))
            {
                foreach (Eveniment ev in evenimente)
                {
                    writer.WriteLine(ev.ConversieLaSir_PentruFisier());
                }
            }
        }

        public List<Eveniment> CautaEveniment(string titlu)
        {
            if(string.IsNullOrWhiteSpace(titlu))
            {
                return null;
            }

            var toateEvenimentele = GetEvenimente();
            // Filtram evenimentele după titlu
            var evenimenteFiltrate = toateEvenimentele
                .Where(ev => ev.Titlu.IndexOf(titlu, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            return evenimenteFiltrate;
        }

    }

}
