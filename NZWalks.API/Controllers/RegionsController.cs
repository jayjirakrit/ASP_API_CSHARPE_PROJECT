using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Entity;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await _regionRepository.GetAllRegionsAsync();
            var regionsDTO = _mapper.Map<List<RegionDTO>>(regions);
            return Ok(regionsDTO);
        }


        [HttpGet]
        [Authorize(Roles = "reader")]
        [Route("{id:guid}")]
        [ActionName(nameof(GetRegionByIdAsync))]
        public async Task<IActionResult> GetRegionByIdAsync(Guid id)
        {
            var region = await _regionRepository.GetRegionByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = _mapper.Map<RegionDTO>(region);

            return Ok(regionDTO);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddRegionAsync(AddRegionDTO addRequestRegion)
        {
            if (!await ValidateAddRegionAsync(addRequestRegion))
            {
                return BadRequest(ModelState);
            }

            var region = new Region()
            {
                Code = addRequestRegion.Code,
                Name = addRequestRegion.Name,
                Area = addRequestRegion.Area,
                Lat = addRequestRegion.Lat,
                Long = addRequestRegion.Long,
                Population = addRequestRegion.Population
            };
            region = await _regionRepository.AddRegionAsync(region);

            var regionDTO = _mapper.Map<RegionDTO>(region);

            return CreatedAtAction(nameof(GetRegionByIdAsync), new { id = regionDTO.RegionId }, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await _regionRepository.DeleteRegionAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = _mapper.Map<RegionDTO>(region);
            return Ok(regionDTO);
        }

        [HttpPatch]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateRegionAsync(Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
            var region = new Region()
            {
                Code = updateRegionDTO.Code,
                Name = updateRegionDTO.Name,
                Area = updateRegionDTO.Area,
                Lat = updateRegionDTO.Lat,
                Long = updateRegionDTO.Long,
                Population = updateRegionDTO.Population
            };

            region = await _regionRepository.UpdateRegionAsync(id, region);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = _mapper.Map<RegionDTO>(region);
            return Ok(regionDTO);
        }

        #region Private Method
        private async Task<bool> ValidateAddRegionAsync(AddRegionDTO addRequestRegion)
        {
            if(addRequestRegion == null)
            {
                ModelState.AddModelError(nameof(addRequestRegion), $"{nameof(addRequestRegion)} cannot be empty or white space.");
                return false;
            }
            var regions = await _regionRepository.GetAllRegionsAsync();
            if(regions.Any(r => r.Name.Equals(addRequestRegion.Name)))
            {
                ModelState.AddModelError(nameof(addRequestRegion.Name), $"{nameof(addRequestRegion.Name)} cannot be duplicate.");
                return false;
            }
            return true;
        }

        #endregion  
    }
}
