using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Entity;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public  async Task<IActionResult> GetAllWalksAsync()
        {
            var walks = await _walkRepository.GetAllWalksAsync();
            var walksDTO = _mapper.Map<List<WalkDTO>>(walks);
            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName(nameof(GetWalkAsync))]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            var walk = await _walkRepository.GetWalkAsync(id);
            if(walk == null)
            {
                return NotFound();
            }

            var walkDTO = _mapper.Map<WalkDTO>(walk);

            return Ok(walkDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync(AddWalkDTO addWalkRequest)
        {
            var walk = new Walk()
            {
                Name = addWalkRequest.Name,
                Length = addWalkRequest.Length,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultyId = addWalkRequest.WalkDifficultyId
            };

            walk = await _walkRepository.AddWalkAsync(walk);

            var walkDTO = _mapper.Map<WalkDTO>(walk);
            return CreatedAtAction(nameof(GetWalkAsync), new { id = walkDTO.Id}, walkDTO);

        }


    }
}
