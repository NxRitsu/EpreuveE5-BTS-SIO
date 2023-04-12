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
using MySql.Data.MySqlClient;

namespace StudoNote
{
    public partial class SupprimerSection : KryptonForm
    {
        public SupprimerSection()
        {
            InitializeComponent();
        }

        private void SupprimerSection_Load(object sender, EventArgs e)
        {
            string connString = "Server=localhost;Database=studonote;Uid=root;Pwd=";
            string Query = "SELECT idSection, nom FROM section";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(); sda.SelectCommand = cmd;
            DataTable dbtable = new DataTable();
            sda.Fill(dbtable);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dbtable;
            listeSectionsDataGridView.DataSource = bsource;
            sda.Update(dbtable);
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Accueil Accueil = new Accueil();
            Accueil.Show();
        }

        private void sectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SupprimerNote SupprimerNote = new SupprimerNote();
            SupprimerNote.Show();
        }

        private void actualiser()
        {
            string connString = "Server=localhost;Database=studonote;Uid=root;Pwd=";
            string Query = "SELECT idSection, nom FROM section";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(); sda.SelectCommand = cmd;
            DataTable dbtable = new DataTable();
            sda.Fill(dbtable);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dbtable;
            listeSectionsDataGridView.DataSource = bsource;
            sda.Update(dbtable);
        }

        private void cmdSupprimer_Click(object sender, EventArgs e)
        {
            MySqlConnection myconnection = new MySqlConnection("datasource=localhost; username=root; password=");
            string myquery = "DELETE FROM studonote.section WHERE idSection = " + idSectionTextBox.Text;
            MySqlCommand mycommand = new MySqlCommand(myquery, myconnection);
            MySqlDataReader myreader;

            myconnection.Open();
            myreader = mycommand.ExecuteReader();
            MessageBox.Show("Section supprimée", "Info Message");
            myconnection.Close();
            actualiser();
        }

        private void etudiantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SupprimerEtudiant SupprimerEtudiant = new SupprimerEtudiant();
            SupprimerEtudiant.Show();
        }

        private void absencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SupprimerAbsence SupprimerAbsence = new SupprimerAbsence();
            SupprimerAbsence.Show();
        }
    }
}
