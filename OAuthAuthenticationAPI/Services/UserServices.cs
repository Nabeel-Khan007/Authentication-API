using OAuthAuthenticationAPI.Models;

namespace OAuthAuthenticationAPI.Services
{
    public class UserServices
    {
        private List<User> _users = new List<User>
        {
            new User { Username = "user1", Password = "password1", Role = "player", Scopes = new[] { "b_game" } },
            new User { Username = "admin", Password = "adminpass", Role = "admin", Scopes = new[] { "b_game", "vip_chararacter_personalize" } }
        };

        public User Authenticate(string username, string password)
        {
            return _users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
