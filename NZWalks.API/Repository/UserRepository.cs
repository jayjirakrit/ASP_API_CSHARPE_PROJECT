using NZWalks.API.Data;
using NZWalks.API.Models.Entity;

namespace NZWalks.API.Repository
{
    public class UserRepository : IUserRepository

    {

        public async Task<User> getUserAsync(string Username, string Password)
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Name = "FName LName",
                    Email = "Email",
                    Password = "Password",
                    Roles = new List<string>{"reader"}
                },
                new User()
                {
                    Id = 2,
                    Name = "FName LName",
                    Email = "Email2",
                    Password = "Password2",
                   Roles = new List<string>{"reader", "writer" }
                }
            };

            var user = users.Find(u => u.Email.Equals(Username) && u.Password.Equals(Password));
            if (user == null)
                return null;

            return user;


        }
    }
}
