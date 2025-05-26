using LibrarieModele;
using MetroFramework.Forms;
using NivelStocareDate;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Adăugare_Eveniment: MetroForm
    {
        ManagementAgenda_FisierText agendaFisier;
        private User userCurent;
        public Adăugare_Eveniment(User user)
        {
            InitializeComponent();
            userCurent = user;

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

            EnumPentruZiuaSaptamanii zileSelectate = EnumPentruZiuaSaptamanii.Toate; // Default
            zileSelectate = GetZileSelectate();

            DateTime dataEveniment;
            if (!DateTime.TryParse(txtData.Text, out dataEveniment))
            {
                MessageBox.Show("Data introdusă nu este validă!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Eveniment ev = new Eveniment(
                0,
                txtNume.Text,
                dataEveniment,
                txtDescriere.Text,
                GetPrioritateSelectata(),
                zileSelectate.ToString() );
            
            ev.UserId = userCurent.Id_User; //Setez UserId

            agendaFisier.AdaugaEveniment(ev);

            txtNume.Clear();
            txtData.Clear();
            txtDescriere.Clear();
            radiobtnSCAZUTA.Checked = false;
            radiobtnNORMALA.Checked = false;
            radiobtnRIDICATA.Checked = false;
            radiobtnCRITICA.Checked = false;
            foreach (Control control in groupZileSaptamana.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
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
            //Verificam cu operatorul bitwise AND daca codul de eroare este insetat in "validare"
            if ((validare & CodEroare.NumeIncorect) == CodEroare.NumeIncorect)
                lblNume.ForeColor = Color.Red;
            if ( (validare & CodEroare.DataIncorecta) == CodEroare.DataIncorecta )
                lblData.ForeColor = Color.Red;
            if ( (validare & CodEroare.DescriereIncorecta) == CodEroare.DescriereIncorecta )
                lblDescriere.ForeColor = Color.Red;
            if ((validare & CodEroare.PrioritateIncorecta) == CodEroare.PrioritateIncorecta)
            {
                groupPrioritate.ForeColor = Color.Red;
                foreach (Control control in groupPrioritate.Controls)
                {
                    control.ForeColor = Color.Red;
                }
            }
            if ( (validare & CodEroare.ZileIncorecte) == CodEroare.ZileIncorecte )
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

        private int GetPrioritateSelectata()
        {
            if (radiobtnSCAZUTA.Checked)
                return (int)EnumPentruPrioritateEveniment.SCĂZUTĂ;
            if (radiobtnNORMALA.Checked)
                return (int)EnumPentruPrioritateEveniment.NORMALĂ;
            if (radiobtnRIDICATA.Checked)
                return (int)EnumPentruPrioritateEveniment.RIDICATĂ;
            if (radiobtnCRITICA.Checked)
                return (int)EnumPentruPrioritateEveniment.CRITICĂ;
            return 0;
        }


    }
}
