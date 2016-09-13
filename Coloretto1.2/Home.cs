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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void btJouer_Click(object sender, EventArgs e)
        {
            Parametres_nom fenetre = new Parametres_nom();
            fenetre.Show();
            this.Hide();
        }

        private void btRegles_Click(object sender, EventArgs e)
        {
            Regles form = new Regles();
            this.Hide();
            form.Show();
        }
    }
}
