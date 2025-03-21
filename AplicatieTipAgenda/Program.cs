﻿using System;
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
            ManagementAgenda_Memorie agenda = new ManagementAgenda_Memorie(10);
            ManagementAgenda_FisierText agendaFisier = new ManagementAgenda_FisierText("evenimente.txt");
            ManagementUser_FisierText managementUser = new ManagementUser_FisierText("useri.txt");

            int nrEvenimente = 0;
            int nrUseri = 0;

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

                    case "J":
                        managementUser.AdaugaUser(us);
                        nrUseri++;
                        break;

                    case "I":
                        User[] useri = managementUser.GetUsers(out nrEvenimente);
                        for (int i = 0; i< nrEvenimente; i++)
                        {
                            Console.WriteLine(useri[i].ConversieLaSir_PentruFisier());
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

        public static User CitireUseriTastatura()
        {
            Console.Write("Introduceti numele: ");
            string nume = Console.ReadLine();
            Console.Write("Introduceti prenumele: ");
            string prenume = Console.ReadLine();
            User user = new User(nume, prenume);
            
            return user;
        }
    }
}
