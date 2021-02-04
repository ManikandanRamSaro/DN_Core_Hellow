using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HellowWorld.Data;
using HellowWorld.Dtos.Charecter;
using HellowWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace HellowWorld.Services.CharecterServices
{
    public class CharecterServices : ICharecterServices
    {
        private static List<Charecter> knights = new List<Charecter>{
            new Charecter{ Id=1,Name="Sai" },
            new Charecter { Id=2,Name="Shree"}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _contect;
        public CharecterServices(IMapper mapper, DataContext contect)
        {
            _mapper = mapper;            
            _contect = contect;
        }

        public async Task<ServiceResponse<List<GetCharecterDto>>> addNewCharecter(AddCharecterDto objOfClass)
        {
            ServiceResponse<List<GetCharecterDto>> serviceResponse = new ServiceResponse<List<GetCharecterDto>>();

            Charecter chars = _mapper.Map<Charecter>(objOfClass);
            // chars.Id = knights.Max(ob => ob.Id) + 1;  // getting max id and incrementing it using LINQ
            // knights.Add(chars);
            await _contect.charecters.AddAsync(chars);
            await _contect.SaveChangesAsync();
            serviceResponse.data = (_contect.charecters.Select(ob => _mapper.Map<GetCharecterDto>(ob))).ToList();   // this select all data and convert to dto object and make it List          
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharecterDto>>> deleteCharecter(int id)
        {
            ServiceResponse<List<GetCharecterDto>> serviceResponse = new ServiceResponse<List<GetCharecterDto>>();
            try
            {


                Charecter chars = await _contect.charecters.FirstAsync(da => da.Id == id);
                _contect.charecters.Remove(chars);
                await _contect.SaveChangesAsync();
                serviceResponse.data = (_contect.charecters.Select(ob => _mapper.Map<GetCharecterDto>(ob))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharecterDto>>> GetListOfChars()
        {
            ServiceResponse<List<GetCharecterDto>> serviceResponse = new ServiceResponse<List<GetCharecterDto>>();
            List<Charecter> charlist = await _contect.charecters.ToListAsync(); // getting data from database
            serviceResponse.data = (charlist.Select(ob => _mapper.Map<GetCharecterDto>(ob))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharecterDto>> getNamebyID(int id)
        {
            ServiceResponse<GetCharecterDto> serviceResponse = new ServiceResponse<GetCharecterDto>();
            Charecter chars= await _contect.charecters.SingleOrDefaultAsync(x=>x.Id==id);
            serviceResponse.data = _mapper.Map<GetCharecterDto>(chars);
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetCharecterDto>> updateCharecter(UpdateCharecterDto obj)
        {
            ServiceResponse<GetCharecterDto> serviceResponse = new ServiceResponse<GetCharecterDto>();
            try
            {


                Charecter chars = await _contect.charecters.FirstOrDefaultAsync(da => da.Id == obj.Id);
                chars.Name = obj.Name;
                chars.Intelligence = obj.Intelligence;
                chars.Class = obj.Class;
                chars.Defence = obj.Defence;
                chars.HitPoints = obj.HitPoints;
                chars.Strength = obj.Strength;

                _contect.Update(chars);
                await _contect.SaveChangesAsync();

                serviceResponse.data = _mapper.Map<GetCharecterDto>(chars);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

    }
}