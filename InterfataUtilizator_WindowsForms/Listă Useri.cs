using LibrarieModele;
using MetroFramework.Forms;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Listă_Useri: MetroForm
    {
        private ManagementUser_FisierText managementUser;
        private List<User> useri;
        private int paginaCurenta = 1;
        private const int UseriPePagina = 10;
        public Listă_Useri()
        {
            InitializeComponent();
            string numeFisier2 = System.Configuration.ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie2 = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;
            managementUser = new ManagementUser_FisierText(caleCompletaFisier2);

            useri = managementUser.GetUsers();
        }

        private void Listă_Useri_Load(object sender, EventArgs e)
        {
            metroGridUseri.Columns.Clear();
            metroGridUseri.Columns.Add("Nume", "Nume");
            metroGridUseri.Columns.Add("Prenume", "Prenume");
            metroGridUseri.Columns.Add("Gen", "Gen");

            AfiseazaPagina(paginaCurenta);
        }

        public Listă_Useri(List<User> useriGasiti)
        {
            InitializeComponent();
            this.useri = useriGasiti;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (paginaCurenta * UseriPePagina < useri.Count)
            {
                paginaCurenta++;
                AfiseazaPagina(paginaCurenta);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (paginaCurenta > 1)
            {
                paginaCurenta--;
                AfiseazaPagina(paginaCurenta);
            }
        }
        private void AfiseazaPagina(int pagina)
        {
            int startIndex = (pagina - 1) * UseriPePagina;
            int endIndex = Math.Min(startIndex + UseriPePagina, useri.Count);
            metroGridUseri.Rows.Clear();

            for (int i = startIndex; i < endIndex; i++)
            {
                var user = useri[i];
                metroGridUseri.Rows.Add(user.Nume, user.Prenume, user.Gen.ToString());
            }

            btnPrevious.Enabled = pagina > 1;
            btnNext.Enabled = endIndex < useri.Count;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (metroGridUseri.SelectedRows.Count > 0)
            {
                int indexSelectat = metroGridUseri.SelectedRows[0].Index;
                int indexUser = (paginaCurenta - 1) * UseriPePagina + indexSelectat;

                if (indexUser >= 0 && indexUser < useri.Count)
                {
                    User userSelectat = useri[indexUser];

                    Editare_User formEditare = new Editare_User(userSelectat);
                    if (formEditare.ShowDialog() == DialogResult.OK)
                    {
                        // Actualizeaza userul in lista cu cel modificat
                        useri[indexUser] = formEditare.ObiectEditat;

                        managementUser.SalveazaUseri(useri);

                        AfiseazaPagina(paginaCurenta);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectați un user pentru a-l edita.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            if (metroGridUseri.SelectedRows.Count > 0)
            {
                int indexSelectat = metroGridUseri.SelectedRows[0].Index;
                int indexUser = (paginaCurenta - 1) * UseriPePagina + indexSelectat;

                if (indexUser >= 0 && indexUser < useri.Count)
                {
                    var confirmResult = MessageBox.Show(
                        "Sigur doriți să ștergeți userul selectat?",
                        "Confirmare ștergere",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        var userDeSters = useri[indexUser];
                        managementUser.StergeUser(userDeSters);
                        useri = managementUser.GetUsers();
                        AfiseazaPagina(paginaCurenta);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectați un user pentru a-l șterge.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
