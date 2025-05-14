using LibrarieModele;
using MetroFramework.Forms;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Listă_Evenimente: MetroForm
    {
        private ManagementAgenda_FisierText agendaFisier;
        private List<Eveniment> evenimente;
        private int paginaCurenta = 1;
        private const int EvenimentePePagina = 10;
        public Listă_Evenimente()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            agendaFisier = new ManagementAgenda_FisierText(caleCompletaFisier);
            evenimente = agendaFisier.GetEvenimente();
        }

        private void Listă_Evenimente_Load(object sender, EventArgs e)
        {
            // Configuram coloanele pentru metroGridEvenimente
            metroGridEvenimente.Columns.Clear();
            metroGridEvenimente.Columns.Add("Titlu", "Titlu");
            metroGridEvenimente.Columns.Add("Data", "Data");
            metroGridEvenimente.Columns.Add("Descriere", "Descriere");
            metroGridEvenimente.Columns.Add("Prioritate", "Prioritate");
            metroGridEvenimente.Columns.Add("Zile", "Zile");

            // Setam coloanele sa aiba dimensiuni fixe sau sa se redimensioneze proportional
            metroGridEvenimente.Columns["Titlu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            metroGridEvenimente.Columns["Data"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            metroGridEvenimente.Columns["Descriere"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            metroGridEvenimente.Columns["Prioritate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Setam coloana "Zile" sa umple spatiul ramas
            metroGridEvenimente.Columns["Zile"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            AfiseazaPagina(paginaCurenta);
        }

        public Listă_Evenimente(List<Eveniment> evenimenteFiltrate)
        {
            InitializeComponent();
            this.evenimente = evenimenteFiltrate;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AfiseazaPagina(int pagina)
        {
            // Calculam indexul de start si de sfarsit
            int startIndex = (pagina - 1) * EvenimentePePagina;
            int endIndex = Math.Min(startIndex + EvenimentePePagina, evenimente.Count);
            metroGridEvenimente.Rows.Clear();

            for (int i = startIndex; i < endIndex; i++)
            {
                Eveniment ev = evenimente[i];
                metroGridEvenimente.Rows.Add(
                    ev.Titlu,
                    ev.Data.ToString("dd/MM/yyyy HH:mm"),
                    ev.Descriere,
                    ev.PrioritateEveniment.ToString(),
                    ev.ZileSelectate.ToString()
                );
            }
            // Actualizam butoanele de navigare
            btnPrevious.Enabled = pagina > 1;
            btnNext.Enabled = endIndex < evenimente.Count;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (paginaCurenta > 1)
            {
                paginaCurenta--;
                AfiseazaPagina(paginaCurenta);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (paginaCurenta * EvenimentePePagina < evenimente.Count)
            {
                paginaCurenta++;
                AfiseazaPagina(paginaCurenta);
            }
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (metroGridEvenimente.SelectedRows.Count > 0)
            {
                int indexSelectat = metroGridEvenimente.SelectedRows[0].Index;
                Eveniment evenimentSelectat = evenimente[indexSelectat];

                Editare_Eveniment formEditare = new Editare_Eveniment(evenimentSelectat);
                if (formEditare.ShowDialog() == DialogResult.OK)
                {
                    evenimente[indexSelectat] = formEditare.ObiectEditat;

                    agendaFisier.SalveazaEvenimente(evenimente);
                    AfiseazaPagina(paginaCurenta);
                }
            }
            else
            {
                MessageBox.Show("Selectați un eveniment pentru a-l edita.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
