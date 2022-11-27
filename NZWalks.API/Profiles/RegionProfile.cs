using AutoMapper;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Entity;

namespace NZWalks.API.Profiles
{
    public class RegionProfile: Profile
    {

        public RegionProfile()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
        }
    }
}
