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
        public async Task<List<Charecter>> addNewCharecter(Charecter objOfClass)
        {
             knights.Add(objOfClass);
             return knights;
        }

        public async Task<List<Charecter>> GetListOfChars()
        {
             return knights;
        }

        public async Task<Charecter> getNamebyID(int id)
        {
             return knights.FirstOrDefault(x =>x.Id==id);
        }
    }
}