using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Coloretto1._2
{
    public class Carte
    {
        static int idCount = 0;
        private int id;
        private string nom;
        private Image imageCarte;
        

        public Carte(string unNom, Image uneImage)
        {
            nom = unNom;
            idCount++;
            id = idCount;
            imageCarte = uneImage;
            
            
        }

        public Carte(string unNom)
        {
            nom = unNom;
            idCount++;
            id = idCount;
        }

        public int GetId()
        {
            return this.id;
        }
        public string GetNom()
        {
            return this.nom;
        }

        public Image GetImageCarte()
        {
            return this.imageCarte;
        }
      
    }
}
