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
    public partial class Score_manche : Form
    {
        List<Joueur> listeDeJoueurs;
        Partie maPartie;
        Manche maManche;
        public Score_manche(List<Joueur> uneListe, Partie unePartie)
        {
            
            maPartie = unePartie;
            maManche = maPartie.GetManches().Last<Manche>();
            listeDeJoueurs = new List<Joueur>(maPartie.GetManches().Last<Manche>().GetJoueurs());
            InitializeComponent();
        }


        public void MettreAJourDataGrid()
        {
            foreach (Joueur j in listeDeJoueurs)
            {
                dgScore.Rows.Add(j.GetNom(), j.GetPointsPositifs(), j.GetPointsNegatifs(), j.nombreDeCartesJokerOuPlus("joker"),j.nombreDeCartesJokerOuPlus("plus"),j.GetScoreManche());
            }
        }

    
        private void Score_manche_Load(object sender, EventArgs e)
        {
            MettreAJourDataGrid();
           
        }


        private void lbContinuer_Click(object sender, EventArgs e)
        {
            Parametres_nom form = new Parametres_nom(maPartie);
            form.Show();
            this.Close();
        }

        private void lbFinGame_Click(object sender, EventArgs e)
        {

           
            Score_game form = new Score_game(listeDeJoueurs, maPartie);
            form.Show();
            this.Close();
        }
    }
}
