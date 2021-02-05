using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HellowWorld.Data;
using HellowWorld.Dtos.Charecter;
using HellowWorld.Dtos.Weapon;
using HellowWorld.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HellowWorld.Services.WeaponServices
{
    public class WeaponServices : IWeaponServices
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public WeaponServices(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;

        } 

        private int GetUserID() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<GetCharecterDto>> AddWeapons(AddWeaponDto addWeapon)
        {
            ServiceResponse<GetCharecterDto> response = new ServiceResponse<GetCharecterDto>();
            try
            {
                int userid=GetUserID();
                Charecter chars = await _context.charecters.
                            FirstOrDefaultAsync(x => x.Id == addWeapon.CharecterId && x.Users.Id== GetUserID());
                if(chars==null)
                {
                    response.Success=false;
                    response.Message="Charecter not found";
                    return response;
                }
                Weapon weapon= new Weapon{
                    Name = addWeapon.Name,
                    Damage = addWeapon.Damage,
                    charecter = chars
                };
                await _context.Weapons.AddAsync(weapon);
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