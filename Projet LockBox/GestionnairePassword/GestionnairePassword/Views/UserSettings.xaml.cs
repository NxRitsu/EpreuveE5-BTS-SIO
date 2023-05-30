using GestionnairePassword.Data;
using GestionnairePassword.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using GestionnairePassword.Views;

namespace GestionnairePassword.Views;

public partial class UserSettings : ContentPage
{
	Login login = new Login();
    public UserSettings()
	{
		InitializeComponent();
    }

	private async void Change_Clicked(object sender, EventArgs e)
	{
		login.Connexion(OldPassword.Text);
		if(login.Connexion(OldPassword.Text) == true)
		{
			login.SupprimerMotDePasse();
			login.Inscription(NewPassword.Text);
            await DisplayAlert("Succès", "Mot de passe changé", "OK");
        }else if(login.Connexion(OldPassword.Text) == false)
		{
            await DisplayAlert("Erreur", "L'ancien mot de passe n'est pas le bon", "OK");
        }

    }
}