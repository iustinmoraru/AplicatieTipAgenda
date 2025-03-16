using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelStocareDate
{
    public class ManagementAgenda_Memorie
    {
        private Eveniment[] Evenimente;
        private int numarEvenimente;

        public ManagementAgenda_Memorie(int capacitateMaxima)
        {
            Evenimente = new Eveniment[capacitateMaxima]; 
            numarEvenimente = 0;
        }

        public void AdaugaEveniment(Eveniment eveniment)
        {
            if (numarEvenimente < Evenimente.Length)
            {
                Evenimente[numarEvenimente] = eveniment;
                numarEvenimente++;
            }
        }

        public string AfiseazaEvenimente()
        {
            if (numarEvenimente == 0)
            {
                return "Nu există evenimente salvate.";
            }

            string rezultat = "Lista evenimentelor:\n";
            for (int i = 0; i < numarEvenimente; i++)
            {
                rezultat += Evenimente[i].ToString() + "\n";
            }
            return rezultat;
        }

        public string CautaEveniment(string titlu)
        {
            bool gasit = false;
            string rezultat = "Evenimente găsite:\n";

            for (int i = 0; i < numarEvenimente; i++)
            {
                if (Evenimente[i].Titlu.IndexOf(titlu, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    rezultat += Evenimente[i].ToString() + "\n";
                    gasit = true;
                }
            }

            if (!gasit)
            {
                return "Niciun eveniment găsit cu acest titlu.";
            }

            return rezultat;
        }

        public string StergeEveniment(string titlu)
        {
            for (int i = 0; i < numarEvenimente; i++)
            {
                if (Evenimente[i].Titlu.Equals(titlu, StringComparison.OrdinalIgnoreCase))
                {
                    for (int j = i; j < numarEvenimente - 1; j++)
                    {
                        Evenimente[j] = Evenimente[j + 1];
                    }
                    Evenimente[numarEvenimente - 1] = null;
                    numarEvenimente--;
                }
            }
            return "Evenimentul nu a fost găsit.";
        }

    }
}
