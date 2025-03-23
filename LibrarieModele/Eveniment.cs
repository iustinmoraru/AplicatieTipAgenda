﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Eveniment
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int ID = 0;
        private const int TITLU = 1;
        private const int DATA = 2;
        private const int DESCRIERE = 3;
        private const int PRIORITATE = 4;
        private const int ZILE_SAPTAMANA = 5;

        public int Id { get; set; }
        public string Titlu { get; set; }
        public DateTime Data { get; set; }
        public string Descriere { get; set; }
        public EnumPentruPrioritateEveniment PrioritateEveniment { get; set; }
        public EnumPentruZiuaSaptamanii ZileSelectate { get; set; }

        // Constructor 
        public Eveniment(int _Id, string _Titlu, DateTime? _Data = null, string _Descriere = "", int _PrioritateEveniment = 0, string _ZileSelectate = "")
        {
            Id = _Id;
            Titlu = _Titlu;
            Data = _Data ?? DateTime.Now;
            Descriere = _Descriere;
            PrioritateEveniment = (EnumPentruPrioritateEveniment)_PrioritateEveniment;
            if (!string.IsNullOrEmpty(_ZileSelectate))
            {
                ZileSelectate = (EnumPentruZiuaSaptamanii)Enum.Parse(typeof(EnumPentruZiuaSaptamanii), _ZileSelectate);
            }
            else
            {
                ZileSelectate = EnumPentruZiuaSaptamanii.Nimic;
            }
        }

        public override string ToString()
        {
            return $"ID: {Id} Eveniment: {Titlu} Data: {Data:dd/MM/yyyy HH:mm} Descriere: {Descriere} Prioritate Eveniment: {PrioritateEveniment} Zile Saptamana: {ZileSelectate}\n";
        }

        public Eveniment(string linieFisier)
        {
            string[] date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            Array.Resize(ref date, 6);

            Id = int.Parse(date[ID]);
            Titlu = date[TITLU];
            Data = DateTime.Parse(date[DATA]);
            Descriere = date[DESCRIERE];
            PrioritateEveniment = (EnumPentruPrioritateEveniment)Enum.Parse(typeof(EnumPentruPrioritateEveniment), date[PRIORITATE]);
            if (!string.IsNullOrEmpty(date[ZILE_SAPTAMANA]))
            {
                ZileSelectate = (EnumPentruZiuaSaptamanii)Enum.Parse(typeof(EnumPentruZiuaSaptamanii), date[ZILE_SAPTAMANA]);
            }
            else
            {
                ZileSelectate = EnumPentruZiuaSaptamanii.Toate;
            }
        }

        public string ConversieLaSir_PentruFisier()
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}",
                SEPARATOR_PRINCIPAL_FISIER,
                Id,
                Titlu ?? "NECUNOSCUT",
                Data.ToString("dd/MM/yyyy HH:mm") ?? "NECUNOSCUT",
                Descriere ?? "NECUNOSCUT",
                PrioritateEveniment,
                ZileSelectate);
        }

    }
}

