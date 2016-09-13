namespace Coloretto1._2
{
    partial class Parametres_nom
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
            this.btValider = new System.Windows.Forms.Button();
            this.btRetour = new System.Windows.Forms.Button();
            this.tbIA4 = new System.Windows.Forms.TextBox();
            this.tbIA3 = new System.Windows.Forms.TextBox();
            this.tbIA2 = new System.Windows.Forms.TextBox();
            this.tbIA1 = new System.Windows.Forms.TextBox();
            this.numUpNbJouers = new System.Windows.Forms.NumericUpDown();
            this.tbPseudo = new System.Windows.Forms.TextBox();
            this.lbPseudoAdversaires = new System.Windows.Forms.Label();
            this.lbNbJouers = new System.Windows.Forms.Label();
            this.lbPseudo = new System.Windows.Forms.Label();
            this.lbTitleParametres = new System.Windows.Forms.Label();
            this.logoGame = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpNbJouers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoGame)).BeginInit();
            this.SuspendLayout();
            // 
            // btValider
            // 
            this.btValider.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btValider.Location = new System.Drawing.Point(305, 421);
            this.btValider.Name = "btValider";
            this.btValider.Size = new System.Drawing.Size(75, 23);
            this.btValider.TabIndex = 27;
            this.btValider.Text = "Valider";
            this.btValider.UseVisualStyleBackColor = false;
            this.btValider.Click += new System.EventHandler(this.btValider_Click);
            // 
            // btRetour
            // 
            this.btRetour.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btRetour.Location = new System.Drawing.Point(56, 421);
            this.btRetour.Name = "btRetour";
            this.btRetour.Size = new System.Drawing.Size(75, 23);
            this.btRetour.TabIndex = 28;
            this.btRetour.Text = "< Retour";
            this.btRetour.UseVisualStyleBackColor = false;
            this.btRetour.Click += new System.EventHandler(this.btRetour_Click);
            // 
            // tbIA4
            // 
            this.tbIA4.Location = new System.Drawing.Point(418, 360);
            this.tbIA4.Name = "tbIA4";
            this.tbIA4.Size = new System.Drawing.Size(80, 20);
            this.tbIA4.TabIndex = 25;
            this.tbIA4.Visible = false;
            // 
            // tbIA3
            // 
            this.tbIA3.Location = new System.Drawing.Point(303, 360);
            this.tbIA3.Name = "tbIA3";
            this.tbIA3.Size = new System.Drawing.Size(86, 20);
            this.tbIA3.TabIndex = 24;
            this.tbIA3.Visible = false;
            // 
            // tbIA2
            // 
            this.tbIA2.Location = new System.Drawing.Point(190, 360);
            this.tbIA2.Name = "tbIA2";
            this.tbIA2.Size = new System.Drawing.Size(85, 20);
            this.tbIA2.TabIndex = 23;
            this.tbIA2.Visible = false;
            // 
            // tbIA1
            // 
            this.tbIA1.Location = new System.Drawing.Point(82, 360);
            this.tbIA1.Name = "tbIA1";
            this.tbIA1.Size = new System.Drawing.Size(85, 20);
            this.tbIA1.TabIndex = 22;
            this.tbIA1.Visible = false;
            // 
            // numUpNbJouers
            // 
            this.numUpNbJouers.Location = new System.Drawing.Point(274, 278);
            this.numUpNbJouers.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUpNbJouers.Name = "numUpNbJouers";
            this.numUpNbJouers.Size = new System.Drawing.Size(100, 20);
            this.numUpNbJouers.TabIndex = 21;
            this.numUpNbJouers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpNbJouers.ValueChanged += new System.EventHandler(this.numUpNbJouers_ValueChanged);
            // 
            // tbPseudo
            // 
            this.tbPseudo.Location = new System.Drawing.Point(274, 242);
            this.tbPseudo.Name = "tbPseudo";
            this.tbPseudo.Size = new System.Drawing.Size(100, 20);
            this.tbPseudo.TabIndex = 20;
            // 
            // lbPseudoAdversaires
            // 
            this.lbPseudoAdversaires.AutoSize = true;
            this.lbPseudoAdversaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPseudoAdversaires.Location = new System.Drawing.Point(81, 322);
            this.lbPseudoAdversaires.Name = "lbPseudoAdversaires";
            this.lbPseudoAdversaires.Size = new System.Drawing.Size(182, 20);
            this.lbPseudoAdversaires.TabIndex = 19;
            this.lbPseudoAdversaires.Text = "Nom(s) d\'adversaire(s)";
            // 
            // lbNbJouers
            // 
            this.lbNbJouers.AutoSize = true;
            this.lbNbJouers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNbJouers.Location = new System.Drawing.Point(81, 279);
            this.lbNbJouers.Name = "lbNbJouers";
            this.lbNbJouers.Size = new System.Drawing.Size(151, 20);
            this.lbNbJouers.TabIndex = 18;
            this.lbNbJouers.Text = "Nombre de joueurs";
            // 
            // lbPseudo
            // 
            this.lbPseudo.AutoSize = true;
            this.lbPseudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPseudo.Location = new System.Drawing.Point(81, 242);
            this.lbPseudo.Name = "lbPseudo";
            this.lbPseudo.Size = new System.Drawing.Size(159, 20);
            this.lbPseudo.TabIndex = 17;
            this.lbPseudo.Text = "Entrez votre pseudo";
            // 
            // lbTitleParametres
            // 
            this.lbTitleParametres.AutoSize = true;
            this.lbTitleParametres.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleParametres.Location = new System.Drawing.Point(23, 175);
            this.lbTitleParametres.Name = "lbTitleParametres";
            this.lbTitleParametres.Size = new System.Drawing.Size(128, 30);
            this.lbTitleParametres.TabIndex = 16;
            this.lbTitleParametres.Text = "Paramètres";
            // 
            // logoGame
            // 
            this.logoGame.BackgroundImage = global::Coloretto1._2.Properties.Resources.coloretto;
            this.logoGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoGame.Location = new System.Drawing.Point(229, 12);
            this.logoGame.Name = "logoGame";
            this.logoGame.Size = new System.Drawing.Size(227, 152);
            this.logoGame.TabIndex = 15;
            this.logoGame.TabStop = false;
            // 
            // Parametres_nom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(675, 446);
            this.Controls.Add(this.btValider);
            this.Controls.Add(this.btRetour);
            this.Controls.Add(this.tbIA4);
            this.Controls.Add(this.tbIA3);
            this.Controls.Add(this.tbIA2);
            this.Controls.Add(this.tbIA1);
            this.Controls.Add(this.numUpNbJouers);
            this.Controls.Add(this.tbPseudo);
            this.Controls.Add(this.lbPseudoAdversaires);
            this.Controls.Add(this.lbNbJouers);
            this.Controls.Add(this.lbPseudo);
            this.Controls.Add(this.lbTitleParametres);
            this.Controls.Add(this.logoGame);
            this.Name = "Parametres_nom";
            this.Text = "Parametres_nom";
            this.Load += new System.EventHandler(this.Parametres_nom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUpNbJouers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btValider;
        private System.Windows.Forms.Button btRetour;
        private System.Windows.Forms.TextBox tbIA4;
        private System.Windows.Forms.TextBox tbIA3;
        private System.Windows.Forms.TextBox tbIA2;
        private System.Windows.Forms.TextBox tbIA1;
        private System.Windows.Forms.NumericUpDown numUpNbJouers;
        private System.Windows.Forms.TextBox tbPseudo;
        private System.Windows.Forms.Label lbPseudoAdversaires;
        private System.Windows.Forms.Label lbNbJouers;
        private System.Windows.Forms.Label lbPseudo;
        private System.Windows.Forms.Label lbTitleParametres;
        private System.Windows.Forms.PictureBox logoGame;
    }
}