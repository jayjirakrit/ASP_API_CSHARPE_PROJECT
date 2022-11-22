using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Entity;

namespace NZWalks.API.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _DbContext;

        public RegionRepository(NZWalksDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            return await _DbContext.Regions.ToListAsync();
        }
    }
}
