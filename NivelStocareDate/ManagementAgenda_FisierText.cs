﻿using LibrarieModele;
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
        private const int nr_max = 50;
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

            return evenimente;
        }
    }
}
