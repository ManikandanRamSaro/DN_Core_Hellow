using AutoMapper;
using HellowWorld.Dtos.Charecter;
using HellowWorld.Models;

namespace HellowWorld
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Charecter,GetCharecterDto>();  // here we configure source and destionation of Class mapping
            CreateMap<AddCharecterDto,Charecter>();
        }
    }
}