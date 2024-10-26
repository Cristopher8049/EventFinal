using AutoMapper;
using EventManagement.DTO;
using EventManagement.Model;

namespace EventManagement.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            #region User
            CreateMap<User, UserDto>()
                .ForMember(target => target.RolName, opt => opt.MapFrom(source => source.Role!.Name));

            CreateMap<UserDto, User>()
                .ForMember(target => target.Role, opt => opt.Ignore());
            #endregion

        }
    }
}
