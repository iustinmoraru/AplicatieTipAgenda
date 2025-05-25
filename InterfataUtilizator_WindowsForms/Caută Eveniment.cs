using LibrarieModele;
using MetroFramework.Forms;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Caută_Eveniment: MetroForm
    {
        private ManagementAgenda_FisierText agendaFisier;
        private User userCurent;
        public Caută_Eveniment(User user)
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            agendaFisier = new ManagementAgenda_FisierText(caleCompletaFisier);
            userCurent = user;
        }

        private void Caută_Eveniment_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCauta_Click(object sender, EventArgs e)
        {
            string numeCautat = txtNumeCautat.Text.Trim();

            if (string.IsNullOrEmpty(numeCautat))
            {
                MessageBox.Show("Introdu un nume pentru căutare!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Eveniment> evenimenteFiltrate = agendaFisier.CautaEvenimentDupaUser(numeCautat, userCurent.Id_User);
            
            if (evenimenteFiltrate == null || evenimenteFiltrate.Count == 0)
            {
                MessageBox.Show("Nu s-au găsit evenimente cu acest nume", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Deschidem fereastra Listă_Evenimente cu lista filtrată
            Listă_Evenimente formLista = new Listă_Evenimente(evenimenteFiltrate);
            formLista.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
