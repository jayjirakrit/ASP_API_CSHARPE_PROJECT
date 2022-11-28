using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Entity;

namespace NZWalks.API.Repository
{
    public class UserRepository : IUserRepository

    {
        private readonly NZWalksDbContext _dbContext;

        public UserRepository(NZWalksDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<User> getUserAsync(string Username, string Password)
        {
            var user = await _dbContext.Users.
                Include(x => x.User_Role)
                .FirstOrDefaultAsync(u => u.Email.ToLower().Equals(Username.ToLower()) && u.Password.Equals(Password));
            if (user == null)
                return null;
            return user;

        }
    }
}
