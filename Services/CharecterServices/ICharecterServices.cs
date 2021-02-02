using System.Collections.Generic;
using System.Threading.Tasks;
using HellowWorld.Models;
namespace HellowWorld.Services.CharecterServices
{
    public interface ICharecterServices
    {
         Task<List<Charecter>> GetListOfChars();

         Task<Charecter> getNamebyID(int id);

         Task<List<Charecter>> addNewCharecter(Charecter obj);

         //Task<> is multi thread object
    }
}