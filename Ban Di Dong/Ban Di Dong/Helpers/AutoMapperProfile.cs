using AutoMapper;
using Ban_Di_Dong.Data;
using Ban_Di_Dong.ViewModels;

namespace Ban_Di_Dong.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<RegisterVM, TbUser>();
        }
    }
}
