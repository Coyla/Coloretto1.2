using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coloretto1._2
{
    public class Partie
    {
        static int countId;
        private int id { get; set; }
        private List<Manche> mesManches { get; set; }

        private string nomGagnant { get; set; }

        public Partie()
        {
            countId++;

            this.id = countId;
            mesManches = new List<Manche>();
            nomGagnant = "";
        }

        public int GetId()
        {
            return this.id;
        }

        public List<Manche> GetManches()
        {
            return this.mesManches;
        }

        public string GetGagnant()
        {
            return this.nomGagnant;
        }
        public void AjouterManche(Manche uneManche)
        {
            this.mesManches.Add(uneManche);
        }
        
    }
}
