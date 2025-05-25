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
using NivelStocareDate;
using LibrarieModele;
using System.Runtime.Remoting.Messaging;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Caută_User: MetroForm
    {
        private ManagementUser_FisierText managementUser;
        public Caută_User()
        {
            InitializeComponent();
            string numeFisier2 = System.Configuration.ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie2 = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;
            managementUser = new ManagementUser_FisierText(caleCompletaFisier2);
        }

        private void Caută_User_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCauta_Click(object sender, EventArgs e)
        {
            string numeCautat = txtBoxNumeCautat.Text.Trim();
            string prenumeCautat = txtBoxPrenumeCautat.Text.Trim();
            if (string.IsNullOrEmpty(numeCautat) || string.IsNullOrEmpty(prenumeCautat))
            {
                MessageBox.Show("Introdu nume și prenume pentru căutare!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<User> useriGasiti = managementUser.CautaUseriDupaNumePrenume(numeCautat, prenumeCautat);

            if (useriGasiti == null)
            {
                MessageBox.Show("Nu s-a găsit niciun user cu acest nume și prenume.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Listă_Useri formLista = new Listă_Useri(useriGasiti);
            formLista.ShowDialog();
        }
    }
}
