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
    public partial class Parametres_couleur : Form
    {
        
        //On définie un paramètre pour récuprer la liste de
        //joueurs de la fenetre precédente
        //on déclare d'abord le nom d'une liste "listeJoueurs"
        //pour pourvoir l'utiliser dans les évènements
        private List<Joueur> listeJoueurs;
    
        private Partie maPartie;
        

        
        public Parametres_couleur(List<Joueur> uneListe, Partie unePartie)
        {
            maPartie = unePartie;
            listeJoueurs = new List<Joueur>(uneListe);
            
            InitializeComponent();
           
        }
        //---- Fonctions du jeu
        private bool Verification()
        {   bool verif = false;
            if (lbAnnonceCouleurDepart.Text == "X")
            {
                verif = false;
                return verif;
            }
             else
                verif = true;
                return verif;
            
        }
       

        //---- Fin

        private void Parametres_couleur_Load(object sender, EventArgs e)
        {
           
           
        }

        private void btValider_Click(object sender, EventArgs e)
        {
            
            bool CouleurNonSelectionnee = Verification();
            if (CouleurNonSelectionnee == true)
            {
              
                this.Hide();
                Game form = new Game(listeJoueurs, maPartie);
                form.Show();
                
            }
            else
                MessageBox.Show("Veuillez selectionner une carte pour choisir une couleur");
        }

        //On définie la couleur de départ du joueur selon son choix de carte
        //on utilise le texte de la propriété Tag du picture
        private void cardOrange_Click(object sender, EventArgs e)
        {
            listeJoueurs.Last<Joueur>().CouleurDepart = "orange";
            lbAnnonceCouleurDepart.Text = cardOrange.Tag.ToString();

        }

        private void cardBleu_Click(object sender, EventArgs e)
        {
            listeJoueurs.Last<Joueur>().CouleurDepart = "bleu";
            lbAnnonceCouleurDepart.Text = cardBleu.Tag.ToString();
        }

        private void cardMarron_Click(object sender, EventArgs e)
        {
            listeJoueurs.Last<Joueur>().CouleurDepart = "marron";
            lbAnnonceCouleurDepart.Text = cardMarron.Tag.ToString();

        }

        private void cardJaune_Click(object sender, EventArgs e)
        {
            listeJoueurs.Last<Joueur>().CouleurDepart = "jaune";
            lbAnnonceCouleurDepart.Text = cardJaune.Tag.ToString();
        }

        private void cardViolet_Click(object sender, EventArgs e)
        {
            listeJoueurs.Last<Joueur>().CouleurDepart = "violet";
            lbAnnonceCouleurDepart.Text = cardViolet.Tag.ToString();
        }

        private void cardVert_Click(object sender, EventArgs e)
        {
            listeJoueurs.Last<Joueur>().CouleurDepart = "vert";
            lbAnnonceCouleurDepart.Text = cardVert.Tag.ToString();
        }

        private void cardRouge_Click(object sender, EventArgs e)
        {
            listeJoueurs.Last<Joueur>().CouleurDepart = "rouge";
            lbAnnonceCouleurDepart.Text = cardRouge.Tag.ToString();
        }

        private void btRetour_Click(object sender, EventArgs e)
        {
            Parametre_Score form = new Parametre_Score(listeJoueurs, maPartie);
            form.Show();
            this.Close();
        }
        //fin de définition couleur de départ//
    }
}
