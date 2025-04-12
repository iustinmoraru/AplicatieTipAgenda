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
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
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
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroTile1.Location = new System.Drawing.Point(200, 292);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(200, 80);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTile1.TabIndex = 2;
            this.metroTile1.Text = "Caută Eveniment";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile1.UseSelectable = true;
            // 
            // Meniu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.ListaEvenimenteButton);
            this.Controls.Add(this.AdaugareButton);
            this.Name = "Meniu";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Meniu";
            this.Load += new System.EventHandler(this.Meniu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile AdaugareButton;
        private MetroFramework.Controls.MetroTile ListaEvenimenteButton;
        private MetroFramework.Controls.MetroTile metroTile1;
    }
}