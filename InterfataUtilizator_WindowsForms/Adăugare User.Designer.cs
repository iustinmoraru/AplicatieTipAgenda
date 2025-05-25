namespace InterfataUtilizator_WindowsForms
{
    partial class Adăugare_User
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
            this.lblNumeUser = new MetroFramework.Controls.MetroLabel();
            this.lblPrenumeUser = new MetroFramework.Controls.MetroLabel();
            this.groupGen = new System.Windows.Forms.GroupBox();
            this.radioNECUNOSCUT = new MetroFramework.Controls.MetroRadioButton();
            this.radioFEMININ = new MetroFramework.Controls.MetroRadioButton();
            this.radioMASCULIN = new MetroFramework.Controls.MetroRadioButton();
            this.txtBoxNumeUser = new MetroFramework.Controls.MetroTextBox();
            this.txtBoxPrenumeUser = new MetroFramework.Controls.MetroTextBox();
            this.btnAdauga = new MetroFramework.Controls.MetroTile();
            this.btnBack = new MetroFramework.Controls.MetroButton();
            this.groupGen.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumeUser
            // 
            this.lblNumeUser.AutoSize = true;
            this.lblNumeUser.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblNumeUser.Location = new System.Drawing.Point(142, 78);
            this.lblNumeUser.Name = "lblNumeUser";
            this.lblNumeUser.Size = new System.Drawing.Size(49, 19);
            this.lblNumeUser.TabIndex = 0;
            this.lblNumeUser.Text = "Nume";
            this.lblNumeUser.UseCustomForeColor = true;
            // 
            // lblPrenumeUser
            // 
            this.lblPrenumeUser.AutoSize = true;
            this.lblPrenumeUser.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblPrenumeUser.Location = new System.Drawing.Point(142, 120);
            this.lblPrenumeUser.Name = "lblPrenumeUser";
            this.lblPrenumeUser.Size = new System.Drawing.Size(69, 19);
            this.lblPrenumeUser.TabIndex = 1;
            this.lblPrenumeUser.Text = "Prenume";
            this.lblPrenumeUser.UseCustomForeColor = true;
            // 
            // groupGen
            // 
            this.groupGen.Controls.Add(this.radioNECUNOSCUT);
            this.groupGen.Controls.Add(this.radioFEMININ);
            this.groupGen.Controls.Add(this.radioMASCULIN);
            this.groupGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupGen.Location = new System.Drawing.Point(142, 164);
            this.groupGen.Name = "groupGen";
            this.groupGen.Size = new System.Drawing.Size(216, 100);
            this.groupGen.TabIndex = 2;
            this.groupGen.TabStop = false;
            this.groupGen.Text = "Gen";
            // 
            // radioNECUNOSCUT
            // 
            this.radioNECUNOSCUT.AutoSize = true;
            this.radioNECUNOSCUT.Location = new System.Drawing.Point(28, 40);
            this.radioNECUNOSCUT.Name = "radioNECUNOSCUT";
            this.radioNECUNOSCUT.Size = new System.Drawing.Size(101, 15);
            this.radioNECUNOSCUT.Style = MetroFramework.MetroColorStyle.Red;
            this.radioNECUNOSCUT.TabIndex = 2;
            this.radioNECUNOSCUT.Text = "NECUNOSCUT";
            this.radioNECUNOSCUT.UseCustomForeColor = true;
            this.radioNECUNOSCUT.UseSelectable = true;
            // 
            // radioFEMININ
            // 
            this.radioFEMININ.AutoSize = true;
            this.radioFEMININ.Location = new System.Drawing.Point(118, 19);
            this.radioFEMININ.Name = "radioFEMININ";
            this.radioFEMININ.Size = new System.Drawing.Size(70, 15);
            this.radioFEMININ.Style = MetroFramework.MetroColorStyle.Red;
            this.radioFEMININ.TabIndex = 1;
            this.radioFEMININ.Text = "FEMININ";
            this.radioFEMININ.UseCustomForeColor = true;
            this.radioFEMININ.UseSelectable = true;
            // 
            // radioMASCULIN
            // 
            this.radioMASCULIN.AutoSize = true;
            this.radioMASCULIN.Location = new System.Drawing.Point(28, 19);
            this.radioMASCULIN.Name = "radioMASCULIN";
            this.radioMASCULIN.Size = new System.Drawing.Size(82, 15);
            this.radioMASCULIN.Style = MetroFramework.MetroColorStyle.Red;
            this.radioMASCULIN.TabIndex = 0;
            this.radioMASCULIN.Text = "MASCULIN";
            this.radioMASCULIN.UseCustomForeColor = true;
            this.radioMASCULIN.UseSelectable = true;
            // 
            // txtBoxNumeUser
            // 
            // 
            // 
            // 
            this.txtBoxNumeUser.CustomButton.Image = null;
            this.txtBoxNumeUser.CustomButton.Location = new System.Drawing.Point(87, 1);
            this.txtBoxNumeUser.CustomButton.Name = "";
            this.txtBoxNumeUser.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBoxNumeUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBoxNumeUser.CustomButton.TabIndex = 1;
            this.txtBoxNumeUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBoxNumeUser.CustomButton.UseSelectable = true;
            this.txtBoxNumeUser.CustomButton.Visible = false;
            this.txtBoxNumeUser.Lines = new string[0];
            this.txtBoxNumeUser.Location = new System.Drawing.Point(238, 78);
            this.txtBoxNumeUser.MaxLength = 32767;
            this.txtBoxNumeUser.Name = "txtBoxNumeUser";
            this.txtBoxNumeUser.PasswordChar = '\0';
            this.txtBoxNumeUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBoxNumeUser.SelectedText = "";
            this.txtBoxNumeUser.SelectionLength = 0;
            this.txtBoxNumeUser.SelectionStart = 0;
            this.txtBoxNumeUser.ShortcutsEnabled = true;
            this.txtBoxNumeUser.Size = new System.Drawing.Size(109, 23);
            this.txtBoxNumeUser.Style = MetroFramework.MetroColorStyle.Red;
            this.txtBoxNumeUser.TabIndex = 3;
            this.txtBoxNumeUser.UseSelectable = true;
            this.txtBoxNumeUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBoxNumeUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBoxPrenumeUser
            // 
            // 
            // 
            // 
            this.txtBoxPrenumeUser.CustomButton.Image = null;
            this.txtBoxPrenumeUser.CustomButton.Location = new System.Drawing.Point(87, 1);
            this.txtBoxPrenumeUser.CustomButton.Name = "";
            this.txtBoxPrenumeUser.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBoxPrenumeUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBoxPrenumeUser.CustomButton.TabIndex = 1;
            this.txtBoxPrenumeUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBoxPrenumeUser.CustomButton.UseSelectable = true;
            this.txtBoxPrenumeUser.CustomButton.Visible = false;
            this.txtBoxPrenumeUser.Lines = new string[0];
            this.txtBoxPrenumeUser.Location = new System.Drawing.Point(238, 120);
            this.txtBoxPrenumeUser.MaxLength = 32767;
            this.txtBoxPrenumeUser.Name = "txtBoxPrenumeUser";
            this.txtBoxPrenumeUser.PasswordChar = '\0';
            this.txtBoxPrenumeUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBoxPrenumeUser.SelectedText = "";
            this.txtBoxPrenumeUser.SelectionLength = 0;
            this.txtBoxPrenumeUser.SelectionStart = 0;
            this.txtBoxPrenumeUser.ShortcutsEnabled = true;
            this.txtBoxPrenumeUser.Size = new System.Drawing.Size(109, 23);
            this.txtBoxPrenumeUser.Style = MetroFramework.MetroColorStyle.Red;
            this.txtBoxPrenumeUser.TabIndex = 4;
            this.txtBoxPrenumeUser.UseSelectable = true;
            this.txtBoxPrenumeUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBoxPrenumeUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnAdauga
            // 
            this.btnAdauga.ActiveControl = null;
            this.btnAdauga.Location = new System.Drawing.Point(191, 301);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(146, 49);
            this.btnAdauga.Style = MetroFramework.MetroColorStyle.Red;
            this.btnAdauga.TabIndex = 5;
            this.btnAdauga.Text = "Adaugă";
            this.btnAdauga.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdauga.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnAdauga.UseSelectable = true;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(233, 356);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(55, 21);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseSelectable = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Adăugare_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAdauga);
            this.Controls.Add(this.txtBoxPrenumeUser);
            this.Controls.Add(this.txtBoxNumeUser);
            this.Controls.Add(this.groupGen);
            this.Controls.Add(this.lblPrenumeUser);
            this.Controls.Add(this.lblNumeUser);
            this.Name = "Adăugare_User";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Adăugare_User";
            this.Load += new System.EventHandler(this.Adăugare_User_Load);
            this.groupGen.ResumeLayout(false);
            this.groupGen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblNumeUser;
        private MetroFramework.Controls.MetroLabel lblPrenumeUser;
        private System.Windows.Forms.GroupBox groupGen;
        private MetroFramework.Controls.MetroTextBox txtBoxNumeUser;
        private MetroFramework.Controls.MetroTextBox txtBoxPrenumeUser;
        private MetroFramework.Controls.MetroRadioButton radioMASCULIN;
        private MetroFramework.Controls.MetroRadioButton radioNECUNOSCUT;
        private MetroFramework.Controls.MetroRadioButton radioFEMININ;
        private MetroFramework.Controls.MetroTile btnAdauga;
        private MetroFramework.Controls.MetroButton btnBack;
    }
}