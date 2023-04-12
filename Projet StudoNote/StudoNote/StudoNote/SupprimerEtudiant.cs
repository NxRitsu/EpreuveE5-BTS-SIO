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
    public partial class SupprimerEtudiant : KryptonForm
    {
        public SupprimerEtudiant()
        {
            InitializeComponent();
        }

        private void notesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SupprimerNote SupprimerNote = new SupprimerNote();
            SupprimerNote.Show();
        }

        private void sectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SupprimerSection SupprimerSection = new SupprimerSection();
            SupprimerSection.Show();
        }

        private void absencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SupprimerAbsence SupprimerAbsence = new SupprimerAbsence();
            SupprimerAbsence.Show();
        }

        private void cmdSupprimer_Click(object sender, EventArgs e)
        {
            MySqlConnection myconnection2 = new MySqlConnection("datasource=localhost; username=root; password=");
            string myquery2 = "DELETE FROM studonote.absence WHERE idEtudiant = " + idEtudiantTextBox.Text;
            MySqlCommand mycommand2 = new MySqlCommand(myquery2, myconnection2);
            MySqlDataReader myreader2;

            myconnection2.Open();
            myreader2 = mycommand2.ExecuteReader();
            myconnection2.Close();

            MySqlConnection myconnection1 = new MySqlConnection("datasource=localhost; username=root; password=");
            string myquery1 = "DELETE FROM studonote.note WHERE idEtudiant = " + idEtudiantTextBox.Text;
            MySqlCommand mycommand1 = new MySqlCommand(myquery1, myconnection1);
            MySqlDataReader myreader1;

            myconnection1.Open();
            myreader1 = mycommand1.ExecuteReader();
            myconnection1.Close();

            MySqlConnection myconnection = new MySqlConnection("datasource=localhost; username=root; password=");
            string myquery = "DELETE FROM studonote.etudiant WHERE idEtudiant = " + idEtudiantTextBox.Text;
            MySqlCommand mycommand = new MySqlCommand(myquery, myconnection);
            MySqlDataReader myreader;

            myconnection.Open();
            myreader = mycommand.ExecuteReader();
            MessageBox.Show("Etudiant supprimé", "Info Message");
            myconnection.Close();
            actualiser();
        }

        private void actualiser()
        {
            string connString = "Server=localhost;Database=studonote;Uid=root;Pwd=";
            string Query = "SELECT idEtudiant, nom, prenom FROM etudiant";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(); sda.SelectCommand = cmd;
            DataTable dbtable = new DataTable();
            sda.Fill(dbtable);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dbtable;
            listeEtudiantDataGridView.DataSource = bsource;
            sda.Update(dbtable);
        }

        private void SupprimerEtudiant_Load(object sender, EventArgs e)
        {
            string connString = "Server=localhost;Database=studonote;Uid=root;Pwd=";
            string Query = "SELECT idEtudiant, nom, prenom FROM etudiant";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(); sda.SelectCommand = cmd;
            DataTable dbtable = new DataTable();
            sda.Fill(dbtable);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dbtable;
            listeEtudiantDataGridView.DataSource = bsource;
            sda.Update(dbtable);
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Accueil Accueil = new Accueil();
            Accueil.Show();
        }
    }
}
