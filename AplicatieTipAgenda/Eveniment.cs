using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieTipAgenda
{
    class Eveniment
    {
        string Titlu, Descriere;
        DateTime Data;

        // Constructor
        public Eveniment(string _Titlu, DateTime? _Data = null, string _Descriere = "")
        {
            Titlu = _Titlu;
            Data = _Data ?? DateTime.Now;  // Dacă _Data este null, setează la data curentă (DateTime.Now)
            Descriere = _Descriere;
        }

        public override string ToString()
        {
            return $"Eveniment: {Titlu}\nData: {Data.ToString("dd/MM/yyyy HH:mm")}\nDescriere: {Descriere}";
        }

        public string GetTitlu()
        {
            return Titlu;
        }
        public DateTime GetData()
        {
            return Data;
        }
        public string GetDescriere()
        {
            return Descriere;
        }
        public void SetTitlu(string TitluNou)
        {
            Titlu = TitluNou;
        }
        public void SetData(DateTime DataNoua)
        {
            Data = DataNoua;
        }
        public void SetDescriere(string DescriereNoua)
        {
            Descriere = DescriereNoua;
        }
    }
}
