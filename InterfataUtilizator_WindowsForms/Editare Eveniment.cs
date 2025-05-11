using LibrarieModele;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Editare_Eveniment: MetroForm
    {
        private Eveniment evenimentEditat;
        public Eveniment ObiectEditat => evenimentEditat; //Proprietate pentru a accesa obiectul editat dupa ce formularul este inchis

        public Editare_Eveniment(Eveniment eveniment)
        {
            InitializeComponent();
            evenimentEditat = eveniment.Clone();  //Lucram pe o clona
            cmbPrioritate.Items.AddRange(Enum.GetValues(typeof(EnumPentruPrioritateEveniment)).Cast<object>().ToArray());

            PopuleazaCampuri();
        }
        private void PopuleazaCampuri()
        {
            txtNume.Text = evenimentEditat.Titlu;
            txtData.Text = evenimentEditat.Data.ToString("dd.MM.yyyy HH:mm");
            txtDescriere.Text = evenimentEditat.Descriere;
            cmbPrioritate.SelectedItem = evenimentEditat.PrioritateEveniment;

            EnumPentruZiuaSaptamanii zileSelectate = evenimentEditat.ZileSelectate;

            foreach (Control control in groupZileSaptamana.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    EnumPentruZiuaSaptamanii zi;
                    if (Enum.TryParse(checkBox.Text, out zi))
                    {
                        checkBox.Checked = zileSelectate.HasFlag(zi);
                    }
                }

            }
        }

        private void Editare_Eveniment_Load(object sender, EventArgs e)
        {

        }

        private void btnAactualizeaza_Click(object sender, EventArgs e)
        {
            CodEroare validare = Validare();
            if (validare != CodEroare.Corect)
            {
                MarcheazaControaleCuDateIncorecte(validare);
                MessageBox.Show("Există erori în completarea formularului. Vă rugăm să verificați câmpurile marcate.",
                                "Eroare de validare",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            evenimentEditat.Titlu = txtNume.Text;
            evenimentEditat.Data = DateTime.ParseExact(txtData.Text, "dd.MM.yyyy HH:mm", null);
            evenimentEditat.Descriere = txtDescriere.Text;
            evenimentEditat.PrioritateEveniment = (EnumPentruPrioritateEveniment)cmbPrioritate.SelectedItem;

            evenimentEditat.ZileSelectate = 0;
            foreach (Control control in groupZileSaptamana.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    EnumPentruZiuaSaptamanii zi;
                    if (Enum.TryParse(checkBox.Text, out zi))
                    {
                        evenimentEditat.ZileSelectate |= zi;
                    }
                }
            }

            MessageBox.Show("Modificările au fost salvate cu succes!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        public CodEroare Validare()
        {
            CodEroare rezultat = CodEroare.Corect;
            if (string.IsNullOrWhiteSpace(txtNume.Text))
                rezultat |= CodEroare.NumeIncorect;
            if (string.IsNullOrWhiteSpace(txtData.Text))
                rezultat |= CodEroare.DataIncorecta;
            if (string.IsNullOrWhiteSpace(txtDescriere.Text))
                rezultat |= CodEroare.DescriereIncorecta;
            if (cmbPrioritate.SelectedIndex == -1)
                rezultat |= CodEroare.PrioritateIncorecta;
            if (GetZileSelectate() == 0)
                rezultat |= CodEroare.ZileIncorecte;

            return rezultat;
        }

        public void MarcheazaControaleCuDateIncorecte(CodEroare validare)
        {
            //Verificam cu operatorul bitwise AND daca codul de eroare este insetat in "validare"
            if ((validare & CodEroare.NumeIncorect) == CodEroare.NumeIncorect)
                lblNume.ForeColor = Color.Red;
            if ((validare & CodEroare.DataIncorecta) == CodEroare.DataIncorecta)
                lblData.ForeColor = Color.Red;
            if ((validare & CodEroare.DescriereIncorecta) == CodEroare.DescriereIncorecta)
                lblDescriere.ForeColor = Color.Red;
            if ((validare & CodEroare.PrioritateIncorecta) == CodEroare.PrioritateIncorecta)
                lblPrioritate.ForeColor = Color.Red;
            if ((validare & CodEroare.ZileIncorecte) == CodEroare.ZileIncorecte)
            {
                groupZileSaptamana.ForeColor = Color.Red;
                foreach (Control control in groupZileSaptamana.Controls)
                {
                    if (control is CheckBox checkBox)
                    {
                        checkBox.ForeColor = Color.Red;
                    }
                }
            }
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
