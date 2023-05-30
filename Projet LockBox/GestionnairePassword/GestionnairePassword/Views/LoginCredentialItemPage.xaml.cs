using GestionnairePassword.Data;
using GestionnairePassword.Models;
using GestionnairePassword.Views;
using System.Security.Cryptography;
using System.Text;

namespace GestionnairePassword.Views;

[QueryProperty("Item", "Item")]
public partial class LoginCredentialItemPage : ContentPage
{
    private readonly Database database;

    public LoginCrendential Item
    {
        get => BindingContext as LoginCrendential;
        set => BindingContext = value;
    }

    public LoginCredentialItemPage(Database database)
    {
        InitializeComponent();

        this.database = database;

        if(Générateur.GeneratedPassword == null)
        {
            RecupPassword.IsVisible = false;
        }else if(Générateur.GeneratedPassword != null)
        {
            RecupPassword.IsVisible = true;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (Item.Id == 0)
        {
            Title = "Ajouter un mot de passe";
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Website))
        {
            await DisplayAlert("Site obligatoire", "Renseignez un sie internet", "OK");
            return;
        }

        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..", true);
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..", true);
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.Id == 0)
        {
            return;
        }

        var answer = await DisplayAlert("Alerte", "Voulez vraiment supprimer le mot de passe ?", "Oui", "Non");

        if (answer)
        {
            await database.DeleteItemAsync(Item);
            await Shell.Current.GoToAsync("..", true);
        }
    }

    private void OnPasswordFocused(object sender, FocusEventArgs e)
    {
        if (e.IsFocused)
            ((Entry)sender).IsPassword = false;
        else
            ((Entry)sender).IsPassword = true;
    }

    private void OnGeneratedClicked(object sender, EventArgs e)
    {
        Password.Text = Générateur.GeneratedPassword;
    }
}