using GestionnairePassword.Data;
using GestionnairePassword.Models;
using GestionnairePassword.Views;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using SecureStorage = Microsoft.Maui.Storage.SecureStorage;

namespace GestionnairePassword.Views;

public partial class LoginCredentialListPage : ContentPage
{
    private readonly Database database;
    Login login = new Login();

    public ObservableCollection<LoginCrendential> Items { get; set; } = new();

    public LoginCredentialListPage(Database database)
    {
        InitializeComponent();

        this.database = database;

        BindingContext = this;

        Shell.SetTabBarIsVisible(this, false); // Cache la TabBar

        if(login.ChargerMotDePasse() == null)
        {
            InscriptionButton.IsVisible = true;
            LoginButton.IsVisible = false;
        }
        else
        {
            InscriptionButton.IsVisible = false;
            LoginButton.IsVisible = true;
        }

        //Cache le bouton pour supprimer le mot de passe enregistré
        DeleteButton.IsVisible = false;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var items = await database.GetItemsAsync();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in items)
                Items.Add(item);
        });
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not LoginCrendential item)
            return;

        await Shell.Current.GoToAsync(nameof(LoginCredentialItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }

    private async void OnItemAdd(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LoginCredentialItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new LoginCrendential()
        });
    }


    //Connexion et inscription

    public void Inscription_Clicked(object sender, EventArgs e)
    {
        login.Inscription(EntryMotDePasse.Text);

        // Afficher un message de succès
        DisplayAlert("Succès", "Mot de passe enregistré avec succès", "OK");

        Form.IsVisible = false;
        Liste.IsVisible = true;
        AddButton.IsVisible = true;
        Logo.IsVisible = false;
        Shell.SetTabBarIsVisible(this, true); // Affiche la TabBar
    }

    public async void Connexion_Clicked(object sender, EventArgs e)
    {
        login.Connexion(EntryMotDePasse.Text);

        // Vérifier si les mots de passe hachés correspondent
        if (login.Connexion(EntryMotDePasse.Text) == true)
        {
            // Afficher un message de connexion réussie
            await DisplayAlert("Succès", "Connexion réussie", "OK");
            Form.IsVisible = false;
            Liste.IsVisible = true;
            AddButton.IsVisible = true;
            Logo.IsVisible = false;
            Shell.SetTabBarIsVisible(this, true); // Affiche la TabBar
        }
        else
        {
            // Afficher un message d'échec de connexion
            await DisplayAlert("Erreur", "Mot de passe incorrect", "OK");
        }
    }

    public async void Delete_Clicked(object sender, EventArgs e)
    {
        login.SupprimerMotDePasse();
        await DisplayAlert("Succès", "Mot de passe supprimé", "OK");
    }
}
