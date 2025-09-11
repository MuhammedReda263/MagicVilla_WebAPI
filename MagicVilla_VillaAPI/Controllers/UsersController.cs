using Asp.Versioning;
using Azure;
using MagicVilla_VillaAPI.Modles;
using MagicVilla_VillaAPI.Modles.DTOs;
using MagicVilla_VillaAPI.Repository.IRepostiory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersionNeutral]
    public class UsersController : ControllerBase
    {
        IUserRepository _userRepository;
        APIResponse APIResponse { get; set; }
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            APIResponse = new();

        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] LoginRequestDTO loginDTO)
        {
            var loginRespons = await _userRepository.Login(loginDTO);
            if(loginRespons.User == null || string.IsNullOrEmpty(loginRespons.Token))
            {
                APIResponse.StatusCode = HttpStatusCode.BadRequest;
                APIResponse.IsSuccess = false;
                APIResponse.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(APIResponse);
            }
            APIResponse.StatusCode = HttpStatusCode.OK;
            APIResponse.IsSuccess = true;
            APIResponse.Result = loginRespons;
            return Ok(APIResponse);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDTO model)
        {
            bool ifUserNameUnique = _userRepository.IsUniqueUser(model.UserName);
            if (ifUserNameUnique)
            {
                APIResponse.StatusCode = HttpStatusCode.BadRequest;
                APIResponse.IsSuccess = false;
                APIResponse.ErrorMessages.Add("Username already exists");
                return BadRequest(APIResponse);
            }

            var user = await _userRepository.Register(model);
            if (user == null)
            {
                APIResponse.StatusCode = HttpStatusCode.BadRequest;
                APIResponse.IsSuccess = false;
                APIResponse.ErrorMessages.Add("Error while registering");
                return BadRequest(APIResponse);
            }
            APIResponse.StatusCode = HttpStatusCode.OK;
            APIResponse.IsSuccess = true;
            return Ok(APIResponse);
        }
    }
}
