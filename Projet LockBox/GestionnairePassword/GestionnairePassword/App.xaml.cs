using GestionnairePassword.Views;
using GestionnairePassword.Models;
using GestionnairePassword.Data;
using Application = Microsoft.Maui.Controls.Application;

namespace GestionnairePassword;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        MainPage = new AppShell();
        //MainPage = new LoginPage();
        //MainPage = new NavigationPage(new LoginPage());
        //NavigationPage.SetHasBackButton(MainPage, false);
    }
}
