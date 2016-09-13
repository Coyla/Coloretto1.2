using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coloretto1._2
{
    public class TableDeJeu
    {
        //Champs privées //
        static int countId;
        private int id;
        private List<Carte> rangeeA { get; set; }
        private List<Carte> rangeeB { get; set; }
        private List<Carte> rangeeC { get; set; }
        private List<Carte> rangeeD { get; set; }
        private List<Carte> rangeeE { get; set; }
        private List<Carte> tatDeCartes { get; set; }
        private List<Carte> pioche { get; set; }

        //Fonctions//
        public TableDeJeu()
        {
            countId++;
            id = countId;
            rangeeA = new List<Carte>();
            rangeeB = new List<Carte>();
            rangeeC = new List<Carte>();
            rangeeD = new List<Carte>();
            rangeeE = new List<Carte>();
            tatDeCartes = new List<Carte>();
            

            pioche = new List<Carte>();
          
            
        }

        public int GetId()
        {
            return this.id;
        }
        public List<Carte> GetRangeeA()
        {
            return this.rangeeA;
        }
        public List<Carte> GetRangeeB()
        {
            return this.rangeeB;
        }
        public List<Carte> GetRangeeC()
        {
            return this.rangeeC;
        }
        public List<Carte> GetRangeeD()
        {
            return this.rangeeD;
        }
        public List<Carte> GetRangeeE()
        {
            return this.rangeeE;
        }

        public List<Carte> GetTatDeCarte()
        {
            return this.tatDeCartes;
        }
        public List<Carte> GetPioche()
        {
            return this.pioche;
        }

        public List<Carte> GetListeRange(string uneRange)
        {
            List<Carte> listeRetour = new List<Carte>();
            switch (uneRange)
            {
                case "A":
                    listeRetour = this.rangeeA;
                    break;
                case "B":
                    listeRetour = this.rangeeB;
                    break;
                case "C":
                    listeRetour = this.rangeeC;
                    break;
                  
                case "D":
                    listeRetour = this.rangeeD;
                    break;
                  
                case "E":
                    listeRetour= this.rangeeE;
                    break;
            }
            return listeRetour;
        }

        public void AjouterCarteDansRangee(Carte uneCarte, string uneRangee)
        {
            Carte lacarte = uneCarte;
            string larangee = uneRangee;
            switch (larangee) //On pose la carte selon la rangée indiqué
            {
                case "A":
                    rangeeA.Add(lacarte); //Ajout d'une carte dans la propriété rangeeA
                    break;
                case "B":
                    rangeeB.Add(lacarte);
                    break;
                case "C":
                    rangeeC.Add(lacarte);
                    break;
                case "D":
                    rangeeD.Add(lacarte);
                    break;
                case "E":
                    rangeeE.Add(lacarte);
                    break;

            }

        }
        public void AjouterCarteDansPioche(Carte uneCarte)
        {
            this.pioche.Add(uneCarte);

        }

        public void AjouterTatDeCartes(List<Carte> uneListe)
        {
            this.tatDeCartes = uneListe;
        }
        //Fin fonctions//

        public void ResetRangee(string uneRange)
        {
            switch (uneRange)
            {
                case "A":
                    this.GetRangeeA().Clear();
                    break;
                case "B":
                    this.GetRangeeB().Clear();
                    break;
                case "C":
                    this.GetRangeeC().Clear();
                    break;
                case "D":
                    this.GetRangeeD().Clear();
                    break;
                case "E":
                    this.GetRangeeE().Clear();
                    break;
            }
        }

        public int nombreDeCarteCouleur(string uneRange,string nomDeCarte)
        {
            int compteur = 0;
            
            switch(uneRange)
            {
                case "A":
                    foreach (Carte c in this.rangeeA)
                    {
                        if (c.GetNom() == nomDeCarte)
                        {
                            compteur = compteur + 1;
                        }
                    }
                  
                    break;
                case "B":
                    compteur = 0;
                    foreach (Carte c in this.rangeeB)
                    {
                        if (c.GetNom() == nomDeCarte)
                        {
                            compteur = compteur + 1;

                        }
                    }
                    break;
                   
                case "C":
                    compteur = 0;
                    foreach (Carte c in this.rangeeC)
                    {
                        if (c.GetNom() == nomDeCarte)
                        {
                            compteur = compteur + 1;

                        }
                    }
                    break;
                case "D":
                    compteur = 0;
                    foreach (Carte c in this.rangeeD)
                    {
                        if (c.GetNom() == nomDeCarte)
                        {
                            compteur = compteur + 1;
                        }
                    }
                  
                    break;
                case "E":
                    compteur = 0;
                    foreach (Carte c in this.rangeeE)
                    {
                        if (c.GetNom() == nomDeCarte)
                        {
                            compteur = compteur + 1;

                        }
                    }
                    break;
            }
            return compteur;
        }
       
    }
}
