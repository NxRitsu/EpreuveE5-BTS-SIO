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
    public partial class Viescolaire : KryptonForm
    {
        public Viescolaire()
        {
            InitializeComponent();
        }

        private void Viescolaire_Load(object sender, EventArgs e)
        {
            matiereComboBox.Items.Add("Mathématiques");
            matiereComboBox.Items.Add("Français");
            matiereComboBox.Items.Add("Droit");
            matiereComboBox.Items.Add("Économie");
            matiereComboBox.Items.Add("Anglais");
            matiereComboBox.Items.Add("Cybersécurité");
            matiereComboBox.Items.Add("Algorithme");

            matiereComboBox.SelectedIndex = 0;

            //Affichage des étudiants 

            string connString = "Server=localhost;Database=studonote;Uid=root;Pwd=";
            string Query = "SELECT idEtudiant, nom, prenom FROM etudiant";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(); sda.SelectCommand = cmd;
            DataTable dbtable = new DataTable();
            sda.Fill(dbtable);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dbtable;
            listeEtudiantsDataGridView.DataSource = bsource;
            sda.Update(dbtable);
        }

        private void cmdConfirm_Click(object sender, EventArgs e)
        {
            if (idEtudiantNote.Text == "ID de l'étudiant"|| noteTextBox.Text == "Note sur 20")
            {
                MessageBox.Show("Remplissez l'intégralité des cases", "Info Message");
            }
            else
            {
                MySqlConnection myconnection = new MySqlConnection("datasource=localhost; username=root; password=");
                string myquery = "INSERT INTO studonote.note (matiere, resultat, idEtudiant) VALUES  ('" + matiereComboBox.Text + "', '" + noteTextBox.Text + "','" + idEtudiantNote.Text + "')";
                MySqlCommand mycommand = new MySqlCommand(myquery, myconnection);
                MySqlDataReader myreader;

                myconnection.Open();
                myreader = mycommand.ExecuteReader();
                MessageBox.Show("Note insérée !", "Info Message");
                myconnection.Close();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (idAbsenceEtudiant.Text == "ID de l'étudiant" || motifAbsence.Text == "Motif de l'absence")
            {
                MessageBox.Show("Remplissez l'intégralité des cases", "Info Message");
            }
            else
            {
                MySqlConnection myconnection = new MySqlConnection("datasource=localhost; username=root; password=");
                string myquery = "INSERT INTO studonote.absence (date, motif, idEtudiant) VALUES  ('" +dateAbsence.Value.ToString("yyyy-MM-dd") + "', '" + motifAbsence.Text + "','" + idAbsenceEtudiant.Text + "')";
                MySqlCommand mycommand = new MySqlCommand(myquery, myconnection);
                MySqlDataReader myreader;

                myconnection.Open();
                myreader = mycommand.ExecuteReader();
                MessageBox.Show("Absence insérée !", "Info Message");
                myconnection.Close();
            }

        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Accueil Accueil = new Accueil();
            Accueil.Show();
        }
    }
}
