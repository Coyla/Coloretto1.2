namespace Coloretto1._2
{
    partial class Score_game
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
            this.lbRejouer = new System.Windows.Forms.Button();
            this.lbAnnonceGagnant = new System.Windows.Forms.Label();
            this.lbGagnant = new System.Windows.Forms.Label();
            this.dgScore = new System.Windows.Forms.DataGridView();
            this.lbTitleScore = new System.Windows.Forms.Label();
            this.logoWin = new System.Windows.Forms.PictureBox();
            this.joueur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manche1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manche2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manche3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoWin)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRejouer
            // 
            this.lbRejouer.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lbRejouer.Location = new System.Drawing.Point(319, 383);
            this.lbRejouer.Name = "lbRejouer";
            this.lbRejouer.Size = new System.Drawing.Size(75, 46);
            this.lbRejouer.TabIndex = 20;
            this.lbRejouer.Text = "Rejouer";
            this.lbRejouer.UseVisualStyleBackColor = false;
            this.lbRejouer.Click += new System.EventHandler(this.lbRejouer_Click);
            // 
            // lbAnnonceGagnant
            // 
            this.lbAnnonceGagnant.AutoSize = true;
            this.lbAnnonceGagnant.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAnnonceGagnant.Location = new System.Drawing.Point(401, 251);
            this.lbAnnonceGagnant.Name = "lbAnnonceGagnant";
            this.lbAnnonceGagnant.Size = new System.Drawing.Size(26, 27);
            this.lbAnnonceGagnant.TabIndex = 18;
            this.lbAnnonceGagnant.Text = "X";
            // 
            // lbGagnant
            // 
            this.lbGagnant.AutoSize = true;
            this.lbGagnant.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGagnant.Location = new System.Drawing.Point(270, 251);
            this.lbGagnant.Name = "lbGagnant";
            this.lbGagnant.Size = new System.Drawing.Size(125, 27);
            this.lbGagnant.TabIndex = 17;
            this.lbGagnant.Text = "GAGNANT :";
            // 
            // dgScore
            // 
            this.dgScore.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgScore.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.joueur,
            this.manche1,
            this.manche2,
            this.manche3,
            this.Total});
            this.dgScore.Location = new System.Drawing.Point(129, 69);
            this.dgScore.Name = "dgScore";
            this.dgScore.Size = new System.Drawing.Size(449, 157);
            this.dgScore.TabIndex = 16;
            // 
            // lbTitleScore
            // 
            this.lbTitleScore.AutoSize = true;
            this.lbTitleScore.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleScore.Location = new System.Drawing.Point(22, 18);
            this.lbTitleScore.Name = "lbTitleScore";
            this.lbTitleScore.Size = new System.Drawing.Size(135, 30);
            this.lbTitleScore.TabIndex = 15;
            this.lbTitleScore.Text = "Score Total";
            // 
            // logoWin
            // 
            this.logoWin.BackgroundImage = global::Coloretto1._2.Properties.Resources.trophée_best_of_yoga_2014;
            this.logoWin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoWin.Location = new System.Drawing.Point(319, 297);
            this.logoWin.Name = "logoWin";
            this.logoWin.Size = new System.Drawing.Size(76, 68);
            this.logoWin.TabIndex = 21;
            this.logoWin.TabStop = false;
            // 
            // joueur
            // 
            this.joueur.HeaderText = "Joueur";
            this.joueur.Name = "joueur";
            // 
            // manche1
            // 
            this.manche1.HeaderText = "Manche n°1";
            this.manche1.Name = "manche1";
            this.manche1.Width = 70;
            // 
            // manche2
            // 
            this.manche2.HeaderText = "Manche n°2";
            this.manche2.Name = "manche2";
            this.manche2.Width = 70;
            // 
            // manche3
            // 
            this.manche3.HeaderText = "Manche n°3";
            this.manche3.Name = "manche3";
            this.manche3.Width = 70;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // Score_game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(713, 441);
            this.Controls.Add(this.logoWin);
            this.Controls.Add(this.lbRejouer);
            this.Controls.Add(this.lbAnnonceGagnant);
            this.Controls.Add(this.lbGagnant);
            this.Controls.Add(this.dgScore);
            this.Controls.Add(this.lbTitleScore);
            this.Name = "Score_game";
            this.Text = "Score_game";
            this.Load += new System.EventHandler(this.Score_game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoWin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoWin;
        private System.Windows.Forms.Button lbRejouer;
        private System.Windows.Forms.Label lbAnnonceGagnant;
        private System.Windows.Forms.Label lbGagnant;
        private System.Windows.Forms.DataGridView dgScore;
        private System.Windows.Forms.Label lbTitleScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn joueur;
        private System.Windows.Forms.DataGridViewTextBoxColumn manche1;
        private System.Windows.Forms.DataGridViewTextBoxColumn manche2;
        private System.Windows.Forms.DataGridViewTextBoxColumn manche3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}