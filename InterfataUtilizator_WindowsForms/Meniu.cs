using LibrarieModele;
using MetroFramework.Forms;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Meniu: MetroForm
    {
        private ManagementUser_FisierText managementUser;
        private User userCurent;
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
            if (userCurent == null)
            {
                MessageBox.Show("Selectați un user mai întâi!");
                return;
            }
            Adăugare_Eveniment adaugăEveniment = new Adăugare_Eveniment(userCurent);
            adaugăEveniment.ShowDialog();
        }

        private void ListaEvenimenteButton_Click(object sender, EventArgs e)
        {
            if (userCurent == null)
            {
                MessageBox.Show("Selectați un user mai întâi!");
                return;
            }
            Listă_Evenimente listăEvenimente = new Listă_Evenimente(userCurent);
            listăEvenimente.ShowDialog();
        }

        private void CautaEvenimentButton_Click(object sender, EventArgs e)
        {
            Caută_Eveniment cautăEveniment = new Caută_Eveniment();
            cautăEveniment.ShowDialog();
        }

        private void AdaugareUser_Click(object sender, EventArgs e)
        {
            Adăugare_User adaugareUserForm = new Adăugare_User();
            adaugareUserForm.ShowDialog();
        }

        private void ListaUseri_Click(object sender, EventArgs e)
        {
            Listă_Useri listăUseri = new Listă_Useri();
            listăUseri.ShowDialog();
        }

        private void CautaUser_Click(object sender, EventArgs e)
        {
            Caută_User cautăUser = new Caută_User();
            cautăUser.ShowDialog();
        }

        private void btnSelecteazaUser_Click(object sender, EventArgs e)
        {
            Selectează_User selecteazaUserForm = new Selectează_User();
            if (selecteazaUserForm.ShowDialog() == DialogResult.OK && selecteazaUserForm.UserSelectat != null)
            {
                userCurent = selecteazaUserForm.UserSelectat;
                lblNumeUser.Text = userCurent.Nume;
                lblPrenumeUser.Text = userCurent.Prenume;
                lblGenUser.Text = userCurent.Gen.ToString();
            }
        }
    }
}
