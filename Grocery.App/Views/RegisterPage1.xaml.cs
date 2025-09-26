using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm; // Use the same ViewModel for registration
    }
}

