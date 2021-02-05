using System.Threading.Tasks;
using HellowWorld.Dtos.Weapon;
using HellowWorld.Services.WeaponServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HellowWorld.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponServices _weaponServices;
        public WeaponController(IWeaponServices weaponServices)
        {
            _weaponServices = weaponServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddWeapon(AddWeaponDto addWeapon)
        {
            return Ok(await _weaponServices.AddWeapons(addWeapon));
        }
    }
}