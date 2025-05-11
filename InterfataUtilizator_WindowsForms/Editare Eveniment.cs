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
    }
}
