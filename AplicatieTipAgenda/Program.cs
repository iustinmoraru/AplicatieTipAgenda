using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;
using NivelStocareDate;

namespace AplicatieTipAgenda
{
    class Program
    {
        static Eveniment ev;
        static void Main()
        {
            ManagementAgenda_Memorie agenda = new ManagementAgenda_Memorie(10);
            ManagementAgenda_FisierText agendaFisier = new ManagementAgenda_FisierText("evenimente.txt");

            int nrEvenimente = 0;

            string optiune;
            do
            {
                Console.WriteLine("C. Citirea datelor de la tastatura");
                Console.WriteLine("S. Salvarea datelor intr-un vector de obiecte");
                Console.WriteLine("A. Afisarea datelor dintr-un vector de obiecte");
                Console.WriteLine("B. Cautarea dupa anumite criterii");
                Console.WriteLine("D. Salvare eveniment in fisier");
                Console.WriteLine("E. Afisare evenimente din fisier");
                Console.WriteLine("X. Inchidere program");

                Console.WriteLine("Alege o optiune");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        ev = CitireEvenimentTastatura();
                        break;

                    case "S":
                        agenda.AdaugaEveniment(ev);
                        break;

                    case "A":
                        Console.WriteLine(agenda.AfiseazaEvenimente());
                        break;

                    case "B":
                        Console.Write("Introdu titlul evenimentului pentru căutare: ");
                        string titluCautat = Console.ReadLine();
                        agenda.CautaEveniment(titluCautat);
                        break;

                    case "D":
                        agendaFisier.AdaugaEveniment(ev);
                        nrEvenimente++;
                        break;

                    case "E":
                        Eveniment[] evenimente = agendaFisier.GetEvenimente(out nrEvenimente);
                        for (int i = 0; i < nrEvenimente; i++)
                        {
                            Console.WriteLine(evenimente[i].ConversieLaSir_PentruFisier());
                        }
                        break;

                    case "X":
                        Console.WriteLine();
                        return;

                    default:
                        Console.WriteLine("Optiunea inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }
        public static Eveniment CitireEvenimentTastatura()
        {
            Console.Write("Introduceti titlul evenimentului: ");
            string titlu = Console.ReadLine();

            Console.Write("Introduceti data evenimentului (dd/MM/yyyy HH:mm): ");
            DateTime data;
            while (!DateTime.TryParse(Console.ReadLine(), out data))
            {
                Console.Write("Format invalid! Introduceti data corect: ");
            }

            Console.Write("Introduceti descrierea evenimentului: ");
            string descriere = Console.ReadLine();

            Eveniment eveniment = new Eveniment(titlu, data, descriere);

            return eveniment;
        }
    }
}
