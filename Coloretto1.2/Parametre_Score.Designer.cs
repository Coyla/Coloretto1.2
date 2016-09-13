namespace Coloretto1._2
{
    partial class Parametre_Score
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
            this.lbOu = new System.Windows.Forms.Label();
            this.cardScoreB = new System.Windows.Forms.PictureBox();
            this.cardScoreA = new System.Windows.Forms.PictureBox();
            this.lbExplications = new System.Windows.Forms.Label();
            this.lbTitleParametresScore = new System.Windows.Forms.Label();
            this.lbMessageConfirmation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cardScoreB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardScoreA)).BeginInit();
            this.SuspendLayout();
            // 
            // btValider
            // 
            this.btValider.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btValider.Location = new System.Drawing.Point(279, 411);
            this.btValider.Name = "btValider";
            this.btValider.Size = new System.Drawing.Size(75, 38);
            this.btValider.TabIndex = 14;
            this.btValider.Text = "Valider";
            this.btValider.UseVisualStyleBackColor = false;
            this.btValider.Click += new System.EventHandler(this.btValider_Click);
            // 
            // btRetour
            // 
            this.btRetour.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btRetour.Location = new System.Drawing.Point(12, 411);
            this.btRetour.Name = "btRetour";
            this.btRetour.Size = new System.Drawing.Size(75, 38);
            this.btRetour.TabIndex = 13;
            this.btRetour.Text = "Retour";
            this.btRetour.UseVisualStyleBackColor = false;
            this.btRetour.Click += new System.EventHandler(this.btRetour_Click);
            // 
            // lbOu
            // 
            this.lbOu.AutoSize = true;
            this.lbOu.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOu.Location = new System.Drawing.Point(298, 218);
            this.lbOu.Name = "lbOu";
            this.lbOu.Size = new System.Drawing.Size(41, 27);
            this.lbOu.TabIndex = 12;
            this.lbOu.Text = "OU";
            // 
            // cardScoreB
            // 
            this.cardScoreB.BackgroundImage = global::Coloretto1._2.Properties.Resources.ScoreB;
            this.cardScoreB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cardScoreB.Location = new System.Drawing.Point(355, 132);
            this.cardScoreB.Name = "cardScoreB";
            this.cardScoreB.Size = new System.Drawing.Size(156, 220);
            this.cardScoreB.TabIndex = 11;
            this.cardScoreB.TabStop = false;
            this.cardScoreB.Click += new System.EventHandler(this.cardScoreB_Click);
            // 
            // cardScoreA
            // 
            this.cardScoreA.BackgroundImage = global::Coloretto1._2.Properties.Resources.ScoreA;
            this.cardScoreA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cardScoreA.Location = new System.Drawing.Point(122, 132);
            this.cardScoreA.Name = "cardScoreA";
            this.cardScoreA.Size = new System.Drawing.Size(156, 220);
            this.cardScoreA.TabIndex = 10;
            this.cardScoreA.TabStop = false;
            this.cardScoreA.Click += new System.EventHandler(this.cardScoreA_Click);
            // 
            // lbExplications
            // 
            this.lbExplications.AutoSize = true;
            this.lbExplications.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExplications.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbExplications.Location = new System.Drawing.Point(24, 53);
            this.lbExplications.Name = "lbExplications";
            this.lbExplications.Size = new System.Drawing.Size(345, 76);
            this.lbExplications.TabIndex = 9;
            this.lbExplications.Text = "Instructions\r\nClick sur une image pour choisir le type de comptage\r\npour le score" +
                ". Pour plus d\'information click ici\r\n\r\n";
            // 
            // lbTitleParametresScore
            // 
            this.lbTitleParametresScore.AutoSize = true;
            this.lbTitleParametresScore.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleParametresScore.Location = new System.Drawing.Point(24, 9);
            this.lbTitleParametresScore.Name = "lbTitleParametresScore";
            this.lbTitleParametresScore.Size = new System.Drawing.Size(345, 30);
            this.lbTitleParametresScore.TabIndex = 8;
            this.lbTitleParametresScore.Text = "Choix pour le comptage de score";
            // 
            // lbMessageConfirmation
            // 
            this.lbMessageConfirmation.AutoSize = true;
            this.lbMessageConfirmation.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessageConfirmation.Location = new System.Drawing.Point(75, 376);
            this.lbMessageConfirmation.Name = "lbMessageConfirmation";
            this.lbMessageConfirmation.Size = new System.Drawing.Size(160, 21);
            this.lbMessageConfirmation.TabIndex = 15;
            this.lbMessageConfirmation.Text = "Votre type de Score";
            // 
            // Parametre_Score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(660, 458);
            this.Controls.Add(this.lbMessageConfirmation);
            this.Controls.Add(this.btValider);
            this.Controls.Add(this.btRetour);
            this.Controls.Add(this.lbOu);
            this.Controls.Add(this.cardScoreB);
            this.Controls.Add(this.cardScoreA);
            this.Controls.Add(this.lbExplications);
            this.Controls.Add(this.lbTitleParametresScore);
            this.Name = "Parametre_Score";
            this.Text = "Parametre_Score";
            this.Load += new System.EventHandler(this.Parametre_Score_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cardScoreB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardScoreA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btValider;
        private System.Windows.Forms.Button btRetour;
        private System.Windows.Forms.Label lbOu;
        private System.Windows.Forms.PictureBox cardScoreB;
        private System.Windows.Forms.PictureBox cardScoreA;
        private System.Windows.Forms.Label lbExplications;
        private System.Windows.Forms.Label lbTitleParametresScore;
        private System.Windows.Forms.Label lbMessageConfirmation;
    }
}