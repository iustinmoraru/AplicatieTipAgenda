using LibrarieModele;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Editare_User: MetroForm
    {
        private User userEditat;
        public User ObiectEditat => userEditat; // Proprietate pentru a accesa userul editat
        public Editare_User(User user)
        {
            InitializeComponent();
            userEditat = new User(user.Id_User, user.Nume, user.Prenume)
            {
                Gen = user.Gen
            };
            PopuleazaCampuri();
        }
        private void PopuleazaCampuri()
        {
            txtBoxNumeUser.Text = userEditat.Nume;
            txtBoxPrenumeUser.Text = userEditat.Prenume;
            switch (userEditat.Gen)
            {
                case GenUser.MASCULIN:
                    radioMASCULIN.Checked = true;
                    break;
                case GenUser.FEMININ:
                    radioFEMININ.Checked = true;
                    break;
                case GenUser.NECUNOSCUT:
                    radioNECUNOSCUT.Checked = true;
                    break;
            }
        }

        private void Editare_User_Load(object sender, EventArgs e)
        {

        }


        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            CodEroareUser validare = Validare();
            MarcheazaControaleCuDateIncorecte(validare);

            if (validare != CodEroareUser.Corect)
            {
                MessageBox.Show("Există erori în completarea formularului. Vă rugăm să verificați câmpurile marcate.",
                                "Eroare de validare",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            userEditat.Nume = txtBoxNumeUser.Text.Trim();
            userEditat.Prenume = txtBoxPrenumeUser.Text.Trim();

            if (radioMASCULIN.Checked)
                userEditat.Gen = GenUser.MASCULIN;
            else if (radioFEMININ.Checked)
                userEditat.Gen = GenUser.FEMININ;
            else if (radioNECUNOSCUT.Checked)
                userEditat.Gen = GenUser.NECUNOSCUT;

            MessageBox.Show("Modificările au fost salvate cu succes!");
            this.DialogResult = DialogResult.OK;
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
            lblNumeUser.ForeColor = (validare & CodEroareUser.NumeUserIncorect) == CodEroareUser.NumeUserIncorect ? Color.Red : Color.Black;
            lblPrenumeUser.ForeColor = (validare & CodEroareUser.PrenumeUserIncorect) == CodEroareUser.PrenumeUserIncorect ? Color.Red : Color.Black;
            if ((validare & CodEroareUser.GenIncorect) == CodEroareUser.GenIncorect)
            {
                groupGen.ForeColor = Color.Red;
                foreach (Control control in groupGen.Controls)
                    control.ForeColor = Color.Red;
            }
            else
            {
                groupGen.ForeColor = Color.Black;
                foreach (Control control in groupGen.Controls)
                    control.ForeColor = Color.Black;
            }
        }
    }
}
