namespace Coloretto1._2
{
    partial class Score_manche
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
            this.lbFinGame = new System.Windows.Forms.Button();
            this.joueur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgScore = new System.Windows.Forms.DataGridView();
            this.pointPlus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsMoin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nbJoker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsDeux = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbTitleScore = new System.Windows.Forms.Label();
            this.btAudio = new System.Windows.Forms.Button();
            this.lbContinuer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgScore)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFinGame
            // 
            this.lbFinGame.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lbFinGame.Location = new System.Drawing.Point(264, 383);
            this.lbFinGame.Name = "lbFinGame";
            this.lbFinGame.Size = new System.Drawing.Size(75, 46);
            this.lbFinGame.TabIndex = 14;
            this.lbFinGame.Text = "Fin du Jeu";
            this.lbFinGame.UseVisualStyleBackColor = false;
            this.lbFinGame.Click += new System.EventHandler(this.lbFinGame_Click);
            // 
            // joueur
            // 
            this.joueur.HeaderText = "Joueur";
            this.joueur.Name = "joueur";
            // 
            // dgScore
            // 
            this.dgScore.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.joueur,
            this.pointPlus,
            this.pointsMoin,
            this.nbJoker,
            this.pointsDeux,
            this.total});
            this.dgScore.GridColor = System.Drawing.Color.AliceBlue;
            this.dgScore.Location = new System.Drawing.Point(112, 100);
            this.dgScore.Name = "dgScore";
            this.dgScore.Size = new System.Drawing.Size(492, 169);
            this.dgScore.TabIndex = 11;
            // 
            // pointPlus
            // 
            this.pointPlus.HeaderText = "Points +";
            this.pointPlus.Name = "pointPlus";
            this.pointPlus.Width = 70;
            // 
            // pointsMoin
            // 
            this.pointsMoin.HeaderText = "Points -";
            this.pointsMoin.Name = "pointsMoin";
            this.pointsMoin.Width = 70;
            // 
            // nbJoker
            // 
            this.nbJoker.HeaderText = "Nombre Jokers";
            this.nbJoker.Name = "nbJoker";
            this.nbJoker.Width = 70;
            // 
            // pointsDeux
            // 
            this.pointsDeux.HeaderText = "Points +2";
            this.pointsDeux.Name = "pointsDeux";
            this.pointsDeux.Width = 70;
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.Width = 70;
            // 
            // lbTitleScore
            // 
            this.lbTitleScore.AutoSize = true;
            this.lbTitleScore.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleScore.Location = new System.Drawing.Point(64, 17);
            this.lbTitleScore.Name = "lbTitleScore";
            this.lbTitleScore.Size = new System.Drawing.Size(72, 30);
            this.lbTitleScore.TabIndex = 10;
            this.lbTitleScore.Text = "Score";
            // 
            // btAudio
            // 
            this.btAudio.Location = new System.Drawing.Point(592, 2);
            this.btAudio.Name = "btAudio";
            this.btAudio.Size = new System.Drawing.Size(75, 23);
            this.btAudio.TabIndex = 16;
            this.btAudio.Text = "Audio";
            this.btAudio.UseVisualStyleBackColor = true;
            // 
            // lbContinuer
            // 
            this.lbContinuer.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lbContinuer.Location = new System.Drawing.Point(377, 383);
            this.lbContinuer.Name = "lbContinuer";
            this.lbContinuer.Size = new System.Drawing.Size(75, 46);
            this.lbContinuer.TabIndex = 15;
            this.lbContinuer.Text = "Continuer";
            this.lbContinuer.UseVisualStyleBackColor = false;
            this.lbContinuer.Click += new System.EventHandler(this.lbContinuer_Click);
            // 
            // Score_manche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(730, 430);
            this.Controls.Add(this.lbFinGame);
            this.Controls.Add(this.dgScore);
            this.Controls.Add(this.lbTitleScore);
            this.Controls.Add(this.btAudio);
            this.Controls.Add(this.lbContinuer);
            this.Name = "Score_manche";
            this.Text = "Score_manche";
            this.Load += new System.EventHandler(this.Score_manche_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lbFinGame;
        private System.Windows.Forms.DataGridViewTextBoxColumn joueur;
        private System.Windows.Forms.DataGridView dgScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointPlus;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsMoin;
        private System.Windows.Forms.DataGridViewTextBoxColumn nbJoker;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsDeux;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.Label lbTitleScore;
        private System.Windows.Forms.Button btAudio;
        private System.Windows.Forms.Button lbContinuer;
    }
}