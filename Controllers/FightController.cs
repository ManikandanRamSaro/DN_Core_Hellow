using System.Threading.Tasks;
using HellowWorld.Dtos.Fight;
using HellowWorld.Services.FightService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HellowWorld.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FightController : ControllerBase
    {
        private readonly IFightService _fightService;

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }

        [HttpPost("Weapon")]
        public async Task<IActionResult> WeaponAttack(WeaponAttachDto request){
            return Ok(await _fightService.WeaponAttack(request));
        }
        
        [HttpPost("Skill")]
        public async Task<IActionResult> SkillAttack(SkillAttackDto request){
            return Ok(await _fightService.SkillAttack(request));
        }
    }
}