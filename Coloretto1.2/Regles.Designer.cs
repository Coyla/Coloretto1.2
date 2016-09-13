namespace Coloretto1._2
{
    partial class Regles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Regles));
            this.btRetour = new System.Windows.Forms.Button();
            this.rchtBodyRegles = new System.Windows.Forms.RichTextBox();
            this.lbTitleRegles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btRetour
            // 
            this.btRetour.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btRetour.Location = new System.Drawing.Point(39, 400);
            this.btRetour.Name = "btRetour";
            this.btRetour.Size = new System.Drawing.Size(75, 23);
            this.btRetour.TabIndex = 6;
            this.btRetour.Text = "<  Retour";
            this.btRetour.UseVisualStyleBackColor = false;
            this.btRetour.Click += new System.EventHandler(this.btRetour_Click);
            // 
            // rchtBodyRegles
            // 
            this.rchtBodyRegles.Location = new System.Drawing.Point(39, 30);
            this.rchtBodyRegles.Name = "rchtBodyRegles";
            this.rchtBodyRegles.Size = new System.Drawing.Size(708, 348);
            this.rchtBodyRegles.TabIndex = 5;
            this.rchtBodyRegles.Text = resources.GetString("rchtBodyRegles.Text");
            // 
            // lbTitleRegles
            // 
            this.lbTitleRegles.AutoSize = true;
            this.lbTitleRegles.Font = new System.Drawing.Font("Comic Sans MS", 16.25F, System.Drawing.FontStyle.Bold);
            this.lbTitleRegles.Location = new System.Drawing.Point(33, -13);
            this.lbTitleRegles.Name = "lbTitleRegles";
            this.lbTitleRegles.Size = new System.Drawing.Size(81, 31);
            this.lbTitleRegles.TabIndex = 4;
            this.lbTitleRegles.Text = "Règles";
            // 
            // Regles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(779, 479);
            this.Controls.Add(this.btRetour);
            this.Controls.Add(this.rchtBodyRegles);
            this.Controls.Add(this.lbTitleRegles);
            this.Name = "Regles";
            this.Text = "Regles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRetour;
        private System.Windows.Forms.RichTextBox rchtBodyRegles;
        private System.Windows.Forms.Label lbTitleRegles;
    }
}