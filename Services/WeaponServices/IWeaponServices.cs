using System.Threading.Tasks;
using HellowWorld.Dtos.Charecter;
using HellowWorld.Dtos.Weapon;
using HellowWorld.Models;

namespace HellowWorld.Services.WeaponServices
{
    public interface IWeaponServices
    {
         Task<ServiceResponse<GetCharecterDto>> AddWeapons(AddWeaponDto addWeapon);
    }
}