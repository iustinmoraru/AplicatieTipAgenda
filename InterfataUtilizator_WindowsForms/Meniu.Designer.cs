namespace InterfataUtilizator_WindowsForms
{
    partial class Meniu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AdaugareButton = new MetroFramework.Controls.MetroTile();
            this.ListaEvenimenteButton = new MetroFramework.Controls.MetroTile();
            this.CautaEvenimentButton = new MetroFramework.Controls.MetroTile();
            this.lblNumeUser = new MetroFramework.Controls.MetroLabel();
            this.lblPrenumeUser = new MetroFramework.Controls.MetroLabel();
            this.lblGenUser = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // AdaugareButton
            // 
            this.AdaugareButton.ActiveControl = null;
            this.AdaugareButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdaugareButton.Location = new System.Drawing.Point(200, 120);
            this.AdaugareButton.Name = "AdaugareButton";
            this.AdaugareButton.Size = new System.Drawing.Size(200, 80);
            this.AdaugareButton.Style = MetroFramework.MetroColorStyle.Red;
            this.AdaugareButton.TabIndex = 0;
            this.AdaugareButton.Text = "Adăugare Eveniment";
            this.AdaugareButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AdaugareButton.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.AdaugareButton.UseSelectable = true;
            this.AdaugareButton.Click += new System.EventHandler(this.AdaugareButton_Click);
            // 
            // ListaEvenimenteButton
            // 
            this.ListaEvenimenteButton.ActiveControl = null;
            this.ListaEvenimenteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListaEvenimenteButton.Location = new System.Drawing.Point(200, 206);
            this.ListaEvenimenteButton.Name = "ListaEvenimenteButton";
            this.ListaEvenimenteButton.Size = new System.Drawing.Size(200, 80);
            this.ListaEvenimenteButton.Style = MetroFramework.MetroColorStyle.Red;
            this.ListaEvenimenteButton.TabIndex = 1;
            this.ListaEvenimenteButton.Text = "Listă Evenimente";
            this.ListaEvenimenteButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ListaEvenimenteButton.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.ListaEvenimenteButton.UseSelectable = true;
            this.ListaEvenimenteButton.Click += new System.EventHandler(this.ListaEvenimenteButton_Click);
            // 
            // CautaEvenimentButton
            // 
            this.CautaEvenimentButton.ActiveControl = null;
            this.CautaEvenimentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CautaEvenimentButton.Location = new System.Drawing.Point(200, 292);
            this.CautaEvenimentButton.Name = "CautaEvenimentButton";
            this.CautaEvenimentButton.Size = new System.Drawing.Size(200, 80);
            this.CautaEvenimentButton.Style = MetroFramework.MetroColorStyle.Red;
            this.CautaEvenimentButton.TabIndex = 2;
            this.CautaEvenimentButton.Text = "Caută Eveniment";
            this.CautaEvenimentButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CautaEvenimentButton.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.CautaEvenimentButton.UseSelectable = true;
            this.CautaEvenimentButton.Click += new System.EventHandler(this.CautaEvenimentButton_Click);
            // 
            // lblNumeUser
            // 
            this.lblNumeUser.AutoSize = true;
            this.lblNumeUser.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblNumeUser.Location = new System.Drawing.Point(23, 60);
            this.lblNumeUser.Name = "lblNumeUser";
            this.lblNumeUser.Size = new System.Drawing.Size(49, 19);
            this.lblNumeUser.TabIndex = 3;
            this.lblNumeUser.Text = "Nume";
            // 
            // lblPrenumeUser
            // 
            this.lblPrenumeUser.AutoSize = true;
            this.lblPrenumeUser.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblPrenumeUser.Location = new System.Drawing.Point(78, 60);
            this.lblPrenumeUser.Name = "lblPrenumeUser";
            this.lblPrenumeUser.Size = new System.Drawing.Size(69, 19);
            this.lblPrenumeUser.TabIndex = 4;
            this.lblPrenumeUser.Text = "Prenume";
            // 
            // lblGenUser
            // 
            this.lblGenUser.AutoSize = true;
            this.lblGenUser.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblGenUser.Location = new System.Drawing.Point(23, 79);
            this.lblGenUser.Name = "lblGenUser";
            this.lblGenUser.Size = new System.Drawing.Size(35, 19);
            this.lblGenUser.TabIndex = 5;
            this.lblGenUser.Text = "Gen";
            // 
            // Meniu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.lblGenUser);
            this.Controls.Add(this.lblPrenumeUser);
            this.Controls.Add(this.lblNumeUser);
            this.Controls.Add(this.CautaEvenimentButton);
            this.Controls.Add(this.ListaEvenimenteButton);
            this.Controls.Add(this.AdaugareButton);
            this.Name = "Meniu";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Meniu";
            this.Load += new System.EventHandler(this.Meniu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile AdaugareButton;
        private MetroFramework.Controls.MetroTile ListaEvenimenteButton;
        private MetroFramework.Controls.MetroTile CautaEvenimentButton;
        private MetroFramework.Controls.MetroLabel lblNumeUser;
        private MetroFramework.Controls.MetroLabel lblPrenumeUser;
        private MetroFramework.Controls.MetroLabel lblGenUser;
    }
}