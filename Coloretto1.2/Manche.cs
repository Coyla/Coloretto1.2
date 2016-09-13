using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coloretto1._2
{
    public class Manche
    {
        static int countId;
        private int id;
        private TableDeJeu maTable;
        private List<Joueur> listeJoueurs;

        public Manche()
        {
            countId++;
            this.id = countId;
            maTable = new TableDeJeu();
            listeJoueurs = new List<Joueur>();
 
        }

        public Manche(List<Joueur> listeJoueurs, TableDeJeu maTable)
        {
            // TODO: Complete member initialization
            this.listeJoueurs = new List<Joueur>(listeJoueurs) ;
            this.maTable = maTable;
            countId++;
            this.id = countId;
        }

        public int GetId()
        {
            return this.id;
        }

        public List<Joueur> GetJoueurs()
        {
            return this.listeJoueurs;
        }

        public TableDeJeu GetTable()
        {
            return this.maTable;
        }

        public void AjouterTable(TableDeJeu uneTable)
        {
            this.maTable = uneTable;
        }
        public void Ajouter(List<Joueur> uneListe)
        {
            this.listeJoueurs = uneListe;
        }
    }
}
