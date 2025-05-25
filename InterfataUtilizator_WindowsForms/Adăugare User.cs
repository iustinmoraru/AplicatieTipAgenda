using LibrarieModele;
using MetroFramework.Forms;
using NivelStocareDate;
using System;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Adăugare_User: MetroForm
    {
        ManagementUser_FisierText managementUser;
        public Adăugare_User()
        {
            InitializeComponent();
            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie2 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;

            managementUser = new ManagementUser_FisierText(caleCompletaFisier2);
        }

        private void Adăugare_User_Load(object sender, EventArgs e)
        {

        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            lblNumeUser.ForeColor = Color.Black;
            lblPrenumeUser.ForeColor = Color.Black;
            groupGen.ForeColor = Color.Black;
            foreach (Control control in groupGen.Controls)
            {
                control.ForeColor = Color.Black;
            }

            CodEroareUser validare = Validare();
            if (validare != CodEroareUser.Corect)
            {
                MarcheazaControaleCuDateIncorecte(validare);
                MessageBox.Show("Există erori în completarea formularului. Vă rugăm să verificați câmpurile marcate.",
                                "Eroare de validare",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            string nume = txtBoxNumeUser.Text.Trim();
            string prenume = txtBoxPrenumeUser.Text.Trim();

            GenUser? gen = null;
            if (radioMASCULIN.Checked)
                gen = GenUser.MASCULIN;
            else if (radioFEMININ.Checked)
                gen = GenUser.FEMININ;
            else if (radioNECUNOSCUT.Checked)
                gen = GenUser.NECUNOSCUT;

            

            var userNou = new User(0, nume, prenume);
            userNou.Gen = gen.Value;

            managementUser.AdaugaUser(userNou);

            txtBoxNumeUser.Clear();
            txtBoxPrenumeUser.Clear();
            radioMASCULIN.Checked = false;
            radioFEMININ.Checked = false;
            radioNECUNOSCUT.Checked = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private CodEroareUser Validare()
        {
            CodEroareUser rezultat = CodEroareUser.Corect;
            if (string.IsNullOrWhiteSpace(txtBoxNumeUser.Text))
                rezultat |= CodEroareUser.NumeUserIncorect;
            if (string.IsNullOrWhiteSpace(txtBoxPrenumeUser.Text))
                rezultat |= CodEroareUser.PrenumeUserIncorect;
            if (!radioMASCULIN.Checked && !radioFEMININ.Checked && !radioNECUNOSCUT.Checked)
                rezultat |= CodEroareUser.GenIncorect;
            return rezultat;
        }
        private void MarcheazaControaleCuDateIncorecte(CodEroareUser validare)
        {
            if ((validare & CodEroareUser.NumeUserIncorect) == CodEroareUser.NumeUserIncorect)
                lblNumeUser.ForeColor = Color.Red;
            if ((validare & CodEroareUser.PrenumeUserIncorect) == CodEroareUser.PrenumeUserIncorect)
                lblPrenumeUser.ForeColor = Color.Red;
            if ((validare & CodEroareUser.GenIncorect) == CodEroareUser.GenIncorect)
            {
                groupGen.ForeColor = Color.Red;
                foreach (Control control in groupGen.Controls)
                {
                    control.ForeColor = Color.Red;
                }
            }
        }
    }
}
