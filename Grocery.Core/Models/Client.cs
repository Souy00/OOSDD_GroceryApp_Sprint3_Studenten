
namespace Grocery.Core.Models
{
    public partial class Client : Model
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Client(): base(0, string.Empty) { }



        public Client(int id, string name, string email, string password) : base(id, name)
        {
            Email=email;
            Password = password;
        }
    }
}
