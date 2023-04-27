using GestionnairePassword.Views;

namespace GestionnairePassword;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(LoginCredentialItemPage), typeof (LoginCredentialItemPage));
        Routing.RegisterRoute(nameof(Générateur), typeof(Générateur));
    }
}
