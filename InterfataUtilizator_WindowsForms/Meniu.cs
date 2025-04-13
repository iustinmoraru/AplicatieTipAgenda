using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using NivelStocareDate;
using System.Configuration;
using System.IO;
using NivelStocareDate;
using LibrarieModele;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Meniu: MetroForm
    {
        private ManagementUser_FisierText managementUser;
        public Meniu()
        {
            InitializeComponent();
            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie2 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;

            managementUser = new ManagementUser_FisierText(caleCompletaFisier2);
        }

        private void Meniu_Load(object sender, EventArgs e)
        {
            List<User> useri = managementUser.GetUsers();
            if (useri.Count > 0)
            {
                lblNumeUser.Text = useri[0].Nume;
                lblPrenumeUser.Text = useri[0].Prenume;
                lblGenUser.Text = useri[0].Gen.ToString();
            }
        }

        private void AdaugareButton_Click(object sender, EventArgs e)
        {
            Adăugare_Eveniment adaugăEveniment = new Adăugare_Eveniment();
            adaugăEveniment.ShowDialog();

        }

        private void ListaEvenimenteButton_Click(object sender, EventArgs e)
        {
            Listă_Evenimente listăEvenimente = new Listă_Evenimente();
            listăEvenimente.ShowDialog();
        }

        private void CautaEvenimentButton_Click(object sender, EventArgs e)
        {
            Caută_Eveniment cautăEveniment = new Caută_Eveniment();
            cautăEveniment.ShowDialog();
        }
    }
}
