using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Get()
        {
            return Ok(_charecterService.GetListOfChars());
        }
 
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(_charecterService.getNamebyID(id));  // filter data from the list -> linq
        }

        [HttpPost("AddCharecter")]
        public IActionResult AddCharecter(Charecter chars){
            
            return Ok(_charecterService.addNewCharecter(chars));
        }
    }
}