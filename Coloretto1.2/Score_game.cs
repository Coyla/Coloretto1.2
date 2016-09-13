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
    public partial class Score_game : Form
    {
        List<Joueur> listeDeJoueurs;
        Partie maPartie;
        public Score_game(List<Joueur> uneListe, Partie unePartie)
        {
            listeDeJoueurs = new List<Joueur>(uneListe);
            maPartie = unePartie;
            InitializeComponent();
        }



        public void MettreAJourDataGrid()
        {
            
            for (int j = 0; j < listeDeJoueurs.Count; j++)
            {
                
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgScore);
                row.Cells[0].Value = listeDeJoueurs[j].GetNom();
                for ( int i = 0; i<maPartie.GetManches().Count;i++)
                {
                    
                    row.Cells[i+1].Value = maPartie.GetManches()[i].GetJoueurs()[j].GetScoreManche().ToString();
                    
                    
                }
                dgScore.Rows.Add(row);
                
            }

            foreach (DataGridViewRow item in dgScore.Rows)
            {
                int n = item.Index;
                if (maPartie.GetManches().Count == 1)
                {
                    dgScore.Rows[n].Cells[4].Value = (Convert.ToInt16(dgScore.Rows[n].Cells[1].Value)).ToString();
                }
                else if (maPartie.GetManches().Count == 2)
                {
                    dgScore.Rows[n].Cells[4].Value = (Convert.ToInt16(dgScore.Rows[n].Cells[1].Value) + Convert.ToInt16(dgScore.Rows[n].Cells[2].Value)).ToString();
                }
                else if (maPartie.GetManches().Count == 3)
                {
                    dgScore.Rows[n].Cells[4].Value = (Convert.ToInt16(dgScore.Rows[n].Cells[1].Value) + Convert.ToInt16(dgScore.Rows[n].Cells[2].Value) + Convert.ToInt16(dgScore.Rows[n].Cells[3]).ToString());
                }
            }
            
            

           
        }

        public string GetGagnat()
        {
            string gagnant = "";
            int max = Convert.ToInt16(dgScore.Rows[0].Cells[4].Value.ToString());
            for (int i = 0; i < dgScore.Rows.Count-1; ++i)
            {
                
                
                int max1 = Convert.ToInt16(dgScore.Rows[i + 1].Cells[4].Value.ToString());
                if (max < max1)
                {
                   max = Convert.ToInt16(dgScore.Rows[i+1].Cells[4].Value.ToString());
                }
                
            }
            foreach (DataGridViewRow row in dgScore.Rows)
            {
                if ((Convert.ToInt16(row.Cells[4].Value).ToString()).Equals(max.ToString()))
                {
                    gagnant = row.Cells[0].Value.ToString();
                }
            }

            return gagnant;
            
        }

        

        private void Score_game_Load(object sender, EventArgs e)
        {
           
            MettreAJourDataGrid();
            lbAnnonceGagnant.Text = GetGagnat();
        }

        private void lbRejouer_Click(object sender, EventArgs e)
        {
            Home form = new Home();
            form.Show();
            this.Close();
        }

 
        
    }
}
