using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Entity;

namespace NZWalks.API.Repository
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User userRequest);
    }
}
