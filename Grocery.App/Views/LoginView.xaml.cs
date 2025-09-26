using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }

	private async void OnRegisterClicked(object sender, EventArgs e)
	{
		if (BindingContext is LoginViewModel vm && Navigation != null)
		{
			await Navigation.PushAsync(new RegisterPage(vm));
		}
	}
}	