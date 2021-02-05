using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HellowWorld.Dtos.Charecter;
using HellowWorld.Models;
using HellowWorld.Services.CharecterServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HellowWorld.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]

    // ctor -> constructor short cut
    public class HomeController : ControllerBase
    {
        private readonly ICharecterServices _charecterService;  // create and assign field for "service name" on constructor object

        // private static Charecter knight= new Charecter(); // getting single

        public HomeController(ICharecterServices charecterService)
       {
            _charecterService = charecterService;
        }
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            int id = int.Parse(User.Claims.FirstOrDefault(x=>x.Type==ClaimTypes.NameIdentifier).Value);  
            return Ok(await _charecterService.GetListOfChars(id));
        }
 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _charecterService.getNamebyID(id));  // filter data from the list -> linq
        }

        [HttpPost("AddCharecter")]
        public  async Task<IActionResult> AddCharecter(AddCharecterDto chars){
            
            return Ok(await _charecterService.addNewCharecter(chars));
        }

        [HttpPut("updateCharecter")]
        public  async Task<IActionResult> updateCharecter(UpdateCharecterDto chars){
            
            return Ok(await _charecterService.updateCharecter(chars));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteRecord(int id)
        {
            ServiceResponse<List<GetCharecterDto>> response=await _charecterService.deleteCharecter(id);
            if(response.data==null)
            {
                return NotFound(response);
            }
            return Ok(response);  // filter data from the list -> linq
        }
    }
}