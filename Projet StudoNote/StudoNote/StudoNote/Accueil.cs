using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace StudoNote
{
    public partial class Accueil : KryptonForm
    {
        public Accueil()
        {
            InitializeComponent();
        }

        private void cmdSections_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sections Sections = new Sections();
            Sections.Show();
        }

        private void cmdEtudiants_Click(object sender, EventArgs e)
        {
            this.Close();
            Etudiants Etudiants = new Etudiants();
            Etudiants.Show();
        }

        private void cmdViescolaire_Click(object sender, EventArgs e)
        {
            this.Hide();
            Viescolaire Viescolaire = new Viescolaire();
            Viescolaire.Show();
        }

        private void cmdSupprimer_Click(object sender, EventArgs e)
        {
            this.Hide();
            SupprimerNote Supprimer = new SupprimerNote();
            Supprimer.Show();
        }
    }
}
