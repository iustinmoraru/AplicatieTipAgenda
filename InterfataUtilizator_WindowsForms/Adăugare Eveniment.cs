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

namespace InterfataUtilizator_WindowsForms
{
    public partial class Adăugare_Eveniment: MetroForm
    {
        public Adăugare_Eveniment()
        {
            InitializeComponent();
            cmbPrioritate.Items.AddRange(Enum.GetValues(typeof(EnumPentruPrioritateEveniment)).Cast<object>().ToArray());
        }

        private void Adăugare_Eveniment_Load(object sender, EventArgs e)
        {

        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
