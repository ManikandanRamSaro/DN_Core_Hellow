using System.Threading.Tasks;
using HellowWorld.Data;
using HellowWorld.Dtos.Users;
using HellowWorld.Models;
using Microsoft.AspNetCore.Mvc;

namespace HellowWorld.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authrepo;
        public AuthController(IAuthRepository authrepo)
        {
            _authrepo = authrepo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto user)
        {
            ServiceResponse<int> response= await _authrepo.Register(new User{ UserName=user.UserName},user.Password);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
           
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto user)
        {
            ServiceResponse<string> response= await _authrepo.Login(user.userName,user.password);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}