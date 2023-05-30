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
    public partial class Sections : KryptonForm
    {
        public Sections()
        {
            InitializeComponent();
        }

        private void cmdEntrer_Click(object sender, EventArgs e)
        {
            if (nomSectionTextBox.Text == "Nom de la section")
            {
                MessageBox.Show("Donnez un nom à la section", "Info Message");
            }
            else
            {
                MySqlConnection myconnection = new MySqlConnection("datasource=localhost; username=root; password=");
                string myquery = "INSERT INTO studonote.section (nom) VALUES  ('" + nomSectionTextBox.Text + "')";
                MySqlCommand mycommand = new MySqlCommand(myquery, myconnection);
                MySqlDataReader myreader;

                myconnection.Open();
                myreader = mycommand.ExecuteReader();
                MessageBox.Show("Section créée !", "Info Message");
                myconnection.Close();
            }
        }

        private void nomSectionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Accueil Accueil = new Accueil();
            Accueil.Show();
        }
    }
}
