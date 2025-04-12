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
            this.txtNume = new MetroFramework.Controls.MetroTextBox();
            this.btnCauta = new MetroFramework.Controls.MetroTile();
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
            // txtNume
            // 
            // 
            // 
            // 
            this.txtNume.CustomButton.Image = null;
            this.txtNume.CustomButton.Location = new System.Drawing.Point(76, 1);
            this.txtNume.CustomButton.Name = "";
            this.txtNume.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtNume.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNume.CustomButton.TabIndex = 1;
            this.txtNume.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNume.CustomButton.UseSelectable = true;
            this.txtNume.CustomButton.Visible = false;
            this.txtNume.Lines = new string[0];
            this.txtNume.Location = new System.Drawing.Point(146, 112);
            this.txtNume.MaxLength = 32767;
            this.txtNume.Name = "txtNume";
            this.txtNume.PasswordChar = '\0';
            this.txtNume.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNume.SelectedText = "";
            this.txtNume.SelectionLength = 0;
            this.txtNume.SelectionStart = 0;
            this.txtNume.ShortcutsEnabled = true;
            this.txtNume.Size = new System.Drawing.Size(100, 25);
            this.txtNume.TabIndex = 6;
            this.txtNume.UseSelectable = true;
            this.txtNume.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNume.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnCauta
            // 
            this.btnCauta.ActiveControl = null;
            this.btnCauta.Location = new System.Drawing.Point(77, 163);
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
            // Caută_Eveniment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 360);
            this.Controls.Add(this.btnCauta);
            this.Controls.Add(this.txtNume);
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
        private MetroFramework.Controls.MetroTextBox txtNume;
        private MetroFramework.Controls.MetroTile btnCauta;
    }
}