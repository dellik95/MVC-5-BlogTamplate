using AutoMapper;
using MVC_5_BlogTamplate.Dto;
using MVC_5_BlogTamplate.Models;

namespace MVC_5_BlogTamplate.App_Start
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
        }
    }
}