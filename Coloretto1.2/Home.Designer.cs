namespace Coloretto1._2
{
    partial class Home
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
            this.btRegles = new System.Windows.Forms.Button();
            this.btJouer = new System.Windows.Forms.Button();
            this.logoGame = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoGame)).BeginInit();
            this.SuspendLayout();
            // 
            // btRegles
            // 
            this.btRegles.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btRegles.Location = new System.Drawing.Point(285, 333);
            this.btRegles.Name = "btRegles";
            this.btRegles.Size = new System.Drawing.Size(97, 43);
            this.btRegles.TabIndex = 5;
            this.btRegles.Text = "Règles";
            this.btRegles.UseVisualStyleBackColor = false;
            this.btRegles.Click += new System.EventHandler(this.btRegles_Click);
            // 
            // btJouer
            // 
            this.btJouer.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btJouer.Location = new System.Drawing.Point(285, 269);
            this.btJouer.Name = "btJouer";
            this.btJouer.Size = new System.Drawing.Size(97, 43);
            this.btJouer.TabIndex = 4;
            this.btJouer.Text = "Jouer";
            this.btJouer.UseVisualStyleBackColor = false;
            this.btJouer.Click += new System.EventHandler(this.btJouer_Click);
            // 
            // logoGame
            // 
            this.logoGame.BackgroundImage = global::Coloretto1._2.Properties.Resources.coloretto;
            this.logoGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoGame.Location = new System.Drawing.Point(217, 12);
            this.logoGame.Name = "logoGame";
            this.logoGame.Size = new System.Drawing.Size(233, 230);
            this.logoGame.TabIndex = 3;
            this.logoGame.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(666, 408);
            this.Controls.Add(this.btRegles);
            this.Controls.Add(this.btJouer);
            this.Controls.Add(this.logoGame);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRegles;
        private System.Windows.Forms.Button btJouer;
        private System.Windows.Forms.PictureBox logoGame;
    }
}