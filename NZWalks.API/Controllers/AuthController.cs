using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }


        // GET: api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginDTO loginRequest)
        {
            //Validate Request

            //Check User is Authenticate
            var userAuthen = await _userRepository.getUserAsync(loginRequest.Username, loginRequest.Password);
            if(userAuthen == null)
            {
                return BadRequest("Invalid Username or Password");
            }

            //Generate token
            var token = await _tokenHandler.CreateTokenAsync(userAuthen);
            return Ok(token);
        }

    }
}
