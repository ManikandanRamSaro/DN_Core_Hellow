using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HellowWorld.Models;

namespace HellowWorld.Services.CharecterServices
{
    public class CharecterServices : ICharecterServices
    {
         private static List<Charecter> knights = new List<Charecter>{
            new Charecter{ Id=1,Name="Sai" },
            new Charecter { Id=2,Name="Shree"}
        };
        public async Task<ServiceResponse<List<GetCharecterDto>>> addNewCharecter(Charecter objOfClass)
        {
             knights.Add(objOfClass);
             ServiceResponse<List<GetCharecterDto>> serviceResponse = new ServiceResponse<List<GetCharecterDto>>();
             serviceResponse.data=knights;             
             return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharecterDto>>> GetListOfChars()
        {
             ServiceResponse<List<GetCharecterDto>> serviceResponse = new ServiceResponse<List<GetCharecterDto>>();
             serviceResponse.data=knights;
             return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharecterDto>> getNamebyID(int id)
        {
             ServiceResponse<GetCharecterDto> serviceResponse = new ServiceResponse<GetCharecterDto>();
             serviceResponse.data=knights.FirstOrDefault(x =>x.Id==id);
             return serviceResponse;
        }
    }
}