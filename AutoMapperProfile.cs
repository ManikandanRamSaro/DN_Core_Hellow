using System.Linq;
using AutoMapper;
using HellowWorld.Dtos.Charecter;
using HellowWorld.Dtos.Skill;
using HellowWorld.Dtos.Weapon;
using HellowWorld.Models;

namespace HellowWorld
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Charecter,GetCharecterDto>()  // here we configure source and destionation of Class mapping
                .ForMember(cs => cs.Skills, s => s.MapFrom(c => c.CharecterSkills.Select(c => c.Skills)));
            CreateMap<AddCharecterDto,Charecter>();
            CreateMap<Weapon,GetWeaponDto>();
            CreateMap<Skill,GetSkillDto>();
        }
    }
}