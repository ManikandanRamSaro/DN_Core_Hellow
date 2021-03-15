using System.Threading.Tasks;
using HellowWorld.Dtos.Fight;
using HellowWorld.Models;

namespace HellowWorld.Services.FightService
{
    public interface IFightService
    {
         Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttachDto request);
    }
}