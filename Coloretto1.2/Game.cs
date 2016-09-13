using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;


namespace Coloretto1._2
{
    public partial class Game : Form
    {
       
        int action = 0; //variable pour savoir si on pioche ou on prends c'est pour les picturebox des rangees
        Thread th;
        bool dernierRound;
        int tour;
        string choisieDeRangee;
        private List<string> couleurCarte = new List<string>();
         private List<Joueur> listeJoueurs;
         private List<Carte> tatDeCartes;
        private Partie maPartie;
        private TableDeJeu maTable;
        private Manche maManche;
        public Game(List<Joueur>uneListe,Partie unePartie)
        {
            
            maPartie = unePartie;
            maTable = new TableDeJeu();
            maManche = new Manche();
            maManche.Ajouter(listeJoueurs = new List<Joueur>(uneListe));
            maManche.AjouterTable(maTable);
            maPartie.AjouterManche(maManche);
            InitializeComponent();
        }



        /// <summary>
        /// METHODES de MISE EN PLACE DU JEU
        /// </summary>
     
        
        public List<Carte> Creation_TatDeCartes()
        {
            ///<summary>
            ///Creation de 87 Cartes si 5 joueurs
            ///Cretion de 84 Cartes si 4 joueurs etc.
            ///les test a été effectué
            ///on ajoute les carte dans la liste tatDeCartes et on les renvoies
            ///</summary>
            
            couleurCarte.Add("orange");
            couleurCarte.Add("bleu");
            couleurCarte.Add("marron");
            couleurCarte.Add("jaune");
            couleurCarte.Add("violet");
            couleurCarte.Add("vert");
            couleurCarte.Add("rouge");
            if (listeJoueurs.Count == 2)
            {
                List<string> listeCouleurJoueurs = new List<string>();
                foreach (Joueur j in listeJoueurs)
                {
                    listeCouleurJoueurs.Add(j.CouleurDepart);
                }
                Random rd = new Random();
                for (int c = 0; c < 2; c++)
                {
                    int alea = rd.Next(couleurCarte.Count);
                    while (listeCouleurJoueurs.Contains(couleurCarte[alea]) == true)
                    {
                        alea = rd.Next(couleurCarte.Count);
                    }
                    couleurCarte.Remove(couleurCarte[alea]);
                }
            }
            else if (listeJoueurs.Count == 3)
            {
                List<string> listeCouleurJoueurs = new List<string>();
                foreach (Joueur j in listeJoueurs)
                {
                    listeCouleurJoueurs.Add(j.CouleurDepart);
                }
                Random rd = new Random();
                int alea = rd.Next(couleurCarte.Count);
                while (listeCouleurJoueurs.Contains(couleurCarte[alea]) == true)
                {
                    alea = rd.Next(couleurCarte.Count);
                }
                couleurCarte.Remove(couleurCarte[alea]);
 
            }
            int i = 0;
            Image monimage = Properties.Resources.pioche;
            while (i < 9)
            {
                
                foreach (string e in couleurCarte)
                {
                   
                    switch(e)
                    {

                        case "orange":
                            monimage = Properties.Resources.orange;
                            break;
                        case "bleu":
                            monimage = Properties.Resources.bleu;
                            break;
                        case "marron":
                            monimage = Properties.Resources.marron;
                            break;
                        case "jaune":
                            monimage = Properties.Resources.jaune;
                            break;
                        case "violet":
                            monimage = Properties.Resources.violet;
                            break;
                        case "vert":
                            monimage = Properties.Resources.vert;
                            break;
                        case "rouge":
                            monimage = Properties.Resources.rouge;
                            break;
                    }
                    
                    Carte carteCouleur = new Carte(e,monimage);
                    tatDeCartes.Add(carteCouleur);

                }
                i++;   
            }

            for (i=0; i<3; i++)
            {
                
                Carte carteJoker = new Carte("joker", Properties.Resources.joker);
                tatDeCartes.Add(carteJoker);
            }

            
            for (i = 0; i < 10; i++)
            {
                Carte cartePlus = new Carte("plus", Properties.Resources.plus);
                tatDeCartes.Add(cartePlus);
            }
          

            Carte carteManche = new Carte("manche", Properties.Resources.manche);
            tatDeCartes.Add(carteManche);

            for (i = 0; i < listeJoueurs.Count; i++)
            {
                
                if (listeJoueurs[i].TypeScore == true)
                {
                    Carte carteAideA = new Carte("aideA", Properties.Resources.ScoreA);
                    tatDeCartes.Add(carteAideA);

                }
                else
                {
                    Carte carteAideB = new Carte("aideB", Properties.Resources.ScoreB);
                    tatDeCartes.Add(carteAideB);
                }  
                    
            }
          
            return tatDeCartes;
 
        }

        public void Attribution_couleurDeparts_IA(List<Joueur> uneListe)
        {
            ///<summary>
            ///On ajoute une liste de couleurs
            ///ensuite on enleve la couleur choisie par le joueur
            ///on créer une liste de nombre pour choisir dessus aléatoirement
            ///puis on suprrime l'entier choisie pour ne pas avoir de doublons
            ///et on utilise se chiffre pour prendre un élément dans la liste de couleurs
            ///puis on ajoute cette couleur à un joueur ordinateur
            ///Test effectué
            ///</summary>
            List<string> listeDeCouleurs =new List<string>();
            listeDeCouleurs.Add("orange");
            listeDeCouleurs.Add("bleu");
            listeDeCouleurs.Add("marron");
            listeDeCouleurs.Add("jaune");
            listeDeCouleurs.Add("violet");
            listeDeCouleurs.Add("vert");
            listeDeCouleurs.Add("rouge");

            listeDeCouleurs.Remove(listeJoueurs.Last<Joueur>().CouleurDepart);
            List<Int32> listeRandom = new List<int>();
            listeRandom.Add(0);
            listeRandom.Add(1);
            listeRandom.Add(2);
            listeRandom.Add(3);
            listeRandom.Add(4);
            listeRandom.Add(5);
            listeRandom.Add(6);

            for (int i = 0; i < listeJoueurs.Count-1; i++)
            {
                Random random = new Random();
                int r = random.Next(0,listeRandom.Count-1);
                int numeroRandom = listeRandom[r];
                listeJoueurs[i].CouleurDepart = listeDeCouleurs[numeroRandom];
                listeRandom.Remove(numeroRandom);
            }
        }

        public void Attribution_TypeDeScore(List<Joueur> uneListe)
        {
            /// <summary>
            /// attribution d'une type de score
            /// True = typeA 
            /// False = typeB
            /// on n'attribue pas de type score au dernier joueur qui est le Joueur qui a crée la partie
            /// puisqu'il a deja seléctioné sans type de score dans la fenetre precédente
            Random random = new Random();
            for (int i = 0; i < listeJoueurs.Count - 1; i++)
            {
               
                int r = random.Next(0,2);
                if (r == 0)
                {
                    listeJoueurs[i].ChangerTypeScore(true);
                }
                else if (r == 1)
                {
                    listeJoueurs[i].ChangerTypeScore(false);
                }
            }


        }
        public void Attribution_CarteDepart(List<Joueur> uneListe)
        {
            /// <summary>
            /// On attribue les cartes de Couleurs de depart
            /// </summary>
            for (int i = 0; i < listeJoueurs.Count; i++)
            {
                for (int c = 0; c < tatDeCartes.Count;)
                {
                    if (listeJoueurs[i].CouleurDepart == tatDeCartes[c].GetNom())
                    {
                        listeJoueurs[i].AjouterCartes(tatDeCartes[c]);
                        tatDeCartes.Remove(tatDeCartes[c]);
                        break;
                    }
                    else
                        c++;
                }
            }
        }

        public void Attribution_CarteAide(List<Joueur> uneListe)
        {
            ///<summary>    
            ///On donne les cartes aide qui se trouvent dans le tatdecartes 
            ///a chaque joueur puis on les enleve du tat
            ///test effectué après avoir utilisé la méthode on se retrouve avec moins de cartes
            ///</summary>
            for (int i = 0; i < listeJoueurs.Count; i++)
            {
                for (int c = 0; c < tatDeCartes.Count; )
                {
                    if (listeJoueurs[i].TypeScore == true && tatDeCartes[c].GetNom() == "aideA")
                    {
                        listeJoueurs[i].AjouterCarteAide(tatDeCartes[c]);
                        tatDeCartes.Remove(tatDeCartes[c]);
                       
                        break;
                    }
                    else if (listeJoueurs[i].TypeScore == false && tatDeCartes[c].GetNom() == "aideB")
                    {
                        listeJoueurs[i].AjouterCarteAide(tatDeCartes[c]);
                        tatDeCartes.Remove(tatDeCartes[c]);
                      
                        break;

                    }
                    else
                       
                        c++;
                }
            }
        }

        public void Attribution_CarteBeige(TableDeJeu uneTable)
        {
            ///<summary>
            ///On prend les cartes beiges qui se trouvent dans le tat 
            ///et on les places dans la table de jeu
            ///test effectué Ok
            ///</summary>
            List<string> lesRangee = new List<string>();
            lesRangee.Add("A");
            lesRangee.Add("B");
            lesRangee.Add("C");
            lesRangee.Add("D");
            lesRangee.Add("E");
            for (int i = 0; i < listeJoueurs.Count; i++)
            {
                for (int c = 0; c < tatDeCartes.Count; )
                {
                    if (tatDeCartes[c].GetNom() == "rangee")
                    {
                        uneTable.AjouterCarteDansRangee(tatDeCartes[c], lesRangee[i]);
                        tatDeCartes.Remove(tatDeCartes[c]);
                        break;
                    }
                    else
                        c++;
                }
            }
        }


        public List<Carte> MelangeDuTatDeCartes()
        {
            /// <summary>
            /// On enlève la carte "Manche" du tat de cartes on la met dans une listeC
            /// On mélange le tat de cartes restant avec la méthode suffle
            /// Ensuite on elève les 15 premiers cartes du tat et on les ajoute à la liste B
            /// puis on remet la carte "Manche" a la fin du tat de cartes, et on ajoute les cartes de la liste B
            /// a la fin également
            /// </summary>

            
            List<Carte> listeB = new List<Carte>();
            List<Carte> listeC = new List<Carte>();

            for (int c = 0; c < tatDeCartes.Count; )
            {
                if (tatDeCartes[c].GetNom() == "manche")
                {
                    listeC.Add(tatDeCartes[c]);
                    tatDeCartes.Remove(tatDeCartes[c]);
                    break;
                }
                else
                    c++;
            }
            tatDeCartes.Shuffle(); //melange des cartes avec la méthode Suffle de la classe MethodeExtension Statique
            ///<summary>
            ///on enlève 15 cartes dans le tat
            ///et on ajoute dans la liste B
            ///</summary>

            for (int i = 0; i < 15; i++ )
            {
                listeB.Add(tatDeCartes[i]);
                tatDeCartes.Remove(tatDeCartes[i]);
            }
            tatDeCartes.Add(listeC[0]);
            ///<summary>
            ///on ajoute toutes les cartes de la listeB 
            ///dans le tatdeCartes
            foreach (Carte c in listeB)
            {
                tatDeCartes.Add(c);
            }
            return tatDeCartes;
        }

        /// <summary>
        /// FIN METHODES DE MISE EN PLACE
        /// </summary>
      

        /// <summary>
        /// DEBUT METHODES D'AFFICHAGE D'IMAGES
        /// </summary> 

        public void ChargementImagesCarteAides()
        {
            ///<summary>
            ///affichage des cartes de Score ou Aide
            ///de chaque joueur 
            if (listeJoueurs.Count == 1)
            {
                this.pbJ1score.BackgroundImage = listeJoueurs[1].GetListeAide()[0].GetImageCarte();

            }
            else if (listeJoueurs.Count == 2)
            {
                this.pbIA1score.BackgroundImage = listeJoueurs[0].GetListeAide()[0].GetImageCarte();
                this.pbJ1score.BackgroundImage = listeJoueurs[1].GetListeAide()[0].GetImageCarte();
            }
            else if (listeJoueurs.Count == 3)
            {
                this.pbIA1score.BackgroundImage = listeJoueurs[0].GetListeAide()[0].GetImageCarte();
                this.pbIA2score.BackgroundImage = listeJoueurs[1].GetListeAide()[0].GetImageCarte();
                this.pbJ1score.BackgroundImage = listeJoueurs[2].GetListeAide()[0].GetImageCarte();
            }
            else if (listeJoueurs.Count == 4)
            {
                this.pbIA1score.BackgroundImage = listeJoueurs[0].GetListeAide()[0].GetImageCarte();
                this.pbIA2score.BackgroundImage = listeJoueurs[1].GetListeAide()[0].GetImageCarte();
                this.pbIA3score.BackgroundImage = listeJoueurs[2].GetListeAide()[0].GetImageCarte();
                this.pbJ1score.BackgroundImage = listeJoueurs[3].GetListeAide()[0].GetImageCarte();
            }
            else
            {


                this.pbIA1score.BackgroundImage = listeJoueurs[0].GetListeAide()[0].GetImageCarte();
                this.pbIA2score.BackgroundImage = listeJoueurs[1].GetListeAide()[0].GetImageCarte();
                this.pbIA3score.BackgroundImage = listeJoueurs[2].GetListeAide()[0].GetImageCarte();
                this.pbIA4score.BackgroundImage = listeJoueurs[3].GetListeAide()[0].GetImageCarte();
                this.pbJ1score.BackgroundImage = listeJoueurs[4].GetListeAide()[0].GetImageCarte();
            }
        }
      
      
        public void AffichageDesGroupeBoxIA()
        {
            ///<summary>
            ///affichage des groupe box selon le nombre de joueur
            ///On desactive les groupbox et les picturebox des cartes beiges ou verte
            ///</summary>
            int nbJoueurs = listeJoueurs.Count();
            switch (nbJoueurs)
            {
                    //le cas deux est pour le 1 vs 1
                case 2:
                    gbIA2.Visible = false;
                    gbIA3.Visible = false;
                    gbIA4.Visible = false;
                    pbRang5Beige.Visible = false;
                    pbRang5Card1.Visible = false;
                    pbRang5Card2.Visible = false;
                    pbRang5Card3.Visible = false;
                    pbRang4Beige.Visible = false;
                    pbRang4Card1.Visible = false;
                    pbRang4Card2.Visible = false;
                    pbRang4Card3.Visible = false;
                    pbRang1Card2.Visible = false;
                    pbRang1Card3.Visible = false;
                    pbRang2Card3.Visible = false;
                   
                  

                    break;
                case 3:
                    gbIA3.Visible = false;
                    gbIA4.Visible = false;
                    pbRang5Beige.Visible = false;
                    pbRang5Card1.Visible = false;
                    pbRang5Card2.Visible = false;
                    pbRang5Card3.Visible = false;
                    pbRang4Beige.Visible = false;
                    pbRang4Card1.Visible = false;
                    pbRang4Card2.Visible = false;
                    pbRang4Card3.Visible = false;
                    break;
                case 4:
                    gbIA4.Visible = false;
                    pbRang5Beige.Visible = false;
                    pbRang5Card1.Visible = false;
                    pbRang5Card2.Visible = false;
                    pbRang5Card3.Visible = false;
                    break;

            }
        }
        
        

        /// <summary>
        /// FIN METHODES D'AFFICHAGE
        /// </summary>

        /// <summary>
        /// DEBUT METHOS DE CHARGEMENT D'INFORMATION 
        /// Reset des donnes pour les nouvelles manches
        /// </summary>

        public void ResetDonnesCartes()
        {
            foreach (Joueur j in maPartie.GetManches().Last<Manche>().GetJoueurs())
            {
                j.GetLesCartes().Clear();
                j.GetListeJoker().Clear();
                j.GetListePlus().Clear();
                j.GetListeAide().Clear();
                j.ChangerScoreManche(0);
            }
        }
        public void MettreAJourDonneesPlayer1()
        {
            lbIA1orange.Text = listeJoueurs[0].nombreDeCartesCouleur("orange");
            lbIA1bleu.Text = listeJoueurs[0].nombreDeCartesCouleur("bleu");
            lbIA1marron.Text = listeJoueurs[0].nombreDeCartesCouleur("marron");
            lbIA1jaune.Text = listeJoueurs[0].nombreDeCartesCouleur("jaune");
            lbIA1joker.Text = listeJoueurs[0].nombreDeCartesJokerOuPlus("joker");
            lbIA1vert.Text = listeJoueurs[0].nombreDeCartesCouleur("vert");
            lbIA1violet.Text = listeJoueurs[0].nombreDeCartesCouleur("violet");
            lbIA1rouge.Text = listeJoueurs[0].nombreDeCartesCouleur("rouge");
            lbIA1info.Text = listeJoueurs[0].GetNom();
        }

        public void MettreAJourDonneesPlayer2()
        {
            if (listeJoueurs.Count > 2)
            {
                lbIA2orange.Text = listeJoueurs[1].nombreDeCartesCouleur("orange");
                lbIA2bleu.Text = listeJoueurs[1].nombreDeCartesCouleur("bleu");
                lbIA2marron.Text = listeJoueurs[1].nombreDeCartesCouleur("marron");
                lbIA2jaune.Text = listeJoueurs[1].nombreDeCartesCouleur("jaune");
                lbIA2joker.Text = listeJoueurs[1].nombreDeCartesJokerOuPlus("joker");
                lbIA2vert.Text = listeJoueurs[1].nombreDeCartesCouleur("vert");
                lbIA2violet.Text = listeJoueurs[1].nombreDeCartesCouleur("violet");
                lbIA2rouge.Text = listeJoueurs[1].nombreDeCartesCouleur("rouge");
                lbIA2info.Text = listeJoueurs[1].GetNom();
            }
        }

        public void MettreAJourDonneesPlayer3()
        {
            if (listeJoueurs.Count > 3)
            {
                lbIA3orange.Text = listeJoueurs[2].nombreDeCartesCouleur("orange");
                lbIA3bleu.Text = listeJoueurs[2].nombreDeCartesCouleur("bleu");
                lbIA3marron.Text = listeJoueurs[2].nombreDeCartesCouleur("marron");
                lbIA3jaune.Text = listeJoueurs[2].nombreDeCartesCouleur("jaune");
                lbIA3joker.Text = listeJoueurs[2].nombreDeCartesJokerOuPlus("joker");
                lbIA3vert.Text = listeJoueurs[2].nombreDeCartesCouleur("vert");
                lbIA3violet.Text = listeJoueurs[2].nombreDeCartesCouleur("violet");
                lbIA3rouge.Text = listeJoueurs[2].nombreDeCartesCouleur("rouge");
                lbIA3info.Text = listeJoueurs[2].GetNom();
            }
        }

        public void MettreAJourDonneesPlayer4()
        {

           if (listeJoueurs.Count == 5)
            {
                lbIA4orange.Text = listeJoueurs[3].nombreDeCartesCouleur("orange");
                lbIA4bleu.Text = listeJoueurs[3].nombreDeCartesCouleur("bleu");
                lbIA4marron.Text = listeJoueurs[3].nombreDeCartesCouleur("marron");
                lbIA4jaune.Text = listeJoueurs[3].nombreDeCartesCouleur("jaune");
                lbIA4joker.Text = listeJoueurs[3].nombreDeCartesJokerOuPlus("joker");
                lbIA4vert.Text = listeJoueurs[3].nombreDeCartesCouleur("vert");
                lbIA4violet.Text = listeJoueurs[3].nombreDeCartesCouleur("violet");
                lbIA4rouge.Text = listeJoueurs[3].nombreDeCartesCouleur("rouge");
                lbIA4info.Text = listeJoueurs[3].GetNom();
            }
        }

        public void MettreAJourDonneesPlayer5()
        {
            if (listeJoueurs.Count == 5)
            {
                lbJ1orange.Text = listeJoueurs[4].nombreDeCartesCouleur("orange");
                lbJ1bleu.Text = listeJoueurs[4].nombreDeCartesCouleur("bleu");
                lbJ1marron.Text = listeJoueurs[4].nombreDeCartesCouleur("marron");
                lbJ1jaune.Text = listeJoueurs[4].nombreDeCartesCouleur("jaune");
                lbJ1joker.Text = listeJoueurs[4].nombreDeCartesJokerOuPlus("joker");
                lbJ1vert.Text = listeJoueurs[4].nombreDeCartesCouleur("vert");
                lbJ1violet.Text = listeJoueurs[4].nombreDeCartesCouleur("violet");
                lbJ1rouge.Text = listeJoueurs[4].nombreDeCartesCouleur("rouge");
                lbJ1plus.Text = listeJoueurs[4].nombreDeCartesJokerOuPlus("plus");
                lbJ1Info.Text = listeJoueurs[4].GetNom();
            }
            else if (listeJoueurs.Count == 2)
            {
                lbJ1orange.Text = listeJoueurs[1].nombreDeCartesCouleur("orange");
                lbJ1bleu.Text = listeJoueurs[1].nombreDeCartesCouleur("bleu");
                lbJ1marron.Text = listeJoueurs[1].nombreDeCartesCouleur("marron");
                lbJ1jaune.Text = listeJoueurs[1].nombreDeCartesCouleur("jaune");
                lbJ1joker.Text = listeJoueurs[1].nombreDeCartesJokerOuPlus("joker");
                lbJ1vert.Text = listeJoueurs[1].nombreDeCartesCouleur("vert");
                lbJ1violet.Text = listeJoueurs[1].nombreDeCartesCouleur("violet");
                lbJ1rouge.Text = listeJoueurs[1].nombreDeCartesCouleur("rouge");
                lbJ1plus.Text = listeJoueurs[1].nombreDeCartesJokerOuPlus("plus");
                lbJ1Info.Text = listeJoueurs[1].GetNom();
            }
            else if (listeJoueurs.Count == 3)
            {
                lbJ1orange.Text = listeJoueurs[2].nombreDeCartesCouleur("orange");
                lbJ1bleu.Text = listeJoueurs[2].nombreDeCartesCouleur("bleu");
                lbJ1marron.Text = listeJoueurs[2].nombreDeCartesCouleur("marron");
                lbJ1jaune.Text = listeJoueurs[2].nombreDeCartesCouleur("jaune");
                lbJ1joker.Text = listeJoueurs[2].nombreDeCartesJokerOuPlus("joker");
                lbJ1vert.Text = listeJoueurs[2].nombreDeCartesCouleur("vert");
                lbJ1violet.Text = listeJoueurs[2].nombreDeCartesCouleur("violet");
                lbJ1rouge.Text = listeJoueurs[2].nombreDeCartesCouleur("rouge");
                lbJ1plus.Text = listeJoueurs[2].nombreDeCartesJokerOuPlus("plus");
                lbJ1Info.Text = listeJoueurs[2].GetNom();
            }

            else if (listeJoueurs.Count == 4)
            {
                lbJ1orange.Text = listeJoueurs[3].nombreDeCartesCouleur("orange");
                lbJ1bleu.Text = listeJoueurs[3].nombreDeCartesCouleur("bleu");
                lbJ1marron.Text = listeJoueurs[3].nombreDeCartesCouleur("marron");
                lbJ1jaune.Text = listeJoueurs[3].nombreDeCartesCouleur("jaune");
                lbJ1joker.Text = listeJoueurs[3].nombreDeCartesJokerOuPlus("joker");
                lbJ1vert.Text = listeJoueurs[3].nombreDeCartesCouleur("vert");
                lbJ1violet.Text = listeJoueurs[3].nombreDeCartesCouleur("violet");
                lbJ1rouge.Text = listeJoueurs[3].nombreDeCartesCouleur("rouge");
                lbJ1Info.Text = listeJoueurs[3].GetNom();
            }
            else if (listeJoueurs.Count == 2)
            {
                lbJ1orange.Text = listeJoueurs[1].nombreDeCartesCouleur("orange");
                lbJ1bleu.Text = listeJoueurs[1].nombreDeCartesCouleur("bleu");
                lbJ1marron.Text = listeJoueurs[1].nombreDeCartesCouleur("marron");
                lbJ1jaune.Text = listeJoueurs[1].nombreDeCartesCouleur("jaune");
                lbJ1joker.Text = listeJoueurs[1].nombreDeCartesJokerOuPlus("joker");
                lbJ1vert.Text = listeJoueurs[1].nombreDeCartesCouleur("vert");
                lbJ1violet.Text = listeJoueurs[1].nombreDeCartesCouleur("violet");
                lbJ1rouge.Text = listeJoueurs[1].nombreDeCartesCouleur("rouge");
                lbJ1Info.Text = listeJoueurs[1].GetNom();
            }
            
        }

        public void MiseAjourToutLesJoueurs()
        {
            if(listeJoueurs.Count == 2)
            {
                MettreAJourDonneesPlayer1();
                MettreAJourDonneesPlayer5();
            }

            else if (listeJoueurs.Count == 3)
            {
                MettreAJourDonneesPlayer1();
                MettreAJourDonneesPlayer2();
                MettreAJourDonneesPlayer5();
                
            }
            else if (listeJoueurs.Count == 4)
            {
                MettreAJourDonneesPlayer1();
                MettreAJourDonneesPlayer2();
                MettreAJourDonneesPlayer3();
                MettreAJourDonneesPlayer5();
            }
            else if (listeJoueurs.Count == 5)
            {
                MettreAJourDonneesPlayer1();
                MettreAJourDonneesPlayer2();
                MettreAJourDonneesPlayer3();
                MettreAJourDonneesPlayer4();
                MettreAJourDonneesPlayer5();
            }
           
        }

        public delegate void MiseAJour();

        public void MiseAJourJoueursThread()
        {
            Invoke(new MiseAJour(MiseAjourToutLesJoueurs));

        }
        public void AffichageNoManche()
        {
            lbAnnonceNoManche.Text = maPartie.GetManches().Last<Manche>().GetId().ToString();
 
        }
        public void AffichageNoPartie()
        {
            lbAnnonceNoPartie.Text = maPartie.GetId().ToString();
        }
        /// <summary>
        /// FIN METHODES DE CHARGEMENT D'INFORMATION
        /// </summary>
        

        ///<summary>
        ///DEBUT METHODES D'ACTIONS de JEU
        ///</summary>

        public void Cycle_ActionsDeJoueursBis(int nombreJoueurs, List<Joueur> uneListe)
        {
            ///<summary>
            ///Cycle des actions pour les joueurs
            ///il y a plusieurs condictions selon le nombre de joueurs dans la partie
            ///par exemple si il y a 3 joueurs le dernier joueur donc le 3eme (MOI). Aura le groupebox 5
            ///avec tout les labels et controls dedans
            ///Parcontre s'il y a 5 joueurs le joueurs 3 n'aura plus le groupbox5 attribué mais le groupebox 3
            ///et le 5eme joueur (MOI) aura le groupebox 5
            ///enfaite le joueur qui crée la partie(moi) a obligatoirement le groupebox5
            ///
            /// Ensuite on vérifie si le joueur a le droite de jouer 
            /// pour sela il faut que sa propriété droitTour soit égale a true
            /// s'il ne peut pas jouer alors on saute a la personne suivante
            /// on fait cela car dans la partie à un moment le joueur devra prendre une rangee donc
            /// il ne pourra plus jouer durant le cycle de roud
            /// 
            /// RAPPEL :
            /// Une manche a plusieurs Round: Le round se termine quand tout les personnes on
            /// pris une rangee
            ///</summary>
            desactiverControlsThread();
       
            switch (nombreJoueurs)
            {
                case 2:
  
                    switch (tour)
                    {
                        case 1:
                            if (uneListe[0].GetDroitTour() == true)
                            {
                                ChoixDesBot(listeJoueurs[0]);
                                tour = tour + 1;
                             
                            }
                            else
                                tour = tour + 1;
                            break;
                        case 2:
                            //si c'est le tour du J1 (le joueur main)
                            //alors les boutons "Piocher" et "Prendre Range" son activés
                            //si on appuye sur le bouton piocher la varaible action prend la valeur 1 ce qui va desactiver le bouton prendre
                            //de meme pour le bouton prendre avec la valeur 2
                            //si le tour du joueur est False (else) il met tour = 1 pour que la boucle se répéte et vérifier si c'est au joueur 1 de jouer ainsi de suite
                            if (uneListe[1].GetDroitTour() == true)
                            {
                                activerBoutonsThread();
                                while (tour == 2)
                                {
                                    if (action == 1)
                                    {
                                        desactiverBoutonPrendreThread();
                                    }
                                    else if (action == 2)
                                        desactiverBoutonPiocheThread();

                                }

                            }
                            else
                            {
                                    tour = 1;
                            }
                            break;
                    }
                    break;

                case 3:
                    
                    switch (tour)
                    {
                        case 1:
                            if (uneListe[0].GetDroitTour() == true)
                            {
                                ChoixDesBot(listeJoueurs[0]);
                                tour = tour + 1;
                             
                            }
                            else
                                tour = tour + 1;
                            break;
                        case 2:
                           if (uneListe[1].GetDroitTour() == true)
                            {
                                ChoixDesBot(listeJoueurs[1]);
                                tour = tour + 1;
                             
                            }
                            else
                                tour = tour + 1;
                            break;
                        case 3:
                            if (uneListe[2].GetDroitTour() == true)
                            {
                                activerBoutonsThread();
                                while (tour == 3)
                                {
                                    if (action == 1)
                                    {
                                        desactiverBoutonPrendreThread();
                                    }
                                    else if (action == 2)
                                        desactiverBoutonPiocheThread();

                                }

                            }
                            else

                            {
                              
                                    tour = 1;
                            }
                            break;
                    }
                    break;
                case 4:
                  
                    switch (tour)
                    {
                        case 1:
                            if (uneListe[0].GetDroitTour() == true)
                            {
                                ChoixDesBot(listeJoueurs[0]);
                                tour = tour + 1;
                             
                            }
                            else
                                tour = tour + 1;
                            break;
                        case 2:
                           if (uneListe[1].GetDroitTour() == true)
                            {
                                ChoixDesBot(listeJoueurs[1]);
                                tour = tour + 1;
                             
                            }
                            else
                                tour = tour + 1;
                            break;
                        case 3:
                            if (uneListe[2].GetDroitTour() == true)
                            {
                                ChoixDesBot(listeJoueurs[2]);
                                tour = tour + 1;
                             
                            }
                            else
                                tour = tour + 1;
                            break;
                        case 4:
                            if (uneListe[3].GetDroitTour() == true)
                            {
                                activerBoutonsThread();
                                while (tour == 4)
                                {
                                    if (action == 1)
                                    {
                                        desactiverBoutonPrendreThread();
                                    }
                                    else if (action == 2)
                                        desactiverBoutonPiocheThread();

                                }

                            }
                            else
                            {
                                    tour = 1;
                            }
                            break;
                            
                    }
                    break;
                case 5:
                    
                    switch (tour)
                    {
                        case 1:
                           
                            if (uneListe[0].GetDroitTour() == true)
                            {
                                ChoixDesBot(listeJoueurs[0]);
                                tour = tour + 1;
                             
                            }
                            else
                                tour = tour + 1;
                            break;
                        case 2:
                            if (uneListe[1].GetDroitTour() == true)
                            {
                                ChoixDesBot(listeJoueurs[1]);
                                tour = tour + 1;
                             
                                
                            }
                            else
                                tour = tour + 1;
                            break;
                        case 3:
                            if (uneListe[2].GetDroitTour() == true)
                            {
                                ChoixDesBot(listeJoueurs[2]);
                                tour = tour + 1;
                              
                            }
                            else
                                tour = tour + 1;
                            break;
                        case 4:
                            if (uneListe[3].GetDroitTour() == true)
                            {
                                ChoixDesBot(listeJoueurs[3]);

                                tour = tour + 1;

                            }
                            else
                           
                                tour = tour + 1;
                            break;
                        case 5:
                            if (uneListe[4].GetDroitTour() == true)
                            {
                                activerBoutonsThread();
                                while (tour == 5)
                                {
                                    if (action == 1)
                                    {
                                        desactiverBoutonPrendreThread();
                                    }
                                    else if(action == 2)
                                        desactiverBoutonPiocheThread();
                                }
                              
                            }
                            else
                            {
                             
                               tour = 1;
                                 
                                
                            }
                            break;
                    }
                    break;
            }
        }
     

        public void RemettreDroitsDesJoueurs()
        {
            foreach (Joueur j in listeJoueurs)
            {
                j.ChangerDroitTour(true);
            }
        }
        public bool VerificationDernierRound()
        {
            bool verif = false;
            {
                if (maManche.GetTable().GetPioche()[0].GetNom() == "manche")
                {
                    verif = true;
                }
                else
                    verif = false;
            }
            return verif;
        }
        public bool VerificationJoueursOff()
        {   ///<summary>
            /// Verification pour savoir si tout les joueurs ont pris une rangee
            /// on renvoie false si c'est pas le cas et vrai s'il sont tous OFF
            /// </summary>
            bool ToutLesJoueurOnJouee;
            
                if (listeJoueurs.All(j => j.GetDroitTour() == false))
                {
                    ToutLesJoueurOnJouee = true;
                }
                else
                    ToutLesJoueurOnJouee = false;
            
            return ToutLesJoueurOnJouee;
 
         }


        public void Cycle_Round()
        {
            ///<summary>
            ///on cree un cycle de round pour sortir du cycle il faut que tout les
            ///joueurs soit OFF donc qui on pris une rangee
            ///a chaque cycle d'actions on verifie si la carte "derniermanche" à été tiré
            ///si c'est le cas alors on renvoie la valeur true
            ///cela va nous servir pour le cycle_manche
            ///pour savoir si on arrete la manche ou pas.
            ///RAPPEL : On arrete une manche quand on trouve la carte dernier manche
            ///<summary>

            bool ToutlesJoueursOff = VerificationJoueursOff();
            
            while (ToutlesJoueursOff == false)
            {
               Cycle_ActionsDeJoueursBis(listeJoueurs.Count,listeJoueurs);
         
               ToutlesJoueursOff = VerificationJoueursOff();
               
            }
         
          

        }

        public void Cycle_Manche()
            
        {   ///<summary>
            ///Tant qu'on trouve pas la carte "manche" on continue le cycle de round
            ///</summary>
            while (dernierRound == false)
            {
                RemettreDroitsDesJoueurs();
                Cycle_Round();
                if (listeJoueurs.Count == 2)
                {
                        List<string> rangeelibre = RangeesDisponiblePourPrendre(listeJoueurs.Count);
                        DesactiverRangeeThread(rangeelibre[0]);
                        maTable.GetListeRange(rangeelibre[0]).Clear();
                        MettreAJourRangee(rangeelibre[0]);
                        ActiverToutesRangeesThreadMode1vs1();

                }
                else
                {
                    ActiverToutesRangeesThread();
                }
            }
            ActiverBoutonScoreThread();
            MessageBox.Show("Veuillez appuyer sur le bouton Score pour choisir les 3 couleurs Positives");
            th.Abort();

            
        }
        ///<summary>
        ///FIN METHODES D'ACTIONS de JEU
        ///</summary>
        ///

        ///<summary>
        ///DEBUT FONCTIONS ACTIONS DES JOUEURS
        ///</summary>
        public delegate void activerBouton();
        public delegate void desactiverControl();
        public delegate void activerRange();
        public delegate void desactiverRange();



        public void DesactiverA()
        {
            pbRang1Beige.Enabled = false;
        }
        public void DesactiverB()
        {
            pbRang2Beige.Enabled = false;
        }
        public void DesactiverC()
        {
            pbRang3Beige.Enabled = false;
        }
        public void DesactiverD()
        {
            pbRang4Beige.Enabled = false;
        }
        public void DesactiverE()
        {
            pbRang5Beige.Enabled = false;
        }
        public void ActiverBoutonScore()
        {
            btCalculScore.Visible = true;
        }

        public void ActiverBoutonScoreThread()
        {
            btCalculScore.Invoke(new activerBouton(ActiverBoutonScore));
        }
        public void DesactiverRangeeThread(string uneRangee)
        {
            switch (uneRangee)
            {
                case "A":
                    pbRang1Beige.Invoke(new desactiverRange(DesactiverA));
                    pbRang1Beige.BackgroundImage = null;
                    break;
                case "B":
                    pbRang2Beige.Invoke(new desactiverRange(DesactiverB));
                    pbRang2Beige.BackgroundImage = null;
                    break;
                case "C":
                    pbRang3Beige.Invoke(new desactiverRange(DesactiverC));
                    pbRang3Beige.BackgroundImage = null;
                    break;
                case "D":
                    pbRang4Beige.Invoke(new desactiverRange(DesactiverD));
                    pbRang4Beige.BackgroundImage = null;
                    break;
                case "E":
                    pbRang5Beige.Invoke(new desactiverRange(DesactiverE));
                    pbRang5Beige.BackgroundImage = null;
                    break;
            }
        
        }
        public void ActiverA()
        {
            pbRang1Beige.Enabled = true;
        }
        public void ActiverB()
        {
            pbRang2Beige.Enabled = true;
        }
        public void ActiverC()
        {
            pbRang3Beige.Enabled = true;
        }
        public void ActiverD()
        {
            pbRang4Beige.Enabled = true;
        }
        public void ActiverE()
        {
            pbRang5Beige.Enabled = true;
        }

        public void ActiverRangeeThread(string uneRangee)
        {
            switch (uneRangee)
            {
                case "A":
                    pbRang1Beige.Invoke(new desactiverRange(ActiverA));
                    pbRang1Beige.BackgroundImage = Properties.Resources.beige;
                    break;
                case "B":
                    pbRang2Beige.Invoke(new desactiverRange(ActiverB));
                    pbRang2Beige.BackgroundImage = Properties.Resources.beige;
                    break;
                case "C":
                    pbRang3Beige.Invoke(new desactiverRange(ActiverC));
                    pbRang3Beige.BackgroundImage = Properties.Resources.beige;
                    break;
                case "D":
                    pbRang4Beige.Invoke(new desactiverRange(ActiverD));
                    pbRang4Beige.BackgroundImage = Properties.Resources.beige;
                    break;
                case "E":
                    pbRang5Beige.Invoke(new desactiverRange(ActiverE));
                    pbRang5Beige.BackgroundImage = Properties.Resources.beige;
                    break;
            }

        }

        public void ActiverRangeeThreadMode1VS1(string uneRangee)
        {
            switch (uneRangee)
            {
                case "A":
                    pbRang1Beige.Invoke(new desactiverRange(ActiverA));
                    pbRang1Beige.BackgroundImage = Properties.Resources.verteA;
                    break;
                case "B":
                    pbRang2Beige.Invoke(new desactiverRange(ActiverB));
                    pbRang2Beige.BackgroundImage = Properties.Resources.verteB;
                    break;
                case "C":
                    pbRang3Beige.Invoke(new desactiverRange(ActiverC));
                    pbRang3Beige.BackgroundImage = Properties.Resources.verteC;
                    break;
                
            }
        }

        public void ActiverToutesRangeesThread()
        {
            ActiverRangeeThread("A");
            ActiverRangeeThread("B");
            ActiverRangeeThread("C");
            ActiverRangeeThread("D");
            ActiverRangeeThread("E");
        }

        public void ActiverToutesRangeesThreadMode1vs1()
        {
            ActiverRangeeThreadMode1VS1("A");
            ActiverRangeeThreadMode1VS1("B");
            ActiverRangeeThreadMode1VS1("C");
            
        }
    


        public void activerRangee(string rangee)
        {
            switch (rangee)
            {
                case "A":
                    pbRang1Beige.Enabled = true;
                    break;
                case "B":
                    pbRang2Beige.Enabled = true;
                    break;
                case "C":
                    pbRang3Beige.Enabled = true;
                    break;
                case "D":
                    pbRang4Beige.Enabled = true;
                    break;
                case "E":
                    pbRang5Beige.Enabled = true;
                    break;
            }
            
        }
        public void DesactiverRange(string rangee)
        {
            switch (rangee)
            {
                case "A":
                    pbRang1Beige.Enabled = false;
                    break;
                case "B":
                    pbRang2Beige.Enabled = false;
                    break;
                case "C":
                    pbRang3Beige.Enabled = false;
                    break;
                case "D":
                    pbRang4Beige.Enabled = false;
                    break;
                case "E":
                    pbRang5Beige.Enabled = false;
                    break;
            }
        }
        


        public void activerBoutons()
        {
            btPiocher.Enabled = true;
           
           
        }

        public void activerBoutonMettre()
        {
            btPrendreRangee.Enabled = true;
        }
        public void desactiverBoutons()
        {
            btPiocher.Enabled = false;
           

        }
        public void activerBoutonsThread()
        {
            btPiocher.Invoke(new activerBouton(activerBoutons));
            btPrendreRangee.Invoke(new activerBouton(activerBoutonMettre));
          
        }
        public void desactiverControlsThread()
        {
            btPiocher.Invoke(new desactiverControl(desactiverBoutons));
            btPrendreRangee.Invoke(new desactiverControl(desactiverBoutonPrendre));
        }

        public void desactiverBoutonPiocheThread()
        {
            btPiocher.Invoke(new desactiverControl(desactiverBoutons));
        }
        public void desactiverBoutonPrendre()
        {
            btPrendreRangee.Enabled = false;
        }
        public void activerBoutonPrendreThread()
        {
            btPiocher.Invoke(new activerBouton(activerBoutonMettre));
        }
        public void desactiverBoutonPrendreThread()
        {
            btPrendreRangee.Invoke(new desactiverControl(desactiverBoutonPrendre));
        }

        
       


        ///<summary>
        ///FIN FONCTIONS ACTIONS DES JOUEURS
        ///</summary>
        ///

        ///<summary>
        ///DEBUT FONCTIONS DE MISE A JOUR DES RANGEES IMAGES
        ///</summary>

        public void MettreAJourRangeeA()
        {
            if (maTable.GetRangeeA().Count == 1)
            {
                pbRang1Card1.BackgroundImage = maTable.GetRangeeA()[0].GetImageCarte();
            }
            else if (maTable.GetRangeeA().Count == 2)
            {
                pbRang1Card1.BackgroundImage = maTable.GetRangeeA()[0].GetImageCarte();
                pbRang1Card2.BackgroundImage = maTable.GetRangeeA()[1].GetImageCarte();
            }
            else if (maTable.GetRangeeA().Count == 3)
            {
                pbRang1Card1.BackgroundImage = maTable.GetRangeeA()[0].GetImageCarte();
                pbRang1Card2.BackgroundImage = maTable.GetRangeeA()[1].GetImageCarte();
                pbRang1Card3.BackgroundImage = maTable.GetRangeeA()[2].GetImageCarte();
            }
            else if (maTable.GetRangeeA().Count == 0)
            {
                pbRang1Card1.BackgroundImage = null;
                pbRang1Card2.BackgroundImage = null;
                pbRang1Card3.BackgroundImage = null;
            }
        }
        public void MettreAJourRangeeB()
        {
            if (maTable.GetRangeeB().Count == 1)
            {
                pbRang2Card1.BackgroundImage = maTable.GetRangeeB()[0].GetImageCarte();
            }
            else if (maTable.GetRangeeB().Count == 2)
            {
                pbRang2Card1.BackgroundImage = maTable.GetRangeeB()[0].GetImageCarte();
                pbRang2Card2.BackgroundImage = maTable.GetRangeeB()[1].GetImageCarte();
            }
            else if (maTable.GetRangeeB().Count == 3)
            {
                pbRang2Card1.BackgroundImage = maTable.GetRangeeB()[0].GetImageCarte();
                pbRang2Card2.BackgroundImage = maTable.GetRangeeB()[1].GetImageCarte();
                pbRang2Card3.BackgroundImage = maTable.GetRangeeB()[2].GetImageCarte();
            }
            else if (maTable.GetRangeeB().Count == 0)
            {
                pbRang2Card1.BackgroundImage = null;
                pbRang2Card2.BackgroundImage = null;
                pbRang2Card3.BackgroundImage = null;
            }
        }
        public void MettreAJourRangeeC()
        {
            if (maTable.GetRangeeC().Count == 1)
            {
                pbRang3Card1.BackgroundImage = maTable.GetRangeeC()[0].GetImageCarte();
            }
            else if (maTable.GetRangeeC().Count == 2)
            {
                pbRang3Card1.BackgroundImage = maTable.GetRangeeC()[0].GetImageCarte();
                pbRang3Card2.BackgroundImage = maTable.GetRangeeC()[1].GetImageCarte();
            }
            else if (maTable.GetRangeeC().Count == 3)
            {
                pbRang3Card1.BackgroundImage = maTable.GetRangeeC()[0].GetImageCarte();
                pbRang3Card2.BackgroundImage = maTable.GetRangeeC()[1].GetImageCarte();
                pbRang3Card3.BackgroundImage = maTable.GetRangeeC()[2].GetImageCarte();
            }
            else if (maTable.GetRangeeC().Count == 0)
            {
                pbRang3Card1.BackgroundImage = null;
                pbRang3Card2.BackgroundImage = null;
                pbRang3Card3.BackgroundImage = null;
            }
            
        }

        public void MettreAJourRangeeD()
        {
            if (maTable.GetRangeeD().Count == 1)
            {
                pbRang4Card1.BackgroundImage = maTable.GetRangeeD()[0].GetImageCarte();
            }
            else if (maTable.GetRangeeD().Count == 2)
            {
                pbRang4Card1.BackgroundImage = maTable.GetRangeeD()[0].GetImageCarte();
                pbRang4Card2.BackgroundImage = maTable.GetRangeeD()[1].GetImageCarte();
            }
            else if (maTable.GetRangeeD().Count == 3)
            {
                pbRang4Card1.BackgroundImage = maTable.GetRangeeD()[0].GetImageCarte();
                pbRang4Card2.BackgroundImage = maTable.GetRangeeD()[1].GetImageCarte();
                pbRang4Card3.BackgroundImage = maTable.GetRangeeD()[2].GetImageCarte();
            }
            else if (maTable.GetRangeeD().Count == 0)
            {
                pbRang4Card1.BackgroundImage = null;
                pbRang4Card2.BackgroundImage = null;
                pbRang4Card3.BackgroundImage = null;
            }
        }
        public void MettreAJourRangeeE()
        {
            if (maTable.GetRangeeE().Count == 1)
            {
                pbRang5Card1.BackgroundImage = maTable.GetRangeeE()[0].GetImageCarte();
            }
            else if (maTable.GetRangeeE().Count == 2)
            {
                pbRang5Card1.BackgroundImage = maTable.GetRangeeE()[0].GetImageCarte();
                pbRang5Card2.BackgroundImage = maTable.GetRangeeE()[1].GetImageCarte();
            }
            else if (maTable.GetRangeeE().Count == 3)
            {
                pbRang5Card1.BackgroundImage = maTable.GetRangeeE()[0].GetImageCarte();
                pbRang5Card2.BackgroundImage = maTable.GetRangeeE()[1].GetImageCarte();
                pbRang5Card3.BackgroundImage = maTable.GetRangeeE()[2].GetImageCarte();
            }
            else if (maTable.GetRangeeE().Count == 0)
            {
                pbRang5Card1.BackgroundImage = null;
                pbRang5Card2.BackgroundImage = null;
                pbRang5Card3.BackgroundImage = null;
            }
        }

        public void MettreAJourRangee(string uneRange)
        {
            switch (uneRange)
            {
                case "A":
                    MettreAJourRangeeA();
                    break;

                case "B":
                    MettreAJourRangeeB();
                    break;
                case "C":
                    MettreAJourRangeeC();
                    break;
                case "D":
                    MettreAJourRangeeD();
                    break;
                case "E":
                    MettreAJourRangeeE();
                    break;
            }
        }

        ///<summary>
        ///FIN FONCTIONS DE MISE A JOUR DES RANGEES IMAGES
        ///</summary>


        ///<summary>
        ///DEBUT FONCTIONS OUTILITAIRES
        ///</summary>
        public bool compararer(Image Manche)
        {
            bool rep = false;
            Image imgComparer = Manche;
            Image bck = pictureBox2.BackgroundImage;

            byte[] img = ImageToByte(Manche);
            byte[] pbback = ImageToByte(bck);

            if (img.Length == pbback.Length && img != null && pbback != null)
            {
                for (int i = 0; i < pbback.Length; i++)  //compare every byte
                {
                    if (pbback[i] != img[i])
                    {
                        rep = false;
                    }
                    else
                        rep = true;
                }
                return rep;
            }
            else
            {
                return rep = false;
            }

        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        ///<summary>
        ///FIN FONCTIONS OUTILITAIRES
        ///</summary>
        
        ///<summary>
        ///AUTRES FONCTIONS
        ///</summary>

        public string MeuilleurRangeeAPrendre(int nbDeJoueurs, string nomDeCarte)
        {
            string bestRang = "s";
            int nbRangeeA;
            int nbRangeeB;
            int nbRangeeC;
            int nbRangeeD;
            int nbRangeeE;
            
            if (nbDeJoueurs <=3)
            {
                nbRangeeA = maTable.nombreDeCarteCouleur("A", nomDeCarte);
                nbRangeeB = maTable.nombreDeCarteCouleur("B", nomDeCarte);
                nbRangeeC = maTable.nombreDeCarteCouleur("C", nomDeCarte);

                if (nbRangeeA > nbRangeeB)
                {
                    bestRang = "A";
                }
                else if (nbRangeeB > nbRangeeC)
                {
                    bestRang = "B";
                }
                else
                    bestRang = "C";
                return bestRang;
                
            }
            else if (nbDeJoueurs == 4)
            {
                nbRangeeA = maTable.nombreDeCarteCouleur("A", nomDeCarte);
                nbRangeeB = maTable.nombreDeCarteCouleur("B", nomDeCarte);
                nbRangeeC = maTable.nombreDeCarteCouleur("C", nomDeCarte);
                nbRangeeD = maTable.nombreDeCarteCouleur("D", nomDeCarte);

                if (nbRangeeA > nbRangeeB)
                {
                    bestRang = "A";
                }
                else if (nbRangeeB > nbRangeeC)
                {
                    bestRang = "B";
                }
                else if (nbRangeeC > nbRangeeD)
                    bestRang = "C";
                else
                {
                    bestRang = "D";
                }
                return bestRang;
                
            }
            else if (nbDeJoueurs == 5)
            {
                nbRangeeA = maTable.nombreDeCarteCouleur("A", nomDeCarte);
                nbRangeeB = maTable.nombreDeCarteCouleur("B", nomDeCarte);
                nbRangeeC = maTable.nombreDeCarteCouleur("C", nomDeCarte);
                nbRangeeD = maTable.nombreDeCarteCouleur("D", nomDeCarte);
                nbRangeeE = maTable.nombreDeCarteCouleur("E", nomDeCarte);

                if (nbRangeeA > nbRangeeB)
                {
                    bestRang = "A";
          
                }
                else if (nbRangeeB > nbRangeeC)
                {
                    bestRang = "B";
                  
                }
                else if (nbRangeeC > nbRangeeD)
                {
                    bestRang = "C";
              
                }
                else if (nbRangeeD > nbRangeeE)
                {
                    bestRang = "D";
                  
                }
                else if (nbRangeeD <= nbRangeeE)
                {
                    bestRang = "E";
                    
                }
               
            }

            return bestRang;
            
        }

        public Tuple<int,string> AnalyseDeChoixPrendreBot(Joueur unJoueur)
        {
            
            string carteLapluhaute = unJoueur.NomDeCarteLaPlusHaute();
            string bestRangee = MeuilleurRangeeAPrendre(listeJoueurs.Count, carteLapluhaute);

            int nbDeCartesDansRangee = maTable.nombreDeCarteCouleur(bestRangee, carteLapluhaute);

            Tuple<int, string> monTuple = new Tuple<int, string>(nbDeCartesDansRangee, bestRangee);
            return monTuple;
        }

        public void ChoixDesBot(Joueur unJoueur)
        {
            Tuple<int, string> monTuple = AnalyseDeChoixPrendreBot(unJoueur);
            if (monTuple.Item1 >0)
            {
                unJoueur.PrendreRangee(maTable, monTuple.Item2);
                maTable.ResetRangee(monTuple.Item2);
                MettreAJourRangee(monTuple.Item2);
                Thread.Sleep(300);
                MiseAJourJoueursThread();
                DesactiverRangeeThread(monTuple.Item2);
                unJoueur.ChangerDroitTour(false);
          
               
                
                
            }
            else if(monTuple.Item1 == 0)
            {
         
                ChoixPiocherBot(unJoueur);
            }
        }

         public List<string> RangeesLibres(int nbJoueur)
        {
           
            List<string> maListe = new List<string>();
            switch (nbJoueur)
            {
                case 2:
                    if (pbRang1Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeA().Count < 1)
                        {
                            maListe.Add("A");
                        }
                    }
                    if (pbRang2Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeB().Count < 2)
                            maListe.Add("B");
                    }
                    if (pbRang3Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeC().Count < 3)
                            maListe.Add("C");
                    }
                    break;
                case 3:
                    if (pbRang1Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeA().Count < 3)
                        {
                            maListe.Add("A");
                        }
                    }
                    if (pbRang2Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeB().Count < 3)
                        {
                            maListe.Add("B");
                        }
                    }
                    if (pbRang3Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeC().Count < 3)
                        {
                            maListe.Add("C");
                        }
                    }
                    break;
                case 4:
                    if (pbRang1Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeA().Count < 3)
                        {
                            maListe.Add("A");
                        }
                    }
                    if (pbRang2Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeB().Count < 3)
                        {
                            maListe.Add("B");
                        }
                    }
                    if (pbRang3Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeC().Count < 3)
                        {
                            maListe.Add("C");
                        }
                    }
                    if (pbRang4Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeD().Count < 3)
                        {
                            maListe.Add("D");
                        }
                    }
                    break;
                case 5:
                    if (pbRang1Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeA().Count < 3)
                        {
                            maListe.Add("A");
                        }
                    }
                    if (pbRang2Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeB().Count < 3)
                        {
                            maListe.Add("B");
                        }
                    }
                    if (pbRang3Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeC().Count < 3)
                        {
                            maListe.Add("C");
                        }

                    }
                    if (pbRang4Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeD().Count < 3)
                        {
                            maListe.Add("D");
                        }
                    }
                    if (pbRang5Beige.Enabled == true)
                    {
                        if (maTable.GetRangeeE().Count < 3)
                        {
                            maListe.Add("E");
                        }
                    }
                    break;
            }
            return maListe;
        }
         public List<string> RangeesDisponiblePourPrendre(int nbJoueur)
         {

             List<string> maListe = new List<string>();
             switch (nbJoueur)
             {
                 case 2:
                     if (pbRang1Beige.Enabled == true)
                     {
                         
                             maListe.Add("A");
                         
                     }
                     if (pbRang2Beige.Enabled == true)
                     {
      
                             maListe.Add("B");
                         
                     }
                     if (pbRang3Beige.Enabled == true)
                     {
                       
                             maListe.Add("C");
                         
                     }
                     break;

                 case 3:
                     if (pbRang1Beige.Enabled == true)
                     {
                         
                             maListe.Add("A");
                         
                     }
                     if (pbRang2Beige.Enabled == true)
                     {
      
                             maListe.Add("B");
                         
                     }
                     if (pbRang3Beige.Enabled == true)
                     {
                       
                             maListe.Add("C");
                         
                     }
                     break;
                 case 4:
                     if (pbRang1Beige.Enabled == true)
                     {
                       
                             maListe.Add("A");
                         
                     }
                     if (pbRang2Beige.Enabled == true)
                     {
                       
                             maListe.Add("B");
                         
                     }
                     if (pbRang3Beige.Enabled == true)
                     {
                        
                             maListe.Add("C");
                         
                     }
                     if (pbRang4Beige.Enabled == true)
                     {
                         
                             maListe.Add("D");
                         
                     }
                     break;
                 case 5:
                     if (pbRang1Beige.Enabled == true)
                     {
                         
                             maListe.Add("A");
                         
                     }
                     if (pbRang2Beige.Enabled == true)
                     {
                         
                             maListe.Add("B");
                         
                     }
                     if (pbRang3Beige.Enabled == true)
                     {
                        
                             maListe.Add("C");
                         

                     }
                     if (pbRang4Beige.Enabled == true)
                     {
                         
                             maListe.Add("D");
                         
                     }
                     if (pbRang5Beige.Enabled == true)
                     {
                         
                             maListe.Add("E");
                         
                     }
                     break;
             }
             return maListe;
         }


        public void ChoixPiocherBot(Joueur unJoueur)
        {
            List<string> listeDeRangeesLibres = RangeesLibres(listeJoueurs.Count);
            if (listeDeRangeesLibres.Count > 0)
            {
                Random rd = new Random();
                int nbAlea = rd.Next(listeDeRangeesLibres.Count);

                string rangeeChoix = listeDeRangeesLibres[nbAlea];
                unJoueur.PiocheCarte(maTable);
                pictureBox2.BackgroundImage = maTable.GetPioche()[0].GetImageCarte();
                Thread.Sleep(400);
                if (maTable.GetPioche()[0].GetNom() == "manche")
                {
                    MessageBox.Show("Dernier Round");
                    dernierRound = true;
                    Thread.Sleep(1000);
                    maTable.GetPioche().Remove(maTable.GetPioche()[0]);
                    unJoueur.PiocheCarte(maTable);
                    pictureBox2.BackgroundImage = maTable.GetPioche()[0].GetImageCarte();
                }
                
                Carte maCarte = maTable.GetPioche()[0];
         
                maTable.AjouterCarteDansRangee(maCarte, rangeeChoix);
                MettreAJourRangee(rangeeChoix);
                maTable.GetPioche().Remove(maCarte);
                pictureBox2.BackgroundImage = null;
                Thread.Sleep(400);
            }
            else if (listeDeRangeesLibres.Count == 0)
            {
                List<string> listeRangeesLibresPourPrendre = RangeesDisponiblePourPrendre(listeJoueurs.Count);
                Random r = new Random();
                int nbAleatoire = r.Next(listeRangeesLibresPourPrendre.Count);
                unJoueur.PrendreRangee(maTable, listeRangeesLibresPourPrendre[nbAleatoire]);
                maTable.ResetRangee(listeRangeesLibresPourPrendre[nbAleatoire]);
                MettreAJourRangee(listeRangeesLibresPourPrendre[nbAleatoire]);
                Thread.Sleep(300);
                MiseAJourJoueursThread();
                DesactiverRangeeThread(listeRangeesLibresPourPrendre[nbAleatoire]);
                unJoueur.ChangerDroitTour(false);

            }
        }

        /// <summary>
        /// Fonctions De Calcul De points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public List<string> ListeDeTroisCouleursPositifs()
        {
            List<string> couleursPositifsJ1 = new List<string>();
            foreach (Control c in gbJoueur.Controls)
            {
                if (c is CheckBox)
                {
                    if (((CheckBox)c).Checked)
                    {
                        couleursPositifsJ1.Add(c.Tag.ToString());
                    }
                }
            }
            return couleursPositifsJ1;
        }

        public List<string> ListeDeCouleursNegatifs()
        {
            List<string> couleursNegatifsJ1 = new List<string>();
            foreach (Control c in gbJoueur.Controls)
            {
                if (c is CheckBox)
                {
                    if (((CheckBox)c).Checked == false)
                    {
                        couleursNegatifsJ1.Add(c.Tag.ToString());
                    }
                }
            }
            return couleursNegatifsJ1;
        }

        public int CalculDePointsSelonCartes(int nombreDeCartes, Joueur unJoueur)
        {
            int points = 0;
            if (unJoueur.TypeScore == true)
            {
                if (nombreDeCartes == 1)
                {
                    points = 1;
                }
                else if (nombreDeCartes == 2)
                {
                    points = 3;
                }
                else if (nombreDeCartes == 3)
                {
                    points = 6;
                }
                else if (nombreDeCartes == 4)
                {
                    points = 10;
                }
                else if (nombreDeCartes == 5)
                {
                    points = 15;
                }
                else if (nombreDeCartes >= 6)
                {
                    points = 21;
                }
            }
            else
            {
                if (nombreDeCartes == 1)
                {
                    points = 1;
                }
                else if (nombreDeCartes == 2)
                {
                    points = 4;
                }
                else if (nombreDeCartes == 3)
                {
                    points = 8;
                }
                else if (nombreDeCartes == 4)
                {
                    points = 7;
                }
                else if (nombreDeCartes == 5)
                {
                    points = 6;
                }
                else if (nombreDeCartes >= 6)
                {
                    points = 5;
                }
            }
            return points;
        }

        public int CalculDePointsParListe(List<string> ListeDeCouleur, Joueur unJoueur)
        {
            int PointsPositifs = 0;
            for (int i = 0; i<ListeDeCouleur.Count; i++)
            {
               
                int nombreDeCarte = Convert.ToInt32(unJoueur.nombreDeCartesCouleur(ListeDeCouleur[i]));
                
                PointsPositifs += CalculDePointsSelonCartes(nombreDeCarte, unJoueur);
           
            }
            return PointsPositifs;
        }

        public List<string> ListeDeTroisCouleursBot(Joueur unJoueur)
        {
            List<int> listeNbDeCarte = ListeDesNbDeChaqueCarte(unJoueur);
            List<string> listeDeRetour = new List<string>();
            List<string> couleurs = new List<string>() { "rouge", "jaune", "vert", "orange", "violet", "bleu", "marron" };

            for (int i = 0; i < 3; i++)
            {
                for (int c= 0; c < couleurs.Count; c++)
                {
                    int nbCartes = Convert.ToInt32(unJoueur.nombreDeCartesCouleur(couleurs[c]));
                    if (nbCartes == listeNbDeCarte.Max())
                    {
                        listeDeRetour.Add(couleurs[c]);
                        listeNbDeCarte.Remove(nbCartes);
                        couleurs.Remove(couleurs[c]);
                        break;
                    }
                }
                if (listeDeRetour.Count == 3)
                {
                    break;
                }
            }
            return listeDeRetour;

 
        }
        public List<string> ListeDeCouleurNegatifsBot(List<string> uneListe)
        {
            List<string> couleurs = new List<string>() { "rouge", "jaune", "vert", "orange", "violet", "bleu", "marron" };
            foreach (string s in uneListe)
            {
                couleurs.Remove(s);
            }
            return couleurs;
            
        }

        public void ChangementScorePlusEtMoinToutLesJoueurs()
        {
            for (int i = 0; i < listeJoueurs.Count-1; i++)
            {
                AjouterLesCartesJokerBot(listeJoueurs[i]);
                List<string> couleurPositives = ListeDeTroisCouleursBot(listeJoueurs[i]);
               
                List<string> couleurNegatives = ListeDeCouleurNegatifsBot(couleurPositives);
                int pointsPositifs = CalculDePointsParListe(couleurPositives, listeJoueurs[i]);
                int pointsNegatifs = CalculDePointsParListe(couleurNegatives, listeJoueurs[i]);
                listeJoueurs[i].ChangerPointsPositifs(pointsPositifs);
                listeJoueurs[i].ChangerPointsNegatifs(pointsNegatifs);

                maManche.GetJoueurs()[i].ChangerScoreManche(CalculDeScoreMancheBot(listeJoueurs[i]));

             
            }
 
        }

        public List<int> ListeDesNbDeChaqueCarte(Joueur unJoueur)
        {
            List<int> nb = new List<int>();
            List<string> couleurs = new List<string>() { "rouge", "jaune","vert","orange","violet","bleu","marron" };
            foreach (string s in couleurs)
            {
                nb.Add(Convert.ToInt32(unJoueur.nombreDeCartesCouleur(s)));

            }
            return nb;
        }

        public void AjouterLesCartesJoker(Joueur unJoueur)
        {
            if (unJoueur.GetListeJoker().Count == 1)
            {
                Carte carte1 = new Carte(cbJoker1.SelectedItem.ToString());
                
                unJoueur.AjouterCartes(carte1);
                 
            }
            else if (unJoueur.GetListeJoker().Count == 2)
            {
                Carte carte1 = new Carte(cbJoker1.SelectedItem.ToString());
                Carte carte2 = new Carte(cbJoker2.SelectedItem.ToString());
                unJoueur.AjouterCartes(carte1);
                unJoueur.AjouterCartes(carte2);
            }
            else if (unJoueur.GetListeJoker().Count == 3)
            {
                Carte carte1 = new Carte(cbJoker1.SelectedItem.ToString());
                Carte carte2 = new Carte(cbJoker2.SelectedItem.ToString());
                Carte carte3 = new Carte(cbJoker3.SelectedItem.ToString());
                unJoueur.AjouterCartes(carte1);
                unJoueur.AjouterCartes(carte2);
                unJoueur.AjouterCartes(carte3);
            }

        }

        public void AjouterLesCartesJokerBot(Joueur unJoueur)
        {
            if (unJoueur.GetListeJoker().Count > 0)
            {
                List<string> couleurPositifs = ListeDeTroisCouleursBot(unJoueur);
                Random rd = new Random();
                for (int i = 0; i < unJoueur.GetListeJoker().Count; i++)
                {
                    int nbAleatoirePourLaliste = rd.Next(couleurPositifs.Count);
                    Carte Ajouter = new Carte(couleurPositifs[nbAleatoirePourLaliste]);
              
                    unJoueur.AjouterCartes(Ajouter);
                }
            }
        }

        public int CalculDeScoreMancheBot(Joueur unJoueur)
        {
            int scoreMancheRetour;
            int pointsPlus = 0;
            if (unJoueur.GetListePlus().Count > 0)
            {
                 pointsPlus = 2 * unJoueur.GetListePlus().Count();
            }

            List<string> couleurPositives = ListeDeTroisCouleursBot(unJoueur);
            List<string> couleurNegatives = ListeDeCouleurNegatifsBot(couleurPositives);
            int pointsPositifs = CalculDePointsParListe(couleurPositives,unJoueur);
            int pointsNegatifs = CalculDePointsParListe(couleurNegatives, unJoueur);
            

            scoreMancheRetour = (pointsPositifs - pointsNegatifs) + pointsPlus;
            return scoreMancheRetour;
        }



        public int CalculScoreManche(Joueur unJoueur)
        {
            int plus = 0;
            if (unJoueur.GetListePlus().Count > 0)
            {
                plus = unJoueur.GetListePlus().Count * 2;
            }
            int scoremancheCalcule = (unJoueur.GetPointsPositifs() - unJoueur.GetPointsNegatifs()) + plus;
            return scoremancheCalcule;
        }


        ///<summary>
        ///Fin Fonctions De calcul de points
        ///</summary>

        public void ChargerImagesCartesVertes()
        {
            pbRang1Beige.BackgroundImage = Properties.Resources.verteA;
            pbRang2Beige.BackgroundImage = Properties.Resources.verteB;
            pbRang3Beige.BackgroundImage = Properties.Resources.verteC;
        }
        ///<summary>
        ///DEBUT Fonction Pour le Mode 1 vs 1 
        ///</summary>
        ///


        ///<summary>
        ///Fin Mode 1 VS 1
        ///</summary>
        private void Game_Load(object sender, EventArgs e)
        {

            
            tatDeCartes = new List<Carte>();
            ResetDonnesCartes();
            Attribution_couleurDeparts_IA(listeJoueurs);
            Attribution_TypeDeScore(listeJoueurs);
            tatDeCartes = Creation_TatDeCartes();
            maTable.AjouterTatDeCartes(tatDeCartes);
            Attribution_CarteDepart(listeJoueurs);
            Attribution_CarteAide(listeJoueurs);
            //Attribution_CarteBeige(maTable);
            tatDeCartes = MelangeDuTatDeCartes();
            AffichageDesGroupeBoxIA();
            if(listeJoueurs.Count<=3)
                ActiverToutesRangeesThreadMode1vs1();
            ChargementImagesCarteAides();
            AffichageNoManche();
            AffichageNoPartie();
            maPartie.GetManches().Last<Manche>().GetJoueurs().Last<Joueur>().ChangerDroitTour(true);
            MiseAjourToutLesJoueurs();
            
            tour = 1;
            
            
            
        }

       


        private void label33_Click(object sender, EventArgs e)
        {
          

        }

      
        private void btQuitter_Click(object sender, EventArgs e)
        {
            th.Abort();
            this.Close();
            Home form = new Home();
            form.Show();
        }

        private void pbIA1score_Click(object sender, EventArgs e)
        {
            pbIA1score.BackgroundImage = listeJoueurs[0].GetListeAide()[0].GetImageCarte();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void Game_VisibleChanged(object sender, EventArgs e)
        {
        
        }

        private void pbRang1Beige_Click(object sender, EventArgs e)
        {
            choisieDeRangee = "A";
            if (action == 1)
            {
                if (listeJoueurs.Count == 2)
                {
                    if (maTable.GetRangeeA().Count == 1)
                    {
                        MessageBox.Show("choisie une autre rangee");

                    }
                    else if (maTable.GetRangeeA().Count < 1)
                    {

                        Carte maCarte = maTable.GetPioche()[0];
                        maTable.AjouterCarteDansRangee(maCarte, choisieDeRangee);
                        MettreAJourRangeeA();
                        maTable.GetPioche().Remove(maCarte);

                        pictureBox2.BackgroundImage = null;
                        action = 0;
                        tour = 1;
                    }
                }
                else
                {

                    if (maTable.GetRangeeA().Count == 3)
                    {
                        MessageBox.Show("choisie une autre rangee");

                    }
                    else if (maTable.GetRangeeA().Count < 3)
                    {

                        Carte maCarte = maTable.GetPioche()[0];
                        maTable.AjouterCarteDansRangee(maCarte, choisieDeRangee);
                        MettreAJourRangeeA();
                        maTable.GetPioche().Remove(maCarte);

                        pictureBox2.BackgroundImage = null;
                        action = 0;
                        tour = 1;
                    }
                }

            }
            else if (action == 2)
            {
                listeJoueurs.Last<Joueur>().PrendreRangee(maTable, choisieDeRangee);
                maTable.GetRangeeA().Clear();
                MettreAJourRangeeA();
                MettreAJourDonneesPlayer5();
                DesactiverRange(choisieDeRangee);
                pbRang1Beige.BackgroundImage = null;
                listeJoueurs.Last<Joueur>().ChangerDroitTour(false);
         
                action = 0;
                tour = 1;
            
                
                
            }
          

        }

        private void pbRang2Beige_Click(object sender, EventArgs e)
        { choisieDeRangee = "B";
            if (action == 1)
            {
                if (listeJoueurs.Count == 2)
                {
                    if (maTable.GetRangeeB().Count == 2)
                    {
                        MessageBox.Show("choisie une autre rangee");

                    }
                    else if (maTable.GetRangeeB().Count < 2)
                    {

                        Carte maCarte = maTable.GetPioche()[0];
                        maTable.AjouterCarteDansRangee(maCarte, choisieDeRangee);
                        MettreAJourRangeeB();
                        maTable.GetPioche().Remove(maCarte);

                        pictureBox2.BackgroundImage = null;
                        action = 0;
                        tour = 1;
                    }
                }
                else
                {

                    if (maTable.GetRangeeB().Count == 3)
                    {
                        MessageBox.Show("choisie une autre rangee");

                    }
                    else if (maTable.GetRangeeB().Count < 3)
                    {


                        Carte maCarte = maTable.GetPioche()[0];
                        maTable.AjouterCarteDansRangee(maCarte, choisieDeRangee);
                        MettreAJourRangeeB();
                        maTable.GetPioche().Remove(maCarte);
                        pictureBox2.BackgroundImage = null;

                        action = 0;
                        tour = 1;

                    }
                }
            }
            else if (action == 2)
            {
                listeJoueurs.Last<Joueur>().PrendreRangee(maTable, choisieDeRangee);
                maTable.GetRangeeB().Clear();
                MettreAJourRangeeB();
                MettreAJourDonneesPlayer5();
                pbRang2Beige.BackgroundImage = null;
                DesactiverRange(choisieDeRangee);
                listeJoueurs.Last<Joueur>().ChangerDroitTour(false);
       
                action = 0;
                tour = 1;
              
            }
                
        }

        private void pbRang3Beige_Click(object sender, EventArgs e)
        {
            
            choisieDeRangee = "C";
            if (action == 1)
            {
                if (maTable.GetRangeeC().Count == 3)
                {
                    MessageBox.Show("choisie une autre rangee");

                }
                else if (maTable.GetRangeeC().Count < 3)
                {


                    Carte maCarte = maTable.GetPioche()[0];
                    maTable.AjouterCarteDansRangee(maCarte, choisieDeRangee);
                    MettreAJourRangeeC();
                    maTable.GetPioche().Remove(maCarte);
                    pictureBox2.BackgroundImage = null;
                    action = 0;
                    tour = 1;
               
                }
            }
            else if (action == 2)
            {
                listeJoueurs.Last<Joueur>().PrendreRangee(maTable, choisieDeRangee);
                maTable.GetRangeeC().Clear();
                MettreAJourRangeeC();
                MettreAJourDonneesPlayer5();
                DesactiverRange(choisieDeRangee);
                pbRang3Beige.BackgroundImage = null;
                listeJoueurs.Last<Joueur>().ChangerDroitTour(false);
           
                action = 0;
                tour = 1;
             
            }
        }

        private void pbRang4Beige_Click(object sender, EventArgs e)
        {
            
            choisieDeRangee = "D";
            if (action == 1)
            {
                if (maTable.GetRangeeD().Count == 3)
                {
                    MessageBox.Show("choisie une autre rangee");

                }
                else if (maTable.GetRangeeD().Count < 3)
                {


                    Carte maCarte = maTable.GetPioche()[0];
                    maTable.AjouterCarteDansRangee(maCarte, choisieDeRangee);
                    MettreAJourRangeeD();
                    maTable.GetPioche().Remove(maCarte);
                    pictureBox2.BackgroundImage = null;
                    action = 0;
                    tour = 1;
                 
                }
            }
            else if (action == 2)
            {
                listeJoueurs.Last<Joueur>().PrendreRangee(maTable, choisieDeRangee);
                maTable.GetRangeeD().Clear();
                MettreAJourRangeeD();
                MettreAJourDonneesPlayer5();
                DesactiverRange(choisieDeRangee);
                pbRang4Beige.BackgroundImage = null;
                listeJoueurs.Last<Joueur>().ChangerDroitTour(false);

                action = 0;
                tour = 1;
            }
        }

        private void pbRang5Beige_Click(object sender, EventArgs e)
        {
            choisieDeRangee = "E";
            if (action == 1)
            {
                if (maTable.GetRangeeE().Count == 3)
                {
                    MessageBox.Show("choisie une autre rangee");

                }
                else if (maTable.GetRangeeE().Count < 3)
                {


                    Carte maCarte = maTable.GetPioche()[0];
                    maTable.AjouterCarteDansRangee(maCarte, choisieDeRangee);
                    MettreAJourRangeeE();
                    maTable.GetPioche().Remove(maCarte);
                    pictureBox2.BackgroundImage = null;
                    action = 0;
                    tour = 1;
                }
            }
            else if (action == 2)
            {
                listeJoueurs.Last<Joueur>().PrendreRangee(maTable, choisieDeRangee);
                maTable.GetRangeeE().Clear();
                MettreAJourRangeeE();
                MettreAJourDonneesPlayer5();
                DesactiverRange(choisieDeRangee);
                pbRang5Beige.BackgroundImage = null;
                listeJoueurs.Last<Joueur>().ChangerDroitTour(false);
          
                action = 0;
                tour = 1;
                    
            }
        }

        private void btPrendreRangee_Click(object sender, EventArgs e)
        {
            action = 2;
       
        }

        private void Game_Shown(object sender, EventArgs e)
        {
            th = new Thread(Cycle_Manche);
            th.Start();           
        }

        

        private void pictureBox2_BackgroundImageChanged(object sender, EventArgs e)
        {

            
        }

        private void btPiocher_Click(object sender, EventArgs e)
        {
            action = 1;
            listeJoueurs.Last<Joueur>().PiocheCarte(maTable);
            pictureBox2.BackgroundImage = maTable.GetPioche()[0].GetImageCarte();
            if (maTable.GetPioche()[0].GetNom() == "manche")
            {
                MessageBox.Show("Dernier Round");
                dernierRound = true;
                Thread.Sleep(1000);
                maTable.GetPioche().Remove(maTable.GetPioche()[0]);
                listeJoueurs.Last<Joueur>().PiocheCarte(maTable);
                pictureBox2.BackgroundImage = maTable.GetPioche()[0].GetImageCarte();
            }
         
        }

        private void pbRang1Card1_DragEnter(object sender, DragEventArgs e)
        {
            MessageBox.Show("lol");
        }

        private void pictureBox2_DragLeave(object sender, EventArgs e)
        {
            MessageBox.Show("lol");
        }

        private void pbRang1Card1_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(listeJoueurs[4].nombreDeCartesCouleur("bleu").ToString());
        }

        private void btTableauDeScore_Click(object sender, EventArgs e)
        {
            int scorePositif;
            int scoreNegatif;
            List<string> couleurChoisies = ListeDeTroisCouleursPositifs();
            List<string> couleurNegatifs = ListeDeCouleursNegatifs();


            if (couleurChoisies.Count != 3)
            {
                MessageBox.Show("veuillez choisir seulement trois couleurs");
            }
            else
            {
                AjouterLesCartesJoker(listeJoueurs.Last<Joueur>());
                scorePositif  = CalculDePointsParListe(couleurChoisies, listeJoueurs.Last<Joueur>());
                scoreNegatif = CalculDePointsParListe(couleurNegatifs, listeJoueurs.Last<Joueur>());
                listeJoueurs.Last<Joueur>().ChangerPointsPositifs(scorePositif);
                listeJoueurs.Last<Joueur>().ChangerPointsNegatifs(scoreNegatif);
                listeJoueurs.Last<Joueur>().ChangerScoreManche(CalculScoreManche(listeJoueurs.Last<Joueur>()));
          
                ChangementScorePlusEtMoinToutLesJoueurs();
               
            
                
                Score_manche form = new Score_manche(listeJoueurs, maPartie);
              
                form.Show();
                this.Close();

            }

        }

        private void btCalculScore_Click(object sender, EventArgs e)
        {
            foreach (Control c in gbJoueur.Controls)
            {
               if (c is CheckBox)
                {
                    c.Visible = true;
                  
                 }
            }

            if (listeJoueurs.Last<Joueur>().GetListeJoker().Count == 1)
            {
                MessageBox.Show("vous avez 1 Joker veuillez choisir sa couleur");
                cbJoker1.Visible = true;
            }
             else if (listeJoueurs.Last<Joueur>().GetListeJoker().Count == 2)
            {
                MessageBox.Show("vous avez 2 Joker veuillez choisir les couleurs");
                cbJoker1.Visible = true;
                cbJoker2.Visible = true;
            }
            else if (listeJoueurs.Last<Joueur>().GetListeJoker().Count == 3)
            {
                MessageBox.Show("vous avez 3 Joker veuillez choisir les couleurs");
                cbJoker1.Visible = true;
                cbJoker2.Visible = true;
                cbJoker3.Visible = true;
            }
            
        }




        public int scorePositif { get; set; }

    }
}
