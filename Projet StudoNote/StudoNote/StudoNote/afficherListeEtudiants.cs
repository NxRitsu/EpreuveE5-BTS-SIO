﻿using System;
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
    public partial class afficherListeEtudiants : KryptonForm
    {
        public afficherListeEtudiants()
        {
            InitializeComponent();
        }

        private void afficherListeEtudiants_Load(object sender, EventArgs e)
        {
            string connString = "Server=localhost;Database=studonote;Uid=root;Pwd=";
            string Query = "SELECT * FROM etudiant";
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
    }
}
