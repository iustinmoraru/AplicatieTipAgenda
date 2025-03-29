using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarieModele;
using NivelStocareDate;
using System.Configuration;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        ManagementAgenda_FisierText agendaFisier;
        ManagementUser_FisierText managementUser;

        private Label lblNumeUser;
        private Label lblPrenumeUser;
        private Label lblGenUser;

        private Label lblNume;
        private Label lblData;
        private Label lblDescriere;
        private Label lblPrioritate;
        private Label lblZileSaptamana;

        private Label[] lblsNume;
        private Label[] lblsData;
        private Label[] lblsDescriere;
        private Label[] lblsPrioritate;
        private Label[] lblsZileSaptamana;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;

        public Form1()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie2 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;

            agendaFisier = new ManagementAgenda_FisierText(caleCompletaFisier);
            managementUser = new ManagementUser_FisierText(caleCompletaFisier2);

            int nrEvenimente = 0;
            int nrUseri = 0;

            Eveniment[] evenimente = agendaFisier.GetEvenimente(out nrEvenimente);
            User[] users = managementUser.GetUsers(out nrUseri);

            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(100, 100);
            this.Text = "Agenda evenimente";


            // Afisare useri
            lblNumeUser = new Label();
            lblNumeUser.Width = LATIME_CONTROL;
            this.Controls.Add(lblNumeUser);

            lblPrenumeUser = new Label();
            lblPrenumeUser.Width = LATIME_CONTROL;
            this.Controls.Add(lblPrenumeUser);

            lblGenUser = new Label();
            lblGenUser.Width = LATIME_CONTROL;
            this.Controls.Add(lblGenUser);


            // Afisare evenimente
            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume";
            lblNume.Left = DIMENSIUNE_PAS_X;
            lblNume.Top = lblPrenumeUser.Bottom + DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblNume);

            lblData = new Label();
            lblData.Width = LATIME_CONTROL;
            lblData.Text = "Data";
            lblData.Left = 2 * DIMENSIUNE_PAS_X;
            lblData.Top = lblPrenumeUser.Bottom + DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblData);

            lblDescriere = new Label();
            lblDescriere.Width = LATIME_CONTROL;
            lblDescriere.Text = "Descriere";
            lblDescriere.Left = 3 * DIMENSIUNE_PAS_X;
            lblDescriere.Top = lblPrenumeUser.Bottom + DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblDescriere);

            lblPrioritate = new Label();
            lblPrioritate.Width = LATIME_CONTROL;
            lblPrioritate.Text = "Prioritate";
            lblPrioritate.Left = 4 * DIMENSIUNE_PAS_X;
            lblPrioritate.Top = lblPrenumeUser.Bottom + DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblPrioritate);

            lblZileSaptamana = new Label();
            lblZileSaptamana.Width = LATIME_CONTROL;
            lblZileSaptamana.Text = "Zile saptamana";
            lblZileSaptamana.Left = 5 * DIMENSIUNE_PAS_X;
            lblZileSaptamana.Top = lblPrenumeUser.Bottom + DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblZileSaptamana);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfisareUser();
            AfiseazaEvenimente();
        }

        private void AfisareUser()
        {
            User[] useri = managementUser.GetUsers(out int nrUseri);

            if (nrUseri > 0)
            {
                User user = useri[0];
                lblNumeUser.Text = user.Nume;
                lblNumeUser.Left = 10;
                lblNumeUser.Top = 10;
                lblNumeUser.AutoSize = true;
                this.Controls.Add(lblNumeUser);

                lblPrenumeUser.Text = user.Prenume;
                lblPrenumeUser.Left = lblNumeUser.Left + lblNumeUser.PreferredWidth + 5;
                lblPrenumeUser.Top = 10;
                lblPrenumeUser.AutoSize = true; 
                this.Controls.Add(lblPrenumeUser);

                lblGenUser.Text = user.Gen.ToString();
                lblGenUser.Left = 10;
                lblGenUser.Top = lblPrenumeUser.Bottom + 5;
                lblGenUser.AutoSize = true;
                this.Controls.Add(lblGenUser);
            }

        }

        private void AfiseazaEvenimente()
        {
            Eveniment[] evenimente = agendaFisier.GetEvenimente(out int nrEvenimente);

            lblsNume = new Label[nrEvenimente];
            lblsData = new Label[nrEvenimente];
            lblsDescriere = new Label[nrEvenimente];    
            lblsPrioritate = new Label[nrEvenimente];
            lblsZileSaptamana = new Label[nrEvenimente];

            int i = 0;

            foreach (Eveniment eveniment in evenimente)
            { 
                lblsNume[i] = new Label();
                lblsNume[i].Width = LATIME_CONTROL;
                lblsNume[i].Text = eveniment.Titlu;
                lblsNume[i].Left = DIMENSIUNE_PAS_X;
                lblsNume[i].Top = lblZileSaptamana.Bottom + (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNume[i]);

                lblsData[i] = new Label();
                lblsData[i].Width = LATIME_CONTROL;
                lblsData[i].Text = eveniment.Data.ToString();
                lblsData[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsData[i].Top = lblZileSaptamana.Bottom + (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsData[i]);

                lblsDescriere[i] = new Label();
                lblsDescriere[i].Width = LATIME_CONTROL;
                lblsDescriere[i].Text = eveniment.Descriere;
                lblsDescriere[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsDescriere[i].Top = lblZileSaptamana.Bottom + (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsDescriere[i]);

                lblsPrioritate[i] = new Label();
                lblsPrioritate[i].Width = LATIME_CONTROL;
                lblsPrioritate[i].Text = eveniment.PrioritateEveniment.ToString();
                lblsPrioritate[i].Left = 4 * DIMENSIUNE_PAS_X;
                lblsPrioritate[i].Top = lblZileSaptamana.Bottom + (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsPrioritate[i]);

                lblsZileSaptamana[i] = new Label();
                lblsZileSaptamana[i].Width = LATIME_CONTROL;
                lblsZileSaptamana[i].Text = eveniment.ZileSelectate.ToString();
                lblsZileSaptamana[i].Left = 5 * DIMENSIUNE_PAS_X;
                lblsZileSaptamana[i].Top = lblZileSaptamana.Bottom + (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsZileSaptamana[i]);

                i++;
            }
        }
    }
}
