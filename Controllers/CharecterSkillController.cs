using System.Threading.Tasks;
using HellowWorld.Dtos.CharecterSkill;
using HellowWorld.Services.CharecterSkillService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HellowWorld.Controllers
{   
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharecterSkillController : ControllerBase
    {
        private readonly ICharecterSkillService _charecterSkillService;
        public CharecterSkillController(ICharecterSkillService charecterSkillService)
        {
            _charecterSkillService = charecterSkillService;
        }

        [HttpPost]

        public async Task<IActionResult> addCharecterSkills(AddCharecterSkillDto addCharecterSkill)
        {
            return Ok(await _charecterSkillService.AddCharecterSkill(addCharecterSkill));
        }  
    }
}