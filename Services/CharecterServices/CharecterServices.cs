using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HellowWorld.Dtos.Charecter;
using HellowWorld.Models;

namespace HellowWorld.Services.CharecterServices
{
    public class CharecterServices : ICharecterServices
    {
        private static List<Charecter> knights = new List<Charecter>{
            new Charecter{ Id=1,Name="Sai" },
            new Charecter { Id=2,Name="Shree"}
        };
        private readonly IMapper _mapper;
         public CharecterServices(IMapper mapper)
         {
            _mapper = mapper;
         }

        public async Task<ServiceResponse<List<GetCharecterDto>>> addNewCharecter(AddCharecterDto objOfClass)
        {             
             ServiceResponse<List<GetCharecterDto>> serviceResponse = new ServiceResponse<List<GetCharecterDto>>();
             
             Charecter chars= _mapper.Map<Charecter>(objOfClass);
             chars.Id=knights.Max(ob=>ob.Id)+1;  // getting max id and incrementing it using LINQ
             knights.Add(chars);

             serviceResponse.data=(knights.Select(ob=>_mapper.Map<GetCharecterDto>(ob))).ToList();   // this select all data and convert to dto object and make it List          
             return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharecterDto>>> deleteCharecter(int id)
        {
           ServiceResponse<List<GetCharecterDto>> serviceResponse = new ServiceResponse<List<GetCharecterDto>>();
            try 
            {

            
            Charecter chars= knights.First(da=>da.Id==id); 
            knights.Remove(chars);

            serviceResponse.data=(knights.Select(ob=>_mapper.Map<GetCharecterDto>(ob))).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message; 
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharecterDto>>> GetListOfChars()
        {
             ServiceResponse<List<GetCharecterDto>> serviceResponse = new ServiceResponse<List<GetCharecterDto>>();
             serviceResponse.data=(knights.Select(ob=>_mapper.Map<GetCharecterDto>(ob))).ToList();
             return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharecterDto>> getNamebyID(int id)
        {
             ServiceResponse<GetCharecterDto> serviceResponse = new ServiceResponse<GetCharecterDto>();
             serviceResponse.data = _mapper.Map<GetCharecterDto>(knights.FirstOrDefault(x=>x.Id==id)); 
             return serviceResponse;        
        }
        public async Task<ServiceResponse<GetCharecterDto>> updateCharecter(UpdateCharecterDto obj)
        {
            ServiceResponse<GetCharecterDto> serviceResponse = new ServiceResponse<GetCharecterDto>();
            try 
            {

            
            Charecter chars= knights.FirstOrDefault(da=>da.Id==obj.Id);
            chars.Name=obj.Name;
            chars.Intelligence=obj.Intelligence;
            chars.Class=obj.Class;
            chars.Defence=obj.Defence;
            chars.HitPoints=obj.HitPoints;
            chars.Strength=obj.Strength; 

            serviceResponse.data=_mapper.Map<GetCharecterDto>(chars);
            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message; 
            }
            return serviceResponse;
        }   
         
    }
}