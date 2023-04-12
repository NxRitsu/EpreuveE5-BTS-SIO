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
using System.Web;
using System.Net.Mail;
using System.Net;

namespace StudoNote
{
    public partial class Etudiants : KryptonForm
    {
        public Etudiants()
        {
            InitializeComponent();
        }

        private void Etudiants_Load(object sender, EventArgs e)
        {
            voirMdp.Hide();
        }

        private void hideMdp_Click(object sender, EventArgs e)
        {
            hideMdp.Hide();
            passwordEtudiantTextBox.PasswordChar = '●';
            voirMdp.Show();
        }

        private void voirMdp_Click(object sender, EventArgs e)
        {
            voirMdp.Hide();
            passwordEtudiantTextBox.PasswordChar = (char)0;
            hideMdp.Show();
        }

        private void cmdEntrer_Click(object sender, EventArgs e)
        {
           MySqlConnection connection = new MySqlConnection("datasource=localhost; username=root; password=");

            string query = "SELECT COUNT(*) FROM studonote.etudiant WHERE identifiant = @identifiant";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@identifiant", identifiantTextBox.Text);

            connection.Open();

            int count = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            if(count > 0)
            {
                MessageBox.Show("L'identifiant existe déjà", "Info Message");

            }
            else
            {
                if (sectionEtudiantTextBox.Text == "Section" || nomEtudiantTextBox.Text == "Nom" || prenomEtudiantTextBox.Text == "Prénom" || emailEtudiantTextBox.Text == "Adresse email scolaire" || passwordEtudiantTextBox.Text == "Mot de passe")
                {
                    MessageBox.Show("Remplissez l'intégralité des cases", "Info Message");
                }
                else
                {
                    MySqlConnection myconnection = new MySqlConnection("datasource=localhost; username=root; password=");
                    string myquery = "INSERT INTO studonote.etudiant (nom, prenom, identifiant, email, password, idSection) VALUES  ('" + nomEtudiantTextBox.Text + "', '" + prenomEtudiantTextBox.Text + "','" + identifiantTextBox.Text + "','" + emailEtudiantTextBox.Text + "',sha1('" + passwordEtudiantTextBox.Text + "'),(SELECT idSection FROM studonote.section WHERE nom = '" + sectionEtudiantTextBox.Text + "'))";
                    MySqlCommand mycommand = new MySqlCommand(myquery, myconnection);
                    MySqlDataReader myreader;

                    myconnection.Open();
                    myreader = mycommand.ExecuteReader();
                    MessageBox.Show("Etudiant créé !", "Info Message");
                    myconnection.Close();
                }
                try
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.Credentials = new NetworkCredential("studonote@gmail.com", "hqqwunnmsyxqeexy");
                    client.EnableSsl = true;

                    client.Send("studonote@gmail.com", emailEtudiantTextBox.Text, "Vos coordonnées Studonote", "Bonjour " + prenomEtudiantTextBox.Text + ", voici les identifiants de connexions Studonote ! \n Identifiant : " + identifiantTextBox.Text + " \n Adresse email : " + emailEtudiantTextBox.Text + "\n Mot de passe : " + passwordEtudiantTextBox.Text + " \n \n Il est important que tu ne donne pas ton mot de passe à personne ! (ne pas répondre à ce message)");

                    MessageBox.Show("Mail envoyé !", "Info Message");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Envoi du mail impossible : " + ex);
                }
            }
        }

        private void cmdListeSections_Click(object sender, EventArgs e)
        {
            afficherListeSections afficherListeSections = new afficherListeSections();
            afficherListeSections.Show();
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Accueil Accueil = new Accueil();
            Accueil.Show();
        }

        private void cmdListeEtudiants_Click(object sender, EventArgs e)
        {
            afficherListeEtudiants afficherListeEtudiants = new afficherListeEtudiants();
            afficherListeEtudiants.Show();
        }
    }
}
