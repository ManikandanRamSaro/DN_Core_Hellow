using System;
using System.Linq;
using System.Threading.Tasks;
using HellowWorld.Data;
using HellowWorld.Dtos.Fight;
using HellowWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace HellowWorld.Services.FightService
{
    public class FightService : IFightService
    {
        private readonly DataContext _context;

        public FightService(DataContext  context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttachDto request)
        {
            ServiceResponse<AttackResultDto> response = new ServiceResponse<AttackResultDto>();
            try{
                Charecter attacker = await _context.charecters.Include(chars => chars.Weapons)
                                                        .FirstOrDefaultAsync(c => c.Id == request.AttackerId);
                Charecter opponent = await _context.charecters.FirstOrDefaultAsync(c => c.Id == request.OpponentId);

                int damage = int.Parse(attacker.Weapons.Damage) + (new Random().Next(attacker.Strength));
                damage-= new Random().Next(opponent.Defence);
                if(damage>0)
                    opponent.HitPoints-=damage;
                if(opponent.HitPoints<=0)
                    response.Message = $"{opponent.Name} has been defeated !";

                _context.charecters.Update(opponent);
                await _context.SaveChangesAsync();

                response.data = new AttackResultDto{
                    Attacker = attacker.Name,
                    AttackerHP = attacker.HitPoints.ToString(),
                    Opponent = opponent.Name,
                    OpponentHP = opponent.HitPoints.ToString(),
                    Damage =damage


                };
            }
            catch(Exception ex)
            {
                response.Message= ex.Message;
                response.Success = false;
            }
            return response;
        }

        
        public async Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request)
        {
             ServiceResponse<AttackResultDto> response = new ServiceResponse<AttackResultDto>();
            try{
                Charecter attacker = await _context.charecters.Include(chars => chars.CharecterSkills).ThenInclude(cs => cs.Skills)
                                                        .FirstOrDefaultAsync(c => c.Id == request.AttackerId);
                Charecter opponent = await _context.charecters.FirstOrDefaultAsync(c => c.Id == request.OpponentId);

                CharecterSkill charecterSkill=
                        attacker.CharecterSkills.FirstOrDefault(cs => cs.Skills.Id == request.SkillId);

                if(charecterSkill == null)
                {
                    response.Message= $"{attacker.Name} does not known Skil";
                    response.Success = false;
                    return response;
                }
                int damage = int.Parse(charecterSkill.Skills.Damage) + (new Random().Next(attacker.Intelligence));
                damage-= new Random().Next(opponent.Defence);
                if(damage>0)
                    opponent.HitPoints-=damage;
                if(opponent.HitPoints<=0)
                    response.Message = $"{opponent.Name} has been defeated !";

                _context.charecters.Update(opponent);
                await _context.SaveChangesAsync();

                response.data = new AttackResultDto{
                    Attacker = attacker.Name,
                    AttackerHP = attacker.HitPoints.ToString(),
                    Opponent = opponent.Name,
                    OpponentHP = opponent.HitPoints.ToString(),
                    Damage =damage


                };
            }
            catch(Exception ex)
            {
                response.Message= ex.ToString();
                response.Success = false;
            }
            return response;
        }
    }
}