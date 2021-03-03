using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HellowWorld.Data;
using HellowWorld.Dtos.Charecter;
using HellowWorld.Dtos.CharecterSkill;
using HellowWorld.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HellowWorld.Services.CharecterSkillService
{
    public class CharecterSkillService : ICharecterSkillService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public CharecterSkillService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public int userID() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<GetCharecterDto>> AddCharecterSkill(AddCharecterSkillDto addCharecterSkill)
        {
            ServiceResponse<GetCharecterDto> response=new ServiceResponse<GetCharecterDto>();
            try 
            {
                Charecter chars= await _context.charecters
                            .Include(c =>c.Weapons)
                            .Include(c =>c.CharecterSkills)
                            .ThenInclude(we => we.Skills)
                            .FirstOrDefaultAsync(c => c.Id == addCharecterSkill.CharecterId &&
                                        c.Users.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                if(chars==null)
                {                    
                    response.Success=false;
                    response.Message="No Charecter Record found";
                    return response;
                }

                Skill skill = await _context.Skills.SingleOrDefaultAsync(s => s.Id==addCharecterSkill.SkillId);
                if(skill==null)
                {                    
                    response.Success=false;
                    response.Message="No skill Record found";
                    return response;
                }

                CharecterSkill charecter= new CharecterSkill{
                    charecters=chars,
                    Skills=skill
                };
                await _context.CharecterSkills.AddAsync(charecter);

                await _context.SaveChangesAsync();

                response.data = _mapper.Map<GetCharecterDto>(chars);

            }
            catch(Exception e)
            {
                response.Success=false;
                response.Message=e.Message;
            }
            return response;
        }
    }
}