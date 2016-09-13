using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Coloretto1._2
{
    public partial class Parametre_Score : Form
    {
        List<Joueur> maliste;
        Partie maPartie;
        public Parametre_Score(List<Joueur> uneListe, Partie unePartie)
        {
            maPartie = unePartie;
            maliste = new List<Joueur>(uneListe);
            InitializeComponent();
        }

        private void cardScoreA_Click(object sender, EventArgs e)
        {
            //Type de score A
            //le True équivaut au type A
            //et le False équivaut au type B

            maliste.Last<Joueur>().ChangerTypeScore(true); 
            lbMessageConfirmation.Text = "Type de score A";

        }

        private void cardScoreB_Click(object sender, EventArgs e)
        {
            maliste.Last<Joueur>().ChangerTypeScore(false);
            lbMessageConfirmation.Text = "Type de score B";

        }

        private void btValider_Click(object sender, EventArgs e)
        {
            //On passe en paramètre la liste//
            //On oublie pas de mettre les classes en public si non
            //elles pourront pas etre utilisés par les autres classes
            Parametres_couleur form = new Parametres_couleur(maliste,maPartie);
           
            form.Show();
            this.Close();
        }

        private void Parametre_Score_Load(object sender, EventArgs e)
        {
            
        }

        private void btRetour_Click(object sender, EventArgs e)
        {
            Parametres_nom form = new Parametres_nom(maPartie);
            form.Show();
            this.Close();
        }
    }
}
