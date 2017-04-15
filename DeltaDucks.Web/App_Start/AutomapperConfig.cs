using AutoMapper;
using DeltaDucks.Models;
using DeltaDucks.Web.Dtos;
using DeltaDucks.Web.ViewModels;
using DeltaDucks.Web.ViewModels.Account;

namespace DeltaDucks.Web
{
    public class AutomapperConfig
    {
        public static void Config()
        {
            // TODO : Add more mappings
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RegisterViewModel, ApplicationUser>()
                    .ForMember(u => u.UserName, map => map.MapFrom(vm => vm.UserName))
                    .ForMember(u => u.FirstName, map => map.MapFrom(vm => vm.FirstName))
                    .ForMember(u => u.LastName, map => map.MapFrom(vm => vm.LastName))
                    .ForMember(u => u.Email, map => map.MapFrom(vm => vm.Email));

                cfg.CreateMap<ApplicationUser, RegisterViewModel>();
                cfg.CreateMap<ApplicationUser, LoginViewModel>();
                cfg.CreateMap<LoginViewModel, ApplicationUser>();
                cfg.CreateMap<ResetPasswordViewModel, ApplicationUser>();
                cfg.CreateMap<Landmark, LandmarkViewModel>();
                cfg.CreateMap<LandmarkViewModel, Landmark>();

                cfg.CreateMap<Landmark, LandmarkToMapDto>()
                    .ForMember(dest => dest.title,
                        opt => opt.MapFrom(src =>
                            $"<a href=\"/Landmark/Details?number={src.Number}\">" + src.Name + "</a>"))
                    .ForMember(dest => dest.position,
                        opt => opt.MapFrom(src => src.Location));

                cfg.CreateMap<Location, LocationToMapDto>()
                    .ForMember(dest => dest.lat, opt => opt.MapFrom(src => src.Latitude))
                    .ForMember(dest => dest.lng, opt => opt.MapFrom(src => src.Longitude));
            });
        }
    }
}