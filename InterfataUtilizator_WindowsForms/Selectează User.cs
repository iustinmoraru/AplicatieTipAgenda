using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarieModele;
using MetroFramework.Forms;
using NivelStocareDate;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Selectează_User: MetroForm
    {
        private ManagementUser_FisierText managementUser;
        private List<User> useri;
        private int paginaCurenta = 1;
        private const int UseriPePagina = 10;

        public User UserSelectat { get; private set; }
        public Selectează_User()
        {
            InitializeComponent();
            string numeFisier2 = System.Configuration.ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie2 = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;
            managementUser = new ManagementUser_FisierText(caleCompletaFisier2);

            useri = managementUser.GetUsers();
        }

        private void Selectează_User_Load(object sender, EventArgs e)
        {
            metroGridSelecteazaUser.Columns.Clear();
            metroGridSelecteazaUser.Columns.Add("Nume", "Nume");
            metroGridSelecteazaUser.Columns.Add("Prenume", "Prenume");
            metroGridSelecteazaUser.Columns.Add("Gen", "Gen");

            AfiseazaPagina(paginaCurenta);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (paginaCurenta > 1)
            {
                paginaCurenta--;
                AfiseazaPagina(paginaCurenta);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (paginaCurenta * UseriPePagina < useri.Count)
            {
                paginaCurenta++;
                AfiseazaPagina(paginaCurenta);
            }
        }

        private void btnSelecteaza_Click(object sender, EventArgs e)
        {
            if (metroGridSelecteazaUser.SelectedRows.Count > 0)
            {
                int indexSelectat = metroGridSelecteazaUser.SelectedRows[0].Index;
                int userIndex = (paginaCurenta - 1) * UseriPePagina + indexSelectat;

                if (userIndex >= 0 && userIndex < useri.Count)
                {
                    UserSelectat = useri[userIndex];
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Selectați un user din listă!", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void AfiseazaPagina(int pagina)
        {
            int startIndex = (pagina - 1) * UseriPePagina;
            int endIndex = Math.Min(startIndex + UseriPePagina, useri.Count);
            metroGridSelecteazaUser.Rows.Clear();

            for (int i = startIndex; i < endIndex; i++)
            {
                var user = useri[i];
                metroGridSelecteazaUser.Rows.Add(user.Nume, user.Prenume, user.Gen.ToString());
            }

            btnPrevious.Enabled = pagina > 1;
            btnNext.Enabled = endIndex < useri.Count;
        }
    }
}
