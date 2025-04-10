﻿using System;
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
        private Label lblAdaugaNume;
        private TextBox txtNume;
        private Label lblData;
        private Label lblAdaugaData;
        private TextBox txtData;
        private Label lblDescriere;
        private Label lblAdaugaDescriere;
        private TextBox txtDescriere;
        private Label lblPrioritate;
        private Label lblAdaugaPrioritate;
        private ComboBox cmbPrioritate;
        private Label lblZileSaptamana;
        private Label lblAdaugaZileSaptamana;
        private CheckedListBox clbZileSaptamana;

        private Label[] lblsNume;
        private Label[] lblsData;
        private Label[] lblsDescriere;
        private Label[] lblsPrioritate;
        private Label[] lblsZileSaptamana;

        private Button btnAdaugaEveniment;
        private Button btnRefresh;

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
            this.Font = new Font("Arial", 9, FontStyle.Bold);
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

            //Adaugare evenimente
            lblAdaugaNume = new Label();
            lblAdaugaNume.Text = "Nume";
            lblAdaugaNume.Left = DIMENSIUNE_PAS_X;
            lblAdaugaNume.AutoSize = true;
            this.Controls.Add(lblAdaugaNume);

            txtNume = new TextBox();
            txtNume.Width = LATIME_CONTROL;
            txtNume.Left = lblAdaugaNume.Right + 112;
            this.Controls.Add(txtNume);

            lblAdaugaData = new Label();
            lblAdaugaData.Text = "Data (dd.mm.yyyy hh:mm)";
            lblAdaugaData.Width = LATIME_CONTROL;
            lblAdaugaData.Left = DIMENSIUNE_PAS_X;
            lblAdaugaData.Top = DIMENSIUNE_PAS_Y;
            lblAdaugaData.AutoSize = true;
            this.Controls.Add(lblAdaugaData);

            txtData = new TextBox();
            txtData.Width = LATIME_CONTROL;
            txtData.Left = lblAdaugaData.Right;
            txtData.Top = DIMENSIUNE_PAS_Y;
            this.Controls.Add(txtData);

            lblAdaugaDescriere = new Label();
            lblAdaugaDescriere.Text = "Descriere";
            lblAdaugaDescriere.Width = LATIME_CONTROL;
            lblAdaugaDescriere.Left = DIMENSIUNE_PAS_X;
            lblAdaugaDescriere.Top = 2 * DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblAdaugaDescriere);

            txtDescriere = new TextBox();
            txtDescriere.Width = LATIME_CONTROL;
            txtDescriere.Left = lblAdaugaData.Right;
            txtDescriere.Top = 2 * DIMENSIUNE_PAS_Y;
            this.Controls.Add(txtDescriere);

            lblAdaugaPrioritate = new Label();
            lblAdaugaPrioritate.Text = "Prioritate";
            lblAdaugaPrioritate.Width = LATIME_CONTROL;
            lblAdaugaPrioritate.Left = DIMENSIUNE_PAS_X;
            lblAdaugaPrioritate.Top = 3 * DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblAdaugaPrioritate);

            cmbPrioritate = new ComboBox();
            cmbPrioritate.Width = LATIME_CONTROL;
            cmbPrioritate.Left = lblAdaugaData.Right;
            cmbPrioritate.Top = 3 * DIMENSIUNE_PAS_Y;
            cmbPrioritate.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrioritate.Items.AddRange(Enum.GetValues(typeof(EnumPentruPrioritateEveniment)).Cast<object>().ToArray());
            cmbPrioritate.SelectedIndex = -1;
            this.Controls.Add(cmbPrioritate);

            lblAdaugaZileSaptamana = new Label();
            lblAdaugaZileSaptamana.Text = "Zile saptamana";
            lblAdaugaZileSaptamana.Width = LATIME_CONTROL;
            lblAdaugaZileSaptamana.Left = DIMENSIUNE_PAS_X;
            lblAdaugaZileSaptamana.Top = 4 * DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblAdaugaZileSaptamana);

            clbZileSaptamana = new CheckedListBox();
            clbZileSaptamana.Width = LATIME_CONTROL;
            clbZileSaptamana.Left = lblAdaugaData.Right;
            clbZileSaptamana.Top = 4 * DIMENSIUNE_PAS_Y;
            clbZileSaptamana.Height = 150;
            clbZileSaptamana.Items.AddRange(Enum.GetValues(typeof(EnumPentruZiuaSaptamanii)).Cast<object>().ToArray());
            this.Controls.Add(clbZileSaptamana);

            //Butoane
            btnAdaugaEveniment = new Button();
            btnAdaugaEveniment.Text = "Adauga";
            btnAdaugaEveniment.Width = LATIME_CONTROL;
            btnAdaugaEveniment.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 9 * DIMENSIUNE_PAS_Y);
            btnAdaugaEveniment.Click += AdaugaEvenimentButton;
            this.Controls.Add(btnAdaugaEveniment);

            btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Width = LATIME_CONTROL;
            btnRefresh.Location = new System.Drawing.Point(2 * DIMENSIUNE_PAS_X, 9 * DIMENSIUNE_PAS_Y);
            btnRefresh.Click += RefreshButton;
            this.Controls.Add(btnRefresh);

            // Afisare evenimente
            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume";
            lblNume.Left = DIMENSIUNE_PAS_X;
            lblNume.Top = 11 * DIMENSIUNE_PAS_Y;
            lblNume.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblNume);

            lblData = new Label();
            lblData.Width = LATIME_CONTROL;
            lblData.Text = "Data";
            lblData.Left = 2 * DIMENSIUNE_PAS_X;
            lblData.Top = 11 * DIMENSIUNE_PAS_Y;
            lblData.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblData);

            lblDescriere = new Label();
            lblDescriere.Width = LATIME_CONTROL;
            lblDescriere.Text = "Descriere";
            lblDescriere.Left = 3 * DIMENSIUNE_PAS_X;
            lblDescriere.Top = 11 * DIMENSIUNE_PAS_Y;
            lblDescriere.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblDescriere);

            lblPrioritate = new Label();
            lblPrioritate.Width = LATIME_CONTROL;
            lblPrioritate.Text = "Prioritate";
            lblPrioritate.Left = 4 * DIMENSIUNE_PAS_X;
            lblPrioritate.Top = 11 * DIMENSIUNE_PAS_Y;
            lblPrioritate.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblPrioritate);

            lblZileSaptamana = new Label();
            lblZileSaptamana.Width = LATIME_CONTROL;
            lblZileSaptamana.Text = "Zile saptamana";
            lblZileSaptamana.Left = 5 * DIMENSIUNE_PAS_X;
            lblZileSaptamana.Top = 11 * DIMENSIUNE_PAS_Y;
            lblZileSaptamana.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblZileSaptamana);
        }

        private int ValidareEveniment(string nume, string data, string descriere, int prioritate)
        {
            bool numeValid = !string.IsNullOrEmpty(nume);
            bool dataValid = DateTime.TryParse(data, out _);
            bool descriereValid = !string.IsNullOrEmpty(descriere);
            bool prioritateValid = prioritate >= 0;
            bool zileValid = clbZileSaptamana.CheckedItems.Count > 0;

            if (!numeValid && !dataValid && !descriereValid && !prioritateValid && !zileValid)
                return 21; 
            if (!numeValid && !dataValid && !descriereValid && !prioritateValid)
                return 20;
            if (!numeValid && !dataValid && !descriereValid && !zileValid)
                return 19;
            if (!numeValid && !dataValid && !prioritateValid && !zileValid)
                return 18;
            if (!numeValid && !descriereValid && !prioritateValid && !zileValid)
                return 17;
            if (!dataValid && !descriereValid && !prioritateValid && !zileValid)
                return 16;
            if (!numeValid && !dataValid && !descriereValid)
                return 15;
            if (!numeValid && !dataValid && !prioritateValid)
                return 14;
            if (!numeValid && !dataValid && !zileValid)
                return 13;
            if (!numeValid && !descriereValid && !prioritateValid)
                return 12;
            if (!numeValid && !descriereValid && !zileValid)
                return 11;
            if (!numeValid && !prioritateValid && !zileValid)
                return 10;
            if (!dataValid && !descriereValid && !prioritateValid)
                return 9;
            if (!dataValid && !descriereValid && !zileValid)
                return 8;
            if (!dataValid && !prioritateValid && !zileValid)
                return 7;
            if (!descriereValid && !prioritateValid && !zileValid)
                return 6;
            if (!numeValid)
                return 5;
            if (!dataValid)
                return 4;
            if (!descriereValid)
                return 3;
            if (!prioritateValid)
                return 2;
            if (!zileValid)
                return 1;

            return 0;
        }


        private void AdaugaEvenimentButton(object sender, EventArgs e)
        {
            string nume = txtNume.Text;
            string data = txtData.Text;
            string descriere = txtDescriere.Text;
            int prioritate = cmbPrioritate.SelectedIndex;

            lblAdaugaNume.ForeColor = Color.Black;
            lblAdaugaData.ForeColor = Color.Black;
            lblAdaugaDescriere.ForeColor = Color.Black;
            lblAdaugaPrioritate.ForeColor = Color.Black;
            lblAdaugaZileSaptamana.ForeColor = Color.Black;

            int codEroare = ValidareEveniment(nume, data, descriere, prioritate);

            if (codEroare != 0)
            {
                if (codEroare == 21 || codEroare == 20 || codEroare == 19 || codEroare == 18 || codEroare == 17 || codEroare == 15 || 
                    codEroare == 14 || codEroare == 13 || codEroare == 12 || codEroare == 11 || codEroare == 10 || codEroare == 5)
                    lblAdaugaNume.ForeColor = Color.Red;
                if (codEroare == 21 || codEroare == 20 || codEroare == 19 || codEroare == 18 || codEroare == 15 || codEroare == 14 ||
                    codEroare == 13 || codEroare == 4 || codEroare == 9 || codEroare == 8 || codEroare == 7 || codEroare == 16)
                    lblAdaugaData.ForeColor = Color.Red;
                if (codEroare == 21 || codEroare == 20 || codEroare == 19 || codEroare == 15 || codEroare == 12 || codEroare == 11 || 
                    codEroare == 9 || codEroare == 8 || codEroare == 6 || codEroare == 3 || codEroare == 17 || codEroare == 16)
                    lblAdaugaDescriere.ForeColor = Color.Red;
                if (codEroare == 21 || codEroare == 20 || codEroare == 18 || codEroare == 17 || codEroare == 16 || codEroare == 14 || 
                    codEroare == 12 || codEroare == 10 || codEroare == 9 || codEroare == 7  || codEroare == 6 || codEroare == 2)
                    lblAdaugaPrioritate.ForeColor = Color.Red;
                if (codEroare == 21 || codEroare == 19 || codEroare == 18 || codEroare == 17 || codEroare == 16 || codEroare == 13 ||
                    codEroare == 11 || codEroare == 10 || codEroare == 8 || codEroare == 7 || codEroare == 6 || codEroare == 1)
                    lblAdaugaZileSaptamana.ForeColor = Color.Red;

                MessageBox.Show("Eroare: Datele introduse sunt incorecte!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Eveniment eveniment = new Eveniment(
                0,
                txtNume.Text,
                DateTime.Parse(txtData.Text),
                txtDescriere.Text,
                (int)cmbPrioritate.SelectedItem,
                clbZileSaptamana.CheckedItems.Cast<EnumPentruZiuaSaptamanii>().Aggregate((a, b) => a | b).ToString()); // combina toate zilele selectate

            int nrEvenimente = 0;
            agendaFisier.AdaugaEveniment(eveniment, ref nrEvenimente);

            txtNume.Clear();
            txtData.Clear();
            txtDescriere.Clear();
            cmbPrioritate.SelectedIndex = -1;
            clbZileSaptamana.ClearSelected();
        }

        private void RefreshButton(object sender, EventArgs e)
        {
            AfiseazaEvenimente();
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
                lblsZileSaptamana[i].Width = LATIME_CONTROL + 100;
                lblsZileSaptamana[i].Text = eveniment.ZileSelectate.ToString();
                lblsZileSaptamana[i].Left = 5 * DIMENSIUNE_PAS_X;
                lblsZileSaptamana[i].Top = lblZileSaptamana.Bottom + (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsZileSaptamana[i]);

                i++;
            }
        }
    }
}
