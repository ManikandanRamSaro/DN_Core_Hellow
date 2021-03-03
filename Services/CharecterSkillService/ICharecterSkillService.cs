using System.Threading.Tasks;
using HellowWorld.Dtos.Charecter;
using HellowWorld.Dtos.CharecterSkill;
using HellowWorld.Models;

namespace HellowWorld.Services.CharecterSkillService
{
    public interface ICharecterSkillService
    {
         Task<ServiceResponse<GetCharecterDto>> AddCharecterSkill(AddCharecterSkillDto addCharecterSkill);
    }
}