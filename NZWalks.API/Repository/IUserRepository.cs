using NZWalks.API.Models.Entity;

namespace NZWalks.API.Repository
{
    public interface IUserRepository
    {
        Task<User> getUserAsync(string Username, string Password);
    }
}
