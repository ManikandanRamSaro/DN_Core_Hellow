using System.Collections.Generic;
using System.Threading.Tasks;
using HellowWorld.Dtos.Charecter;
using HellowWorld.Models;
namespace HellowWorld.Services.CharecterServices
{
    public interface ICharecterServices
    {
         Task<ServiceResponse<List<GetCharecterDto>>> GetListOfChars();

         Task<ServiceResponse<GetCharecterDto>> getNamebyID(int id);

         Task<ServiceResponse<List<GetCharecterDto>>> addNewCharecter(AddCharecterDto obj);

         //Task<> is multi thread object
    }
}