using LibrarieModele;
using MetroFramework.Forms;
using System;
using System.Drawing;
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

            PopuleazaCampuri();
        }
        private void PopuleazaCampuri()
        {
            txtNume.Text = evenimentEditat.Titlu;
            txtData.Text = evenimentEditat.Data.ToString("dd.MM.yyyy HH:mm");
            txtDescriere.Text = evenimentEditat.Descriere;
            switch (evenimentEditat.PrioritateEveniment)
            {
                case EnumPentruPrioritateEveniment.SCĂZUTĂ:
                    radiobtnSCAZUTA.Checked = true;
                    break;
                case EnumPentruPrioritateEveniment.NORMALĂ:
                    radiobtnNORMALA.Checked = true;
                    break;
                case EnumPentruPrioritateEveniment.RIDICATĂ:
                    radiobtnRIDICATA.Checked = true;
                    break;
                case EnumPentruPrioritateEveniment.CRITICĂ:
                    radiobtnCRITICA.Checked = true;
                    break;
            }

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
            lblNume.ForeColor = Color.Black;
            lblData.ForeColor = Color.Black;
            lblDescriere.ForeColor = Color.Black;
            groupPrioritate.ForeColor = Color.Black;
            foreach (Control control in groupPrioritate.Controls)
            {
                control.ForeColor = Color.Black;
            }
            groupZileSaptamana.ForeColor = Color.Black;
            foreach (Control control in groupZileSaptamana.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.ForeColor = Color.Black;
                }
            }

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
            
            if (radiobtnSCAZUTA.Checked)
                evenimentEditat.PrioritateEveniment = EnumPentruPrioritateEveniment.SCĂZUTĂ;
            else if (radiobtnNORMALA.Checked)
                evenimentEditat.PrioritateEveniment = EnumPentruPrioritateEveniment.NORMALĂ;
            else if (radiobtnRIDICATA.Checked)
                evenimentEditat.PrioritateEveniment = EnumPentruPrioritateEveniment.RIDICATĂ;
            else if (radiobtnCRITICA.Checked)
                evenimentEditat.PrioritateEveniment = EnumPentruPrioritateEveniment.CRITICĂ;

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
            if (!radiobtnSCAZUTA.Checked && !radiobtnNORMALA.Checked && !radiobtnRIDICATA.Checked && !radiobtnCRITICA.Checked)
                rezultat |= CodEroare.PrioritateIncorecta;
            if (GetZileSelectate() == 0)
                rezultat |= CodEroare.ZileIncorecte;

            return rezultat;
        }

        public void MarcheazaControaleCuDateIncorecte(CodEroare validare)
        {
            //Verificam cu operatorul bitwise AND daca codul de eroare este setat in "validare"
            if ((validare & CodEroare.NumeIncorect) == CodEroare.NumeIncorect)
                lblNume.ForeColor = Color.Red;
            if ((validare & CodEroare.DataIncorecta) == CodEroare.DataIncorecta)
                lblData.ForeColor = Color.Red;
            if ((validare & CodEroare.DescriereIncorecta) == CodEroare.DescriereIncorecta)
                lblDescriere.ForeColor = Color.Red;
            if ((validare & CodEroare.PrioritateIncorecta) == CodEroare.PrioritateIncorecta)
            {
                groupPrioritate.ForeColor = Color.Red;
                foreach (Control control in groupPrioritate.Controls)
                {
                    control.ForeColor = Color.Red;
                }
            }
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
