using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coloretto1._2
{
    public class Joueur
    {
        static int countId;
        private int id;
        private string nom { get; set; }
        private int pointPositifs { get; set; }
        private int pointNegatifs { get; set; }
        private int scoreManche { get; set; }
       
        private List<Carte> listeCouleurs { get; set; }
        private List<Carte> listeJokers { get; set; }
        private List<Carte> listePlus { get; set; }
        private List<Carte> listeAide { get; set; }
        private bool typeScore;

        public bool TypeScore
        {
            get { return typeScore; }
            set { typeScore = value; }
        }
        private bool droitDeTour {get;set;}
        private string couleurDepart;

        public string CouleurDepart
        {
            get { return couleurDepart; }
            set { couleurDepart = value; }
        }
   
        public Joueur(string unNom)
        {
            countId++;
            this.id = countId;
            this.nom = unNom;
            this.scoreManche = 0;
           
            this.listeCouleurs = new List<Carte>();
            this.listeJokers = new List<Carte>();
            this.listePlus = new List<Carte>();
            this.listeAide = new List<Carte>();
            this.pointNegatifs = 0;
            this.pointPositifs = 0;
            this.typeScore = true;
            this.droitDeTour = true;
            

        }

        public Joueur()
        {
            // TODO: Complete member initialization
        }

       
        public int GetId()
        {
            return this.id;
        }
        public string GetNom()
        {
            return this.nom;
        }
        public int GetScoreManche()
        {
            return this.scoreManche;
        }
        public List<Carte> GetLesCartes()
        {
            return this.listeCouleurs;
        }
        public List<Carte> GetListeAide()
        {
            return this.listeAide;
        }
        public List<Carte> GetListeJoker()
        {
            return this.listeJokers;
        }
        public List<Carte> GetListePlus()
        {
            return this.listePlus;
        }
        public bool GetDroitTour()
        {
            return this.droitDeTour;

        }
        public int GetPointsPositifs()
        {
            return this.pointPositifs;
        }
        public int GetPointsNegatifs()
        {
            return this.pointNegatifs;
        }
      
        public void ChangerPointsPositifs(int points)
        {
            this.pointPositifs = points;
        }
        public void ChangerPointsNegatifs(int points)
        {
            this.pointNegatifs = points;
        }
        public void ChangerTypeScore(bool unType)
        {
            this.typeScore = unType;
        }
        public void ChangerDroitTour(bool unType)
        {
            this.droitDeTour = unType;
        }
        public void ChangerScoreManche(int score)
        {
            this.scoreManche = score;
        }
    
        public void AjouterCartes(Carte uneCarte)
        {
            this.listeCouleurs.Add(uneCarte);
        }

        public void AjouterCarteAide(Carte uneCarte)
        {
            this.listeAide.Add(uneCarte);

        }
        public void AjouterCarteJoker(Carte uneCarte)
        {
            this.listeJokers.Add(uneCarte);

        }
        public void AjouterCartePlus(Carte uneCarte)
        {
            this.listePlus.Add(uneCarte);
        }
        public void PrendreRangee(TableDeJeu uneTable, string uneRangee)
        {
            //Ajoute les cartes de la rangée choisie et la mes dans les propriétés mesCartes du joueur
            switch (uneRangee)
            {
                case "A":

                    foreach (Carte c in uneTable.GetRangeeA())
                    {
                        if (c.GetNom() == "joker")
                        {
                            this.AjouterCarteJoker(c);
                        }
                        else if (c.GetNom() == "plus")
                        {
                            this.AjouterCartePlus(c);
                        }
                        else
                            this.listeCouleurs.Add(c);
                    }
                    break;
                case "B":
                    foreach (Carte c in uneTable.GetRangeeB())
                    {
                        if (c.GetNom() == "joker")
                        {
                            this.AjouterCarteJoker(c);
                        }
                        else if (c.GetNom() == "plus")
                        {
                            this.AjouterCartePlus(c);
                        }
                        else
                            this.listeCouleurs.Add(c);
                    }
                    break;
                case "C":
                    foreach (Carte c in uneTable.GetRangeeC())
                    {
                        if (c.GetNom() == "joker")
                        {
                            this.AjouterCarteJoker(c);
                        }
                        else if (c.GetNom() == "plus")
                        {
                            this.AjouterCartePlus(c);
                        }
                        else
                            this.listeCouleurs.Add(c);
                    }
                    break;
                case "D":
                    foreach (Carte c in uneTable.GetRangeeD())
                    {
                        if (c.GetNom() == "joker")
                        {
                            this.AjouterCarteJoker(c);
                        }
                        else if (c.GetNom() == "plus")
                        {
                            this.AjouterCartePlus(c);
                        }
                        else
                            this.listeCouleurs.Add(c);
                    }
                    break;
                case "E":
                    foreach (Carte c in uneTable.GetRangeeE())
                    {
                        if (c.GetNom() == "joker")
                        {
                            this.AjouterCarteJoker(c);
                        }
                        else if (c.GetNom() == "plus")
                        {
                            this.AjouterCartePlus(c);
                        }
                        else
                            this.listeCouleurs.Add(c);
                       
                    }
                    break;
            }
        }

        public void PiocheCarte(TableDeJeu uneTable)
        {
            Carte carteAjouter = uneTable.GetTatDeCarte()[0];
            uneTable.AjouterCarteDansPioche(carteAjouter);
            uneTable.GetTatDeCarte().Remove(carteAjouter);
          
        }

        public string nombreDeCartesCouleur(string nomDeCarte)
        {
            int compteur = 0;
            foreach (Carte c in this.listeCouleurs)
            {
                if (c.GetNom() == nomDeCarte)
                {
                    compteur = compteur + 1;

                }
            }
            return compteur.ToString();

        }

        public string nombreDeCartesJokerOuPlus(string nomDeCarte)
        {
            int compteur = 0;
            if (nomDeCarte == "joker")
            {
                foreach(Carte c in this.listeJokers)
                {
                    compteur = compteur + 1;
                }
            }
             else if (nomDeCarte =="plus")
                {
                 foreach(Carte c in this.listePlus)
                 {
                     compteur = compteur +1;

                 }
                }
            return compteur.ToString();
        }

       

        public string NomDeCarteLaPlusHaute()
        {
            string max;
            int nbOrange = Convert.ToInt32(nombreDeCartesCouleur("orange"));
            int nbBleu = Convert.ToInt32(nombreDeCartesCouleur("bleu"));
            int nbJaune = Convert.ToInt32(nombreDeCartesCouleur("jaune"));
            int nbMarron = Convert.ToInt32(nombreDeCartesCouleur("marron"));
            int nbViolet = Convert.ToInt32(nombreDeCartesCouleur("violet"));
            int nbVert = Convert.ToInt32(nombreDeCartesCouleur("vert"));
            int nbRouge = Convert.ToInt32(nombreDeCartesCouleur("rouge"));

            if (nbOrange > nbBleu)
            {
                max = "orange";

            }
            else if (nbBleu > nbJaune)
            {
                max = "bleu";
            }
            else if (nbJaune > nbMarron)
            {
                max = "jaune";

            }
            else if (nbMarron > nbViolet)
            {
                max = "marron";
            }
            else if (nbViolet > nbVert)
            {
                max = "violet";
            }
            else if (nbVert > nbRouge)
            {
                max = "vert";

            }
            else
                max = "rouge";
            return max;
            
        }

        
       
    }
}
