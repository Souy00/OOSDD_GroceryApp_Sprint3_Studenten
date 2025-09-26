
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;


namespace Grocery.App.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly GlobalViewModel _global;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private string loginMessage = string.Empty;

        public LoginViewModel(IAuthService authService, GlobalViewModel global)
        { //_authService = App.Services.GetServices<IAuthService>().FirstOrDefault();
            _authService = authService;
            _global = global;
        }

        [RelayCommand]
        private void Login()
        {
            Client? authenticatedClient = _authService.Login(Email, Password);
            if (authenticatedClient != null)
            {
                LoginMessage = $"Welkom {authenticatedClient.Name}!";
                _global.Client = authenticatedClient;
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                LoginMessage = "Ongeldige inloggegevens.";
            }
        }
        [RelayCommand]
        private void Register()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                LoginMessage = "Vul alle velden in om te registreren";
                return;
            }

            Client newClient = new Client
            {
                Name = Name,
                Email = Email,
                Password = Password
            };

            bool success = _authService.Register(newClient);
            LoginMessage = success ? "Registratie gelukt! Je kan nu inloggen." : "Registratie mislukt. Gebruiker bestaat al";
        }
    }
    
}    

