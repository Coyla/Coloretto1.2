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
    
    public partial class Parametres_nom : Form
    {
        private List<Joueur> lesJoueurs;

        private Partie maPartie;
        public Parametres_nom()
        {
            lesJoueurs = new List<Joueur>();
            maPartie = new Partie();
            InitializeComponent();
        }

        public Parametres_nom(Partie unePartie)
        {
            lesJoueurs = new List<Joueur>();
            maPartie = unePartie;
            InitializeComponent();
            
        }

        public void DesactiverTextBox()
        {
            foreach (Control t in this.Controls)
            {

                if (t is TextBox)
                {
                    t.Enabled = false;
                }
            }
        }
        

        private void btValider_Click(object sender, EventArgs e)
        {
            ///<summay>
            ///on récupere le text dans les textbox qui sont visibles
            ///puis on utilise ce texte pour créer un joueur le text est le nom du joueur
            ///le compteur sert à incrémenter l'id
            ///mais on peut changer comme pour les cartes 
            ///a faire plus tard. /!
            foreach (Control t in this.Controls)
            {
               
                if (t.Visible == true && t is TextBox)
                {



                    string nom_joueur = t.Text;
                    Joueur player = new Joueur(nom_joueur);
                    lesJoueurs.Add(player);
                }
               
            }
            this.Close();
    
            Parametre_Score fenetre = new Parametre_Score(lesJoueurs,maPartie);
            
            fenetre.Show();
           
        }

        private void numUpNbJouers_ValueChanged(object sender, EventArgs e)
        {
            if (numUpNbJouers.Value >= 1)
            {
                tbIA1.Visible = true;
            }
            else
                tbIA1.Visible = false;

            if (numUpNbJouers.Value >= 2)
            {
                tbIA2.Visible = true;
            }
            else
                tbIA2.Visible = false;

            if (numUpNbJouers.Value >= 3)
            {
                tbIA3.Visible = true;
            }
            else
                tbIA3.Visible = false;
            if (numUpNbJouers.Value >= 4)
            {
                tbIA4.Visible = true;
            }
            else
                tbIA4.Visible = false;
            
        }

        private void Parametres_nom_Load(object sender, EventArgs e)
        {
            if (maPartie.GetManches().Count > 0)
            {
                if (maPartie.GetManches()[0].GetJoueurs().Count == 2)
                {
                    numUpNbJouers.Value = 1;
                    tbIA1.Text = maPartie.GetManches()[0].GetJoueurs()[0].GetNom();
                    tbIA1.Text = maPartie.GetManches()[0].GetJoueurs()[0].GetNom();
                    tbIA1.Text = maPartie.GetManches()[0].GetJoueurs()[0].GetNom();
                    tbIA1.Text = maPartie.GetManches()[0].GetJoueurs()[0].GetNom();
                    tbIA1.Text = maPartie.GetManches()[0].GetJoueurs()[0].GetNom();
                    
                }
                else if (maPartie.GetManches()[0].GetJoueurs().Count == 3)
                {
                    numUpNbJouers.Value = 2;
                    tbIA1.Text = maPartie.GetManches()[0].GetJoueurs()[0].GetNom();
                    tbIA2.Text = maPartie.GetManches()[0].GetJoueurs()[1].GetNom();
                    tbPseudo.Text = maPartie.GetManches()[0].GetJoueurs()[2].GetNom();
                }
                else if (maPartie.GetManches()[0].GetJoueurs().Count == 4)
                {
                    numUpNbJouers.Value = 3;
                    tbIA1.Text = maPartie.GetManches()[0].GetJoueurs()[0].GetNom();
                    tbIA2.Text = maPartie.GetManches()[0].GetJoueurs()[1].GetNom();
                    tbIA3.Text = maPartie.GetManches()[0].GetJoueurs()[2].GetNom();
                    tbPseudo.Text = maPartie.GetManches()[0].GetJoueurs()[3].GetNom();
                }
                else if (maPartie.GetManches()[0].GetJoueurs().Count == 5)
                {
                    numUpNbJouers.Value = 4;
                    tbIA1.Text = maPartie.GetManches()[0].GetJoueurs()[0].GetNom();
                    tbIA2.Text = maPartie.GetManches()[0].GetJoueurs()[1].GetNom();
                    tbIA3.Text = maPartie.GetManches()[0].GetJoueurs()[2].GetNom();
                    tbIA4.Text = maPartie.GetManches()[0].GetJoueurs()[3].GetNom();
                    tbPseudo.Text = maPartie.GetManches()[0].GetJoueurs()[4].GetNom();

                    
                }
                DesactiverTextBox();
                numUpNbJouers.Enabled = false;
            }

        }

        private void btRetour_Click(object sender, EventArgs e)
        {
            
            Home form = new Home();
            form.Show();
            this.Close();
        }

      
    }
}
