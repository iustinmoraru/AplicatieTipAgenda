using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;
using NivelStocareDate;
using Microsoft.Win32;

namespace AplicatieTipAgenda
{
    class Program
    {
        static Eveniment ev;
        static User us;
        static void Main()
        {
            ManagementAgenda_Memorie agenda = new ManagementAgenda_Memorie(100);
            ManagementAgenda_FisierText agendaFisier = new ManagementAgenda_FisierText("evenimente.txt");
            ManagementUser_FisierText managementUser = new ManagementUser_FisierText("useri.txt");

            int nrEvenimente;
            int nrUseri;

            agendaFisier.GetEvenimente(out nrEvenimente);
            managementUser.GetUsers(out nrUseri);

            string optiune;
            do
            {
                Console.WriteLine("C. Citire eveniment de la tastatura");
                Console.WriteLine("Q. Citire user de la tastatura");
                Console.WriteLine("S. Salvarea datelor intr-un vector de obiecte");
                Console.WriteLine("A. Afisarea datelor dintr-un vector de obiecte");
                Console.WriteLine("B. Cautarea dupa anumite criterii");
                Console.WriteLine("D. Salvare eveniment in fisier");
                Console.WriteLine("E. Afisare evenimente din fisier");
                Console.WriteLine("J. Salvare useri in fisier");
                Console.WriteLine("I. Afisare useri in fisier");
                Console.WriteLine("Z. Stergere eveniment din fisier");
                Console.WriteLine("Y. Stergere user din fisier");
                Console.WriteLine("X. Inchidere program");

                Console.WriteLine("Alege o optiune");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        ev = CitireEvenimentTastatura();
                        break;

                    case "Q":
                        us = CitireUseriTastatura();
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
                        agendaFisier.AdaugaEveniment(ev, ref nrEvenimente);
                        break;

                    case "E":
                        Eveniment[] evenimente = agendaFisier.GetEvenimente(out nrEvenimente);
                        for (int i = 0; i < nrEvenimente; i++)
                        {
                            Console.WriteLine(evenimente[i].ConversieLaSir_PentruFisier());
                        }
                        break;

                    case "J":
                        managementUser.AdaugaUser(us, ref nrUseri);
                        break;

                    case "I":
                        User[] useri = managementUser.GetUsers(out nrEvenimente);
                        for (int i = 0; i< nrEvenimente; i++)
                        {
                            Console.WriteLine(useri[i].ConversieLaSir_PentruFisier());
                        }
                        break;

                    case "Z":
                        Console.Write("Introdu titlul evenimentului pentru stergere: ");
                        string titluSters = Console.ReadLine();
                        agendaFisier.StergeEvenimente(titluSters);
                        break;

                    case "Y":
                        Console.WriteLine("Introdu numele pentru stergere:");
                        string numeSters = Console.ReadLine();
                        Console.WriteLine("Introdu prenumele pentru stergere:");
                        string prenumeSters = Console.ReadLine();
                        managementUser.StergeUser(numeSters, prenumeSters);
                        break;

                    case "X":
                        break;

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

            
            Eveniment eveniment = new Eveniment(0, titlu, data, descriere);

            Console.WriteLine("Introduceti prioritatea evenimentului:");

            foreach (EnumPentruPrioritateEveniment prioritate in Enum.GetValues(typeof(EnumPentruPrioritateEveniment)))
            {
                Console.WriteLine($"{(int)prioritate} - {prioritate}");
            }

            string inputPrioritate = Console.ReadLine();

            if (Enum.TryParse(inputPrioritate, out EnumPentruPrioritateEveniment prioritateEveniment) && Enum.IsDefined(typeof(EnumPentruPrioritateEveniment), prioritateEveniment))
            {
                eveniment.PrioritateEveniment = prioritateEveniment;
            }

            Console.WriteLine("Introduceti zilele saptamanii (separate prin virgula) pentru evenimentul: ");
            foreach (EnumPentruZiuaSaptamanii zi in Enum.GetValues(typeof(EnumPentruZiuaSaptamanii)))
            {
                if (zi != EnumPentruZiuaSaptamanii.Toate)  
                {
                    Console.WriteLine($"{(int)zi} - {zi}");
                }
            }

            string inputZile = Console.ReadLine();
            EnumPentruZiuaSaptamanii zileSelectate = 0;
            string[] zileInput = inputZile.Split(',');

            foreach (var zi in zileInput)
            {
                if (Enum.TryParse(zi.Trim(), out EnumPentruZiuaSaptamanii ziSelectata) && Enum.IsDefined(typeof(EnumPentruZiuaSaptamanii), ziSelectata))
                {
                    zileSelectate |= ziSelectata; 
                }
                else
                {
                    Console.WriteLine($"Ziua {zi.Trim()} nu este validă.");
                }
            }

            eveniment.ZileSelectate = zileSelectate;

            return eveniment;
        }

        public static User CitireUseriTastatura()
        {
            Console.Write("Introduceti numele: ");
            string nume = Console.ReadLine();
            Console.Write("Introduceti prenumele: ");
            string prenume = Console.ReadLine();
            
            User user = new User(0, nume, prenume);

            Console.WriteLine("Introduceti genul userului:");
            
            foreach (GenUser gen in Enum.GetValues(typeof(GenUser)))
            {
                Console.WriteLine($"{(int)gen} - {gen}");
            }

            string inputGen = Console.ReadLine();

            if (Enum.TryParse(inputGen, out GenUser genUser) && Enum.IsDefined(typeof(GenUser), genUser))
            {
                user.Gen = genUser;
            }
            return user;
        }
    }
}
