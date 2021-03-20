using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        
        private IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        [HttpPost]
        public IActionResult Register(UserforRegisterDTO registerDto)
        {
            IResult userExists = _auth.UserExists(registerDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }

            var registerResult = _auth.Register(registerDto);
            var tokenResult = _auth.CreateAccessToken(registerResult.Data);
            if (tokenResult.Success)
            {
                return Ok(tokenResult);
            }
            return BadRequest(tokenResult);
        }

        [HttpPost("login")]
        public IActionResult Login(UserforLoginDTO loginDto)
        {
            var userResult = _auth.Login(loginDto);
            if (!userResult.Success)
            {
                return BadRequest(userResult);
            }

            var tokenResult = _auth.CreateAccessToken(userResult.Data);
            if (tokenResult.Success)
            {
                return Ok(tokenResult);
            }

            return BadRequest(tokenResult);

        }


    }
}