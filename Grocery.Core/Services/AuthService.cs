using Grocery.Core.Models;
using Grocery.Core.Interfaces.Services;

namespace Grocery.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly List<Client> _clients = new();

        public AuthService()
        {
            // Voorbeeld gebruiker
            _clients.Add(new Client(1, "User3", "user3@mail.com", "user3"));
        }

        public Client? Login(string email, string password)
        {
            return _clients.FirstOrDefault(c => c.Email == email && c.Password == password);
        }

        public bool Register(Client client)
        {
            if (_clients.Any(c => c.Email == client.Email))
                return false; // gebruiker bestaat al

            client.Id = _clients.Count + 1;
            _clients.Add(client);
            return true;
        }
    }
}
