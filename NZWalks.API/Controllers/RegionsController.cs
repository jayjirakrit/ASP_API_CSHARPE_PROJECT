using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _RegionRepository;
        private readonly IMapper _Mapper;

        public RegionsController(IRegionRepository RegionRepository, IMapper Mapper)
        {
            _RegionRepository = RegionRepository;
            _Mapper = Mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _RegionRepository.GetAllRegionsAsync();
            var regionsDTO = _Mapper.Map<List<RegionDTO>>(regions);
            return Ok(regionsDTO);
        }


    }
}
