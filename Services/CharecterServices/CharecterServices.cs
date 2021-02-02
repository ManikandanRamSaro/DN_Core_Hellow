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
        public async Task<ServiceResponse<List<Charecter>>> addNewCharecter(Charecter objOfClass)
        {
             knights.Add(objOfClass);
             ServiceResponse<List<Charecter>> serviceResponse = new ServiceResponse<List<Charecter>>();
             serviceResponse.data=knights;             
             return serviceResponse;
        }

        public async Task<ServiceResponse<List<Charecter>>> GetListOfChars()
        {
             ServiceResponse<List<Charecter>> serviceResponse = new ServiceResponse<List<Charecter>>();
             serviceResponse.data=knights;
             return serviceResponse;
        }

        public async Task<ServiceResponse<Charecter>> getNamebyID(int id)
        {
             ServiceResponse<Charecter> serviceResponse = new ServiceResponse<Charecter>();
             serviceResponse.data=knights.FirstOrDefault(x =>x.Id==id);
             return serviceResponse;
        }
    }
}