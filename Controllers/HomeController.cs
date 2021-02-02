using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HellowWorld.Models;
using HellowWorld.Services.CharecterServices;
using Microsoft.AspNetCore.Mvc;

namespace HellowWorld.Controllers
{
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
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _charecterService.GetListOfChars());
        }
 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _charecterService.getNamebyID(id));  // filter data from the list -> linq
        }

        [HttpPost("AddCharecter")]
        public  async Task<IActionResult> AddCharecter(Charecter chars){
            
            return Ok(await _charecterService.addNewCharecter(chars));
        }
    }
}