namespace InterfataUtilizator_WindowsForms
{
    partial class Caută_Eveniment
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
            this.lblCautareNume = new MetroFramework.Controls.MetroLabel();
            this.txtNumeCautat = new MetroFramework.Controls.MetroTextBox();
            this.btnCauta = new MetroFramework.Controls.MetroTile();
            this.btnBack = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // lblCautareNume
            // 
            this.lblCautareNume.AutoSize = true;
            this.lblCautareNume.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblCautareNume.Location = new System.Drawing.Point(77, 112);
            this.lblCautareNume.Name = "lblCautareNume";
            this.lblCautareNume.Size = new System.Drawing.Size(49, 19);
            this.lblCautareNume.TabIndex = 0;
            this.lblCautareNume.Text = "Nume";
            // 
            // txtNumeCautat
            // 
            // 
            // 
            // 
            this.txtNumeCautat.CustomButton.Image = null;
            this.txtNumeCautat.CustomButton.Location = new System.Drawing.Point(189, 1);
            this.txtNumeCautat.CustomButton.Name = "";
            this.txtNumeCautat.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtNumeCautat.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNumeCautat.CustomButton.TabIndex = 1;
            this.txtNumeCautat.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNumeCautat.CustomButton.UseSelectable = true;
            this.txtNumeCautat.CustomButton.Visible = false;
            this.txtNumeCautat.Lines = new string[0];
            this.txtNumeCautat.Location = new System.Drawing.Point(146, 112);
            this.txtNumeCautat.MaxLength = 32767;
            this.txtNumeCautat.Name = "txtNumeCautat";
            this.txtNumeCautat.PasswordChar = '\0';
            this.txtNumeCautat.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNumeCautat.SelectedText = "";
            this.txtNumeCautat.SelectionLength = 0;
            this.txtNumeCautat.SelectionStart = 0;
            this.txtNumeCautat.ShortcutsEnabled = true;
            this.txtNumeCautat.Size = new System.Drawing.Size(213, 25);
            this.txtNumeCautat.Style = MetroFramework.MetroColorStyle.Red;
            this.txtNumeCautat.TabIndex = 6;
            this.txtNumeCautat.UseSelectable = true;
            this.txtNumeCautat.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNumeCautat.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnCauta
            // 
            this.btnCauta.ActiveControl = null;
            this.btnCauta.Location = new System.Drawing.Point(131, 158);
            this.btnCauta.Name = "btnCauta";
            this.btnCauta.Size = new System.Drawing.Size(169, 49);
            this.btnCauta.Style = MetroFramework.MetroColorStyle.Red;
            this.btnCauta.TabIndex = 14;
            this.btnCauta.Text = "Caută";
            this.btnCauta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCauta.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnCauta.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnCauta.UseSelectable = true;
            this.btnCauta.Click += new System.EventHandler(this.btnCauta_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(188, 213);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(55, 21);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Back";
            this.btnBack.UseSelectable = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Caută_Eveniment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 360);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCauta);
            this.Controls.Add(this.txtNumeCautat);
            this.Controls.Add(this.lblCautareNume);
            this.Name = "Caută_Eveniment";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Caută_Eveniment";
            this.Load += new System.EventHandler(this.Caută_Eveniment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblCautareNume;
        private MetroFramework.Controls.MetroTextBox txtNumeCautat;
        private MetroFramework.Controls.MetroTile btnCauta;
        private MetroFramework.Controls.MetroButton btnBack;
    }
}