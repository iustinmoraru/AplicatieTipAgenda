using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieTipAgenda
{
    // Clasa Agenda va stoca o lista de evenimente si va oferi metode pentru: adaugarea, stergerea, visualizarea si cautarea evenimentelor
    class ManagementAgenda
    {
        private Eveniment[] Evenimente;
        private int numarEvenimente;

        public ManagementAgenda(int capacitateMaxima)
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
                Console.WriteLine("Eveniment adăugat cu succes!\n");
            }
            else
            {
                Console.WriteLine("Nu mai există spațiu pentru evenimente!\n");
            }
        }

        public void AfiseazaEvenimente()
        {
            if (numarEvenimente == 0)
            {
                Console.WriteLine("Nu există evenimente salvate.\n");
                return;
            }

            Console.WriteLine("\nLista evenimentelor:");
            for (int i = 0; i < numarEvenimente; i++)
            {
                Console.WriteLine(Evenimente[i].ToString());  
            }
            Console.WriteLine();
        }


        public void CautaEveniment(string titlu)
        {
            bool gasit = false;
            Console.WriteLine("\nEvenimente găsite:");
            for (int i = 0; i < numarEvenimente; i++)
            {
                if (Evenimente[i].Titlu.IndexOf(titlu, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine(Evenimente[i].ToString()); 
                    gasit = true;
                }
            }

            if (!gasit)
            {
                Console.WriteLine("Niciun eveniment găsit cu acest titlu.\n");
            }
            Console.WriteLine();
        }

    }
}
