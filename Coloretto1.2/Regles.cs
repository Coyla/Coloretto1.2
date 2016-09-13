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
    public partial class Regles : Form
    {
        public Regles()
        {
            InitializeComponent();
        }

        private void btRetour_Click(object sender, EventArgs e)
        {
            Home form = new Home();
            form.Show();
            this.Close();
        }
    }
}
