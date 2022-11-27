using AutoMapper;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Entity;

namespace NZWalks.API.Profiles
{
    public class WalkProfile: Profile
    {

        public WalkProfile()
        {
            CreateMap<Walk, WalkDTO>().ReverseMap();
            CreateMap<WalkDifficulty, WalkDifficultyDTO>().ReverseMap();
        }
    }
}
