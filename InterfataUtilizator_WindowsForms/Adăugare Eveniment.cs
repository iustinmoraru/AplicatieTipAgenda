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
using LibrarieModele;
using NivelStocareDate;
using System.Configuration;
using System.IO;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Adăugare_Eveniment: MetroForm
    {
        ManagementAgenda_FisierText agendaFisier;

        public Adăugare_Eveniment()
        {
            InitializeComponent();
            cmbPrioritate.Items.AddRange(Enum.GetValues(typeof(EnumPentruPrioritateEveniment)).Cast<object>().ToArray());
            
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            agendaFisier = new ManagementAgenda_FisierText(caleCompletaFisier);
        }

        private void Adăugare_Eveniment_Load(object sender, EventArgs e)
        {

        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            string nume = txtNume.Text;
            string data = txtData.Text;
            string descriere = txtDescriere.Text;
            int prioritate = cmbPrioritate.SelectedIndex;

            EnumPentruZiuaSaptamanii zileSelectate = EnumPentruZiuaSaptamanii.Toate; // Default
            zileSelectate = GetZileSelectate();

            Eveniment ev = new Eveniment(
                0,
                txtNume.Text,
                DateTime.Parse(txtData.Text),
                txtDescriere.Text,
                (int)cmbPrioritate.SelectedItem,
                zileSelectate.ToString() );

            agendaFisier.AdaugaEveniment(ev);

            txtNume.Clear();
            txtData.Clear();
            txtDescriere.Clear();
            cmbPrioritate.SelectedIndex = -1;
            foreach (Control control in groupZileSaptamana.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private EnumPentruZiuaSaptamanii GetZileSelectate()
        {
            EnumPentruZiuaSaptamanii zileSelectate = 0;

            // Iterăm prin toate controalele din GroupBox
            foreach (Control control in groupZileSaptamana.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked) // Verificăm dacă este CheckBox și dacă este bifat
                {
                    if (Enum.TryParse(checkBox.Text, out EnumPentruZiuaSaptamanii zi))
                    {
                        zileSelectate |= zi; // Adăugăm ziua selectată folosind operatorul bitwise OR
                    }
                }
            }

            return zileSelectate;
        }

        
    }
}
