using System.Collections.Generic;
using System.Threading.Tasks;
using HellowWorld.Models;
namespace HellowWorld.Services.CharecterServices
{
    public interface ICharecterServices
    {
         Task<ServiceResponse<List<Charecter>>> GetListOfChars();

         Task<ServiceResponse<Charecter>> getNamebyID(int id);

         Task<ServiceResponse<List<Charecter>>> addNewCharecter(Charecter obj);

         //Task<> is multi thread object
    }
}